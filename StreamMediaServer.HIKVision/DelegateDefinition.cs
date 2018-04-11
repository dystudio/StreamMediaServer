using System;
using System.Collections.Generic;
using System.Text;

namespace StreamMediaServer.HIKVision
{
    public delegate void REALDATACALLBACK(Int32 lRealHandle, UInt32 dwDataType, IntPtr pBuffer, UInt32 dwBufSize, IntPtr pUser);

    public delegate void STDDATACALLBACK(Int32 lRealHandle, UInt32 dwDataType, IntPtr pBuffer, UInt32 dwBufSize, IntPtr dwUser);
}
