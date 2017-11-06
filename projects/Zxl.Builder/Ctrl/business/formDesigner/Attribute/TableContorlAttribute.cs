using System;
using System.Collections.Generic;
using System.Text;

namespace FormDesigner.Attribute
{
    public class TableContorlAttribute : GeneralAttribute
    {
        private Dictionary<string,Group> dicGroup=new Dictionary<string,Group>();

        public Dictionary<string, Group> Groups
        {
            get { return dicGroup; }
        }

        public void AddGroup(string name, Group group)
        {
            if (!dicGroup.ContainsKey(name))
            {
                dicGroup.Add(name, group);
            }
        }
    }

    public class Group
    {
        private string name;
        private Dictionary<string, GeneralAttribute> groupControls=new Dictionary<string,GeneralAttribute>();

        public string Name 
        {
            get { return name; }
            set { name = value; }
        }
        public Dictionary<string, GeneralAttribute> GroupControls
        {
            get { return groupControls; }
        }

        public void AddGroupControl(string id,GeneralAttribute generalAttribute)
        {
            if (!groupControls.ContainsKey(id))
            {
                groupControls.Add(id, generalAttribute);
            }
        }
    }
}
