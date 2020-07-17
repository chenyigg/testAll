using System;
using System.Collections.Generic;

namespace LinXi_Model
{
    public partial class QmProduct
    {
        public QmProduct()
        {
            PrProductTask = new HashSet<PrProductTask>();
        }

        public int Id { get; set; }
        public string No { get; set; }
        public int? TaskId { get; set; }
        public DateTime? QmDate { get; set; }
        public int? Result { get; set; }
        public int? HandleId { get; set; }
        public int? OperatorId { get; set; }
        public DateTime? OperateTime { get; set; }
        public string Pic { get; set; }
        public string Remark { get; set; }

        public virtual AcStaff Handle { get; set; }
        public virtual AcStaff Operator { get; set; }
        public virtual PrProductTask Task { get; set; }
        public virtual ICollection<PrProductTask> PrProductTask { get; set; }
    }
}
