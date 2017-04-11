using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zxl.Data;

namespace Zxl.WebSite.Model
{
    [Table]
    public class SYS_BUSINESSROLEUSER : AbstractModel
    {
        public SYS_BUSINESSROLEUSER() { }

        [Field(PrimaryKey = true)]
        public int ID { get; set; }
        [Field]
        public int REF_USER_ID { get; set; }
        [Field]
        public int REF_BUSINESSROLE_ID { get; set; }
    }
}
