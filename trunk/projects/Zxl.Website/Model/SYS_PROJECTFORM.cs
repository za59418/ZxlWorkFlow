using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zxl.Data;

namespace Zxl.Website.Model
{
    [Table]
    public class SYS_PROJECTFORM : AbstractModel
    {
        public SYS_PROJECTFORM() { }

        [Field(PrimaryKey = true)]
        public int ID { get; set; }
        [Field]
        public string FORMNAME { get; set; }
        [Field]
        public string DESCRIPTION { get; set; }
        [Field]
        public int REF_BUSINESSFORM_ID { get; set; }
        [Field]
        public int REF_PROJECT_ID { get; set; }
        [Field]
        public DateTime CREATETIME { get; set; }
    }
}
