using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace StreamMediaServer.Core.LibRTMP
{
    public struct RTMP
    {
        int m_inChunkSize;
        int m_outChunkSize;
        int m_nBWCheckCounter;
        int m_nBytesIn;
        int m_nBytesInSent;
        int m_nBufferMS;
        int m_stream_id;        /* returned in _result from createStream */
        int m_mediaChannel;
        uint m_mediaStamp;
        uint m_pauseStamp;
        int m_pausing;
        int m_nServerBW;
        int m_nClientBW;
        byte m_nClientBW2;
        byte m_bPlaying;
        byte m_bSendEncoding;
        byte m_bSendCounter;

        int m_numInvokes;
        int m_numCalls;
        IntPtr m_methodCalls; /* remote method calls queue   RTMP_METHOD*/

        IntPtr m_vecChannelsIn;  //RTMPPacket数组指针，长度65600
        IntPtr m_vecChannelsOut;  //RTMPPacket数组指针，长度65600

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65600)]
        int[] m_channelTimestamp;  /* abs timestamp of last packet */

        double m_fAudioCodecs;  /* audioCodecs for the connect packet */
        double m_fVideoCodecs;  /* videoCodecs for the connect packet */
        double m_fEncoding;     /* AMF0 or AMF3 */

        double m_fDuration;     /* duration of stream in seconds */

        int m_msgCounter;       /* RTMPT stuff */
        int m_polling;
        int m_resplen;
        int m_unackd;
        //AVal m_clientID;

        RTMP_READ m_read;
        RTMPPacket m_write;
        RTMPSockBuf m_sb;
        RTMP_LNK Link;
    }
}
