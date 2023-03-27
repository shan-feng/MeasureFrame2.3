using CPublicDefine;
using HalconDotNet;
using HEViewer.jig;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HEViewer
{
    public partial class Frm_PointCloud : Form
    {
        private double xScale = 0;//x像素当量
        private double yScale = 0;//y像素当量
        private double zRel = 0;//z方向的补偿值, 后面的z值需要加上这个值
        private bool roiFlag = false;//是否提取roi,提取的话,会把点云一分为2

        public Frm_PointCloud()
        {
            InitializeComponent();
        }

        private void button_export_cloud_Click(object sender, EventArgs e)
        {
            try
            {


                #region "导出点云设置"
                xScale = (Double)num_XScale.Value;
                yScale = (Double)num_YScale.Value*-1;//点云镜像矫正
                zRel = (Double)num_ZRef.Value;
                roiFlag = ckb_roi.Checked;
                #endregion



                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.Description = "请选择文件路径";


                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string foldPath = dialog.SelectedPath;

                    //设置进度条最大长度
                    ProgressBarForm pb = new ProgressBarForm();
                    pb.setMax(Frm_HEViewer.fileNameArr.Length);
                    ThreadPool.QueueUserWorkItem(o =>
                    {
                        Thread.Sleep(500);//故意停 ,否则下面的线程会在窗口弹出前就执行了
                        for (int i = 0; i < Frm_HEViewer.fileNameArr.Length; i++)
                        {
                            pb.setValue(i);

                            HImageExt tempHE = SerialTool.FromBinary<HImageExt>(Frm_HEViewer.fileNameArr[i]);
                            //   MessageBox.Show(scaleSize.ToString());
                            int width, height;
                            tempHE.GetImageSize(out width, out height);

                            //保存点云
                            exportPointCloud(tempHE, foldPath + "/" + Path.GetFileName(Frm_HEViewer.fileNameArr[i]).Split('.')[0]);
                            //
                            tempHE.Dispose();
                        }

                        pb.BeginInvoke(new Action(() =>
                        {
                            pb.Close();
                        }));
                    });

                    if (pb.IsDisposed == false)
                    {
                        pb.ShowDialog();
                    }

                    Process.Start("explorer.exe", foldPath);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void exportPointCloud(HImageExt tempHE, string fileName)
        {
            
            int width, height;
            tempHE.GetImageSize(out width, out height);

            if (roiFlag == true)//提出roi
            {
                List<HXLD> hXLDList = new List<HXLD>();

                //提取出所有的hXLD
                foreach (MeasureROI measureROI in tempHE.measureROIlist)
                {
                    HXLDCont hXLD = new HXLDCont(measureROI.hobject);

                    hXLDList.Add(hXLD);
                }

                StreamWriter sw1 = new StreamWriter(fileName + "_INROI.csv");
                StreamWriter sw2 = new StreamWriter(fileName + "_OUTROI.csv");

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        double z = tempHE.GetGrayval(y, x);
                        if (z > -99999)//剔除异常点
                        {
                            int isContainFlag = 0;//是否是roi内的点 1 表示包含,0表示不包含

                            foreach (HXLDCont xld in hXLDList)
                            {
                                if (isContainFlag == 0)//已经包含了就不用继续计算了
                                {
                                    isContainFlag = xld.TestXldPoint((double)y, x);
                                }
                            }

                            if (isContainFlag == 1)//如果包含在roiRegion范围内,则保存到INROI.csv
                            {
                                sw1.WriteLine(x * xScale + "," + y * yScale + "," + (z / 1000 + zRel));
                            }
                            else
                            {
                                sw2.WriteLine(x * xScale + "," + y * yScale + "," + (z / 1000 + zRel));
                            }
                        }
                    }
                }

                sw1.Close();
                sw2.Close();
            }
            else
            {
                StreamWriter sw = new StreamWriter(fileName + ".csv");
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        double z = tempHE.GetGrayval( y,x);
                        if (z > -99999)//剔除异常点
                        {
                            sw.WriteLine(x * xScale + "," + y * yScale + "," + (z / 1000 + zRel));
                        }
                    }
                }

                sw.Close();
            }


        }
    }
}
