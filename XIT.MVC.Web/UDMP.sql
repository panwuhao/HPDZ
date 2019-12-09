 --使用默认数据库
use master
go

--判断该数据库是否存在，如果存在，先删除。
if exists(select * from sys.databases where name='UDMP')
drop database UDMP

--创建UDMP数据库
create database UDMP 
go

--使用UDMP数据库
use UDMP

--判断角色表是否存在
if exists(select *from sys.tables where name='role')
drop table role
go
--角色表
create table role
(
	roleID int identity(1,1) primary key, --角色编号 （主键）
	roleName  varchar(20) not null, --角色名（不同部分不同开头，外键）
)
go
--插入角色信息
insert into role values
('学生'),
('老师'),
('班主任'),
('财务'),
('教务')

--判断登录注册表是否存在
if exists(select *from sys.tables where name='LoginInfo')
drop table LoginInfo
go
--登录注册表
create table LoginInfo
(
	LogID int identity(1,1) primary key, --角色编号 （主键）
	LogNum  varchar(20) not null, --登录账号
	LogPwd  varchar(20) not null, --密码
	roleID int  references role(roleID),--角色（外键）
	IsDelete int check(IsDelete=0 or IsDelete=1) default(0) --软删除
)
go
--插入登录信息
insert into LoginInfo values
('谭顺顺','123456',1,0),
('王洋','123456',1,0),
('潘武豪','123456',1,0),
('张建行','123456',1,0),
('田松茂','123456',1,0),
('赵涵','123456',1,0),
('王奔驰','123456',1,0),
('刘翔荣','123456',1,0),
('侯轲','123456',1,0),
('王莹莹','123456',1,0),
('白亚军','123456',1,0),
('柳林军','123456',1,0),
('李明','123456',1,0),
('宋玉鑫','123456',1,0),
('杨申','123456',1,0),
('彭霖','123456',1,0),
('王瑞祥','123456',2,0),
('谢建义','123456',2,0),
('王雪玲','123456',2,0),
('黎明','123456',2,0),
('刘瑾','123456',3,0),
('孟老师','123456',4,0),
('刘经理','admin',5,0)


--判断班级信息表是否存在
if exists(select *from sys.tables where name='ClassInfo')
drop table ClassInfo
go
--班级信息表
create table ClassInfo
(
	ClaID int identity(17311061,1) primary key, --班级编号（主键）
	ClaName  varchar(20) not null,  --班级名称
	IsDelete int check(IsDelete=0 or IsDelete=1) default(0) --软删除
)
go
insert into ClassInfo values
('.Net研发室',0),
('Java研发室',0),
('物联网研发室',0),
('企信信息化研发室',0)

--判断班课程表是否存在
if exists(select *from sys.tables where name='Course')
drop table Course
go
--课程表
create table Course
(
	CouID int primary key identity(101,1),--课程编号（主键）pk
	CouName varchar(50) not null ,--课程名称
	CouTime varchar(20) not null ,--时间（上一，上二，下一，下二）
	ClaID int references ClassInfo(ClaID),--班级（外键）
	IsDelete int check(IsDelete=0 or IsDelete=1) default(0) --软删除
)
go
insert into Course values
('EasyUI介绍','上一',17311061,0),
('Layout布局','上二',17311061,0),
('菜单和按钮','下一',17311061,0),
('From表单','下二',17311061,0),
('事务','上一',17311062,0),
('AJAX的应用','上二',17311062,0),
('AJAX技术分析篇','下一',17311062,0),
('AJAX技术应用篇','下二',17311062,0),
('AJAX技术实战篇','晚一',17311062,0),
('索引和视图','上一',17311063,0),
('存储过程（低级）','上二',17311063,0),
('存储过程（高级）','下一',17311063,0),
('职业体检','下二',17311063,0),
('T-SQL编程（低级）','上一',17311064,0),
('T-SQL编程（高级）','上二',17311064,0),
('项目答辩（上半场）','下一',17311064,0),
('项目答辩（下半场）','下二',17311064,0)

select * from Course
SELECT  dbo.Course.CouID, dbo.Course.CouName, dbo.Course.CouTime, dbo.ClassInfo.ClaName
FROM      dbo.Course INNER JOIN
                   dbo.ClassInfo ON dbo.Course.ClaID = dbo.ClassInfo.ClaID and Course.IsDelete=0

update Course set IsDelete=1 where CouID=101
--判断学生信息表是否存在
if exists(select *from sys.tables where name='StuInfo')
drop table StuInfo
go
--学生信息表
create table StuInfo
(
	StuID int identity(190901,1) primary key, --学生学号（主键）
	StuSex char(2) check(StuSex='男' or StuSex='女'),  --性别
	StuAge int not null,  --年龄
	StuPost varchar(100) null,  --有何职务
	StuAdmintime varchar(100) not null,  --入学时间
	StuGradtime varchar(100) not null,--毕业时间
	--StuState int check(StuState=1 or StuState=2 or StuState=3 or StuState=4) , --学校状态（在校/请假/休学/退学/）
	LogID int  references LoginInfo(LogID),--登录注册（外键）
	ClaID int references  ClassInfo(ClaID),--班级(外键)
	IsDelete int check(IsDelete=0 or IsDelete=1) default(0) --软删除
)
go
--插入学生信息
insert into StuInfo values
('男',20,'项目组长','2017-9-1','2020-6-30',1,17311061,0),
('男',20,'技术顾问','2017-9-1','2020-6-30',2,17311062,0),
('男',21,'学生','2017-9-1','2020-6-30',3,17311063,0),
('男',21,'学生','2017-9-1','2020-6-30',4,17311064,0),
('男',21,'学生','2017-9-1','2020-6-30',5,17311064,0),
('女',20,'学生','2017-9-1','2020-6-30',6,17311063,0),
('男',21,'技术顾问','2017-9-1','2020-6-30',7,17311062,0),
('男',22,'学生','2017-9-1','2020-6-30',8,17311061,0),
('男',21,'学生','2017-9-1','2020-6-30',9,17311061,0),
('女',21,'项目组长','2017-9-1','2020-6-30',10,17311062,0),
('男',21,'学生','2017-9-1','2020-6-30',11,17311063,0),
('男',22,'项目助理','2017-9-1','2020-6-30',12,17311064,0),
('男',21,'学生','2017-9-1','2020-6-30',13,17311064,0),
('男',22,'学生','2017-9-1','2020-6-30',14,17311063,0),
('男',21,'项目组长','2017-9-1','2020-6-30',15,17311062,0),
('男',21,'学生','2017-9-1','2020-6-30',16,17311061,0)
select * from StuInfo
SELECT   dbo.StuInfo.StuID, dbo.StuInfo.StuAge, dbo.StuInfo.StuSex, dbo.StuInfo.StuPost, dbo.StuInfo.StuAdmintime, 
                dbo.StuInfo.StuGradtime, dbo.LoginInfo.LogNum, dbo.ClassInfo.ClaName
FROM      dbo.StuInfo INNER JOIN
                dbo.LoginInfo ON dbo.StuInfo.LogID = dbo.LoginInfo.LogID INNER JOIN
                dbo.ClassInfo ON dbo.StuInfo.ClaID = dbo.ClassInfo.ClaID and StuInfo.IsDelete=0 and StuID=190901

--判断学期表是否存在
if exists(select *from sys.tables where name='Semester')
drop table Semester
go
--学期表
create table Semester
(
	StrID int  identity(1,1) primary key, --学期编号（主键）
	StrName varchar(100) not null, --学期名
	IsDelete int check(IsDelete=0 or IsDelete=1) default(0) --软删除
)
insert into Semester values
('2017-2018上半学期',0),
('2017-2018下半学期',0),
('2018-2019上半学期',0),
('2018-2019下半学期',0)



--判断科目表是否存在
if exists(select *from sys.tables where name='Subject')
drop table Subject
go
--科目表
create table Subject
(
	SubID	int  identity(1,1) primary key, --科目编号（主键）
	SubName   varchar(20) not null, --科目名
	IsDelete int check(IsDelete=0 or IsDelete=1) default(0) --软删除
)
--插入科目信息
insert into Subject values 
('HTML',0),
('SQL',0),
('Web',0),
('Java',0),
('WinForm',0),
('物联网（高级）',0),
('PHP',0)


--判断成绩表是否存在
if exists(select *from sys.tables where name='StuScore')
drop table StuScore
go
--成绩表
create table StuScore
(
	stuSID int primary key identity(1,1),--主键
	StuID int references StuInfo(StuID), --学生学号（主键）
	Score 	float ,		--成绩
	SubID	int	 references Subject(SubID),	--科目（外键）
	StrID	int references Semester(StrID),	--学期（外键）
	IsDelete int check(IsDelete=0 or IsDelete=1) default(0) --软删除
)
go
insert into StuScore values
(190901,90,1,1,0),
(190902,85.5,1,1,0),
(190903,60,1,1,0),
(190904,75,1,1,0),
(190905,80,1,1,0),
(190906,45,1,1,0),
(190907,0,1,1,0),
(190908,56,1,1,0),
(190909,55.5,1,1,0),
(190910,85,1,1,0),
(190911,86,1,1,0),
(190912,70,1,1,0),
(190913,92,1,1,0),
(190914,50,1,1,0),
(190915,60,1,1,0),
(190916,60,1,1,0),

(190901,90,2,1,0),
(190902,85.5,2,1,0),
(190903,60,2,1,0),
(190904,75,2,1,0),
(190905,80,2,1,0),
(190906,45,2,1,0),
(190907,0,2,1,0),
(190908,56,2,1,0),
(190909,55.5,2,1,0),
(190910,85,2,1,0),
(190911,86,2,1,0),
(190912,70,2,1,0),
(190913,92,2,1,0),
(190914,50,2,1,0),
(190915,60,2,1,0),
(190916,60,2,1,0)


select * from LoginInfo,StuInfo,StuScore where LoginInfo.LogID=StuInfo.LogID and StuInfo.StuID=StuScore.StuID

select * from LoginInfo,StuInfo,StuScore,ClassInfo where LoginInfo.LogID=StuInfo.LogID and StuInfo.StuID=StuScore.StuID and StuInfo.ClaID=ClassInfo.ClaID and LogNum='王洋'

select * from LoginInfo,StuInfo,StuScore,ClassInfo where LoginInfo.LogID=StuInfo.LogID and StuInfo.StuID=StuScore.StuID and StuInfo.ClaID=ClassInfo.ClaID

select * from LoginInfo,StuInfo,StuScore where LoginInfo.LogID=StuInfo.LogID and StuInfo.StuID=StuScore.StuID and 1=1

--insert into  LoginInfo,StuInfo,StuScore values()
--select * from LoginInfo,StuScore right outer join StuInfo on StuScore.StuID=StuInfo.StuID where LoginInfo.LogNum='王洋'
if exists(select *from sys.tables where name='StuLeave')
drop table StuLeave
go
--请假表（学生）
create table StuLeave
(
	LeaID int primary key identity(1,1), --主键
	StuID int references StuInfo(StuID), --请假人编号（外键）
	LeaBegintime  datetime ,  -- 请假时间
	LeaEndtime datetime default(null),  --请假结束时间
	LeaCause varchar(100) not null, --请假缘由
	LeaState bit check(LeaState=0 or LeaState=1),  --审批状态 0:未审批 1:已审批
	IsDelete int check(IsDelete=0 or IsDelete=1) default(0) --软删除
)
--请假表（学生）信息
insert into StuLeave values
(190901,'2019-10-17','2019-10-18','去医务室',0,0),
(190902,'2019-10-7','2019-10-9','外出参加比赛',1,0),
(190905,'2019-10-7','2019-10-9','参加婚礼',0,0),
(190915,'2019-10-17','2019-10-25','家中有事',1,0),
(190916,'2019-10-7','2019-10-9','体检',0,0),
(190903,'2019-10-7','2019-10-9','找工作',1,0)


--判断老师信息表是否存在
if exists(select *from sys.tables where name='TeacherInfo')
drop table TeacherInfo
go
--老师信息表
create table TeacherInfo
(
	TeaID int identity(1001,1) primary key, --老师编号（主键）
	TeaSex char(2) check(TeaSex='男' or TeaSex='女'),  --性别
	TeaAge int not null,  --年龄
	ClaID int references ClassInfo(ClaID), -- 负责班级（外键）
	LogID int  references LoginInfo(LogID),--登录注册（外键）
	SubID int  references Subject(SubID),--科目（外键）
	IsDelete int check(IsDelete=0 or IsDelete=1) default(0) --软删除
)
--插入教师表信息
insert into TeacherInfo values
('男',26,17311061,17,1,0),
('男',26,17311062,18,2,0),
('女',27,17311063,19,3,0),
('女',26,17311064,20,4,0),
('女',27,17311063,21,3,0)

select * from TeacherInfo
--SELECT   dbo.TeacherInfo.TeaID, dbo.TeacherInfo.TeaSex, dbo.TeacherInfo.TeaAge, dbo.LoginInfo.LogNum, 
--                dbo.Subject.SubName, dbo.StuLeave.StuID, dbo.ClassInfo.ClaName
--FROM      dbo.TeacherInfo INNER JOIN
--                dbo.ClassInfo ON dbo.TeacherInfo.ClaID = dbo.ClassInfo.ClaID INNER JOIN
--                dbo.LoginInfo ON dbo.TeacherInfo.LogID = dbo.LoginInfo.LogID INNER JOIN
--                dbo.StuLeave ON dbo.TeacherInfo.LeaID = dbo.StuLeave.LeaID INNER JOIN
--                dbo.Subject ON dbo.TeacherInfo.SubID = dbo.Subject.SubID 


--判断请假表是否存在（老师）
if exists(select *from sys.tables where name='TeLeave')
drop table TeLeave

--请假表（老师）
create table TeLeave
(
	LeaID int primary key identity(1,1), --主键
	TeaID int references TeacherInfo(TeaID), --请假人编号（外键）
	LeaBegintime datetime ,  -- 请假时间
	LeaEndtime datetime default(null),  --请假结束时间
	LeaCause varchar(100) not null, --请假缘由
	LeaState bit check(LeaState=0 or LeaState=1),  --审批状态 0:未审批 1:已审批
	IsDelete int check(IsDelete=0 or IsDelete=1) default(0) --软删除
)

select * from TeLeave where TeaID=1001

update TeLeave set LeaState=0 where LeaID=4
--插入请假表（教师）信息
insert into TeLeave values 
(1001,'2019-11-20','2019-11-27','结婚',0,0),
(1002,'2019-10-7','2019-10-8','体检',1,0),
(1004,'2019-11-25','2019-11-25','参加婚礼',1,0)


if exists(select *from sys.tables where name='Appraisal')
drop table Appraisal
go
--评教表（学生进行评教）代码实现权限查看（最高查看，本级不能互看）
create table Appraisal
(
	AppID int primary key identity(1,1),--主键
	StuID int references StuInfo(StuID), --评教人（外键）
	TeaID int references TeacherInfo(TeaID), --被评教人（外键）
	AppRemark  varchar(200) not null,  --评语
	AppGrade int not null,  -- 打分
	AppTime datetime default(getdate()),  --评教时间
	AppState bit check(AppState=0 or AppState=1),  --是否评教 1:是 0:否 
	IsDelete int check(IsDelete=0 or IsDelete=1) default(0) --软删除
)
--插入评教表信息
insert into Appraisal values
(190901,1001,'很有耐心',90,getdate(),1,0),
(190901,1002,'很有耐心',95,getdate(),1,0),
(190901,1003,'很有耐心',90,getdate(),1,0),
(190901,1004,'很有耐心',90,getdate(),1,0),
(190902,1001,'很有耐心',90,getdate(),2,0),
(190902,1002,'很有耐心',95,getdate(),2,0),
(190902,1003,'很有耐心',90,getdate(),2,0),
(190902,1004,'很有耐心',90,getdate(),2,0)

--判断财务报表信息表是否存在
if exists(select *from sys.tables where name='Finance')
drop table Finance
--财务报表信息表
create table Finance
(
	FinID int primary key identity(1,1), --财务编号（主键）
	FinType varchar(100) check(FinType=1 or FinType=2 or  FinType=3), --消费类型  可以单拉  1.住宿 2.书本 3.学费
	FinTime datetime default(null),  -- 消费时间
	FinLimit int not null,  --消费额度
	IsDelete int check(IsDelete=0 or IsDelete=1) default(0) --软删除
)
--插入财务报表信息
insert into Finance values
(1,getdate(),800,0),
(2,getdate(),400,0),
(3,getdate(),3600,0)
--delete from Finance where FinID=2
 --select FinLimit,count(FinLimit) as FinType from Finance group by FinLimit
--判断学生缴费信息表是否存在
if exists(select *from sys.tables where name='Payment')
drop table Payment
--学生缴费信息表
create table Payment
(
	PayID int primary key identity(1,1), --信息ID（主键）
	StuID int references StuInfo(StuID) , --学生学号（学生信息表 外键）
	--StuName  varchar(20) not null,  --姓名
	Payable int not null,  --应缴费用
	PayTime datetime default(null),-- 缴费日期
	PayPaidin int,  --已缴费用
	PayArrearage  int,  --欠款费用
	IsDelete int check(IsDelete=0 or IsDelete=1) default(0) --软删除
)
--学生缴费信息表
insert into Payment values
(190901,4800,getdate(),4000,800,0),
(190902,4800,getdate(),4000,800,0),
(190903,4800,getdate(),4000,800,0),
(190904,4800,getdate(),4000,800,0),
(190905,4800,getdate(),4000,800,0),
(190906,4800,getdate(),4000,800,0),
(190907,4800,getdate(),4000,800,0),
(190908,4800,getdate(),4000,800,0),
(190909,4800,getdate(),4000,800,0),
(190910,4800,getdate(),4000,800,0),
(190911,4800,getdate(),4000,800,0),
(190912,4800,getdate(),4000,800,0),
(190913,4800,getdate(),4000,800,0),
(190914,4800,getdate(),4000,800,0),
(190915,4800,getdate(),4000,800,0),
(190916,4800,getdate(),4000,800,0)

----角色表
--select * from role
----登录表
--select * from LoginInfo 
----班级表
--select * from ClassInfo
----科目表
--select * from Subject
----学生信息表
--select * from StuInfo,LoginInfo where StuInfo.LogID = LoginInfo.LogID
----学期表
--select * from Semester
----成绩表
--select * from StuScore
----请假表（学生）
--select * from StuLeave
----教师表
--select * from TeacherInfo,LoginInfo where TeacherInfo.LogID = LoginInfo.LogID
----请假（教师）
--select * from TeLeave
----评教表
--select * from Appraisal
----财务信息表
--select * from Finance
----学生缴费信息表
--select * from Payment
select * from StuInfo where LogID=17