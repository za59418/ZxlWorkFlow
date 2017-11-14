using System;
using System.Collections.Generic;
using System.Text;

namespace FormDesigner.Attribute
{
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
