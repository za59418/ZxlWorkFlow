using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zxl.Data;

namespace Zxl.Business.Model
{
    [Table]
    public class SYS_PROJECTPROCESS : AbstractModel
    {
        public SYS_PROJECTPROCESS() { }

        [Field(PrimaryKey = true)]
        public int ID { get; set; }
        [Field]
        public int REF_BUSINESSPROCESS_ID { get; set; }
        [Field]
        public int REF_USER_ID { get; set; }
        [Field]
        public DateTime CREATETIME { get; set; }
        [Field]
        public int REF_PROJECT_ID { get; set; }

    }
}
