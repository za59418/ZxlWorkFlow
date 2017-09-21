using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zxl.Data;

namespace Zxl.Business.Model
{
    [Table]
    public class SYS_BUSINESSDATA : AbstractModel
    {
        public SYS_BUSINESSDATA() { }

        [Field(PrimaryKey = true)]
        public int ID { get; set; }
        [Field]
        public string NAME { get; set; }
        [Field]
        public string DESCRIPTION { get; set; }
    }
}
