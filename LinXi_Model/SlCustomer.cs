using System;
using System.Collections.Generic;

namespace LinXi_Model
{
    public partial class SlCustomer
    {
        public SlCustomer()
        {
            SlOrder = new HashSet<SlOrder>();
            SlReject = new HashSet<SlReject>();
            SlSaleOrder = new HashSet<SlSaleOrder>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Postcode { get; set; }
        public string Address { get; set; }
        public string Custtel { get; set; }
        public string Linkman { get; set; }
        public string Linktel { get; set; }
        public string Email { get; set; }
        public sbyte? Sex { get; set; }
        public DateTime? Birthday { get; set; }
        public string Love { get; set; }
        public string Remark { get; set; }

        public virtual ICollection<SlOrder> SlOrder { get; set; }
        public virtual ICollection<SlReject> SlReject { get; set; }
        public virtual ICollection<SlSaleOrder> SlSaleOrder { get; set; }
    }
}
