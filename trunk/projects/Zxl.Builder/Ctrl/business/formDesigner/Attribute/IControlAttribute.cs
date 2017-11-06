using System;
using System.Collections.Generic;
using System.Text;

namespace FormDesigner.Attribute
{
    /// <summary>
    /// 目  的：控件属性接口
    /// 创建人：weiwy
    /// 创建日期：2008-02-22
    /// </summary>
    public interface IControlAttribute
    {
        string ControlId
        {
            get;
        }
    }
}
