use master
go
--����
if exists(select * from sys.databases where name='Owl')
drop database Owl
go
create database Owl
go
use Owl
go

--����
--�û���¼ע���
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

--��¼ע���Userinfo�� 
--�û��˺ţ� UserID  varchar��30��
--�û������� UserName varchar��20������ not null               
--�û����룺 UserPwd varchar��20��not null
--�û����䣺UserEmail varchar��30��not null
--�û��Ա� UserSex char(2) not null
--�û�סַ�� UserAdress varchar(30) not null


--��ǩ���ݱ�
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
IsDelete int check(IsDelete=0 or IsDelete=1) default(0) --��ɾ��
)
go
