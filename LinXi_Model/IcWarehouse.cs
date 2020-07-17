using System;
using System.Collections.Generic;

namespace LinXi_Model
{
    public partial class IcWarehouse
    {
        public IcWarehouse()
        {
            IcCommodityRecord = new HashSet<IcCommodityRecord>();
            IcCommodityStock = new HashSet<IcCommodityStock>();
            IcProductRecord = new HashSet<IcProductRecord>();
            IcProductStock = new HashSet<IcProductStock>();
        }

        public int Id { get; set; }
        public string No { get; set; }
        public string Name { get; set; }
        public int? Category { get; set; }
        public string Address { get; set; }
        public int? ManagerId { get; set; }
        public int? OperatorId { get; set; }
        public DateTime? OperateTime { get; set; }
        public int? Status { get; set; }
        public string Remark { get; set; }

        public virtual ICollection<IcCommodityRecord> IcCommodityRecord { get; set; }
        public virtual ICollection<IcCommodityStock> IcCommodityStock { get; set; }
        public virtual ICollection<IcProductRecord> IcProductRecord { get; set; }
        public virtual ICollection<IcProductStock> IcProductStock { get; set; }
    }
}
