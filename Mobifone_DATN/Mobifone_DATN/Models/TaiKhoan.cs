using System;
using System.Collections.Generic;

namespace Mobifone_DATN.Models
{
    public partial class TaiKhoan
    {
        public TaiKhoan()
        {
            NhanViens = new HashSet<NhanVien>();
        }

        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PassWord { get; set; }
        public int? RoleId { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
