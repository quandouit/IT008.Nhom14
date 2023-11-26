
create table NGUOIDUNG
(
ID char(6) primary key,
TAIKHOAN varchar(40),
MATKHAU varchar(20),
SDT varchar(20),
TONGTIEN money,
)
go

create table NGANSACH
(
MANS char(6) primary key,
ID char(6),
TENNS varchar(40),
TIENNS money,
HSD smalldatetime,
constraint FK_ID_NGANSACH foreign key (ID) references NGUOIDUNG(ID),
)
go

create table LOAIGIAODICH
(
MALOAIGD char(6) primary key,
TENLOAIGD varchar(40),
TRANGTHAI varchar(40),
)
go

create table GIAODICH
(
MAGD char(6) primary key,
ID char(6),
MALOAIGD char(6),
TENGD varchar(40),
TIEN money,
MINHHOA text,
GHICHU text,
NGAYTAO smalldatetime,
constraint FK_ID_GIAODICH foreign key (ID) references NGUOIDUNG(ID),
constraint FK_MALOAIGD_GIAODICH foreign key (MALOAIGD) references LOAIGIAODICH(MALOAIGD),
)
go

insert into NGUOIDUNG (ID, TAIKHOAN, MATKHAU, SDT, TONGTIEN)
values 
('001' , 'uit.ktpm22' , '22521248' , '0905226464' , '20000000'),
('002' , 'sondang04' , '20120000' , '0906545560' , '11500000'),
('003' , 'tencent10' , 'TC@10com' , '1900107777' , '50255600'),
('004' , 'riot.entertainment' , 'LoL2005' , '0852006789' , '68762430'),
('005' , 'sudo_vnu' , 'Icpc22' , '0261364570' , '15049112'),
('006' , 'ngoisaocodon' , 'secret123' , '0977358510' , '5060300');

insert into NGANSACH (MANS, ID, TENNS, TIENNS, HSD)
values
('NS001' , '001' , 'Ngan sach thang 10/23' , '6000000' , '2023-10-01'),
('NS002' , '005' , 'Ngan sach thang 11/23' , '10000000' , '2023-11-01'),
('NS003' , '004' , 'Ngan sach thang 10/23' , '20000000' , '2023-10-01'),
('NS004' , '003' , 'Ngan sach thang 10/23' , '4600000' , '2023-10-01'),
('NS005' , '002' , 'Ngan sach thang 09/23' , '3500000' , '2023-09-01'),
('NS006' , '003' , 'Ngan sach thang 12/23' , '1200000' , '2023-12-01'),
('NS007' , '006' , 'Ngan sach thang 10/23' , '1000000' , '2023-10-01'),
('NS008' , '004' , 'Ngan sach thang 11/23' , '15000000' , '2023-11-01');

insert into LOAIGIAODICH(MALOAIGD, TENLOAIGD, TRANGTHAI)
values
('C01' , 'An uong' , 'OUT'),
('C02' , 'Mua sam' , 'OUT'),
('C03' , 'Luong thuong' , 'IN'),
('C04' , 'Hoc tap' , 'OUT'),
('C05' , 'Phat sinh' , 'OUT');

insert into GIAODICH (MAGD, ID, MALOAIGD, TENGD, TIEN, MINHHOA, GHICHU, NGAYTAO)
values
('GD001' , '002' , 'C04' , 'Hoc phi thang 10' , '2500000' , null , null , '2023-10-01'),
('GD002' , '001' , 'C01' , 'Dam cuoi anh Ba' , '500000' , null , null , '2023-11-06'),
('GD003' , '001' , 'C03' , 'Luong thang 9' , '12000000' , null , 'Cong 500000 thuong them gio' , '2023-10-05'),
('GD004' , '005' , 'C05' , 'Phat vuot den do' , '200000' , null , 'Nop tai cong an phuong' , '2023-08-22'),
('GD005' , '006' , 'C05' , 'Vien phi' , '3000000' , null , null , '2023-10-16'),
('GD006' , '003' , 'C02' , 'Quan ao tet' , '1760000' , null , null , '2023-01-30'),
('GD007' , '003' , null , 'Ung ho lu lut' , '300000' , null , null , '2023-07-25'),
('GD008' , '005' , 'C03' , 'Tien thuong tet' , '2000000' , null , null , '2023-02-01'),
('GD009' , '004' , null , 'Tien dien thang 10' , '688000' , null , 'Thanh toan tien mat' , '2023-11-04'),
('GD010' , '004' , 'C05' , 'Spotify prenium Month 12' , '60000' , null , '//Tu dong thanh toan' , '2022-12-01');

