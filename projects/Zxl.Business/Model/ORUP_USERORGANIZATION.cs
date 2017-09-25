using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zxl.Data;

namespace Zxl.Business.Model
{
    [Table]
    public class ORUP_USERORGANIZATION : AbstractModel
    {
        public ORUP_USERORGANIZATION() { }

        [Field(PrimaryKey = true)]
        public int ID { get; set; }
        [Field]
        public int USERID { get; set; }
        [Field]
        public int ORGANIZATIONID{ get; set; }
    }
}
