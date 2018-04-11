/*
 
 */
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace StreamMediaServer.Core
{
    public class LibRTMP
    {
        /// <summary>
        /// 用于创建一个RTMP会话的句柄。
        /// </summary>
        /// <returns></returns>
        [DllImport("librtmp.dll")]
        public static extern int RTMP_Alloc();

        /// <summary>
        /// 初始化句柄
        /// </summary>
        /// <returns></returns>
        [DllImport("librtmp.dll")]
        public static extern int RTMP_Init();

        /// <summary>
        /// 设置会话的参数
        /// </summary>
        /// <returns></returns>
        [DllImport("librtmp.dll")]
        public static extern int RTMP_SetupURL();

        /// <summary>
        /// 建立RTMP链接中的网络连接（NetConnection）。
        /// </summary>
        /// <returns></returns>
        [DllImport("librtmp.dll")]
        public static extern int RTMP_Connect();

        /// <summary>
        /// 建立RTMP链接中的网络流（NetStream）
        /// </summary>
        /// <returns></returns>
        [DllImport("librtmp.dll")]
        public static extern int RTMP_ConnectStream();

        /// <summary>
        /// 读取RTMP流的内容。
        /// </summary>
        /// <returns></returns>
        [DllImport("librtmp.dll")]
        public static extern int RTMP_Read();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DllImport("librtmp.dll")]
        public static extern int RTMP_EnableWrite();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DllImport("librtmp.dll")]
        public static extern int RTMP_Write();

        /// <summary>
        /// 流播放的时候可以用于暂停和继续
        /// </summary>
        /// <returns></returns>
        [DllImport("librtmp.dll")]
        public static extern int RTMP_Pause();

        [DllImport("librtmp.dll")]
        public static extern int RTMP_Close();

        [DllImport("librtmp.dll")]
        public static extern int RTMP_Free();



        /*
            RTMPPacket_Alloc
            RTMPPacket_Dump
            RTMPPacket_Free
            RTMPPacket_Reset
            RTMPProtocolStrings
            RTMPProtocolStringsLower
            RTMPSockBuf_Close
            RTMPSockBuf_Fill
            RTMPSockBuf_Send
            RTMP_ClientPacket
            RTMP_Connect0
            RTMP_Connect1
            RTMP_DefaultFlashVer
            RTMP_DeleteStream
            RTMP_DropRequest
            RTMP_FindFirstMatchingProperty
            RTMP_FindPrefixProperty
            RTMP_GetDuration
            RTMP_GetNextMediaPacket
            RTMP_GetTime
            RTMP_HashSWF
            RTMP_IsConnected
            RTMP_IsTimedout
            RTMP_LibVersion
            RTMP_Log
            RTMP_LogGetLevel
            RTMP_LogHex
            RTMP_LogHexString
            RTMP_LogPrintf
            RTMP_LogSetCallback
            RTMP_LogSetLevel
            RTMP_LogSetOutput
            RTMP_LogStatus
            RTMP_ParsePlaypath
            RTMP_ParseURL
            RTMP_ReadPacket
            RTMP_ReconnectStream
            RTMP_SendChunk
            RTMP_SendClientBW
            RTMP_SendCreateStream
            RTMP_SendCtrl
            RTMP_SendPacket
            RTMP_SendPause
            RTMP_SendSeek
            RTMP_SendServerBW
            RTMP_Serve
            RTMP_SetBufferMS
            RTMP_SetOpt
            RTMP_SetupStream
            RTMP_Socket
            RTMP_TLS_Init
            RTMP_TLS_ctx
            RTMP_ToggleStream
            RTMP_UpdateBufferMS
            RTMP_UserInterrupt
            RTMP_ctrlC
            RTMP_debuglevel
            */

    }
}
