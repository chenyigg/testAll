using System;
using System.Collections.Generic;

namespace LinXi_Model
{
    public partial class SlOrder
    {
        public SlOrder()
        {
            SlReject = new HashSet<SlReject>();
            SlSaleOrder = new HashSet<SlSaleOrder>();
        }

        public int Id { get; set; }
        public string No { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public decimal Nums { get; set; }
        public decimal? Price { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string DeliveryWay { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? OrderAmount { get; set; }
        public int? HandleId { get; set; }
        public int? OperatorId { get; set; }
        public DateTime? OperatorTime { get; set; }
        public int? Status { get; set; }
        public string Remark { get; set; }

        public virtual SlCustomer Customer { get; set; }
        public virtual AcStaff Handle { get; set; }
        public virtual AcStaff Operator { get; set; }
        public virtual PrProduct Product { get; set; }
        public virtual ICollection<SlReject> SlReject { get; set; }
        public virtual ICollection<SlSaleOrder> SlSaleOrder { get; set; }
    }
}
