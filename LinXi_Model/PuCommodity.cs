using System;
using System.Collections.Generic;

namespace LinXi_Model
{
    public partial class PuCommodity
    {
        public PuCommodity()
        {
            IcCommodityRecord = new HashSet<IcCommodityRecord>();
            IcCommodityStock = new HashSet<IcCommodityStock>();
            PrProductMaterial = new HashSet<PrProductMaterial>();
            PuOrder = new HashSet<PuOrder>();
        }

        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public int? SupplierId { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public decimal? Stock { get; set; }
        public string Place { get; set; }
        public string Spec { get; set; }
        public string LicenseNo { get; set; }
        public int? OperatorId { get; set; }
        public DateTime? OperateTime { get; set; }
        public string Remark { get; set; }

        public virtual PuCommodityCategory Category { get; set; }
        public virtual AcStaff Operator { get; set; }
        public virtual PuSupplier Supplier { get; set; }
        public virtual ICollection<IcCommodityRecord> IcCommodityRecord { get; set; }
        public virtual ICollection<IcCommodityStock> IcCommodityStock { get; set; }
        public virtual ICollection<PrProductMaterial> PrProductMaterial { get; set; }
        public virtual ICollection<PuOrder> PuOrder { get; set; }
    }
}
