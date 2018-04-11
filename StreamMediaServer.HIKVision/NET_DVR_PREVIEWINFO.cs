using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StreamMediaServer.HIKVision
{
    /// <summary>
    /// 预览参数结构体
    /// </summary>
    public struct NET_DVR_PREVIEWINFO
    {
        public Int32 lChannel;
        public uint dwStreamType;
        public uint dwLinkMode;
        public IntPtr hPlayWnd;
        public bool bBlocked;
        public bool bPassbackRecord;
        public byte byPreviewMode;
        public byte[] byStreamID;
        public byte byProtoType;
        public byte byRes1;
        public byte byVideoCodingType;
        public uint dwDisplayBufNum;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 216, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
