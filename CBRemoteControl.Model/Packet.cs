using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBRemoteControl.Model
{
    public class Packet
    {
        //发送的整个包
        private byte[] m_Packet;
        //action码
        private byte m_code;
        //JSON序列化后字符串
        private string m_jsonStr;
        //JSON序列化后字符串的长度
        private int m_jsonStrLength;
        //截图byte数组的长度
        private int m_bitmapLength;
        //截图byte数组
        private byte[] m_bitmapData;
        /// <summary>
        /// 构造封包
        /// </summary>
        /// <param name="code">action动作码</param>
        /// <param name="jsonStr">JSON序列化后的字符串</param>
        /// <param name="bitmapData">截图的byte数组</param>
        public Packet(byte code, string jsonStr, byte[] bitmapData)
        {
            this.m_code = code;
            Byte[] head;
            if (bitmapData == null)
                m_bitmapLength = 0;
            else
                m_bitmapLength = bitmapData.Length;

            if (jsonStr == null)
                jsonStr = "";
            else
                this.m_jsonStr = jsonStr;
            var BjsonData = Encoding.UTF8.GetBytes(jsonStr);
            var BjsonLength = BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(BjsonData.Length));
            var BbitmapDataLength = BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(m_bitmapLength));
            //action1 json4 data4 jsondatax datax

            if (bitmapData == null)
                head = new byte[1 + 4 + 4 + BjsonData.Length];
            else
                head = new byte[1 + 4 + 4 + BjsonData.Length + m_bitmapLength];

            head[0] = code;//action动作码
            Buffer.BlockCopy(BjsonLength, 0, head, 1, 4);
            Buffer.BlockCopy(BbitmapDataLength, 0, head, 5, 4);
            Buffer.BlockCopy(BjsonData, 0, head, 9, BjsonData.Length);
            if (bitmapData != null)
                Buffer.BlockCopy(bitmapData, 0, head, BjsonData.Length + 9, m_bitmapLength);

            m_Packet = head;
        }

        /// <summary>
        /// 拆包
        /// </summary>
        /// <param name="packetData">自定义包</param>
        public Packet(byte[] packetData)
        {
            this.m_Packet = packetData;
            this.m_code = this.m_Packet[0];
            var b = new Byte[4];//JSON序列化后字符串长度
            Buffer.BlockCopy(this.m_Packet, 1, b, 0, 4);
            this.m_jsonStrLength = (int)(b[0] | b[1] << 8 | b[2] << 16 | b[3] << 24);
            this.m_jsonStrLength = System.Net.IPAddress.NetworkToHostOrder(this.m_jsonStrLength);//转为本机

            b = new Byte[4];//截图byte[]的长度
            Buffer.BlockCopy(this.m_Packet, 5, b, 0, 4);

            //MSDN:为了适用于使用不同字节排序方式的计算机，通过网络发送的所有整数值都按网络字节顺序发送，其中最高有效字节第一个发送
            this.m_bitmapLength = (int)(b[0] | b[1] << 8 | b[2] << 16 | b[3] << 24);
            this.m_bitmapLength = System.Net.IPAddress.NetworkToHostOrder(this.m_bitmapLength);//转为本机


            var jsonByte = new byte[this.m_jsonStrLength];
            Buffer.BlockCopy(m_Packet, 9, jsonByte, 0, this.m_jsonStrLength);
            this.m_jsonStr = System.Text.Encoding.UTF8.GetString(jsonByte);

            if (this.m_bitmapLength != 0)
            {
                m_bitmapData = new byte[this.m_bitmapLength];
                Buffer.BlockCopy(m_Packet, 9 + this.m_jsonStrLength, m_bitmapData, 0, this.m_bitmapLength);
            }
        }


        /// <summary>
        /// 获取json指令
        /// </summary>
        /// <returns>序列化json</returns>
        public string GetJsonStr()
        {
            return this.m_jsonStr;
        }

        /// <summary>
        /// 获取动作指令
        /// </summary>
        /// <returns>指令码</returns>
        public byte GetAction()
        {
            return this.m_code;
        }
        /// <summary>
        /// 获取图片的Byte[]
        /// </summary>
        /// <returns>字符数组</returns>
        public byte[] GetBitmapData()
        {
            return this.m_bitmapData;
        }
        /// <summary>
        /// 获取封包数据
        /// </summary>
        /// <returns>封包数据</returns>
        public byte[] GetData()
        {
            return this.m_Packet;
        }
    }
}
