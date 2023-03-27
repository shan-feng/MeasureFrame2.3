using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using Measure.UserDefine;
using CPublicDefine;

namespace Measure
{
    public class VBA_Function
    {
        private static int m_ProIndex = 0;
        public static int m_ProjectID
        {
            set
            {
                m_ProIndex = HMeasureSYS.g_ProjectList.FindIndex(c => c.m_ProjectID == value);
            }

        }

        /// <summary>
        /// 信息提示框
        /// </summary>
        /// <param name="s">提示信息</param>
        public static void Show(string s)
        {
            MessageBox.Show(s);
        }
        /// <summary>
        /// 触发对应的trigger
        /// </summary>
        /// <param name="str">trigger名称 TR1,TR2,TR3,TR4</param>
        public static void T(string str)
        {
            HMeasureSYS.setTrigger(str);
        }
        /// <summary>
        /// 服务器socket给客户端发送信息
        /// </summary>
        /// <param name="str">发送信息</param>
        public static void SendMsg(string str)
        {
            HMeasureSYS.g_TcpServer.SendMsgUserToEveryone(Encoding.Default.GetBytes(str));
        }

        /// <summary>
        /// 后面单元的变量的值赋给前面全局变量 
        /// </summary>
        /// <param name="outUnitID">输出ID  小于0 -全局变量 大于等于0 -局部变量</param>
        /// <param name="outName">输出变量名称</param>
        /// <param name="inUnitID">赋值单元ID</param>
        /// <param name="inName">赋值的变量名</param>
        public static void SetValue(int outUnitID, string outName, int inUnitID, string inName)
        {
            if (outUnitID > 0)
            {
                MessageBox.Show("不允许给单元变量赋值");
            }
            else
            {
                F_DATA_CELL dataSrc;
                F_DATA_CELL dataDst;
                if (inUnitID < 0)
                    dataSrc = HMeasureSYS.g_VariableList.FirstOrDefault(c => c.m_Data_CellID == inUnitID && c.m_Data_Name.ToUpper() == inName.Trim().ToUpper());
                else
                    dataSrc = HMeasureSYS.g_ProjectList[m_ProIndex].m_VariableList.FirstOrDefault(c => c.m_Data_CellID == HMeasureSYS.U000 && c.m_Data_Name.ToUpper() == inName.Trim().ToUpper());

                if (outUnitID < 0)
                {
                    dataDst = HMeasureSYS.g_VariableList.FirstOrDefault(c => c.m_Data_CellID == outUnitID && c.m_Data_Name.ToUpper() == outName.Trim().ToUpper());
                    if (dataDst.m_Data_Type == dataSrc.m_Data_Type && dataDst.m_Data_Group == dataSrc.m_Data_Group)
                    {
                        dataDst.m_Data_Value = dataSrc.m_Data_Value;
                        int index = HMeasureSYS.g_VariableList.FindIndex(c => c.m_Data_CellID == outUnitID && c.m_Data_Name.ToUpper() == outName.Trim().ToUpper());
                        HMeasureSYS.g_VariableList[index] = dataDst;
                    }
                    else
                        MessageBox.Show("值类型或值复数不一致，不允许赋值");
                }
                else
                {
                    dataDst = HMeasureSYS.g_ProjectList[m_ProIndex].m_VariableList.FirstOrDefault(c => c.m_Data_CellID == outUnitID && c.m_Data_Name.ToUpper() == outName.Trim().ToUpper());
                    if (dataDst.m_Data_Type == dataSrc.m_Data_Type && dataDst.m_Data_Group == dataSrc.m_Data_Group)
                    {
                        dataDst.m_Data_Value = dataSrc.m_Data_Value;
                        int index = HMeasureSYS.g_ProjectList[m_ProIndex].m_VariableList.FindIndex(c => c.m_Data_CellID == outUnitID && c.m_Data_Name.ToUpper() == outName.Trim().ToUpper());
                        HMeasureSYS.g_ProjectList[m_ProIndex].m_VariableList[index] = dataDst;
                    }
                    else
                        MessageBox.Show("值类型或值复数不一致，不允许赋值");
                }
            }


        }

        /// <summary>
        /// 后面的变量的值赋给前面全局变量
        /// </summary>
        /// <param name="outUnitID"></param>
        /// <param name="outName"></param>
        /// <param name="_value"></param>
        public static void SetValue(int outUnitID, string outName, object _value)
        {
            if (outUnitID < 0)
                SetValue(ref HMeasureSYS.g_VariableList, HMeasureSYS.USys, outName, _value);
            else if (outUnitID == 0)
                SetValue(ref HMeasureSYS.g_ProjectList[m_ProIndex].m_VariableList, HMeasureSYS.U000, outName, _value);
            else
                MessageBox.Show("不允许给单元变量赋值");
        }

        /// <summary>
        /// 获取变量值
        /// </summary>
        /// <param name="UnitID">单元ID</param>
        /// <param name="inName">变量名称</param>
        /// <returns>object返回值</returns>
        public static object GetValue(int UnitID, string inName)
        {
            object _value = null;
            if (UnitID < 0)
                _value = GetValue(HMeasureSYS.g_VariableList, HMeasureSYS.USys, inName);
            else
            {
                bool checkOk = false;
                //单元0不参与判断 林玉刚 2018-9-12 15:26:20
                if (UnitID == 0)
                {
                    checkOk = true;
                }
                else
                {
                    //只有执行成功才获取值,否则获取到的可能是上次的值  20180823 林玉刚
                    CMeasureCell cell = HMeasureSYS.g_ProjectList[m_ProIndex].m_CellList.FirstOrDefault(c => c.m_CellID == UnitID);
                    if (cell != null && cell.blnSuccessed)
                    {
                        checkOk = true;
                    }
                }

                if (checkOk)
                {
                    _value = GetValue(HMeasureSYS.g_ProjectList[m_ProIndex].m_VariableList, UnitID, inName);
                }

            }

            return _value;
        }

        /// <summary>
        /// 给定义的变量赋值 只限全局变量
        /// </summary>
        /// <param name="VariableList">输出变量列表</param>
        /// <param name="outUnitID">输出变量ID</param>
        /// <param name="outName">输出变量名称</param>
        /// <param name="_value">变量值</param>
        private static void SetValue(ref List<F_DATA_CELL> VariableList, int outUnitID, string outName, object _value)
        {
            try
            {
                int index = VariableList.FindIndex(c => c.m_Data_CellID == outUnitID && c.m_Data_Name.ToUpper() == outName.Trim().ToUpper());
                F_DATA_CELL data2 = VariableList.FirstOrDefault(c => c.m_Data_CellID == outUnitID && c.m_Data_Name.ToUpper() == outName.Trim().ToUpper());
                data2.SetValue(data2.m_Data_Type, _value);
                VariableList[index] = data2;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("自定义变量给" + outUnitID + "单元的变量 " + outName + " 赋值时出错", "Error");
            }

        }

        public static void Sys_Start(int index)
        {
            HMeasureSYS.g_SysStatus.m_RunMode = RunMode.循环运行;
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


        /// <summary>
        /// 获取变量值
        /// </summary>
        /// <param name="VariableList">变量列表</param>
        /// <param name="UnitID">单元ID</param>
        /// <param name="inName">变量名称</param>
        /// <returns>object返回值</returns>
        private static object GetValue(List<F_DATA_CELL> VariableList, int UnitID, string inName)
        {
            object _value = null;
            try
            {
                F_DATA_CELL data = VariableList.FirstOrDefault(c => c.m_Data_CellID == UnitID && c.m_Data_Name.ToUpper() == inName.Trim().ToUpper());
                return data.GetValue();
            }
            catch (System.Exception ex)
            {
                return _value;
            }
        }

        /// <summary>
        /// 获取单元输出的行列坐标值
        /// </summary>
        /// <param name="IDList">单元ID列表 用逗号隔开 eg："3,4"</param>
        /// <param name="X">列坐标</param>
        /// <param name="Y">行坐标</param>
        /// <returns></returns>
        public static bool getPoints(string IDList, out List<Double> X, out List<Double> Y)
        {
            X = new List<Double>();
            Y = new List<Double>();

            try
            {
                foreach (string s in IDList.Split(','))
                {
                    int index = int.Parse(s);

                    F_DATA_CELL data1 = HMeasureSYS.g_ProjectList[m_ProIndex].m_VariableList.FirstOrDefault(c => c.m_Data_CellID == index && c.m_Data_Name == "outY");
                    F_DATA_CELL data2 = HMeasureSYS.g_ProjectList[m_ProIndex].m_VariableList.FirstOrDefault(c => c.m_Data_CellID == index && c.m_Data_Name == "outX");
                    Y = Y.Concat((List<double>)data1.m_Data_Value).ToList();
                    X = X.Concat((List<double>)data2.m_Data_Value).ToList();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        ///// <summary>
        ///// 计算两条直线的距离
        ///// </summary>
        ///// <param name="Line1">直线1</param>
        ///// <param name="Line2">直线2</param>
        ///// <param name="Dis">距离</param>
        //public static void DistanceLL(Line_INFO Line1, Line_INFO Line2, out double Dis)
        //{
        //    //直线方程
        //    //r*Ny+c*Nx-Dist=0   A*X+B*Y+C=0
        //    Dis = 0.0;
        //    try
        //    {
        //        Line_INFO line_C = new Line_INFO();
        //        //Line 向量夹角
        //        //Vector v_Line1 = new PointF(Line1.EndX - Line1.StartX, Line1.EndY - Line1.StartY);
        //        //Vector v_Line2 = new PointF(Line2.EndX - Line2.StartX, Line2.EndY - Line2.StartY);
        //        double A = (Line1.EndX - Line1.StartX) * (Line2.EndX - Line2.StartX) + (Line1.EndY - Line1.StartY) * (Line2.EndY - Line2.StartY);
        //        double B = Math.Sqrt(Math.Pow(Line1.EndX - Line1.StartX, 2) + Math.Pow(Line1.EndY - Line1.StartY, 2)) * Math.Sqrt(Math.Pow(Line2.EndX - Line2.StartX, 2) + Math.Pow(Line2.EndY - Line2.StartY, 2));
        //        double cosT = A / B;
        //        if (Math.Abs(Math.Acos(cosT)) > Math.PI / 2)
        //        {
        //            line_C.StartY = (Line1.StartY + Line2.EndY) / 2;
        //            line_C.StartX = (Line1.StartX + Line2.EndX) / 2;
        //            line_C.EndY = (Line1.EndY + Line2.StartY) / 2;
        //            line_C.EndX = (Line1.EndX + Line2.StartX) / 2;
        //        }
        //        else
        //        {
        //            line_C.StartY = (Line1.StartY + Line2.StartY) / 2;
        //            line_C.StartX = (Line1.StartX + Line2.StartX) / 2;
        //            line_C.EndY = (Line1.EndY + Line2.EndY) / 2;
        //            line_C.EndX = (Line1.EndX + Line2.EndX) / 2;
        //        }
        //        double Distance1 = HMisc.DistancePl((Line1.StartY + Line1.EndY) / 2, (Line1.StartX + Line1.EndX) / 2, line_C.StartY, line_C.StartX, line_C.EndY, line_C.EndX);
        //        double Distance2 = HMisc.DistancePl((Line2.StartY + Line2.EndY) / 2, (Line2.StartX + Line2.EndX) / 2, line_C.StartY, line_C.StartX, line_C.EndY, line_C.EndX);
        //        Dis = Distance1 + Distance2;
        //    }
        //    catch (System.Exception ex)
        //    {

        //    }
        //}

        /// <summary>
        /// 计算点到线的距离
        /// </summary>
        /// <param name="rows">点行序列</param>
        /// <param name="cols">点列序列</param>
        /// <param name="Line1">线</param>
        /// <param name="dis">返回距离</param>
        public static void DistancePL(List<Double> rows, List<Double> cols, Line_INFO Line1, out List<Double> dis)
        {
            dis = new List<Double>() { -999.999 };
            try
            {
                HTuple disT = HMisc.DistancePl(new HTuple(rows.ToArray()), new HTuple(cols.ToArray()), new HTuple(Line1.StartY), new HTuple(Line1.StartX), new HTuple(Line1.EndY), new HTuple(Line1.EndX));
                dis = disT.ToDArr().ToList();
            }
            catch (System.Exception ex)
            {

            }
        }

        /// <summary>
        /// 点到点的距离
        /// </summary>
        /// <param name="rows1">点1的行序列</param>
        /// <param name="cols1">点1的列序列</param>
        /// <param name="rows2">点2的行序列</param>
        /// <param name="cols2">点2的列序列</param>
        /// <param name="dis">返回距离</param>
        public static void DistancePP(List<Double> rows1, List<Double> cols1, List<Double> rows2, List<Double> cols2, out List<Double> dis)
        {
            dis = new List<Double>();
            try
            {
                HTuple disT = HMisc.DistancePp(new HTuple(rows1.ToArray()), new HTuple(cols1.ToArray()), new HTuple(rows2.ToArray()), new HTuple(cols2.ToArray()));
                dis = disT.ToDArr().ToList();

            }
            catch (System.Exception ex)
            {

            }
        }


        /// <summary>
        /// 点到点的距离
        /// </summary>
        /// <param name="rows1">点1的行序列</param>
        /// <param name="cols1">点1的列序列</param>
        /// <param name="rows2">点2的行序列</param>
        /// <param name="cols2">点2的列序列</param>
        /// <returns>距离结果</returns>
        public static double DistancePP(double rows1, double cols1, double rows2, double cols2)
        {
            double dis = 0.0;
            try
            {
                dis = HMisc.DistancePp(rows1, cols1, rows2, cols2);
            }
            catch (System.Exception ex)
            {

            }
            return dis;
        }

        /// <summary>
        /// 点转换为世界坐标
        /// </summary>
        /// <param name="Calib">相机标定参数</param>
        /// <param name="rows">行序列</param>
        /// <param name="cols">列序列</param>
        /// <param name="X">输出 X</param>
        /// <param name="Y">输出 Y</param>
        public static void ConvPix2World(List<Double> Calib, List<Double> rows, List<Double> cols, out List<Double> X, out List<Double> Y)
        {
            X = new List<double>();
            Y = new List<Double>();
            HTuple _x = new HTuple();
            HTuple _y = new HTuple();
            try
            {
                HTuple CamPar = new HTuple(Calib.Take(8).ToArray());
                HTuple CamPose = new HTuple();
                for (int i = 8; i < Calib.Count; i++)
                {
                    CamPose.Append(new HTuple(Calib[i]));
                }
                //18此函数取消
                //HMisc.ImagePointsToWorldPlane(CamPar, new HPose(CamPose), new HTuple(rows.ToArray()), new HTuple(cols.ToArray()), "mm", out _x, out _y);
                HOperatorSet.ImagePointsToWorldPlane(CamPar, new HPose(CamPose), new HTuple(rows.ToArray()), new HTuple(cols.ToArray()), "mm", out _x, out _y);
                X = _x.DArr.ToList();
                Y = _y.DArr.ToList();
            }
            catch (System.Exception ex)
            {

            }
        }

        /// <summary>
        /// 两条直线交点
        /// </summary>
        /// <param name="line1">直线1</param>
        /// <param name="line2">直线2</param>
        /// <param name="row">交点row</param>
        /// <param name="col">交点col</param>
        /// <param name="isParallel">平行1，不平行0</param>
        public static void IntersectionLl(Line_INFO line1, Line_INFO line2, out Double row, out Double col, out int isParallel)
        {
            row = 0.0;
            col = 0.0;
            isParallel = 0;
            try
            {
                HMisc.IntersectionLl(line1.StartY, line1.StartX, line1.EndY, line1.EndX,
                    line2.StartY, line2.StartX, line2.EndY, line2.EndX, out row, out col, out isParallel);
            }
            catch (System.Exception ex)
            {

            }
        }

        /// <summary>
        /// /使用halcon的拟合直线算法,比fitLine更准确,因为有其自己的剔除异常点算法
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="line"></param>
        /// <returns>结果直线</returns>
        public static bool fitLineByH(List<Double> rows, List<Double> cols, out Line_INFO line)
        {
            line = new Line_INFO();
            try
            {
                SortPairs(ref rows, ref cols);
                double rowBegin, colBegin, rowEnd, colEnd, nr, nc, dist;
                HXLDCont lineXLD = new HXLDCont(new HTuple(rows.ToArray()), new HTuple(cols.ToArray()));
                lineXLD.FitLineContourXld("tukey", -1, 0, 5, 2, out rowBegin, out colBegin, out rowEnd, out colEnd, out nr, out nc, out dist);//tukey剔除算法为halcon推荐算法
                line = new Line_INFO(rowBegin, colBegin, rowEnd, colEnd);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        /// <summary>
        /// 点排序
        /// </summary>
        /// <param name="hv_T1"></param>
        /// <param name="hv_T2"></param>
        public static void SortPairs(ref HTuple hv_T1, ref HTuple hv_T2)
        {
            HTuple hv_Sorted1 = new HTuple();
            HTuple hv_Sorted2 = new HTuple();
            HTuple hv_SortMode = new HTuple();
            HTuple hv_Indices1 = new HTuple(), hv_Indices2 = new HTuple();
            if ((hv_T1.TupleMax().D - hv_T1.TupleMin().D) > (hv_T2.TupleMax().D - hv_T2.TupleMin().D))
                hv_SortMode = new HTuple("1");
            else
                hv_SortMode = new HTuple("2");
            if ((int)((new HTuple(hv_SortMode.TupleEqual("1"))).TupleOr(new HTuple(hv_SortMode.TupleEqual(
                1)))) != 0)
            {
                HOperatorSet.TupleSortIndex(hv_T1, out hv_Indices1);
                hv_Sorted1 = hv_T1.TupleSelect(hv_Indices1);
                hv_Sorted2 = hv_T2.TupleSelect(hv_Indices1);
            }
            else if ((int)((new HTuple((new HTuple(hv_SortMode.TupleEqual("column"))).TupleOr(
                new HTuple(hv_SortMode.TupleEqual("2"))))).TupleOr(new HTuple(hv_SortMode.TupleEqual(
                2)))) != 0)
            {
                HOperatorSet.TupleSortIndex(hv_T2, out hv_Indices2);
                hv_Sorted1 = hv_T1.TupleSelect(hv_Indices2);
                hv_Sorted2 = hv_T2.TupleSelect(hv_Indices2);
            }
            hv_T1 = hv_Sorted1;
            hv_T2 = hv_Sorted2;
        }
        /// <summary>
        /// 点排序
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        public static void SortPairs(ref List<double> rows, ref List<double> cols)
        {
            HTuple hv_T1 = new HTuple(rows.ToArray());
            HTuple hv_T2 = new HTuple(cols.ToArray());
            //相同的方法 直接使用htuple返回结果
            SortPairs(ref hv_T1, ref hv_T2);
            rows = hv_T1.ToDArr().ToList();
            cols = hv_T2.ToDArr().ToList();
            return;

            //HTuple hv_Sorted1 = new HTuple();
            //HTuple hv_Sorted2 = new HTuple();
            //HTuple hv_SortMode = new HTuple();
            //HTuple hv_Indices1 = new HTuple(), hv_Indices2 = new HTuple();
            //if ((rows.Max() - rows.Min()) > (cols.Max() - cols.Min()))
            //    hv_SortMode = new HTuple("1");
            //else
            //    hv_SortMode = new HTuple("2");
            //if ((int)((new HTuple(hv_SortMode.TupleEqual("1"))).TupleOr(new HTuple(hv_SortMode.TupleEqual(
            //    1)))) != 0)
            //{
            //    HOperatorSet.TupleSortIndex(hv_T1, out hv_Indices1);
            //    hv_Sorted1 = hv_T1.TupleSelect(hv_Indices1);
            //    hv_Sorted2 = hv_T2.TupleSelect(hv_Indices1);
            //}
            //else if ((int)((new HTuple((new HTuple(hv_SortMode.TupleEqual("column"))).TupleOr(
            //    new HTuple(hv_SortMode.TupleEqual("2"))))).TupleOr(new HTuple(hv_SortMode.TupleEqual(
            //    2)))) != 0)
            //{
            //    HOperatorSet.TupleSortIndex(hv_T2, out hv_Indices2);
            //    hv_Sorted1 = hv_T1.TupleSelect(hv_Indices2);
            //    hv_Sorted2 = hv_T2.TupleSelect(hv_Indices2);
            //}
            //rows = hv_Sorted1.ToDArr().ToList();
            //cols = hv_Sorted2.ToDArr().ToList();
        }


        /// <summary>
        /// 最小二乘法圆拟合
        /// </summary>
        /// <param name="rows">点云 行坐标</param>
        /// <param name="cols">点云 列坐标</param>
        /// <param name="circle">返回圆</param>
        /// <returns>是否拟合成功</returns>
        public static bool fitCircle(List<Double> rows, List<Double> cols, out Circle_INFO circle)
        {
            circle = new Circle_INFO();
            if (cols.Count < 3)
            {
                return false;
            }
            //HTuple resultTuple;
            //if (Wrapper.Fun.fitCircle(new HTuple(rows.ToArray()), new HTuple(cols.ToArray()), out resultTuple))
            //{
            //    circle.CenterY = resultTuple[1];
            //    circle.CenterX = resultTuple[0];
            //    circle.Radius = resultTuple[2];
            //    return true;
            //}
            //return false;

            //本地代码验证通过------20180827 yoga
            ////原始托管代码
            double sum_x = 0.0f, sum_y = 0.0f;
            double sum_x2 = 0.0f, sum_y2 = 0.0f;
            double sum_x3 = 0.0f, sum_y3 = 0.0f;
            double sum_xy = 0.0f, sum_x1y2 = 0.0f, sum_x2y1 = 0.0f;

            int N = cols.Count;
            for (int i = 0; i < N; i++)
            {
                double x = rows[i];
                double y = cols[i];
                double x2 = x * x;
                double y2 = y * y;
                sum_x += x;
                sum_y += y;
                sum_x2 += x2;
                sum_y2 += y2;
                sum_x3 += x2 * x;
                sum_y3 += y2 * y;
                sum_xy += x * y;
                sum_x1y2 += x * y2;
                sum_x2y1 += x2 * y;
            }

            double C, D, E, G, H;
            double a, b, c;

            C = N * sum_x2 - sum_x * sum_x;
            D = N * sum_xy - sum_x * sum_y;
            E = N * sum_x3 + N * sum_x1y2 - (sum_x2 + sum_y2) * sum_x;
            G = N * sum_y2 - sum_y * sum_y;
            H = N * sum_x2y1 + N * sum_y3 - (sum_x2 + sum_y2) * sum_y;
            a = (H * D - E * G) / (C * G - D * D);
            b = (H * C - E * D) / (D * D - G * C);
            c = -(a * sum_x + b * sum_y + sum_x2 + sum_y2) / N;

            circle.CenterY = a / (-2);
            circle.CenterX = b / (-2);
            circle.Radius = Math.Sqrt(a * a + b * b - 4 * c) / 2;
            return true;
        }
        /// <summary>
        /// 求已知直线的垂线
        /// </summary>
        /// <param name="srcLine"></param>
        /// <returns>结果垂线</returns>
        public static Line_INFO CalVerticalLine(Line_INFO srcLine)
        {
            Line_INFO outLine = new Line_INFO();
            //HTuple outLineTmp;
            //Wrapper.Fun.CalVerticalLine(new HTuple(srcLine.StartX, srcLine.StartY, srcLine.EndX, srcLine.EndY), out outLineTmp);

            //outLine.StartY = outLineTmp[1];
            //outLine.StartX = outLineTmp[0];
            //outLine.EndY = outLineTmp[3];
            //outLine.EndX = outLineTmp[2];

            //本地代码验证通过------20180827 yoga
            //原始托管代码
            double rawx1 = srcLine.StartY;
            double rawy1 = srcLine.StartX;
            double rawx2 = srcLine.EndY;
            double rawy2 = srcLine.EndX;
            double k = 0;
            double minusy = rawy2 - rawy1;
            double minusx = rawx2 - rawx1;
            k = -1.0 / (minusy / minusx);
            double y1 = (rawy2 + rawy1) / 2.0;
            double x1 = (rawx2 + rawx1) / 2.0;
            double x2 = Math.Min(rawx1, rawx2) + Math.Abs(rawx1 - rawx2) / 4.0;
            double y2 = k * (x2 - x1) + y1;
            outLine.StartY = x1;
            outLine.StartX = y1;
            outLine.EndY = x2;
            outLine.EndX = y2;
            return outLine;
        }

        //public static PointF GetPedalByPointAndLine(PointF point,Line_INFO line)
        //{
        //    return new PointF();
        //}
        /// <summary>
        /// 计算两直线夹角
        /// </summary>
        /// <param name="Line1"></param>
        /// <param name="Line2"></param>
        /// <returns>返回弧度值</returns>
        public static double CalAngleL2L(Line_INFO Line1, Line_INFO Line2)
        {
            HTuple angle = new HTuple();
            HOperatorSet.AngleLl(new HTuple(Line1.StartY), new HTuple(Line1.StartX), new HTuple(Line1.EndY), new HTuple(Line1.EndX),
                new HTuple(Line2.StartY), new HTuple(Line2.StartX), new HTuple(Line2.EndY), new HTuple(Line2.EndX),
                out angle);
            return angle[0].D;
        }

        /// <summary>
        /// 根据位置变换直线坐标
        /// </summary>
        /// <param name="homMat">变换关系</param>
        /// <param name="line">直线</param>
        public static Line_INFO AffineLine(HHomMat2D homMat, Line_INFO line)
        {
            Line_INFO outLine = new Line_INFO();
            double row, col;
            row = homMat.AffineTransPoint2d(line.StartY, line.StartX, out col);
            outLine.StartY = row;
            outLine.StartX = col;
            row = homMat.AffineTransPoint2d(line.EndY, line.EndX, out col);
            outLine.EndY = row;
            outLine.EndX = col;
            return outLine;
        }

        /// <summary>
        /// 根据位置变换圆
        /// </summary>
        /// <param name="homMat">变换关系</param>
        /// <param name="circle">圆</param>
        /// <returns>结果圆</returns>
        public static Circle_INFO AffineCircle(HHomMat2D homMat, Circle_INFO circle)
        {
            Circle_INFO outCircle = new Circle_INFO();
            double row, col, Phi;
            row = homMat.AffineTransPoint2d(circle.CenterY, circle.CenterX, out col);
            Phi = ((HTuple)homMat[0]).TupleAcos().D;
            outCircle.Radius = circle.Radius;
            outCircle.CenterY = row;
            outCircle.CenterX = col;
            outCircle.StartPhi = circle.StartPhi + Phi;
            outCircle.EndPhi = circle.EndPhi + Phi;
            return outCircle;
        }


        /// <summary>
        /// 根据位置变换椭圆
        /// </summary>
        /// <param name="homMat">变换关系</param>
        /// <param name="ellipse">椭圆</param>
        /// <returns>结果椭圆</returns>
        public static Ellipse_INFO AffineEllipse(HHomMat2D homMat, Ellipse_INFO ellipse)
        {
            Ellipse_INFO outEllipse = new Ellipse_INFO();
            double row, col, Phi;
            row = homMat.AffineTransPoint2d(ellipse.CenterY, ellipse.CenterX, out col);
            Phi = ((HTuple)homMat[0]).TupleAcos().D;
            outEllipse.Radius1 = ellipse.Radius1;
            outEllipse.Radius2 = ellipse.Radius2;//修复bug magical20170821 原来都是Radius1
            outEllipse.CenterY = row;
            outEllipse.CenterX = col;
            outEllipse.Phi = ellipse.Phi + Phi;
            return outEllipse;
        }


        /// <summary>
        /// 转换直线，与图像边缘交点
        /// </summary>
        /// <param name="Width">图像宽度</param>
        /// <param name="Height">图像高度</param>
        /// <param name="inLine">输入直线</param>
        /// <param name="moveRow">平移行坐标</param>
        /// <param name="moveCol">平移列坐标</param>
        /// <param name="outLine">输出直线</param>
        public static void TransLine(int Width, int Height, Line_INFO inLine, double moveRow, double moveCol, out Line_INFO outLine)
        {
            outLine = inLine;
            try
            {
                double[] row = { 0, Height, Height, 0, 0 };
                double[] col = { 0, 0, Width, Width, 0 };
                HXLDCont xld = new HXLDCont();
                HTuple outY = new HTuple();
                HTuple outX = new HTuple();
                HTuple IsOverlapping = new HTuple();

                //平移
                inLine.StartY += moveRow;
                inLine.StartX += moveCol;
                inLine.EndY += moveRow;
                inLine.EndX += moveCol;

                xld.GenContourPolygonXld(new HTuple(row), new HTuple(col));
                HOperatorSet.IntersectionLineContourXld(xld, inLine.StartY, inLine.StartX, inLine.EndY, inLine.EndX, out outY, out outX, out IsOverlapping);
                if (outY.Length > 0)
                {
                    outLine = new Line_INFO(outY[0].D, outX[0].D, outY[1].D, outX[1].D);
                }
            }
            catch (System.Exception ex)
            {
            }
        }




        /// <summary>
        /// 求点到线的垂足
        /// </summary>
        /// <param name="inRow">点inRow，即y</param>
        /// <param name="inCol">点inCol，即x</param>
        /// <param name="srcLine">直线line</param>
        /// <param name="outY">垂足outY，即y</param>
        /// <param name="outX">垂足outX，即x</param>
        public static void CalPointLinePedal(Double inRow, Double inCol, Line_INFO srcLine, out Double outY, out Double outX)
        {
            HMisc.ProjectionPl(inRow, inCol, srcLine.StartY, srcLine.StartX, srcLine.EndY, srcLine.EndX, out outY, out outX);
        }

        /// <summary>
        /// 设置原点
        /// </summary>
        /// <param name="x">x坐标</param>
        /// <param name="y">y坐标</param>
        /// <param name="Phi">跟现有坐标弧度角</param>
        /// <returns></returns>
        public static HHomMat2D setOrig(double x, double y, double Phi)
        {


            HHomMat2D hom = new HHomMat2D();
            //本地代码验证通过------20180827 yoga
            try
            {
                hom = hom.HomMat2dRotateLocal(-Phi);
                hom = hom.HomMat2dTranslateLocal(-x, -y);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            //HTuple homTmp;
            //Wrapper.Fun.setOrig(x, y, Phi, out homTmp);
            //hom = new HHomMat2D(homTmp);
            return hom;
        }

        /// <summary>
        /// 计算弧度
        /// </summary>
        /// <returns>结果弧度制</returns>
        public static double CalAngle(double x1, double y1, double x2, double y2)
        {
            return HMisc.AngleLx(y1, x1, y2, x2);
            ////两点的x、y值
            //double x = x1 - x2;
            //double y = y1 - y2;

            ////斜边长度
            //double hypotenuse = Math.Sqrt(Math.Pow(x, 2f) + Math.Pow(y, 2f));

            ////求出弧度
            //double cos = x / hypotenuse;
            //double Phi = Math.Acos(cos);


            //if (y < 0)
            //{
            //    Phi = -Phi;
            //}
            //else if ((y == 0) && (x < 0))
            //{
            //    Phi = Math.PI;
            //}
            //return Phi;

        }

        /// <summary>
        /// 转换坐标点(世界坐标)
        /// </summary>
        /// <param name="hom">变换矩阵</param>
        /// <param name="lstX">输入Xlist</param>
        /// <param name="lstY">输入Ylist</param>
        /// <param name="outX">输出XList</param>
        /// <param name="outY">输出YList</param>
        public static void HomAffineTransPoints(HHomMat2D hom, List<double> lstX, List<double> lstY, out List<double> outX, out List<double> outY)
        {
            outX = new List<double>();
            outY = new List<double>();
            try
            {
                HTuple x = new HTuple();
                HTuple y = new HTuple();
                x = hom.AffineTransPoint2d(new HTuple(lstX.ToArray()), new HTuple(lstY.ToArray()), out y);
                outX = x.ToDArr().ToList();
                outY = y.ToDArr().ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 返回筛选后的数据列表，升序排列
        /// </summary>
        /// <param name="list">原始数据列表</param>
        /// <param name="type">筛选类型 max，mid，min</param>
        /// <param name="percent">百分比 0~1</param>
        /// <returns>返回筛选后的数据，升序排列 eg （list，“max”，0.8）排序后选出最大的80%数据</returns>
        public static List<double> QueryList(List<double> list, string type, double percent)
        {
            list.Sort();
            int per = (int)(list.Count * percent);
            per = per > 0 ? per : 1;
            if (type == "max")
                list = list.Skip((int)(list.Count * (1 - percent))).ToList();
            else if (type == "mid")
                //list = list.Skip((int)(list.Count * (1 - percent / 2))).Take((int)(list.Count * percent)).ToList();
                list = list.Skip((int)Math.Round(list.Count * ((1 - percent) / 2), MidpointRounding.ToEven)).Take(per).ToList();// magical 20171016原来的算法错误!,返回错误
            else if (type == "min")
                list = list.Take(per).ToList();
            return list;
        }

        /// <summary>
        /// 用最小二乘法拟合平面
        /// </summary>
        /// <param name="lstX">x坐标序列点</param>
        /// <param name="lstY">y坐标序列点</param>
        /// <param name="lstZ">z坐标序列点</param>
        /// <returns>结果平面</returns>
        public static Plane_INFO CalPlane(List<double> lstX, List<double> lstY, List<double> lstZ)
        {
            Plane_INFO Plane = new Plane_INFO();
            try
            {
                if (lstX.Count != lstY.Count && lstY.Count != lstZ.Count && lstZ.Count < 3)
                    return Plane;
                int n = lstZ.Count;
                double x, y, z, XY, XZ, YZ;
                double X2, Y2;
                double a, b, c, d;
                double a1, b1, z1;
                double a2, b2, z2;
                tagVector n1;     //{.ax,by,1}  s1
                tagVector n2;     //{0,0,N} XY plane  s2
                tagVector n3;     //line projected plane
                tagVector xLine, yLine, zLine, SLine;
                tagVector VectorPlane;
                xLine.a = 1;
                xLine.b = 0;
                xLine.c = 0;

                yLine.a = 0;
                yLine.b = 1;
                yLine.c = 0;

                zLine.a = 0;
                zLine.b = 0;
                zLine.c = 1;

                x = y = z = 0;
                XY = XZ = YZ = 0;
                X2 = Y2 = 0;

                for (int i = 0; i < n; i++)
                {
                    x += lstX[i];
                    y += lstY[i];
                    z += lstZ[i];

                    XY += lstX[i] * lstY[i];
                    XZ += lstX[i] * lstZ[i];
                    YZ += lstY[i] * lstZ[i];
                    X2 += lstX[i] * lstX[i];
                    Y2 += lstY[i] * lstY[i];
                }
                z1 = n * XZ - x * z;//              'e=z-Ax-By-C  z=Ax+By+D
                a1 = n * X2 - x * x;//
                b1 = n * XY - x * y;
                z2 = n * YZ - y * z;
                a2 = n * XY - x * y;
                b2 = n * Y2 - y * y;
                a = (z1 * b2 - z2 * b1) / (a1 * b2 - a2 * b1);
                b = (a1 * z2 - a2 * z1) / (a1 * b2 - a2 * b1);
                c = 1;
                d = (z - a * x - b * y) / n;


                Plane.x = x / n;
                Plane.y = y / n;
                Plane.z = z / n;
                //'sum(Mi *Ri)/sum(Mi) ,Mi is mass . here  Mi is seted to be 1 and .z is just the average of z
                Plane.ax = -a;
                Plane.by = -b;
                Plane.cz = 1;
                Plane.d = -d; //z=Ax+By+D-----Ax+By+Z+D=0

                VectorPlane.a = Plane.ax;
                VectorPlane.b = Plane.by;
                VectorPlane.c = 1;

                Plane.xAn = Intersect(VectorPlane, xLine);
                Plane.yAn = Intersect(VectorPlane, yLine);
                Plane.zAn = Intersect(VectorPlane, zLine);

                n1.a = Plane.ax;
                n1.b = Plane.by;
                n1.c = 1;

                SLine.a = Plane.ax;
                SLine.b = Plane.by;
                SLine.c = 0;

                Plane.Angle = Intersect(xLine, SLine);// (xLine.A * SLine.A + xLine.A * SLine.B + xLine.C * SLine.C)
                //if (SLine.b < 0)
                {
                    Plane.Angle = 360 - Plane.Angle;
                    double MaxF = 0d, MinF = 0d, rDist = 0d;
                    double MinZ = 0d, MaxZ = 0d;
                    for (int i = 0; i < n; i++)
                    {
                        rDist = PointToPlane(lstX[i], lstY[i], lstZ[i], Plane);
                        if (i == 0)
                        {
                            MaxF = MinF = rDist;
                            MaxZ = MinZ = lstZ[i];
                        }
                        else
                        {
                            if (MaxF < rDist)
                                MaxF = rDist;
                            if (MinF > rDist)
                                MinF = rDist;

                            if (MaxZ < lstZ[i])
                                MaxZ = lstZ[i];
                            if (MinZ > lstZ[i])
                                MinZ = lstZ[i];
                        }
                    }
                    Plane.MaxFlat = MaxF;
                    Plane.MinFlat = MinF;
                    Plane.Flat = MaxF - MinF;

                    Plane.MinZ = MinZ;
                    Plane.MaxZ = MaxZ;
                }
            }
            catch (Exception ex)
            {
                Helper.LogHandler.Instance.VTLogError(ex.ToString());
            }
            return Plane;
        }

        /// <summary>
        /// 通过RectList来计算平面度
        /// </summary>
        /// <param name="rectList">矩阵列表</param>
        /// <param name="type">计算方法 List-所有点参与计算 min-区域最小值参与计算 max-区域最大值参与计算 avg-区域平均值参与计算 med-区域中值参与计算 </param>
        /// <returns></returns>
        public static Plane_INFO CalPlaneByRectList(List<RectInfo> rectList, string type)
        {
            Plane_INFO Plane = new Plane_INFO();
            try
            {
                type = type.Trim().ToUpper();
                List<double> xList = new List<double>();
                List<double> yList = new List<double>();
                List<double> zList = new List<double>();
                if (type == "LIST")
                {
                    foreach (RectInfo rect in rectList)
                    {
                        xList = xList.Concat(rect.X_List).ToList();
                        yList = yList.Concat(rect.Y_List).ToList();
                        zList = zList.Concat(rect.Value_List).ToList();
                    }
                }
                else
                {
                    foreach (RectInfo rect in rectList)
                    {
                        xList.Add(rect.X);
                        yList.Add(rect.Y);
                        if (type == "MAX")
                            zList.Add(rect.Value_Max);
                        else if (type == "MIN")
                            zList.Add(rect.Value_Min);
                        else if (type == "AVG")
                            zList.Add(rect.Value_Avg);
                        else if (type == "MED")
                            zList.Add(rect.Value_Median);
                    }
                }

                Plane = CalPlane(xList, yList, zList);
            }
            catch (Exception ex)
            {
                Helper.LogHandler.Instance.VTLogError(ex.ToString());
            }
            return Plane;
        }

        /// <summary>
        ///  求两向量之间的夹角
        /// </summary>
        /// <param name="v1">  tagVector</param>
        /// <param name="v2">tagVector</param>
        /// <param name="LinePlane"></param>
        /// <returns> 0:表示两直线之间的夹角,其它值:表示如线与平面之间,平面与平面之间的夹角(0~90)</returns>
        static double Intersect(tagVector v1, tagVector v2, long LinePlane = 0)
        {
            //LinePlane 0 :line -line ,1:line --Plane
            double tmp, tmpSqr1, tmpSqr2;
            tmp = (v1.a * v2.a + v1.b * v2.b + v1.c * v2.c);
            //'MsgBox tm
            tmpSqr1 = Math.Sqrt(v1.a * v1.a + v1.b * v1.b + v1.c * v1.c);
            tmpSqr2 = Math.Sqrt(v2.a * v2.a + v2.b * v2.b + v2.c * v2.c);
            if (tmpSqr1 != 0)
            {
                if (tmpSqr2 != 0)
                {
                    tmp = tmp / tmpSqr1 / tmpSqr2;
                }
                else
                {
                    tmp = tmp / tmpSqr1;
                }
            }
            else
            {
                if (tmpSqr2 != 0)
                    tmp = tmp / tmpSqr2;
                else
                    tmp = 0;
            }
            if (LinePlane != 0)
            {
                tmp = Math.Abs(tmp);
            }
            if (-tmp * tmp + 1 != 0)
            {
                tmp = Math.Atan(-tmp / Math.Sqrt(-tmp * tmp + 1)) + 2 * Math.Atan(1.0);
                tmp = tmp / Math.PI * 180;
            }
            else
            {
                tmp = 90;
            }
            return tmp;
        }

        /// <summary>
        /// 求点到平面的距离
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="Plane"></param>
        /// <returns>距离值</returns>
        public static double PointToPlane(double x, double y, double z, Plane_INFO Plane)
        {
            double tmp = (Plane.ax * x + Plane.by * y + Plane.cz * z + Plane.d)
            / Math.Sqrt(Plane.ax * Plane.ax + Plane.by * Plane.by + Plane.cz * Plane.cz);
            return tmp;
        }
        /// <summary>
        /// 首次筛选异常点排除
        /// </summary>
        /// <param name="list">点集合</param>
        /// <returns>排除异常值-21474836的点</returns>
        public static List<double> DelList(List<double> list)
        {
            int i;
            List<double> templist = list.ToList();
            for (i = 0; i <= templist.Count - 1; i++)
            {
                if (templist[i] == -21474836)
                {
                    templist.RemoveAt(i);
                    i = i - 1;
                }
            }
            return templist;
        }

        /// <summary>
        /// 求两条边的中心基准线
        /// </summary>
        /// <param name="inLine1">输入直线1</param>
        /// <param name="inLine2">输入直线2</param>
        /// <returns>结果基准线</returns>
        public static Line_INFO middleLine(Line_INFO inLine1, Line_INFO inLine2)
        {
            try
            {
                double phi1 = HMisc.AngleLx(inLine1.StartY, inLine1.StartX, inLine1.EndY, inLine1.EndX);
                double phi2 = HMisc.AngleLx(inLine2.StartY, inLine2.StartX, inLine2.EndY, inLine2.EndX);
                double angle = Math.Abs(phi1 - phi1) * 180 / Math.PI;
                if (angle < 90 || angle > 270)
                {
                    double StartY = (inLine1.StartY + inLine2.StartY) / 2;
                    double StartX = (inLine1.StartX + inLine2.StartX) / 2;
                    double EndY = (inLine1.EndY + inLine2.EndY) / 2;
                    double EndX = (inLine1.EndX + inLine2.EndX) / 2;
                    Line_INFO outLine = new Line_INFO(StartY, StartX, EndY, EndX);
                    return outLine;
                }
                else
                {
                    double StartY = (inLine1.StartY + inLine2.EndY) / 2;
                    double StartX = (inLine1.StartX + inLine2.EndX) / 2;
                    double EndY = (inLine1.EndY + inLine2.StartY) / 2;
                    double EndX = (inLine1.EndX + inLine2.StartX) / 2;
                    Line_INFO outLine = new Line_INFO(StartY, StartX, EndY, EndX);
                    return outLine;
                }
            }
            catch (System.Exception ex)
            {
                return inLine1;
            }
        }


        /// <summary>
        /// 区分显示三西格玛 magical 20180405
        /// </summary>
        /// <param name="rowList">传入的点</param>
        /// <param name="colList">传入的点</param>
        /// <param name="line">传入的直线,用传入的点和直线做比较</param>
        /// <param name="rowIn3SigmaList">在三西格玛内的点</param>
        /// <param name="colIn3SigmaList">在三西格玛内的点</param>
        /// <param name="rowOut3SigmaList">在三西格玛外的点</param>
        /// <param name="colOut3SigmaList">在三西格玛外的点</param>
        public static void Cal3Sigma4Line(List<double> rowList, List<double> colList, Line_INFO line, out List<double> rowIn3SigmaList, out List<double> colIn3SigmaList, out List<double> rowOut3SigmaList, out List<double> colOut3SigmaList)
        {
            List<Double> dis = new List<Double>();
            VBA_Function.DistancePL(rowList, colList, line, out dis);

            double mean = dis.Average();//

            List<double> listDataV = new List<double>();
            foreach (double d in dis)
            {
                listDataV.Add((d - mean) * (d - mean));
            }
            double sumDataV = listDataV.Sum();
            double std = Math.Sqrt(sumDataV / (listDataV.Count - 1));//标准方差

            rowIn3SigmaList = new List<double>();
            colIn3SigmaList = new List<double>();
            rowOut3SigmaList = new List<double>();
            colOut3SigmaList = new List<double>();

            for (int i = 0; i < dis.Count; i++)
            {
                if (dis[i] >= std * 3)
                {
                    rowOut3SigmaList.Add(rowList[i]);
                    colOut3SigmaList.Add(colList[i]);
                }
                else
                {
                    rowIn3SigmaList.Add(rowList[i]);
                    colIn3SigmaList.Add(colList[i]);
                }
            }
        }

        /// <summary>
        /// 像素坐标转换为机械坐标和角度
        /// </summary>
        /// <param name="X">像素坐标x</param>
        /// <param name="Y">像素坐标y</param>
        /// <param name="Phi">像素坐标角度</param>
        /// <param name="hom9Calib">九点标定矩阵</param>
        /// <param name="homRoteCalib">选择中心标定矩阵</param>
        /// <param name="outX">输出机械坐标X</param>
        /// <param name="outY">输出机械坐标Y</param>
        /// <param name="outPhi">输出机械坐标角度</param>
        public static void Pixel2MachineCoord(double X, double Y, double Phi, HHomMat2D hom9Calib, HHomMat2D homRoteCalib, out double outX, out double outY, out double outPhi)
        {
            outX = 0f;
            outY = 0f;
            outPhi = 0f;
            try
            {
                HTuple pointAndPhi = new HTuple(X, Y, Phi);
                HTuple pointAndPhiResult;
                //Wrapper.Fun.Pixel2MachineCoord(pointAndPhi, hom9Calib, homRoteCalib, out pointAndPhiResult);
                //if (pointAndPhiResult.Length == 3)
                //{
                //    outX = pointAndPhiResult[0];
                //    outY = pointAndPhiResult[1];
                //    outPhi = pointAndPhiResult[2];
                //}
                //本地代码验证通过------20180827 yoga
                //原始托管代码
                double tmpX, tmpY, tmpPhi;
                tmpX = hom9Calib.AffineTransPoint2d(X, Y, out tmpY);//图像坐标转换为世界坐标
                HHomMat2D hom = homRoteCalib.HomMat2dInvert();//反转变成世界坐标到机械坐标的转换
                outX = hom.AffineTransPoint2d(tmpX, tmpY, out outY);//世界坐标系到机械坐标系转换
                double sx, sy, angle, theta, tx, ty;
                sx = hom9Calib.HomMat2dToAffinePar(out sy, out angle, out theta, out tx, out ty);
                outPhi = angle + Phi;
            }
            catch (Exception ex)
            { }

        }
        /// <summary>
        /// 像素坐标转换为世界坐标和角度
        /// </summary>
        /// <param name="X">像素坐标x</param>
        /// <param name="Y">像素坐标y</param>
        /// <param name="Phi">像素坐标角度</param>
        /// <param name="hom9Calib">九点标定矩阵</param>
        /// <param name="outX">输出机械坐标X</param>
        /// <param name="outY">输出机械坐标Y</param>
        /// <param name="outPhi">输出机械坐标角度</param>
        public static void Pixel2WorldCoord(double X, double Y, double Phi, HHomMat2D hom9Calib, out double outX, out double outY, out double outPhi)
        {
            outX = 0f;
            outY = 0f;
            outPhi = 0f;
            try
            {

                //HTuple pointAndPhi = new HTuple(X, Y, Phi);
                //HTuple pointAndPhiResult;
                //Wrapper.Fun.Pixel2WorldCoord(pointAndPhi, hom9Calib, out pointAndPhiResult);
                //if (pointAndPhiResult.Length == 3)
                //{
                //    outX = pointAndPhiResult[0];
                //    outY = pointAndPhiResult[1];
                //    outPhi = pointAndPhiResult[2];
                //}
                //本地代码验证通过------20180827 yoga
                //原始托管代码
                outX = hom9Calib.AffineTransPoint2d(X, Y, out outY);//图像坐标转换为世界坐标
                double sx, sy, angle, theta, tx, ty;
                sx = hom9Calib.HomMat2dToAffinePar(out sy, out angle, out theta, out tx, out ty);
                outPhi = angle + Phi;
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 从当前像素坐标到目标像素坐标需要的转换
        /// </summary>
        /// <param name="fromX">当前世界坐标x</param>
        /// <param name="fromY">当前世界坐标y</param>
        /// <param name="fromPhi">当前世界坐标Phi</param>
        /// <param name="RoteCenterX">世界坐标旋转中心X</param>
        /// <param name="RoteCenterY">世界坐标旋转中心Y</param>
        /// <param name="aimX">目标世界坐标x</param>
        /// <param name="aimY">目标世界坐标y</param>
        /// <param name="aimPhi">目标世界坐标phi</param>
        /// <param name="offsetX">纠偏机械坐标offsetX</param>
        /// <param name="offsetY">纠偏机械坐标offsetY</param>
        /// <param name="offsetPhi">纠偏机械坐标offsetPhi</param>
        public static void CalCorrectionOffset(double fromX, double fromY, double fromPhi, double RoteCenterX, double RoteCenterY, double aimX, double aimY, double aimPhi, out double offsetX, out double offsetY, out double offsetPhi)
        {
            offsetX = 0f;
            offsetY = 0f;
            offsetPhi = 0f;
            try
            {
                //角度差
                offsetPhi = aimPhi - fromPhi;//弧度
                //根据旋转中心 旋转
                HHomMat2D hom_旋转中心旋转 = new HHomMat2D();
                hom_旋转中心旋转 = hom_旋转中心旋转.HomMat2dRotate(offsetPhi, RoteCenterX, RoteCenterY);
                double new_x;
                double new_y;
                new_x = hom_旋转中心旋转.AffineTransPoint2d(fromX, fromY, out new_y);

                //计算xy最终偏移
                offsetX = aimX - new_x;
                offsetY = aimY - new_y;

            }
            catch (Exception ex)
            { }
        }

        /// <summary>
        /// 使用脚本显示点
        /// </summary>
        /// <param name="unitID">需要操作的点显示单元</param>
        /// <param name="rowList">点坐标行</param>
        /// <param name="colLis">点坐标列</param>
        public static void SetCrossShow(int unitID, List<double> rowList, List<double> colLis)
        {
            CMeasureCell cell = HMeasureSYS.g_ProjectList[m_ProIndex].m_CellList.First(c => c.m_CellID == unitID);

            ((CMeasure_Show)cell).genCrossShow(rowList, colLis);
        }


        /// <summary>
        /// 使用脚本显示 一条直线
        /// </summary>
        /// <param name="unitID">单元号</param>
        /// <param name="start_row">直线起点行</param>
        /// <param name="start_col">直线起点列</param>
        /// <param name="end_row">直线终点行</param>
        /// <param name="end_col">直线终点列</param>
        public static void SetLineShow(int unitID, double start_row, double start_col, double end_row, double end_col)
        {
            CMeasureCell cell = HMeasureSYS.g_ProjectList[m_ProIndex].m_CellList.First(c => c.m_CellID == unitID);

            ((CMeasure_Show)cell).genLineShow(start_row, start_col, end_row, end_col);
        }
        /// <summary>
        /// 使用脚本显示文本输出
        /// 脚本实例
        /// dim rowList, colList as new List(of double)
        /// rowList.add(100)
        /// colList.add(100)
        /// h.SetCrossShow(15,rowList,colList)
        /// h.SetLineShow(15,100,100,2000,2000)
        /// h.SetTextShow(15,"显示的内容",500,500,"mono",50,"red")
        /// </summary>
        /// <param name="unitID">要显示的工具单元</param>
        /// <param name="_text">文本信息</param>
        /// <param name="_row">行</param>
        /// <param name="_col">列</param>
        /// <param name="_font">字体</param>
        /// <param name="_size">文字大小</param>
        /// <param name="_color">文字颜色</param>
        public static void SetTextShow(int unitID, string _text, double _row, double _col, string _font, int _size, string _color)
        {
            CMeasureCell cell = HMeasureSYS.g_ProjectList[m_ProIndex].m_CellList.First(c => c.m_CellID == unitID);

            ROIText roiText = new ROIText(_text, _row, _col, _font, _size, _color);
            ((CMeasure_Show)cell).genTextShow(roiText);
        }
        /// <summary>
        /// 更新单元显示内容到图像中
        /// </summary>
        /// <param name="imgName">图像变量名称</param>
        /// <param name="CellID">计算单元</param>
        /// <param name="Descrip">描述</param>
        /// <param name="obj">要显示的内容</param>
        public static void UpdateROI(string imgName, int CellID, string Descrip, HObject obj)
        {
            CMeasureCell cell = HMeasureSYS.g_ProjectList[m_ProIndex].m_CellList.First(c => c.m_CellID == CellID);
            MeasureROI roi坐标系 = new MeasureROI(cell.m_CellID.ToString(), cell.m_CellCatagory.ToString(), cell.m_CellDesCribe, Descrip, "green", new HObject(obj));
            HImageExt img;
            HMeasureSet.QueryImage(HMeasureSYS.g_ProjectList[m_ProIndex].m_VariableList, null, ImageCatagory.当前图像, imgName, out img);
            img.UpdateRoiList(roi坐标系);
        }

        /// <summary>
        /// 根据镭射图像及矩形框将高度信息转化为c基准对应的ccd图像上的点
        /// </summary>
        /// <param name="inImage">输入图像  镭射图像</param>
        /// <param name="ROWPIX">ccd相机的列像素当量 作为镭射图像的行像素当量</param>
        /// <param name="colPix">镭射扫描像素当量 默认为0.2</param>
        /// <param name="DATUM_C_HIGH">镭射补偿量,用于调整C基准</param>
        /// <param name="LASER_FirstLserRow">镭射第一条线的行数</param>
        /// <param name="LASER_Column4FirstLserRow">第一条线在图像坐标系 对应的column</param>
        /// <param name="LASER_Z">镭射的高度 </param>
        /// <param name="LASER_Row4Z">镭射的高度对应的row</param>
        /// <param name="inRectInfo">镭射图像选点框输出的矩阵信息</param>
        /// <param name="outRectInfo">转换为ccd坐标后的矩阵信息</param>
        public static void GetDatunCPoint(HImageExt inImage, double ROWPIX, double colPix, double DATUM_C_HIGH, double LASER_FirstLserRow, double LASER_Column4FirstLserRow,
        double LASER_Z, double LASER_Row4Z, List<RectInfo> inRectInfo, out List<RectInfo> outRectInfo)
        {

            //double ROWPIX = double.Parse(CProductInfo.Config["ROWPIX"]);//相机的像素当量
            //double DATUM_C_HIGH = double.Parse(CProductInfo.Config["DATUM_C_HIGH"]);//镭射补偿量,用于调整C基准

            //double LASER_FirstLserRow = double.Parse(CProductInfo.Config["LASER_FirstLserRow"]);//镭射第一条线的行数
            //double LASER_Column4FirstLserRow = double.Parse(CProductInfo.Config["LASER_Column4FirstLserRow"]);//第一条线在图像坐标系 对应的column

            //double LASER_Z = double.Parse(CProductInfo.Config["LASER_Z"]);//镭射的高度 
            //double LASER_Row4Z = double.Parse(CProductInfo.Config["LASER_Row4Z"]);//镭射的高度对应的row

            outRectInfo = new List<RectInfo>();
            if (inRectInfo == null || inRectInfo.Count < 1)
            {
                return;
            }
            int count = inRectInfo.Count;

            HTuple rows, cols, temp_values;
            for (int i = 0; i < count; i++)
            {
                RectInfo _RectInfo = new RectInfo();
                temp_values = new HTuple(inRectInfo[i].Value_List.ToArray());
                rows = new HTuple(inRectInfo[i].Y_List.ToArray()).TupleDiv(inImage.ScaleY);
                cols = new HTuple(inRectInfo[i].X_List.ToArray()).TupleDiv(inImage.ScaleX);
                //获取z值的最大1%用于剔除异常点
                List<double> zList = temp_values.DArr.ToList<double>();
                zList.Sort();
                zList.Reverse();
                double zLimit = zList.Take((int)(zList.Count * 0.002)).ToList().Min();

                _RectInfo.Value_List = temp_values.ToDArr().ToList();

                List<double> rowCCDList = new List<double>();
                List<double> colCCDList = new List<double>();

                double rowCCDPix = ROWPIX;//CCD的像素当量
                //double colPix = 0.2;//间隔

                double rowCCDDif = LASER_Row4Z - LASER_Z / rowCCDPix + DATUM_C_HIGH / rowCCDPix;//镭射扫描出的row,在ccd的坐标的补偿值
                double colCCDDif = LASER_Column4FirstLserRow - LASER_FirstLserRow * colPix / rowCCDPix;//镭射扫描出的col,在ccd的坐标的补偿值

                #region 只提取每行z值最大的
                List<double> zTmpLis = new List<double>();
                int OldRow = rows[0];
                for (int m = 0; m < temp_values.Length; m++)
                {
                    int curRow = rows[m];
                    double z = temp_values.DArr[m];
                    if (curRow == OldRow)//一行一行提取
                    {
                        if (z > -99999 && z < zLimit)//剔除异常点i
                        {
                            zTmpLis.Add(z);
                        }
                    }
                    else //已经换行
                    {
                        double zWant = zTmpLis.Max();
                        double r = (zWant / 1000) / rowCCDPix + rowCCDDif;
                        double c = (OldRow * colPix / rowCCDPix) + colCCDDif;
                        rowCCDList.Add(r);
                        colCCDList.Add(c);
                        OldRow = curRow;
                        zTmpLis.Clear();
                    }

                } 
                #endregion
                //for (int m = 0; m < temp_values.Length; m++)
                //{

                //    double z = temp_values.DArr[m];
                //    //均为double型数组 林玉刚 2018-9-12 15:23:39
                //    double col = rows.DArr[m];
                //    if (z > -99999 && z < zLimit)//剔除异常点i
                //    {
                //        double r = (z / 1000) / rowCCDPix + rowCCDDif;
                //        double c = (col * colPix / rowCCDPix) + colCCDDif;
                //        rowCCDList.Add(r);
                //        colCCDList.Add(c);
                //        //  sw1.WriteLine(r+ "," + c);
                //    }
                //}
                _RectInfo.X_List = rowCCDList;
                _RectInfo.Y_List = colCCDList;
                outRectInfo.Add(_RectInfo);
            }

        }
    }
}
