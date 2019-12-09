use master
go
if exists (select * from sys.databases where name='pro')
drop database pro
go

create database pro 
go

use pro
go

--(ѡ�����)
if exists(select *from sys.tables where name='ComCity')
drop table ComCity
go
create table ComCity 
(
	ComID int primary key identity(1,1) not null, 
	Cityname varchar(20) not null  , 

)
insert into ComCity values('����')
insert into ComCity values('�Ϻ�')
insert into ComCity values('�㶫')
insert into ComCity values('����')
insert into ComCity values('֣��')
go


--��ҵ����
if exists(select *from sys.tables where name='ComFx')
drop table ComFx
go
create table ComFx
(
	ComFxID int primary key identity(1,1) not null, 
	ComFxname varchar(20) not null  , 

)
insert into ComFx values('.Net')
insert into ComFx values('Webǰ��')
insert into ComFx values('��������')
insert into ComFx values('Java')
insert into ComFx values('�ƶ�����')
go
--��Ϣ��Դ
if exists(select *from sys.tables where name='ComLy')
drop table ComLy
go
create table ComLy
(
	ComLyID int primary key identity(1,1) not null, 
	ComLyname varchar(20) not null  , 

)
insert into ComLy values('������Ƹ')
insert into ComLy values('ǰ������')
insert into ComLy values('58ͬ��')
go

--��ҵ��Ϣ��
if exists(select *from sys.tables where name='qiye')
drop table qiye
go
create table qiye
(
	qID int primary key identity(1001,1) not null, --��ҵ���
	qName varchar(50) not null, --��ҵ��
	qHe varchar(50) not null,  --������ҵ
	jieshao varchar(200) not null,  --��ҵ����
	ComID int references ComCity(ComID) not null --������
)
insert into qiye values('�껪','�����','�ߴ���',1)
insert into qiye values('��ʿ��','�ֻ�','�ߴ���',2)
insert into qiye values('����','����','�ߴ���',3)
insert into qiye values('�ܿ�','����','�ߴ���',4)
insert into qiye values('����','��Ϸ','�ߴ���',5)
go

select * from ComCity inner join qiye on ComCity.ComID=qiye.ComID


--��Ƹ��Ϣ
if exists(select *from sys.tables where name='comGw')
drop table comGw
go
create table comGw
(
	GwID int primary key identity(1001,1) not null, 
	GwName varchar(50) not null,  --��λ����
	age int not null, --��������
	jieshao varchar(200) not null, --��λ����
	ComFxID int references ComFx(ComFxID) not null, --����
	ComLyID int references ComLy(ComLyID) not null  --��Դ
)
insert into comGw values('.net',3,'fdsvs',1,1)

--���и�λ
if exists(select *from sys.tables where name='comGww')
drop table comGww
go
create table comGww
(
	GwwID int primary key identity(1001,1)  not null, 
	GwwName int references comGw(GwID) not null, --��λ����
	Peo int  not null, --����
	Addtime datetime not null, --��ʼʱ��
	Endtime datetime not null,  --����ʱ��
	Mone int not null   --ƽ��н��
)
insert into comGww values (1001,2,'2019-01-02','2019-02-03',5000)

select * from ComCity
select * from comGw
select * from comGww
select * from ComFx
select * from ComLy
select * from qiye


--1-��ѯ���� DropDownList


--2-����    DropDownList
--2-��Դ DropDownList
--2-��ѯ�б���ʾ
select GwName as ��λ����,ComFxname as ����,age as ��������,jieshao as ��λ���� from comGw inner join ComFx on comGw.ComFxID=ComFx.ComFxID

--3-��λ���� DropDownList
--3-��ѯ�б�
select GwName as ��λ����,Addtime as ��ʼʱ��,Endtime as ����ʱ�� from comGw inner join comGww on comGw.GwID=comGww.GwwName
































--��������
create table Engineer
(
	EngID int identity(101,1) primary key, --����ʦ���
	EngName varchar(100) not null --����ʦ����
)

insert into Engineer values('NET����ʦ')
insert into Engineer values('JAVA����ʦ')
insert into Engineer values('��ҵ��Ϣ������ʦ')
insert into Engineer values('�����ݹ���ʦ')
insert into Engineer values('Webǰ�˹���ʦ')
insert into Engineer values('����Ӫ������ʦ')


select * from Engineer

--��������
create table Assessment
(
	AssEngID int references Engineer(EngID), --����ʦ���
	AssName varchar(100) not null --������
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
