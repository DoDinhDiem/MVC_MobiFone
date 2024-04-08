namespace Mobifone_DATN.Models.Dto
{
    public class TaiKhoanNhanVien
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PassWord { get; set; }
        public int? RoleId { get; set; }
        public int? TaiKhoanId { get; set; }
        public string? HoTen { get; set; }
        public string? GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string? DiaChi { get; set; }
    }
}
