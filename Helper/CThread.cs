using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Helper;
using System.Runtime.Serialization;

namespace Helper
{
    [Serializable]
    public class CThread : IDisposable
    {
        [NonSerialized]
        protected Thread _thread = null;
        //线程状态不序列化  否则可能导致打开直接指示已经运行   yoga 2018-9-1 17:52:32
        [NonSerialized]
        protected bool _threadStatus = false;
        [NonSerialized]
        public AutoResetEvent eventWait = new AutoResetEvent(false);
        //public Mutex
        public int ThreadID;

        private static int _threadID = 0;
        /// <summary>
        /// 构造函数
        /// </summary>
        public CThread()
        {
            _threadID++;
            ThreadID = _threadID;
        }

        public bool m_Status
        {
            get { return _threadStatus; }
        }

        public virtual void Thread_Start()
        {
            _threadStatus = true;
            //eventWait.Set();
        }

        public virtual void Thread_Stop()
        {
            _threadStatus = false;
            //eventWait.Reset();
        }

        /// <summary>
        /// 释放线程资源
        /// </summary>
        public virtual void Dispose()
        {
            if (_thread != null && _thread.ThreadState != ThreadState.Aborted)
            {
                LogHandler.Instance.VTLogWarning(this.GetType().Name + " 线程停止！");
                _threadStatus = false;
                _thread.Abort();
                _thread = null;
            }
        }

        [OnDeserializing()]
        internal void OnDeSerializingMethod(StreamingContext context)
        {
            eventWait = new AutoResetEvent(false);//采集信号
        }
    }
}
