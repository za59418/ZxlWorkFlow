using System;
using System.Collections.Generic;
using System.Text;

namespace FormDesigner.Common
{
    public class PageProperty
    {
        private static bool _isPrint = true;
        public static bool IsPrint
        {
            get { return _isPrint; }
            set { _isPrint = value; }
        }
    }
}
