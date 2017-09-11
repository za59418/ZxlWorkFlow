using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zxl.Data;

namespace Zxl.Business.Model
{
    [Table]
    public class SYS_METADATA : AbstractModel
    {
        public SYS_METADATA() { }

        [Field(PrimaryKey = true)]
        public int ID { get; set; }
        [Field]
        public string NAME { get; set; }
        [Field]
        public string DESCRIPTION { get; set; }
        [Field]
        public string LAYOUT { get; set; }
    }
}
