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
    public class ConfigService : IConfigService
    {
        #region 配置
        public List<SYS_SYSTEMCONFIG> Configs()
        {
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                return orm.Query<SYS_SYSTEMCONFIG>();
            }
        }
        public int DelConfig(int ConfigId)
        {
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                return orm.Delete<SYS_SYSTEMCONFIG>("where ID=" + ConfigId);
            }
        }
        public SYS_SYSTEMCONFIG SaveConfig(SYS_SYSTEMCONFIG config)
        {
            if (0 == config.ID)
            {
                config.ID = ValueOperator.CreatePk("SYS_SYSTEMCONFIG");
            }
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                orm.Save(config);
                return config;
            }
        }
        public SYS_SYSTEMCONFIG GetConfig(int ConfigId)
        {
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                return orm.Init<SYS_SYSTEMCONFIG>("where ID=" + ConfigId);
            }
        }
        #endregion 配置

    }
}
