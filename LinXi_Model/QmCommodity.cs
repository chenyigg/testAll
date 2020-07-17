using System;
using System.Collections.Generic;

namespace LinXi_Model
{
    public partial class QmCommodity
    {
        public QmCommodity()
        {
            PuOrder = new HashSet<PuOrder>();
        }

        public int Id { get; set; }
        public string No { get; set; }
        public int? OrderId { get; set; }
        public DateTime? QmDate { get; set; }
        public int? Result { get; set; }
        public int? HandleId { get; set; }
        public int? OperatorId { get; set; }
        public DateTime? OperateTime { get; set; }
        public string Pic { get; set; }
        public string Remark { get; set; }

        public virtual AcStaff Handle { get; set; }
        public virtual AcStaff Operator { get; set; }
        public virtual PuOrder Order { get; set; }
        public virtual ICollection<PuOrder> PuOrder { get; set; }
    }
}
