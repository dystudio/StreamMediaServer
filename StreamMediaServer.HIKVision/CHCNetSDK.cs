using System;
using System.Runtime.InteropServices;

namespace StreamMediaServer.HIKVision
{
    /// <summary>
    /// 海康SDK的封装
    /// </summary>
    public class CHCNetSDK
    {
        /// <summary>
        /// 初始化SDK
        /// </summary>
        /// <returns>TRUE表示成功，FALSE表示失败</returns>
        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_Init();

        /// <summary>
        /// 设备登陆
        /// </summary>
        /// <param name="sDVRIP">设备IP地址</param>
        /// <param name="wDVRPort">设备端口号</param>
        /// <param name="sUserName">登录的用户名</param>
        /// <param name="sPassword">用户密码</param>
        /// <param name="lpDeviceInfo">设备信息</param>
        /// <returns>-1表示失败，其他值表示返回的用户ID值</returns>
        [DllImport("HCNetSDK.dll")]
        public static extern Int32 NET_DVR_Login_V30(string sDVRIP, Int32 wDVRPort, string sUserName, string sPassword, ref NET_DVR_DEVICEINFO_V30 lpDeviceInfo);

        /// <summary>
        /// 实时预览扩展接口
        /// </summary>
        /// <param name="iUserID">NET_DVR_Login()或NET_DVR_Login_V30()的返回值 </param>
        /// <param name="lpPreviewInfo">预览参数</param>
        /// <param name="fRealDataCallBack_V30">码流数据回调函数</param>
        /// <param name="pUser">用户数据 </param>
        /// <returns></returns>
        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_RealPlay_V40(int iUserID, ref NET_DVR_PREVIEWINFO lpPreviewInfo, REALDATACALLBACK fRealDataCallBack_V30, IntPtr pUser);


        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SetRealDataCallBack(int lRealHandle, REALDATACALLBACK fRealDataCallBack, IntPtr dwUser);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SetStandardDataCallBack(int lRealHandle, STDDATACALLBACK fStdDataCallBack, IntPtr dwUser);

        /// <summary>
        /// 停止预览
        /// </summary>
        /// <param name="iRealHandle">预览句柄,NET_DVR_RealPlay或者NET_DVR_RealPlay_V30的返回值 </param>
        /// <returns></returns>
        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_StopRealPlay(int iRealHandle);

        /// <summary>
        /// 登出设备
        /// </summary>
        /// <param name="lUserID">用户ID号</param>
        /// <returns></returns>
        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_Logout_V30(Int32 lUserID);

        /// <summary>
        /// 释放SDK资源，在结束之前最后调用
        /// </summary>
        /// <returns></returns>
        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_Cleanup();

        /// <summary>
        /// 返回最后操作的错误码
        /// </summary>
        /// <returns></returns>
        [DllImport("HCNetSDK.dll")]
        public static extern uint NET_DVR_GetLastError();
    }
}
