using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Zxl.Workflow
{
    public class Activity
    {
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

        protected string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        virtual public Rectangle GetRange()
        {
            return new Rectangle();
        }


        virtual public void Draw(Graphics g) { }
        virtual public void Move(int offX, int offY) { }
        virtual public void OpenPropertyDialog() { }
        virtual public void RangeSelect(Rectangle rect) { }
    }
}
