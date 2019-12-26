use master
go

if exists(select * from sys.databases where name='DPHZ')
drop database DPHZ
go
create database DPHZ
go

use DPHZ
go

--�ȼ���
create table Grade
(
	GradeID int primary key identity(1,1),--�û��ȼ�(1Ϊ��ͨ�û���2Ϊ����Ա)
	GradeTypes varchar(20)--�ȼ�����(��ͨ�û������羯��)
)
insert into Grade values('��ͨ�û�')
insert into Grade values('����Ա')
go
-- select * from Grade

--�û���
create table Users
(
	UserID int primary key identity(1,1),--�û�ID
	UserName varchar(50) not null,       --�û���
	UserPassword varchar(50) not null,   --�û�����
	Tel varchar(50) not null,            --�绰����
	IDCard varchar(50) not null,         --���֤��
	GradeID int references Grade(GradeID) default(1), --�û��ȼ�(1Ϊ��ͨ�û���2Ϊ���羯��)
)
insert into Users values('�����','123456','13911111','41101234567891',1)
insert into Users values('����','123456','13922222','41101234567892',1)
insert into Users values('������','123456','13933333','41101234567893',2)
insert into Users values('�Ž���','123456','13944444','41101234567894',2)
go
-- select * from Users where UserName='�����'

--������Ϣ��
create table FlightInfo
(
	FlightID int primary key identity(1011,1),--������
	FlightLoad varchar(50) not null,       --����·��
	FlightDate datetime not null,          --��������
	FlightTime varchar(50) not null,       --���ʱ��
	CabinType varchar(20) not null,        --��������(���òգ�����գ�ͷ�Ȳ�)
	TicketPrice money not null,			   --Ʊ��
	IsDelay int check(IsDelay=1 or IsDelay=2),--�����Ƿ�����(1�ǣ�2��)
	DelayCause varchar(50),                --����ԭ��(����Ϊ��)
	SurTicket int not null,                --ʣ��Ʊ��
	PlaneType varchar(20) not null		   --����
)
insert into FlightInfo values('����-�Ϻ�','2019-12-19','9:00','���ò�','799',2,null,200,'����CA1392')
insert into FlightInfo values('����-�Ϻ�','2019-12-19','9:00','�����','1599',2,null,100,'����CA1392')
insert into FlightInfo values('����-�Ϻ�','2019-12-19','9:00','ͷ�Ȳ�','2899',2,null,20,'����CA1392')
insert into FlightInfo values('����-�ɶ�','2019-12-19','15:00','���ò�','799',1,'��ѩ����Ӱ�쵼�º�������',200,'����CA1391')
insert into FlightInfo values('����-�ɶ�','2019-12-19','15:00','�����','1599',1,'��ѩ����Ӱ�쵼�º�������',100,'����CA1391')
insert into FlightInfo values('����-�ɶ�','2019-12-19','15:00','ͷ�Ȳ�','2899',1,'��ѩ����Ӱ�쵼�º�������',20,'����CA1391')
go
--select * from FlightInfo where DelayCause is not null


--������Ϣ��
create table ListInfo
(
	ListID int primary key identity(1,1),--�������
	--FlightID int references FlightInfo(FlightID),--������
	UserID int references Users(UserID),--��Ʊ��
	ListTime datetime default(getdate()),--�µ�ʱ��
	ListState int check(ListState=1 or ListState=2) default(2)--����״̬(1����2δ����)
)
--insert into ListInfo values(1011,1,default,default)
--insert into ListInfo values(1012,1,default,default)
insert into ListInfo values(2,default,default)
insert into ListInfo values(2,default,default)
insert into ListInfo values(2,default,default)
insert into ListInfo values(2,default,default)
go
-- select * from ListInfo