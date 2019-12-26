use master
go

if exists(select * from sys.databases where name='DPHZ')
drop database DPHZ
go
create database DPHZ
go

use DPHZ
go

--等级表
create table Grade
(
	GradeID int primary key identity(1,1),--用户等级(1为普通用户，2为管理员)
	GradeTypes varchar(20)--等级类型(普通用户，网络警察)
)
insert into Grade values('普通用户')
insert into Grade values('管理员')
go
-- select * from Grade

--用户表
create table Users
(
	UserID int primary key identity(1,1),--用户ID
	UserName varchar(50) not null,       --用户名
	UserPassword varchar(50) not null,   --用户密码
	Tel varchar(50) not null,            --电话号码
	IDCard varchar(50) not null,         --身份证号
	GradeID int references Grade(GradeID) default(1), --用户等级(1为普通用户，2为网络警察)
)
insert into Users values('潘武豪','123456','13911111','41101234567891',1)
insert into Users values('侯轲','123456','13922222','41101234567892',1)
insert into Users values('董雅敏','123456','13933333','41101234567893',2)
insert into Users values('张建行','123456','13944444','41101234567894',2)
go
-- select * from Users where UserName='潘武豪'

--航班信息表
create table FlightInfo
(
	FlightID int primary key identity(1011,1),--航班编号
	FlightLoad varchar(50) not null,       --航班路线
	FlightDate datetime not null,          --航班日期
	FlightTime varchar(50) not null,       --起飞时间
	CabinType varchar(20) not null,        --机舱类型(经济舱，商务舱，头等舱)
	TicketPrice money not null,			   --票价
	IsDelay int check(IsDelay=1 or IsDelay=2),--航班是否延误(1是，2否)
	DelayCause varchar(50),                --延误原因(可以为空)
	SurTicket int not null,                --剩余票数
	PlaneType varchar(20) not null		   --机型
)
insert into FlightInfo values('北京-上海','2019-12-19','9:00','经济舱','799',2,null,200,'国航CA1392')
insert into FlightInfo values('北京-上海','2019-12-19','9:00','商务舱','1599',2,null,100,'国航CA1392')
insert into FlightInfo values('北京-上海','2019-12-19','9:00','头等舱','2899',2,null,20,'国航CA1392')
insert into FlightInfo values('北京-成都','2019-12-19','15:00','经济舱','799',1,'暴雪天气影响导致航班延误',200,'川航CA1391')
insert into FlightInfo values('北京-成都','2019-12-19','15:00','商务舱','1599',1,'暴雪天气影响导致航班延误',100,'川航CA1391')
insert into FlightInfo values('北京-成都','2019-12-19','15:00','头等舱','2899',1,'暴雪天气影响导致航班延误',20,'川航CA1391')
go
--select * from FlightInfo where DelayCause is not null


--订单信息表
create table ListInfo
(
	ListID int primary key identity(1,1),--订单编号
	--FlightID int references FlightInfo(FlightID),--航班编号
	UserID int references Users(UserID),--购票人
	ListTime datetime default(getdate()),--下单时间
	ListState int check(ListState=1 or ListState=2) default(2)--订单状态(1受理，2未受理)
)
--insert into ListInfo values(1011,1,default,default)
--insert into ListInfo values(1012,1,default,default)
insert into ListInfo values(2,default,default)
insert into ListInfo values(2,default,default)
insert into ListInfo values(2,default,default)
insert into ListInfo values(2,default,default)
go
-- select * from ListInfo