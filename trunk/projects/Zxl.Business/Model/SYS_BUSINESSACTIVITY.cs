using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zxl.Data;

namespace Zxl.Business.Model
{
    [Table]
    public class SYS_BUSINESSACTIVITY : AbstractModel
    {
        public SYS_BUSINESSACTIVITY() { }

        [Field(PrimaryKey = true)]
        public int ID { get; set; }
        [Field]
        public string ACTIVITYNAME { get; set; }
        [Field]
        public int REF_BUSINESS_ID { get; set; }
        [Field]
        public int REF_BUSINESSPROCESS_ID { get; set; }
        [Field]
        public int REF_BUSINESSROLE_ID { get; set; }
    }
}
