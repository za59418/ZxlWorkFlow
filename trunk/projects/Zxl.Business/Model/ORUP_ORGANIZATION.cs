using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zxl.Data;

namespace Zxl.Business.Model
{
    [Table]
    public class ORUP_ORGANIZATION : AbstractModel
    {
        public ORUP_ORGANIZATION() { }

        [Field(PrimaryKey = true)]
        public int ID { get; set; }
        [Field]
        public string ORGNAME { get; set; }
        [Field]
        public int ORGTYPE { get; set; }
        [Field]
        public int PARENT { get; set; }
        [Field]
        public DateTime CREATETIME { get; set; }
        [Field]
        public string DESCRIPTION { get; set; }
        [Field]
        public int STATE { get; set; }
    }
}
