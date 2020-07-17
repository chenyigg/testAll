using System;
using System.Collections.Generic;

namespace LinXi_Model
{
    public partial class AcRole
    {
        public AcRole()
        {
            AcRolePermission = new HashSet<AcRolePermission>();
            AcUserinfo = new HashSet<AcUserinfo>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }

        public virtual ICollection<AcRolePermission> AcRolePermission { get; set; }
        public virtual ICollection<AcUserinfo> AcUserinfo { get; set; }
    }
}
