using System;
using System.Collections.Generic;

namespace Mobifone_DATN.Models
{
    public partial class HoaDonXuat
    {
        public HoaDonXuat()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }

        public int Id { get; set; }
        public string? HoTen { get; set; }
        public string? SoDienThoai { get; set; }
        public string? DiaChi { get; set; }
        public string? GhiChu { get; set; }
        public int? TongTien { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? TrangThaiDonHang { get; set; }
        public string? PhuongThucThanhToan { get; set; }

        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}
