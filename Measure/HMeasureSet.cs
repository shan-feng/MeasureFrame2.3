using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.Windows.Forms;
using System.Drawing;
using Measure.UserDefine;
using CPublicDefine;
using AcqDevice;
using System.Threading;

namespace Measure
{
    public class HMeasureSet
    {
        /// <summary>
        /// 查到数据列表中的图像
        /// </summary>
        /// <param name="inVariableList">输入变量列表</param>
        /// <param name="outVariableIMGlist">输出变量列表</param>
        public static void getVariableImageList(List<F_DATA_CELL> inVariableList, out List<F_DATA_CELL> outVariableIMGlist)
        {
            IEnumerable<F_DATA_CELL> resultList = from datacell in inVariableList
                                                  where datacell.m_Data_Type == DataType.图像
                                                  select datacell;
            outVariableIMGlist = resultList.ToList();

        }

        /// <summary>
        /// 通过单元ID和名称查找变量列表
        /// </summary>
        /// <param name="inVariableList">输入列表</param>
        /// <param name="inCellID">单元ID</param>
        /// <param name="inVariableName">变量名称</param>
        /// <param name="outList">输出变量列表</param>
        public static void getVariableList(List<F_DATA_CELL> inVariableList, int inCellID, string inVariableName, out List<F_DATA_CELL> outList)
        {
            try
            {
                outList = new List<F_DATA_CELL>();
                //查找对应的直线
                IEnumerable<F_DATA_CELL> resultList = from datacell in inVariableList
                                                      where datacell.m_Data_CellID == inCellID
                                                           && datacell.m_Data_Name == inVariableName
                                                      select datacell;
                outList = resultList.ToList();
            }
            catch (System.Exception ex)
            {
                outList = new List<F_DATA_CELL>();

            }
        }

        /// <summary>
        /// 更新全局变量列表中的值
        /// </summary>
        /// <param name="_CellID">单元ID</param>
        /// <param name="_DataName">变量名称</param>
        /// <param name="_ListValue">newValue</param>
        public static void UpdateVariableValue(ref List<F_DATA_CELL> VariableList, int _CellID, string _DataName, object _ListValue)
        {
            int index = VariableList.FindIndex(e => e.m_Data_CellID == _CellID && e.m_Data_Name.ToUpper() == _DataName.Trim().ToUpper());

            if (index > -1)
            {
                //F_DATA_CELL datacell = VariableList.FirstOrDefault(e => e.m_Data_CellID == _CellID && e.m_Data_Name == _DataName);
                F_DATA_CELL datacell = VariableList[index];
                datacell.m_Data_Value = _ListValue;
                VariableList[index] = datacell;
            }
            //else
            //{
            //    F_DATA_CELL datacell = new F_DATA_CELL();
            //    VariableList.Add(datacell);
            //}
        }

        /// <summary>
        /// 更新全局变量列表中的值
        /// </summary>
        /// <param name="VariableList">列表</param>
        /// <param name="data">值</param>
        public static void UpdateVariableValue(ref List<F_DATA_CELL> VariableList, F_DATA_CELL data)
        {
            int index = VariableList.FindIndex(e => e.m_Data_CellID == data.m_Data_CellID && e.m_Data_Name == data.m_Data_Name);
            if (index > -1)
                VariableList[index] = data;
            else
                VariableList.Add(data);
        }


        /// <summary>
        /// 检测直线 增加屏蔽区域 magical20171028
        /// </summary>
        /// <param name="inImage">检测图像</param>
        /// <param name="inLine">输入检测直线区域</param>
        /// <param name="inMetrology">形态参数</param>
        /// <param name="outLine">输出直线</param>
        /// <param name="outR">输出行点</param>
        /// <param name="outC">输出列点</param>
        /// <param name="outMeasureXLD">输出检测轮廓</param>
        /// <param name="disableRegion">屏蔽区域 可选</param>
        /// <param name="isPaint">对屏蔽区域进行喷绘 可选</param>
        public static void MeasureLine(HImage inImage, Line_INFO inLine, Metrology_INFO inMetrology, out Line_INFO outLine, out HTuple outR, out HTuple outC, out HXLDCont outMeasureXLD, HRegion disableRegion = null)
        {
            HMetrologyModel hMetrologyModel = new HMetrologyModel();
            try
            {
                outLine = new Line_INFO();
                HTuple lineResult = new HTuple();
                HTuple lineInfo = new HTuple();
                lineInfo.Append(new HTuple(new double[] { inLine.StartY, inLine.StartX, inLine.EndY, inLine.EndX }));

                //magical 20180405增加最强边的计算
                if (inMetrology.ParamValue[1] == "strongest")
                {
                    MeasureLine1D(inImage, inLine, inMetrology, out outLine, out outR, out outC, out outMeasureXLD, disableRegion);
                    return;
                }

                hMetrologyModel.AddMetrologyObjectGeneric(new HTuple("line"), lineInfo, new HTuple(inMetrology.Length1),
                    new HTuple(inMetrology.Length2), new HTuple(1), new HTuple(inMetrology.Threshold)
                    , inMetrology.ParamName, inMetrology.ParamValue);
                hMetrologyModel.SetMetrologyObjectParam(0, "min_score", 0.1);//降低直线拟合的最低得分,尽量使用halcon的拟合方法,因为VBA_Function.fitLine方法拟合的直线不准 magical 20171018


                if (disableRegion != null && disableRegion.IsInitialized())
                {
                    hMetrologyModel.ApplyMetrologyModel(inImage);

                    //单个测量区域 刚好 有一大半在屏蔽区域,一小部分在有效区域,这时候也会测出一个点,这个点在屏蔽区域内,导致精度损失约为1个像素左右.需要喷绘之后,再进行点是否在屏蔽区域判断
                    outMeasureXLD = hMetrologyModel.GetMetrologyObjectMeasures("all", "all", out outR, out outC);

                    List<double> tempOutR = new List<double>(), tempOutC = new List<double>();

                    for (int i = 0; i < outR.DArr.Length - 1; i++)
                    {
                        //0 表示没有包含
                        if (disableRegion.TestRegionPoint(outR[i].D, outC[i].D) == 0)
                        {
                            tempOutR.Add(outR[i].D);
                            tempOutC.Add(outC[i].D);
                        }
                    }
                    outR = new HTuple(tempOutR.ToArray());
                    outC = new HTuple(tempOutC.ToArray());
                }
                else
                {
                    hMetrologyModel.ApplyMetrologyModel(inImage);
                    outMeasureXLD = hMetrologyModel.GetMetrologyObjectMeasures("all", "all", out outR, out outC);
                }
                lineResult = hMetrologyModel.GetMetrologyObjectResult(new HTuple("all"), new HTuple("all"), new HTuple("result_type"), new HTuple("all_param"));
                if (lineResult.TupleLength() >= 4)
                {
                    outLine = new Line_INFO(lineResult[0].D, lineResult[1].D, lineResult[2].D, lineResult[3].D);
                }
                else
                {
                    if (VBA_Function.fitLineByH(outR.ToDArr().ToList(), outC.ToDArr().ToList(), out outLine))
                        outLine = inLine;
                }

                hMetrologyModel.Dispose();
            }
            catch (Exception ex)
            {
                outLine = inLine;
                outR = new HTuple();
                outC = new HTuple();
                outMeasureXLD = new HXLDCont();
                hMetrologyModel.Dispose();

                //异常写入日志文件
                // MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 利用一维测量算子,检测直线.再利用halcon的拟合直线算法拟合直线 主要用于最强边缘的测量 magical20180405
        /// </summary>
        /// <param name="inImage"></param>
        /// <param name="inLine"></param>
        /// <param name="inMetrology"></param>
        /// <param name="outLine"></param>
        /// <param name="outR"></param>
        /// <param name="outC"></param>
        /// <param name="outMeasureXLD"></param>
        /// <param name="disableRegion"></param>
        /// <param name="isPaint"></param>
        public static void MeasureLine1D(HImage inImage, Line_INFO inLine, Metrology_INFO inMetrology, out Line_INFO outLine, out HTuple outR, out HTuple outC, out HXLDCont outMeasureXLD, HRegion disableRegion = null, bool isPaint = true)
        {

            outLine = inLine;
            outR = new HTuple();
            outC = new HTuple();
            List<double> outRList = new List<double>();
            List<double> outCList = new List<double>();
            HImage tempImage;
            if (disableRegion != null && disableRegion.IsInitialized())
            {
                //将屏蔽区域喷绘为0,这样就无法测量到点 magical 20171028
                tempImage = disableRegion.PaintRegion(inImage, 0d, "fill");
            }
            else
            {
                tempImage = inImage;
            }

            //注意下这里的角度
            double angle = HMisc.AngleLx(inLine.StartY, inLine.StartX, inLine.EndY, inLine.EndX);
            int pointsNum = (int)((HMisc.DistancePp(inLine.StartY, inLine.StartX, inLine.EndY, inLine.EndX) - 2 * inMetrology.Length2) / inMetrology.MeasureDis) + 1;
            double newMeasureDis = (HMisc.DistancePp(inLine.StartY, inLine.StartX, inLine.EndY, inLine.EndX) - 2 * inMetrology.Length2) / pointsNum;
            double rectRowC, rectColC;

            outMeasureXLD = new HXLDCont();
            outMeasureXLD.GenEmptyObj();
            for (int i = 0; i <= pointsNum; i++)
            {
                //rectRowC = inLine.StartY + (((inLine.EndY - inLine.StartY) * (i + 1)) / (pointsNum)) + inMetrology.Length2*Math.Sin(angle);
                //rectColC = inLine.StartX + (((inLine.EndX - inLine.StartX) * (i )) / (pointsNum))+ inMetrology.Length2 * Math.Cos(angle);
                rectRowC = inLine.StartY + (inMetrology.Length2 - i * newMeasureDis) * Math.Sin(angle);
                rectColC = inLine.StartX + (inMetrology.Length2 + i * newMeasureDis) * Math.Cos(angle);



                HXLDCont tempRect = new HXLDCont();
                tempRect.GenRectangle2ContourXld(rectRowC, rectColC, angle - Math.PI / 2, inMetrology.Length1, inMetrology.Length2);
                outMeasureXLD = outMeasureXLD.ConcatObj(tempRect);


                HMeasure mea = new HMeasure();
                int width, height;
                inImage.GetImageSize(out width, out height);
                mea.GenMeasureRectangle2(rectRowC, rectColC, angle - Math.PI / 2, inMetrology.Length1, inMetrology.Length2, width, height, "nearest_neighbor");
                HTuple rowEdge, columnEdge, amplitude, distance;
                mea.MeasurePos(tempImage, 1, inMetrology.Threshold, inMetrology.ParamValue[0], "all", out rowEdge, out columnEdge, out amplitude, out distance);

                if (amplitude != null & amplitude.Length > 0)
                {
                    // amplitude.TupleSort();
                    HTuple HIndex = amplitude.TupleAbs().TupleSortIndex();
                    outRList.Add(rowEdge[HIndex[HIndex.Length - 1].I]);
                    outCList.Add(columnEdge[HIndex[HIndex.Length - 1].I]);
                }

                mea.Dispose();
            }
            outR = new HTuple(outRList.ToArray());
            outC = new HTuple(outCList.ToArray());

            if (disableRegion != null && disableRegion.IsInitialized())
            {
                List<double> tempOutR = new List<double>(), tempOutC = new List<double>();
                for (int i = 0; i < outR.DArr.Length - 1; i++)
                {
                    //0 表示没有包含
                    if (disableRegion.TestRegionPoint(outR[i].D, outC[i].D) == 0)
                    {
                        tempOutR.Add(outR[i].D);
                        tempOutC.Add(outC[i].D);
                    }
                }
                outR = new HTuple(tempOutR.ToArray());
                outC = new HTuple(tempOutC.ToArray());
            }

            if (outR.Length > 0)
            {
                VBA_Function.fitLineByH(outRList, outCList, out outLine);
            }
            else
            {
                outLine = inLine;
            }

        }

        /// <summary>
        /// 检测圆
        /// </summary>
        /// <param name="inImage">输入图像</param>
        /// <param name="inCircle">输入圆</param>
        /// <param name="inMetrology">输入形态学</param>
        /// <param name="outCircle">输出圆</param>
        /// <param name="outR">输出行坐标</param>
        /// <param name="outC">输出列坐标</param>
        /// <param name="outMeasureXLD">输出检测轮廓</param>
        public static void MeasureCircle(HImage inImage, Circle_INFO inCircle, Metrology_INFO inMetrology, HRegion disableRegion, out Circle_INFO outCircle, out HTuple outR, out HTuple outC, out HXLDCont outMeasureXLD)
        {
            HMetrologyModel hMetrologyModel = new HMetrologyModel();

            try
            {
                outCircle = new Circle_INFO();
                HTuple CircleResult = new HTuple();
                HTuple CircleInfo = new HTuple();
                CircleInfo.Append(new HTuple(new double[] { inCircle.CenterY, inCircle.CenterX, inCircle.Radius }));
                hMetrologyModel.AddMetrologyObjectGeneric(new HTuple("circle"), CircleInfo, new HTuple(inMetrology.Length1),
                    new HTuple(inMetrology.Length2), new HTuple(1), new HTuple(inMetrology.Threshold)
                    , inMetrology.ParamName, inMetrology.ParamValue);

                hMetrologyModel.ApplyMetrologyModel(inImage);
                outMeasureXLD = hMetrologyModel.GetMetrologyObjectMeasures("all", "all", out outR, out outC);

                if (disableRegion != null && disableRegion.IsInitialized() && disableRegion.Area > 0 && outR.Length > 0)
                {
                    List<double> tempOutR = new List<double>(), tempOutC = new List<double>();
                    for (int i = 0; i < outR.DArr.Length - 1; i++)
                    {
                        //0 表示没有包含
                        if (disableRegion.TestRegionPoint(outR[i].D, outC[i].D) == 0)
                        {
                            tempOutR.Add(outR[i].D);
                            tempOutC.Add(outC[i].D);
                        }
                    }
                    outR = new HTuple(tempOutR.ToArray());
                    outC = new HTuple(tempOutC.ToArray());
                    VBA_Function.fitCircle(outR.ToDArr().ToList(), outC.ToDArr().ToList(), out outCircle);
                    //outMeasureXLD = outCircle.genXLD();
                }
                else
                {
                    CircleResult = hMetrologyModel.GetMetrologyObjectResult(new HTuple("all"), new HTuple("all"), new HTuple("result_type"), new HTuple("all_param"));
                    if (CircleResult.TupleLength() >= 3)
                    {
                        outCircle.CenterY = CircleResult[0].D;
                        outCircle.CenterX = CircleResult[1].D;
                        outCircle.Radius = CircleResult[2].D;
                    }
                    else
                    {
                        VBA_Function.fitCircle(outR.ToDArr().ToList(), outC.ToDArr().ToList(), out outCircle);
                    }
                }



                hMetrologyModel.Dispose();
            }
            catch (Exception ex)
            {
                outCircle = inCircle;
                outR = new HTuple();
                outC = new HTuple();
                outMeasureXLD = new HXLDCont();
                hMetrologyModel.Dispose();

                //异常写入日志文件
                // MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 检测椭圆
        /// </summary>
        /// <param name="inImage">输入图像</param>
        /// <param name="inEllipse">输入椭圆</param>
        /// <param name="inMetrology">输入形态学</param>
        /// <param name="outEllipse">输出椭圆</param>
        /// <param name="outR">输出行坐标</param>
        /// <param name="outC">输出列坐标</param>
        /// <param name="outMeasureXLD">输出检测轮廓</param>
        public static void MeasureEllipse(HImage inImage, Ellipse_INFO inEllipse, Metrology_INFO inMetrology, out Ellipse_INFO outEllipse, out HTuple outR, out HTuple outC, out HXLDCont outMeasureXLD)
        {
            HMetrologyModel hMetrologyModel = new HMetrologyModel();

            try
            {
                outEllipse = new Ellipse_INFO();
                HTuple EllipseResult = new HTuple();
                HTuple EllipseInfo = new HTuple();
                EllipseInfo.Append(new HTuple(new double[] { inEllipse.CenterY, inEllipse.CenterX, inEllipse.Phi, inEllipse.Radius1, inEllipse.Radius2 }));
                //hMetrologyModel.AddMetrologyObjectGeneric(new HTuple("ellipse"), EllipseInfo, new HTuple(inMetrology.Length1),
                //    new HTuple(inMetrology.Length2), new HTuple(1), new HTuple(inMetrology.Threshold)
                //    , inMetrology.ParamName, inMetrology.ParamValue);
                hMetrologyModel.AddMetrologyObjectEllipseMeasure(new HTuple(inEllipse.CenterY), new HTuple(inEllipse.CenterX), new HTuple(inEllipse.Phi),
                    new HTuple(inEllipse.Radius1), new HTuple(inEllipse.Radius2), new HTuple(inMetrology.Length1),
                    new HTuple(inMetrology.Length2), new HTuple(1), new HTuple(inMetrology.Threshold), inMetrology.ParamName, inMetrology.ParamValue);
                hMetrologyModel.SetMetrologyObjectParam("all", "max_num_iterations", 70);
                hMetrologyModel.ApplyMetrologyModel(inImage);
                outMeasureXLD = hMetrologyModel.GetMetrologyObjectMeasures("all", "all", out outR, out outC);

                EllipseResult = hMetrologyModel.GetMetrologyObjectResult(new HTuple("all"), new HTuple("all"), new HTuple("result_type"), new HTuple("all_param"));
                if (EllipseResult.TupleLength() >= 4)
                {
                    outEllipse.CenterY = EllipseResult[0].D;
                    outEllipse.CenterX = EllipseResult[1].D;
                    outEllipse.Phi = EllipseResult[2].D;
                    outEllipse.Radius1 = EllipseResult[3].D;
                    outEllipse.Radius2 = EllipseResult[4].D;
                }

                hMetrologyModel.Dispose();
            }
            catch (Exception ex)
            {
                outEllipse = inEllipse;
                outR = new HTuple();
                outC = new HTuple();
                outMeasureXLD = new HXLDCont();
                hMetrologyModel.Dispose();

                //异常写入日志文件
                // MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// 边缘对检测
        /// </summary>
        /// <param name="inImage">输入图像</param>
        /// <param name="inCross">输入矩形框中心</param>
        /// <param name="inMetrology">形态学参数</param>
        /// <param name="lstLine">返回直线列表</param>
        /// <param name="lstWidth">直线长度</param>
        /// <param name="lstDistance">直线间隔</param>
        /// <param name="outMeasureXLD">直线轮廓</param>
        public static void MeasurePairs(HImage inImage, Coordinate_INFO inCross, Metrology_INFO inMetrology, out List<Line_INFO> lstLine, out List<double> lstWidth, out List<double> lstDistance, out HXLDCont outMeasureXLD)
        {
            HMeasure hMeasure = new HMeasure();
            lstLine = new List<Line_INFO>();
            lstWidth = new List<double>();
            lstDistance = new List<double>();
            outMeasureXLD = new HXLDCont();
            outMeasureXLD.GenEmptyObj();
            try
            {
                HTuple rowEdgeFirst = new HTuple();
                HTuple columnEdgeFirst = new HTuple();
                HTuple amplitudeFirst = new HTuple();
                HTuple rowEdgeSecond = new HTuple();
                HTuple columnEdgeSecond = new HTuple();
                HTuple amplitudeSecond = new HTuple();
                HTuple intraDistance = new HTuple();
                HTuple interDistance = new HTuple();
                string tempStr = "all_strongest";
                if (inMetrology.ParamValue[0].S == "negative")
                {
                    tempStr = "negative_strongest";
                }
                else if (inMetrology.ParamValue[0].S == "positive")
                {
                    tempStr = "positive_strongest";
                }
                else if (inMetrology.ParamValue[0].S == "uniform")
                {
                    tempStr = "all_strongest";
                }
                int width, height;
                inImage.GetImageSize(out width, out height);
                hMeasure.GenMeasureRectangle2(inCross.Y, inCross.X, inCross.Phi, inMetrology.Length1, inMetrology.Length2, width, height, "nearest_neighbor");
                hMeasure.MeasurePairs(inImage, 1.5, inMetrology.Threshold, tempStr, inMetrology.ParamValue[1].S,
                    out rowEdgeFirst, out columnEdgeFirst, out amplitudeFirst, out rowEdgeSecond, out columnEdgeSecond, out amplitudeSecond, out intraDistance, out interDistance);

                if (rowEdgeFirst.Length > 0)
                {
                    for (int i = 0; i < rowEdgeFirst.Length; i++)
                    {
                        Line_INFO temp = new Line_INFO(rowEdgeFirst[i].D, columnEdgeFirst[i].D, rowEdgeSecond[i].D, columnEdgeSecond[i].D);
                        lstLine.Add(temp);
                        HXLDCont xld = new HXLDCont();
                        HTuple row = (new HTuple(rowEdgeFirst[i].D)).TupleConcat(rowEdgeSecond[i].D);
                        HTuple col = (new HTuple(columnEdgeFirst[i].D)).TupleConcat(columnEdgeSecond[i].D);
                        xld.GenContourPolygonXld(row, col);
                        outMeasureXLD = outMeasureXLD.ConcatObj(xld);
                    }
                    lstWidth = intraDistance.ToDArr().ToList();
                    lstDistance = interDistance.ToDArr().ToList();
                }
            }
            catch (Exception ex)
            {
                //异常写入日志文件
                // MessageBox.Show(ex.Message);
            }
            finally
            {
                hMeasure.Dispose();
            }
        }


        /// <summary>
        /// 根据坐标重定位矩阵的位置
        /// </summary>
        /// <param name="inRectangleList">输入原始矩阵</param>
        /// <param name="inCoordInfo">坐标系</param>
        /// <param name="outRectangleList">输出像素矩阵</param>
        public static void RectPosition(HImageExt img, List<Rectangle2_INFO> inRectangleList, Coordinate_INFO inCoordInfo, out List<Rectangle2_INFO> outRectangleList)
        {
            try
            {
                outRectangleList = new List<Rectangle2_INFO>();
                HHomMat2D homMat2D = new HHomMat2D();
                homMat2D = homMat2D.HomMat2dRotateLocal(inCoordInfo.Phi);
                homMat2D = homMat2D.HomMat2dTranslate(inCoordInfo.X, inCoordInfo.Y);
                foreach (Rectangle2_INFO r in inRectangleList)
                {
                    double x, y, row, col;
                    x = homMat2D.AffineTransPoint2d(r.CenterX, r.CenterY, out y);
                    HMeasureSet.WorldPlane2Point(img, x, y, out row, out col);
                    Rectangle2_INFO temp_R = new Rectangle2_INFO();
                    temp_R.CenterY = row;
                    temp_R.CenterX = col;
                    temp_R.Phi = r.Phi + inCoordInfo.Phi;
                    //temp_R.Length1 = r.Length1 / (img.ScaleX + img.ScaleY) / 2;
                    //temp_R.Length2 = r.Length2 / (img.ScaleX + img.ScaleY) / 2;
                    //此处错误  应该是行列的比例整体除以2  yoga 20180827
                    temp_R.Length1 = r.Length1 / ((img.ScaleX + img.ScaleY) / 2);
                    temp_R.Length2 = r.Length2 / ((img.ScaleX + img.ScaleY) / 2);

                    outRectangleList.Add(temp_R);
                }
            }
            catch (System.Exception ex)
            {
                outRectangleList = new List<Rectangle2_INFO>();
                //异常写入日志文件
                // MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// 获取矩形框的值
        /// </summary>
        /// <param name="inImage">输入图像</param>
        /// <param name="inRectangleList">矩形阵列</param>
        /// <param name="inPreTreatMent">预处理</param>
        /// <param name="outRectInfo">返回RectInfo列表</param>
        public static void QueryRectInfo(HImageExt inImage, List<Rectangle2_INFO> inRectangleList, PreTreatMent inPreTreatMent, out List<RectInfo> outRectInfo)
        {
            try
            {
                outRectInfo = new List<RectInfo>();
                HRegion m_Region = new HRegion();
                var rowList = from datacell in inRectangleList select datacell.CenterY;
                var colList = from datacell in inRectangleList select datacell.CenterX;
                var phiList = from datacell in inRectangleList select datacell.Phi;
                var length1List = from datacell in inRectangleList select datacell.Length1;
                var length2List = from datacell in inRectangleList select datacell.Length2;

                m_Region.GenRectangle2(new HTuple(rowList.ToArray()), new HTuple(colList.ToArray()), new HTuple(phiList.ToArray()),
                    new HTuple(length1List.ToArray()), new HTuple(length2List.ToArray()));

                HTuple rows, cols, temp_values;
                int count = m_Region.CountObj();
                if (inPreTreatMent == PreTreatMent.无)
                {

                }
                else if (inPreTreatMent == PreTreatMent.均值滤波)
                {
                    inImage = HImageExt.Instance(inImage.MeanImage(3, 3));
                }
                else if (inPreTreatMent == PreTreatMent.中值滤波)
                {
                    inImage = HImageExt.Instance(inImage.MedianImage("circle", 1, "mirrored"));
                }
                else if (inPreTreatMent == PreTreatMent.高斯滤波)
                {
                    inImage = HImageExt.Instance(inImage.GaussFilter(3));
                }
                else if (inPreTreatMent == PreTreatMent.平滑滤波)
                {
                    inImage = HImageExt.Instance(inImage.SmoothImage("deriche2", 0.5));
                }
                for (int i = 0; i < count; i++)
                {
                    RectInfo _RectInfo = new RectInfo();
                    m_Region[i + 1].GetRegionPoints(out rows, out cols);
                    temp_values = inImage.GetGrayval(rows, cols);
                    _RectInfo.X = inRectangleList[i].CenterX * inImage.ScaleX;
                    _RectInfo.Y = inRectangleList[i].CenterY * inImage.ScaleY;
                    _RectInfo.Value_Avg = temp_values.TupleMean().D;
                    _RectInfo.Value_Median = temp_values.TupleMedian().D;
                    _RectInfo.Value_Max = temp_values.TupleMax().D;
                    _RectInfo.Value_Min = temp_values.TupleMin().D;
                    _RectInfo.X_List = cols.TupleMult(inImage.ScaleX).ToDArr().ToList();
                    _RectInfo.Y_List = rows.TupleMult(inImage.ScaleY).ToDArr().ToList();
                    _RectInfo.Value_List = temp_values.ToDArr().ToList();

                    outRectInfo.Add(_RectInfo);
                }
                m_Region.Dispose();

            }
            catch (System.Exception ex)
            {
                outRectInfo = new List<RectInfo>();
                //异常写入日志文件
                // MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 查询图片
        /// </summary>
        /// <param name="m_ImageCatagory">图片类型</param>
        /// <param name="m_CurrentImgName">当前图片名称</param>
        /// <param name="m_RegisterImgName">注册图名称</param>
        /// <param name="m_Image">返回图像</param>
        public static void QueryImage(List<F_DATA_CELL> VariableList, List<RegisterIMG_Info> m_RegisterImg, ImageCatagory m_ImageCatagory, string ImgName, out HImageExt m_Image)
        {
            try
            {
                m_Image = new HImageExt();
                if (m_ImageCatagory == ImageCatagory.当前图像)
                {
                    F_DATA_CELL datacell = VariableList.FirstOrDefault(c => c.m_Data_Name == ImgName);
                    if (datacell.m_Data_Value != null)
                    {
                        m_Image = ((List<HImageExt>)datacell.m_Data_Value)[0];
                    }
                }
                else if (m_ImageCatagory == ImageCatagory.注册图像)
                {
                    RegisterIMG_Info datacell = m_RegisterImg.FirstOrDefault(c => c.m_ImageID == ImgName);
                    if (datacell.m_Image.IsInitialized())
                    {
                        m_Image = datacell.m_Image;
                    }
                }
            }
            catch (System.Exception ex)
            {
                m_Image = new HImageExt();
            }

        }

        /// <summary>
        /// 创建模板
        /// </summary>
        /// <param name="_Type">模板类型</param>
        /// <param name="_Model">模板</param>
        /// <param name="_image">图像</param>
        /// <param name="_region">模板区域</param>
        public static void CreateModel(ModelType _Type, ref HHandle _Model, double _StartPhi, double _EndPhi, HImage _image, ROI _roi)
        {
            try
            {
                if (_image.IsInitialized())
                {
                    HRegion _region = _roi.genRegion();
                    if (_region.IsInitialized())
                    {
                        _image = _image.ReduceDomain(_region);
                        //_image = _image.MeanImage(5, 5);
                    }
                    if (_Type == ModelType.形状模板)
                    {
                        HXLDCont xld = _image.EdgesSubPix("canny", 1, 20, 40);
                        //                     HTuple tLength = xld.LengthXld();
                        //                     double _max = tLength.TupleMax();
                        //                     xld = xld.SelectContoursXld("contour_length", _max, _max + 1, -0.5, 0.5);
                        //((HShapeModel)_Model).CreateShapeModelXld(xld, "auto", -0.39, 0.78, "auto", "auto", "ignore_local_polarity", 5);
                        ((HShapeModel)_Model).CreateScaledShapeModelXld(xld, "auto", Math.Round(_StartPhi * Math.PI / 180, 3), Math.Round((_EndPhi - _StartPhi) * Math.PI / 180, 3), "auto", 0.9, 1.1, "auto", "auto", "use_polarity", 5);
                        xld.Dispose();
                    }
                    else if (_Type == ModelType.灰度模板)
                    {
                        ((HNCCModel)_Model).CreateNccModel(_image, "auto", Math.Round(_StartPhi * Math.PI / 180, 3), Math.Round((_EndPhi - _StartPhi) * Math.PI / 180, 3), "auto", "use_polarity");
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        /// <summary>
        /// 查找模板
        /// </summary>
        /// <param name="_Type">模板类型</param>
        /// <param name="_Model">模式</param>
        /// <param name="_image">图片</param>
        /// <param name="_region">寻找区域</param>
        /// <param name="outCoord">输出坐标</param>
        public static void FindModel(ModelType _Type, HHandle _Model, double _StartPhi, double _EndPhi, HImage _image, ROI _roi, out Coordinate_INFO outCoord)
        {
            outCoord = new Coordinate_INFO();
            try
            {
                HTuple row, col, Phi, scale, score;
                if (_image.IsInitialized())
                {
                    HRegion _region = _roi.genRegion();
                    if (_region.IsInitialized())
                    {
                        _image = _image.ReduceDomain(_region);
                    }
                    if (_Type == ModelType.形状模板)
                    {
                        ((HShapeModel)_Model).FindScaledShapeModel(_image, Math.Round(_StartPhi * Math.PI / 180, 3), Math.Round((_EndPhi - _StartPhi) * Math.PI / 180, 3), 0.9, 1.1, 0.5, 1, 0.5, "least_squares", 0, 0.9, out row, out col, out Phi, out scale, out score);
                        if (score.Length > 0)
                        {
                            outCoord.Y = row[0].D;
                            outCoord.X = col[0].D;
                            outCoord.Phi = Phi[0].D;
                        }
                    }
                    else if (_Type == ModelType.灰度模板)
                    {
                        ((HNCCModel)_Model).FindNccModel(_image, Math.Round(_StartPhi * Math.PI / 180, 3), Math.Round((_EndPhi - _StartPhi) * Math.PI / 180, 3), 0.8, 1, 0.5, "true", 0, out row, out col, out Phi, out score);
                        if (score.Length > 0)
                        {
                            outCoord.Y = row[0].D;
                            outCoord.X = col[0].D;
                            outCoord.Phi = Phi[0].D;
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }


        /// <summary>
        /// 根据位置变换矩形
        /// </summary>
        /// <param name="homMat">变换关系</param>
        /// <param name="rect">矩阵</param>
        public static Rectangle2_INFO AffineRectangle2(HHomMat2D homMat, Rectangle2_INFO rect)
        {
            Rectangle2_INFO outRect = new Rectangle2_INFO();
            double row, col, Phi;
            row = homMat.AffineTransPoint2d(rect.CenterY, rect.CenterX, out col);
            Phi = ((HTuple)homMat[0]).TupleAcos().D;
            outRect.Length1 = rect.Length1;
            outRect.Length2 = rect.Length2;
            outRect.CenterY = row;
            outRect.CenterX = col;
            outRect.Phi = rect.Phi + Phi;
            return outRect;
        }


        /// <summary>
        /// 创建箭头xld
        /// </summary>
        /// <param name="ho_Arrow">返回箭头轮廓</param>
        /// <param name="hv_Row1">起始点row</param>
        /// <param name="hv_Column1">起始点col</param>
        /// <param name="hv_Row2">终点row</param>
        /// <param name="hv_Column2">终点col</param>
        /// <param name="hv_HeadLength">箭头长度</param>
        /// <param name="hv_HeadWidth">箭头宽度</param>
        public static void GenArrowContourXld(out HXLDCont ho_Arrow, HTuple hv_Row1, HTuple hv_Column1,
            HTuple hv_Row2, HTuple hv_Column2, HTuple hv_HeadLength, HTuple hv_HeadWidth)
        {

            HTuple hv_Length = null, hv_ZeroLengthIndices = null;
            HTuple hv_DR = null, hv_DC = null, hv_HalfHeadWidth = null;
            HTuple hv_RowP1 = null, hv_ColP1 = null, hv_RowP2 = null;
            HTuple hv_ColP2 = null, hv_Index = null;
            // Initialize local and output iconic variables 
            ho_Arrow = new HXLDCont();
            HXLDCont ho_TempArrow = new HXLDCont();

            HOperatorSet.DistancePp(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_Length);
            //
            //Mark arrows with identical start and end point
            //(set Length to -1 to avoid division-by-zero exception)
            hv_ZeroLengthIndices = hv_Length.TupleFind(0);
            if ((int)(new HTuple(hv_ZeroLengthIndices.TupleNotEqual(-1))) != 0)
            {
                if (hv_Length == null)
                    hv_Length = new HTuple();
                hv_Length[hv_ZeroLengthIndices] = -1;
            }
            //
            //Calculate auxiliary variables.
            hv_DR = (1.0 * (hv_Row2 - hv_Row1)) / hv_Length;
            hv_DC = (1.0 * (hv_Column2 - hv_Column1)) / hv_Length;
            hv_HalfHeadWidth = hv_HeadWidth / 2.0;
            //
            //Calculate end points of the arrow head.
            hv_RowP1 = (hv_Row1 + ((hv_Length - hv_HeadLength) * hv_DR)) + (hv_HalfHeadWidth * hv_DC);
            hv_ColP1 = (hv_Column1 + ((hv_Length - hv_HeadLength) * hv_DC)) - (hv_HalfHeadWidth * hv_DR);
            hv_RowP2 = (hv_Row1 + ((hv_Length - hv_HeadLength) * hv_DR)) - (hv_HalfHeadWidth * hv_DC);
            hv_ColP2 = (hv_Column1 + ((hv_Length - hv_HeadLength) * hv_DC)) + (hv_HalfHeadWidth * hv_DR);
            //
            //Finally create output XLD contour for each input point pair
            for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_Length.TupleLength())) - 1); hv_Index = (int)hv_Index + 1)
            {
                if ((int)(new HTuple(((hv_Length.TupleSelect(hv_Index))).TupleEqual(-1))) != 0)
                {
                    //Create_ single points for arrows with identical start and end point
                    ho_TempArrow.Dispose();
                    ho_TempArrow.GenContourPolygonXld(hv_Row1.TupleSelect(hv_Index),
                        hv_Column1.TupleSelect(hv_Index));
                }
                else
                {
                    //Create arrow contour
                    ho_TempArrow.Dispose();
                    ho_TempArrow.GenContourPolygonXld(((((((((((hv_Row1.TupleSelect(
                        hv_Index))).TupleConcat(hv_Row2.TupleSelect(hv_Index)))).TupleConcat(
                        hv_RowP1.TupleSelect(hv_Index)))).TupleConcat(hv_Row2.TupleSelect(hv_Index)))).TupleConcat(
                        hv_RowP2.TupleSelect(hv_Index)))).TupleConcat(hv_Row2.TupleSelect(hv_Index)),
                        ((((((((((hv_Column1.TupleSelect(hv_Index))).TupleConcat(hv_Column2.TupleSelect(
                        hv_Index)))).TupleConcat(hv_ColP1.TupleSelect(hv_Index)))).TupleConcat(
                        hv_Column2.TupleSelect(hv_Index)))).TupleConcat(hv_ColP2.TupleSelect(
                        hv_Index)))).TupleConcat(hv_Column2.TupleSelect(hv_Index)));
                }
                if (!ho_Arrow.IsInitialized())
                {
                    ho_Arrow = ho_TempArrow;
                }
                ho_Arrow = ho_Arrow.ConcatObj(ho_TempArrow);
            }
            ho_TempArrow.Dispose();

            return;
        }

        /// <summary>
        /// 图像坐标点转换为世界坐标点
        /// </summary>
        /// <param name="img">坐标信息图像</param>
        /// <param name="rows">输入坐标行</param>
        /// <param name="cols">输入坐标列</param>
        /// <param name="wX">输出世界坐标行</param>
        /// <param name="wY">输出世界坐标列</param>
        public static void Points2WorldPlane(HImageExt img, List<double> rows, List<double> cols, out List<double> wX, out List<double> wY)
        {
            wX = new List<double>();
            wY = new List<double>();
            try
            {
                HTuple xImg, yImg;
                double xAxis, yAxis;
                //相机缩放比率校正
                //xImg = img.getHomImg().AffineTransPoint2d(new HTuple(cols.ToArray()), new HTuple(rows.ToArray()), out yImg);
                Pixel2WorldPlane(img, rows, cols, out xImg, out yImg);
                xAxis = img.getHomAxis().AffineTransPoint2d(img.X, img.Y, out yAxis);

                wX = xImg.TupleAdd(xAxis).ToDArr().ToList();
                wY = yImg.TupleAdd(yAxis).ToDArr().ToList();
            }
            catch (System.Exception ex)
            {
            }
        }

        /// <summary>
        /// 图像坐标点转换为世界坐标点
        /// </summary>
        /// <param name="img">坐标信息图像</param>
        /// <param name="row">输入坐标行</param>
        /// <param name="col">输入坐标列</param>
        /// <param name="wX">输出世界坐标行</param>
        /// <param name="wY">输出世界坐标列</param>
        public static void Points2WorldPlane(HImageExt img, double row, double col, out double wX, out double wY)
        {
            wX = 0f;
            wY = 0f;
            try
            {
                double xImg, yImg;
                double xAxis, yAxis;
                //相机缩放比率校正
                //xImg = img.getHomImg().AffineTransPoint2d(new HTuple(cols.ToArray()), new HTuple(rows.ToArray()), out yImg);
                Pixel2WorldPlane(img, row, col, out xImg, out yImg);
                xAxis = img.getHomAxis().AffineTransPoint2d(img.X, img.Y, out yAxis);

                wX = xImg + xAxis;
                wY = yImg + yAxis;
            }
            catch (System.Exception ex)
            {
            }
        }

        /// <summary>
        /// 直线转换世界坐标系
        /// </summary>
        /// <param name="img">图片信息</param>
        /// <param name="inLine">输入直线</param>
        /// <returns>返回世界坐标系直线</returns>
        public static Line_INFO Line2WorldPlane(HImageExt img, Line_INFO inLine)
        {
            Line_INFO outLine = new Line_INFO();
            try
            {
                Points2WorldPlane(img, inLine.StartY, inLine.StartX, out outLine.StartX, out outLine.StartY);
                Points2WorldPlane(img, inLine.EndY, inLine.EndX, out outLine.EndX, out outLine.EndY);
                outLine = new Line_INFO(outLine.StartY, outLine.StartX, outLine.EndY, outLine.EndX);
                return outLine;
            }
            catch (System.Exception ex)
            {
                Helper.LogHandler.Instance.VTLogError(ex.ToString());
                return outLine;
            }
        }

        /// <summary>
        /// 圆转换成世界坐标系
        /// </summary>
        /// <param name="img">图像信息</param>
        /// <param name="inCircle">输入圆</param>
        /// <returns>返回世界坐标系圆</returns>
        public static Circle_INFO Circle2WorldPlane(HImageExt img, Circle_INFO inCircle)
        {
            Circle_INFO outCircle = new Circle_INFO();
            try
            {
                Points2WorldPlane(img, inCircle.CenterY, inCircle.CenterX, out outCircle.CenterX, out outCircle.CenterY);
                outCircle.Radius = inCircle.Radius * (img.ScaleY + img.ScaleX) / 2;
                return outCircle;
            }
            catch (System.Exception ex)
            {
                Helper.LogHandler.Instance.VTLogError(ex.ToString());
                return outCircle;
            }
        }

        /// <summary>
        /// 椭圆转换成世界坐标系
        /// </summary>
        /// <param name="img">图像信息</param>
        /// <param name="inCircle">输入椭圆</param>
        /// <returns>返回世界坐标系椭圆</returns>
        public static Ellipse_INFO Ellipse2WorldPlane(HImageExt img, Ellipse_INFO inEllipse)
        {
            Ellipse_INFO outEllipse = new Ellipse_INFO();
            try
            {
                Points2WorldPlane(img, inEllipse.CenterY, inEllipse.CenterX, out outEllipse.CenterX, out outEllipse.CenterY);
                outEllipse.Radius1 = inEllipse.Radius1 * (img.ScaleY + img.ScaleX) / 2;
                outEllipse.Radius2 = inEllipse.Radius2 * (img.ScaleY + img.ScaleX) / 2;
                return outEllipse;
            }
            catch (System.Exception ex)
            {
                Helper.LogHandler.Instance.VTLogError(ex.ToString());
                return outEllipse;
            }
        }

        /// <summary>
        /// 图像坐标点转换为mm坐标点，使用区域标定的方法
        /// </summary>
        /// <param name="img">坐标信息图像</param>
        /// <param name="rows">输入坐标行</param>
        /// <param name="cols">输入坐标列</param>
        /// <param name="X">输出mm坐标行</param>
        /// <param name="Y">输出mm坐标列</param>
        public static void Pixel2WorldPlane(HImageExt img, List<double> rows, List<double> cols, out HTuple X, out HTuple Y)
        {
            X = new HTuple();
            Y = new HTuple();
            try
            {
                double xImg, yImg;
                //缩放校正
                for (int i = 0; i < rows.Count; i++)
                {
                    if (img.blnCalibrated)
                    {
                        HTuple row = HTuple.TupleGenConst(img.BoardRow.Length, rows[i]);
                        HTuple col = HTuple.TupleGenConst(img.BoardRow.Length, cols[i]);
                        HTuple distance = HMisc.DistancePp(row, col, img.BoardRow, img.BoardCol);
                        int index = distance.TupleFindFirst(distance.TupleMin()).I;
                        xImg = img.BoardX[index].D + (cols[i] - img.BoardCol[index].D) * img.ScaleX;
                        yImg = img.BoardY[index].D + (rows[i] - img.BoardRow[index].D) * img.ScaleY;
                    }
                    else
                    {
                        xImg = cols[i] * img.ScaleX;
                        yImg = rows[i] * img.ScaleY;
                    }
                    X = X.TupleConcat(xImg);
                    Y = Y.TupleConcat(yImg);
                }
            }
            catch (System.Exception ex)
            {
            }
        }
        /// <summary>
        /// 图像坐标点转换为mm坐标
        /// </summary>
        /// <param name="img">坐标信息图像</param>
        /// <param name="row">输入坐标行</param>
        /// <param name="col">输入坐标列</param>
        /// <param name="wX">输出mm坐标行</param>
        /// <param name="wY">输出mm坐标列</param>
        public static void Pixel2WorldPlane(HImageExt img, double row, double col, out double X, out double Y)
        {
            X = 0f; Y = 0f;
            try
            {
                if (img.blnCalibrated)
                {
                    //缩放校正
                    HTuple rows = HTuple.TupleGenConst(img.BoardRow.Length, row);
                    HTuple cols = HTuple.TupleGenConst(img.BoardRow.Length, col);
                    HTuple distance = HMisc.DistancePp(rows, cols, img.BoardRow, img.BoardCol);
                    int index = distance.TupleFindFirst(distance.TupleMin()).I;
                    X = img.BoardX[index].D + (col - img.BoardCol[index].D) * img.ScaleX;
                    Y = img.BoardY[index].D + (row - img.BoardRow[index].D) * img.ScaleY;
                }
                else
                {
                    X = col * img.ScaleX;
                    Y = row * img.ScaleY;
                }
            }
            catch (System.Exception ex)
            {
            }
        }

        /// <summary>
        /// mm坐标转换为图像坐标
        /// </summary>
        /// <param name="img">坐标信息图像</param>
        /// <param name="X">当前图像mm坐标X</param>
        /// <param name="Y">当前图像mm坐标Y</param>
        /// <param name="row">图像坐标row</param>
        /// <param name="col">图像坐标col</param>
        public static void ImagePlane2Pixel(HImageExt img, double X, double Y, out double row, out double col)
        {
            row = 0f; col = 0f;
            try
            {
                if (img.blnCalibrated)
                {
                    //缩放校正
                    HTuple Xs = HTuple.TupleGenConst(img.BoardRow.Length, X);
                    HTuple Ys = HTuple.TupleGenConst(img.BoardRow.Length, Y);
                    HTuple distance = HMisc.DistancePp(Xs, Ys, img.BoardX, img.BoardY);
                    int index = distance.TupleFindFirst(distance.TupleMin()).I;
                    col = img.BoardCol[index].D + (X - img.BoardX[index].D) / img.ScaleX;
                    row = img.BoardRow[index].D + (Y - img.BoardY[index].D) / img.ScaleY;
                }
                else
                {
                    col = X / img.ScaleX;
                    row = Y / img.ScaleY;
                }
            }
            catch (System.Exception ex)
            {
            }
        }

        /// <summary>
        /// 世界坐标转换为当前图像的像素坐标
        /// </summary>
        /// <param name="img">坐标信息图像</param>
        /// <param name="wX">世界坐标X</param>
        /// <param name="wY">世界坐标Y</param>
        /// <param name="row">图像坐标row</param>
        /// <param name="col">图像坐标col</param>
        public static void WorldPlane2Point(HImageExt img, double wX, double wY, out double row, out double col)
        {
            row = 0f; col = 0f;
            double xImg, yImg;
            try
            {
                double xAxis, yAxis;
                xAxis = img.getHomAxis().AffineTransPoint2d(img.X, img.Y, out yAxis);
                xImg = wX - xAxis;
                yImg = wY - yAxis;
                ImagePlane2Pixel(img, xImg, yImg, out row, out col);

            }
            catch (System.Exception ex)
            {
            }
        }
        /// <summary>
        /// 直线转换世界坐标系
        /// </summary>
        /// <param name="img">图片信息</param>
        /// <param name="inLine">输入世界坐标直线</param>
        /// <returns>返回图像坐标系直线</returns>
        public static Line_INFO Line2PixelPlane(HImageExt img, Line_INFO inLine)
        {
            Line_INFO outLine = new Line_INFO();
            try
            {
                WorldPlane2Point(img, inLine.StartX, inLine.StartY, out outLine.StartY, out outLine.StartX);
                WorldPlane2Point(img, inLine.EndX, inLine.EndY, out outLine.EndY, out outLine.EndX);
                outLine = new Line_INFO(outLine.StartY, outLine.StartX, outLine.EndY, outLine.EndX);
                return outLine;
            }
            catch (System.Exception ex)
            {
                Helper.LogHandler.Instance.VTLogError(ex.ToString());
                return outLine;
            }
        }


        /// <summary>
        /// 世界坐标圆转换成当前图像坐标系
        /// </summary>
        /// <param name="img">图像信息</param>
        /// <param name="inCircle">输入圆</param>
        /// <returns>返回当前图像坐标系圆</returns>
        public static Circle_INFO Circle2PixelPlane(HImageExt img, Circle_INFO inCircle)
        {
            Circle_INFO outCircle = new Circle_INFO();
            try
            {
                WorldPlane2Point(img, inCircle.CenterX, inCircle.CenterY, out outCircle.CenterY, out outCircle.CenterX);


                outCircle.Radius = inCircle.Radius * 2 / (img.ScaleY + img.ScaleX);
                return outCircle;
            }
            catch (System.Exception ex)
            {
                Helper.LogHandler.Instance.VTLogError(ex.ToString());
                return outCircle;
            }
        }

        /// <summary>
        /// 世界坐标系椭圆转换成图像坐标系
        /// </summary>
        /// <param name="img">图像信息</param>
        /// <param name="inEllipse">输入椭圆</param>
        /// <returns>返回当前图像坐标系椭圆</returns>
        public static Ellipse_INFO Ellipse2PixelPlane(HImageExt img, Ellipse_INFO inEllipse)
        {
            Ellipse_INFO outEllipse = new Ellipse_INFO();
            try
            {
                WorldPlane2Point(img, inEllipse.CenterX, inEllipse.CenterY, out outEllipse.CenterY, out outEllipse.CenterX);

                outEllipse.Radius1 = inEllipse.Radius1 * 2 / (img.ScaleY + img.ScaleX);
                outEllipse.Radius2 = inEllipse.Radius2 * 2 / (img.ScaleY + img.ScaleX);
                return outEllipse;
            }
            catch (System.Exception ex)
            {
                Helper.LogHandler.Instance.VTLogError(ex.ToString());
                return outEllipse;
            }
        }

        public static HXLDCont GetCoord(HImageExt img, Coordinate_INFO coord)
        {
            int Width, Height;
            double row, col;
            HXLDCont CoordXLD;
            img.GetImageSize(out Width, out Height);
            HTuple row1 = new HTuple(new double[] { 0, 0 });
            HTuple col1 = new HTuple(new double[] { 0, 0 });
            HTuple row2 = new HTuple(new double[] { 0, Height / 2 });
            HTuple col2 = new HTuple(new double[] { Width / 2, 0 });
            HMeasureSet.GenArrowContourXld(out CoordXLD, row1, col1, row2, col2, 10, 10);
            HMeasureSet.WorldPlane2Point(img, coord.X, coord.Y, out row, out col);
            HHomMat2D hom = new HHomMat2D();
            hom.VectorAngleToRigid(0, 0, 0, row, col, coord.Phi);
            CoordXLD = CoordXLD.AffineTransContourXld(hom);
            return CoordXLD;
        }

        public static HImage AffineImage(HImage img, AcqDevice.IMG_ADJUST ImgAdjustMode)
        {
            HImage tempImg = new HImage();

            switch (ImgAdjustMode)
            {
                case IMG_ADJUST.None:
                    tempImg = img.Clone();
                    break;
                case IMG_ADJUST.垂直镜像:
                    tempImg = img.MirrorImage("row");
                    break;
                case IMG_ADJUST.水平镜像:
                    tempImg = img.MirrorImage("column");
                    break;
                case IMG_ADJUST.顺时针90度:
                    tempImg = img.RotateImage(270.0, "nearest_neighbor");
                    break;
                case IMG_ADJUST.逆时针90度:
                    tempImg = img.RotateImage(90.0, "nearest_neighbor");
                    break;
                case IMG_ADJUST.旋转180度:
                    tempImg = img.RotateImage(180.0, "nearest_neighbor");
                    break;
            }
            return tempImg;
        }
    }
}