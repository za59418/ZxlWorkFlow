using System;
using System.Collections.Generic;
using System.Text;

namespace FormDesigner.Attribute
{
    /// <summary>
    /// Ŀ  �ģ����ݰ�����
    /// �����ˣ�weiwy
    /// �������ڣ�2008-02-22
    /// </summary>
    public class DataBindAttribute : IControlAttribute
    {
        protected string id=string.Empty;

        public string ControlId
        {
            get
            {
                return id;
            }
        }
    }
}
