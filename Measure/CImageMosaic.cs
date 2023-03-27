using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.Data;
using CPublicDefine;

namespace Measure
{
    /// <summary>
    /// 图像拼接
    /// </summary>
    [Serializable]
    public class CImageMosaic : CMeasureCell
    {
        public CImageMosaic()
            : base()
        {
        }
        public CImageMosaic(CellCatagory _CellCatagory, int _CellID)
            : base(_CellCatagory, _CellID)
        {
        }
        #region 属性
        /// <summary>
        /// 拼接图像列表
        /// </summary>
        public List<string> ImageList = new List<string>();

        /// <summary>
        /// 输出图像名称
        /// </summary>
        public string outImg = string.Empty;

        /// <summary>
        /// 图像拼接模式
        /// </summary>
        public int MosaicMode = 0; //0-位置拼接 1-特征拼接
        #endregion

        #region 方法
        public override void Execute(bool blnByHand = false)
        {
            try
            {
                F_DATA_CELL data = m_Owner.m_VariableList.FirstOrDefault(c => c.m_Data_CellID == HMeasureSYS.U000 && c.m_Data_Name == outImg);

                #region 图像位置信息拼接
                if (MosaicMode == 0)
                { }
                #endregion

                #region 特征点拼接
                else if(MosaicMode==1)
                {
                    if (ImageList.Count < 1)
                        return;
                    else if (ImageList.Count == 1)
                    {
                        F_DATA_CELL dataImg = m_Owner.m_VariableList.FirstOrDefault(c => c.m_Data_CellID == HMeasureSYS.U000 && c.m_Data_Name == ImageList[0]);
                        ((List<HImageExt>)data.m_Data_Value)[0] = ((List<HImageExt>)dataImg.m_Data_Value)[0];
                    }
                    else
                    {
                        F_DATA_CELL dataImg = m_Owner.m_VariableList.FirstOrDefault(c => c.m_Data_CellID == HMeasureSYS.U000 && c.m_Data_Name == ImageList[0]);
                        HImage img0 = ((List<HImageExt>)dataImg.m_Data_Value)[0];

                        HTuple rowJunctions; HTuple columnJunctions; HTuple coRRJunctions; HTuple coRCJunctions; HTuple coCCJunctions; HTuple rowArea; HTuple columnArea; HTuple coRRArea; HTuple coRCArea; HTuple coCCArea;
                        HTuple rowJunctions1; HTuple columnJunctions1; HTuple coRRJunctions1; HTuple coRCJunctions1; HTuple coCCJunctions1; HTuple rowArea1; HTuple columnArea1; HTuple coRRArea1; HTuple coRCArea1; HTuple coCCArea1;
                        img0.PointsFoerstner((double)1, 2, 3, 50, 0.1, "gauss", "true", out rowJunctions, out columnJunctions, out coRRJunctions, out coRCJunctions, out coCCJunctions, out rowArea, out columnArea, out coRRArea, out coRCArea, out coCCArea);
                        int width, height;
                        img0.GetImageSize(out width, out height);
                        HHomMat2D HomMat2DUnrectified; HTuple Points1Unrectified; HTuple Points2Unrectified;
                        for (int i = 1; i < ImageList.Count; i++)
                        {
                            HImage img = ((List<HImageExt>)dataImg.m_Data_Value)[i];

                            img.PointsFoerstner((double)1, 2, 3, 50, 0.1, "gauss", "true", out rowJunctions1, out columnJunctions1, out coRRJunctions1, out coRCJunctions1, out coCCJunctions1, out rowArea1, out columnArea1, out coRRArea1, out coRCArea1, out coCCArea1);
                            //img0.ProjMatchPointsRansac(img, rowJunctions, columnJunctions, rowJunctions1, columnJunctions1, "ncc", 10, 0, 0, height, width, 0, 0.5, "gold_standard", 2, 42,out HomMat2DUnrectified,out Points1Unrectified,out Points2Unrectified);
                            HomMat2DUnrectified = img0.ProjMatchPointsRansac(img, rowJunctions, columnJunctions, rowJunctions1, columnJunctions1, "ncc", 10, 0, 0, height, width, 0, 0.5, "gold_standard", 2, 42, out Points1Unrectified, out Points2Unrectified);
                            img0 = img0.ConcatObj(img);
                            HHomMat2D[] MosaicMatrices2DUnrectified;
                            img0 = img0.GenProjectiveMosaic(1, 1, 2, new HHomMat2D[] { HomMat2DUnrectified}, "default", "false", out MosaicMatrices2DUnrectified);
                            img0.PointsFoerstner((double)1, 2, 3, 50, 0.1, "gauss", "true", out rowJunctions, out columnJunctions, out coRRJunctions, out coRCJunctions, out coCCJunctions, out rowArea, out columnArea, out coRRArea, out coRCArea, out coCCArea);
                            img0.GetImageSize(out width, out height);
                        }
                        ((List<HImageExt>)data.m_Data_Value)[0] = HImageExt.Instance(img0);
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
            }
        }
        #endregion
    }
}
