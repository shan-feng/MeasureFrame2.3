using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework_CCD;
using System.Threading;
using Measure;
using System.Windows.Forms;
using Measure_Sys.IUI;

namespace Measure_Sys
{
    public class ThreadCal : CThread
    {
        public override void Thread_Start()
        {
            base.Thread_Start();
            if (_thread == null)
            {
                _threadStatus = true;
                _thread = new Thread(MeasureProcess);
                _thread.Name = "Mearsur_SYS";
                _thread.IsBackground = true;
                _thread.Start();
            }
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
                    if (HMeasureSYS.g_SysStatus.m_RunMode == RunMode.执行一次)
                    {
                        _threadStatus = false;
                    }
                    try
                    {
                        foreach (CMeasureCell Unit in HMeasureSYS.m_CellList)
                        {
                            bool bReturn = true;
                            CHelper.PostMessage(CHelper.g_MainWnd, CHelper.MAIN_MESSAGE, 10, Unit.m_CellID);//开始计算一个单元
                            switch (Unit.m_CellCatagory)
                            {
                                case CellCatagory.图像单元:
                                    CHelper.PostMessage(CHelper.g_ViewLogWnd, CHelper.VIEW_MESSAGE, 10, Unit.m_CellID);
                                    bReturn = ((CImageReg)Unit).Acq_Image();
                                    break;
                                case CellCatagory.相机标定:
                                    CHelper.PostMessage(CHelper.g_ViewLogWnd, CHelper.VIEW_MESSAGE, 11, Unit.m_CellID);
                                    bReturn = ((CCalibration)Unit).Calibration();
                                    break;
                                case CellCatagory.直线单元:
                                    CHelper.PostMessage(CHelper.g_ViewLogWnd, CHelper.VIEW_MESSAGE, 12, Unit.m_CellID);
                                    bReturn = ((CMeasure_Line)Unit).Cal_Line();
                                    break;
                                case CellCatagory.圆单元:
                                    CHelper.PostMessage(CHelper.g_ViewLogWnd, CHelper.VIEW_MESSAGE, 13, Unit.m_CellID);
                                    bReturn = ((CMeasure_Circle)Unit).Cal_Circle();
                                    break;
                                case CellCatagory.椭圆单元:
                                    CHelper.PostMessage(CHelper.g_ViewLogWnd, CHelper.VIEW_MESSAGE, 14, Unit.m_CellID);
                                    bReturn = ((CMeasure_Ellipse)Unit).Cal_Ellipse();
                                    break;
                                case CellCatagory.建立坐标系:
                                    CHelper.PostMessage(CHelper.g_ViewLogWnd, CHelper.VIEW_MESSAGE, 15, Unit.m_CellID);
                                    bReturn = ((CCoordinate)Unit).Cal_Coord();
                                    break;
                                case CellCatagory.矩形阵列:
                                    CHelper.PostMessage(CHelper.g_ViewLogWnd, CHelper.VIEW_MESSAGE, 16, Unit.m_CellID);
                                    bReturn = ((CRectArray)Unit).Cal_Rect();
                                    break;
                                case CellCatagory.数据存储:
                                    CHelper.PostMessage(CHelper.g_ViewLogWnd, CHelper.VIEW_MESSAGE, 17, Unit.m_CellID);
                                    bReturn = ((CDataSave)Unit).DataSave();
                                    break;
                                case CellCatagory.数据计算:
                                    CHelper.PostMessage(CHelper.g_ViewLogWnd, CHelper.VIEW_MESSAGE, 18, Unit.m_CellID);
                                    bReturn = ((CCalculate)Unit).Cal_Script();
                                    break;
                                case CellCatagory.位置补正:
                                    CHelper.PostMessage(CHelper.g_ViewLogWnd, CHelper.VIEW_MESSAGE, 19, Unit.m_CellID);
                                    bReturn = ((CCorrect_Position)Unit).Cal_HomMat2D();
                                    break;
                                case CellCatagory.结果显示:
                                    CHelper.PostMessage(CHelper.g_ViewLogWnd, CHelper.VIEW_MESSAGE, 20, Unit.m_CellID);
                                    if (((CResultView)Unit).bVisible && CHelper.g_ResultViewWnd != IntPtr.Zero)
                                    {
                                        frm_ResultView frm = (frm_ResultView)Form.FromHandle(CHelper.g_ResultViewWnd);
                                        frm.ShowMSG(Unit);
                                    }
                                    break;
                                case CellCatagory.TCP_IP通讯:
                                    CHelper.PostMessage(CHelper.g_ViewLogWnd, CHelper.VIEW_MESSAGE, 21, Unit.m_CellID);
                                    bReturn = ((CCommunication_TCPServer)Unit).SendMSG();
                                    break;
                                case CellCatagory.相机机械坐标转换:
                                    CHelper.PostMessage(CHelper.g_ViewLogWnd, CHelper.VIEW_MESSAGE, 21, Unit.m_CellID);
                                    bReturn = ((CCalib_Coord)Unit).Cal_Calib_Coord();
                                    break;
                                default:
                                    break;
                            }
                            CHelper.PostMessage(CHelper.g_MainWnd, CHelper.MAIN_MESSAGE, 11, Unit.m_CellID);//一个单元计算结束
                            if (!bReturn)
                            {
                                //_threadStatus = false;
                                HMeasureSYS.g_TcpServer.SendMsgUserToEveryone(Encoding.Default.GetBytes("ERROR"));
                                CHelper.PostMessage(CHelper.g_ViewLogWnd, CHelper.VIEW_MESSAGE, 0, Unit.m_CellID);
                                CHelper.PostMessage(CHelper.g_MainWnd, CHelper.MAIN_MESSAGE, 0, Unit.m_CellID);
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }

                }
            }
        }
    }
}
