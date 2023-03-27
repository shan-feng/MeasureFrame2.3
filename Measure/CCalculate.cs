using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Measure.UserDefine;
using System.Drawing;
using HalconDotNet;
using System.Runtime.Serialization;

namespace Measure
{
    [Microsoft.VisualBasic.CompilerServices.StandardModuleAttribute()]
    /// <summary>
    /// 计算单元
    /// </summary>
    [Serializable]
    public class CCalculate : CMeasureCell
    {
        private static readonly object obLock = new object();
        public CCalculate()
            : base()
        {
            InitVBAEngine();
        }

        public CCalculate(CellCatagory _CellCatagory, int _CellID)
            : base(_CellCatagory, _CellID)
        {
            InitVBAEngine();
        }
        [NonSerialized]
        public XVBAEngine m_VBAEngine = null;

        //private string _Script = string.Empty;
        private string _Script = string.Empty;
        /// <summary>
        /// 脚本代码
        /// </summary>
        public string m_Script
        {
            set
            {
                _Script = value;
                m_VBAEngine.ScriptText = value;
            }
            get
            {
                return _Script;
            }
        }

        public override void Execute(bool blnByHand = false)
        {
            bool result = false;
            if (!m_VBAEngine.bDebuged)
            {
                if (!m_VBAEngine.Compile())
                {
                    blnSuccessed = false;
                    return;
                }
            }
            object[] param = { m_Owner.m_ProjectID };
            lock (obLock)
            {
                result = m_VBAEngine.Execute("Cal", param, true);
            }
            blnSuccessed = true;
        }

        /// <summary>
        /// 初始化VBA脚本引擎
        /// </summary>
        private void InitVBAEngine()
        {
            // 创建脚本引擎
            m_VBAEngine = new XVBAEngine();
            m_VBAEngine.P = this;
            m_VBAEngine.AddReferenceAssemblyByType(this.GetType());
            m_VBAEngine.AddReferenceAssemblyByType((new Measure.HMeasureSYS()).GetType());
            m_VBAEngine.VBCompilerImports.Add("Measure.Global");
            m_VBAEngine.VBCompilerImports.Add("Measure.UserDefine");
            //设置脚本引擎全局对象
        }
        [OnDeserializing()]
        internal void OnDeSerializingMethod(StreamingContext context)
        {
            InitVBAEngine();
        }
        [OnDeserialized()]
        internal void OnDeSerializedMethod(StreamingContext context)
        {
            m_VBAEngine.ScriptText = m_Script;
        }
    }
}
