using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zxl.Data;

namespace Zxl.WebSite.Model
{
    [Table]
    public class SYS_BUSINESS : AbstractModel
    {
        public SYS_BUSINESS() { }

        [Field(PrimaryKey = true)]
        public int ID { get; set; }
        [Field]
        public string BUSINESSNAME { get; set; }
        [Field]
        public string SHORTNAME { get; set; }
        [Field]
        public DateTime CREATETIME { get; set; }
        [Field]
        public string DESCRIPTION { get; set; }
    }
}
