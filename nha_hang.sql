USE [NHAHANG]
GO
/****** Object:  Table [dbo].[BAN_AN]    Script Date: 9/19/2020 1:42:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BAN_AN](
	[MaBan] [int] IDENTITY(1,1) NOT NULL,
	[SoGhe] [int] NULL,
	[BanSo] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHITIETHD]    Script Date: 9/19/2020 1:42:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETHD](
	[MaHD] [int] NOT NULL,
	[MaMon] [int] NOT NULL,
	[SoLuong] [int] NULL,
	[DonGia] [money] NULL,
	[ThanhTien] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC,
	[MaMon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHUCVU]    Script Date: 9/19/2020 1:42:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHUCVU](
	[MaCV] [int] IDENTITY(1,1) NOT NULL,
	[TenCV] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaCV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HOADON]    Script Date: 9/19/2020 1:42:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOADON](
	[MaHD] [int] IDENTITY(1,1) NOT NULL,
	[NgayLap] [datetime] NULL,
	[MaKH] [int] NOT NULL,
	[MaBan] [int] NOT NULL,
	[MaNV] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 9/19/2020 1:42:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[MaKH] [int] IDENTITY(1,1) NOT NULL,
	[TenKH] [nvarchar](100) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[SDT] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAIMON]    Script Date: 9/19/2020 1:42:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAIMON](
	[MaLoaiMon] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiMon] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLoaiMon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MONAN]    Script Date: 9/19/2020 1:42:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MONAN](
	[MaMon] [int] IDENTITY(1,1) NOT NULL,
	[TenMon] [nvarchar](100) NULL,
	[DonViTinh] [nvarchar](50) NULL,
	[DonGia] [money] NULL,
	[MoTa] [nvarchar](200) NULL,
	[HinhAnh] [varchar](100) NULL,
	[MaLoaiMon] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaMon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 9/19/2020 1:42:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[MaNV] [int] IDENTITY(1,1) NOT NULL,
	[TenNV] [nvarchar](100) NULL,
	[NgaySinh] [datetime] NULL,
	[DiaChi] [nvarchar](100) NULL,
	[SDT] [varchar](15) NULL,
	[UserName] [varchar](50) NULL,
	[PassWork] [varchar](50) NULL,
	[MaCV] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BAN_AN] ON 

INSERT [dbo].[BAN_AN] ([MaBan], [SoGhe], [BanSo]) VALUES (1, 10, N'30')
INSERT [dbo].[BAN_AN] ([MaBan], [SoGhe], [BanSo]) VALUES (2, 5, N'1')
INSERT [dbo].[BAN_AN] ([MaBan], [SoGhe], [BanSo]) VALUES (3, 4, N'2')
INSERT [dbo].[BAN_AN] ([MaBan], [SoGhe], [BanSo]) VALUES (4, 4, N'3')
INSERT [dbo].[BAN_AN] ([MaBan], [SoGhe], [BanSo]) VALUES (5, 6, N'4')
INSERT [dbo].[BAN_AN] ([MaBan], [SoGhe], [BanSo]) VALUES (6, 8, N'10')
INSERT [dbo].[BAN_AN] ([MaBan], [SoGhe], [BanSo]) VALUES (8, 5, N'33')
SET IDENTITY_INSERT [dbo].[BAN_AN] OFF
SET IDENTITY_INSERT [dbo].[CHUCVU] ON 

INSERT [dbo].[CHUCVU] ([MaCV], [TenCV]) VALUES (1, N'Boss')
INSERT [dbo].[CHUCVU] ([MaCV], [TenCV]) VALUES (2, N'QUẢN LÍ')
INSERT [dbo].[CHUCVU] ([MaCV], [TenCV]) VALUES (3, N'KÊ TOÁN')
INSERT [dbo].[CHUCVU] ([MaCV], [TenCV]) VALUES (4, N'BỒI BÀN')
INSERT [dbo].[CHUCVU] ([MaCV], [TenCV]) VALUES (5, N'Tạp Vụ')
INSERT [dbo].[CHUCVU] ([MaCV], [TenCV]) VALUES (18, N'bảo vệ')
INSERT [dbo].[CHUCVU] ([MaCV], [TenCV]) VALUES (24, N'Thu Ngân')
SET IDENTITY_INSERT [dbo].[CHUCVU] OFF
SET IDENTITY_INSERT [dbo].[KHACHHANG] ON 

INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [DiaChi], [SDT]) VALUES (1, N'Nguyễn Thị Kim Thoa', N'Quận 10', N'03654829521')
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [DiaChi], [SDT]) VALUES (2, N'Đặng Kim Ngân', N'q9', N'0365259685')
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [DiaChi], [SDT]) VALUES (4, N'Bùi Minh Thuận', N'Q9', N'111111')
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [DiaChi], [SDT]) VALUES (5, N'khách lẻ', N'      ', N'111111')
SET IDENTITY_INSERT [dbo].[KHACHHANG] OFF
SET IDENTITY_INSERT [dbo].[LOAIMON] ON 

INSERT [dbo].[LOAIMON] ([MaLoaiMon], [TenLoaiMon]) VALUES (2, N'Mì Cay')
INSERT [dbo].[LOAIMON] ([MaLoaiMon], [TenLoaiMon]) VALUES (3, N'Lẩu Mì Cay')
INSERT [dbo].[LOAIMON] ([MaLoaiMon], [TenLoaiMon]) VALUES (6, N'Trà Sữa')
INSERT [dbo].[LOAIMON] ([MaLoaiMon], [TenLoaiMon]) VALUES (8, N'Nước Uống')
SET IDENTITY_INSERT [dbo].[LOAIMON] OFF
SET IDENTITY_INSERT [dbo].[MONAN] ON 

INSERT [dbo].[MONAN] ([MaMon], [TenMon], [DonViTinh], [DonGia], [MoTa], [HinhAnh], [MaLoaiMon]) VALUES (1, N'MÌ KIM CHI BÒ', N'phần', 490000.0000, N'Mì Chinnoo, bò, cá viên, xúc xích, nấm kim châm, kim chi, bắp cải tím, bông cải xanh.', N'~/images/sanpham/11-9619.png', 2)
INSERT [dbo].[MONAN] ([MaMon], [TenMon], [DonViTinh], [DonGia], [MoTa], [HinhAnh], [MaLoaiMon]) VALUES (3, N'MÌ KIM CHI GÀ', N'tô', 49000.0000, N'Mì Chinnoo, gà, nấm kim châm, kim chi, bắp cải tím, bông cải xanh.', N'~/images/sanpham/12-6665.png', 2)
INSERT [dbo].[MONAN] ([MaMon], [TenMon], [DonViTinh], [DonGia], [MoTa], [HinhAnh], [MaLoaiMon]) VALUES (4, N'MÌ KIM CHI BÒ MỸ', N'phần', 49000.0000, N'Mì Chinnoo, bod Mỹ, xúc xích, cá viên, nấm kim châm, kim chi, bắp cải tím, bông cải xanh.', N'~/images/sanpham/16-5999.png', 2)
INSERT [dbo].[MONAN] ([MaMon], [TenMon], [DonViTinh], [DonGia], [MoTa], [HinhAnh], [MaLoaiMon]) VALUES (5, N'MÌ KIM CHI CÁ', N'phần', 49000.0000, N'Mì Chinnoo, tôm, mực, cá viên, nấm kim châm, kim chi, bắp cải tím, bông cải xanh.', N'~/images/sanpham/10-9569.png', 2)
INSERT [dbo].[MONAN] ([MaMon], [TenMon], [DonViTinh], [DonGia], [MoTa], [HinhAnh], [MaLoaiMon]) VALUES (7, N'MÌ KIM CHI HẢI SẢN', N'phần', 49000.0000, N'Mì Chinnoo, tôm, mực, cá viên, nấm kim châm, kim chi, bắp cải tím, bông cải xanh.', N'~/images/sanpham/9-2997.png', 2)
INSERT [dbo].[MONAN] ([MaMon], [TenMon], [DonViTinh], [DonGia], [MoTa], [HinhAnh], [MaLoaiMon]) VALUES (8, N'LẨU TOMYUM BÒ (2 NGƯỜI)', N'phần', 169000.0000, N'Thịt bò, cá viên, trứng, nấm kim châm, kim chi, bắp cải tím, bông cải xanh với nước lẩu Tomyum ăn kèm với mì Chinnoo.', N'~/images/sanpham/18-2821.png', 3)
INSERT [dbo].[MONAN] ([MaMon], [TenMon], [DonViTinh], [DonGia], [MoTa], [HinhAnh], [MaLoaiMon]) VALUES (9, N'LẨU TOMYUM HẢI SẢN (2 NGƯỜI)', N'phần', 169000.0000, N'Tôm, mực, nghiêu, cá viên, nấm kim châm, kim chi, bắp cải tím, bông cải xanh với nước lẩu Tomyum ăn kèm với mì Chinnoo.', N'~/images/sanpham/19-8265.png', 3)
INSERT [dbo].[MONAN] ([MaMon], [TenMon], [DonViTinh], [DonGia], [MoTa], [HinhAnh], [MaLoaiMon]) VALUES (10, N'LẨU KIM CHI BÒ MỸ ( 4 NGƯỜI)', N'phần', 339000.0000, N'Bò Mỹ, trứng, cá viên, nấm kim châm, kim chi, bắp cải tím, bông cải xanh với nước lẩu kim chi ăn kèm với mì Chinnoo.', N'~/images/sanpham/21-3689.png', 3)
INSERT [dbo].[MONAN] ([MaMon], [TenMon], [DonViTinh], [DonGia], [MoTa], [HinhAnh], [MaLoaiMon]) VALUES (11, N'LẨU KIM CHI BÒ MỸ( 2 NGƯỜI)', N'phần', 169000.0000, N'Bò Mỹ, trứng, cá viên, nấm kim châm, kim chi, bắp cải tím, bông cải xanh với nước lẩu kim chi ăn kèm với mì Chinnoo.', N'~/images/sanpham/26-6163.png', 3)
INSERT [dbo].[MONAN] ([MaMon], [TenMon], [DonViTinh], [DonGia], [MoTa], [HinhAnh], [MaLoaiMon]) VALUES (12, N'STING LON', N'Lon', 20000.0000, N'', N'~/images/sanpham/62-416.png', 8)
INSERT [dbo].[MONAN] ([MaMon], [TenMon], [DonViTinh], [DonGia], [MoTa], [HinhAnh], [MaLoaiMon]) VALUES (13, N'PEPSI LON', N'Lon', 20000.0000, N'', N'~/images/sanpham/63-5652.png', 8)
INSERT [dbo].[MONAN] ([MaMon], [TenMon], [DonViTinh], [DonGia], [MoTa], [HinhAnh], [MaLoaiMon]) VALUES (14, N'7UP LON', N'Lon', 20000.0000, N'', N'~/images/sanpham/64-8894.png', 8)
INSERT [dbo].[MONAN] ([MaMon], [TenMon], [DonViTinh], [DonGia], [MoTa], [HinhAnh], [MaLoaiMon]) VALUES (15, N'REDBULL', N'Lon', 22000.0000, N'', N'~/images/sanpham/65-4136.png', 8)
SET IDENTITY_INSERT [dbo].[MONAN] OFF
SET IDENTITY_INSERT [dbo].[NHANVIEN] ON 

INSERT [dbo].[NHANVIEN] ([MaNV], [TenNV], [NgaySinh], [DiaChi], [SDT], [UserName], [PassWork], [MaCV]) VALUES (1, N'Nguyễn Thị Kim Thoa', CAST(N'1990-06-02T00:00:00.000' AS DateTime), N'q2', N'0366795684', N'thoa', N'', 3)
INSERT [dbo].[NHANVIEN] ([MaNV], [TenNV], [NgaySinh], [DiaChi], [SDT], [UserName], [PassWork], [MaCV]) VALUES (2, N'Khoa', CAST(N'1998-06-01T00:00:00.000' AS DateTime), N'q3', N'0365259685', N'', N'', 1)
INSERT [dbo].[NHANVIEN] ([MaNV], [TenNV], [NgaySinh], [DiaChi], [SDT], [UserName], [PassWork], [MaCV]) VALUES (3, N'bình', CAST(N'1987-06-24T00:00:00.000' AS DateTime), N'Q9', N'0366795684', N'', N'', 4)
INSERT [dbo].[NHANVIEN] ([MaNV], [TenNV], [NgaySinh], [DiaChi], [SDT], [UserName], [PassWork], [MaCV]) VALUES (7, N'Triệu Thị Thanh', CAST(N'2020-06-28T00:00:00.000' AS DateTime), N'q3', N'0984008508', N'thanh', N'123', 3)
INSERT [dbo].[NHANVIEN] ([MaNV], [TenNV], [NgaySinh], [DiaChi], [SDT], [UserName], [PassWork], [MaCV]) VALUES (8, N'kim kim ', CAST(N'2020-07-05T00:00:00.000' AS DateTime), N'q3', N'0365259685', N'kim', N'123', 1)
SET IDENTITY_INSERT [dbo].[NHANVIEN] OFF
ALTER TABLE [dbo].[CHITIETHD]  WITH CHECK ADD FOREIGN KEY([MaHD])
REFERENCES [dbo].[HOADON] ([MaHD])
GO
ALTER TABLE [dbo].[CHITIETHD]  WITH CHECK ADD FOREIGN KEY([MaMon])
REFERENCES [dbo].[MONAN] ([MaMon])
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD FOREIGN KEY([MaBan])
REFERENCES [dbo].[BAN_AN] ([MaBan])
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD FOREIGN KEY([MaKH])
REFERENCES [dbo].[KHACHHANG] ([MaKH])
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
GO
ALTER TABLE [dbo].[MONAN]  WITH CHECK ADD FOREIGN KEY([MaLoaiMon])
REFERENCES [dbo].[LOAIMON] ([MaLoaiMon])
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD FOREIGN KEY([MaCV])
REFERENCES [dbo].[CHUCVU] ([MaCV])
GO
