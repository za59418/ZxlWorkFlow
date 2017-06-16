using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zxl.Data;

namespace Zxl.Business.Model
{
    [Table]
    public class SYS_ARCHIVE : AbstractModel
    {
        public SYS_ARCHIVE() { }

        [Field(PrimaryKey = true)]
        public int ID { get; set; }
        [Field]
        public int REF_PROJECT_ID { get; set; }
        [Field]
        public string PROJECTNO { get; set; }
        [Field]
        public string PROJECTNAME { get; set; }
        [Field]
        public string BUILDORG { get; set; }
        [Field]
        public string BUILDADRESS { get; set; }
        [Field]
        public string ARCHIVENO { get; set; }
        [Field]
        public DateTime ARCHIVETIME { get; set; }
    }
}
