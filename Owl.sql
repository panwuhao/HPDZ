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
insert into Userinfo values('p1051250511','�����','123456','1051250511@qq.com','15516070627','��','����ʡ֣���о�����')
insert into Userinfo values('d1872311885','	������','123456','1872311885@qq.com','15290605027','Ů','����ʡ֣���о�����')
insert into Userinfo values('d1872311885','	�Ž���','123456','1486358520@qq.com','18530599939','��','����ʡ֣���о�����')
insert into Userinfo values('d1872311885','	����','123456','2536071741@qq.com','15737473190','��','����ʡ֣���о�����')

--��ǩ���ݱ�
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
IsDelete int check(IsDelete=0 or IsDelete=1) default(0) --��ɾ��
)
go
select * from Noteinfo
insert into Noteinfo values('��һ�β���','èͷӥ:���嵭��ɫ,��ڰ�,ͷ���н�״����ë,ͷ��,����ֻ��ǰ���Ĵ���,�̶��������,ǿ�����Ĺ�צ,�ܷ�ת����ֺ���ֽ�ҹè��',1,default,default,default)
insert into Noteinfo values('�ڶ��β���','èͷӥ:���嵭��ɫ,��ڰ�,ͷ���н�״����ë,ͷ��,����ֻ��ǰ���Ĵ���,�̶��������,ǿ�����Ĺ�צ,�ܷ�ת����ֺ���ֽ�ҹè��',1,default,default,default)
insert into Noteinfo values('�����β���','èͷӥ:���嵭��ɫ,��ڰ�,ͷ���н�״����ë,ͷ��,����ֻ��ǰ���Ĵ���,�̶��������,ǿ�����Ĺ�צ,�ܷ�ת����ֺ���ֽ�ҹè��',1,default,default,default)
insert into Noteinfo values('���Ĵβ���','èͷӥ:���嵭��ɫ,��ڰ�,ͷ���н�״����ë,ͷ��,����ֻ��ǰ���Ĵ���,�̶��������,ǿ�����Ĺ�צ,�ܷ�ת����ֺ���ֽ�ҹè��',1,default,default,default)
