using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zxl.Data;

namespace Zxl.Website.Model
{
    [Table]
    public class SYS_PROJECTWORKITEM : AbstractModel
    {
        public SYS_PROJECTWORKITEM() { }

        [Field(PrimaryKey = true)]
        public int ID { get; set; }
        [Field]
        public int REF_PROJECT_ID { get; set; }
        [Field]
        public int REF_PROJECTACTIVITY_ID { get; set; }
        [Field]
        public int REF_USER_ID { get; set; }
        [Field]
        public DateTime STARTTIME { get; set; }
        [Field]
        public DateTime ENDTIME { get; set; }
        [Field]
        public int STATE { get; set; }

    }
}
