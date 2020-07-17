using System;
using System.Collections.Generic;

namespace LinXi_Model
{
    public partial class AcRolePermission
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

        public virtual AcPermission Permission { get; set; }
        public virtual AcRole Role { get; set; }
    }
}
