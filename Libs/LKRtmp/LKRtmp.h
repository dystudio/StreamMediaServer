#ifndef __LKRTMP_H__
#define __LKRTMP_H__

#if defined(LKRTMP_API)
	#undef LKRTMP_API
	#define LKRTMP_API
#endif

#ifndef LKRTMP_API
	#ifdef WIN32
		#ifdef LKRTMP_EXPORTS
			#define LKRTMP_API extern "C" __declspec(dllexport)
		#else
			#define LKRTMP_API extern "C" __declspec(dllimport)
		#endif
	#else
		#define LKRTMP_API extern "C"
	#endif
#endif

LKRTMP_API char*	__stdcall LKRtmp_GetVersion();
LKRTMP_API long		__stdcall LKRtmp_Init(char* pStreamAddr);
LKRTMP_API void		__stdcall LKRtmp_Fini(long lHandle);

/*
iDataType的定义
#define LKAVFORMAT_H264			100   *已实现
#define LKAVFORMAT_MPEG4		101
#define LKAVFORMAT_MJPEG		102
#define LKAVFORMAT_PCM			200
#define LKAVFORMAT_MULAW		201
#define LKAVFORMAT_ALAW			202
#define LKAVFORMAT_G726			203
#define LKAVFORMAT_AAC			204   *已实现
#define LKAVFORMAT_YUV420		300
#define LKAVFORMAT_BMP			301
#define LKAVFORMAT_JPEG			302
*/
LKRTMP_API int		__stdcall LKRtmp_PutData(long lHandle, int iDataType, char* pDataBuf, int iDataLen, UINT64 unPts, int iKeyFrame);





LKRTMP_API BOOL		__stdcall LKRtmp_IsConnected(long lHandle);

#endif // __LKRTMP_H__

