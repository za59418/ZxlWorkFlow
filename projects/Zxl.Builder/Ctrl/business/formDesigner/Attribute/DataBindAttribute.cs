using System;
using System.Collections.Generic;
using System.Text;

namespace FormDesigner.Attribute
{
    /// <summary>
    /// 目  的：数据绑定属性
    /// 创建人：weiwy
    /// 创建日期：2008-02-22
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
