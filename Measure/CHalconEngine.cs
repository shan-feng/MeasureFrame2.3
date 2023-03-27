using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.IO;
using System.Windows.Forms;
using Measure.UserDefine;
using System.Runtime.Serialization;
using CPublicDefine;

namespace Measure
{
    /// <summary>
    /// halcon引擎单元
    /// </summary>
    [Serializable]
    public class CHalconEngine : CMeasureCell
    {
        private static readonly object lck = new object();
        public CHalconEngine()
            : base()
        {

        }

        public CHalconEngine(CellCatagory _CellCatagory, int _CellID)
            : base(_CellCatagory, _CellID)
        {

        }
        [NonSerialized]
        private HDevEngine MyEngine = new HDevEngine();
        [NonSerialized]
        private HDevProgramCall ProgramCall;
        /// <summary>
        /// halcon 执行文件路劲
        /// </summary>
        public string filePhth { get; set; }

        /// <summary>
        /// 输入参数名称列表
        /// </summary>
        public List<string> inParamList = new List<string>();

        /// <summary>
        /// 输出参数名称列表，只限局部变量
        /// </summary>
        public List<string> outParamList = new List<string>();

        public override void Execute(bool blnByHand = false)
        {
            blnSuccessed = false;
            try
            {
                lock (lck)
                {
                    if (File.Exists(filePhth))
                    {
                        //创建脚本
                        using (HDevProgram hdevProgram = new HDevProgram(filePhth))
                        {
                            using (ProgramCall = new HDevProgramCall(hdevProgram))
                            {
                                //变量赋值
                                foreach (string name in inParamList)
                                {
                                    F_DATA_CELL data = this._Owner.m_VariableList.First(c => c.m_Data_CellID == HMeasureSYS.U000 &&
                                        c.m_Data_Name == name);
                                    if (!SetEngineParam(data))
                                        return;
                                }
                                //执行脚本
                                ProgramCall.Execute();
                                //结果提取
                                foreach (string name in outParamList)
                                {
                                    int index = this._Owner.m_VariableList.FindIndex(c => c.m_Data_CellID == HMeasureSYS.U000 &&
                                        c.m_Data_Name == name);
                                    this._Owner.m_VariableList[index] = GetEngineParam(this._Owner.m_VariableList[index]);
                                }
                            }
                        }
                        blnSuccessed = true;
                    }
                    else
                    {
                        MessageBox.Show($"halcon脚本文件路径:{filePhth} 不存在！");
                    }
                }
            }
            catch (System.Exception ex)
            {
                if (ProgramCall != null)
                {
                    ProgramCall.Dispose();
                }
                //MessageBox.Show(ex.ToString());
                return ;
            }
        }

        private bool SetEngineParam(F_DATA_CELL data)
        {
            try
            {
                switch (data.m_Data_Type)
                {
                    case DataType.数值型:
                        MyEngine.SetGlobalCtrlVarTuple(data.m_Data_Name, new HTuple(((List<double>)data.m_Data_Value).ToArray()));
                        break;
                    case DataType.字符串:
                        MyEngine.SetGlobalCtrlVarTuple(data.m_Data_Name, new HTuple(((List<string>)data.m_Data_Value)[0]));
                        break;
                    case DataType.旋转矩形:
                        Rectangle2_INFO rect = ((List<Rectangle2_INFO>)data.m_Data_Value)[0];
                        MyEngine.SetGlobalCtrlVarTuple(data.m_Data_Name, rect.getTuple());
                        break;
                    case DataType.矩形:
                        Rectangle_INFO rect1 = ((List<Rectangle_INFO>)data.m_Data_Value)[0];
                        MyEngine.SetGlobalCtrlVarTuple(data.m_Data_Name, rect1.getTuple());
                        break;
                    case DataType.图像:
                        HImageExt img = ((List<HImageExt>)data.m_Data_Value)[0];
                        MyEngine.SetGlobalIconicVarObject(data.m_Data_Name, img);
                        break;
                    case DataType.椭圆:
                        Ellipse_INFO ellipse = ((List<Ellipse_INFO>)data.m_Data_Value)[0];
                        MyEngine.SetGlobalCtrlVarTuple(data.m_Data_Name, ellipse.getTuple());
                        break;
                    case DataType.圆:
                        Circle_INFO circle = ((List<Circle_INFO>)data.m_Data_Value)[0];
                        MyEngine.SetGlobalCtrlVarTuple(data.m_Data_Name, circle.getTuple());
                        break;

                    case DataType.直线:
                        Line_INFO line = ((List<Line_INFO>)data.m_Data_Value)[0];
                        MyEngine.SetGlobalCtrlVarTuple(data.m_Data_Name, line.getTuple());
                        break;
                    default:
                        return false;
                }
                return true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        private F_DATA_CELL GetEngineParam(F_DATA_CELL data)
        {
            HTuple t = new HTuple();
            try
            {
                switch (data.m_Data_Type)
                {
                    case DataType.数值型:
                        t = ProgramCall.GetCtrlVarTuple(data.m_Data_Name);
                        List<double> value = t.ToDArr().ToList();
                        data.m_Data_Value = value;
                        break;
                    case DataType.字符串:
                        t = ProgramCall.GetCtrlVarTuple(data.m_Data_Name);
                        List<string> lstStr = t.ToSArr().ToList();
                        data.m_Data_Value = lstStr;
                        break;
                    case DataType.旋转矩形:
                        t = ProgramCall.GetCtrlVarTuple(data.m_Data_Name);
                        Rectangle2_INFO rect = new Rectangle2_INFO(t[0].D, t[1].D, t[2].D, t[3].D, t[4].D);
                        data.m_Data_Value = new List<Rectangle2_INFO>() { rect };
                        break;
                    case DataType.图像:
                        HImage img = ProgramCall.GetIconicVarImage(data.m_Data_Name);
                        HImageExt imgOld = ((List<HImageExt>)data.m_Data_Value)[0];
                        HImageExt imgNew = HImageExt.Instance(img);
                        imgNew.SetExtData(imgOld);
                        data.m_Data_Value = new List<HImageExt>() { imgNew };
                        break;
                    case DataType.椭圆:
                        t = ProgramCall.GetCtrlVarTuple(data.m_Data_Name);
                        Ellipse_INFO ell = new Ellipse_INFO(t[0].D, t[1].D, t[2].D, t[3].D, t[4].D);
                        data.m_Data_Value = new List<Ellipse_INFO>() { ell };
                        break;

                    case DataType.圆:
                        t = ProgramCall.GetCtrlVarTuple(data.m_Data_Name);
                        Circle_INFO cir = new Circle_INFO(t[0].D, t[1].D, t[2].D);
                        data.m_Data_Value = new List<Circle_INFO>() { cir };
                        break;

                    case DataType.直线:
                        t = ProgramCall.GetCtrlVarTuple(data.m_Data_Name);
                        Line_INFO lin = new Line_INFO(t[0].D, t[1].D, t[2].D, t[3].D);
                        data.m_Data_Value = new List<Line_INFO>() { lin };
                        break;

                    default:
                        return data;
                }
                return data;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return data;
            }
        }

        [OnDeserialized]
        internal void OnDeSerializedMethod(StreamingContext context)
        {
            MyEngine = new HDevEngine();
        }
    }
}
