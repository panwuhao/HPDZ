use master
go
--建库
if exists(select * from sys.databases where name='Owl')
drop database Owl
go
create database Owl
go
use Owl
go

--建表
--用户登录注册表
if exists(select * from sys.tables where name='Userinfo')
drop table Userinfo
go
create table Userinfo
(
UserID int identity(1,1) primary key,
LoginID varchar(30)not null,
UserName varchar(20)  not null,
UserPwd varchar(20) not null,
UserEmail varchar(30) not null,
UserCall varchar(30) not null,
UserSex char(2) not null,
UserAdress varchar(30) not null
)
go
select * from Userinfo
insert into Userinfo values('p1051250511','潘武豪','123456','1051250511@qq.com','15516070627','男','河南省郑州市经开区')
insert into Userinfo values('d1872311885','	董雅敏','123456','1872311885@qq.com','15290605027','女','河南省郑州市经开区')
insert into Userinfo values('d1872311885','	张建行','123456','1486358520@qq.com','18530599939','男','河南省郑州市经开区')
insert into Userinfo values('d1872311885','	侯轲','123456','2536071741@qq.com','15737473190','男','河南省郑州市经开区')

--标签内容表
if exists(select * from sys.tables where name='Noteinfo')
drop table Noteinfo
go
create table Noteinfo
(
NoteID int primary key identity(1,1),
Notetheme varchar(30)not null,
Notecontent varchar(max) not null,
NoteauthorID int references Userinfo(UserID),
NoteTime datetime default(getdate()),
NoteUpTime datetime default(null),
IsDelete int check(IsDelete=0 or IsDelete=1) default(0) --软删除
)
go
select * from Noteinfo
insert into Noteinfo values('第一次测试','猫头鹰:身体淡褐色,多黑斑,头部有角状的羽毛,头大,有两只向前看的大眼,短而弯曲的喙,强有力的钩爪,能翻转的外趾。又叫夜猫子',1,default,default,default)
insert into Noteinfo values('第二次测试','猫头鹰:身体淡褐色,多黑斑,头部有角状的羽毛,头大,有两只向前看的大眼,短而弯曲的喙,强有力的钩爪,能翻转的外趾。又叫夜猫子',1,default,default,default)
insert into Noteinfo values('第三次测试','猫头鹰:身体淡褐色,多黑斑,头部有角状的羽毛,头大,有两只向前看的大眼,短而弯曲的喙,强有力的钩爪,能翻转的外趾。又叫夜猫子',1,default,default,default)
insert into Noteinfo values('第四次测试','猫头鹰:身体淡褐色,多黑斑,头部有角状的羽毛,头大,有两只向前看的大眼,短而弯曲的喙,强有力的钩爪,能翻转的外趾。又叫夜猫子',1,default,default,default)
