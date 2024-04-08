using System;
using System.Collections.Generic;

namespace Mobifone_DATN.Models
{
    public partial class SimSo
    {
        public SimSo()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }

        public int Id { get; set; }
        public string? SoThueBao { get; set; }
        public string? LoaiThueBao { get; set; }
        public string? LoaiSo { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? GiaBan { get; set; }
        public bool TrangThai { get; set; }

        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}
