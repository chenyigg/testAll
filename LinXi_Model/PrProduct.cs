using System;
using System.Collections.Generic;

namespace LinXi_Model
{
    public partial class PrProduct
    {
        public PrProduct()
        {
            IcProductRecord = new HashSet<IcProductRecord>();
            IcProductStock = new HashSet<IcProductStock>();
            PrProductTask = new HashSet<PrProductTask>();
            SlOrder = new HashSet<SlOrder>();
            SlReject = new HashSet<SlReject>();
            SlSaleOrder = new HashSet<SlSaleOrder>();
        }

        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public string BarCode { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public decimal? Stock { get; set; }
        public string LicenseNo { get; set; }
        public string Spec { get; set; }
        public string Unit { get; set; }
        public string Place { get; set; }
        public string Manufacturer { get; set; }
        public int? OperatorId { get; set; }
        public DateTime? OperatorTime { get; set; }
        public string Remark { get; set; }

        public virtual PrProductCategory Category { get; set; }
        public virtual ICollection<IcProductRecord> IcProductRecord { get; set; }
        public virtual ICollection<IcProductStock> IcProductStock { get; set; }
        public virtual ICollection<PrProductTask> PrProductTask { get; set; }
        public virtual ICollection<SlOrder> SlOrder { get; set; }
        public virtual ICollection<SlReject> SlReject { get; set; }
        public virtual ICollection<SlSaleOrder> SlSaleOrder { get; set; }
    }
}
