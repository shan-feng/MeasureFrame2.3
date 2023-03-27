using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Measure;
using HalconDotNet;
using System.IO;
using CPublicDefine;
using Helper;

namespace MeasureFrame.IUI
{
    public partial class frm_RegImg : Form
    {
        public frm_RegImg()
        {
            InitializeComponent();
        }

        private void frm_RegImg_Load(object sender, EventArgs e)
        {
            dgv_ImgList.DataSource = new BindingList<RegisterIMG_Info>(HMeasureSYS.Cur_Project.m_RegisterImg);

            //当列表的row长度大于0的时候,再显示图片 magical20170821
            if (dgv_ImgList.Rows.Count > 0)
            {
                dgv_ImgList.Rows[0].Selected = true;
                DispImg();
            }
          
      
        }

        private void bt_Add_Click(object sender, EventArgs e)
        {
            OpenFileDialog fD = new OpenFileDialog();
            fD.Filter = "HE图像|*.he|PNG图像|*.png|BMP图像|*.bmp|JPEG图像|*.jpg|所有文件|*.*";
            if (fD.ShowDialog() == DialogResult.OK)
            {
                if (HMeasureSYS.Cur_Project.m_RegisterImg.FindIndex(c => c.m_ImageID == Path.GetFileNameWithoutExtension(fD.FileName)) < 0)
                {
                    //HImage _image = new HImage();
                    //_image.ReadImage(fD.FileName);
                    RegisterIMG_Info regImg = new RegisterIMG_Info(Path.GetFileNameWithoutExtension(fD.FileName), HImageExt.ReadImageExt(fD.FileName), Path.GetExtension(fD.FileName));
                    HMeasureSYS.Cur_Project.m_RegisterImg.Add(regImg);
                    dgv_ImgList.DataSource = new BindingList<RegisterIMG_Info>(HMeasureSYS.Cur_Project.m_RegisterImg);
                    dgv_ImgList.Rows[dgv_ImgList.Rows.Count - 1].Selected = true;
                    DispImg();
                }
                else
                {
                    MessageBox.Show(this, "该图像已经注册，或更改问件名称", "Warming");
                }
            }

        }

        private void bt_Delete_Click(object sender, EventArgs e)
        {
            if (dgv_ImgList.SelectedRows.Count > 0)
            {
                HMeasureSYS.Cur_Project.m_RegisterImg.RemoveAt(dgv_ImgList.SelectedRows[0].Cells[0].RowIndex);
                dgv_ImgList.DataSource = new BindingList<RegisterIMG_Info>(HMeasureSYS.Cur_Project.m_RegisterImg);
                DispImg();
            }
        }

        private void bt_ReName_Click(object sender, EventArgs e)
        {
            if (dgv_ImgList.SelectedRows.Count > 0)
            {
                if (HMeasureSYS.Cur_Project.m_RegisterImg.FindIndex(c => c.m_ImageID == txtName.Text.Trim()) < 0)
                {
                    RegisterIMG_Info regImg=HMeasureSYS.Cur_Project.m_RegisterImg[dgv_ImgList.SelectedRows[0].Cells[0].RowIndex];
                    regImg.m_ImageID = Path.GetFileNameWithoutExtension(txtName.Text.Trim());
                    HMeasureSYS.Cur_Project.m_RegisterImg[dgv_ImgList.SelectedRows[0].Cells[0].RowIndex] = regImg;

                }
                dgv_ImgList.DataSource = new BindingList<RegisterIMG_Info>(HMeasureSYS.Cur_Project.m_RegisterImg);
            }
        }

        private void bt_SaveImg_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_ImgList.SelectedRows.Count > 0)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "HE图片|*.he|PNG图像|*.png|BMP图像|*.bmp|JPEG图像|*.jpg|所有文件|*.*";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        HMeasureSYS.Cur_Project.m_RegisterImg[dgv_ImgList.SelectedRows[0].Cells[0].RowIndex].m_Image.WriteImageExt(sfd.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                LogHandler.Instance.VTLogError("注册图像保存错误 " + ex.ToString());
            }
        }


        private void dgv_ImgList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DispImg();
        }

        private void DispImg()
        {
            try
            {
                if (dgv_ImgList.SelectedRows.Count > 0)
                {
                    int height, width;
                    HImage img = HMeasureSYS.Cur_Project.m_RegisterImg[dgv_ImgList.SelectedRows[0].Cells[0].RowIndex].m_Image;
                    txtName.Text = HMeasureSYS.Cur_Project.m_RegisterImg[dgv_ImgList.SelectedRows[0].Cells[0].RowIndex].m_ImageID;
                    img.GetImageSize(out width, out height);
                    hWindowControl1.HalconWindow.SetPart(0, 0, height - 1, width - 1);
                    hWindowControl1.HalconWindow.DispImage(img);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("注册图像丢失，请重启软件");
            }
           
        }
    }
}
