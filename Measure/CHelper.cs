using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Measure;
using CPublicDefine;
using HEViewer;

namespace Measure
{
    public class CHelper
    {
        #region 声明 API 函数 
        /// <summary>
        /// SendMessage发送消息后会等对方处理完这个消息后才会继续
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern IntPtr SendMessage(int hWnd, int msg, IntPtr wParam, IntPtr lParam);
        /// <summary>
        /// PostMessage则将消息发送出去后就会继续,注意指针会销毁
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        [DllImport("User32.dll", EntryPoint = "PostMessage")]
        public static extern void PostMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);

        [DllImport("User32.dll", EntryPoint = "SetParent")]
        public static extern int SetParent(int hWndChild, int hWndNewParent);
        #endregion

        #region 定义消息常数 
        public const int MAIN_MESSAGE = 0X400 + 1;//自定义消息
        public const int VIEW_MESSAGE = 0X400 + 2;//自定义消息
        //public const int MAIN_UNIT = 0X400 + 3;//自定义消息
        #endregion

        #region 定义窗体句柄
        /// <summary>
        /// 显示日志句柄
        /// </summary>
        public static IntPtr g_ViewLogWnd = IntPtr.Zero;
        /// <summary>
        /// 主窗体句柄
        /// </summary>
        public static IntPtr g_MainWnd = IntPtr.Zero;
        /// <summary>
        /// 结果窗体句柄
        /// </summary>
        public static IntPtr g_ResultViewWnd = IntPtr.Zero;
        #endregion

        /// <summary>
        /// 回调结果数据
        /// </summary>
        /// <param name="ID">当前projectID</param>
        /// <param name="sResult">结果字符串</param>
        /// <returns>放回值</returns>
        public delegate int dlgResult(int ID, string sResult);

        /// <summary>
        /// 更新视觉主界面列表
        /// </summary>
        /// <param name="C">当前项目</param>
        public delegate void DlgUpdateProjectList(CProject C);
        public static DlgUpdateProjectList UpdateProject;
        /// <summary>
        /// 更新ShowView窗体
        /// </summary>
        /// <param name="mUnit">单元信息</param>
        public delegate void DlgUpdateWindow(CMeasureCell mUnit);
        public static DlgUpdateWindow dlgUpdate = null;

        /// <summary>
        /// 将he插入到HeViewer magical 20170823
        /// </summary>
        /// <param name="name">项目名称+变量名称</param>
        /// <param name="he">he</param>
        public delegate void DlgInsertHe(string name, HImageExt he);
        public static DlgInsertHe insertHe2HeViewer;

        public delegate void InsertHE2AutoRunWindow(List<HImageExt> heList, string projectName);
        public static InsertHE2AutoRunWindow InsertHe2ExtWindow;
        //public static Frm_HEViewer frm_HEViewer = new Frm_HEViewer(true);// 效果图展示窗口  magical 20170823

        /// <summary>
        /// 将输入的字符串转换
        /// </summary>
        /// <param name="strName">输入字符串</param>
        /// <returns></returns>
        public static string TransChar(string strName)
        {
            string str = string.Empty;
            if (strName == "逗 号")
            {
                str = ",";
            }
            else if (strName == "分 号")
            {
                str = ";";
            }
            else if (strName == "空 格")
            {
                str = " ";
            }
            else if (strName == "# 号")
            {
                str = "#";
            }
            else if (strName == "$ 号")
            {
                str = "$";
            }
            else if (strName == "* 号")
            {
                str = "*";
            }
            else if (strName == "@ 号")
            {
                str = "@";
            }
            else if (strName == "% 号")
            {
                str = "%";
            }
            else if (strName == "& 号")
            {
                str = "&";
            }
            return str;
        }
    }
}
