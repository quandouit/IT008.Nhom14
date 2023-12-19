
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
TENNS varchar(40),
TIENNS decimal,
HSD smalldatetime,
constraint FK_ID_NGANSACH foreign key (ID) references NGUOIDUNG(ID),
)
go

create table LOAIGIAODICH
(
MALOAIGD int identity(1,1) primary key,
TENLOAIGD varchar(40),
TRANGTHAI varchar(40),
)
go

create table GIAODICH
(
MAGD int identity(1,1) primary key,
ID int,
MALOAIGD int,
TENGD varchar(40),
TIEN decimal,
MINHHOA text,
GHICHU text,
NGAYTAO smalldatetime,
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
('1' , 'Ngan sach thang 10/23' , '6000000' , '2023-10-01'),
('5' , 'Ngan sach thang 11/23' , '10000000' , '2023-11-01'),
('4' , 'Ngan sach thang 10/23' , '20000000' , '2023-10-01'),
('3' , 'Ngan sach thang 10/23' , '4600000' , '2023-10-01'),
('2' , 'Ngan sach thang 09/23' , '3500000' , '2023-09-01'),
('3' , 'Ngan sach thang 12/23' , '1200000' , '2023-12-01'),
('6' , 'Ngan sach thang 10/23' , '1000000' , '2023-10-01'),
('4' , 'Ngan sach thang 11/23' , '15000000' , '2023-11-01');
go

insert into LOAIGIAODICH(TENLOAIGD, TRANGTHAI)
values
('An uong' , 'OUT'),
('Mua sam' , 'OUT'),
('Luong thuong' , 'IN'),
('Hoc tap' , 'OUT'),
('Phat sinh' , 'OUT');
go

insert into GIAODICH (ID, MALOAIGD, TENGD, TIEN, MINHHOA, GHICHU, NGAYTAO)
values
('2' , '4' , 'Hoc phi thang 10' , '2500000' , null , null , '2023-10-01'),
('1' , '1' , 'Dam cuoi anh Ba' , '500000' , null , null , '2023-11-06'),
('1' , '3' , 'Luong thang 9' , '12000000' , null , 'Cong 500000 thuong them gio' , '2023-10-05'),
('5' , '5' , 'Phat vuot den do' , '200000' , null , 'Nop tai cong an phuong' , '2023-08-22'),
('6' , '5' , 'Vien phi' , '3000000' , null , null , '2023-10-16'),
('3' , '2' , 'Quan ao tet' , '1760000' , null , null , '2023-01-30'),
('3' , null , 'Ung ho lu lut' , '300000' , null , null , '2023-07-25'),
('5' , '3' , 'Tien thuong tet' , '2000000' , null , null , '2023-02-01'),
('4' , null , 'Tien dien thang 10' , '688000' , null , 'Thanh toan tien mat' , '2023-11-04'),
('4' , '5' , 'Spotify prenium Month 12' , '60000' , null , '//Tu dong thanh toan' , '2022-12-01');
go

insert into GIAODICH (ID, MALOAIGD, TENGD, TIEN, MINHHOA, GHICHU, NGAYTAO)
values
('6', '3', 'Thuong tet 2023', '1000000', null, null, '2023-12-20'),
('6', '1', 'An toi', '50000', null, null, '2023-12-19'),
('6', '2', 'Mua trai cay cung', '140000', null, null, '2023-12-15'),
('6', '4', 'Mua SGK', '480000', null, null, '2023-09-12'),
('6', '5', 'Sua dong ho', '250000', null, null, '2023-11-30'),
('6', null, 'Mua hang tu thien', '50000', null, null, '2023-12-01'),
('6', '3', 'Tien tang ca', '1000000', null, null, '2023-12-02'),
('6', '5', 'Bo Tiet kiem', '200000', null, null, '2023-11-27'),
('6', '2', 'Sam do tet', '720000', null, null, '2024-01-20'),
('6', '1', 'Di cho', '176000', null, null, '2023-12-19');
go