
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Helper
{
    public class HMath
    {

        /// <summary>
        /// 最小二乘法直线拟合
        /// </summary>
        /// <param name="xv">x点序列</param>
        /// <param name="zv">y点序列</param>
        /// <param name="num">个数</param>
        /// <param name="k">斜率</param>
        /// <param name="b">b</param>
        /// <returns></returns>
        public static bool fitLine(double[] xv, double[] zv, int num, out double k, out double b)
        {
            if (num < 3)
            {
                k = 0; b = 0;
                return false;
            }
            double A = 0.0;
            double B = 0.0;
            double C = 0.0;
            double D = 0.0;


            for (int i = 0; i < num; i++)
            {
                //ss.Format("i = %d,num = %d, %0.3f,%0.3f",i,num,xv[i],zv[i]);
                //AfxMessageBox(ss);
                A += (xv[i] * xv[i]);
                B += xv[i];
                C += (zv[i] * xv[i]);
                D += zv[i];
            }

            double tmp = 0;
            tmp = (A * num - B * B);

            if (Math.Abs(tmp) > 0.000001)
            {
                k = (C * num - B * D) / tmp;
                b = (A * D - C * B) / tmp;
            }
            else
            {
                k = 1;
                b = 0;
            }
            return true;
        }

        /// <summary>
        /// 通过最小二乘法拟合直线，计算斜率k和截距b,该算法当k趋近于1时，b！=0
        /// </summary>
        /// <remarks>y位基准值，x为测量值</remarks>
        public static void CalSlopeAndIntercept(double[] x, double[] y, out double K, out double b)
        {
            try
            {
                if (x.Length == y.Length && x.Length > 1)
                {
                    int nCount = x.Length;
                    double SumX = default(double);
                    double SumY = default(double);
                    double SumXY = default(double);
                    double SumX2 = default(double);
                    double Slope = default(double);
                    double Intercept = default(double);
                    SumX = 0;
                    SumX2 = 0;
                    for (int i = 0; i <= nCount - 1; i++)
                    {
                        SumX += System.Convert.ToDouble(x[i]); //横坐标的和
                        SumX2 += x[i] * x[i]; //横坐标的平方的和
                    }

                    SumY = 0;
                    for (int i = 0; i <= nCount - 1; i++)
                    {
                        SumY += System.Convert.ToDouble(y[i]); //纵坐标的和
                    }

                    SumXY = 0;
                    for (int i = 0; i <= nCount - 1; i++)
                    {
                        SumXY += x[i] * y[i]; //横坐标乘以纵坐标的积的和
                    }

                    Intercept = System.Convert.ToDouble((SumX2 * SumY - SumX * SumXY) / (nCount * SumX2 - SumX * SumX)); //截距
                    Slope = System.Convert.ToDouble((nCount * SumXY - SumX * SumY) / (nCount * SumX2 - SumX * SumX)); //斜率

                    K = Slope;
                    b = Intercept;
                }
                else
                {
                    K = 1;
                    b = 0;
                }
            }
            catch (Exception ex)
            {
                K = 1; b = 0;
            }

        }

        /// <summary>
        /// 计算标准差
        /// </summary>
        /// <param name="array">标准差数组</param>
        /// <returns>返回标准差值</returns>
        public static double StandardDev(double[] array)
        {
            double dStdev = 0d;
            try
            {
                int N = array.Length;
                double sum = 0;//总和  
                double avg;//平均值  
                for (int i = 0; i < N; i++)
                {
                    sum += array[i];//求总和  
                }
                avg = sum / N;//计算平均值  
                double Spow = 0;
                for (int i = 0; i < N; i++)
                {
                    Spow += (array[i] - avg) * (array[i] - avg);//平方累加  
                }
                dStdev = Math.Sqrt(Spow / N);
                return dStdev;
            }
            catch (Exception ex)
            {
                return dStdev;
            }
        }

    }

    #region PCL 平面度算法
    public struct tagPlane
    {
        //平面方程 ax+by+cz+d=0
        /// <summary>ratio of the X</summary>
        public double a;
        /// <summary>ratio of the Y</summary>
        public double b;
        /// <summary>ratio of the Z</summary>
        public double c;
        /// <summary>constant of the plane's equation</summary>
        public double d;
    };

    /// <summary>
    /// ratio of plane's equation and curvature
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VectorInfo
    {
        /// <summary>ratio of the X</summary>
        public float _ratioX;
        /// <summary>ratio of the Y</summary>
        public float _ratioY;
        /// <summary>ratio of the Z</summary>
        public float _ratioZ;
        /// <summary>constant of the plane's equation</summary>
        public float _constant;
        /// <summary>curvature</summary>
        public float _curvature;
        /// <summary>reserve</summary>
        public float _reserve;
    };
    /// <summary>
    /// DLL function calling class
    /// </summary>	
    public static class PCL_Methods
    {
        /** \brief 将坐标存入点云，
        * \param[in] 输入点X坐标
        * \param[in] 输入点Y坐标
        * \param[in] 输入点Z坐标  
        * \param[in] 输入点I坐标
        * \param[in] 输入列数
        * \param[in] 输入行数 
        * \param[out] 返回的点云 
        */
        [DllImport("PCL_Library_Dll.dll", CallingConvention = CallingConvention.Cdecl)]
        /*使用pcl内部算法 返回平面方程和曲率，但根据使用经验，当点趋于平面是效果不好*/
        public static extern int compute_PointNormal(Single[] iX, Single[] iY, Single[] iZ, int length, ref VectorInfo _vectorInfo);

        [DllImport("PCL_Library_Dll.dll", CallingConvention = CallingConvention.Cdecl)]
        /*使用网友改编的算法 返回平面方程，Z值永远为1*/
        public static extern int compute_PointNormal2(Single[] iX, Single[] iY, Single[] iZ, int length, ref VectorInfo _vectorInfo);

        [DllImport("PCL_Library_Dll.dll", CallingConvention = CallingConvention.Cdecl)]
        /*用第一种方法计算平面度*/
        public static extern int Calculate_Flatness(Single[] iX, Single[] iY, Single[] iZ, int length, ref double _result);

        [DllImport("PCL_Library_Dll.dll", CallingConvention = CallingConvention.Cdecl)]
        /*用第二种方法计算平面度*/
        public static extern int Calculate_Flatness2(Single[] iX, Single[] iY, Single[] iZ, int length, ref double _result);

        /// <summary>
        /// 用PCL中的算法拟合平面
        /// </summary>
        /// <param name="lstX">x坐标序列点</param>
        /// <param name="lstY">y坐标序列点</param>
        /// <param name="lstZ">z坐标序列点</param>
        /// <returns></returns>
        public static tagPlane CalPlane2(List<double> lstX, List<double> lstY, List<double> lstZ)
        {
            tagPlane plane = new tagPlane();
            try
            {
                VectorInfo vec_info = new VectorInfo();
                Single[] iX = Array.ConvertAll<double, float>(lstX.ToArray(), a => Convert.ToSingle(a));
                Single[] iY = Array.ConvertAll<double, float>(lstY.ToArray(), a => Convert.ToSingle(a));
                Single[] iZ = Array.ConvertAll<double, float>(lstZ.ToArray(), a => Convert.ToSingle(a));

                PCL_Methods.compute_PointNormal2(iX, iY, iZ, iX.Length, ref vec_info);
                plane.a = vec_info._ratioX;
                plane.b = vec_info._ratioY;
                plane.c = vec_info._ratioZ;
                plane.d = vec_info._constant;
            }
            catch (Exception ex)
            {
            }
            return plane;
        }

        /// <summary>
        /// 用PCL方法计算平面度
        /// </summary>
        /// <param name="lstX">x坐标序列点</param>
        /// <param name="lstY">y坐标序列点</param>
        /// <param name="lstZ">z坐标序列点</param>
        /// <returns></returns>
        public static double CalFlatness2(List<double> lstX, List<double> lstY, List<double> lstZ)
        {
            double flatness = 0;
            try
            {
                Single[] iX = Array.ConvertAll<double, float>(lstX.ToArray(), a => Convert.ToSingle(a));
                Single[] iY = Array.ConvertAll<double, float>(lstY.ToArray(), a => Convert.ToSingle(a));
                Single[] iZ = Array.ConvertAll<double, float>(lstZ.ToArray(), a => Convert.ToSingle(a));
                PCL_Methods.Calculate_Flatness2(iX, iY, iZ, iX.Length, ref flatness);
            }
            catch (Exception ex)
            {
                //Helper.LogHandler.Instance.VTLogError(ex.ToString());
            }
            return flatness;
        }
        #endregion
    }
}
