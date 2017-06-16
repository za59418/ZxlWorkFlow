using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zxl.Data;

namespace Zxl.Business.Model
{
    [Table]
    public class SYS_SYSTEMCONFIG : AbstractModel
    {
        public SYS_SYSTEMCONFIG() { }

        [Field(PrimaryKey = true)]
        public int ID { get; set; }
        [Field]
        public string KEY { get; set; }
        [Field]
        public string VALUE { get; set; }
        [Field]
        public string DESCRIPTION { get; set; }
    }
}
