using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Zxl.Business.Model;
using Zxl.Business.Interface;
using Zxl.Business.Impl;

namespace Zxl.FormDesigner
{
    public class Activity
    {
        public enum HitTestState
        {
            None,
            Center
        }

        protected const int GridSize = 10;

        virtual public HitTestState HitTest(int x, int y)
        {
            return HitTestState.None;
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set { _isSelected = value; }
        }

        protected string _id;
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }

        protected string _value;
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        virtual public Rectangle GetRange()
        {
            return new Rectangle();
        }

        virtual public void AlignToGrid() { }
        protected int AlignToNumber(int number, int alignNumber)
        {
            int newNum = number - (number % alignNumber);
            if ((number - newNum) > (alignNumber / 2))
            {
                return newNum + alignNumber;
            }
            else
            {
                return newNum;
            }
        }

        virtual public void Draw(Graphics g) { }
        virtual public void Move(int offX, int offY) { }
        virtual public void OpenPropertyDialog() { }
        virtual public void RangeSelect(Rectangle rect) { }
    }
}
