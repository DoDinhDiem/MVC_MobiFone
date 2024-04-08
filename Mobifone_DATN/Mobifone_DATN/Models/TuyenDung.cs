using System;
using System.Collections.Generic;

namespace Mobifone_DATN.Models
{
    public partial class TuyenDung
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? NoiDung { get; set; }
        public string? LinkGoogleForm { get; set; }
        public string? Image { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
