using System;
using System.Collections.Generic;
using System.Text;

namespace StreamMediaServer.Core.LibRTMP
{
    public struct RTMPPacket
    {
        public byte m_headerType;
        public byte m_packetType;
        public byte m_hasAbsTimestamp;  /* timestamp absolute or relative? */
        public int m_nChannel;
        public uint m_nTimeStamp;  /* timestamp */
        public int m_nInfoField2;  /* last 4 bytes in a long header */
        public uint m_nBodySize;
        public uint m_nBytesRead;
        public IntPtr m_chunk;  //RTMPChunk类型的指针
        public string m_body;
    }
}
