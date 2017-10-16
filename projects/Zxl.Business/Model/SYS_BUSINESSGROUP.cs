using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zxl.Data;

namespace Zxl.Business.Model
{
    [Table]
    public class SYS_BUSINESSGROUP : AbstractModel
    {
        public SYS_BUSINESSGROUP() { }

        [Field(PrimaryKey = true)]
        public int ID { get; set; }
        [Field]
        public string GROUPNAME { get; set; }
        [Field]
        public string DESCRIPTION { get; set; }
        [Field]
        public int SORTINDEX { get; set; }
    }
}
