using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StreamMediaServer.HIKVision
{  
    /// <summary>
    /// 海康未提供该动态库的接口文档，按照当前的方式无法调用
    /// </summary>
    public class AnalyzeData
    {
        /******************************************************************************
* function：get a empty port number
* parameters：
* return： 0 - 499 : empty port number
*          -1      : server is full  			
* comment：
******************************************************************************/
        [DllImport("AnalyzeData.dll")]
        public static extern int AnalyzeDataGetSafeHandle();


        /******************************************************************************
        * function：open standard stream data for analyzing
        * parameters：lHandle - working port number
        *             pHeader - pointer to file header or info header
        * return：TRUE or FALSE
        * comment：
        ******************************************************************************/
        [DllImport("AnalyzeData.dll")]
        public static extern bool AnalyzeDataOpenStreamEx(int iHandle, byte[] pFileHead);


        /******************************************************************************
        * function：close analyzing
        * parameters：lHandle - working port number
        * return：
        * comment：
        ******************************************************************************/
        [DllImport("AnalyzeData.dll")]
        public static extern bool AnalyzeDataClose(int iHandle);


        /******************************************************************************
        * function：input stream data
        * parameters：lHandle		- working port number
        *			  pBuffer		- data pointer
        *			  dwBuffersize	- data size
        * return：TRUE or FALSE
        * comment：
        ******************************************************************************/
        [DllImport("AnalyzeData.dll")]
        public static extern bool AnalyzeDataInputData(int iHandle, IntPtr pBuffer, uint uiSize); //byte []


        /******************************************************************************
        * function：get analyzed packet
        * parameters：lHandle		- working port number
        *			  pPacketInfo	- returned structure
        * return：-1 : error
        *          0 : succeed
        *		   1 : failed
        *		   2 : file end (only in file mode)				
        * comment：
        ******************************************************************************/
        [DllImport("AnalyzeData.dll")]
        public static extern int AnalyzeDataGetPacket(int iHandle, ref PACKET_INFO pPacketInfo);  //要把pPacketInfo转换成PACKET_INFO结构


        /******************************************************************************
        * function：get remain data from input buffer
        * parameters：lHandle		- working port number
        *			  pBuf	        - pointer to the mem which stored remain data
        *             dwSize        - size of remain data  
        * return： TRUE or FALSE				
        * comment：
        ******************************************************************************/
        [DllImport("AnalyzeData.dll")]
        public static extern bool AnalyzeDataGetTail(int iHandle, ref IntPtr pBuffer, ref uint uiSize);


        [DllImport("AnalyzeData.dll")]
        public static extern uint AnalyzeDataGetLastError(int iHandle);

    }
}
