using System;
using System.Collections.Generic;

namespace Mobifone_DATN.Models
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            TinTucs = new HashSet<TinTuc>();
        }

        public int Id { get; set; }
        public int? TaiKhoanId { get; set; }
        public string? HoTen { get; set; }
        public string? GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string? DiaChi { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual TaiKhoan? TaiKhoan { get; set; }
        public virtual ICollection<TinTuc> TinTucs { get; set; }
    }
}
