using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zxl.Data;

namespace Zxl.WebSite.Model
{
    [Table]
    public class SYS_PROJECTMATERIAL : AbstractModel
    {
        public SYS_PROJECTMATERIAL() { }

        [Field(PrimaryKey = true)]
        public int ID { get; set; }
        [Field]
        public string MATERIALNAME { get; set; }
        [Field]
        public int REF_BUSINESSMATERIAL_ID { get; set; }
        [Field]
        public int REF_PROJECT_ID { get; set; }
        [Field]
        public string FILEPATH { get; set; }
        [Field]
        public string FILESIZE { get; set; }
        [Field]
        public DateTime CREATETIME { get; set; }
        [Field]
        public int CREATEUSER { get; set; }
        [Field]
        public string DESCRIPTION { get; set; }

    }
}
