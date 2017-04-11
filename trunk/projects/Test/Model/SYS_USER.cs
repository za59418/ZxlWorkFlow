using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DCIIDS.Data;

namespace Test.Model
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
        public string PASSWORD { get; set; }
        [Field]
        public DateTime CREATETIME { get; set; }
        [Field]
        public int STATE { get; set; }
    }
}
