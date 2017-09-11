using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zxl.Business.Model;

namespace Zxl.Business.Interface
{
    public interface IMessageService
    {
        List<SYS_MESSAGE> GetNoReadMsgs(string UserId);
        List<SYS_MESSAGE> GetReadMsgs(string UserId);
        List<SYS_MESSAGE> ReadMsg(string MsgId);
    }
}
