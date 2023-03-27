using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Helper;
using HalconDotNet;
using System.Runtime.Serialization;
using CPublicDefine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Measure
{

    /// <summary>
    /// 流程
    /// </summary>
    [Serializable]
    public class CProject : CThread, ICloneable
    {
        public int m_LastCellID = 1;

        public CProject()
        {
            m_LastProjectID++;
            _ProjectID = m_LastProjectID;
            m_ProjectName = "New Project" + _ProjectID.ToString();
        }

        public CProject(int ID)
        {
            _ProjectID = ID;
            m_ProjectName = "New Project" + _ProjectID.ToString();
        }

        public static int m_LastProjectID = 0;
        private int _ProjectID;

        public static bool m_IsMangerGTCard = false;
        /// <summary>
        /// 流程ID 唯一
        /// </summary>
        public int m_ProjectID
        {
            set { _ProjectID = value; }
            get { return _ProjectID; }
        }
        [NonSerialized]
        public ImageCatagory ImgCatagory = ImageCatagory.注册图像;
        /// <summary>
        /// 流程名称，不能重复
        /// </summary>
        public string m_ProjectName { get; set; }

        /// <summary>
        /// 当前单元执行ID
        /// </summary>
        [NonSerialized]
        public int CurCellID = -1;

        /// <summary>
        /// 是否启动加载
        /// </summary>
        public bool m_IsStart { get; set; }

        [NonSerialized]
        public string Result;//当前检测结果
        /// <summary>
        /// 流程列表
        /// </summary>
        public List<CMeasureCell> m_CellList = new List<CMeasureCell>();

        /// <summary>
        /// 局部变量列表
        /// </summary>
        public List<F_DATA_CELL> m_VariableList = new List<F_DATA_CELL>();

        /// <summary>
        /// 注册图像列表
        /// </summary>
        public List<RegisterIMG_Info> m_RegisterImg = new List<RegisterIMG_Info>();
        /// <summary>
        /// 注册图像单元信息列表
        /// </summary>
        //public List<F_DATA_CELL> m_RegImgVariableList = new List<F_DATA_CELL>();

        /// <summary>
        /// 查询当前项目图像
        /// </summary>
        /// <param name="imgCatagory">图像分类</param>
        /// <param name="m_imgName">图像名称</param>
        /// <param name="m_Image">图像变量</param>
        public void QueryImage(ImageCatagory imgCatagory, string m_imgName, out HImageExt m_Image)
        {
            //m_Image=new HImage();
            HMeasureSet.QueryImage(m_VariableList, m_RegisterImg, imgCatagory, m_imgName, out m_Image);
        }

        /// <summary>
        /// 查询变量
        /// </summary>
        /// <param name="_CellID">变量ID</param>
        /// <param name="_DataName">变量名称</param>
        public F_DATA_CELL QueryVariableValue(int _CellID, string _DataName)
        {
            List<F_DATA_CELL> dataList;
            HMeasureSet.getVariableList(m_VariableList, _CellID, _DataName, out dataList);
            return dataList[0];
        }

        /// <summary>
        /// 更新变量
        /// </summary>
        /// <param name="_CellID">变量ID</param>
        /// <param name="_DataName">变量名称</param>
        /// <param name="_ListValue">变量值</param>
        public void UpdateVariableValue(int _CellID, string _DataName, object _ListValue)
        {
            HMeasureSet.UpdateVariableValue(ref m_VariableList, _CellID, _DataName, _ListValue);
        }        /// <summary>
                 /// 更新注册图像信息变量
                 /// </summary>
                 /// <param name="datacell"></param>
        //public void UpdateRegVariableValue(F_DATA_CELL datacell)
        //{
        //    HMeasureSet.UpdateVariableValue(ref m_RegImgVariableList, datacell);
        //}
        /// <summary>
        /// 更新变量
        /// </summary>
        /// <param name="datacell">数据</param>
        public void UpdateVariableValue(F_DATA_CELL datacell)
        {
            HMeasureSet.UpdateVariableValue(ref m_VariableList, datacell);
        }

        /// <summary>
        /// 获取当前项目xyz轴的坐标,轴未配置或为空则返回0
        /// </summary>
        /// <param name="dValueX">x轴坐标</param>
        /// <param name="dValueY">y轴坐标</param>
        /// <param name="dValueZ">z轴坐标</param>
        public void GetCurrentPosi(out double dValueX, out double dValueY, out double dValueZ)
        {
            dValueX = 0.0;
            dValueY = 0.0;
            dValueZ = 0.0;
        }

        public override void Thread_Start()
        {
            base.Thread_Start();
            if (_thread == null)
            {
                _threadStatus = true;
                _thread = new Thread(MeasureProcess);
                _thread.Name = m_ProjectName;
                _thread.IsBackground = true;
                _thread.Start();
            }
            CHelper.UpdateProject(this);
        }

        /// <summary>
        /// 计算流程
        /// </summary>
        private void MeasureProcess()
        {
            while (true) 
            {
                Thread.Sleep(10);
                if (_threadStatus)//等待一次计算的信号
                {
                    try
                    {
                        //System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                        //sw.Start();
                        System.GC.Collect();//主动回收下系统未使用的资源
                        if (HMeasureSYS.Cur_Project != null && HMeasureSYS.Cur_Project.m_ProjectID == this.m_ProjectID)
                            CHelper.PostMessage(CHelper.g_MainWnd, CHelper.MAIN_MESSAGE, -1, 0);//开始一个流程
                        foreach (CMeasureCell Unit in m_CellList)
                        {
                            CurCellID = Unit.m_CellID;
                            CHelper.PostMessage(CHelper.g_ViewLogWnd, CHelper.VIEW_MESSAGE, this.m_ProjectID, Unit.m_CellID);
                            if (HMeasureSYS.Cur_Project != null && HMeasureSYS.Cur_Project.m_ProjectID == this.m_ProjectID)
                                CHelper.PostMessage(CHelper.g_MainWnd, CHelper.MAIN_MESSAGE, Unit.m_CellID, -2);//如果执行成功为数字 1；否则，为 0,屏蔽-1,开始执行为-2。

                            if (!Unit.blnShield)//屏蔽不执行
                            {
                                //面阵相机由于有可能自动执行,添加单独判断  yoga 2018-8-28 16:44:03
                                if (Unit is CImageReg_Area)
                                {
                                    bool blnByHand = ((CImageReg_Area)Unit).m_IsAcqAuto;
                                    Unit.Execute(blnByHand);
                                }
                                else
                                {
                                    Unit.Execute();
                                }

                            }

                            
                            if (HMeasureSYS.Cur_Project != null && HMeasureSYS.Cur_Project.m_ProjectID == this.m_ProjectID)
                                CHelper.PostMessage(CHelper.g_MainWnd, CHelper.MAIN_MESSAGE, Unit.m_CellID, Unit.blnShield ? -1 : Convert.ToInt32(Unit.blnSuccessed));//如果执行成功为数字 1；否则，为 0,屏蔽-1。
                            if (_threadStatus == false)//线程终止
                                break;
                        }
                        if (_threadStatus == false)//线程终止 
                            continue;

                        if (HMeasureSYS.Cur_Project != null && HMeasureSYS.Cur_Project.m_ProjectID == this.m_ProjectID)
                            CHelper.PostMessage(CHelper.g_MainWnd, CHelper.MAIN_MESSAGE, -1, 1);//结束一个流程
                        ////测试代码 2019-2-14 21:04:46
                        //sw.Stop();
                        //long totalTime = sw.ElapsedMilliseconds;
                        //LogHandler.Instance.VTLogInfo(string.Format("---------运行耗时{0}ms", totalTime));
                        if (HMeasureSYS.g_SysStatus.m_RunMode == RunMode.执行一次) //取消注释 yoga 2019-2-15 09:45:39  测试代码 2019 - 2 - 14 21:04:46
                        {
                            HMeasureSYS.g_SysStatus.m_RunMode = RunMode.None;
                            _threadStatus = false;
                        }

                        //往效果图窗口插入he magical 20170823
                        List<F_DATA_CELL> datalist = m_VariableList.FindAll(c => c.m_Data_CellID == HMeasureSYS.U000
                                       && c.m_Data_Type == DataType.图像);
                        if (CHelper.insertHe2HeViewer != null)
                        {
                            foreach (F_DATA_CELL item in datalist)
                            {
                                CHelper.insertHe2HeViewer(m_ProjectName + "_" + item.m_Data_Name, ((List<HImageExt>)item.m_Data_Value)[0].Clone());
                            }
                        }
                        if (CHelper.InsertHe2ExtWindow != null)// && Result=="NG")
                        {
                            List<HImageExt> heList = new List<HImageExt>();
                            foreach (F_DATA_CELL item in datalist)
                            {
                                heList.Add(((List<HImageExt>)item.m_Data_Value)[0].Clone());
                            }
                            CHelper.InsertHe2ExtWindow(heList, this.m_ProjectName);
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHandler.Instance.VTLogError(ex.ToString());
                    }
                    //if (Wrapper.Fun.GetRegistState() == false)
                    //{
                    //    //System.Windows.Forms.MessageBox.Show("软件未注册");
                    //}
                }
            }
        }

        public object Clone()
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
            stream.Position = 0;
            CProject temp = (CProject)formatter.Deserialize(stream);
            //CProject.m_LastProjectID++;
            //temp._ProjectID = m_LastProjectID;
            return temp;
        }

        [OnDeserialized()]
        internal void OnDeSerializedMethod(StreamingContext context)
        {
            CurCellID = -1;
        }
    }
}
