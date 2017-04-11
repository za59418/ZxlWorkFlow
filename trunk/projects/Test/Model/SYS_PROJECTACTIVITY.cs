using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DCIIDS.Data;

namespace Test.Model
{
    [Table]
    public class SYS_PROJECTACTIVITY : AbstractModel
    {
        public SYS_PROJECTACTIVITY() { }

        [Field(PrimaryKey = true)]
        public int ID { get; set; }
        [Field]
        public int REF_PROJECTPROCESS_ID { get; set; }
        [Field]
        public int REF_BUSINESSACTIVITY_ID { get; set; }
        [Field]
        public int REF_USER_ID { get; set; }
        [Field]
        public DateTime STARTTIME { get; set; }
        [Field]
        public DateTime ENDTIME { get; set; }
        [Field]
        public int REF_PROJECT_ID { get; set; }
        [Field]
        public int STATE { get; set; }

    }
}
