using System;
using System.Collections.Generic;

namespace LinXi_Model
{
    public partial class AcStaff
    {
        public AcStaff()
        {
            AcUserinfo = new HashSet<AcUserinfo>();
            AuRecordApprover = new HashSet<AuRecord>();
            AuRecordOperator = new HashSet<AuRecord>();
            IcCommodityRecordOperator = new HashSet<IcCommodityRecord>();
            IcCommodityRecordStaff = new HashSet<IcCommodityRecord>();
            IcProductRecordOperator = new HashSet<IcProductRecord>();
            IcProductRecordStaff = new HashSet<IcProductRecord>();
            PrProductMaterialOperator = new HashSet<PrProductMaterial>();
            PrProductMaterialStaff = new HashSet<PrProductMaterial>();
            PrProductTask = new HashSet<PrProductTask>();
            PuCommodity = new HashSet<PuCommodity>();
            PuOrder = new HashSet<PuOrder>();
            PuSupplier = new HashSet<PuSupplier>();
            QmCommodityHandle = new HashSet<QmCommodity>();
            QmCommodityOperator = new HashSet<QmCommodity>();
            QmProductHandle = new HashSet<QmProduct>();
            QmProductOperator = new HashSet<QmProduct>();
            SlOrderHandle = new HashSet<SlOrder>();
            SlOrderOperator = new HashSet<SlOrder>();
            SlRejectHandle = new HashSet<SlReject>();
            SlRejectOperator = new HashSet<SlReject>();
            SlSaleOrderHandle = new HashSet<SlSaleOrder>();
            SlSaleOrderOperator = new HashSet<SlSaleOrder>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public sbyte Sex { get; set; }
        public string No { get; set; }
        public string Tel { get; set; }
        public string Address { get; set; }
        public int? DepartmentId { get; set; }
        public sbyte Status { get; set; }
        public int? UserId { get; set; }
        public string Remark { get; set; }

        public virtual AcDepartment Department { get; set; }
        public virtual AcUserinfo User { get; set; }
        public virtual ICollection<AcUserinfo> AcUserinfo { get; set; }
        public virtual ICollection<AuRecord> AuRecordApprover { get; set; }
        public virtual ICollection<AuRecord> AuRecordOperator { get; set; }
        public virtual ICollection<IcCommodityRecord> IcCommodityRecordOperator { get; set; }
        public virtual ICollection<IcCommodityRecord> IcCommodityRecordStaff { get; set; }
        public virtual ICollection<IcProductRecord> IcProductRecordOperator { get; set; }
        public virtual ICollection<IcProductRecord> IcProductRecordStaff { get; set; }
        public virtual ICollection<PrProductMaterial> PrProductMaterialOperator { get; set; }
        public virtual ICollection<PrProductMaterial> PrProductMaterialStaff { get; set; }
        public virtual ICollection<PrProductTask> PrProductTask { get; set; }
        public virtual ICollection<PuCommodity> PuCommodity { get; set; }
        public virtual ICollection<PuOrder> PuOrder { get; set; }
        public virtual ICollection<PuSupplier> PuSupplier { get; set; }
        public virtual ICollection<QmCommodity> QmCommodityHandle { get; set; }
        public virtual ICollection<QmCommodity> QmCommodityOperator { get; set; }
        public virtual ICollection<QmProduct> QmProductHandle { get; set; }
        public virtual ICollection<QmProduct> QmProductOperator { get; set; }
        public virtual ICollection<SlOrder> SlOrderHandle { get; set; }
        public virtual ICollection<SlOrder> SlOrderOperator { get; set; }
        public virtual ICollection<SlReject> SlRejectHandle { get; set; }
        public virtual ICollection<SlReject> SlRejectOperator { get; set; }
        public virtual ICollection<SlSaleOrder> SlSaleOrderHandle { get; set; }
        public virtual ICollection<SlSaleOrder> SlSaleOrderOperator { get; set; }
    }
}
