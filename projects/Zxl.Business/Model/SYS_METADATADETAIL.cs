using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zxl.Data;

namespace Zxl.Business.Model
{
    [Table]
    public class SYS_METADATADETAIL : AbstractModel
    {
        public SYS_METADATADETAIL() { }

        [Field(PrimaryKey = true)]
        public int ID { get; set; }
        [Field]
        public int REF_METADATA_ID { get; set; }
        [Field]
        public string NAME { get; set; }
        [Field]
        public string DESCRIPTION { get; set; }
        [Field]
        public string DATATYPE { get; set; }
        [Field]
        public int LENGTH { get; set; }
        [Field]
        public int NULLABLE { get; set; }
        [Field]
        public string DEFAULTVAL { get; set; }
    }
}