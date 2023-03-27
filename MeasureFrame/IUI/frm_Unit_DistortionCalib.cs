using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Measure;
using CPublicDefine;
using HalconDotNet;

namespace MeasureFrame.IUI
{
    public partial class frm_Unit_DistortionCalib : frm_Unit
    {
        private HRegion detectRegion = new HRegion();
        private HRegion disableRegion = new HRegion();
        HImageExt Image = new HImageExt();
        HXLDCont xldMark = new HXLDCont();
        public frm_Unit_DistortionCalib()
            : base()
        {
            InitializeComponent();
            m_Unit = new CDistortionCalib(CellCatagory.畸变标定, HMeasureSYS.Cur_Project.m_LastCellID);
        }
        /// <summary>
        /// 构造函数，打开已有的单元
        /// </summary>
        /// <param name="MeasurCellBase"></param>
        public frm_Unit_DistortionCalib(ref CMeasureCell MeasurCellBase)
            : base(ref MeasurCellBase)
        {
            InitializeComponent();
        }

        private void frm_DistortionCalib_Load(object sender, EventArgs e)
        {
            InitRegisterCmbImgList();
            string m_FlowID = "U" + ((CDistortionCalib)m_Unit).m_CellID.ToString("D4");
            this.Text = m_FlowID + " : " + ((CDistortionCalib)m_Unit).m_CellCatagory.ToString();
            txt_UnitDescrible.Text = ((CDistortionCalib)m_Unit).m_CellDesCribe;
            if (!blnNewUnit)
            {
                detectRegion = ((CDistortionCalib)m_Unit).DetectRegion;
                disableRegion = ((CDistortionCalib)m_Unit).DisableRegion;
                cmb_registerImg.Text = ((CDistortionCalib)m_Unit).RegisterImgName;
                cmb_BoardType.SelectedIndex = ((CDistortionCalib)m_Unit).BoardType;
                numericUpDown.Value = (decimal)((CDistortionCalib)m_Unit).Distance;
                lScaleX.Text = "X=" + ((CDistortionCalib)m_Unit).ScaleX.ToString("#0.0000000");
                lScaleY.Text = "Y=" + ((CDistortionCalib)m_Unit).ScaleY.ToString("#0.0000000");
            }
            frm_Main.thisHandle.hWindow_Fit.RePaint += new HalconControl.DelegateRePaint(PaintMetrology);

        }
        /// <summary>
        /// 初始化注册图像列表
        /// </summary>
        protected void InitRegisterCmbImgList()
        {
            List<string> m_RegisterImageNames = new List<string>();//注册图像名称列表
            foreach (RegisterIMG_Info datacell in HMeasureSYS.Cur_Project.m_RegisterImg)
            {
                m_RegisterImageNames.Add(datacell.m_ImageID);
            }
            cmb_registerImg.DataSource = m_RegisterImageNames;
        }

        private void cmb_registerImg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_registerImg.SelectedIndex >= 0)
            {
                HMeasureSYS.Cur_Project.QueryImage(ImageCatagory.注册图像, cmb_registerImg.Text, out Image);
                frm_Main.thisHandle.hWindow_Fit.Image = Image;
                frm_Main.thisHandle.hWindow_Fit.DispImageFit();
            }
        }

        private void bt_ROI_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            double row1, col1, row2, col2;
            frm_Main.thisHandle.hWindow_Fit.HWindowID.SetDraw("margin");
            frm_Main.thisHandle.hWindow_Fit.DrawRectangle1("green", out row1, out col1, out row2, out col2);
            detectRegion = new HRegion(row1, col1, row2, col2);
            this.Visible = true;
        }

        private void bt_disableRegion_Click(object sender, EventArgs e)
        {

            this.Visible = false;
            if (disableRegion == null || !disableRegion.IsInitialized())
            {
                disableRegion = new HRegion();
            }
            disableRegion = frm_Main.thisHandle.hWindow_Fit.SetROI(disableRegion);

            this.Visible = true;

            //this.Visible = false;
            //frm_Main.thisHandle.hWindow_Fit.HWindowID.SetDraw("margin");
            //disableRegion = frm_Main.thisHandle.hWindow_Fit.SetROI(disableRegion);
            //this.Visible = true;
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            try
            {
                double Scale = 1f;
                double ScaleX = 0f;
                double ScaleY = 0f;
                HTuple Row = new HTuple(), Col = new HTuple(), PositionX = new HTuple(), PositionY = new HTuple();
                HHomMat2D homPhi = new HHomMat2D();//孔板放置夹角
                HTuple tmpRow = new HTuple(), tmpCol = new HTuple();
                HTuple tmpX = new HTuple(), tmpY = new HTuple();
                if (Image.IsInitialized())
                {
                    HRegion roi = detectRegion;
                    if (disableRegion!=null&&disableRegion.IsInitialized())
                        roi = detectRegion.Difference(disableRegion);
                    HImage tmpIMG = Image.ReduceDomain(roi);
                    double gapDistance = (double)numericUpDown.Value;
                    int seed = 0;
                    if (cmb_BoardType.SelectedIndex == 0)//孔板
                    {
                        HXLDCont xld = tmpIMG.ThresholdSubPix(new HTuple(60));

                        // 长度增加异常长度剔除  yoga 2017-8-31 9:34:24
                        //根据面积、长度和圆度剔除异常圆
                        //area_center_xld(Border, Area, Row, Column, PointOrder)
                        HTuple Length = xld.LengthXld();
                        int errCount =(int)( Length.Length*0.8);
                        List<double> length = new List<double>(Length.ToDArr());// .ToList();
                        length.Sort();
                        length.RemoveRange(0, errCount);

                        //list = list.Skip((int)(list.Count * (1 - percent))).ToList();

                        HTuple Radius = new HTuple(), StartPhi = new HTuple(), EndPhi = new HTuple(), order = new HTuple();
                        double avgLength = length.Average();
                        xld = xld.SelectShapeXld("contlength", "and", 0.7 * avgLength, 1.3 * avgLength);
                        xld = xld.SelectShapeXld("circularity", "and", 0.8, 1);
                        xld.FitCircleContourXld("algebraic", -1, 0, 0, 3, 2, out Row, out Col, out Radius, out StartPhi, out EndPhi, out order);
                        if (Row==null||Row.Length<1)
                        {
                            MessageBox.Show("标志点查找失败,请检查设置");
                            return;
                        }
                        //显示轮廓
                        xldMark.GenCircleContourXld(Row, Col, Radius, StartPhi, EndPhi, order, 1.0);
                        HXLDCont cross = new HXLDCont();
                        cross.GenCrossContourXld(Row, Col, 3, 0);
                        xldMark = xldMark.ConcatObj(cross);
                        //计算像素比  随机取一个点 到其他点的距离，取最小的作为点间距 ，不允许孤立的点
                        Random rd = new Random();
                        seed = rd.Next(Row.Length);
                        seed = 0;
                        VBA_Function.SortPairs(ref Row, ref Col);
                        HTuple chooseRow = HTuple.TupleGenConst(Row.Length - 1, Row[seed]);
                        HTuple chooseCol = HTuple.TupleGenConst(Col.Length - 1, Col[seed]);
                        tmpRow = Row.TupleRemove(seed);
                        tmpCol = Col.TupleRemove(seed);
                        double distance = HMisc.DistancePp(chooseRow, chooseCol, tmpRow, tmpCol).TupleMin().D;
                        Scale = (double)numericUpDown.Value / distance;
                        
                        for (int i = 0; i < Row.Length; i++)
                        {
                            if (i == seed)
                            {
                                PositionX = PositionX.TupleConcat(0f);
                                PositionY = PositionY.TupleConcat(0f);
                                continue;
                            }
                            int sRow = (int)((Row[i].D - Row[seed].D) / distance + ((Row[i].D - Row[seed].D) > 0 ? 1 : -1) * 0.5);//四舍五入
                            int sCol = (int)((Col[i].D - Col[seed].D) / distance + ((Col[i].D - Col[seed].D) > 0 ? 1 : -1) * 0.5);//四舍五入
                            PositionX = PositionX.TupleConcat(sCol * gapDistance);
                            PositionY = PositionY.TupleConcat(sRow * gapDistance);
                        }
                        HTuple chooseX = HTuple.TupleGenConst(PositionX.Length - 1, PositionX[seed]);
                        HTuple chooseY = HTuple.TupleGenConst(PositionY.Length - 1, PositionY[seed]);
                        tmpX = PositionX.TupleRemove(seed);
                        tmpY = PositionY.TupleRemove(seed);

                        //计算出像素当量
                        double PixCount= HMisc.DistancePp(chooseRow, chooseCol, tmpRow, tmpCol).TupleSum().D;
                        double mmCount = HMisc.DistancePp(chooseY, chooseX, tmpY, tmpX).TupleSum().D;
                        Scale = mmCount / PixCount;
                        //计算标定板角度偏差
                        HHomMat2D hom = new HHomMat2D();
                        hom.VectorToHomMat2d(PositionX, PositionY, Col, Row);
                        double sx, sy, phi, theta, tx, ty;
                        sx = hom.HomMat2dToAffinePar(out sy, out phi, out theta, out tx, out ty);
                        hom = new HHomMat2D();
                        hom = hom.HomMat2dRotate(phi, 0, 0);
                        hom = hom.HomMat2dTranslate(Scale * Col[seed].D, Scale * Row[seed].D);
                        PositionX = hom.AffineTransPoint2d(PositionX, PositionY, out PositionY);
                        //homPhi = homPhi.HomMat2dRotate(phi, Col[seed].D, Row[seed].D);
                    }
                    else if (cmb_BoardType.SelectedIndex == 1)//棋盘格
                    {

                    }
                    //计算比例
                    //tmpCol = homPhi.AffineTransPoint2d(Col, Row, out tmpRow);

                    ScaleX = Scale;
                    ScaleY = Scale;
                    ((CDistortionCalib)m_Unit).ScaleX = ScaleX;
                    ((CDistortionCalib)m_Unit).ScaleY = ScaleY;
                    ((CDistortionCalib)m_Unit).RegisterImgName = cmb_registerImg.Text;
                    ((CDistortionCalib)m_Unit).BoardType = cmb_BoardType.SelectedIndex;
                    ((CDistortionCalib)m_Unit).Distance = (double)numericUpDown.Value;
                    ((CDistortionCalib)m_Unit).DetectRegion = detectRegion;
                    ((CDistortionCalib)m_Unit).DisableRegion = disableRegion;
                    ((CDistortionCalib)m_Unit).BoardRow = Row;
                    ((CDistortionCalib)m_Unit).BoardCol = Col;
                    ((CDistortionCalib)m_Unit).BoardX = PositionX;
                    ((CDistortionCalib)m_Unit).BoardY = PositionY;
                    ((CDistortionCalib)m_Unit).Calibrated = true;
                    lScaleX.Text = "X=" + ScaleX.ToString("#0.000000");
                    lScaleY.Text = "Y=" + ScaleY.ToString("#0.000000");
                    if (blnNewUnit)
                    {
                        ((CDistortionCalib)m_Unit).m_Owner = HMeasureSYS.Cur_Project;
                        blnNewUnit = false;
                    }

                    PaintMetrology();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 绘画出模型
        /// </summary>
        protected void PaintMetrology()
        {

            frm_Main frm_Main = frm_Main.thisHandle;
            frm_Main.hWindow_Fit.HWindowID.SetDraw("margin");
            frm_Main.hWindow_Fit.HWindowID.SetColor("#0000FF");
            if (xldMark.IsInitialized())
            {
                frm_Main.hWindow_Fit.HWindowID.DispXld(xldMark);
            }

            if (disableRegion != null && disableRegion.IsInitialized())
            {
                frm_Main.hWindow_Fit.HWindowID.SetColor("red");
                frm_Main.hWindow_Fit.HWindowID.DispXld(disableRegion);
            }
            if (detectRegion != null && detectRegion.IsInitialized())
            {
                frm_Main.hWindow_Fit.HWindowID.SetColor("green");
                frm_Main.hWindow_Fit.HWindowID.DispXld(detectRegion);
            }
        }

        private void frm_Unit_DistortionCalib_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm_Main.thisHandle.hWindow_Fit.RePaint -= new HalconControl.DelegateRePaint(PaintMetrology);
        }
    }
}
