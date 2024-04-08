using System;
using System.Collections.Generic;

namespace Mobifone_DATN.Models
{
    public partial class GoiCuoc
    {
        public GoiCuoc()
        {
            ThongTinGoiCuocs = new HashSet<ThongTinGoiCuoc>();
        }

        public int Id { get; set; }
        public string? MaGoi { get; set; }
        public string? ThongTinChinh { get; set; }
        public string? Data { get; set; }
        public int? GiaGoiCuoc { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<ThongTinGoiCuoc> ThongTinGoiCuocs { get; set; }
    }
}
