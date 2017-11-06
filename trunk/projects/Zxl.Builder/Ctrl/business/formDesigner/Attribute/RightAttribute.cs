using System;
using System.Collections.Generic;
using System.Text;

namespace FormDesigner.Attribute
{
    /// <summary>
    /// Ŀ  �ģ��ؼ�Ȩ�ް�����
    /// �����ˣ�weiwy
    /// �������ڣ�2008-02-22
    /// </summary>
    public class RightAttribute : IControlAttribute
    {
        #region Variables
        private string _id;
        private string _right;
        private string _state;
        #endregion

        #region Properties
        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }


        public string Right
        {
            get
            {
                return _right;
            }
            set
            {
                _right = value;
            }
        }

        public string States
        {
            set
            {
                _state = value;
            }
            get
            {
                return _state;
            }
        }

        public string ControlId
        {
            get { return _id; }
        }
        #endregion
    }
}
