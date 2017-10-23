using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zxl.Data;

namespace Zxl.Business.Model
{
    [Table]
    public class SYS_BUSINESSFORM : AbstractModel
    {
        public SYS_BUSINESSFORM() { }

        [Field(PrimaryKey = true)]
        public int ID { get; set; }
        [Field]
        public string FORMNAME { get; set; }
        [Field]
        public int REF_BUSINESS_ID { get; set; }
        [Field]
        public byte[] CONTENT { get; set; }
        [Field]
        public DateTime CREATETIME { get; set; }
        [Field]
        public string DESCRIPTION { get; set; }
        [Field]
        public byte[] SHEET { get; set; }
        [Field]
        public int SORTINDEX { get; set; }

        public int Checked { get; set; }
    }
}
