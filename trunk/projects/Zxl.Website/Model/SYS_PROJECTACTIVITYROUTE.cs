using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zxl.Data;

namespace Zxl.Website.Model
{
    [Table]
    public class SYS_PROJECTACTIVITYROUTE : AbstractModel
    {
        public SYS_PROJECTACTIVITYROUTE() { }

        [Field(PrimaryKey = true)]
        public int ID { get; set; }
        [Field]
        public int REF_FROM_PROACT_ID { get; set; }
        [Field]
        public int REF_TO_PROACT_ID { get; set; }
        [Field]
        public int ROUTETYPE { get; set; }
    }

    public enum PROJECTACTIVITYROUTE
    {
        SEND=0,
        BACK=1
    }
}
