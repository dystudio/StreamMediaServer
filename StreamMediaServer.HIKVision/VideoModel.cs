using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace StreamMediaServer.HIKVision
{
    class VideoModel
    {
        public VideoModel()
        {
            Buffer = new List<byte>();
            AudioBuffer = new List<byte>();
        }

        public string IP
        {
            get; set;
        }

        public int Port
        {
            get; set;
        }

        public int Channel
        {
            get; set;
        }

        public int UserHandle
        {
            get; set;
        }

        public int RealHandle
        {
            get; set;
        }

        public int RTMPHandle
        {
            get; set;
        }

        public List<byte> Buffer
        {
            get; set;
        }

        public List<byte> AudioBuffer
        {
            get; set;
        }
    }
}
