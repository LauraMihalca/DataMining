using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMeans
{
    class Item : ICloneable
    {
        private bool m_IsUser;
        private bool m_Exists;
        private string m_ItemText;
        private double m_Distance;
        private IAttribList m_AttribList = null;
        public Item(string item_text, IAttribList attributes,
            double distance, bool is_user, bool exists)
        {
            if (AttribList == null)
                AttribList = (IAttribList)attributes;

            IsUser = is_user; Exists = exists;
            ItemText = item_text; Distance = distance;
        }
        public IAttribList GetAttribList()
        {
            return m_AttribList;
        }

        public object Clone()
        {
            Item TargetItem = (Item)this.MemberwiseClone();
            IAttribList TargetAttribList = new IAttribList();
            foreach (Attrib attrib in this.AttribList)
                TargetAttribList.Add(attrib);

            if (TargetAttribList.Count() > 0)
                TargetItem.AttribList = (IAttribList)TargetAttribList.Clone();

            TargetItem.IsUser = this.IsUser; TargetItem.Exists = this.Exists;
            TargetItem.ItemText = this.ItemText; TargetItem.Distance = this.Distance;

            return TargetItem;
        }

        private double Relevance(string attrib1, string attrib2)
        {
            double nRelevance = 0;
            // Assigning the nLength variable the value of the smallest string length
            int nLength = attrib1.Length < attrib2.Length ? attrib1.Length : attrib2.Length;
            // Iterating through the two strings of character, comparing the pairs of items
            // from either attrib1 and attrib2. If the two characters are lexicographically equal
            // we're adding the value 1 / nLength to the nRelevance variable
            for (int iIndex = 0; iIndex < nLength; iIndex++)
                nRelevance += (attrib1[iIndex] == attrib2[iIndex]) ? (double)1 / nLength : 0;

            return nRelevance;
        }
        public double EuclDW(Item item)
        {
            int nCount = 0;
            int iIndex = 0; double nDistance = 0;
            // Iterating through the array of attributes and for each pair of either users or items
            // attributes computing the distance between those attributes. Then, each distance values
            // is added to the nDistance variable. During the computation we're also obtaining the
            // value of releavance between the lexicographical representations of those attributes
            while (iIndex < item.AttribList.Count() && iIndex < AttribList.Count())
            {
                // Compute the relevance between names of the pair of attributes
                double nRel = Relevance(item.AttribList[iIndex].Name, AttribList[iIndex].Name);
                if (nRel == 1) nCount++;

                // Computing the Eucledean distance between the pair of current attributes
                nDistance += Math.Pow(item.AttribList[iIndex].Value - AttribList[iIndex].Value, 2.0) *
                    ((double)((nRel > 0) ? nRel : 1));

                iIndex++;
            }

            // Returning the value of the distance between two vectors of attributes
            return Math.Sqrt(nDistance) * ((double)1 / ((nCount > 0) ? nCount : 0.01));
        }

        public string ItemText
        {
            get { return m_ItemText; }
            set { m_ItemText = value; }
        }
        public double Distance
        {
            get { return m_Distance; }
            set { m_Distance = value; }
        }
        public bool IsUser
        {
            get { return m_IsUser; }
            set { m_IsUser = value; }
        }
        public bool Exists
        {
            get { return m_Exists; }
            set { m_Exists = value; }
        }
        public IAttribList AttribList
        {
            get { return m_AttribList; }
            set { m_AttribList = value; }
        }
    }
}
