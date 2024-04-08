using System;
using System.Collections.Generic;

namespace Mobifone_DATN.Models
{
    public partial class TinTuc
    {
        public int Id { get; set; }
        public string? TieuDe { get; set; }
        public string? NoiDung { get; set; }
        public string? Image { get; set; }
        public int? NguoiViet { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual NhanVien? NguoiVietNavigation { get; set; }
    }
}
