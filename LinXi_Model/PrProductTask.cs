using System;
using System.Collections.Generic;

namespace LinXi_Model
{
    public partial class PrProductTask
    {
        public PrProductTask()
        {
            PrProductMaterial = new HashSet<PrProductMaterial>();
            QmProduct = new HashSet<QmProduct>();
        }

        public int Id { get; set; }
        public string No { get; set; }
        public int? ProductId { get; set; }
        public decimal? Nums { get; set; }
        public DateTime? ProductDate { get; set; }
        public string Batch { get; set; }
        public int? DepartmentId { get; set; }
        public int? OperatorId { get; set; }
        public DateTime? OperateTime { get; set; }
        public int? Status { get; set; }
        public string Remark { get; set; }
        public int? QmId { get; set; }

        public virtual AcStaff Operator { get; set; }
        public virtual AcDepartment Product { get; set; }
        public virtual PrProduct ProductNavigation { get; set; }
        public virtual QmProduct Qm { get; set; }
        public virtual ICollection<PrProductMaterial> PrProductMaterial { get; set; }
        public virtual ICollection<QmProduct> QmProduct { get; set; }
    }
}
