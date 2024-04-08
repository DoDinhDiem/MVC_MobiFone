using System;
using System.Collections.Generic;

namespace Mobifone_DATN.Models
{
    public partial class ThongTinGoiCuoc
    {
        public int Id { get; set; }
        public int? GoiCuocId { get; set; }
        public string? MoTa { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual GoiCuoc? GoiCuoc { get; set; }
    }
}
