using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zxl.Business.Model;

namespace Zxl.Business.Interface
{
    public interface IBusinessService
    {
        List<SYS_PROJECT> Projectsing(string UserId);
        List<SYS_METADATA> MetaDatas();
    }
}
