using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zxl.Data;

namespace Zxl.Business.Model
{
    [Table]
    public class SYS_MESSAGE : AbstractModel
    {
        public SYS_MESSAGE() { }

        [Field(PrimaryKey = true)]
        public int ID { get; set; }
        [Field]
        public int TYPE { get; set; }
        [Field]
        public int REF_PROJECT_ID { get; set; }
        public string PROJECTNAME { get; set; }

        [Field]
        public string INSPARAMS { get; set; }
        [Field]
        public int SENDUSERID { get; set; }

        public string SENDUSERNAME { get; set; }
        public string SENDUSERIMG { get; set; }

        [Field]
        public DateTime SENDDATE { get; set; }
        [Field]
        public int RECVUSERID { get; set; }

        public string RECVUSERNAME { get; set; }

        [Field]
        public DateTime RECVDATE { get; set; }
        [Field]
        public int RECVSTATE { get; set; }
        [Field]
        public int SHOWRECV { get; set; }
        [Field]
        public string CONTENT { get; set; }
        [Field]
        public int STATE { get; set; }

    }
}
