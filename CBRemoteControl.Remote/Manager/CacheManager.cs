using CBRemoteControl.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBRemoteControl.Remote.Manager
{
    class CacheManager
    {
        #region 字段
        private ConcurrentQueue<ActionType> _CommandQueue;
        #endregion

        #region 属性
        public static CacheManager Instance;
        #endregion

        #region 构造方法
        static CacheManager()
        {
            Instance = new CacheManager();
        }
        CacheManager()
        {
            _CommandQueue = new ConcurrentQueue<ActionType>();
            Task.Factory.StartNew(() => GuardQueue());
        }
        #endregion

        #region 方法
        public void AddCommand(ActionType actionCode)
        {
            if (actionCode == ActionType.SayHeelo)
                return;
            _CommandQueue.Enqueue(actionCode);
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
