using StreamMediaServer.Core;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StreamMediaServer.HIKVision
{
    public static class  Client
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        public static Task Init()
        {
            return Task.Run(() =>
            {
                var result = CHCNetSDK.NET_DVR_Init();
                if (!result)
                {
                    var errorCode = CHCNetSDK.NET_DVR_GetLastError();
                    throw new Exception($"初始化失败，错误码：{errorCode}");
                }
            });
        }

        /// <summary>
        /// 清理
        /// </summary>
        /// <returns></returns>
        public static Task Cleanup()
        {
            return Task.Run(() =>
            {
                CHCNetSDK.NET_DVR_Cleanup();
            });
        }

        /// <summary>
        /// 推流
        /// </summary>
        /// <param name="rtmp"></param>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static Task PullStream(string rtmp, string ip, int port, string username, string password)
        {
            return Task.Run(() =>
            {
                var rtmpId = -1;
                List<byte> buffer = new List<byte>();
                NET_DVR_DEVICEINFO_V30 deviceInfo = new NET_DVR_DEVICEINFO_V30();
                int playerId = -1;

                var userid = CHCNetSDK.NET_DVR_Login_V30(ip, port, username, password, ref deviceInfo);
                if (userid >= 0)
                {
                    var sn = Encoding.UTF8.GetString(deviceInfo.sSerialNumber);
                    Console.WriteLine("SN: " + sn);

                    var previewInfo = new NET_DVR_PREVIEWINFO();
                    previewInfo.hPlayWnd = IntPtr.Zero;//预览窗口 live view window
                    previewInfo.lChannel = 1;//预览的设备通道 the device channel number
                    previewInfo.dwStreamType = 0;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
                    previewInfo.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
                    previewInfo.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流
                    previewInfo.dwDisplayBufNum = 15; //播放库显示缓冲区最大帧数

                    playerId = CHCNetSDK.NET_DVR_RealPlay_V40(userid
                        , ref previewInfo
                        , (lRealHandle, dwDataType, pBuffer, dwBufSize, pUser) =>
                        {
                            if (dwDataType == 1)  //数据头
                            {
                                rtmpId = LKRtmp.LKRtmp_Init(rtmp);
                                Console.WriteLine("链接结果：" + rtmpId);
                            }
                            else if (dwDataType == 2)
                            {

                                var head = Marshal.ReadInt32(pBuffer, 0);
                                if (head == -1174339584) //0x00, 0x00, 0x01, 0xBA = -1174339584
                                {
                                    if (buffer.Count > 0)
                                    {
                                        IntPtr p = Marshal.AllocHGlobal(buffer.Count);
                                        Marshal.Copy(buffer.ToArray(), 0, p, buffer.Count);
                                        var ts = (ulong)((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000);
                                        var result = LKRtmp.LKRtmp_PutData(rtmpId, 100, p, buffer.Count, ts, buffer[4] == 0x67 ? 1 : 0);
                                    }
                                    buffer.Clear();
                                }
                                else if (-536805376 == head) //-536805376 = 0x00, 0x00, 0x01, 0xE0
                                {
                                    var skip = Marshal.ReadByte(pBuffer, 8) + 9;
                                    var buff = new byte[dwBufSize - skip];
                                    var pData = IntPtr.Add(pBuffer, skip);
                                    Marshal.Copy(pData, buff, 0, (int)(dwBufSize - skip));
                                    buffer.AddRange(buff);
                                }
                                else
                                {
                                    //var t = BitConverter.GetBytes(head);
                                    //Console.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] 未知包头:{t[0].ToString("X")} {t[1].ToString("X")} {t[2].ToString("X")} {t[3].ToString("X")}");
                                }
                            }
                        }
                        , IntPtr.Zero);


                    if (playerId < 0)
                    {
                        Console.WriteLine("预览失败，错误码：" + CHCNetSDK.NET_DVR_GetLastError());
                    }
                }
                else
                {
                    Console.WriteLine("登陆失败，错误码：" + CHCNetSDK.NET_DVR_GetLastError());
                }
                Console.ReadLine();
                if (playerId >= 0)
                {
                    CHCNetSDK.NET_DVR_StopRealPlay(playerId);
                    Console.WriteLine("停止预览");
                }

                if (userid >= 0)
                {
                    CHCNetSDK.NET_DVR_Logout_V30(userid);
                    Console.WriteLine("登出");
                }
            });
        }
    }
}
