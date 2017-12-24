using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMeans
{
    class IAttribList : ICloneable, IEnumerable<Attrib>
    {
        private List<Attrib> m_AttribList = null;
        public IAttribList()
        {
            if (m_AttribList == null)
                m_AttribList = new List<Attrib>();
        }
        public void Add(Attrib attrib_item)
        {
            m_AttribList.Add((Attrib)attrib_item.Clone());
        }
        public object Clone()
        {
            IAttribList TargetAttribList = new IAttribList();
            foreach (Attrib attrib in m_AttribList)
                TargetAttribList.Add(attrib);

            return TargetAttribList.Count() > 0 ?
               (IAttribList)TargetAttribList.Clone() : null;
        }
        public Attrib this[int iIndex]
        {
            get { return m_AttribList[iIndex]; }
            set { m_AttribList[iIndex] = value; }
        }
        public int Count() { return m_AttribList.Count(); }
        public IEnumerator GetEnumerator()
        {
            return m_AttribList.GetEnumerator();
        }
        IEnumerator<Attrib> IEnumerable<Attrib>.GetEnumerator()
        {
            return (IEnumerator<Attrib>)this.GetEnumerator();
        }
    }
}
