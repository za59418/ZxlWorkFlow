using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zxl.Data;

namespace Zxl.Business.Model
{
    [Table]
    public class SYS_BUSINESSACTIVITYROUTE : AbstractModel
    {
        public SYS_BUSINESSACTIVITYROUTE() { }

        [Field(PrimaryKey = true)]
        public int ID { get; set; }
        [Field]
        public int REF_FROM_BUSINESSACTIVITY_ID { get; set; }
        [Field]
        public int REF_TO_BUSINESSACTIVITY_ID { get; set; }
    }
}
