using System;
using System.Runtime.InteropServices;

namespace StreamMediaServer.Core
{
    public class LKRtmp
    {
        /// <summary>
        /// 取得LKRtmp版本号
        /// </summary>
        /// <returns></returns>
        [DllImport("LKRtmp.dll")]
        public static extern string LKRtmp_GetVersion();

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="pStreamAddr">rtmp完整地址</param>
        /// <returns></returns>
        [DllImport("LKRtmp.dll")]
        public static extern int LKRtmp_Init(string pStreamAddr);

        /// <summary>
        /// 反初始化
        /// </summary>
        /// <param name="lHandle">初始化返回的句柄</param>
        [DllImport("LKRtmp.dll")]
        public static extern void LKRtmp_Fini(int lHandle);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lHandle">初始化返回的句柄</param>
        /// <param name="iDataType">H264为100，ACC为204</param>
        /// <param name="pDataBuf">数据指针</param>
        /// <param name="iDataLen">数据长度</param>
        /// <param name="unPts">时间戳（保证递增即可）</param>
        /// <param name="iKeyFrame">1关键帧， 0 非关键帧   (注：H264的pDataBuf[4]==0x67 为关键帧</param>
        /// <returns></returns>
        [DllImport("LKRtmp.dll")]
        public static extern int LKRtmp_PutData(int lHandle, int iDataType, IntPtr pDataBuf, int iDataLen, UInt64 unPts, int iKeyFrame);
        /// <summary>
        /// 判断链接是否正常
        /// </summary>
        /// <param name="lHandle"></param>
        /// <returns></returns>
        [DllImport("LKRtmp.dll")]
        public static extern bool LKRtmp_IsConnected(int lHandle);
    }
}
