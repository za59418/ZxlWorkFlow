using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zxl.Data;

namespace Zxl.Business.Model
{
    [Table]
    public class SYS_USER : AbstractModel
    {
        public SYS_USER() { }

        [Field(PrimaryKey = true)]
        public int ID { get; set; }
        [Field]
        public string USERNAME { get; set; }
        [Field]
        public string NICKNAME { get; set; }
        [Field]
        public string USERIMG { get; set; }
        [Field]
        public string DEPARTMENT { get; set; }
        [Field]
        public string ROLE { get; set; }
        [Field]
        public string MOBILE { get; set; }
        [Field]
        public string PHONE { get; set; }
        [Field]
        public string EMAIL { get; set; }
        [Field]
        public string PASSWORD { get; set; }
        [Field]
        public DateTime CREATETIME { get; set; }
        [Field]
        public int STATE { get; set; }
    }
}
