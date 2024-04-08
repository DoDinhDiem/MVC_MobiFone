using System;
using System.Collections.Generic;

namespace Mobifone_DATN.Models
{
    public partial class GioiThieu
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? NoiDung { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
