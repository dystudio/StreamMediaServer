using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace StreamMediaServer.Core.LibRTMP
{
    public struct RTMPSockBuf
    {
        int sb_socket;
        int sb_size;        /* number of unprocessed bytes in buffer */
        IntPtr sb_start;     /* pointer into sb_pBuffer of next byte to process */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16384)]
        byte[] sb_buf;    /* data read from socket  16*1024 */
        int sb_timedout;
        IntPtr sb_ssl;
    }
}
