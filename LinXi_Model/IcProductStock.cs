using System;
using System.Collections.Generic;

namespace LinXi_Model
{
    public partial class IcProductStock
    {
        public int Id { get; set; }
        public int? WarehouseId { get; set; }
        public int? ProductId { get; set; }
        public decimal? Stock { get; set; }
        public string Remark { get; set; }

        public virtual PrProduct Product { get; set; }
        public virtual IcWarehouse Warehouse { get; set; }
    }
}
