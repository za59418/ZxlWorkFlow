using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using WeifenLuo.WinFormsUI.Docking;

namespace FormDesigner
{
    public class DockWindowFactory
    {
        private static DockWindowFactory _instance;
        private DockWindowCollection _dockWindowCollection = new DockWindowCollection();


        public static DockWindowFactory Instance
        {
            get
            {
                if (null == _instance)
                    _instance = new DockWindowFactory();
                return _instance;
            }
        }

        public DockContent CurrDockWindow { get; set; }

        public DockWindowCollection DockWindowCollection
        {
            get
            {
                return _dockWindowCollection;
            }
        }
    }

    [Serializable()]
    public class DockWindowCollection : CollectionBase
    {
        public DockWindowCollection() { }

        public DockWindowCollection(DockWindowCollection value)
        {
			this.AddRange(value);
		}

        public DockWindowCollection(DockContent[] value)
        {
			this.AddRange(value);
		}

        public DockContent this[int index]
        {
            get
            {
                return ((DockContent)(List[index]));
            }
            set
            {
                List[index] = value;
            }
        }

        //***********key********//

        public int Add(DockContent value)
        {
            return List.Add(value);
        }

        public void AddRange(DockContent[] value)
        {
            for (int i = 0; (i < value.Length); i = (i + 1))
            {
                this.Add(value[i]);
            }
        }

        public void AddRange(DockWindowCollection value)
        {
            for (int i = 0; (i < value.Count); i = (i + 1))
            {
                this.Add(value[i]);
            }
        }

        public bool Contains(DockContent value)
        {
            return List.Contains(value);
        }

        public void CopyTo(DockContent[] array, int index)
        {
            List.CopyTo(array, index);
        }

        public int IndexOf(DockContent value)
        {
            return List.IndexOf(value);
        }

        public void Insert(int index, DockContent value)
        {
            List.Insert(index, value);
        }

        //************IEnumerator*********//

        public void Remove(DockContent value)
        {
            List.Remove(value);
        }
    }
}
