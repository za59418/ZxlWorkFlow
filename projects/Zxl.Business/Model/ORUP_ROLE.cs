using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zxl.Data;

namespace Zxl.Business.Model
{
    [Table]
    public class ORUP_ROLE : AbstractModel
    {
        public ORUP_ROLE() { }

        [Field(PrimaryKey = true)]
        public int ID { get; set; }
        [Field]
        public string ROLENAME { get; set; }
        [Field]
        public int ROLETYPE { get; set; }
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
