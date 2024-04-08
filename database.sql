CREATE DATABASE [DATN_Mobifone]
GO
USE [DATN_Mobifone]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 4/8/2024 1:42:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[hoaDon_id] [int] NULL,
	[simSo_id] [int] NULL,
	[giaBan] [int] NULL,
 CONSTRAINT [PK_ChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GioiThieu]    Script Date: 4/8/2024 1:42:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GioiThieu](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](255) NULL,
	[noiDung] [ntext] NULL,
	[created_at] [datetime] NULL,
 CONSTRAINT [PK_GioiThieu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GoiCuoc]    Script Date: 4/8/2024 1:42:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GoiCuoc](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[maGoi] [nvarchar](255) NULL,
	[thongTinChinh] [nvarchar](255) NULL,
	[data] [nvarchar](255) NULL,
	[giaGoiCuoc] [int] NULL,
	[created_at] [datetime] NULL,
 CONSTRAINT [PK_GoiCuoc] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDonXuat]    Script Date: 4/8/2024 1:42:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonXuat](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[hoTen] [nvarchar](255) NULL,
	[soDienThoai] [nvarchar](10) NULL,
	[diaChi] [ntext] NULL,
	[ghiChu] [ntext] NULL,
	[tongTien] [int] NULL,
	[created_at] [datetime] NULL,
	[trangThaiDonHang] [nvarchar](255) NULL,
	[phuongThucThanhToan] [nvarchar](255) NULL,
 CONSTRAINT [PK_HoaDonXuat] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LienHe]    Script Date: 4/8/2024 1:42:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LienHe](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fullname] [nvarchar](255) NULL,
	[diaChi] [ntext] NULL,
	[phone] [nvarchar](15) NULL,
	[map] [ntext] NULL,
	[image] [ntext] NULL,
	[created_at] [datetime] NULL,
 CONSTRAINT [PK_LienHe] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nhanVien]    Script Date: 4/8/2024 1:42:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nhanVien](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[taiKhoan_id] [int] NULL,
	[hoTen] [nvarchar](255) NULL,
	[gioiTinh] [nvarchar](5) NULL,
	[ngaySinh] [datetime] NULL,
	[diaChi] [nvarchar](525) NULL,
	[created_at] [datetime] NULL,
 CONSTRAINT [PK_nhanVien] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 4/8/2024 1:42:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tenRole] [nvarchar](255) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SimSo]    Script Date: 4/8/2024 1:42:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SimSo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[soThueBao] [nvarchar](15) NULL,
	[loaiThueBao] [nvarchar](255) NULL,
	[loaiSo] [nvarchar](255) NULL,
	[created_at] [datetime] NULL,
	[giaBan] [int] NULL,
	[trangThai] [bit] NULL,
 CONSTRAINT [PK_SimSo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Slide]    Script Date: 4/8/2024 1:42:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slide](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Image] [ntext] NULL,
 CONSTRAINT [PK__Slide__3213E83F08EE4EAD] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 4/8/2024 1:42:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userName] [nvarchar](255) NULL,
	[email] [nvarchar](255) NULL,
	[passWord] [nvarchar](255) NULL,
	[role_id] [int] NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThongTinGoiCuoc]    Script Date: 4/8/2024 1:42:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongTinGoiCuoc](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[goiCuoc_id] [int] NULL,
	[moTa] [ntext] NULL,
	[created_at] [datetime] NULL,
 CONSTRAINT [PK_ThongTinGoiCuoc] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TinTuc]    Script Date: 4/8/2024 1:42:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TinTuc](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tieuDe] [nvarchar](255) NULL,
	[noiDung] [ntext] NULL,
	[image] [nvarchar](255) NULL,
	[nguoiViet] [int] NULL,
	[created_at] [datetime] NULL,
 CONSTRAINT [PK_TinTuc] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TuyenDung]    Script Date: 4/8/2024 1:42:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TuyenDung](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](255) NULL,
	[noiDung] [ntext] NULL,
	[linkGoogleForm] [ntext] NULL,
	[image] [nvarchar](255) NULL,
	[created_at] [datetime] NULL,
 CONSTRAINT [PK_TuyenDung] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ChiTietHoaDon] ON 

INSERT [dbo].[ChiTietHoaDon] ([id], [hoaDon_id], [simSo_id], [giaBan]) VALUES (7, 3, 5, 60000)
SET IDENTITY_INSERT [dbo].[ChiTietHoaDon] OFF
GO
SET IDENTITY_INSERT [dbo].[GioiThieu] ON 

INSERT [dbo].[GioiThieu] ([id], [title], [noiDung], [created_at]) VALUES (26, N'LỊCH SỬ HÌNH THÀNH MOBIFONE', N'<p>Được thành lập ngày 16/04/1993 với tên gọi ban đầu là Công ty thông tin di động. Ngày 01/12/2014, Công ty được chuyển đổi thành Tổng công ty Viễn thông MobiFone, trực thuộc Bộ Thông tin và Truyền thông, kinh doanh trong các lĩnh vực: dịch vụ viễn thông truyền thống, VAS, Data, Internet &amp; truyền hình IPTV/cable TV, sản phẩm khách hàng doanh nghiệp, dịch vụ công nghệ thông tin, bán lẻ và phân phối và đầu tư nước ngoài.</p><p>Tại Việt Nam, MobiFone là một trong ba mạng di động lớn nhất với hơn 30% thị phần. Chúng tôi cũng là nhà cung cấp mạng thông tin di động đầu tiên và duy nhất tại Việt Nam được bình chọn là thương hiệu được khách hàng yêu thích trong 6 năm liền.</p><p>Hiện nay, MobiFone có gần 50 triệu thuê bao với gần 30.000 trạm 2G và 20.000 trạm 3G. Tổng doanh thu năm 2017&nbsp;của MobiFone đạt xấp xỉ 2 tỷ đô la Mỹ.</p><p><strong>1993:</strong>&nbsp;Thành lập Công ty Thông tin di động. Giám đốc công ty Ông Đinh Văn Phước</p><p><strong>1994:</strong>&nbsp;Thành lập Trung tâm Thông tin di động Khu vực I &amp; II</p><p><strong>1995:</strong>&nbsp;Công ty Thông tin di động ký Hợp đồng hợp tác kinh doanh (BCC) với Tập đoàn Kinnevik/Comvik (Thụy Điển)</p><p>Thành lập Trung tâm Thông tin di động Khu vực III</p><p><strong>2005:</strong>&nbsp;Công ty Thông tin di động ký thanh lý Hợp đồng hợp tác kinh doanh (BCC) với Tập đoàn Kinnevik/Comvik.</p><p>Nhà nước và Bộ Bưu chính Viễn thông (nay là Bộ Thông tin và Truyền thông) có quyết định chính thức về việc cổ phần hoá Công ty Thông tin di động.</p><p>Ông Lê Ngọc Minh lên làm Giám đốc Công ty Thông tin di động thay Ông Đinh Văn Phước (về nghỉ hưu)</p><p><strong>2006:</strong>&nbsp;Thành lập Trung tâm thông tin di động Khu vực IV</p><p><strong>2008:</strong>&nbsp;Thành lập Trung tâm thông tin di động Khu vực V. Kỷ niệm 15 năm thành lập Công ty thông tin di động.</p><p>Thành lập Trung tâm Dịch vụ Giá trị Gia tăng.</p><p>Tính đến tháng 04/2008, MobiFone đang chiếm lĩnh vị trí số 1 về thị phần thuê bao di động tại Việt Nam.</p><p><strong>2009:</strong>&nbsp;Nhận giải Mạng di động xuất sắc nhất năm 2008 do Bộ Thông tin và Truyền thông trao tặng; VMS – MobiFone chính thức cung cấp dịch vụ 3G; Thành lập Trung tâm Tính cước và Thanh khoản.</p><p><strong>2010:</strong>&nbsp;Chuyển đổi thành Công ty TNHH 1 thành viên do Nhà nước làm chủ sở hữu.</p><p><strong>2013:</strong>&nbsp;Kỷ niệm 20 năm thành lập Công ty Thông tin di động và đón nhận Huân chương Độc lập Hạng Ba</p><p>MobiFone là nhà cung cấp mạng thông tin di động đầu tiên và duy nhất tại Việt Nam (2005-2008) được khách hàng yêu mến, bình chọn cho giải thưởng mạng thông tin di động tốt nhất trong năm tại Lễ trao giải Vietnam Mobile Awards do tạp chí Echip Mobile tổ chức. Đặc biệt trong năm 2009, MobiFone vinh dự nhận giải thưởng Mạng di động xuất sắc nhất năm 2008 do Bộ thông tin và Truyền thông Việt nam trao tặng.</p><p><strong>2014:</strong></p><p><strong>Ngày 26/06:</strong>&nbsp;Ông Mai Văn Bình được bổ nhiệm phụ trách chức vụ Chủ tịch Công ty Thông tin di động.</p><p><strong>Ngày 10/07:</strong>&nbsp;Bàn giao quyền đại diện chủ sở hữu Nhà nước tại Công ty VMS từ Tập đoàn VNPT về Bộ TT&amp;TT.</p><p><strong>Ngày 13/08:</strong>&nbsp;Ông Lê Nam Trà được bổ nhiệm chức vụ Tổng Giám đốc Công ty Thông tin di động.</p><p><strong>Ngày 01/12:</strong>&nbsp;Nhận quyết định thành lập Tổng công ty Viễn Thông MobiFone trên cơ sở tổ chức lại Công ty TNHH một thành viên Thông tin di động.</p><p><strong>2015:</strong></p><p><strong>Ngày 21/04:</strong>&nbsp;Ông Lê Nam Trà được bổ nhiệm chức vụ Chủ tịch Hội đồng thành viên. Ông Cao Duy Hải được bổ nhiệm chức vụ Tổng Giám đốc Tổng công ty Viễn thông MobiFone.</p><p><strong>2017:</strong></p><p><strong>Ngày 15/08:</strong>&nbsp;Ông Nguyễn Mạnh Thắng được bổ nhiệm giữ chức vụ Chủ tịch Hội đồng thành viên Tổng công ty Viễn thông MobiFone.</p><p><strong>2018:</strong></p><p><strong>Ngày 22/08:&nbsp;Ông Nguyễn Đăng Nguyên được giao nhiệm vụ Phụ trách chức vụ Tổng giám đốc Tổng công ty Viễn thông MobiFone.</strong></p>', CAST(N'2024-04-08T12:50:49.300' AS DateTime))
SET IDENTITY_INSERT [dbo].[GioiThieu] OFF
GO
SET IDENTITY_INSERT [dbo].[GoiCuoc] ON 

INSERT [dbo].[GoiCuoc] ([id], [maGoi], [thongTinChinh], [data], [giaGoiCuoc], [created_at]) VALUES (3, N'MFY', N'DK MFY 0799980067 GỬI 909', N'DK MFY 0799980067 GỬI 909', 200000, CAST(N'2024-04-08T12:29:52.567' AS DateTime))
INSERT [dbo].[GoiCuoc] ([id], [maGoi], [thongTinChinh], [data], [giaGoiCuoc], [created_at]) VALUES (4, N'MFY200', N'DK MFY200 0799980067 GỬI 909', N'100GB', 20000, CAST(N'2024-04-08T12:30:53.600' AS DateTime))
INSERT [dbo].[GoiCuoc] ([id], [maGoi], [thongTinChinh], [data], [giaGoiCuoc], [created_at]) VALUES (5, N'TK159', N'180GB', N'6GB data tốc độ cao/ngày', 159000, CAST(N'2024-04-08T12:31:46.740' AS DateTime))
INSERT [dbo].[GoiCuoc] ([id], [maGoi], [thongTinChinh], [data], [giaGoiCuoc], [created_at]) VALUES (6, N'TK135', N'210GB', N'7GB data tốc độ cao/ngày', 135000, CAST(N'2024-04-08T12:32:21.890' AS DateTime))
INSERT [dbo].[GoiCuoc] ([id], [maGoi], [thongTinChinh], [data], [giaGoiCuoc], [created_at]) VALUES (7, N'MXH100', N'30GB', N'1GB data tốc độ cao/ngày', 100000, CAST(N'2024-04-08T12:32:57.260' AS DateTime))
INSERT [dbo].[GoiCuoc] ([id], [maGoi], [thongTinChinh], [data], [giaGoiCuoc], [created_at]) VALUES (8, N'MXH120', N'30GB', N'1GB data tốc độ cao/ngày', 120000, CAST(N'2024-04-08T12:33:40.953' AS DateTime))
SET IDENTITY_INSERT [dbo].[GoiCuoc] OFF
GO
SET IDENTITY_INSERT [dbo].[HoaDonXuat] ON 

INSERT [dbo].[HoaDonXuat] ([id], [hoTen], [soDienThoai], [diaChi], [ghiChu], [tongTien], [created_at], [trangThaiDonHang], [phuongThucThanhToan]) VALUES (3, N'Nguyễn Văn A', N'0796498553', N'Hà Đông - Hà Nội', N'Văn Quán', 60000, CAST(N'2024-04-08T13:06:32.477' AS DateTime), N'Giao hàng thành công', N'Thanh toán khi nhận hàng')
SET IDENTITY_INSERT [dbo].[HoaDonXuat] OFF
GO
SET IDENTITY_INSERT [dbo].[LienHe] ON 

INSERT [dbo].[LienHe] ([id], [fullname], [diaChi], [phone], [map], [image], [created_at]) VALUES (4, N'MOBIFONE TỈNH AN GIANG', N'Số 93 Trần Hưng Đạo Phường Mỹ Qúy Thành Phố Long Xuyên Tỉnh An Giang', N'0779249999', N'<iframe src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d7849.425404348258!2d105.449299!3d10.364841!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x310a7307d5714811%3A0xcda168ec36f6ae1f!2sMobiFone%20T%E1%BB%89nh%20An%20Giang!5e0!3m2!1svi!2sus!4v1712555578380!5m2!1svi!2sus" width="600" height="450" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>', N'Image_2024-4-8_12-56-29.jpeg', CAST(N'2024-04-08T12:53:05.443' AS DateTime))
SET IDENTITY_INSERT [dbo].[LienHe] OFF
GO
SET IDENTITY_INSERT [dbo].[nhanVien] ON 

INSERT [dbo].[nhanVien] ([id], [taiKhoan_id], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [created_at]) VALUES (6, 6, N'Admin', N'Nam', CAST(N'1999-02-07T17:00:00.000' AS DateTime), N'Hà Đông - Hà Nội', CAST(N'2024-04-08T11:54:37.413' AS DateTime))
INSERT [dbo].[nhanVien] ([id], [taiKhoan_id], [hoTen], [gioiTinh], [ngaySinh], [diaChi], [created_at]) VALUES (7, 7, N'User', N'Nam', CAST(N'1999-03-07T17:00:00.000' AS DateTime), N'Hà Đông - Hà Nội', CAST(N'2024-04-08T11:55:38.323' AS DateTime))
SET IDENTITY_INSERT [dbo].[nhanVien] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([id], [tenRole]) VALUES (1, N'Role_Admin')
INSERT [dbo].[Role] ([id], [tenRole]) VALUES (3, N'Role_User')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[SimSo] ON 

INSERT [dbo].[SimSo] ([id], [soThueBao], [loaiThueBao], [loaiSo], [created_at], [giaBan], [trangThai]) VALUES (5, N'0902388426', N'Thuê bao trả sau', N'Sim số phổ thông', CAST(N'2024-04-08T12:34:27.477' AS DateTime), 60000, 0)
INSERT [dbo].[SimSo] ([id], [soThueBao], [loaiThueBao], [loaiSo], [created_at], [giaBan], [trangThai]) VALUES (6, N'0902437146', N'Thuê bao trả sau', N'Sim số phổ thông', CAST(N'2024-04-08T12:34:46.663' AS DateTime), 60000, 1)
INSERT [dbo].[SimSo] ([id], [soThueBao], [loaiThueBao], [loaiSo], [created_at], [giaBan], [trangThai]) VALUES (7, N'0902423109', N'Thuê bao trả sau', N'Sim số phổ thông', CAST(N'2024-04-08T12:35:07.117' AS DateTime), 60000, 1)
INSERT [dbo].[SimSo] ([id], [soThueBao], [loaiThueBao], [loaiSo], [created_at], [giaBan], [trangThai]) VALUES (8, N'0766265454', N'Thuê bao trả sau', N'Sim số phổ thông', CAST(N'2024-04-08T12:35:57.763' AS DateTime), 60000, 1)
INSERT [dbo].[SimSo] ([id], [soThueBao], [loaiThueBao], [loaiSo], [created_at], [giaBan], [trangThai]) VALUES (9, N'0931342048', N'Thuê bao trả sau', N'Sim số phổ thông', CAST(N'2024-04-08T12:36:23.340' AS DateTime), 60000, 1)
SET IDENTITY_INSERT [dbo].[SimSo] OFF
GO
SET IDENTITY_INSERT [dbo].[Slide] ON 

INSERT [dbo].[Slide] ([id], [Image]) VALUES (6, N'Image_2024-4-8_12-41-7.jpeg')
INSERT [dbo].[Slide] ([id], [Image]) VALUES (7, N'Image_2024-4-8_12-41-25.jpeg')
INSERT [dbo].[Slide] ([id], [Image]) VALUES (8, N'Image_2024-4-8_12-41-54.jpeg')
INSERT [dbo].[Slide] ([id], [Image]) VALUES (9, N'Image_2024-4-8_12-44-16.jpeg')
SET IDENTITY_INSERT [dbo].[Slide] OFF
GO
SET IDENTITY_INSERT [dbo].[TaiKhoan] ON 

INSERT [dbo].[TaiKhoan] ([id], [userName], [email], [passWord], [role_id]) VALUES (2, N'u33638314', N'dodinhdiem9090@gmail.com', N'12345', 1)
INSERT [dbo].[TaiKhoan] ([id], [userName], [email], [passWord], [role_id]) VALUES (4, N'u336383142', N'dodinhdiem9092@gmail.com', N'12345', 3)
INSERT [dbo].[TaiKhoan] ([id], [userName], [email], [passWord], [role_id]) VALUES (5, N'u336383146666', N'dodinhdiem9099991@gmail.com', N'12345', 1)
INSERT [dbo].[TaiKhoan] ([id], [userName], [email], [passWord], [role_id]) VALUES (6, N'admin', N'admin@gmail.com', N'123456', 1)
INSERT [dbo].[TaiKhoan] ([id], [userName], [email], [passWord], [role_id]) VALUES (7, N'user', N'user@gmail.com', N'123456', 3)
SET IDENTITY_INSERT [dbo].[TaiKhoan] OFF
GO
SET IDENTITY_INSERT [dbo].[ThongTinGoiCuoc] ON 

INSERT [dbo].[ThongTinGoiCuoc] ([id], [goiCuoc_id], [moTa], [created_at]) VALUES (17, 3, N'Miễn Phí truy cập FACEBOOK, YOUTUBE', CAST(N'2024-04-08T12:30:01.197' AS DateTime))
INSERT [dbo].[ThongTinGoiCuoc] ([id], [goiCuoc_id], [moTa], [created_at]) VALUES (18, 3, N'Dùng chung cho nhóm tối đa 5 thành viên', CAST(N'2024-04-08T12:30:01.207' AS DateTime))
INSERT [dbo].[ThongTinGoiCuoc] ([id], [goiCuoc_id], [moTa], [created_at]) VALUES (19, 3, N'30 ngày sử dụng', CAST(N'2024-04-08T12:30:01.213' AS DateTime))
INSERT [dbo].[ThongTinGoiCuoc] ([id], [goiCuoc_id], [moTa], [created_at]) VALUES (20, 4, N'Miễn Phí 500 phút gọi nội mạng', CAST(N'2024-04-08T12:30:53.800' AS DateTime))
INSERT [dbo].[ThongTinGoiCuoc] ([id], [goiCuoc_id], [moTa], [created_at]) VALUES (21, 4, N'Miễn Phí 500 phút gọi nội mạng', CAST(N'2024-04-08T12:30:53.800' AS DateTime))
INSERT [dbo].[ThongTinGoiCuoc] ([id], [goiCuoc_id], [moTa], [created_at]) VALUES (22, 4, N'Miễn Phí truy cập FACEBOOK, YOUTUBE', CAST(N'2024-04-08T12:30:53.800' AS DateTime))
INSERT [dbo].[ThongTinGoiCuoc] ([id], [goiCuoc_id], [moTa], [created_at]) VALUES (23, 4, N'30 ngày sử dụng', CAST(N'2024-04-08T12:30:53.800' AS DateTime))
INSERT [dbo].[ThongTinGoiCuoc] ([id], [goiCuoc_id], [moTa], [created_at]) VALUES (24, 5, N'Miễn phí các cuộc gọi nội mạng dưới 10 phút', CAST(N'2024-04-08T12:31:46.753' AS DateTime))
INSERT [dbo].[ThongTinGoiCuoc] ([id], [goiCuoc_id], [moTa], [created_at]) VALUES (25, 5, N'Miễn phí các cuộc gọi nội mạng dưới 10 phút', CAST(N'2024-04-08T12:31:46.753' AS DateTime))
INSERT [dbo].[ThongTinGoiCuoc] ([id], [goiCuoc_id], [moTa], [created_at]) VALUES (26, 5, N'Miễn Phí truy cập FACEBOOK, YOUTUBE', CAST(N'2024-04-08T12:31:46.753' AS DateTime))
INSERT [dbo].[ThongTinGoiCuoc] ([id], [goiCuoc_id], [moTa], [created_at]) VALUES (27, 5, N'30 ngày sử dụng', CAST(N'2024-04-08T12:31:46.753' AS DateTime))
INSERT [dbo].[ThongTinGoiCuoc] ([id], [goiCuoc_id], [moTa], [created_at]) VALUES (28, 6, N'30 ngày sử dụng', CAST(N'2024-04-08T12:32:21.897' AS DateTime))
INSERT [dbo].[ThongTinGoiCuoc] ([id], [goiCuoc_id], [moTa], [created_at]) VALUES (29, 7, N'Miễn phí truy cập Facebook, Youtube, Tiktok', CAST(N'2024-04-08T12:32:57.263' AS DateTime))
INSERT [dbo].[ThongTinGoiCuoc] ([id], [goiCuoc_id], [moTa], [created_at]) VALUES (30, 7, N'30 ngày sử dụng', CAST(N'2024-04-08T12:32:57.267' AS DateTime))
INSERT [dbo].[ThongTinGoiCuoc] ([id], [goiCuoc_id], [moTa], [created_at]) VALUES (31, 8, N'Miễn phí các cuộc gọi nội mạng dưới 10 phút', CAST(N'2024-04-08T12:33:40.967' AS DateTime))
INSERT [dbo].[ThongTinGoiCuoc] ([id], [goiCuoc_id], [moTa], [created_at]) VALUES (32, 8, N'Miễn phí 30 phút thoại ngoại mạng', CAST(N'2024-04-08T12:33:40.967' AS DateTime))
INSERT [dbo].[ThongTinGoiCuoc] ([id], [goiCuoc_id], [moTa], [created_at]) VALUES (33, 8, N'Miễn phí data YouTube, Facebook, TikTok, nhắn tin FB Messenger', CAST(N'2024-04-08T12:33:40.967' AS DateTime))
INSERT [dbo].[ThongTinGoiCuoc] ([id], [goiCuoc_id], [moTa], [created_at]) VALUES (34, 8, N'30 ngày sử dụng', CAST(N'2024-04-08T12:33:40.967' AS DateTime))
SET IDENTITY_INSERT [dbo].[ThongTinGoiCuoc] OFF
GO
SET IDENTITY_INSERT [dbo].[TinTuc] ON 

INSERT [dbo].[TinTuc] ([id], [tieuDe], [noiDung], [image], [nguoiViet], [created_at]) VALUES (3, N'Mình cùng đón Giáp Thìn – 2024!', N'<p><strong><em>Từ ngày&nbsp;12/12/2023&nbsp;đến ngày&nbsp;31/01/2024, MobiFone Tỉnh An Giang triển khai chương trình khuyến mại “</em>Mình cùng đón Giáp Thìn – 2024!”</strong>&nbsp;Khách hàng hòa mạng mới hoặc đăng ký mới/gia hạn bất kỳ gói cước&nbsp;Data nào của MobiFone trong thời gian diễn ra chương trình .</p><p>Chào đón Năm Mới Giáp Thìn 2024, MobiFone An Giang triển khai chương trình khuyến mại “Mình Cùng Đón Giáp Thìn 2024! ” từ ngày 12/12/2023 đến 31/01/2024 Khách hàng hòa mạng mới hoặc đăng ký mới/gia hạn bất kỳ gói cước&nbsp;Data&nbsp;nào của MobiFone trong thời gian diễn ra chương trình, như một lời chúc, một lời tri ân sâu sắc dành cho các khách hàng đã luôn tin yêu và đồng hành cùng MobiFone Tỉnh An Giang.</p><p>Theo đó, từ ngày từ ngày 12/12/2023 đến 31/01/2024, Khách hàng hòa mạng mới hoặc đăng ký mới/gia hạn bất kỳ gói cước&nbsp;data&nbsp;nào của MobiFone trong thời gian diễn ra chương trình có nhắn tin&nbsp;sms&nbsp;tới số thuê bao 0779249999 kèm số dự đoán gần đúng nhất của 03 số cuối kết quả Giải đặc biệt Xổ số Kiến thiết tỉnh An Giang xổ ngày 01/02/2024.</p><p>Ví dụ: Thuê bao phát triển mới ngày 15/12/2023 soạn tin nhắn: 678 gởi đến 0779249999.</p><ul><li>Sau khi nhắn tin tham gia chương trình thành công, khách hàng sẽ nhận lại được tin nhắn xác nhận đã đăng ký thành công – chậm nhất ngày n+1</li><li>Mỗi khách hàng chỉ được tham dự 01 mã dự thưởng cho 1 số thuê bao (gồm thuê bao trả trước hoặc thuê bao trả sau)</li><li>Kết quả trúng thưởng được căn cứ vào dự đoán của khách hàng có số gần đúng với 03 số cuối (trường hợp giống kết quả sẽ xét thời gian sớm hơn) của Giải đặc biết Xổ số Kiến thiết tỉnh An Giang ngày 01/02/2024</li><li>Giải thưởng:</li></ul><p><strong>Giải thưởngSố lượngQuà tặng</strong>Giải Nhất0101 chỉ vàng&nbsp;9999Giải Nhì20Thẻ cào mệnh giá 100.000 đồngGiải Ba24Thẻ cào mệnh giá 50.000 đồngGiải Khuyến khích10001 hộp khẩu trang y tế</p><ul><li>Danh sách trúng giải sẽ được công bố trên trang fanpage của MobiFone Tỉnh An Giang, đường link:&nbsp;<a href="https://www.facebook.com/mobifonetinhangiang" target="_blank" style="color: rgb(10, 10, 10); background-color: transparent;">https://www.facebook.com/mobifonetinhangiang</a></li><li>Thời gian trao giải chậm nhất đến ngày 8/2/2024</li></ul><p>Gọi 0779 24 9999 hoặc 9090 để biết thêm thông tin chi tiết.</p>', N'Image_2024-4-8_12-19-24.jpeg', 6, CAST(N'2024-04-08T12:10:23.900' AS DateTime))
INSERT [dbo].[TinTuc] ([id], [tieuDe], [noiDung], [image], [nguoiViet], [created_at]) VALUES (5, N'DATA NHÓM THẢ GA – NHẬN 200GB QUÁ ĐÃ', N'<p><span style="color: rgb(0, 0, 0);">Nếu như bạn thường xuyên đi chơi cùng hội bạn bè, đi du lịch xa cùng với các thành viên trong gia đình thì để có thể giúp bạn tiết kiệm trong việc sử dụng 4G, thay vì từng thành viên đăng ký thì giờ đây nhờ những gói data nhóm, người dùng hoàn toàn có thể chia sẻ dung lượng truy cập 4G cho các thuê bao khác</span></p><p><img src="https://mobifoneangiang.com/wp-content/uploads/2023/11/combo_mfy_mfy200_CHOT2-01-1-1024x556.png" height="556" width="1024"></p><p>Hiện tại, MobiFone đem đến cho khách hàng nhiều gói cước nhóm với chi phí hợp lý tùy theo nhu cầu sử dụng. Các gói cước mFamily của MobiFone đem lại nhiều ưu điểm nổi trội như:</p><ul><li>Chi phí tiết kiệm cho gói nhóm, có thể phân bổ hạn mức theo nhu cầu sử dụng của từng thuê bao.</li><li>Thanh toán chỉ 1 lần duy nhất, tiện lợi và dễ dàng quản lý theo nhóm.</li><li>Ngoài ra còn miễn phí gọi không giới hạn nội nhóm.</li></ul><p>Đặc biệt, các gói cước MFY200, MFY với ưu đãi data khủng lên đến 400GB/tháng, miễn phí truy cập Facebook, YouTube là lựa chọn phù hợp cho những khách hàng có nhu cầu sử dụng lưu lượng lớn data hàng ngày.</p><p>Gói cước áp dụng với thuê bao trả trước, trả sau phát triển mới từ 01/6/2023. Hoặc thuê bao trả trước, trả sau hiện hữu theo danh sách quy định.</p><p>Gói cước cho phép chia sẻ tới 05 thuê bao (bao gồm 01 thuê bao trưởng nhóm và 04 thuê bao thành viên khác)</p><p>Chi tiết các gói cước như sau:</p><p><img src="https://mobifoneangiang.com/wp-content/uploads/2023/11/Poster_mfy_chot-02-1-682x1024.png" height="1024" width="682"></p><p><img src="https://mobifoneangiang.com/wp-content/uploads/2023/11/Postermfy200_CHOT-04-682x1024.png" height="1024" width="682"></p><ul><li><br></li></ul><p>Để đăng ký gói cước, soạn tin:&nbsp;<strong>DK Tên gói cước</strong>&nbsp;&nbsp;<strong>0799980067</strong>&nbsp;gửi&nbsp;<strong>909</strong></p><p>Để chia sẻ gói cước cho thành viên, soạn tin&nbsp;<strong>ADM</strong>&nbsp;<strong>MFY Số thuê bao thành viên&nbsp;</strong>gửi<strong>&nbsp;999</strong></p><p>(Phí thành viên:&nbsp;<strong>15.000 đ/thuê bao/30 ngày</strong>, trừ vào Tài khoản chính của thuê bao trưởng nhóm).</p><p>Mọi thông tin chi tiết vui lòng liên hệ hotline 0779 24 9999.</p><p><br></p>', N'Image_2024-4-8_12-16-8.png', 6, CAST(N'2024-04-08T12:16:19.663' AS DateTime))
INSERT [dbo].[TinTuc] ([id], [tieuDe], [noiDung], [image], [nguoiViet], [created_at]) VALUES (6, N'🕊CHÚC MỪNG NGÀY BÁO CHÍ VIỆT NAM 🕊', N'<p>🌹 Nhân kỷ niệm 98 năm Ngày Báo chí cách mạng Việt Nam (21/06/1925-21/06/2023) 🌹</p><p>MobiFone An Giang xin gửi tới các Nhà Báo, Phóng Viên, Biên Tập Viên, những người làm việc trong ngành truyền thông báo chí lời chúc sức khỏe, hạnh phúc, thành công và luôn giữ mãi nhiệt huyết trong sự nghiệp xây dựng nền làm việc trong ngành truyền thông báo chí lời chúc sức khỏe, hạnh phúc, thành công và luôn giữ mãi nhiệt huyết trong sự nghiệp xây dựng nền báo chí Việt Nam.</p><p>🌼MobiFone An Giang xin chân thành cảm ơn Quý đơn vị đã luôn tin tưởng và đồng hành cùng chúng tôi trong suốt quá trình hoạt động và phát triển của MobiFone.</p><p>🌼 Kính chúc Quý đơn vị ngày càng phát triển và cống hiến hết mình cho ngành Báo chí Việt Nam.</p><p>Trân trọng.🥳🥳</p><p><img src="https://mobifoneangiang.com/wp-content/uploads/2023/06/z4450415407841_001828538064ae5b396b5a2cd3e830d6-1024x1024.jpg" height="1024" width="1024"></p><p><br></p>', N'Image_2024-4-8_12-22-14.jpeg', 6, CAST(N'2024-04-08T12:22:15.520' AS DateTime))
INSERT [dbo].[TinTuc] ([id], [tieuDe], [noiDung], [image], [nguoiViet], [created_at]) VALUES (9, N'MOBIFIBER – Internet cáp quang tốc độ cao -Tăng tốc bứt phá MOBIFIBER – Internet cáp quang tốc độ cao', N'<p>Mobi Fiber là dịch vụ Internet cáp quang sử dụng công nghệ NGPDKG1 và XGSPDKG1 hiện đại nhất với đường truyền dẫn hoàn toàn bằng cáp quang đến địa chỉ thuê bao. Dịch vụ này giúp khách hàng sử dụng đa dịch vụ trên mạng viễn thông chất lượng cao, kể cả dịch vụ truyền hình giải trí.</p><h3><strong>Đối tượng được tham gia DV MobiFiber</strong></h3><p>Hiện Mobi Fiber áp dụng cho đối tượng khách hàng là các hộ gia đình, các doanh nghiệp vừa và nhỏ tại các tòa nhà, khu chung cư, khu đô thị mới, khu công nghiệp tại các tỉnh/thành phố lớn trên cả nước.</p><h3>Các tính năng chính của dịch vụ</h3><ul><li>Đường truyền có tốc độ ổn định, tốc độ truy cập Internet cao.</li><li>Không bị suy hao tín hiệu bởi nhiễu điện từ, thời tiết hay chiều dài cáp.</li><li>An toàn cho thiết bị, không sợ sét đánh lan truyền trên đường dây.</li><li>Nâng cấp băng thông dễ dàng mà không cần kéo cáp mới.</li></ul><p><strong>GÓI CƯỚC INTERNET CÁP QUANG</strong></p><p><img src="https://mobifoneangiang.com/wp-content/uploads/2023/05/330867443_715095633450814_3369716648912001108_n-1-1024x1007.jpg" height="1007" width="1024"></p><p>___________________</p><p>MOBIFONE TỈNH AN GIANG</p><p>“Kênh thông tin hỗ trợ khách hàng tại An Giang”</p><p>Hotline: 077 924 9999</p><p>Website:&nbsp;<a href="http://mobifoneangiang.com/" target="_blank" style="color: rgb(10, 10, 10); background-color: transparent;">mobifoneangiang.com</a></p><p>Fanpage:&nbsp;<a href="https://www.facebook.com/mobifoneangiang" target="_blank" style="color: rgb(10, 10, 10); background-color: transparent;">https://www.facebook.com/mobifoneangiang</a></p>', N'Image_2024-4-8_12-28-34.jpeg', 6, CAST(N'2024-04-08T12:28:36.017' AS DateTime))
SET IDENTITY_INSERT [dbo].[TinTuc] OFF
GO
SET IDENTITY_INSERT [dbo].[TuyenDung] ON 

INSERT [dbo].[TuyenDung] ([id], [title], [noiDung], [linkGoogleForm], [image], [created_at]) VALUES (6, N'NHÂN VIÊN BÁN HÀNG – CHĂM SÓC KHÁCH HÀNG', N'<p><span style="background-color: rgb(249, 249, 249); color: rgb(0, 0, 0);">💼 Nơi Làm việc : tại các huyện tại An Giang</span></p><p>II<span style="background-color: rgb(249, 249, 249); color: rgb(0, 0, 0);">./.HỒ SƠ DỰ TUYỂN</span></p><p>–<span style="background-color: rgb(249, 249, 249); color: rgb(0, 0, 0);"> Tất cả giấy tờ trong hồ sơ được chính quyền địa phương chứng thực trong thời gian không quá 6 tháng tính đến ngày nộp</span></p><p><br></p><p><span style="background-color: rgb(249, 249, 249); color: rgb(0, 0, 0);">– Bìa hồ sơ ghi rõ: Vị trí dự tuyển, số điện thoại, địa bàn dự tuyển, kênh nhận thông tin tuyển dụng (từ trang web, thông báo tại các trường, facebook,…)</span></p><p><span style="background-color: rgb(249, 249, 249); color: rgb(0, 0, 0);">– 01 đơn xin dự tuyển viết tay (nêu rõ vị trí dự tuyển, quá trình công tác, kinh nghiệm của bản thân)</span></p><p><span style="background-color: rgb(249, 249, 249); color: rgb(0, 0, 0);">– Bản sao các văn bằng, chứng chỉ. (Chấp nhận Giấy chứng nhận tốt nghiệp tạm thời đối với ứng viên đang chờ nhận bằng tốt nghiệp chính thức)</span></p><p><span style="background-color: rgb(249, 249, 249); color: rgb(0, 0, 0);">– 01 Bản gốc Sơ yếu lý lịch có dán ảnh và đóng dấu giáp lai theo quy định;</span></p><p><span style="background-color: rgb(249, 249, 249); color: rgb(0, 0, 0);">– 01 Bản sao giấy chứng nhận sức khoẻ;</span></p><p>–<span style="background-color: rgb(249, 249, 249); color: rgb(0, 0, 0);"> 01 Bản sao Sổ hộ khẩu, chứng minh thư nhân dân;</span></p><p>–<span style="background-color: rgb(249, 249, 249); color: rgb(0, 0, 0);"> 02 ảnh 3×4 mới nhất.</span></p><p><span style="background-color: rgb(249, 249, 249); color: rgb(0, 0, 0);">III./.NHẬN HỒ SƠ</span></p><p><span style="background-color: rgb(249, 249, 249); color: rgb(0, 0, 0);">Nơi nhận hồ sơ: Nộp trực tiếp tại Tòa Nhà Mobifone An Giang hoặc</span></p><p><span style="background-color: rgb(249, 249, 249); color: rgb(0, 0, 0);">Đường bưu điện : Tòa nhà MobiFone An Giang – số 93 Trần Hưng Đạo, phường Mỹ Quý, Tp.Long Xuyên, tỉnh An Giang</span></p><p><span style="background-color: rgb(249, 249, 249); color: rgb(0, 0, 0);">Email : mobifoneaglx@gmail.com</span></p>', N'https://docs.google.com/forms/d/e/1FAIpQLSfnVP6Ep5VDEkfsI7x4shYGZV495WP8yso8i4bccwpzOcG1ZA/viewform', N'Image_2024-4-8_12-50-17.png', CAST(N'2024-04-08T12:47:00.393' AS DateTime))
INSERT [dbo].[TuyenDung] ([id], [title], [noiDung], [linkGoogleForm], [image], [created_at]) VALUES (7, N'NHÂN VIÊN KHÁCH HÀNG DOANH NGHIỆP NHÂN VIÊN GIẢI PHÁP CNTT', N'<p><span style="background-color: rgb(249, 249, 249); color: rgb(0, 0, 0);">⏰ Nhận hồ sơ: Từ ngày thông báo đến hết ngày 25/11/2023</span></p><p><span style="background-color: rgb(249, 249, 249); color: rgb(0, 0, 0);">💼 Nơi Làm việc : Long Xuyên và các huyện tại An Giang</span></p><p>II<span style="background-color: rgb(249, 249, 249); color: rgb(0, 0, 0);">./.HỒ SƠ DỰ TUYỂN</span></p><p>–<span style="background-color: rgb(249, 249, 249); color: rgb(0, 0, 0);"> Tất cả giấy tờ trong hồ sơ được chính quyền địa phương chứng thực trong thời gian không quá 6 tháng tính đến ngày nộp.</span></p><p><span style="background-color: rgb(249, 249, 249); color: rgb(0, 0, 0);">– Bìa hồ sơ ghi rõ: Vị trí dự tuyển, số điện thoại, địa bàn dự tuyển, kênh nhận thông tin tuyển dụng (từ trang web, thông báo tại các trường, facebook,…)</span></p><p><span style="background-color: rgb(249, 249, 249); color: rgb(0, 0, 0);">– 01 đơn xin dự tuyển viết tay (nêu rõ vị trí dự tuyển, quá trình công tác, kinh nghiệm của bản thân)</span></p><p><span style="background-color: rgb(249, 249, 249); color: rgb(0, 0, 0);">– Bản sao các văn bằng, chứng chỉ. (Chấp nhận Giấy chứng nhận tốt nghiệp tạm thời đối với ứng viên đang chờ nhận bằng tốt nghiệp chính thức)</span></p><p><span style="background-color: rgb(249, 249, 249); color: rgb(0, 0, 0);">– 01 Bản gốc Sơ yếu lý lịch có dán ảnh và đóng dấu giáp lai theo quy định;</span></p><p><span style="background-color: rgb(249, 249, 249); color: rgb(0, 0, 0);">– 01 Bản sao giấy chứng nhận sức khoẻ;</span></p><p>–<span style="background-color: rgb(249, 249, 249); color: rgb(0, 0, 0);"> 01 Bản sao Sổ hộ khẩu, chứng minh thư nhân dân;</span></p><p>–<span style="background-color: rgb(249, 249, 249); color: rgb(0, 0, 0);"> 02 ảnh 3×4 mới nhất.</span></p><p><span style="background-color: rgb(249, 249, 249); color: rgb(0, 0, 0);">III./.NHẬN HỒ SƠ</span></p><p><span style="background-color: rgb(249, 249, 249); color: rgb(0, 0, 0);">Nơi nhận hồ sơ: Nộp trực tiếp tại Tòa Nhà Mobifone An Giang hoặc</span></p><p><span style="background-color: rgb(249, 249, 249); color: rgb(0, 0, 0);">Đường bưu điện : Tòa nhà MobiFone An Giang – số 93 Trần Hưng Đạo, phường Mỹ Quý, Tp.Long Xuyên, tỉnh An Giang</span></p><p><span style="background-color: rgb(249, 249, 249); color: rgb(0, 0, 0);">Email : mobifoneaglx@gmail.com</span></p>', N'https://docs.google.com/forms/d/e/1FAIpQLSfnVP6Ep5VDEkfsI7x4shYGZV495WP8yso8i4bccwpzOcG1ZA/viewform', N'Image_2024-4-8_12-49-36.png', CAST(N'2024-04-08T12:49:59.550' AS DateTime))
SET IDENTITY_INSERT [dbo].[TuyenDung] OFF
GO
ALTER TABLE [dbo].[GioiThieu] ADD  CONSTRAINT [DF_GioiThieu_created_at]  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[GoiCuoc] ADD  CONSTRAINT [DF_GoiCuoc_created_at]  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[HoaDonXuat] ADD  CONSTRAINT [DF_HoaDonXuat_created_at]  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[LienHe] ADD  CONSTRAINT [DF_LienHe_created_at]  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[nhanVien] ADD  CONSTRAINT [DF_nhanVien_created_at]  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[SimSo] ADD  CONSTRAINT [DF_SimSo_created_at]  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[ThongTinGoiCuoc] ADD  CONSTRAINT [DF_ThongTinGoiCuoc_created_at]  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[TinTuc] ADD  CONSTRAINT [DF_TinTuc_created_at]  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[TuyenDung] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_HoaDonXuat] FOREIGN KEY([hoaDon_id])
REFERENCES [dbo].[HoaDonXuat] ([id])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_HoaDonXuat]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_SimSo] FOREIGN KEY([simSo_id])
REFERENCES [dbo].[SimSo] ([id])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_SimSo]
GO
ALTER TABLE [dbo].[nhanVien]  WITH CHECK ADD  CONSTRAINT [FK_nhanVien_TaiKhoan] FOREIGN KEY([taiKhoan_id])
REFERENCES [dbo].[TaiKhoan] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[nhanVien] CHECK CONSTRAINT [FK_nhanVien_TaiKhoan]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoan_Role] FOREIGN KEY([role_id])
REFERENCES [dbo].[Role] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK_TaiKhoan_Role]
GO
ALTER TABLE [dbo].[ThongTinGoiCuoc]  WITH CHECK ADD  CONSTRAINT [FK_ThongTinGoiCuoc_GoiCuoc] FOREIGN KEY([goiCuoc_id])
REFERENCES [dbo].[GoiCuoc] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ThongTinGoiCuoc] CHECK CONSTRAINT [FK_ThongTinGoiCuoc_GoiCuoc]
GO
ALTER TABLE [dbo].[TinTuc]  WITH CHECK ADD  CONSTRAINT [FK_TinTuc_nhanVien] FOREIGN KEY([nguoiViet])
REFERENCES [dbo].[nhanVien] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TinTuc] CHECK CONSTRAINT [FK_TinTuc_nhanVien]
GO
USE [master]
GO
ALTER DATABASE [DATN_Mobifone] SET  READ_WRITE 
GO
