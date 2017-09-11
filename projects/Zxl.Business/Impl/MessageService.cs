using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zxl.Business.Interface;
using Zxl.Business.Model;
using Zxl.Data;

namespace Zxl.Business.Impl
{
    public class MessageService : IMessageService
    {
        public List<SYS_MESSAGE> GetNoReadMsgs(string UserId)
        {
            List<SYS_MESSAGE> result = null;

            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                result = orm.Query<SYS_MESSAGE>("where STATE=0 and RECVUSERID='" + UserId + "'");
                foreach(SYS_MESSAGE msg in result)
                {
                    SYS_USER sendUser = orm.Init<SYS_USER>("where ID=" + msg.SENDUSERID);
                    msg.SENDUSERNAME = sendUser.USERNAME;
                    msg.SENDUSERIMG = sendUser.USERIMG;
                    msg.PROJECTNAME = orm.Init<SYS_PROJECT>("where ID=" + msg.REF_PROJECT_ID).PROJECTNAME;
                    msg.RECVUSERNAME = orm.Init<SYS_USER>("where ID=" + msg.RECVUSERID).USERNAME;
                }
            }
            return result;
        }
        public List<SYS_MESSAGE> GetReadMsgs(string UserId)
        {
            List<SYS_MESSAGE> result = null;

            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                result = orm.Query<SYS_MESSAGE>("where STATE=1 and RECVUSERID='" + UserId + "'");
                foreach (SYS_MESSAGE msg in result)
                {
                    SYS_USER sendUser = orm.Init<SYS_USER>("where ID=" + msg.SENDUSERID);
                    msg.SENDUSERNAME = sendUser.USERNAME;
                    msg.SENDUSERIMG = sendUser.USERIMG;
                    msg.PROJECTNAME = orm.Init<SYS_PROJECT>("where ID=" + msg.REF_PROJECT_ID).PROJECTNAME;
                    msg.RECVUSERNAME = orm.Init<SYS_USER>("where ID=" + msg.RECVUSERID).USERNAME;
                }
            }
            return result;
        }
        public List<SYS_MESSAGE> ReadMsg(string MsgId)
        {
            SYS_MESSAGE msg = null;

            List<SYS_MESSAGE> result = null;
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                msg = orm.Init<SYS_MESSAGE>("where ID=" + MsgId);
                msg.STATE = 1;
                orm.Save(msg);

                result = GetNoReadMsgs(msg.RECVUSERID + "");
            }
            return result;
        }

    }
}
