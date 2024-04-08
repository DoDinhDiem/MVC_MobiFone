using System;
using System.Collections.Generic;

namespace Mobifone_DATN.Models
{
    public partial class LienHe
    {
        public int Id { get; set; }
        public string? Fullname { get; set; }
        public string? DiaChi { get; set; }
        public string? Phone { get; set; }
        public string? Map { get; set; }
        public string? Image { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
