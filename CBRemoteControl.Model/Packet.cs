﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBRemoteControl.Model
{
    public class Packet
    {
        #region 字段
        /// <summary>
        /// 发送的整个包
        /// </summary>
        private byte[] _PacketData;
        /// <summary>
        /// action码
        /// </summary>
        private ActionType _ActionCode;
        /// <summary>
        /// JSON序列化后字符串
        /// </summary>
        private string _JsonStr;
        /// <summary>
        /// JSON序列化后字符串的长度
        /// </summary>
        private int _JsonStrLength;
        /// <summary>
        /// 截图byte数组的长度
        /// </summary>
        private int _BitmapLength;
        /// <summary>
        /// 截图byte数组
        /// </summary>
        private byte[] _BitmapData;
        #endregion

        #region 属性
        /// <summary>
        /// 获取json指令
        /// </summary>
        public string JsonStr { get { return _JsonStr; } }
        /// <summary>
        /// 获取动作指令
        /// </summary>
        public ActionType ActionCode { get { return _ActionCode; } }
        /// <summary>
        /// 获取图片的Byte[]
        /// </summary>
        public byte[] BitmapData { get { return _BitmapData; } }
        /// <summary>
        /// 获取封包数据
        /// </summary>
        public byte[] PacketData { get { return _PacketData; } }
        #endregion

        #region 构造方法
        /// <summary>
        /// 构造封包
        /// </summary>
        /// <param name="code">action动作码</param>
        /// <param name="jsonStr">JSON序列化后的字符串</param>
        /// <param name="bitmapData">截图的byte数组</param>
        public Packet(ActionType code, string jsonStr, byte[] bitmapData = null)
        {
            _ActionCode = code;
            Byte[] head;
            if (bitmapData == null)
                _BitmapLength = 0;
            else
                _BitmapLength = bitmapData.Length;

            if (jsonStr == null)
                _JsonStr = String.Empty;
            else
                _JsonStr = jsonStr;
            var BjsonData = Encoding.UTF8.GetBytes(jsonStr);
            var BjsonLength = BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(BjsonData.Length));
            var BbitmapDataLength = BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(_BitmapLength));
            //action1 json4 data4 jsondatax datax

            if (bitmapData == null)
                head = new byte[1 + 4 + 4 + BjsonData.Length];
            else
                head = new byte[1 + 4 + 4 + BjsonData.Length + _BitmapLength];

            head[0] = (byte)code;//action动作码
            Buffer.BlockCopy(BjsonLength, 0, head, 1, 4);
            Buffer.BlockCopy(BbitmapDataLength, 0, head, 5, 4);
            Buffer.BlockCopy(BjsonData, 0, head, 9, BjsonData.Length);
            if (bitmapData != null)
                Buffer.BlockCopy(bitmapData, 0, head, BjsonData.Length + 9, _BitmapLength);

            _PacketData = head;
        }

        /// <summary>
        /// 拆包
        /// </summary>
        /// <param name="packetData">自定义包</param>
        public Packet(byte[] packetData)
        {
            _PacketData = packetData;
            _ActionCode = (ActionType)_PacketData[0];
            var b = new Byte[4];//JSON序列化后字符串长度
            Buffer.BlockCopy(_PacketData, 1, b, 0, 4);
            _JsonStrLength = (int)(b[0] | b[1] << 8 | b[2] << 16 | b[3] << 24);
            _JsonStrLength = System.Net.IPAddress.NetworkToHostOrder(_JsonStrLength);//转为本机

            b = new Byte[4];//截图byte[]的长度
            Buffer.BlockCopy(_PacketData, 5, b, 0, 4);

            //MSDN:为了适用于使用不同字节排序方式的计算机，通过网络发送的所有整数值都按网络字节顺序发送，其中最高有效字节第一个发送
            _BitmapLength = (int)(b[0] | b[1] << 8 | b[2] << 16 | b[3] << 24);
            _BitmapLength = System.Net.IPAddress.NetworkToHostOrder(_BitmapLength);//转为本机


            var jsonByte = new byte[_JsonStrLength];
            Buffer.BlockCopy(_PacketData, 9, jsonByte, 0, _JsonStrLength);
            _JsonStr = System.Text.Encoding.UTF8.GetString(jsonByte);

            if (_BitmapLength != 0)
            {
                _BitmapData = new byte[_BitmapLength];
                Buffer.BlockCopy(_PacketData, 9 + _JsonStrLength, _BitmapData, 0, _BitmapLength);
            }
        }
        #endregion
    }
}
