using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zxl.Data;

namespace Zxl.Business.Model
{
    [Table]
    public class SYS_BUSINESSDATADETAIL : AbstractModel
    {
        public SYS_BUSINESSDATADETAIL() { }

        [Field(PrimaryKey = true)]
        public int ID { get; set; }
        [Field]
        public int REF_METADATA_ID { get; set; }
        [Field]
        public int REF_BUSINESSDATA_ID { get; set; }
        [Field]
        public int PARENTID { get; set; }
    }
}