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
UserID varchar(30)not null,
UserName varchar(20) primary key not null,
UserPwd varchar(20) not null,
UserEmail varchar(30) not null,
UserSex char(2) not null,
UserAdress varchar(30) not null
)
go

--登录注册表（Userinfo） 
--用户账号： UserID  varchar（30）
--用户姓名： UserName varchar（20）主键 not null               
--用户密码： UserPwd varchar（20）not null
--用户邮箱：UserEmail varchar（30）not null
--用户性别： UserSex char(2) not null
--用户住址： UserAdress varchar(30) not null


--标签内容表
if exists(select * from sys.tables where name='Noteinfo')
drop table Noteinfo
go
create table Noteinfo
(
NoteID int primary key identity(1,1),
Notetheme varchar(30)not null,
Notecontent varchar(max) not null,
Noteauthor varchar(20) references Userinfo(UserName),
NoteTime datetime default(getdate()),
NoteUpTime datetime default(null),
IsDelete int check(IsDelete=0 or IsDelete=1) default(0) --软删除
)
go
