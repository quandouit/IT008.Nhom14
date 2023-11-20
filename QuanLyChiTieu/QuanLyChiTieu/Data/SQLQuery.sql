create table NGUOIDUNG
(
ID char(6) primary key,
TAIKHOAN varchar(40),
MATKHAU varchar(20),
SDT varchar(20),
TONGTIEN money,
)

create table NGANSACH
(
MANS char(6) primary key,
ID char(6),
TENNS varchar(40),
TIENNS money,
HSD smalldatetime,
constraint FK_ID_NGANSACH foreign key (ID) references NGUOIDUNG(ID),
)

create table LOAIGIAODICH
(
MALOAIGD char(6) primary key,
TENLOAIGD varchar(40),
TRANGTHAI varchar(40),
)

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

insert into NGUOIDUNG (ID, TAIKHOAN, MATKHAU, SDT, TONGTIEN)
values 
('01' , 'sondang@2004' , '123456' , '0822545545' , '1500000'),
('02' , 'uit@gm.edu.vn' , '678678' , '0905123123' , '2000000');

insert into NGANSACH (MANS, ID, TENNS, TIENNS, HSD)
values
('NS01' , '01' , 'AnUong' , '800000' , '2023-12-30'),
('NS02' , '02' , 'MuaSam' , '1000000' , '2024-04-30');

insert into LOAIGIAODICH(MALOAIGD, TENLOAIGD, TRANGTHAI)
values
('CT01' , 'AnUong' , 'Payment'),
('CT02' , 'QuanAo' , 'Payment'),
('CT03' , 'Luong' , 'Income');

insert into GIAODICH (MAGD, ID, MALOAIGD, TENGD, TIEN, MINHHOA, GHICHU, NGAYTAO)
values
('G01' , '01' , 'CT01' , 'An toi cung gia dinh' , '400000' , null , null , '2023-10-24'),
('G02' , '01' , 'CT03' , 'Luong thang 10' , '2000000' , null , null , '2023-10-31'),
('GT03', '02' , 'CT02' , 'Mua dong phuc mua dong' , '500000' , null , null , '2022-09-01');

