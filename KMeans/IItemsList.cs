using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMeans
{
    class IItemsList : ICloneable, IEnumerable<Item>
    {
        private List<Item> m_ItemsList = null;
        public IItemsList()
        {
            if (m_ItemsList == null)
                m_ItemsList = new List<Item>();
        }
        public void Add(Item item)
        {
            m_ItemsList.Add(item);
        }
        public object Clone()
        {
            IItemsList TargetItems = new IItemsList();
            foreach (Item item in m_ItemsList)
            {
                IAttribList TargetAttribList = new IAttribList();
                foreach (Attrib attrib in item.GetAttribList())
                    TargetAttribList.Add(new Attrib(attrib.Name, attrib.Value));

                if (TargetAttribList.Count() > 0)
                    TargetItems.Add(new Item(item.ItemText, TargetAttribList,
                        item.Distance, item.IsUser, item.Exists));
            }

            return TargetItems;
        }
        public Item this[int iIndex]
        {
            get { return m_ItemsList[iIndex]; }
            set { m_ItemsList[iIndex] = value; }
        }
        public int Count() { return m_ItemsList.Count(); }
        public void RemoveAt(int iIndex) { m_ItemsList.RemoveAt(iIndex); }
        public IEnumerator GetEnumerator()
        {
            return m_ItemsList.GetEnumerator();
        }
        IEnumerator<Item> IEnumerable<Item>.GetEnumerator()
        {
            return (IEnumerator<Item>)this.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
