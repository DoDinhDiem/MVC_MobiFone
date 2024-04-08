using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Mobifone_DATN.Models
{
    public partial class DATN_MobifoneContext : DbContext
    {
        public DATN_MobifoneContext()
        {
        }

        public DATN_MobifoneContext(DbContextOptions<DATN_MobifoneContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; } = null!;
        public virtual DbSet<GioiThieu> GioiThieus { get; set; } = null!;
        public virtual DbSet<GoiCuoc> GoiCuocs { get; set; } = null!;
        public virtual DbSet<HoaDonXuat> HoaDonXuats { get; set; } = null!;
        public virtual DbSet<LienHe> LienHes { get; set; } = null!;
        public virtual DbSet<NhanVien> NhanViens { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<SimSo> SimSos { get; set; } = null!;
        public virtual DbSet<Slide> Slides { get; set; } = null!;
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; } = null!;
        public virtual DbSet<ThongTinGoiCuoc> ThongTinGoiCuocs { get; set; } = null!;
        public virtual DbSet<TinTuc> TinTucs { get; set; } = null!;
        public virtual DbSet<TuyenDung> TuyenDungs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DINHDIEMIT;Initial Catalog=DATN_Mobifone;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietHoaDon>(entity =>
            {
                entity.ToTable("ChiTietHoaDon");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GiaBan).HasColumnName("giaBan");

                entity.Property(e => e.HoaDonId).HasColumnName("hoaDon_id");

                entity.Property(e => e.SimSoId).HasColumnName("simSo_id");

                entity.HasOne(d => d.HoaDon)
                    .WithMany(p => p.ChiTietHoaDons)
                    .HasForeignKey(d => d.HoaDonId)
                    .HasConstraintName("FK_ChiTietHoaDon_HoaDonXuat");

                entity.HasOne(d => d.SimSo)
                    .WithMany(p => p.ChiTietHoaDons)
                    .HasForeignKey(d => d.SimSoId)
                    .HasConstraintName("FK_ChiTietHoaDon_SimSo");
            });

            modelBuilder.Entity<GioiThieu>(entity =>
            {
                entity.ToTable("GioiThieu");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NoiDung)
                    .HasColumnType("ntext")
                    .HasColumnName("noiDung");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<GoiCuoc>(entity =>
            {
                entity.ToTable("GoiCuoc");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Data)
                    .HasMaxLength(255)
                    .HasColumnName("data");

                entity.Property(e => e.GiaGoiCuoc).HasColumnName("giaGoiCuoc");

                entity.Property(e => e.MaGoi)
                    .HasMaxLength(255)
                    .HasColumnName("maGoi");

                entity.Property(e => e.ThongTinChinh)
                    .HasMaxLength(255)
                    .HasColumnName("thongTinChinh");
            });

            modelBuilder.Entity<HoaDonXuat>(entity =>
            {
                entity.ToTable("HoaDonXuat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DiaChi)
                    .HasColumnType("ntext")
                    .HasColumnName("diaChi");

                entity.Property(e => e.GhiChu)
                    .HasColumnType("ntext")
                    .HasColumnName("ghiChu");

                entity.Property(e => e.HoTen)
                    .HasMaxLength(255)
                    .HasColumnName("hoTen");

                entity.Property(e => e.PhuongThucThanhToan)
                    .HasMaxLength(255)
                    .HasColumnName("phuongThucThanhToan");

                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(10)
                    .HasColumnName("soDienThoai");

                entity.Property(e => e.TongTien).HasColumnName("tongTien");

                entity.Property(e => e.TrangThaiDonHang)
                    .HasMaxLength(255)
                    .HasColumnName("trangThaiDonHang");
            });

            modelBuilder.Entity<LienHe>(entity =>
            {
                entity.ToTable("LienHe");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DiaChi)
                    .HasColumnType("ntext")
                    .HasColumnName("diaChi");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(255)
                    .HasColumnName("fullname");

                entity.Property(e => e.Image)
                    .HasColumnType("ntext")
                    .HasColumnName("image");

                entity.Property(e => e.Map)
                    .HasColumnType("ntext")
                    .HasColumnName("map");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.ToTable("nhanVien");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DiaChi)
                    .HasMaxLength(525)
                    .HasColumnName("diaChi");

                entity.Property(e => e.GioiTinh)
                    .HasMaxLength(5)
                    .HasColumnName("gioiTinh");

                entity.Property(e => e.HoTen)
                    .HasMaxLength(255)
                    .HasColumnName("hoTen");

                entity.Property(e => e.NgaySinh)
                    .HasColumnType("datetime")
                    .HasColumnName("ngaySinh");

                entity.Property(e => e.TaiKhoanId).HasColumnName("taiKhoan_id");

                entity.HasOne(d => d.TaiKhoan)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.TaiKhoanId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_nhanVien_TaiKhoan");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TenRole)
                    .HasMaxLength(255)
                    .HasColumnName("tenRole");
            });

            modelBuilder.Entity<SimSo>(entity =>
            {
                entity.ToTable("SimSo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GiaBan).HasColumnName("giaBan");

                entity.Property(e => e.LoaiSo)
                    .HasMaxLength(255)
                    .HasColumnName("loaiSo");

                entity.Property(e => e.LoaiThueBao)
                    .HasMaxLength(255)
                    .HasColumnName("loaiThueBao");

                entity.Property(e => e.SoThueBao)
                    .HasMaxLength(15)
                    .HasColumnName("soThueBao");

                entity.Property(e => e.TrangThai).HasColumnName("trangThai");
            });

            modelBuilder.Entity<Slide>(entity =>
            {
                entity.ToTable("Slide");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Image).HasColumnType("ntext");
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.ToTable("TaiKhoan");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.PassWord)
                    .HasMaxLength(255)
                    .HasColumnName("passWord");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .HasColumnName("userName");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TaiKhoans)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TaiKhoan_Role");
            });

            modelBuilder.Entity<ThongTinGoiCuoc>(entity =>
            {
                entity.ToTable("ThongTinGoiCuoc");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GoiCuocId).HasColumnName("goiCuoc_id");

                entity.Property(e => e.MoTa)
                    .HasColumnType("ntext")
                    .HasColumnName("moTa");

                entity.HasOne(d => d.GoiCuoc)
                    .WithMany(p => p.ThongTinGoiCuocs)
                    .HasForeignKey(d => d.GoiCuocId)
                    .HasConstraintName("FK_ThongTinGoiCuoc_GoiCuoc");
            });

            modelBuilder.Entity<TinTuc>(entity =>
            {
                entity.ToTable("TinTuc");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .HasColumnName("image");

                entity.Property(e => e.NguoiViet).HasColumnName("nguoiViet");

                entity.Property(e => e.NoiDung)
                    .HasColumnType("ntext")
                    .HasColumnName("noiDung");

                entity.Property(e => e.TieuDe)
                    .HasMaxLength(255)
                    .HasColumnName("tieuDe");

                entity.HasOne(d => d.NguoiVietNavigation)
                    .WithMany(p => p.TinTucs)
                    .HasForeignKey(d => d.NguoiViet)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TinTuc_nhanVien");
            });

            modelBuilder.Entity<TuyenDung>(entity =>
            {
                entity.ToTable("TuyenDung");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .HasColumnName("image");

                entity.Property(e => e.LinkGoogleForm)
                    .HasColumnType("ntext")
                    .HasColumnName("linkGoogleForm");

                entity.Property(e => e.NoiDung)
                    .HasColumnType("ntext")
                    .HasColumnName("noiDung");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
