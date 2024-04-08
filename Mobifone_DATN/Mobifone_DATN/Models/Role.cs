using System;
using System.Collections.Generic;

namespace Mobifone_DATN.Models
{
    public partial class Role
    {
        public Role()
        {
            TaiKhoans = new HashSet<TaiKhoan>();
        }

        public int Id { get; set; }
        public string? TenRole { get; set; }

        public virtual ICollection<TaiKhoan> TaiKhoans { get; set; }
    }
}
