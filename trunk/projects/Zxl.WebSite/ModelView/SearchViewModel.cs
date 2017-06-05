using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Zxl.WebSite.ModelView
{
    public class SearchViewModel
    {
        [Display(Name = "项目编号")]
        public string PROJECTNO { get; set; }

        [Display(Name = "项目名称")]
        public string PROJECTNAME { get; set; }

        [Display(Name = "建设单位")]
        public string BUILDORG { get; set; }

        [Display(Name = "建设地址")]
        public string BUILDADRESS { get; set; }

        [Display(Name = "创建开始时间")]
        public string CREATETIMESTART { get; set; }

        [Display(Name = "创建结束时间")]
        public string CREATETIMEEND { get; set; }

        [Display(Name = "办结开始时间")]
        public string ENDTIMESTART { get; set; }

        [Display(Name = "办结结束时间")]
        public string ENDTIMEEND { get; set; }
    }
}