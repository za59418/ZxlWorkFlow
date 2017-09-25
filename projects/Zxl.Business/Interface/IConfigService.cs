using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zxl.Business.Model;

namespace Zxl.Business.Interface
{
    public interface IConfigService
    {
        List<SYS_SYSTEMCONFIG> Configs();
        int DelConfig(int ConfigId);
        SYS_SYSTEMCONFIG SaveConfig(SYS_SYSTEMCONFIG config);
        SYS_SYSTEMCONFIG GetConfig(int ConfigId);
    }
}
