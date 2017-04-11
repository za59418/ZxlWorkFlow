using System;
using System.Collections.Generic;
using System.Text;
using DCIIDS.Main;
using Zxl.Data;

namespace Zxl.WebSite.Model
{
	public class AbstractModel
	{
        public int id { get; set; }
        public int pid { get; set; }
        public int _parentId { get; set; }
        public string text { get; set; }
        public string iconCls { get; set; }

        public List<AbstractModel> children { get; set; }


		public void Save()
		{
			using (ORMHandler orm = DatabaseManager.ORMHandler)
			{
				orm.BeginTransaction();
				Save(orm);
				orm.Commit();
				orm.Close();
			}
		}
		public void Delete()
		{
			using (ORMHandler orm = DatabaseManager.ORMHandler)
			{
				orm.BeginTransaction();
				Delete(orm);
				orm.Commit();
				orm.Close();
			}
		}
		public virtual void Save(ORMHandler orm)
		{
			orm.Save(this);
		}
		public virtual void Delete(ORMHandler orm)
		{
			orm.Delete(this);
		}
		
	}
}
