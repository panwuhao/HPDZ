use master
go
if exists (select * from sys.databases where name='pro')
drop database pro
go

create database pro 
go

use pro
go

--(选择城市)
if exists(select *from sys.tables where name='ComCity')
drop table ComCity
go
create table ComCity 
(
	ComID int primary key identity(1,1) not null, 
	Cityname varchar(20) not null  , 

)
insert into ComCity values('北京')
insert into ComCity values('上海')
insert into ComCity values('广东')
insert into ComCity values('深圳')
insert into ComCity values('郑州')
go


--就业方向
if exists(select *from sys.tables where name='ComFx')
drop table ComFx
go
create table ComFx
(
	ComFxID int primary key identity(1,1) not null, 
	ComFxname varchar(20) not null  , 

)
insert into ComFx values('.Net')
insert into ComFx values('Web前端')
insert into ComFx values('电子商务')
insert into ComFx values('Java')
insert into ComFx values('移动开发')
go
--信息来源
if exists(select *from sys.tables where name='ComLy')
drop table ComLy
go
create table ComLy
(
	ComLyID int primary key identity(1,1) not null, 
	ComLyname varchar(20) not null  , 

)
insert into ComLy values('智联招聘')
insert into ComLy values('前程无忧')
insert into ComLy values('58同城')
go

--企业信息表
if exists(select *from sys.tables where name='qiye')
drop table qiye
go
create table qiye
(
	qID int primary key identity(1001,1) not null, --企业编号
	qName varchar(50) not null, --企业名
	qHe varchar(50) not null,  --所属行业
	jieshao varchar(200) not null,  --企业介绍
	ComID int references ComCity(ComID) not null --城市名
)
insert into qiye values('申华','计算机','高大上',1)
insert into qiye values('富士康','手机','高大上',2)
insert into qiye values('厚朴','教育','高大上',3)
insert into qiye values('杰克','服饰','高大上',4)
insert into qiye values('安康','游戏','高大上',5)
go

select * from ComCity inner join qiye on ComCity.ComID=qiye.ComID


--招聘信息
if exists(select *from sys.tables where name='comGw')
drop table comGw
go
create table comGw
(
	GwID int primary key identity(1001,1) not null, 
	GwName varchar(50) not null,  --岗位名称
	age int not null, --工作年限
	jieshao varchar(200) not null, --岗位描述
	ComFxID int references ComFx(ComFxID) not null, --方向
	ComLyID int references ComLy(ComLyID) not null  --来源
)
insert into comGw values('.net',3,'fdsvs',1,1)

--在招岗位
if exists(select *from sys.tables where name='comGww')
drop table comGww
go
create table comGww
(
	GwwID int primary key identity(1001,1)  not null, 
	GwwName int references comGw(GwID) not null, --岗位名称
	Peo int  not null, --人数
	Addtime datetime not null, --开始时间
	Endtime datetime not null,  --结束时间
	Mone int not null   --平均薪资
)
insert into comGww values (1001,2,'2019-01-02','2019-02-03',5000)

select * from ComCity
select * from comGw
select * from comGww
select * from ComFx
select * from ComLy
select * from qiye


--1-查询城市 DropDownList


--2-方向    DropDownList
--2-来源 DropDownList
--2-查询列表显示
select GwName as 岗位名称,ComFxname as 方向,age as 工作年限,jieshao as 岗位描述 from comGw inner join ComFx on comGw.ComFxID=ComFx.ComFxID

--3-岗位名称 DropDownList
--3-查询列表
select GwName as 岗位名称,Addtime as 开始时间,Endtime as 结束时间 from comGw inner join comGww on comGw.GwID=comGww.GwwName
































--技术评估
create table Engineer
(
	EngID int identity(101,1) primary key, --工程师编号
	EngName varchar(100) not null --工程师姓名
)

insert into Engineer values('NET工程师')
insert into Engineer values('JAVA工程师')
insert into Engineer values('企业信息化工程师')
insert into Engineer values('大数据工程师')
insert into Engineer values('Web前端工程师')
insert into Engineer values('网络营销工程师')


select * from Engineer

--技术评估
create table Assessment
(
	AssEngID int references Engineer(EngID), --工程师编号
	AssName varchar(100) not null --评估项
)
insert into Assessment values(101,'WebForm')
insert into Assessment values(101,'HTTP')
insert into Assessment values(101,'MVC')
insert into Assessment values(102,'WCF')
insert into Assessment values(103,'SQL')
insert into Assessment values(104,'JQuery')
insert into Assessment values(105,'WebAPI')
insert into Assessment values(106,'WebService')

select * from Assessment,Engineer where Assessment.AssEngID=Engineer.EngID
