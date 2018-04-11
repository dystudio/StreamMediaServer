/*
 
 */
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace StreamMediaServer.Core.LibRTMP
{
    public class LibRTMP
    {
        [DllImport("librtmp.dll")]
        public static extern void RTMPPacket_Reset(IntPtr rtmpPacket);
        [DllImport("librtmp.dll")]
        public static extern void RTMPPacket_Dump(IntPtr rtmpPacket);
        [DllImport("librtmp.dll")]
        public static extern int RTMPPacket_Alloc(IntPtr rtmpPacket, int nSize);
        [DllImport("librtmp.dll")]
        public static extern void RTMPPacket_Free(IntPtr rtmpPacket);

        //[DllImport("librtmp.dll")]
        //public static extern int RTMP_ParseURL(string url, ref int protocol, AVal* host, ref int port, AVal* playpath, AVal* app);

        //[DllImport("librtmp.dll")]
        //public static extern void RTMP_ParsePlaypath(AVal*in, AVal*out);
        [DllImport("librtmp.dll")]
        public static extern void RTMP_SetBufferMS(ref RTMP r, int size);
        [DllImport("librtmp.dll")]
        public static extern void RTMP_UpdateBufferMS(ref RTMP r);

        //[DllImport("librtmp.dll")]
        //public static extern int RTMP_SetOpt(ref RTMP r, const AVal* opt, AVal *arg);
        [DllImport("librtmp.dll")]
        public static extern int RTMP_SetupURL(ref RTMP r, string url);
        //[DllImport("librtmp.dll")]
        //public static extern void RTMP_SetupStream(ref RTMP r, 
        //    int protocol,
        //          AVal* hostname,
        //          unsigned int port,
        //          AVal* sockshost,
        //          AVal* playpath,
        //          AVal* tcUrl,
        //          AVal* swfUrl,
        //          AVal* pageUrl,
        //          AVal* app,
        //          AVal* auth,
        //          AVal* swfSHA256Hash,
        //          uint32_t swfSize,
        //          AVal* flashVer,
        //          AVal* subscribepath,
        //          int dStart,
        //          int dStop, int bLiveStream, long int timeout);

        [DllImport("librtmp.dll")]
        public static extern int RTMP_Connect(ref RTMP r, ref RTMPPacket cp);

        //[DllImport("librtmp.dll")]
        //public static extern int RTMP_Connect0(ref RTMP r, struct sockaddr *svc);
        //[DllImport("librtmp.dll")]
        //public static extern int RTMP_Connect1(ref RTMP r, ref RTMPPacket cp);

        [DllImport("librtmp.dll")]
        public static extern int RTMP_Serve(ref RTMP r);

        [DllImport("librtmp.dll")]
        public static extern int RTMP_ReadPacket(ref RTMP r, ref RTMPPacket packet);
        [DllImport("librtmp.dll")]
        public static extern int RTMP_SendPacket(ref RTMP r, ref RTMPPacket packet, int queue);
        [DllImport("librtmp.dll")]
        public static extern int RTMP_SendChunk(ref RTMP r, ref RTMPChunk chunk);
        [DllImport("librtmp.dll")]
        public static extern int RTMP_IsConnected(ref RTMP r);
        [DllImport("librtmp.dll")]
        public static extern int RTMP_Socket(ref RTMP r);
        [DllImport("librtmp.dll")]
        public static extern int RTMP_IsTimedout(ref RTMP r);
        [DllImport("librtmp.dll")]
        public static extern double RTMP_GetDuration(ref RTMP r);
        [DllImport("librtmp.dll")]
        public static extern int RTMP_ToggleStream(ref RTMP r);

        [DllImport("librtmp.dll")]
        public static extern int RTMP_ConnectStream(ref RTMP r, int seekTime);
        [DllImport("librtmp.dll")]
        public static extern int RTMP_ReconnectStream(ref RTMP r, int seekTime);
        [DllImport("librtmp.dll")]
        public static extern void RTMP_DeleteStream(ref RTMP r);
        [DllImport("librtmp.dll")]
        public static extern int RTMP_GetNextMediaPacket(ref RTMP r, ref RTMPPacket packet);
        [DllImport("librtmp.dll")]
        public static extern int RTMP_ClientPacket(ref RTMP r, ref RTMPPacket packet);

        [DllImport("librtmp.dll")]
        public static extern void RTMP_Init(ref RTMP r);
        [DllImport("librtmp.dll")]
        public static extern void RTMP_Close(ref RTMP r);
        [DllImport("librtmp.dll")]
        public static extern ref RTMP RTMP_Alloc();
        [DllImport("librtmp.dll")]
        public static extern void RTMP_Free(ref RTMP r);
        [DllImport("librtmp.dll")]
        public static extern void RTMP_EnableWrite(ref RTMP r);

        [DllImport("librtmp.dll")]
        public static extern int RTMP_LibVersion();
        [DllImport("librtmp.dll")]
        public static extern void RTMP_UserInterrupt();  /* user typed Ctrl-C */

        [DllImport("librtmp.dll")]
        public static extern int RTMP_SendCtrl(ref RTMP r, short nType, uint nObject, uint nTime);

        [DllImport("librtmp.dll")]
        public static extern int RTMP_SendPause(ref RTMP r, int DoPause, int dTime);
        [DllImport("librtmp.dll")]
        public static extern int RTMP_Pause(ref RTMP r, int DoPause);

        //[DllImport("librtmp.dll")]
        //public static extern int RTMP_FindFirstMatchingProperty(AMFObject* obj, const AVal* name, AMFObjectProperty * p);

        [DllImport("librtmp.dll")]
        public static extern int RTMPSockBuf_Fill(ref RTMPSockBuf sb);
        [DllImport("librtmp.dll")]
        public static extern int RTMPSockBuf_Send(ref RTMPSockBuf sb, string buf, int len);
        [DllImport("librtmp.dll")]
        public static extern int RTMPSockBuf_Close(ref RTMPSockBuf sb);

        [DllImport("librtmp.dll")]
        public static extern int RTMP_SendCreateStream(ref RTMP r);
        [DllImport("librtmp.dll")]
        public static extern int RTMP_SendSeek(ref RTMP r, int dTime);
        [DllImport("librtmp.dll")]
        public static extern int RTMP_SendServerBW(ref RTMP r);
        [DllImport("librtmp.dll")]
        public static extern int RTMP_SendClientBW(ref RTMP r);
        [DllImport("librtmp.dll")]
        public static extern void RTMP_DropRequest(ref RTMP r, int i, int freeit);
        [DllImport("librtmp.dll")]
        public static extern int RTMP_Read(ref RTMP r, string buf, int size);
        [DllImport("librtmp.dll")]
        public static extern int RTMP_Write(ref RTMP r, string buf, int size);

        /* hashswf.c */
        [DllImport("librtmp.dll")]
        public static extern int RTMP_HashSWF(string url, ref uint size, string hash, int age);


    }
}
