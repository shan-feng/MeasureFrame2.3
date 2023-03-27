using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Measure;
using HalconDotNet;
using System.IO;
using System.Windows.Forms;
using AcqDevice;
using System.Drawing;
using Measure.UserDefine;
using Helper;
using System.Net;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using CPublicDefine;
using System.Threading;

namespace Measure
{
    public delegate void DelegateTrigger();
    public class HMeasureSYS : System.IDisposable
    {
        public static string sConfigPath = @"MeasureSys.cfg";

        /// <summary>
        /// U000单元 全局变量
        /// </summary>
        public const int U000 = 0;
        /// <summary>
        /// USys单元 系统变量
        /// </summary>
        public const int USys = -1;


       
        /// <summary>
        /// 当前项目
        /// </summary>
        public static CProject Cur_Project = null; //当前项目

        /// <summary>
        /// 工程列表
        /// </summary>
        public static List<CProject> g_ProjectList = new List<CProject>();

        /// <summary>
        /// 系统变量列表和常量
        /// </summary>
        public static List<F_DATA_CELL> g_VariableList = new List<F_DATA_CELL>();

        /// <summary>
        /// 采集设备列表
        /// </summary>
        public static List<AcqDeviceBase> g_AcqDeviceList = new List<AcqDeviceBase>();
        /// <summary>
        /// tcp服务器
        /// </summary>
        public static TCPServer2 g_TcpServer = new TCPServer2();


        /// <summary>
        /// 系统运行状态
        /// </summary>
        public static Sys_Status g_SysStatus = new Sys_Status();

        /// <summary>
        /// 相机触发源，定义为EVENT是为了满足一个信号触发多个相机
        /// </summary>
        public static event DelegateTrigger g_TR1 = null;
        public static event DelegateTrigger g_TR2 = null;
        public static event DelegateTrigger g_TR3 = null;
        public static event DelegateTrigger g_TR4 = null;

        /// <summary>
        /// 镭射终止采集触发源，定义为EVENT是为了满足一个信号触发多个相机
        /// </summary>
        public static event DelegateTrigger g_EndTR1 = null;
        public static event DelegateTrigger g_EndTR2 = null;
        public static event DelegateTrigger g_EndTR3 = null;
        public static event DelegateTrigger g_EndTR4 = null;
        
        /// <summary>
        ///  初始化视觉工程项目
        /// </summary>
        /// <param name="filepath">初始化文件所在路径</param>
        /// <returns></returns>
        public static bool InitialVisionProgram(string filepath = @"MeasureSys.cfg")
        {
            try
            {
                string ThePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                if (filepath.Contains(@":\") == false)
                {
                    filepath = System.IO.Path.Combine(ThePath, filepath);
                }

             
             
                if (filepath.Trim() == "" || System.IO.File.Exists(filepath) == false)
                {
                    System.Windows.Forms.MessageBox.Show("输入文件名错误！");
                    throw new Exception("视觉测量模块报错：" + filepath + "不存在！");
                }
                else
                {
                    HMeasureSYS.sConfigPath = filepath;
                }
                //设备也要同步先关闭  yoga 2018-8-30 15:34:29
                HMeasureSYS.DisposeDev();
                //由于可能之前已经打开了  此处要先将tcp服务器关闭
                HMeasureSYS.g_TcpServer.tcp.Stop();

                HMeasureSYS.ReadConfig(HMeasureSYS.sConfigPath);
                //HMeasureSYS.ReadSpaceInfo(out HMeasureSYS.g_ProjectList, out HMeasureSYS.g_VariableList, out HMeasureSYS.g_AcqDeviceList, out HMeasureSYS.g_TcpServer, Application.StartupPath + sProject_Path);

                HMeasureSYS.g_TcpServer.tcp.Start();
                //没次读取新的配置文件时重新检测VB代码状态和设备连接状态
                HMeasureSYS.InitDevStatus();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Measure.HMeasureSYS.InitialVisionProgram:" + ex.ToString());
                return false;
            }
        }

        public static void DisposeVisionProgram()
        {
            Sys_Stop();
            HMeasureSYS.g_TcpServer.Stop();
            HMeasureSYS.DisposeDev();        
        }

        /// <summary>
        ///系统检测启动
        /// </summary>
        public static void Sys_Start()
        {
            for (int i = 0; i < HMeasureSYS.g_ProjectList.Count; i++)
            {
                Sys_Start(i);
            }
        }

        /// <summary>
        ///系统检测启动
        /// </summary>
        public static void Sys_Start(int index)
        {
            HMeasureSYS.g_SysStatus.m_RunMode = RunMode.循环运行;
            Sys_ThreadStart(index);
        }

        public static void Sys_ThreadStart(int index)
        {
            if (index > HMeasureSYS.g_ProjectList.Count - 1)
            {
                return;
            }
            CMeasureCell cell = HMeasureSYS.g_ProjectList[index].m_CellList.First(c => c.m_CellCatagory == CellCatagory.线阵图像单元 || c.m_CellCatagory == CellCatagory.面阵图像单元);
            if (cell.m_CellCatagory == CellCatagory.面阵图像单元)
            {
                ((CImageReg_Area)cell).m_AcqDevice.eventWait.Reset();
                ((CImageReg_Area)cell).m_AcqDevice.SignalWait.Reset();
            }
            else if (cell.m_CellCatagory == CellCatagory.线阵图像单元)
            {
                ((CImageReg_Line)cell).m_AcqDevice.eventWait.Reset();
            }

            HMeasureSYS.g_ProjectList[index].Thread_Start();
        }
        public static void Sys_StartTest(int index)
        {
            HMeasureSYS.g_SysStatus.m_RunMode = RunMode.执行一次;
            Sys_ThreadStart(index);
        }

        /// <summary>
        ///系统检测停止
        /// </summary>
        public static void Sys_Stop(int index)
        {
            try
            {
                if (index > HMeasureSYS.g_ProjectList.Count - 1)
                {
                    return;
                }
                HMeasureSYS.g_ProjectList[index].Thread_Stop();
                int cellIndex = HMeasureSYS.g_ProjectList[index].m_CellList.FindIndex(c => c.m_CellID == HMeasureSYS.g_ProjectList[index].CurCellID);
                if (cellIndex >= 0)
                {
                    CMeasureCell cell = HMeasureSYS.g_ProjectList[index].m_CellList[cellIndex];
                    if (cell.m_CellCatagory == CellCatagory.面阵图像单元)
                    {
                        ((CImageReg_Area)cell).m_AcqDevice.SignalWait.Set();
                        ((CImageReg_Area)cell).m_AcqDevice.eventWait.Set();
                    }
                    else if (cell.m_CellCatagory == CellCatagory.线阵图像单元)
                    {
                        ((CImageReg_Line)cell).m_AcqDevice.eventWait.Set();
                    }
                    else if (cell.m_CellCatagory== CellCatagory.延时单元)
                    {
                        ((CDelay)cell).Stop(); 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Measure.HMeasureSYS.Sys_Stop:" + ex.ToString());
            }
        }

        /// <summary>
        ///系统检测停止
        /// </summary>
        public static void Sys_Stop()
        {
            try
            {
                for (int i = 0; i < HMeasureSYS.g_ProjectList.Count; i++)
                {
                    Sys_Stop(i);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Measure.HMeasureSYS.Sys_Stop:" + ex.ToString());
                Helper.LogHandler.Instance.VTLogWarning(ex.ToString());
            }
        }

        /// <summary>
        /// 相机触发事件/镭射开始终止采集触发事件
        /// </summary>
        /// <param name="str">字符串</param>
        public static void setTrigger(string str)
        {
            switch (str)
            {
                case "TR1":
                    if (HMeasureSYS.g_TR1 != null)
                    {
                        HMeasureSYS.g_TR1();
                    }
                    break;
                case "TR2":
                    if (HMeasureSYS.g_TR2 != null)
                    {
                        HMeasureSYS.g_TR2();
                    }
                    break;
                case "TR3":
                    if (HMeasureSYS.g_TR3 != null)
                    {
                        HMeasureSYS.g_TR3();
                    }
                    break;
                case "TR4":
                    if (HMeasureSYS.g_TR4 != null)
                    {
                        HMeasureSYS.g_TR4();
                    }
                    break;
                case "EndTR1":
                    if (HMeasureSYS.g_EndTR1 != null)
                    {
                        HMeasureSYS.g_EndTR1();
                    }
                    break;
                case "EndTR2":
                    if (HMeasureSYS.g_EndTR2 != null)
                    {
                        HMeasureSYS.g_EndTR2();
                    }
                    break;
                case "EndTR3":
                    if (HMeasureSYS.g_EndTR3 != null)
                    {
                        HMeasureSYS.g_EndTR3();
                    }
                    break;
                case "EndTR4":
                    if (HMeasureSYS.g_EndTR4 != null)
                    {
                        HMeasureSYS.g_EndTR4();
                    }
                    break;
            }
        }

        #region 配置文件
        public static void ReadConfig(string filePath)
        {
            try
            {// Deserialize.
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    fs.Seek(0, SeekOrigin.Begin);
                    BinaryFormatter binaryFmt = new BinaryFormatter();
                    HMeasureSYS.g_VariableList = (List<F_DATA_CELL>)binaryFmt.Deserialize(fs);
                    HMeasureSYS.g_AcqDeviceList = (List<AcqDeviceBase>)binaryFmt.Deserialize(fs);
                    AcqDeviceBase.m_LastDeviceID = (int)binaryFmt.Deserialize(fs);
                    HMeasureSYS.g_TcpServer = (TCPServer2)binaryFmt.Deserialize(fs);
                    HMeasureSYS.g_ProjectList = (List<CProject>)binaryFmt.Deserialize(fs);
                    CProject.m_LastProjectID = (int)binaryFmt.Deserialize(fs);
                    CProject.m_IsMangerGTCard=(bool)binaryFmt.Deserialize(fs);
                    //fs.Close();
                    //GT_MotionControl.Helper.InitMotionControl();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Measure.HMeasureSYS.ReadConfig:" + ex.ToString());
                LogHandler.Instance.VTLogError(ex.ToString());
            }
        }

        public static void SaveConfig(string filePath)
        {
            //添加相对路径判断 如果是相对路径 必须指定到exe目录 否则可能因为打开文件等对话框影响存储路径  yoga 2018-8-30 11:06:48
            string ThePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            string tempFile = "tempMeasureSys.cfg";
            tempFile=System.IO.Path.Combine(ThePath, tempFile);
            try
            {
                System.GC.Collect();
                using (FileStream fs = new FileStream(tempFile, FileMode.Create))
                {
                    BinaryFormatter binaryFmt = new BinaryFormatter();
                    fs.Seek(0, SeekOrigin.Begin);
                    binaryFmt.Serialize(fs, HMeasureSYS.g_VariableList);
                    binaryFmt.Serialize(fs, HMeasureSYS.g_AcqDeviceList);
                    binaryFmt.Serialize(fs, AcqDeviceBase.m_LastDeviceID);
                    binaryFmt.Serialize(fs, HMeasureSYS.g_TcpServer);
                    binaryFmt.Serialize(fs, HMeasureSYS.g_ProjectList);
                    binaryFmt.Serialize(fs, CProject.m_LastProjectID);
                    binaryFmt.Serialize(fs, CProject.m_IsMangerGTCard);
                    //fs.Close();
                }
                string outPath = filePath;
                if (filePath.Contains(@":\") == false)
                {
                    outPath = System.IO.Path.Combine(ThePath, filePath);
                }
                Helper.FileHelper.FileCoppy(tempFile, outPath);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("保存配置文件失败" + ex.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogHandler.Instance.VTLogError(ex.ToString());
            }
        }
        #endregion
        /// <summary>
        /// 检查所有相机是否在线
        /// </summary>
        /// <returns>全部在线为true</returns>
        public static bool CheckDevStatus()
        {
            foreach (AcqDeviceBase dev in HMeasureSYS.g_AcqDeviceList)
            {
                if (dev.m_bConnected==false)
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 初始化设备连接状态
        /// </summary>
        public static void InitDevStatus()
        {
            foreach (AcqDeviceBase dev in HMeasureSYS.g_AcqDeviceList)
            {
                if (dev.m_bConnected)
                {
                    dev.m_bConnected = false;
                    dev.ConnectDev();
                    dev.setSetting();
                }
                else
                {
                    dev.DisConnectDev();
                }
            }
        }

        /// <summary>
        /// 释放设备
        /// </summary>
        public static void DisposeDev()
        {
            foreach (AcqDeviceBase dev in HMeasureSYS.g_AcqDeviceList)
            {
                if (dev.m_bConnected)
                {
                    dev.DisConnectDev();
                }
            }
        }

        public void Dispose()
        {
        }

        #region "图像离线保存"
        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="filePath">文件存储路径</param>
        /// <param name="projectId">项目ID</param>
        /// <param name="imgName">保存图片的变量名称</param>
        public static void SaveImage(string filePath, int projectId, string imgName)
        {
            if (HMeasureSYS.g_ProjectList.Count > projectId)
            {
                RegisterIMG_Info tempImg = new RegisterIMG_Info();
                F_DATA_CELL datacell = HMeasureSYS.g_ProjectList[projectId].m_VariableList.FirstOrDefault(c => c.m_Data_CellID == HMeasureSYS.U000 && c.m_Data_Name == imgName);
                tempImg.m_Image = ((List<HImageExt>)datacell.m_Data_Value)[0].Clone();
                tempImg.m_ImageID = filePath;
                ThreadPool.QueueUserWorkItem(o =>
                {
                    try
                    {
                        RegisterIMG_Info imgInfo = (RegisterIMG_Info)tempImg;
                        string type = imgInfo.m_Image.GetImageType().ToString();
                        if (type.Contains("real"))
                        {
                            imgInfo.m_Image.WriteImage("tiff", 0, imgInfo.m_ImageID);
                        }
                        else if (type.Contains("byte"))
                        {
                            imgInfo.m_Image.WriteImage("tiff lzw alpha", 0, imgInfo.m_ImageID);
                        }
                    }
                    catch (System.Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.ToString());
                    }
                });
            }
        }

        /// <summary>
        /// 保存图像
        /// </summary>
        /// <param name="filepath">图像保存路径，不包括文件后缀如 .png</param>
        /// <param name="scaleSize">放缩比例，建议为1.0，不能小于0</param>
        /// <param name="isSaveSrcImage">是否保存原图，true表示保存原图，false表示保存效果图</param>
        /// <param name="imageName">图像名称 为空保存图像序列中的全部</param>
        public static void SaveImage(string filepath, double scaleSize, bool isSaveSrcImage, string imageName)
        {
            if (filepath == "")
            {
                System.Windows.Forms.MessageBox.Show("SaveBoardImage：输出路径为空！");
                return;
            }

            if (scaleSize <= 0)
            {
                System.Windows.Forms.MessageBox.Show("SaveBoardImage：scaleSize必须大于0！");
                return;
            }

            List<F_DATA_CELL> datalist = HMeasureSYS.Cur_Project.m_VariableList.FindAll(c => c.m_Data_CellID == HMeasureSYS.U000
                           && c.m_Data_Type == DataType.图像);
            foreach (F_DATA_CELL item in datalist)
            {
                if (imageName == "")
                {
                    SaveImage(filepath + "_" + HMeasureSYS.Cur_Project.m_ProjectName + "_" + item.m_Data_Name,
                              scaleSize,
                              isSaveSrcImage,
                              ((List<HImageExt>)item.m_Data_Value)[0].Clone());
                }
                else
                {
                    if (item.m_Data_Name == imageName)
                    {
                        SaveImage(filepath + "_" + HMeasureSYS.Cur_Project.m_ProjectName + "_" + item.m_Data_Name,
                                  scaleSize,
                                  isSaveSrcImage,
                                  ((List<HImageExt>)item.m_Data_Value)[0].Clone());
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 保存单一图像
        /// </summary>
        /// <param name="filepath">图像保存路径，不包括文件后缀如 .png</param>
        /// <param name="scaleSize">放缩比例，建议为1.0，不能小于0</param>
        /// <param name="isSaveSrcImage">是否保存原图，true表示保存原图，false表示保存效果图</param>
        /// <param name="srcImage">需要保存的图像</param>
        public static void SaveImage(string filepath, double scaleSize, bool isSaveSrcImage, HImageExt srcImage)
        {
            if (filepath == "")
            {
                System.Windows.Forms.MessageBox.Show("SaveBoardImage：输出路径为空！");
                return;
            }

            if (scaleSize <= 0)
            {
                System.Windows.Forms.MessageBox.Show("SaveBoardImage：scaleSize必须大于0！");
                return;
            }

            if (srcImage.IsInitialized() == false && srcImage != null)
            {
                System.Windows.Forms.MessageBox.Show("SaveBoardImage：图像未初始化！");
                return;
            }

            if (isSaveSrcImage)
            {
                ThreadPool.QueueUserWorkItem(o =>
                {
                    try
                    {
                        HImageExt image = srcImage.Clone();
                        string type = image.GetImageType().ToString();
                        if (type.Contains("real"))
                        {
                            image.WriteImage("tiff", 0, filepath);
                        }
                        else
                        {
                            image.WriteImage("tiff lzw alpha", 0, filepath);
                        }

                        image.Dispose();
                        GC.Collect();
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.ToString());
                    }
                });
            }
            else
            {
                ThreadPool.QueueUserWorkItem(o =>
                {
                    try
                    {
                        HImageExt image = srcImage.Clone();
                        int width, height;
                        image.GetImageSize(out width, out height);
                        ChoiceTech.Halcon.Control.HWindow_HE tempHWindow_HE = new ChoiceTech.Halcon.Control.HWindow_HE();
                        tempHWindow_HE.Size = new Size((int)(width * scaleSize), (int)(height * scaleSize));
                        tempHWindow_HE.showHE(image);
                        HImage img = tempHWindow_HE.hWindowControl.HalconWindow.DumpWindowImage();
                        img.WriteImage("tiff lzw alpha", 0, filepath);
                        tempHWindow_HE.Dispose();
                        image.Dispose();
                        GC.Collect();
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.ToString());
                    }
                });
            }
        }
        #endregion
    }
}
