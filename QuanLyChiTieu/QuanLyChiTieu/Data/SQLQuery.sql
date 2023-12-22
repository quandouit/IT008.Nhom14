
create table NGUOIDUNG
(
ID int identity(1,1) primary key,
TAIKHOAN varchar(40),
MATKHAU varchar(20),
SDT varchar(20),
TONGTIEN decimal,
)
go

create table NGANSACH
(
MANS int identity(1,1) primary key,
ID int,
TENNS nvarchar(40),
TIENNS decimal,
HSD date,
constraint FK_ID_NGANSACH foreign key (ID) references NGUOIDUNG(ID),
)
go

create table LOAIGIAODICH
(
MALOAIGD int identity(1,1) primary key,
TENLOAIGD nvarchar(40),
TRANGTHAI varchar(40),
)
go

create table GIAODICH
(
MAGD int identity(1,1) primary key,
ID int,
MALOAIGD int,
TENGD nvarchar(40),
TIEN decimal,
GHICHU nvarchar(200),
NGAYTAO date,
constraint FK_ID_GIAODICH foreign key (ID) references NGUOIDUNG(ID),
constraint FK_MALOAIGD_GIAODICH foreign key (MALOAIGD) references LOAIGIAODICH(MALOAIGD),
)
go

insert into NGUOIDUNG (TAIKHOAN, MATKHAU, SDT, TONGTIEN)
values 
('uit.ktpm22' , '22521248' , '0905226464' , '20000000'),
('sondang04' , '20120000' , '0906545560' , '11500000'),
('tencent10' , 'TC@10com' , '1900107777' , '50255600'),
('riot.entertainment' , 'LoL2005' , '0852006789' , '68762430'),
('sudo_vnu' , 'Icpc22' , '0261364570' , '15049112'),
('ngoisaocodon' , 'secret123' , '0977358510' , '5060300');
go

insert into NGANSACH (ID, TENNS, TIENNS, HSD)
values
('1' , N'Ngân sách tháng 10/23' , '6000000' , '2023-10-01'),
('5' , N'Ngân sách tháng 11/23' , '10000000' , '2023-11-01'),
('4' , N'Ngân sách tháng 10/23' , '20000000' , '2023-10-01'),
('3' , N'Ngân sách tháng 10/23' , '4600000' , '2023-10-01'),
('2' , N'Ngân sách tháng 09/23' , '3500000' , '2023-09-01'),
('3' , N'Ngân sách tháng 12/23' , '1200000' , '2023-12-01'),
('6' , N'Ngân sách tháng 10/23' , '1000000' , '2023-10-01'),
('4' , N'Ngân sách tháng 11/23' , '15000000' , '2023-11-01');
go

insert into LOAIGIAODICH(TENLOAIGD, TRANGTHAI)
values
(N'Ăn uống' , 'OUT'),
(N'Mua sắm' , 'OUT'),
(N'Lương thưởng' , 'IN'),
(N'Học tập' , 'OUT'),
(N'Phát sinh' , 'OUT');
go

insert into GIAODICH (ID, MALOAIGD, TENGD, TIEN, GHICHU, NGAYTAO)
values
('2' , '4' , N'Học phí tháng 10' , '2500000', null , '2023-10-01'),
('1' , '1' , N'Đám cưới anh Ba' , '500000', null , '2023-11-06'),
('1' , '3' , N'Lương tháng 9' , '12000000', N'Cộng 500000 làm thêm giờ' , '2023-10-05'),
('5' , '5' , N'Phạt vượt đèn đỏ' , '200000', N'Nộp tại công an phường' , '2023-08-22'),
('6' , '5' , N'Viện phí' , '3000000', null , '2023-10-16'),
('3' , '2' , N'Quần áo tết' , '1760000', null , '2023-01-30'),
('3' , null , N'Ủng hộ lũ lụt' , '300000' , null , '2023-07-25'),
('5' , '3' , N'Tiền thưởng tết' , '2000000' , null , '2023-02-01'),
('4' , null , N'Tiền điện tháng 10' , '688000' , N'Thanh toán tiền mặt' , '2023-11-04'),
('4' , '5' , N'Spotify prenium Month 12' , '60000' , N'//Tự động thanh toán' , '2022-12-01');
go

insert into GIAODICH (ID, MALOAIGD, TENGD, TIEN, GHICHU, NGAYTAO)
values
('6', '3', N'Thưởng 2023', '1000000', null, '2023-12-20'),
('6', '1', N'Ăn tối', '50000', null, '2023-12-19'),
('6', '2', N'Mua trái cây cúng', '140000', null, '2023-12-15'),
('6', '4', N'Mua SGK', '480000', null, '2023-09-12'),
('6', '5', N'Sửa đồng hồ', '250000', null, '2023-11-30'),
('6', null, N'Mua hàng từ thiện', '50000', null, '2023-12-01'),
('6', '3', N'Tiền tăng ca', '1000000', null, '2023-12-02'),
('6', '5', N'Bỏ tiết kiệm', '200000', null, '2023-11-27'),
('6', '2', N'Sắm đồ tết', '720000', null, '2024-01-20'),
('6', '1', N'Đi chợ', '176000', null, '2023-12-19');
go