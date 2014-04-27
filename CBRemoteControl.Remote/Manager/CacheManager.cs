﻿using CBRemoteControl.Model;
using NetMQ;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace CBRemoteControl.Remote.Manager
{
    class CacheManager
    {
        #region 字段
        private ConcurrentQueue<Package> _CommandQueue;
        #endregion

        #region 属性
        public static CacheManager Instance;
        public int CommandCount { get { return _CommandQueue.Count; } }
        #endregion

        #region 构造方法
        static CacheManager()
        {
            Instance = new CacheManager();
        }
        CacheManager()
        {
            _CommandQueue = new ConcurrentQueue<Package>();
            Task.Factory.StartNew(() => GuardQueue());
        }
        #endregion

        #region 方法
        public void AddCommand(NetMQMessage message)
        {
            var actionCode = (ActionType)Enum.Parse(typeof(ActionType),message.First.ConvertToString());

            Console.WriteLine(String.Format("{0} : {1}", DateTime.Now, actionCode));

            if (actionCode.Equals(ActionType.SayHeelo))
            {
                return;
            }

            _CommandQueue.Enqueue(new Package(message));
        }
        #endregion

        #region 私有方法
        private void GuardQueue()
        {
            return;
            //TODO
            //执行一些不需要回馈到服务器的动作
        }
        #endregion
    }
}
