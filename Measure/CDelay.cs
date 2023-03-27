using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Measure.UserDefine;
using System.Drawing;
using HalconDotNet;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Threading;

namespace Measure
{
    /// <summary>
    /// 计算单元
    /// </summary>
    [Serializable]
    public class CDelay : CMeasureCell
    {
        private static readonly object obLock = new object();

        [NonSerialized]
        public AutoResetEvent eventWait = new AutoResetEvent(false);//采集信号
        [NonSerialized]
        CancellationTokenSource cts;
        public CDelay()
            : base()
        {
        }


        public CDelay(CellCatagory _CellCatagory, int _CellID)
            : base(_CellCatagory, _CellID)
        {
        }

        private int delayTime;

        public int DelayTime
        {
            get
            {
                if (delayTime < 1)
                {
                    delayTime = 1;
                }
                return delayTime;
            }

            set
            {
                delayTime = value;
            }
        }
        /// <summary>
        /// 停止当前等待
        /// </summary>
        public void Stop()
        {
            eventWait.Set();
            if (cts != null)
            {
                cts.Cancel(); //取消任务
            }

        }

        private bool WaitTimeTask(int delayTime, CancellationToken token)
        {

            //延时使用循环延时  否则取消时候回出现滞后响应
            if (delayTime<1)
            {
                eventWait.Set();
                return true;
            }
            for (int i = 0; i < delayTime; i++)
            {
                Thread.Sleep(1);
                if (token.IsCancellationRequested )
                {
                    eventWait.Set();
                    return false;
                }
            }
            //Thread.Sleep(delayTime);
            if (token.IsCancellationRequested == false)
            {
                eventWait.Set();
                return true;
            }
            return false;
        }


        public override void Execute(bool blnByHand = false)
        {

            cts = new CancellationTokenSource();
            eventWait.Reset();

            Task<bool> longTask = new Task<bool>(() => WaitTimeTask(DelayTime,cts.Token), cts.Token);
            longTask.Start();

            //Task tt = Task.Factory.StartNew(() => WaitTimeTask(DelayTime, cts.Token), cts.Token);
            //Console.WriteLine("取消前，第一个任务的状态：{0}", tt.Status);
            eventWait.WaitOne();
            blnSuccessed = longTask.Result;
            cts.Dispose();
            cts = null;

        }
        [OnDeserializing()]
        internal void OnDeSerializingMethod(StreamingContext context)
        {
            eventWait = new AutoResetEvent(false);//采集信号
        }
    }
}
