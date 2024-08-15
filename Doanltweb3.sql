Create Database Doanltweb3
use Doanltweb3


CREATE TABLE KhachHang (
    MaKH INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100),
    NgaySinh DATE,
    GioiTinh NVARCHAR(100),
    DienThoai NVARCHAR(15),
    Email NVARCHAR(100),
    DiaChi NVARCHAR(200),
    MatKhau NVARCHAR(100),
    VaiTro NVARCHAR(100)
);


CREATE TABLE LienHe (
    MaLienHe INT IDENTITY(1,1) PRIMARY KEY,
    Ten NVARCHAR(100),
    Gmail NVARCHAR(100),
    TinNhan NVARCHAR(500),
    MaKH INT,
    FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)
);
-- Tạo bảng NhaCungCap
CREATE TABLE NhaCungCap (
    MaNCC INT PRIMARY KEY,
    TenNCC NVARCHAR(100),
    DiaChi NVARCHAR(200),
    SDT NVARCHAR(15)
);

-- Tạo bảng LoaiHoa
CREATE TABLE LoaiHoa (
    MaLoai INT PRIMARY KEY,
    TenLoai NVARCHAR(100),
    MaNCC INT,
    SoLuong INT
);

-- Tạo bảng Hoa
CREATE TABLE Hoa (
    MaHoa INT PRIMARY KEY,
    TenHoa NVARCHAR(100),
    GiaBan DECIMAL(18, 2),
    MoTa NVARCHAR(500),
    Anh NVARCHAR(200),
    SoLuongTon INT,
    MaNCC INT,
    MaLoai INT,
    FOREIGN KEY (MaLoai) REFERENCES LoaiHoa(MaLoai),
    FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC)
);

-- Tạo bảng PhuongThucThanhToan
CREATE TABLE PhuongThucThanhToan (
    MaPhuongThuc INT PRIMARY KEY,
    HinhThuc NVARCHAR(100)
);

select * from PhuongThucThanhToan

-- Tạo bảng DonHang
CREATE TABLE DonHang (
    MaDonHang INT IDENTITY(1,1) PRIMARY KEY,
    NgayGiao DATE,
    MaKH INT,
    ThanhTien DECIMAL(18, 2),
    NgayLap DATE,
    MaPhuongThuc INT,
    HoTenNgNhan NVARCHAR(100),
    GioitinhNgNhan NVARCHAR(100),
    SDTNgNhan NVARCHAR(100),
    LoiChuc NVARCHAR(100),
    FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH),
    FOREIGN KEY (MaPhuongThuc) REFERENCES PhuongThucThanhToan(MaPhuongThuc)
);

-- Tạo bảng ChiTietDonHang
CREATE TABLE ChiTietDonHang (
    MaDonHang INT,
    MaHoa INT,
    SoLuong INT,
    DonGia DECIMAL(18, 2),
    PRIMARY KEY (MaDonHang, MaHoa),
    FOREIGN KEY (MaDonHang) REFERENCES DonHang(MaDonHang),
    FOREIGN KEY (MaHoa) REFERENCES Hoa(MaHoa)
);



INSERT INTO KhachHang (HoTen, NgaySinh, GioiTinh, DienThoai, Email, DiaChi, MatKhau, VaiTro)
VALUES
(N'Nguyễn Văn A', '1980-01-01', N'Nam', '0909123456', 'nguyenvana@example.com', '123 Street A', 'password123', '0'),
(N'Lê Thị B', '1990-02-02', N'Nữ', '0909234567', 'lethib@example.com', '456 Street B', 'password456', '1'),
(N'Trần Văn C', '1985-03-03', N'Nam', '0909345678', 'tranvanc@example.com', '789 Street C', 'password789', '1'),
(N'Phạm Thị D', '1995-04-04', N'Nữ', '0909456789', 'phamthid@example.com', '101 Street D', 'password101', '0'),
(N'Hoàng Văn E', '2000-05-05', N'Nam', '0909567890', 'hoangvane@example.com', '202 Street E', 'password202', '0');

INSERT INTO LienHe (Ten, Gmail, TinNhan, MaKH)
VALUES
(N'Nguyễn Văn A', 'nguyenvana@example.com', N'Xin chào, tôi muốn biết thêm về sản phẩm của bạn.', 1),
(N'Lê Thị B', 'lethib@example.com', N'Tôi có vấn đề với đơn hàng của mình.', 2),
(N'Trần Văn C', 'tranvanc@example.com', N'Có chương trình khuyến mãi nào sắp tới không?', 3),
(N'Phạm Thị D', 'phamthid@example.com', N'Làm thế nào để đổi sản phẩm?', 4),
(N'Hoàng Văn E', 'hoangvane@example.com', N'Tôi muốn hủy đơn hàng của mình.', 5);

-- Thêm dữ liệu vào bảng NhaCungCap
INSERT INTO NhaCungCap (MaNCC, TenNCC, DiaChi, SDT)
VALUES
(1, 'NCC1', '123 NCC Street', '0909123456'),
(2, 'NCC2', '456 NCC Street', '0909234567'),
(3, 'NCC3', '789 NCC Street', '0909345678'),
(4, 'NCC4', '101 NCC Street', '0909456789'),
(5, 'NCC5', '202 NCC Street', '0909567890');

-- Thêm dữ liệu vào bảng LoaiHoa
INSERT INTO LoaiHoa (MaLoai, TenLoai, MaNCC, SoLuong)
VALUES
(1, N'Bó Hoa Tươi', 1, 100),
(2, N'Kệ Hoa Khai Trương', 2, 200),
(3, N'Giỏ Hoa Chúc Mừng', 3, 150),
(4, N'Hoa Cưới', 4, 180),
(5, N'Hoa Sáp', 5, 120);

-- Thêm dữ liệu vào bảng Hoa
INSERT INTO Hoa (MaHoa, TenHoa, GiaBan, MoTa, Anh, SoLuongTon, MaNCC, MaLoai)
VALUES
------ Bo Hoa Tuoi -------
(101, N'Bó Hoa Cát Tường SP000001', 150000, 'SP000001', 'SP000001.jpg', 50, 1, 1),
(102, N'Bó Hoa Cát Tường Mix Đồng Tiền SP000002', 200000, 'SP000002', 'SP000002.jpg', 40, 1, 1),
(103, N'Bó Hoa Cúc Mẫu Đơn SP000003', 100000, 'SP000003', 'SP000003.jpg', 30, 1, 1),
(104, N'Bó hoa cúc tana SP000004', 300000, 'SP000004', 'SP000004.jpg', 20, 1, 1),
(105, N'Bó hoa đồng tiền mix SP000005', 300000, 'SP000005', 'SP000005.jpg', 20, 1, 1),
(106, N'Bó hoa đồng tiền mix SP000006', 300000, 'SP000006', 'SP000006.jpg', 20, 1, 1),
(107, N'Bó hoa đồng tiền mix SP000007', 300000, 'SP000007', 'SP000007.jpg', 20, 1, 1),
(108, N'Bó hoa đồng tiền mix SP000008', 300000, 'SP000008', 'SP000008.jpg', 20, 1, 1),
(109, N'Bó hoa đồng tiền mix SP000009', 300000, 'SP000009', 'SP000009.jpg', 20, 1, 1),
(110, N'Dao Hong', 250000, 'SP000001', 'SP000001.jpg', 10, 1, 1),
(111, N'Bó hoa Hồng đỏ mix scabiosa SP000011', 300000, 'SP000011', 'SP000011.jpg', 20, 1, 1),
(112, N'Bó hoa Hồng 9 bông SP000012', 250000, 'SP000012', 'SP000012.jpg', 10, 1, 1),

----- Ke Hoa -----

(201, N'Hoa chúc mừng hoa khai trương SP000088', 150000, 'SP000088', 'SP000088.jpg', 50, 2, 2),
(202, N'Hoa chúc mừng hoa khai trương SP000089', 150000, 'SP000089', 'SP000089.jpg', 50, 2, 2),
(203, N'Hoa chúc mừng hoa khai trương SP000090', 150000, 'SP000090', 'SP000090.jpg', 50, 2, 2),
(204, N'Hoa chúc mừng hoa khai trương SP000091', 150000, 'SP000091', 'SP000091.jpg', 50, 2, 2),
(205, N'Hoa chúc mừng hoa khai trương SP000092', 150000, 'SP000092', 'SP000092.jpg', 50, 2, 2),
(206, N'Hoa chúc mừng hoa khai trương SP000093', 150000, 'SP000093', 'SP000093.jpg', 50, 2, 2),
(207, N'Hoa chúc mừng hoa khai trương SP000094', 150000, 'SP000094', 'SP000094.jpg', 50, 2, 2),
(208, N'Hoa chúc mừng hoa khai trương SP000095', 150000, 'SP000095', 'SP000095.jpg', 50, 2, 2),
(209, N'Hoa chúc mừng hoa khai trương SP000096', 150000, 'SP000096', 'SP000096.jpg', 50, 2, 2),
(210, N'Hoa chúc mừng hoa khai trương SP000097', 150000, 'SP000097', 'SP000097.jpg', 50, 2, 2),
(211, N'Hoa chúc mừng hoa khai trương SP000098', 150000, 'SP000098', 'SP000098.jpg', 50, 2, 2),
(212, N'Hoa chúc mừng hoa khai trương SP000099', 150000, 'SP000098', 'SP000099.jpg', 50, 2, 2),



----- Gio Hoa Chuc Mung ----
(301, N'Giỏ hoa khai trương SP000013', 206000, 'SP000013', 'SP000014.jpg', 50, 3, 3),
(302, N'Giỏ hoa khai trương SP100014', 206000, 'SP000014', 'SP000014.jpg', 50, 3, 3),
(303, N'Giỏ hoa khai trương SP100015', 206000, 'SP000015', 'SP000015.jpg', 50, 3, 3),
(304, N'Giỏ hoa khai trương SP100016', 206000, 'SP000016', 'SP000016.jpg', 50, 3, 3),
(305, N'Giỏ hoa khai trương SP100017', 206000, 'SP000017', 'SP000017.jpg', 50, 3, 3),
(306, N'Giỏ hoa khai trương SP100018', 206000, 'SP000018', 'SP000018.jpg', 50, 3, 3),
(307, N'Giỏ hoa khai trương SP100019', 206000, 'SP000019', 'SP000019.jpg', 50, 3, 3),
(308, N'Giỏ hoa khai trương SP100020', 206000, 'SP000020', 'SP000020.jpg', 50, 3, 3),
(309, N'Giỏ hoa khai trương SP100021', 206000, 'SP000021', 'SP000021.jpg', 50, 3, 3),
(310, N'Giỏ hoa khai trương SP100022', 206000, 'SP000022', 'SP000022.jpg', 50, 3, 3),
(311, N'Giỏ hoa khai trương SP100023', 206000, 'SP000023', 'SP000023.jpg', 50, 3, 3),
(312, N'Giỏ hoa khai trương SP100024', 206000, 'SP000024', 'SP000024.jpg', 50, 3, 3),


---- Hoa Cuoi ----

(401, N'Hoa Tulip cầm tay cô dâu  SP100025', 100000, 'SP000025', 'SP000025.jpg', 50, 4, 4),
(402, N'Hoa hồng cầm tay SP100026', 100000, 'SP000026', 'SP000026.jpg', 50, 4, 4),
(403, N'Hoa sen cầm tay SP100027', 100000, 'SP000025', 'SP000027.jpg', 50, 4, 4),
(404, N'Hoa Calla Lily (hoa rum) cầm tay SP100028', 100000, 'SP000028', 'SP000028.jpg', 50, 4, 4),
(405, N'Hoa Rum + Tulup Cầm tay SP100029', 100000, 'SP000029', 'SP000029.jpg', 50, 4, 4),
(406, N'Hoa tulip cầm tay SP100030',100000, 'SP000030', 'SP000030.jpg', 50, 4, 4),
(407, N'Hoa Hướng Dương cầm tay SP100031', 100000, 'SP000031', 'SP000031.jpg', 50, 4, 4),
(408, N'Sen đá cầm tay SP100032', 100000, 'SP000032', 'SP000032.jpg', 50, 4, 4),
(409, N'Hoa Tulip cầm tay SP100033', 100000, 'SP000033', 'SP000033.jpg', 50, 4, 4),
(410, N'Hoa Hồng cầm tay SP100034', 100000, 'SP000034', 'SP000034.jpg', 50, 4, 4),
(411, N'Hoa Hồng Cầm tay cô dâu SP100035', 100000, 'SP000035', 'SP000035.jpg', 50, 4, 4),
(412, N'Hoa Hồng cầm tay SP100036', 100000, 'SP000036', 'SP000036.jpg', 50, 4, 4),


----- Hoa Sap -----
(501, N'Bó hoa Hồng sáp bông SP100037', 250000, 'SP000037', 'SP000037.jpg', 50, 5, 5),
(502, N'Hoa Hồng sáp 10 bông SP100038', 250000, 'SP000038', 'SP000038.jpg', 50, 5, 5),
(503, N'Hoa Hống sáp 10 bông SP100039', 250000, 'SP000039', 'SP000039.jpg', 50, 5, 5),
(505, N'Hoa Hồng sáp 10 bông SP100040', 250000, 'SP000040', 'SP000040.jpg', 50, 5, 5),
(506, N'Hoa Hồng sáp 50 bông SP100042', 250000, 'SP000042', 'SP000042.jpg', 50, 5, 5),
(507, N'Giỏ hoa hồng sáp SP100043', 250000, 'SP000043', 'SP000043.jpg', 50, 5, 5),
(508, N'Hoa sáp bướm SP100044', 250000, 'SP000044', 'SP000044.jpg', 50, 5, 5),
(509, N'Giỏ hoa sáp SP100045', 250000, 'SP000045', 'SP000045.jpg', 50, 5, 5),
(510, N'Bó hoa sáp SP100046', 250000, 'SP000046', 'SP000046.jpg', 50, 5, 5),
(511, N'Hộp hoa sáp SP100047', 250000, 'SP000047', 'SP00007.jpg', 50, 5, 5);


-- Thêm dữ liệu vào bảng PhuongThucThanhToan
INSERT INTO PhuongThucThanhToan (MaPhuongThuc, HinhThuc)
VALUES
(1, N'Tiền Mặt'),
(2, N'Tiền Mặt'),
(3, N'Chuyển Khoản'),
(4, N'Chuyển Khoản'),
(5, N'Chuyển Khoản');

select * from DonHang
-- Thêm dữ liệu vào bảng DonHang
INSERT INTO DonHang ( NgayGiao,  MaKH, ThanhTien, NgayLap, MaPhuongThuc, HoTenNgNhan, GioitinhNgNhan, SDTNgNhan, LoiChuc)
VALUES
('2024-07-30', 1, 1500000, '2024-07-29', 1, N'Nguyễn Văn B', N'Nam', '0909123456', N'Chúc mưng sinh nhật!'),
('2024-08-01', 2, 2000000, '2024-07-30', 2, N'Lê THị C', N'Nữ', '0909234567', N'Chúc mừng năm mới!'),
('2024-08-05', 3, 1000000, '2024-08-01', 3, N'Trần Văn D', N'Nam', '0909345678', N'Chúc mừng ngày cưới!'),
('2024-08-10', 4, 3000000, '2024-08-05', 4, N'Phạm Thị E', N'Nữ', '0909456789', N'Chúc mừng ngày kỷ niệm!'),
('2024-08-15', 5, 2500000, '2024-08-10', 5, N'Hoàng Văn F', N'Nam', '0909567890', N'Chúc mừng ngày tháng!');

-- Thêm dữ liệu vào bảng ChiTietDonHang
INSERT INTO ChiTietDonHang (MaDonHang, MaHoa, SoLuong, DonGia)
VALUES
(1, 101, 10, 1500000),
(2, 206, 10, 1500000),
(3, 302, 1, 206000),
(4, 405, 10, 1000000),
(5, 501, 10, 2500000);