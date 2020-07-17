using System;
using System.Collections.Generic;

namespace LinXi_Model
{
    public partial class PuOrder
    {
        public PuOrder()
        {
            QmCommodity = new HashSet<QmCommodity>();
        }

        public int Id { get; set; }
        public string No { get; set; }
        public int? CommodityId { get; set; }
        public decimal? Nums { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string Batch { get; set; }
        public decimal? Amount { get; set; }
        public int? AmountWay { get; set; }
        public decimal? AmountReceivable { get; set; }
        public decimal? AmountReceived { get; set; }
        public int? HandleId { get; set; }
        public int? OperatorId { get; set; }
        public DateTime? OperateTime { get; set; }
        public int? Status { get; set; }
        public int? QmId { get; set; }
        public string Remark { get; set; }

        public virtual PuCommodity Commodity { get; set; }
        public virtual AcStaff Handle { get; set; }
        public virtual QmCommodity Qm { get; set; }
        public virtual ICollection<QmCommodity> QmCommodity { get; set; }
    }
}
