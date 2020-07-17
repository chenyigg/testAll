using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LinXi_Model
{
    public partial class db_erpContext : DbContext
    {
        public db_erpContext()
        {
        }

        public db_erpContext(DbContextOptions<db_erpContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AcDepartment> AcDepartment { get; set; }
        public virtual DbSet<AcPermission> AcPermission { get; set; }
        public virtual DbSet<AcRole> AcRole { get; set; }
        public virtual DbSet<AcRolePermission> AcRolePermission { get; set; }
        public virtual DbSet<AcStaff> AcStaff { get; set; }
        public virtual DbSet<AcUserinfo> AcUserinfo { get; set; }
        public virtual DbSet<AuRecord> AuRecord { get; set; }
        public virtual DbSet<IcCommodityRecord> IcCommodityRecord { get; set; }
        public virtual DbSet<IcCommodityStock> IcCommodityStock { get; set; }
        public virtual DbSet<IcProductRecord> IcProductRecord { get; set; }
        public virtual DbSet<IcProductStock> IcProductStock { get; set; }
        public virtual DbSet<IcWarehouse> IcWarehouse { get; set; }
        public virtual DbSet<PrProduct> PrProduct { get; set; }
        public virtual DbSet<PrProductCategory> PrProductCategory { get; set; }
        public virtual DbSet<PrProductMaterial> PrProductMaterial { get; set; }
        public virtual DbSet<PrProductTask> PrProductTask { get; set; }
        public virtual DbSet<PuCommodity> PuCommodity { get; set; }
        public virtual DbSet<PuCommodityCategory> PuCommodityCategory { get; set; }
        public virtual DbSet<PuOrder> PuOrder { get; set; }
        public virtual DbSet<PuSupplier> PuSupplier { get; set; }
        public virtual DbSet<QmCommodity> QmCommodity { get; set; }
        public virtual DbSet<QmProduct> QmProduct { get; set; }
        public virtual DbSet<SlCustomer> SlCustomer { get; set; }
        public virtual DbSet<SlOrder> SlOrder { get; set; }
        public virtual DbSet<SlReject> SlReject { get; set; }
        public virtual DbSet<SlSaleOrder> SlSaleOrder { get; set; }
        public virtual DbSet<SysConfigItem> SysConfigItem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("uid=root;pwd=123456;database=db_erp;server=localhost", x => x.ServerVersion("8.0.20-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcDepartment>(entity =>
            {
                entity.ToTable("ac_department");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasComment("名称")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasColumnType("varchar(200)")
                    .HasComment("备注")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<AcPermission>(entity =>
            {
                entity.ToTable("ac_permission");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.Icon)
                    .HasColumnName("icon")
                    .HasColumnType("varchar(50)")
                    .HasComment("菜单图标")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.IsMenu)
                    .HasColumnName("is_menu")
                    .HasComment("是否菜单");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasComment("名称")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Pid)
                    .HasColumnName("pid")
                    .HasComment("上级权限");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasColumnType("varchar(200)")
                    .HasComment("备注")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasColumnType("varchar(50)")
                    .HasComment("URL")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<AcRole>(entity =>
            {
                entity.ToTable("ac_role");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasComment("名称")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasColumnType("varchar(200)")
                    .HasComment("备注")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<AcRolePermission>(entity =>
            {
                entity.ToTable("ac_role_permission");

                entity.HasIndex(e => e.PermissionId)
                    .HasName("FK_ac_role_permission_ac_permission");

                entity.HasIndex(e => e.RoleId)
                    .HasName("FK_ac_role_permission_ac_role");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.PermissionId)
                    .HasColumnName("permission_id")
                    .HasComment("权限编号");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasComment("角色编号");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.AcRolePermission)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ac_role_permission_ac_permission");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AcRolePermission)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ac_role_permission_ac_role");
            });

            modelBuilder.Entity<AcStaff>(entity =>
            {
                entity.ToTable("ac_staff");

                entity.HasIndex(e => e.DepartmentId)
                    .HasName("FK_ac_staff_ac_department");

                entity.HasIndex(e => e.No)
                    .HasName("IX_StaffInfo")
                    .IsUnique();

                entity.HasIndex(e => e.UserId)
                    .HasName("FK_ac_staff_ac_userInfo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasColumnType("varchar(50)")
                    .HasComment("地址")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("department_id")
                    .HasComment("部门");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(20)")
                    .HasComment("姓名")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.No)
                    .IsRequired()
                    .HasColumnName("no")
                    .HasColumnType("varchar(10)")
                    .HasComment("员工编号")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasColumnType("varchar(200)")
                    .HasComment("备注")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasComment("0：男，1：女");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("0：离职，1：在职");

                entity.Property(e => e.Tel)
                    .HasColumnName("tel")
                    .HasColumnType("varchar(21)")
                    .HasComment("电话")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasComment("账户id");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.AcStaff)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_ac_staff_ac_department");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AcStaff)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ac_staff_ac_userInfo");
            });

            modelBuilder.Entity<AcUserinfo>(entity =>
            {
                entity.ToTable("ac_userinfo");

                entity.HasIndex(e => e.RoleId)
                    .HasName("FK_ac_userInfo_ac_role");

                entity.HasIndex(e => e.StaffId)
                    .HasName("FK_ac_userInfo_ac_staff");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.Account)
                    .HasColumnName("account")
                    .HasColumnType("varchar(20)")
                    .HasComment("账号")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Pwd)
                    .HasColumnName("pwd")
                    .HasColumnType("varchar(50)")
                    .HasComment("密码")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasComment("角色编号");

                entity.Property(e => e.StaffId)
                    .HasColumnName("staff_id")
                    .HasComment("员工编号");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AcUserinfo)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_ac_userInfo_ac_role");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.AcUserinfo)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK_ac_userInfo_ac_staff");
            });

            modelBuilder.Entity<AuRecord>(entity =>
            {
                entity.ToTable("au_record");

                entity.HasIndex(e => e.ApproverId)
                    .HasName("FK_au_record_ac_staff1");

                entity.HasIndex(e => e.OperatorId)
                    .HasName("FK_au_record_ac_staff");

                entity.HasIndex(e => e.SourceType)
                    .HasName("Relationship_32_FK");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.ApproveDesc)
                    .HasColumnName("approve_desc")
                    .HasColumnType("datetime")
                    .HasComment("处理备注");

                entity.Property(e => e.ApproveReult)
                    .HasColumnName("approve_reult")
                    .HasColumnType("varchar(200)")
                    .HasComment("处理结论")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ApproveTime)
                    .HasColumnName("approve_time")
                    .HasColumnType("datetime")
                    .HasComment("处理时间");

                entity.Property(e => e.ApproverId)
                    .HasColumnName("approver_id")
                    .HasComment("处理人");

                entity.Property(e => e.OperateDesc)
                    .HasColumnName("operate_desc")
                    .HasColumnType("varchar(200)")
                    .HasComment("操作意见")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.OperateTime)
                    .HasColumnName("operate_time")
                    .HasColumnType("datetime")
                    .HasComment("操作时间");

                entity.Property(e => e.OperatorId)
                    .HasColumnName("operator_id")
                    .HasComment("操作人");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasColumnType("varchar(200)")
                    .HasComment("备注")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.SourceId)
                    .HasColumnName("source_id")
                    .HasComment("审批单号");

                entity.Property(e => e.SourceType)
                    .HasColumnName("source_type")
                    .HasComment("审批类型");

                entity.HasOne(d => d.Approver)
                    .WithMany(p => p.AuRecordApprover)
                    .HasForeignKey(d => d.ApproverId)
                    .HasConstraintName("FK_au_record_ac_staff1");

                entity.HasOne(d => d.Operator)
                    .WithMany(p => p.AuRecordOperator)
                    .HasForeignKey(d => d.OperatorId)
                    .HasConstraintName("FK_au_record_ac_staff");
            });

            modelBuilder.Entity<IcCommodityRecord>(entity =>
            {
                entity.ToTable("ic_commodity_record");

                entity.HasIndex(e => e.CommodityId)
                    .HasName("Relationship_19_FK");

                entity.HasIndex(e => e.DepartmentId)
                    .HasName("FK_ic_commodity_record_ac_department");

                entity.HasIndex(e => e.OperatorId)
                    .HasName("FK_ic_commodity_record_ac_staff1");

                entity.HasIndex(e => e.StaffId)
                    .HasName("FK_ic_commodity_record_ac_staff");

                entity.HasIndex(e => e.WarehouseId)
                    .HasName("FK_ic_commodity_record_ic_warehouse");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.Batch)
                    .HasColumnName("batch")
                    .HasColumnType("varchar(20)")
                    .HasComment("批次号")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CommodityId)
                    .HasColumnName("commodity_id")
                    .HasComment("商品");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("department_id")
                    .HasComment("出入库部门");

                entity.Property(e => e.IsIn)
                    .HasColumnName("is_in")
                    .HasComment("出入库");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasComment("主题")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Nums)
                    .HasColumnName("nums")
                    .HasColumnType("decimal(18,2)")
                    .HasComment("数量");

                entity.Property(e => e.OperateTime)
                    .HasColumnName("operate_time")
                    .HasColumnType("datetime")
                    .HasComment("操作时间");

                entity.Property(e => e.OperatorId)
                    .HasColumnName("operator_id")
                    .HasComment("操作人");

                entity.Property(e => e.Reason)
                    .HasColumnName("reason")
                    .HasColumnType("varchar(200)")
                    .HasComment("原因")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasColumnType("varchar(200)")
                    .HasComment("备注")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.SourceCategory)
                    .HasColumnName("source_category")
                    .HasComment("源单类型");

                entity.Property(e => e.SourceId)
                    .HasColumnName("source_id")
                    .HasComment("源单ID");

                entity.Property(e => e.SourceNo)
                    .HasColumnName("source_no")
                    .HasColumnType("varchar(50)")
                    .HasComment("源单编号")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.StaffId)
                    .HasColumnName("staff_id")
                    .HasComment("出入库员工");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态");

                entity.Property(e => e.WarehouseId)
                    .HasColumnName("warehouse_id")
                    .HasComment("仓库");

                entity.HasOne(d => d.Commodity)
                    .WithMany(p => p.IcCommodityRecord)
                    .HasForeignKey(d => d.CommodityId)
                    .HasConstraintName("FK_ic_commodity_record_pu_commodity");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.IcCommodityRecord)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_ic_commodity_record_ac_department");

                entity.HasOne(d => d.Operator)
                    .WithMany(p => p.IcCommodityRecordOperator)
                    .HasForeignKey(d => d.OperatorId)
                    .HasConstraintName("FK_ic_commodity_record_ac_staff1");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.IcCommodityRecordStaff)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK_ic_commodity_record_ac_staff");

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.IcCommodityRecord)
                    .HasForeignKey(d => d.WarehouseId)
                    .HasConstraintName("FK_ic_commodity_record_ic_warehouse");
            });

            modelBuilder.Entity<IcCommodityStock>(entity =>
            {
                entity.ToTable("ic_commodity_stock");

                entity.HasIndex(e => e.CommodityId)
                    .HasName("FK_ic_commodity_stock_pu_commodity");

                entity.HasIndex(e => e.WarehouseId)
                    .HasName("FK_ic_commodity_stock_ic_warehouse");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.CommodityId)
                    .HasColumnName("commodity_id")
                    .HasComment("商品编号");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasColumnType("varchar(200)")
                    .HasComment("备注")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Stock)
                    .HasColumnName("stock")
                    .HasColumnType("decimal(18,2)")
                    .HasComment("库存");

                entity.Property(e => e.WarehouseId)
                    .HasColumnName("warehouse_id")
                    .HasComment("仓库");

                entity.HasOne(d => d.Commodity)
                    .WithMany(p => p.IcCommodityStock)
                    .HasForeignKey(d => d.CommodityId)
                    .HasConstraintName("FK_ic_commodity_stock_pu_commodity");

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.IcCommodityStock)
                    .HasForeignKey(d => d.WarehouseId)
                    .HasConstraintName("FK_ic_commodity_stock_ic_warehouse");
            });

            modelBuilder.Entity<IcProductRecord>(entity =>
            {
                entity.ToTable("ic_product_record");

                entity.HasIndex(e => e.DepartmentId)
                    .HasName("FK_ic_product_record_ac_department");

                entity.HasIndex(e => e.OperatorId)
                    .HasName("FK_ic_product_record_ac_staff1");

                entity.HasIndex(e => e.ProductId)
                    .HasName("FK_ic_product_record_pr_product");

                entity.HasIndex(e => e.StaffId)
                    .HasName("FK_ic_product_record_ac_staff");

                entity.HasIndex(e => e.WarehouseId)
                    .HasName("FK_ic_product_record_ic_warehouse");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.Batch)
                    .HasColumnName("batch")
                    .HasColumnType("varchar(20)")
                    .HasComment("批次号")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("department_id")
                    .HasComment("部门编号");

                entity.Property(e => e.IsIn)
                    .HasColumnName("is_in")
                    .HasComment("出入库");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasComment("名称")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Nums)
                    .HasColumnName("nums")
                    .HasColumnType("decimal(18,2)")
                    .HasComment("数量");

                entity.Property(e => e.OperateTime)
                    .HasColumnName("operate_time")
                    .HasColumnType("datetime")
                    .HasComment("操作时间");

                entity.Property(e => e.OperatorId)
                    .HasColumnName("operator_id")
                    .HasComment("操作人");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasComment("产品编号");

                entity.Property(e => e.Reason)
                    .HasColumnName("reason")
                    .HasColumnType("varchar(200)")
                    .HasComment("原因")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.SourceCategory)
                    .HasColumnName("source_category")
                    .HasComment("源单类型");

                entity.Property(e => e.SourceId)
                    .HasColumnName("source_id")
                    .HasComment("源单编号");

                entity.Property(e => e.SourceNo)
                    .HasColumnName("source_no")
                    .HasColumnType("varchar(50)")
                    .HasComment("原单订单号")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.StaffId)
                    .HasColumnName("staff_id")
                    .HasComment("员工编号");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态");

                entity.Property(e => e.WarehouseId)
                    .HasColumnName("warehouse_id")
                    .HasComment("仓库编号");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.IcProductRecord)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_ic_product_record_ac_department");

                entity.HasOne(d => d.Operator)
                    .WithMany(p => p.IcProductRecordOperator)
                    .HasForeignKey(d => d.OperatorId)
                    .HasConstraintName("FK_ic_product_record_ac_staff1");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.IcProductRecord)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_ic_product_record_pr_product");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.IcProductRecordStaff)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK_ic_product_record_ac_staff");

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.IcProductRecord)
                    .HasForeignKey(d => d.WarehouseId)
                    .HasConstraintName("FK_ic_product_record_ic_warehouse");
            });

            modelBuilder.Entity<IcProductStock>(entity =>
            {
                entity.ToTable("ic_product_stock");

                entity.HasIndex(e => e.ProductId)
                    .HasName("FK_ic_product_stock_pr_product");

                entity.HasIndex(e => e.WarehouseId)
                    .HasName("FK_ic_product_stock_ic_warehouse");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasComment("产品编号");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasColumnType("varchar(200)")
                    .HasComment("备注")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Stock)
                    .HasColumnName("stock")
                    .HasColumnType("decimal(18,2)")
                    .HasComment("库存数");

                entity.Property(e => e.WarehouseId)
                    .HasColumnName("warehouse_id")
                    .HasComment("仓库号");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.IcProductStock)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_ic_product_stock_pr_product");

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.IcProductStock)
                    .HasForeignKey(d => d.WarehouseId)
                    .HasConstraintName("FK_ic_product_stock_ic_warehouse");
            });

            modelBuilder.Entity<IcWarehouse>(entity =>
            {
                entity.ToTable("ic_warehouse");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasColumnType("varchar(200)")
                    .HasComment("地址")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasComment("仓库类型");

                entity.Property(e => e.ManagerId)
                    .HasColumnName("manager_id")
                    .HasComment("管理员");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)")
                    .HasComment("名称")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.No)
                    .IsRequired()
                    .HasColumnName("no")
                    .HasColumnType("varchar(50)")
                    .HasComment("仓库编号")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.OperateTime)
                    .HasColumnName("operate_time")
                    .HasColumnType("datetime")
                    .HasComment("操作时间");

                entity.Property(e => e.OperatorId)
                    .HasColumnName("operator_id")
                    .HasComment("操作人");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasColumnType("varchar(200)")
                    .HasComment("备注")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态");
            });

            modelBuilder.Entity<PrProduct>(entity =>
            {
                entity.ToTable("pr_product");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("Relationship_26_FK");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.BarCode)
                    .HasColumnName("bar_code")
                    .HasColumnType("varchar(20)")
                    .HasComment("条码")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("category_id")
                    .HasComment("产品分类");

                entity.Property(e => e.LicenseNo)
                    .HasColumnName("license_no")
                    .HasColumnType("varchar(50)")
                    .HasComment("批文")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Manufacturer)
                    .IsRequired()
                    .HasColumnName("manufacturer")
                    .HasColumnType("varchar(200)")
                    .HasComment("生产厂家")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasComment("名称")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.OperatorId)
                    .HasColumnName("operator_id")
                    .HasComment("操作人");

                entity.Property(e => e.OperatorTime)
                    .HasColumnName("operator_time")
                    .HasColumnType("datetime")
                    .HasComment("操作时间");

                entity.Property(e => e.Place)
                    .HasColumnName("place")
                    .HasColumnType("varchar(200)")
                    .HasComment("产地")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(19,4)")
                    .HasComment("价格");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasColumnType("varchar(200)")
                    .HasComment("备注")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Spec)
                    .HasColumnName("spec")
                    .HasColumnType("varchar(200)")
                    .HasComment("规格")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Stock)
                    .HasColumnName("stock")
                    .HasColumnType("decimal(18,2)")
                    .HasComment("库存");

                entity.Property(e => e.Unit)
                    .HasColumnName("unit")
                    .HasColumnType("varchar(50)")
                    .HasComment("单位")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.PrProduct)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_pr_product_pr_product_category");
            });

            modelBuilder.Entity<PrProductCategory>(entity =>
            {
                entity.ToTable("pr_product_category");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasComment("名称")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasColumnType("varchar(200)")
                    .HasComment("备注")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<PrProductMaterial>(entity =>
            {
                entity.ToTable("pr_product_material");

                entity.HasIndex(e => e.CommodityId)
                    .HasName("FK_pr_product_material_pu_commodity");

                entity.HasIndex(e => e.DepartmentId)
                    .HasName("FK_pr_product_material_ac_department");

                entity.HasIndex(e => e.OperatorId)
                    .HasName("FK_pr_product_material_ac_staff1");

                entity.HasIndex(e => e.StaffId)
                    .HasName("FK_pr_product_material_ac_staff");

                entity.HasIndex(e => e.Status)
                    .HasName("FK_pr_product_material_pr_product_task");

                entity.HasIndex(e => e.TaskId)
                    .HasName("Relationship_29_FK");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.CommodityId)
                    .HasColumnName("commodity_id")
                    .HasComment("物料编号");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("department_id")
                    .HasComment("领用部门");

                entity.Property(e => e.Nums)
                    .HasColumnName("nums")
                    .HasComment("数量");

                entity.Property(e => e.OperateTime)
                    .HasColumnName("operate_time")
                    .HasColumnType("datetime")
                    .HasComment("操作时间");

                entity.Property(e => e.OperatorId)
                    .HasColumnName("operator_id")
                    .HasComment("操作人");

                entity.Property(e => e.ReceiptDate)
                    .HasColumnName("receipt_date")
                    .HasColumnType("decimal(18,0)")
                    .HasComment("领用日期");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasColumnType("varchar(200)")
                    .HasComment("备注")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.StaffId)
                    .HasColumnName("staff_id")
                    .HasComment("领用人");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态");

                entity.Property(e => e.TaskId)
                    .HasColumnName("task_id")
                    .HasComment("生产任务");

                entity.Property(e => e.Uses)
                    .HasColumnName("uses")
                    .HasColumnType("varchar(200)")
                    .HasComment("用途")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.Commodity)
                    .WithMany(p => p.PrProductMaterial)
                    .HasForeignKey(d => d.CommodityId)
                    .HasConstraintName("FK_pr_product_material_pu_commodity");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.PrProductMaterial)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_pr_product_material_ac_department");

                entity.HasOne(d => d.Operator)
                    .WithMany(p => p.PrProductMaterialOperator)
                    .HasForeignKey(d => d.OperatorId)
                    .HasConstraintName("FK_pr_product_material_ac_staff1");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.PrProductMaterialStaff)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK_pr_product_material_ac_staff");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.PrProductMaterial)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_pr_product_material_pr_product_task");
            });

            modelBuilder.Entity<PrProductTask>(entity =>
            {
                entity.ToTable("pr_product_task");

                entity.HasIndex(e => e.OperatorId)
                    .HasName("FK_pr_product_task_ac_staff");

                entity.HasIndex(e => e.ProductId)
                    .HasName("FK_pr_product_task_pr_product");

                entity.HasIndex(e => e.QmId)
                    .HasName("FK_pr_product_task_qm_product");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.Batch)
                    .HasColumnName("batch")
                    .HasColumnType("varchar(20)")
                    .HasComment("批次号")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("department_id")
                    .HasComment("部门编号");

                entity.Property(e => e.No)
                    .HasColumnName("no")
                    .HasColumnType("varchar(200)")
                    .HasComment("生产单号")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Nums)
                    .HasColumnName("nums")
                    .HasColumnType("decimal(18,2)")
                    .HasComment("数量");

                entity.Property(e => e.OperateTime)
                    .HasColumnName("operate_time")
                    .HasColumnType("datetime")
                    .HasComment("操作时间");

                entity.Property(e => e.OperatorId)
                    .HasColumnName("operator_id")
                    .HasComment("操作人");

                entity.Property(e => e.ProductDate)
                    .HasColumnName("product_date")
                    .HasColumnType("date")
                    .HasComment("生产日期");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasComment("产品编号");

                entity.Property(e => e.QmId)
                    .HasColumnName("qm_id")
                    .HasComment("质检编号");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasColumnType("varchar(200)")
                    .HasComment("备注")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态");

                entity.HasOne(d => d.Operator)
                    .WithMany(p => p.PrProductTask)
                    .HasForeignKey(d => d.OperatorId)
                    .HasConstraintName("FK_pr_product_task_ac_staff");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PrProductTask)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_pr_product_task_ac_department");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.PrProductTask)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_pr_product_task_pr_product");

                entity.HasOne(d => d.Qm)
                    .WithMany(p => p.PrProductTask)
                    .HasForeignKey(d => d.QmId)
                    .HasConstraintName("FK_pr_product_task_qm_product");
            });

            modelBuilder.Entity<PuCommodity>(entity =>
            {
                entity.ToTable("pu_commodity");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("Relationship_10_FK");

                entity.HasIndex(e => e.OperatorId)
                    .HasName("FK_pu_commodity_ac_staff");

                entity.HasIndex(e => e.SupplierId)
                    .HasName("Relationship_20_FK");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("category_id")
                    .HasComment("分类编号");

                entity.Property(e => e.LicenseNo)
                    .HasColumnName("license_no")
                    .HasColumnType("varchar(50)")
                    .HasComment("生产批文")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasComment("名称")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.OperateTime)
                    .HasColumnName("operate_time")
                    .HasColumnType("datetime")
                    .HasComment("操作时间");

                entity.Property(e => e.OperatorId)
                    .HasColumnName("operator_id")
                    .HasComment("操作人");

                entity.Property(e => e.Place)
                    .HasColumnName("place")
                    .HasColumnType("varchar(200)")
                    .HasComment("产地")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(19,4)")
                    .HasComment("价格");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasColumnType("varchar(200)")
                    .HasComment("备注")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Spec)
                    .HasColumnName("spec")
                    .HasColumnType("varchar(20)")
                    .HasComment("规格")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Stock)
                    .HasColumnName("stock")
                    .HasColumnType("decimal(18,2)")
                    .HasComment("库存");

                entity.Property(e => e.SupplierId)
                    .HasColumnName("supplier_id")
                    .HasComment("供应商编号");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.PuCommodity)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_pu_commodity_pu_commodity_category");

                entity.HasOne(d => d.Operator)
                    .WithMany(p => p.PuCommodity)
                    .HasForeignKey(d => d.OperatorId)
                    .HasConstraintName("FK_pu_commodity_ac_staff");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.PuCommodity)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_pu_commodity_pu_supplier");
            });

            modelBuilder.Entity<PuCommodityCategory>(entity =>
            {
                entity.ToTable("pu_commodity_category");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasComment("名称")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasColumnType("varchar(200)")
                    .HasComment("备注")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<PuOrder>(entity =>
            {
                entity.ToTable("pu_order");

                entity.HasIndex(e => e.CommodityId)
                    .HasName("FK_pu_order_pu_commodity");

                entity.HasIndex(e => e.HandleId)
                    .HasName("FK_pu_order_ac_staff");

                entity.HasIndex(e => e.QmId)
                    .HasName("FK_pu_order_qm_commodity");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(19,4)")
                    .HasComment("金额");

                entity.Property(e => e.AmountReceivable)
                    .HasColumnName("amount_receivable")
                    .HasColumnType("decimal(19,4)")
                    .HasComment("应收金额");

                entity.Property(e => e.AmountReceived)
                    .HasColumnName("amount_received")
                    .HasColumnType("decimal(19,4)")
                    .HasComment("实收金额");

                entity.Property(e => e.AmountWay)
                    .HasColumnName("amount_way")
                    .HasComment("结算方式");

                entity.Property(e => e.Batch)
                    .HasColumnName("batch")
                    .HasColumnType("char(10)")
                    .HasComment("批次号")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CommodityId)
                    .HasColumnName("commodity_id")
                    .HasComment("商品编号");

                entity.Property(e => e.HandleId)
                    .HasColumnName("handle_id")
                    .HasComment("经手人");

                entity.Property(e => e.No)
                    .HasColumnName("no")
                    .HasColumnType("varchar(50)")
                    .HasComment("订单号")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Nums)
                    .HasColumnName("nums")
                    .HasColumnType("decimal(18,2)")
                    .HasComment("数量");

                entity.Property(e => e.OperateTime)
                    .HasColumnName("operate_time")
                    .HasColumnType("datetime")
                    .HasComment("操作时间");

                entity.Property(e => e.OperatorId)
                    .HasColumnName("operator_id")
                    .HasComment("操作人");

                entity.Property(e => e.PurchaseDate)
                    .HasColumnName("purchase_date")
                    .HasColumnType("date")
                    .HasComment("采购时间");

                entity.Property(e => e.QmId)
                    .HasColumnName("qm_id")
                    .HasComment("质检单编号");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasColumnType("varchar(200)")
                    .HasComment("备注")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态");

                entity.HasOne(d => d.Commodity)
                    .WithMany(p => p.PuOrder)
                    .HasForeignKey(d => d.CommodityId)
                    .HasConstraintName("FK_pu_order_pu_commodity");

                entity.HasOne(d => d.Handle)
                    .WithMany(p => p.PuOrder)
                    .HasForeignKey(d => d.HandleId)
                    .HasConstraintName("FK_pu_order_ac_staff");

                entity.HasOne(d => d.Qm)
                    .WithMany(p => p.PuOrder)
                    .HasForeignKey(d => d.QmId)
                    .HasConstraintName("FK_pu_order_qm_commodity");
            });

            modelBuilder.Entity<PuSupplier>(entity =>
            {
                entity.ToTable("pu_supplier");

                entity.HasIndex(e => e.OperatorId)
                    .HasName("FK_pu_supplier_ac_staff");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasColumnType("varchar(200)")
                    .HasComment("地址")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Credit)
                    .HasColumnName("credit")
                    .HasColumnType("varchar(50)")
                    .HasComment("信誉度")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(20)")
                    .HasComment("邮箱")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Linkman)
                    .HasColumnName("linkman")
                    .HasColumnType("varchar(50)")
                    .HasComment("联系人")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)")
                    .HasComment("名称")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.OperateTime)
                    .HasColumnName("operate_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.OperatorId).HasColumnName("operator_id");

                entity.Property(e => e.Postcode)
                    .HasColumnName("postcode")
                    .HasColumnType("varchar(20)")
                    .HasComment("邮编")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Qq)
                    .HasColumnName("qq")
                    .HasColumnType("varchar(20)")
                    .HasComment("QQ")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasColumnType("varchar(200)")
                    .HasComment("备注")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Tel)
                    .HasColumnName("tel")
                    .HasColumnType("varchar(50)")
                    .HasComment("电话")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Weixin)
                    .HasColumnName("weixin")
                    .HasColumnType("varchar(20)")
                    .HasComment("微信")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.Operator)
                    .WithMany(p => p.PuSupplier)
                    .HasForeignKey(d => d.OperatorId)
                    .HasConstraintName("FK_pu_supplier_ac_staff");
            });

            modelBuilder.Entity<QmCommodity>(entity =>
            {
                entity.ToTable("qm_commodity");

                entity.HasIndex(e => e.HandleId)
                    .HasName("FK_qm_commodity_ac_staff");

                entity.HasIndex(e => e.OperatorId)
                    .HasName("FK_qm_commodity_ac_staff1");

                entity.HasIndex(e => e.OrderId)
                    .HasName("FK_qm_commodity_pu_order");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.HandleId)
                    .HasColumnName("handle_id")
                    .HasComment("经手人");

                entity.Property(e => e.No)
                    .HasColumnName("no")
                    .HasColumnType("varchar(20)")
                    .HasComment("质检单号")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.OperateTime)
                    .HasColumnName("operate_time")
                    .HasColumnType("datetime")
                    .HasComment("操作时间");

                entity.Property(e => e.OperatorId)
                    .HasColumnName("operator_id")
                    .HasComment("操作人");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasComment("采购单编号");

                entity.Property(e => e.Pic)
                    .HasColumnName("pic")
                    .HasColumnType("varchar(200)")
                    .HasComment("图片")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.QmDate)
                    .HasColumnName("qm_date")
                    .HasColumnType("date")
                    .HasComment("质检日期");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasColumnType("varchar(200)")
                    .HasComment("备注")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Result)
                    .HasColumnName("result")
                    .HasComment("结论");

                entity.HasOne(d => d.Handle)
                    .WithMany(p => p.QmCommodityHandle)
                    .HasForeignKey(d => d.HandleId)
                    .HasConstraintName("FK_qm_commodity_ac_staff");

                entity.HasOne(d => d.Operator)
                    .WithMany(p => p.QmCommodityOperator)
                    .HasForeignKey(d => d.OperatorId)
                    .HasConstraintName("FK_qm_commodity_ac_staff1");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.QmCommodity)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_qm_commodity_pu_order");
            });

            modelBuilder.Entity<QmProduct>(entity =>
            {
                entity.ToTable("qm_product");

                entity.HasIndex(e => e.HandleId)
                    .HasName("FK_qm_product_ac_staff");

                entity.HasIndex(e => e.OperatorId)
                    .HasName("FK_qm_product_ac_staff1");

                entity.HasIndex(e => e.TaskId)
                    .HasName("FK_qm_product_pr_product_task");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.HandleId)
                    .HasColumnName("handle_id")
                    .HasComment("经手人");

                entity.Property(e => e.No)
                    .HasColumnName("no")
                    .HasColumnType("varchar(20)")
                    .HasComment("质检单号")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.OperateTime)
                    .HasColumnName("operate_time")
                    .HasColumnType("datetime")
                    .HasComment("操作时间");

                entity.Property(e => e.OperatorId)
                    .HasColumnName("operator_id")
                    .HasComment("操作人");

                entity.Property(e => e.Pic)
                    .HasColumnName("pic")
                    .HasColumnType("varchar(200)")
                    .HasComment("质检图片")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.QmDate)
                    .HasColumnName("qm_date")
                    .HasColumnType("date")
                    .HasComment("质检日期");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasColumnType("varchar(200)")
                    .HasComment("备注")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Result)
                    .HasColumnName("result")
                    .HasComment("质检结论");

                entity.Property(e => e.TaskId)
                    .HasColumnName("task_id")
                    .HasComment("生产单编号");

                entity.HasOne(d => d.Handle)
                    .WithMany(p => p.QmProductHandle)
                    .HasForeignKey(d => d.HandleId)
                    .HasConstraintName("FK_qm_product_ac_staff");

                entity.HasOne(d => d.Operator)
                    .WithMany(p => p.QmProductOperator)
                    .HasForeignKey(d => d.OperatorId)
                    .HasConstraintName("FK_qm_product_ac_staff1");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.QmProduct)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK_qm_product_pr_product_task");
            });

            modelBuilder.Entity<SlCustomer>(entity =>
            {
                entity.ToTable("sl_customer");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasColumnType("varchar(100)")
                    .HasComment("地址")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasColumnType("date")
                    .HasComment("生日");

                entity.Property(e => e.Custtel)
                    .IsRequired()
                    .HasColumnName("custtel")
                    .HasColumnType("varchar(50)")
                    .HasComment("客户电话")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(32)")
                    .HasComment("邮箱")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Linkman)
                    .HasColumnName("linkman")
                    .HasColumnType("varchar(50)")
                    .HasComment("联系人")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Linktel)
                    .HasColumnName("linktel")
                    .HasColumnType("varchar(50)")
                    .HasComment("联系方式")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Love)
                    .HasColumnName("love")
                    .HasColumnType("varchar(50)")
                    .HasComment("爱好")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasComment("姓名")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Postcode)
                    .HasColumnName("postcode")
                    .HasColumnType("char(10)")
                    .HasComment("邮编")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasColumnType("varchar(200)")
                    .HasComment("备注")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasComment("性别");
            });

            modelBuilder.Entity<SlOrder>(entity =>
            {
                entity.ToTable("sl_order");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("Relationship_23_FK");

                entity.HasIndex(e => e.HandleId)
                    .HasName("FK_sl_order_ac_staff");

                entity.HasIndex(e => e.OperatorId)
                    .HasName("FK_sl_order_ac_staff1");

                entity.HasIndex(e => e.ProductId)
                    .HasName("FK_sl_order_pr_product");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasComment("客户编号");

                entity.Property(e => e.DeliveryDate)
                    .HasColumnName("delivery_date")
                    .HasColumnType("date")
                    .HasComment("交货日期");

                entity.Property(e => e.DeliveryWay)
                    .HasColumnName("delivery_way")
                    .HasColumnType("varchar(20)")
                    .HasComment("交货方式")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.HandleId)
                    .HasColumnName("handle_id")
                    .HasComment("经手人");

                entity.Property(e => e.No)
                    .IsRequired()
                    .HasColumnName("no")
                    .HasColumnType("varchar(20)")
                    .HasComment("订单编号")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Nums)
                    .HasColumnName("nums")
                    .HasColumnType("decimal(10,2)")
                    .HasComment("数量");

                entity.Property(e => e.OperatorId)
                    .HasColumnName("operator_id")
                    .HasComment("操作员");

                entity.Property(e => e.OperatorTime)
                    .HasColumnName("operator_time")
                    .HasColumnType("datetime")
                    .HasComment("操作时间");

                entity.Property(e => e.OrderAmount)
                    .HasColumnName("order_amount")
                    .HasColumnType("decimal(18,2)")
                    .HasComment("订单金额");

                entity.Property(e => e.OrderDate)
                    .HasColumnName("order_date")
                    .HasColumnType("date")
                    .HasComment("下单时间");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(10,2)")
                    .HasComment("单价");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasComment("产品编号");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasColumnType("varchar(200)")
                    .HasComment("备注")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态(0待审核，1已审核，2待发货，3已出库，-1审核不通过)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.SlOrder)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sl_order_sl_customer");

                entity.HasOne(d => d.Handle)
                    .WithMany(p => p.SlOrderHandle)
                    .HasForeignKey(d => d.HandleId)
                    .HasConstraintName("FK_sl_order_ac_staff");

                entity.HasOne(d => d.Operator)
                    .WithMany(p => p.SlOrderOperator)
                    .HasForeignKey(d => d.OperatorId)
                    .HasConstraintName("FK_sl_order_ac_staff1");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SlOrder)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sl_order_pr_product");
            });

            modelBuilder.Entity<SlReject>(entity =>
            {
                entity.ToTable("sl_reject");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("FK_sl_reject_sl_customer");

                entity.HasIndex(e => e.HandleId)
                    .HasName("FK_sl_reject_ac_staff");

                entity.HasIndex(e => e.OperatorId)
                    .HasName("FK_sl_reject_ac_staff1");

                entity.HasIndex(e => e.OrderId)
                    .HasName("FK_sl_reject_sl_order");

                entity.HasIndex(e => e.ProductId)
                    .HasName("FK_sl_reject_pr_product");

                entity.HasIndex(e => e.SaleOrderId)
                    .HasName("FK_sl_reject_sl_sale_order");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18,2)")
                    .HasComment("金额");

                entity.Property(e => e.AmountWay)
                    .HasColumnName("amount_way")
                    .HasColumnType("varchar(20)")
                    .HasComment("结算方式")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ApprovalStatus)
                    .HasColumnName("approval_status")
                    .HasComment("审批状态");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasComment("客户");

                entity.Property(e => e.HandleId)
                    .HasColumnName("handle_id")
                    .HasComment("经手人");

                entity.Property(e => e.No)
                    .HasColumnName("no")
                    .HasColumnType("varchar(50)")
                    .HasComment("退货单号")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Nums)
                    .HasColumnName("nums")
                    .HasColumnType("decimal(18,2)")
                    .HasComment("数量");

                entity.Property(e => e.OperatorId)
                    .HasColumnName("operator_id")
                    .HasComment("操作人");

                entity.Property(e => e.OperatorTime)
                    .HasColumnName("operator_time")
                    .HasColumnType("datetime")
                    .HasComment("操作时间");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasComment("订单号");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasComment("产品");

                entity.Property(e => e.RejectDate)
                    .HasColumnName("reject_date")
                    .HasColumnType("date")
                    .HasComment("退单日期");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasColumnType("varchar(200)")
                    .HasComment("备注")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ReturnStatus)
                    .HasColumnName("return_status")
                    .HasComment("退单状态");

                entity.Property(e => e.SaleOrderId)
                    .HasColumnName("sale_order_id")
                    .HasComment("销售单号");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.SlReject)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_sl_reject_sl_customer");

                entity.HasOne(d => d.Handle)
                    .WithMany(p => p.SlRejectHandle)
                    .HasForeignKey(d => d.HandleId)
                    .HasConstraintName("FK_sl_reject_ac_staff");

                entity.HasOne(d => d.Operator)
                    .WithMany(p => p.SlRejectOperator)
                    .HasForeignKey(d => d.OperatorId)
                    .HasConstraintName("FK_sl_reject_ac_staff1");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.SlReject)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_sl_reject_sl_order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SlReject)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_sl_reject_pr_product");

                entity.HasOne(d => d.SaleOrder)
                    .WithMany(p => p.SlReject)
                    .HasForeignKey(d => d.SaleOrderId)
                    .HasConstraintName("FK_sl_reject_sl_sale_order");
            });

            modelBuilder.Entity<SlSaleOrder>(entity =>
            {
                entity.ToTable("sl_sale_order");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("FK_sl_sale_order_sl_customer");

                entity.HasIndex(e => e.HandleId)
                    .HasName("FK_sl_sale_order_ac_staff");

                entity.HasIndex(e => e.OperatorId)
                    .HasName("FK_sl_sale_order_ac_staff1");

                entity.HasIndex(e => e.OrderId)
                    .HasName("FK_sl_sale_order_sl_order");

                entity.HasIndex(e => e.ProductId)
                    .HasName("FK_sl_sale_order_pr_product");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18,2)")
                    .HasComment("总金额");

                entity.Property(e => e.AmountReceivable)
                    .HasColumnName("amount_receivable")
                    .HasColumnType("decimal(18,2)")
                    .HasComment("应收金额");

                entity.Property(e => e.AmountReceived)
                    .HasColumnName("amount_received")
                    .HasColumnType("decimal(18,2)")
                    .HasComment("实收金额");

                entity.Property(e => e.AmountWay)
                    .HasColumnName("amount_way")
                    .HasColumnType("varchar(20)")
                    .HasComment("结算方式")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.AuditStatus)
                    .HasColumnName("audit_status")
                    .HasComment("审批状态  0待审批  1已审批  -1审批不通过");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasComment("客户编号");

                entity.Property(e => e.HandleId)
                    .HasColumnName("handle_id")
                    .HasComment("经手人");

                entity.Property(e => e.No)
                    .HasColumnName("no")
                    .HasColumnType("varchar(50)")
                    .HasComment("销售编号")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Nums)
                    .HasColumnName("nums")
                    .HasColumnType("decimal(18,2)")
                    .HasComment("销售数量");

                entity.Property(e => e.OperatorId)
                    .HasColumnName("operator_id")
                    .HasComment("操作人");

                entity.Property(e => e.OperatorTime)
                    .HasColumnName("operator_time")
                    .HasColumnType("datetime")
                    .HasComment("操作时间");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasComment("订单");

                entity.Property(e => e.OrderStatus)
                    .HasColumnName("order_status")
                    .HasComment("0待提货  1 已出库");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasComment("产品");

                entity.Property(e => e.Remark)
                    .HasColumnType("varchar(200)")
                    .HasComment("备注")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.SaleDate)
                    .HasColumnName("sale_date")
                    .HasColumnType("date")
                    .HasComment("销售日期");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.SlSaleOrder)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_sl_sale_order_sl_customer");

                entity.HasOne(d => d.Handle)
                    .WithMany(p => p.SlSaleOrderHandle)
                    .HasForeignKey(d => d.HandleId)
                    .HasConstraintName("FK_sl_sale_order_ac_staff");

                entity.HasOne(d => d.Operator)
                    .WithMany(p => p.SlSaleOrderOperator)
                    .HasForeignKey(d => d.OperatorId)
                    .HasConstraintName("FK_sl_sale_order_ac_staff1");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.SlSaleOrder)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_sl_sale_order_sl_order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SlSaleOrder)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_sl_sale_order_pr_product");
            });

            modelBuilder.Entity<SysConfigItem>(entity =>
            {
                entity.ToTable("sys_config_item");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("编号");

                entity.Property(e => e.FieldName)
                    .HasColumnName("field_name")
                    .HasColumnType("varchar(50)")
                    .HasComment("字段名")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Keyword)
                    .HasColumnName("keyword")
                    .HasColumnType("varchar(50)")
                    .HasComment("关键字")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.OptionText)
                    .HasColumnName("option_text")
                    .HasColumnType("varchar(50)")
                    .HasComment("文本")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.OptionValue)
                    .HasColumnName("option_value")
                    .HasComment("值");

                entity.Property(e => e.Sorting)
                    .HasColumnName("sorting")
                    .HasComment("排序");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态");

                entity.Property(e => e.TableName)
                    .HasColumnName("table_name")
                    .HasColumnType("varchar(50)")
                    .HasComment("表名")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
