using System;
using System.Collections.Generic;

namespace LinXi_Model
{
    public partial class PrProductMaterial
    {
        public int Id { get; set; }
        public int? TaskId { get; set; }
        public int? CommodityId { get; set; }
        public int? Nums { get; set; }
        public string Uses { get; set; }
        public int? DepartmentId { get; set; }
        public int? StaffId { get; set; }
        public decimal? ReceiptDate { get; set; }
        public int? OperatorId { get; set; }
        public DateTime? OperateTime { get; set; }
        public int? Status { get; set; }
        public string Remark { get; set; }

        public virtual PuCommodity Commodity { get; set; }
        public virtual AcDepartment Department { get; set; }
        public virtual AcStaff Operator { get; set; }
        public virtual AcStaff Staff { get; set; }
        public virtual PrProductTask StatusNavigation { get; set; }
    }
}
