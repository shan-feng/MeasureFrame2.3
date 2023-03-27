using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Measure;

namespace Measure_Sys
{
    public class CHelper
    {
        #region "声明 API 函数"
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

        #region "定义消息常数"
        public const int MAIN_MESSAGE = 0X400 + 1;//自定义消息
        public const int VIEW_MESSAGE = 0X400 + 2;//自定义消息
        #endregion

        #region "定义窗体句柄"
        public static IntPtr g_ViewLogWnd = IntPtr.Zero;
        public static IntPtr g_MainWnd = IntPtr.Zero;
        public static IntPtr g_ResultViewWnd = IntPtr.Zero;
        #endregion
    }
}
