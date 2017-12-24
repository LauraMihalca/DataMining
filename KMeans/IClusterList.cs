using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace KMeans
{
    class IClustersList : ICloneable, IEnumerable<ICluster>
    {
        private List<ICluster> m_ClustersList = null;
        public IClustersList()
        {
            if (m_ClustersList == null)
                m_ClustersList = new List<ICluster>();
        }
        public void Add(ICluster cluster)
        {
            m_ClustersList.Add(cluster);
        }
        public object Clone()
        {
            IClustersList TargetClustersList = new IClustersList();
            foreach (ICluster cluster in m_ClustersList)
            {
                IItemsList TargetCentroidsList = new IItemsList();
                foreach (Item centroid in (IItemsList)cluster.Centroids.Clone())
                {
                    TargetCentroidsList.Add(new Item(centroid.ItemText, (IAttribList)centroid.AttribList.Clone(),
                        centroid.Distance, centroid.IsUser, centroid.Exists));
                }

                IItemsList TargetItemsList = new IItemsList();
                foreach (Item item in (IItemsList)cluster.Items.Clone())
                {
                    TargetItemsList.Add(new Item(item.ItemText, (IAttribList)item.AttribList.Clone(),
                        item.Distance, item.IsUser, item.Exists));
                }

                TargetClustersList.Add(new ICluster((IItemsList)TargetCentroidsList.Clone(),
                    (IItemsList)TargetItemsList.Clone()));
            }

            return TargetClustersList;
        }
        public ICluster this[int iIndex]
        {
            get { return m_ClustersList[iIndex]; }
        }
        public int Count() { return m_ClustersList.Count(); }
        public IEnumerator GetEnumerator()
        {
            return m_ClustersList.GetEnumerator();
        }
        IEnumerator<ICluster> IEnumerable<ICluster>.GetEnumerator()
        {
            return (IEnumerator<ICluster>)this.GetEnumerator();
        }
    }
}
