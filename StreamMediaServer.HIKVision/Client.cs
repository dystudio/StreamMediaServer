using StreamMediaServer.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StreamMediaServer.HIKVision
{
    public static class Client
    {
        private static List<VideoModel> _videos = new List<VideoModel>();
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
                var _video = new VideoModel()
                {
                    IP = ip,
                    Port = port,
                    Channel = 1
                };

                //取得推流句柄
                _video.RTMPHandle = LKRtmp.LKRtmp_Init(rtmp);
                if (_video.RTMPHandle <= 0)
                {
                    Console.WriteLine("取得推流句柄失败");
                    return;
                }

                //同步登陆
                NET_DVR_DEVICEINFO_V30 deviceInfo = new NET_DVR_DEVICEINFO_V30();
                _video.UserHandle = CHCNetSDK.NET_DVR_Login_V30(ip, port, username, password, ref deviceInfo);

                if (_video.UserHandle < 0)
                {
                    Console.WriteLine("登陆失败，错误码：" + CHCNetSDK.NET_DVR_GetLastError());
                    LKRtmp.LKRtmp_Fini(_video.RTMPHandle);
                    return;
                }

                var sn = Encoding.UTF8.GetString(deviceInfo.sSerialNumber);
                Console.WriteLine($"IP:{ip}, SN: {sn}");

                var previewInfo = new NET_DVR_PREVIEWINFO
                {
                    hPlayWnd = IntPtr.Zero,//预览窗口 live view window
                    lChannel = _video.Channel,//预览的设备通道 the device channel number
                    dwStreamType = 0,//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
                    dwLinkMode = 0,//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
                    bBlocked = true, //0- 非阻塞取流，1- 阻塞取流
                    dwDisplayBufNum = 15 //播放库显示缓冲区最大帧数
                };

                //开视播放                   
                _video.RealHandle = CHCNetSDK.NET_DVR_RealPlay_V40(_video.UserHandle
                    , ref previewInfo
                    , (iRealHandle, dwDataType, pBuffer, dwBufSize, pUser) =>
                    {
                        var video = _videos.Find(d => d.RealHandle == iRealHandle);
                        if (video == null)
                        {
                            CHCNetSDK.NET_DVR_StopRealPlay(iRealHandle);
                            return;
                        }

                        //lRealHandle和CHCNetSDK.NET_DVR_RealPlay_V40返回值是一样的
                        if (dwDataType == 1)  //数据头
                        {
                            //海康私有协议头，只有第一次调用是为1                            
                        }
                        else if (dwDataType == 2)
                        {
                            var head = Marshal.ReadInt32(pBuffer, 0);
                            if (head == -1174339584) //0x00, 0x00, 0x01, 0xBA = -1174339584   PS包
                            {
                                /*如果收到PS包头，表示的是接下来的数据是一个新的PS包，上一个PS数据包接收完成*/

                                if (video.Buffer.Count > 0)
                                {
                                    //Marshal.AllocHGlobal 分配内存 使用完成后一定要使用Marshal.FreeHGlobal 释放，否则会造成内存泄漏
                                    var arr = new byte[video.Buffer.Count];
                                    Array.Copy(video.Buffer.ToArray(), arr, video.Buffer.Count);
                                    var tuple = new Tuple<int, byte[]>(video.RTMPHandle, arr);

                                    //异步推流
                                    Task.Factory.StartNew((obj)=> {
                                        var v = obj as Tuple<int, byte[]>;
                                        IntPtr p = Marshal.AllocHGlobal(v.Item2.Length);
                                        Marshal.Copy(v.Item2, 0, p, v.Item2.Length);
                                        var ts = (ulong)((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000);
                                        var result = LKRtmp.LKRtmp_PutData(v.Item1, 100, p, v.Item2.Length, ts, v.Item2[4] == 0x67 ? 1 : 0);
                                        if(result < 0)
                                        {
                                            Console.WriteLine("推流结果="+result);
                                        }
                                        Marshal.FreeHGlobal(p);
                                    }, tuple);
                                }
                                video.Buffer.Clear();
                            }
                            else if (-536805376 == head) //-536805376 = 0x00, 0x00, 0x01, 0xE0   视频
                            {
                                /*如果收到视频包则追加到缓存中*/
                                var skip = Marshal.ReadByte(pBuffer, 8) + 9;
                                var buff = new byte[dwBufSize - skip];
                                var pData = IntPtr.Add(pBuffer, skip);
                                Marshal.Copy(pData, buff, 0, (int)(dwBufSize - skip));
                                video.Buffer.AddRange(buff);
                            }
                            else if (-1073676288 == head)   //-1073676288 = 0x00, 0x00, 0x01, 0xC0  音频
                            {
                                /*如果收到音频包则追加到缓存中*/
                                var buff = new byte[dwBufSize];
                                Marshal.Copy(pBuffer, buff, 0, (int)dwBufSize);
                                //File.WriteAllBytes(inx++.ToString("000000"), buff);
                            }
                            else
                            {
                                //var t = BitConverter.GetBytes(head);
                                //Console.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] 未知包头:{t[0].ToString("X")} {t[1].ToString("X")} {t[2].ToString("X")} {t[3].ToString("X")}");
                            }
                        }
                    }
                    , IntPtr.Zero);


                if (_video.RealHandle < 0)
                {
                    Console.WriteLine("预览失败，错误码：" + CHCNetSDK.NET_DVR_GetLastError());
                    LKRtmp.LKRtmp_Fini(_video.RTMPHandle);
                    CHCNetSDK.NET_DVR_Logout_V30(_video.UserHandle);
                    return;
                }

                _videos.Add(_video);
            });
        }
    }
}
