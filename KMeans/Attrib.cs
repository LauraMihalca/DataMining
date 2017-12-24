using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMeans
{
    class Attrib : ICloneable
    {
        private string m_Name;
        private double m_Value;
        public Attrib(string name, double value)
        {
            Name = name; Value = value;
        }
        public object Clone()
        {
            Attrib TargetAttrib = (Attrib)this.MemberwiseClone();
            TargetAttrib.Name = Name; TargetAttrib.Value = Value;
            return TargetAttrib;
        }
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
        public double Value
        {
            get { return m_Value; }
            set { m_Value = value; }
        }
    }
}
