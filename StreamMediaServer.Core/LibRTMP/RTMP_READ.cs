using System;
using System.Collections.Generic;
using System.Text;

namespace StreamMediaServer.Core.LibRTMP
{
    public struct RTMP_READ
    {
        public byte[] buf;
        public byte[] bufpos;
        public uint buflen;
        public uint timestamp;
        public byte dataType;
        public byte flags;
        // RTMP_READ_HEADER	0x01
        // RTMP_READ_RESUME	0x02
        // RTMP_READ_NO_IGNORE	0x04
        // RTMP_READ_GOTKF		0x08
        // RTMP_READ_GOTFLVK	0x10
        // RTMP_READ_SEEKING	0x20
        public byte status;
        // RTMP_READ_COMPLETE	-3
        // RTMP_READ_ERROR	-2
        // RTMP_READ_EOF	-1
        // RTMP_READ_IGNORE	  0

        /* if bResume == TRUE */
        public byte initialFrameType;
        public uint nResumeTS;
        public byte[] metaHeader;
        public byte[] initialFrame;
        public uint nMetaHeaderSize;
        public uint nInitialFrameSize;
        public uint nIgnoredFrameCounter;
        public uint nIgnoredFlvFrameCounter;
    }
}
