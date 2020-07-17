using System;
using System.Collections.Generic;

namespace LinXi_Model
{
    public partial class PuSupplier
    {
        public PuSupplier()
        {
            PuCommodity = new HashSet<PuCommodity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Postcode { get; set; }
        public string Address { get; set; }
        public string Linkman { get; set; }
        public string Tel { get; set; }
        public string Qq { get; set; }
        public string Weixin { get; set; }
        public string Email { get; set; }
        public string Credit { get; set; }
        public string Remark { get; set; }
        public int? OperatorId { get; set; }
        public DateTime? OperateTime { get; set; }

        public virtual AcStaff Operator { get; set; }
        public virtual ICollection<PuCommodity> PuCommodity { get; set; }
    }
}
