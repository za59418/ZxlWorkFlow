using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zxl.Data;

namespace Zxl.Business.Model
{
    [Table]
    public class SYS_BUSINESSROLE : AbstractModel
    {
        public SYS_BUSINESSROLE() { }

        [Field(PrimaryKey = true)]
        public int ID { get; set; }
        [Field]
        public string ROLENAME { get; set; }
        [Field]
        public int REF_BUSINESS_ID { get; set; }
        [Field]
        public DateTime CREATETIME { get; set; }
        [Field]
        public int SORTINDEX { get; set; }

        public int Selected { get; set; }
    }
}
