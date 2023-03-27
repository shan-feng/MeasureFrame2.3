using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace AcqDevice
{
    class Wenglor_SDK
    {
        [DllImport("EthernetScanner.dll", EntryPoint = "EthernetScanner_Connect", CallingConvention = CallingConvention.StdCall)]
        //private unsafe static extern IntPtr EthernetScanner_Connect(StringBuilder chIP, StringBuilder chPort, int uiNonBlockingTimeOut);
        public static extern IntPtr EthernetScanner_Connect(string ipAddress, string port, int nonBlockingTimeOut);

        [DllImport("EthernetScanner.dll", EntryPoint = "EthernetScanner_ConnectEx", CallingConvention = CallingConvention.StdCall)]
        public static extern void EthernetScanner_ConnectEx(IntPtr sensorHandle, string ipAddress, string port, int timeOut);

        [DllImport("EthernetScanner.dll", EntryPoint = "EthernetScanner_Disconnect", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr EthernetScanner_Disconnect(IntPtr hScanner);

        [DllImport("EthernetScanner.dll", EntryPoint = "EthernetScanner_GetConnectStatus", CallingConvention = CallingConvention.StdCall)]
        public static extern void EthernetScanner_GetConnectStatus(IntPtr hScanner, int[] uiConnectStatus);

        [DllImport("EthernetScanner.dll", EntryPoint = "EthernetScanner_WriteData", CallingConvention = CallingConvention.StdCall)]
        public static extern int EthernetScanner_WriteData(IntPtr hScanner, byte[] chWriteBuffer, int uiWriteBufferLength);

        [DllImport("EthernetScanner.dll", EntryPoint = "EthernetScanner_GetVersion", CallingConvention = CallingConvention.StdCall)]
        public static extern int EthernetScanner_GetVersion(StringBuilder ucBuffer, int uiBuffer);

        [DllImport("EthernetScanner.dll", EntryPoint = "EthernetScanner_GetXZIExtended", CallingConvention = CallingConvention.StdCall)]
        public static extern int EthernetScanner_GetXZIExtended(IntPtr sensorHandle,
                                                                double[] x,
                                                                double[] z,
                                                                int[] intensity,
                                                                int[] peakWidth,
                                                                int buffer,
                                                                int[] encoder,
                                                                byte[] pucUSRIO,
                                                                int timeOut,
                                                                byte[] ucBufferRaw,
                                                                int iBufferRaw,
                                                                int[] picCount);

        [DllImport("EthernetScanner.dll", EntryPoint = "EthernetScanner_GetInfo", CallingConvention = CallingConvention.StdCall)]
        public static extern int EthernetScanner_GetInfo(IntPtr sensorHandle, StringBuilder info, int buffer, string mode);

        [DllImport("EthernetScanner.dll", EntryPoint = "EthernetScanner_ResetDllFiFo", CallingConvention = CallingConvention.StdCall)]
        public static extern int EthernetScanner_ResetDllFiFo(IntPtr sensorHandle);

        [DllImport("EthernetScanner.dll", EntryPoint = "EthernetScanner_GetDllFiFoState", CallingConvention = CallingConvention.StdCall)]
        public static extern int EthernetScanner_GetDllFiFoState(IntPtr sensorHandle);


        public static int iETHERNETSCANNER_TCPSCANNERDISCONNECTED = 0;
        public static int iETHERNETSCANNER_TCPSCANNERCONNECTING = 1;
        public static int iETHERNETSCANNER_TCPSCANNERDISCONNECTING = 2;
        public static int iETHERNETSCANNER_TCPSCANNERCONNECTED = 3;

        public static int iETHERNETSCANNER_PEAKSPERCMOSSCANLINEMAX = 2;
        public static int iETHERNETSCANNER_SCANXMAX = 2048;
        //int iETHERNETSCANNER_BUFFERSIZEMAX = 2050 * 2050;

        public static int iETHERNETSCANNER_GETINFOSIZEMAX = 128 * 1024;
        public static int iETHERNETSCANNER_GETINFONOVALIDINFO = -3;
        public static int iETHERNETSCANNER_GETINFOSMALLBUFFER = -2;
        public static int iETHERNETSCANNER_ERROR = -1;

        public static int iETHERNETSCANNER_OK = 0;
    }
}
