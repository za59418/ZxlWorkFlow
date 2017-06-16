using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zxl.Data;

namespace Zxl.Business.Model
{
    [Table]
    public class SYS_BUSINESSPROCESS : AbstractModel
    {
        public SYS_BUSINESSPROCESS() { }

        [Field(PrimaryKey = true)]
        public int ID { get; set; }
        [Field]
        public string PROCESSNAME { get; set; }
        [Field]
        public int REF_BUSINESS_ID { get; set; }
        [Field]
        public DateTime CREATETIME { get; set; }
    }
}
