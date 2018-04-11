using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace StreamMediaServer.Core.LibRTMP
{
    public struct RTMP_LNK
    {
        //AVal hostname;
        //AVal sockshost;

        //AVal playpath0; /* parsed from URL */
        //AVal playpath;  /* passed in explicitly */
        //AVal tcUrl;
        //AVal swfUrl;
        //AVal pageUrl;
        //AVal app;
        //AVal auth;
        //AVal flashVer;
        //AVal subscribepath;
        //AVal token;
        //AMFObject extras;
        int edepth;

        int seekTime;
        int stopTime;

        // RTMP_LF_AUTH	0x0001	/* using auth param */
        // RTMP_LF_LIVE	0x0002	/* stream is live */
        // RTMP_LF_SWFV	0x0004	/* do SWF verification */
        // RTMP_LF_PLST	0x0008	/* send playlist before play */
        // RTMP_LF_BUFX	0x0010	/* toggle stream on BufferEmpty msg */
        // RTMP_LF_FTCU	0x0020	/* free tcUrl on close */
        int lFlags;

        int swfAge;

        int protocol;
        int timeout;        /* connection timeout in seconds */

        ushort socksport;
        ushort port;


        IntPtr dh;           /* for encryption */
        IntPtr rc4keyIn;
        IntPtr rc4keyOut;

        uint SWFSize;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        byte[] SWFHash;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 42)]
        byte[] SWFVerificationResponse;

    }
}
