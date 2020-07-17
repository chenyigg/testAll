using System;
using System.Collections.Generic;

namespace LinXi_Model
{
    public partial class AcUserinfo
    {
        public AcUserinfo()
        {
            AcStaff = new HashSet<AcStaff>();
        }

        public int Id { get; set; }
        public string Account { get; set; }
        public string Pwd { get; set; }
        public int? RoleId { get; set; }
        public int? StaffId { get; set; }

        public virtual AcRole Role { get; set; }
        public virtual AcStaff Staff { get; set; }
        public virtual ICollection<AcStaff> AcStaff { get; set; }
    }
}
