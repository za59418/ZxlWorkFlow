using System;
using System.Collections.Generic;
using System.Text;

namespace FormDesigner.Common
{
    public class ControlDictionary : Dictionary<int, string>
    {
        public string GetValue(int key)
        {
            string value=string.Empty;
            if (TryGetValue(key, out value))
            {
                return value;
            }
            else { return null; }
        }

        public void AddValue(int key,string value)
        {
            //if (value.Trim().Length != 0)
            //{
                if (!ContainsKey(key))
                {
                    Add(key, value);
                }
                //else
                //{
                //    throw new Exception("���д�����ͬIDΪ"+key.ToString()+"�ֶ�");
                //}
            //}
            //else
            //{
            //    throw new Exception("����IDΪ"+key+"���ֶ�����Ϊ��");
            //}
            
        }

        public void RemoveValue(int key)
        {
            Remove(key);
        }

        public string GetName(int id)
        {
            string name=string.Empty;
            this.TryGetValue(id, out name);
            return name;

        }

        public void SetValue(int key, string Value)
        {
            if (ContainsKey(key))
            { RemoveValue(key); }
            AddValue(key, Value);
        }

        public bool ValueInDictionary(int key, string value)
        {
            bool valueInDictionary = false;
            foreach (KeyValuePair<int,string> var in this)
            {
                if (key != var.Key)
                {
                    if (var.Value == value)
                    {
                        valueInDictionary = true;
                        break;
                    }
                }
            }
            return valueInDictionary;
        }
    }
}
