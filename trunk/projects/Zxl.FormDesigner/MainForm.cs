using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zxl.Test
{
    public partial class MainForm : Form
    {
        /// <summary>
        ///  有关鼠标样式的相关枚举
        /// </summary>
        private enum EnumMousePointPosition
        {
            MouseSizeNone = 0, //默认
            MouseSizeRight = 1, //拉伸右边框
            MouseSizeLeft = 2,  //拉伸左边框
            MouseSizeBottom = 3, //拉伸下边框
            MouseSizeTop = 4, //拉伸上边框
            MouseSizeTopLeft = 5,//拉伸左上角
            MouseSizeTopRight = 6,//拉伸右上角
            MouseSizeBottomLeft = 7,//拉伸左下角
            MouseSizeBottomRight = 8,//拉伸右下角
            MouseDrag = 9 //鼠标拖动
        }
        const int Band = 5;//范围半径
        const int MinWidth = 10;//最低宽度
        const int MinHeight = 10;//最低高度
        private EnumMousePointPosition m_MousePointPosition; //鼠标样式枚举
        private Point m_lastPoint; //光标上次移动的位置
        private Point m_endPoint; //光标移动的当前位置

        public MainForm()
        {
            InitializeComponent();
            //窗体中控件的事件晚期绑定
            for (int i = 0; i < this.Controls.Count; i++)
            {
                this.Controls[i].MouseDown += new MouseEventHandler(MyMouseDown);
                this.Controls[i].MouseLeave += new EventHandler(MyMouseLeave);
                this.Controls[i].MouseMove += new MouseEventHandler(MyMouseMove);
            }
        }

        //鼠标按下事件
        private void MyMouseDown(object sender, MouseEventArgs e)
        {
            m_lastPoint.X = e.X;
            m_lastPoint.Y = e.Y;
            m_endPoint.X = e.X;
            m_endPoint.Y = e.Y;
        }

        //鼠标离开控件的事件
        private void MyMouseLeave(object sender, System.EventArgs e)
        {
            m_MousePointPosition = EnumMousePointPosition.MouseSizeNone;
            this.Cursor = Cursors.Arrow;
        }

        //鼠标移过控件的事件
        private void MyMouseMove(object sender, MouseEventArgs e)
        {
            Control lCtrl = (sender as Control);//获得事件源
            //左键按下移动
            if (e.Button == MouseButtons.Left)
            {
                switch (m_MousePointPosition)
                {
                    case EnumMousePointPosition.MouseDrag:
                        lCtrl.Left = lCtrl.Left + e.X - m_lastPoint.X;
                        lCtrl.Top = lCtrl.Top + e.Y - m_lastPoint.Y;
                        break;
                    case EnumMousePointPosition.MouseSizeBottom:
                        lCtrl.Height = lCtrl.Height + e.Y - m_endPoint.Y;
                        m_endPoint.X = e.X;
                        m_endPoint.Y = e.Y; //记录光标拖动的当前点                      
                        break;
                    case EnumMousePointPosition.MouseSizeBottomRight:
                        lCtrl.Width = lCtrl.Width + e.X - m_endPoint.X;
                        lCtrl.Height = lCtrl.Height + e.Y - m_endPoint.Y;
                        m_endPoint.X = e.X;
                        m_endPoint.Y = e.Y; //记录光标拖动的当前点                       
                        break;
                    case EnumMousePointPosition.MouseSizeRight:
                        lCtrl.Width = lCtrl.Width + e.X - m_endPoint.X;
                        //lCtrl.Height = lCtrl.Height + e.Y - m_endPoint.Y;
                        m_endPoint.X = e.X;
                        m_endPoint.Y = e.Y; //记录光标拖动的当前点
                        break;
                    case EnumMousePointPosition.MouseSizeTop:
                        lCtrl.Top = lCtrl.Top + (e.Y - m_lastPoint.Y);
                        lCtrl.Height = lCtrl.Height - (e.Y - m_lastPoint.Y);
                        break;
                    case EnumMousePointPosition.MouseSizeLeft:
                        lCtrl.Left = lCtrl.Left + e.X - m_lastPoint.X;
                        lCtrl.Width = lCtrl.Width - (e.X - m_lastPoint.X);
                        break;
                    case EnumMousePointPosition.MouseSizeBottomLeft:
                        lCtrl.Left = lCtrl.Left + e.X - m_lastPoint.X;
                        lCtrl.Width = lCtrl.Width - (e.X - m_lastPoint.X);
                        lCtrl.Height = lCtrl.Height + e.Y - m_endPoint.Y;
                        m_endPoint.X = e.X;
                        m_endPoint.Y = e.Y; //记录光标拖动的当前点
                        break;
                    case EnumMousePointPosition.MouseSizeTopRight:
                        lCtrl.Top = lCtrl.Top + (e.Y - m_lastPoint.Y);
                        lCtrl.Width = lCtrl.Width + (e.X - m_endPoint.X);
                        lCtrl.Height = lCtrl.Height - (e.Y - m_lastPoint.Y);
                        m_endPoint.X = e.X;
                        m_endPoint.Y = e.Y; //记录光标拖动的当前点                       
                        break;
                    case EnumMousePointPosition.MouseSizeTopLeft:
                        lCtrl.Left = lCtrl.Left + e.X - m_lastPoint.X;
                        lCtrl.Top = lCtrl.Top + (e.Y - m_lastPoint.Y);
                        lCtrl.Width = lCtrl.Width - (e.X - m_lastPoint.X);
                        lCtrl.Height = lCtrl.Height - (e.Y - m_lastPoint.Y);
                        break;
                    default:
                        break;
                }
                if (lCtrl.Width < MinWidth) lCtrl.Width = MinWidth;
                if (lCtrl.Height < MinHeight) lCtrl.Height = MinHeight;
            }
            else
            {
                //判断光标的位置状态 
                m_MousePointPosition = MousePointPosition(lCtrl.Size, e);
                switch (m_MousePointPosition)  //改变光标
                {
                    case EnumMousePointPosition.MouseSizeNone:
                        this.Cursor = Cursors.Arrow;//箭头
                        break;
                    case EnumMousePointPosition.MouseDrag:
                        this.Cursor = Cursors.SizeAll;//四方向
                        break;
                    case EnumMousePointPosition.MouseSizeBottom:
                        this.Cursor = Cursors.SizeNS;//南北
                        break;
                    case EnumMousePointPosition.MouseSizeTop:
                        this.Cursor = Cursors.SizeNS;//南北
                        break;
                    case EnumMousePointPosition.MouseSizeLeft:
                        this.Cursor = Cursors.SizeWE;//东西
                        break;
                    case EnumMousePointPosition.MouseSizeRight:
                        this.Cursor = Cursors.SizeWE;//东西
                        break;
                    case EnumMousePointPosition.MouseSizeBottomLeft:
                        this.Cursor = Cursors.SizeNESW;//东北到南西
                        break;
                    case EnumMousePointPosition.MouseSizeBottomRight:
                        this.Cursor = Cursors.SizeNWSE;//东南到西北
                        break;
                    case EnumMousePointPosition.MouseSizeTopLeft:
                        this.Cursor = Cursors.SizeNWSE;//东南到西北
                        break;
                    case EnumMousePointPosition.MouseSizeTopRight:
                        this.Cursor = Cursors.SizeNESW;//东北到南西
                        break;
                    default:
                        break;
                }
            }
        }
        //坐标位置判定
        private EnumMousePointPosition MousePointPosition(Size size, System.Windows.Forms.MouseEventArgs e)
        {
            if ((e.X >= -1 * Band) | (e.X <= size.Width) |
                (e.Y >= -1 * Band) | (e.Y <= size.Height))
            {
                if (e.X < Band)
                {
                    if (e.Y < Band)
                    {
                        return EnumMousePointPosition.MouseSizeTopLeft;
                    }
                    else
                    {
                        if (e.Y > -1 * Band + size.Height)
                        {
                            return EnumMousePointPosition.MouseSizeBottomLeft;
                        }
                        else
                        {
                            return EnumMousePointPosition.MouseSizeLeft;
                        }
                    }
                }
                else
                {
                    if (e.X > -1 * Band + size.Width)
                    {
                        if (e.Y < Band)
                        { return EnumMousePointPosition.MouseSizeTopRight; }
                        else
                        {
                            if (e.Y > -1 * Band + size.Height)
                            { return EnumMousePointPosition.MouseSizeBottomRight; }
                            else
                            { return EnumMousePointPosition.MouseSizeRight; }
                        }
                    }
                    else
                    {
                        if (e.Y < Band)
                        { return EnumMousePointPosition.MouseSizeTop; }
                        else
                        {
                            if (e.Y > -1 * Band + size.Height)
                            { return EnumMousePointPosition.MouseSizeBottom; }
                            else
                            { return EnumMousePointPosition.MouseDrag; }
                        }
                    }
                }
            }
            else
            { return EnumMousePointPosition.MouseSizeNone; }
        }
    }
}
