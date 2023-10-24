create table User_info
(
ID char(6) primary key,
username varchar(40),
pass varchar(20),
phone varchar(20),
balance money,
)

create table NganSach
(
ID char(6) primary key,
userID char(6),
NSname varchar(40),
budget money,
to_date smalldatetime,
constraint FK_userID_NganSach foreign key (userID) references User_info(ID),
)

create table Category
(
ID char(6) primary key,
CTname varchar(40),
GD_status varchar(40),
)

create table GiaoDich
(
ID char(6) primary key,
userID char(6),
categoryID char(6),
title varchar(40),
price money,
thumbnail text,
note text,
created_at smalldatetime,
constraint FK_userID_GiaoDich foreign key (userID) references User_info(ID),
constraint FK_categoryID_Category foreign key (categoryID) references Category(ID),

insert into User_info (ID, username, pass, phone, balance)
values 
('01' , 'sondang@2004' , '123456' , '0822545545' , '1500000'),
('02' , 'uit@gm.edu.vn' , '678678' , '0905123123' , '2000000');

insert into NganSach (ID, userID, NSname, budget, to_date)
values
('NS01' , '01' , 'AnUong' , '800000' , '2023-12-30'),
('NS02' , '02' , 'MuaSam' , '1000000' , '2024-04-30');

insert into Category (ID, CTname, GD_status)
values
('CT01' , 'AnUong' , 'Payment'),
('CT02' , 'QuanAo' , 'Payment'),
('CT03' , 'Luong' , 'Income');

insert into GiaoDich (ID, userID, categoryID, title, price, thumbnail, note, created_at)
values
('G01' , '01' , 'CT01' , 'An toi cung gia dinh' , '400000' , null , null , '2023-10-24'),
('G02' , '01' , 'CT03' , 'Luong thang 10' , '2000000' , null , null , '2023-10-31'),
('GT03', '02' , 'CT02' , 'Mua dong phuc mua dong' , '500000' , null , null , '2022-09-01');
)