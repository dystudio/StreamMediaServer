using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace StreamMediaServer.Core.LibRTMP
{
    public struct RTMPChunk
    {
        public int c_headerSize;
        public int c_chunkSize;
        public string c_chunk;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 18)]
        public byte[] c_header;
    }
}
