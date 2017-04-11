using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DCIIDS.Data;

namespace Test.Model
{
    [Table]
    public class SYS_BUSINESSMATERIAL : AbstractModel
    {

        public SYS_BUSINESSMATERIAL() { }

        [Field(PrimaryKey = true)]
        public int ID { get; set; }
        [Field]
        public string MATERIALNAME { get; set; }
        [Field]
        public int REF_BUSINESS_ID { get; set; }
        [Field]
        public DateTime CREATETIME { get; set; }
        [Field]
        public string DESCRIPTION { get; set; }

    }
}
