using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Measure
{
    [Serializable]
    public class CResultView2 : CMeasureCell
    {
        public CResultView2() : base()
        {
        }

        public CResultView2(CellCatagory _CellCatagory, int _CellID) : base(_CellCatagory, _CellID)
        {
        }

        //是否显示
        public bool bVisible = false;

        //绘画容器位置
        public Rectangle rect = new Rectangle();
        //展示图像的行列offset
        public int offsetRow;
        public int offsetCol;
        public List<ResultView_Info> m_ViewList = new List<ResultView_Info>();
        public override void Execute(bool blnByHand = false)
        {
            if (bVisible && CHelper.g_ResultViewWnd != IntPtr.Zero)
            {
                if (CHelper.dlgUpdate != null)
                {
                    CHelper.dlgUpdate(this);
                }
            }
        }
    }
}
