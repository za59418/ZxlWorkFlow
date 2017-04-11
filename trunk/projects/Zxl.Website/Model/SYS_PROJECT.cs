using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zxl.Data;

namespace Zxl.WebSite.Model
{
    [Table]
    public class SYS_PROJECT : AbstractModel
    {
        public SYS_PROJECT() { }

        [Field(PrimaryKey = true)]
        public int ID { get; set; }
        [Field]
        public string PROJECTNO { get; set; }
        [Field]
        public string PROJECTNAME { get; set; }
        [Field]
        public string BUILDADRESS { get; set; }
        [Field]
        public DateTime CREATETIME { get; set; }
        [Field]
        public DateTime ENDTIME { get; set; }
        [Field]
        public int ISDELETE { get; set; }
        [Field]
        public int REF_BUSINESS_ID { get; set; }
        [Field]
        public int PID { get; set; }

    }
}
