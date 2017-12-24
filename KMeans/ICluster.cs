using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMeans
{
    class ICluster : ICloneable
    {
        private IItemsList m_Items;
        private IItemsList m_Centroids;
        public ICluster(IItemsList cnts_list, IItemsList items_list)
        {
            Items = (IItemsList)items_list;
            Centroids = (IItemsList)cnts_list;
        }
        public object Clone()
        {
            IItemsList TargetItemsList = new IItemsList();
            IItemsList TargetCentroidsList = new IItemsList();
            ICluster TargetCluster = (ICluster)this.MemberwiseClone();

            foreach (Item centroid in Centroids)
                TargetCentroidsList.Add(centroid);

            foreach (Item item in Items)
                TargetItemsList.Add(item);

            TargetCluster.Items = TargetItemsList;
            TargetCluster.Centroids = TargetCentroidsList;

            return TargetCluster;
        }
        public IItemsList Items
        {
            get { return (IItemsList)m_Items; }
            set { m_Items = (IItemsList)value; }
        }
        public IItemsList Centroids
        {
            get { return (IItemsList)m_Centroids; }
            set { m_Centroids = (IItemsList)value; }
        }
    }
}
