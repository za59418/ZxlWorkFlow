using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zxl.FormDesigner
{
    public partial class ListBoxDrgDropListBox : Form
    {

        private bool Mousedown;

        /// <summary>
        /// 鼠标在事件源的位置
        /// </summary>
        private int CurX = 0;
        private int CurY = 0;

        public ListBoxDrgDropListBox()
        {
            InitializeComponent();
        }

        private void Controls_MouseDown(object sender, MouseEventArgs e)
        {
            CurX = e.X;
            CurY = e.Y;
            Mousedown = true;

            ((Control)sender).Cursor = Cursors.NoMove2D;

        }

        private void Controls_MouseMove(object sender, MouseEventArgs e)
        {
            if (Mousedown)
            {
                // 获取当前屏幕的光标坐标
                Point pTemp = new Point(Cursor.Position.X, Cursor.Position.Y);
                // 转换成工作区坐标
                pTemp = this.PointToClient(pTemp);
                // 定位事件源的 Location
                Control control = sender as Control;
                control.Location = new Point(pTemp.X - CurX, pTemp.Y - CurY);
            }
        }

        private void Controls_MouseUp(object sender, MouseEventArgs e)
        {
            Mousedown = false;
            if (sender is TextBox)
            {
                ((TextBox)sender).Cursor = Cursors.IBeam;
            }
        }
    }
}