using System;
using System.Collections.Generic;

namespace Mobifone_DATN.Models
{
    public partial class ChiTietHoaDon
    {
        public int Id { get; set; }
        public int? HoaDonId { get; set; }
        public int? SimSoId { get; set; }
        public int? GiaBan { get; set; }

        public virtual HoaDonXuat? HoaDon { get; set; }
        public virtual SimSo? SimSo { get; set; }
    }
}
