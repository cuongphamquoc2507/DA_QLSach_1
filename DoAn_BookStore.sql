USE [master]
GO
/****** Object:  Database [DoAn_bookstore]    Script Date: 9/5/2022 8:37:00 PM ******/
CREATE DATABASE [DoAn_bookstore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DoAn_bookstore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DoAn_bookstore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DoAn_bookstore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DoAn_bookstore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DoAn_bookstore] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DoAn_bookstore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DoAn_bookstore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DoAn_bookstore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DoAn_bookstore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DoAn_bookstore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DoAn_bookstore] SET ARITHABORT OFF 
GO
ALTER DATABASE [DoAn_bookstore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DoAn_bookstore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DoAn_bookstore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DoAn_bookstore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DoAn_bookstore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DoAn_bookstore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DoAn_bookstore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DoAn_bookstore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DoAn_bookstore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DoAn_bookstore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DoAn_bookstore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DoAn_bookstore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DoAn_bookstore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DoAn_bookstore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DoAn_bookstore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DoAn_bookstore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DoAn_bookstore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DoAn_bookstore] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DoAn_bookstore] SET  MULTI_USER 
GO
ALTER DATABASE [DoAn_bookstore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DoAn_bookstore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DoAn_bookstore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DoAn_bookstore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DoAn_bookstore] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DoAn_bookstore] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DoAn_bookstore] SET QUERY_STORE = OFF
GO
USE [DoAn_bookstore]
GO
/****** Object:  Table [dbo].[CtHoaDon]    Script Date: 9/5/2022 8:37:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CtHoaDon](
	[IDHoaDon] [int] NOT NULL,
	[MaSach] [int] NOT NULL,
	[Sluong] [int] NOT NULL,
	[TongTien] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonHang_1]    Script Date: 9/5/2022 8:37:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHang_1](
	[IDHoaDon] [int] IDENTITY(1,1) NOT NULL,
	[NgayDat] [datetime] NOT NULL,
	[TinhTrang] [nvarchar](50) NOT NULL,
	[IDKhachHang] [int] NOT NULL,
 CONSTRAINT [PK_DonHang_1] PRIMARY KEY CLUSTERED 
(
	[IDHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 9/5/2022 8:37:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[IDKhachHang] [int] IDENTITY(1,1) NOT NULL,
	[TenKH] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[DiaChi] [nvarchar](50) NOT NULL,
	[SoDT] [nchar](10) NOT NULL,
	[MatKhau] [nchar](10) NOT NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[IDKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sach]    Script Date: 9/5/2022 8:37:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sach](
	[MaSach] [int] IDENTITY(1,1) NOT NULL,
	[MaTG] [int] NOT NULL,
	[TenSach] [nvarchar](1000) NOT NULL,
	[anh] [nvarchar](100) NOT NULL,
	[Mota] [nvarchar](100) NOT NULL,
	[Gia] [int] NOT NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK_Sach] PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TacGia]    Script Date: 9/5/2022 8:37:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TacGia](
	[MaTG] [int] IDENTITY(1,1) NOT NULL,
	[TenTG] [nvarchar](50) NOT NULL,
	[Anh] [nvarchar](1000) NULL,
	[Ngaysinh] [nvarchar](20) NULL,
	[Quequan] [nvarchar](100) NULL,
	[Tieusu] [nvarchar](1000) NULL,
 CONSTRAINT [PK_TacGia] PRIMARY KEY CLUSTERED 
(
	[MaTG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 9/5/2022 8:37:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[MaTK] [int] IDENTITY(1,1) NOT NULL,
	[TenDN] [nvarchar](20) NOT NULL,
	[MatKhau] [nvarchar](20) NOT NULL,
	[PhanQuyen] [nvarchar](20) NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[MaTK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([IDKhachHang], [TenKH], [Email], [DiaChi], [SoDT], [MatKhau]) VALUES (1, N'Phạm Cường', N'pqc2507@gmail.com', N'Thái Bình', N'098765    ', N'1234      ')
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
GO
SET IDENTITY_INSERT [dbo].[Sach] ON 

INSERT [dbo].[Sach] ([MaSach], [MaTG], [TenSach], [anh], [Mota], [Gia], [SoLuong]) VALUES (2, 1, N'TẬP VIẾT TIẾNG ANH LỚP 2 (THEO CHƯƠNG TRÌNH GIÁO DỤC PHỔ THÔNG MỚI)', N'anh1.jpg', N'Sách học tập', 21000, 100)
INSERT [dbo].[Sach] ([MaSach], [MaTG], [TenSach], [anh], [Mota], [Gia], [SoLuong]) VALUES (3, 2, N'TẠO LẬP MÔI TRƯỜNG SỐNG ĐỊNH HÌNH NHÂN CÁCH VỊ THÀNH NIÊN - TẬP 2.', N'sach-tao-lap-moi-truong-song-dinh-hinh-nhan-cach-vi-thanh-nien-tap-2.jpg', N'Sách kĩ năng sống', 65600, 100)
INSERT [dbo].[Sach] ([MaSach], [MaTG], [TenSach], [anh], [Mota], [Gia], [SoLuong]) VALUES (4, 3, N'TRUYỆN KIỀU - VĂN HỌC VIỆT NAM THẾ KỶ XIX', N'sach-truyen-kieu-van-hoc-viet-nam-the-ky-xix.jpg', N'Truyện', 33600, 90)
INSERT [dbo].[Sach] ([MaSach], [MaTG], [TenSach], [anh], [Mota], [Gia], [SoLuong]) VALUES (5, 4, N'PHOTO ESSAY "HẬU DUỆ MẶT TRỜI” (TẶNG KÈM 6 POSCARD CÓ CHỮ KÍ VÀ 1 POSTER ẢNH.', N'photo-essay-hau-due-mat-troi-tang-kem-6-postcard-co-chu-ki-va-1-poster-anh.jpg', N'Ngôn tình', 21900, 80)
INSERT [dbo].[Sach] ([MaSach], [MaTG], [TenSach], [anh], [Mota], [Gia], [SoLuong]) VALUES (7, 5, N'ĐẠI BÀNG CÓ KHI BAY THẤP HƠN GÀ.', N'kinang.jpg', N'Truyện ngụ ngôn', 46980, 90)
INSERT [dbo].[Sach] ([MaSach], [MaTG], [TenSach], [anh], [Mota], [Gia], [SoLuong]) VALUES (8, 3, N'HỌC TOÁN QUA TRUYỆN NGỤ NGÔN - GẤU VÀ ĐÀN ONG', N'gau_ong.jpg', N'Truyện ngụ ngôn', 30000, 100)
INSERT [dbo].[Sach] ([MaSach], [MaTG], [TenSach], [anh], [Mota], [Gia], [SoLuong]) VALUES (9, 4, N'HỌC TOÁN QUA TRUYỆN NGỤ NGÔN - GIỎ KHOAI', N'giokhoai.jpg', N'Sách học tập', 50000, 100)
INSERT [dbo].[Sach] ([MaSach], [MaTG], [TenSach], [anh], [Mota], [Gia], [SoLuong]) VALUES (10, 4, N'SINH TỒN MÙA COVID', N'sach-sinh-ton-cung-covid-19.jpg', N'Sách kĩ năng sống', 127000, 40)
INSERT [dbo].[Sach] ([MaSach], [MaTG], [TenSach], [anh], [Mota], [Gia], [SoLuong]) VALUES (11, 3, N'CHUYỂN ĐỔI TOÀN DIỆN MÔ HÌNH KINH DOANH', N'sach-chuyen-doi-toan-dien.jpg', N'Sách kinh doanh', 160000, 50)
INSERT [dbo].[Sach] ([MaSach], [MaTG], [TenSach], [anh], [Mota], [Gia], [SoLuong]) VALUES (12, 2, N'COMBO ĐỒNG DAO CHO BÉ', N'combo-đongao.jpg', N'Sách thiếu nhi', 80000, 60)
INSERT [dbo].[Sach] ([MaSach], [MaTG], [TenSach], [anh], [Mota], [Gia], [SoLuong]) VALUES (13, 2, N'STEAM FOR KIDS - TỚ THÍCH DU HÀNH VŨ TRỤ (3-6 TUỔI)', N'du_hanh.jpg', N'Sách thiếu nhi', 40000, 30)
INSERT [dbo].[Sach] ([MaSach], [MaTG], [TenSach], [anh], [Mota], [Gia], [SoLuong]) VALUES (16, 2, N'STEAM FOR KIDS - PHƯƠNG TIỆN GIAO THÔNG (6-14 TUỔI)', N'steam.jpg', N'Sách thiếu nhi', 70000, 100)
INSERT [dbo].[Sach] ([MaSach], [MaTG], [TenSach], [anh], [Mota], [Gia], [SoLuong]) VALUES (17, 3, N'COMBO CẨM NANG DÀNH CHO MẸ BẦU VÀ THAI NHI - PHẦN 2 (BỘ 3 CUỐN)', N'camnang.jpg', N'Sách Y Học & Thể Dục Thể Thao | Sách Thai Giáo', 191000, 50)
INSERT [dbo].[Sach] ([MaSach], [MaTG], [TenSach], [anh], [Mota], [Gia], [SoLuong]) VALUES (19, 3, N'NGƯỜI ĐÀN ÔNG TƯỞNG NHẦM VỢ MÌNH LÀ CÁI MŨ ', N'danong.jpg', N'Sách Tâm Lý | Sách Y Học & Thể Dục Thể Thao | Sách Y Học - Chăm Sóc Sức Khỏe', 160000, 50)
INSERT [dbo].[Sach] ([MaSach], [MaTG], [TenSach], [anh], [Mota], [Gia], [SoLuong]) VALUES (21, 3, N'KHỎE HƠN 10 TUỔI NHỜ UỐNG NƯỚC ĐÚNG CÁCH', N'khoe.jpg', N'Sách Y Học & Thể Dục Thể Thao | Sách Y Học - Chăm Sóc Sức Khỏe', 100000, 48)
INSERT [dbo].[Sach] ([MaSach], [MaTG], [TenSach], [anh], [Mota], [Gia], [SoLuong]) VALUES (22, 4, N' BÍ MẬT CUNG SƯ TỬ - CHIẾN THẮNG BẢN THÂN', N'sutu.jpg', N'Sách Khám Phá | Sách Thiếu Nhi | Truyện Tranh Thiếu Nhi | Sách Tuổi Teen', 30000, 32)
INSERT [dbo].[Sach] ([MaSach], [MaTG], [TenSach], [anh], [Mota], [Gia], [SoLuong]) VALUES (23, 4, N'BÍ MẬT CUNG CỰ GIẢI - THIẾT KẾ ƯỚC MƠ', N'cugiai.jpg', N'Sách Khám Phá | Sách Thiếu Nhi | Truyện Tranh Thiếu Nhi | Sách Tuổi Teen', 45000, 60)
INSERT [dbo].[Sach] ([MaSach], [MaTG], [TenSach], [anh], [Mota], [Gia], [SoLuong]) VALUES (24, 5, N'BỈ VỎ (BÔNG A)', N'bivo.jpg', N'Sách Văn Học | Sách Văn Học Việt Nam | Tiểu Thuyết', 30000, 100)
INSERT [dbo].[Sach] ([MaSach], [MaTG], [TenSach], [anh], [Mota], [Gia], [SoLuong]) VALUES (25, 5, N'TUYỂN TẬP TRUYỆN NGẮN TRÀO PHÚNG HAY NHẤT CỦA VÕ TÒNG ĐÁNH MÈO - TẬP 2', N'votong.jpg', N'Sách Văn Học | Truyện ngắn - Tản văn', 35000, 100)
SET IDENTITY_INSERT [dbo].[Sach] OFF
GO
SET IDENTITY_INSERT [dbo].[TacGia] ON 

INSERT [dbo].[TacGia] ([MaTG], [TenTG], [Anh], [Ngaysinh], [Quequan], [Tieusu]) VALUES (1, N'Lê Dũng', N'aa.jpg', N'25-01-1988', N'Thái Bình', NULL)
INSERT [dbo].[TacGia] ([MaTG], [TenTG], [Anh], [Ngaysinh], [Quequan], [Tieusu]) VALUES (2, N'Trang Anh', N'tacgia5.jpg', N'12-11-1976', N'Hà Nội', NULL)
INSERT [dbo].[TacGia] ([MaTG], [TenTG], [Anh], [Ngaysinh], [Quequan], [Tieusu]) VALUES (3, N'Duy Quang', N'tacgia3.jpg', N'01-02-1988', N'Hòa Bình', NULL)
INSERT [dbo].[TacGia] ([MaTG], [TenTG], [Anh], [Ngaysinh], [Quequan], [Tieusu]) VALUES (4, N'Trần Thị Yến', N'sale-removebg-preview.png', N'3-5-1977', N'Lào Cai', NULL)
INSERT [dbo].[TacGia] ([MaTG], [TenTG], [Anh], [Ngaysinh], [Quequan], [Tieusu]) VALUES (5, N'Ths. Trương Ngọc Thơi', N'tacgia5.jpg', N'19-10-1975', N'Vĩnh Phúc', NULL)
INSERT [dbo].[TacGia] ([MaTG], [TenTG], [Anh], [Ngaysinh], [Quequan], [Tieusu]) VALUES (6, N'Lê Chi', N'tacgia6.jpg', N'22-10-1990', N'Hải Phòng', NULL)
INSERT [dbo].[TacGia] ([MaTG], [TenTG], [Anh], [Ngaysinh], [Quequan], [Tieusu]) VALUES (7, N'Nguyễn Thị Kim Lan ', N'cart.png', N'01-02-1988', N'Thái BÌnh', NULL)
SET IDENTITY_INSERT [dbo].[TacGia] OFF
GO
SET IDENTITY_INSERT [dbo].[TaiKhoan] ON 

INSERT [dbo].[TaiKhoan] ([MaTK], [TenDN], [MatKhau], [PhanQuyen]) VALUES (1, N'Cuong', N'1234', N'admin')
SET IDENTITY_INSERT [dbo].[TaiKhoan] OFF
GO
ALTER TABLE [dbo].[CtHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_CtHoaDon_DonHang_1] FOREIGN KEY([IDHoaDon])
REFERENCES [dbo].[DonHang_1] ([IDHoaDon])
GO
ALTER TABLE [dbo].[CtHoaDon] CHECK CONSTRAINT [FK_CtHoaDon_DonHang_1]
GO
ALTER TABLE [dbo].[CtHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_CtHoaDon_Sach] FOREIGN KEY([IDHoaDon])
REFERENCES [dbo].[Sach] ([MaSach])
GO
ALTER TABLE [dbo].[CtHoaDon] CHECK CONSTRAINT [FK_CtHoaDon_Sach]
GO
ALTER TABLE [dbo].[DonHang_1]  WITH CHECK ADD  CONSTRAINT [FK_DonHang_1_KhachHang] FOREIGN KEY([IDKhachHang])
REFERENCES [dbo].[KhachHang] ([IDKhachHang])
GO
ALTER TABLE [dbo].[DonHang_1] CHECK CONSTRAINT [FK_DonHang_1_KhachHang]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_TacGia] FOREIGN KEY([MaTG])
REFERENCES [dbo].[TacGia] ([MaTG])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_TacGia]
GO
USE [master]
GO
ALTER DATABASE [DoAn_bookstore] SET  READ_WRITE 
GO
