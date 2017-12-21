create database ExamDB
go
use ExamDB
go
--资讯表
create table NewsInfo
(
	NewsInfoid int identity(1000,1),			--编号
	title nvarchar(50) not null,		--标题
	content nvarchar(max) not null,		--内容
	author nvarchar(50) not null,		--作者来源
	newsCategoryId int,				--资讯分类编号
	imageId int,					--封面图编号
	sort int default(99),				--排序
	reads int default(0),				--阅读数
	isTop int default(0),				--是否置顶
	isHot int default(0),				--是否热门
	ctime datetime default(getdate()),	--创建时间
	utime datetime default(getdate()),	--修改时间
)
--资讯分类表
create table NewsCategory
(
	NewsCategoryId int identity(1000,1),			--编号
	title nvarchar(50) not null,		--分类标题
	ctime datetime default(getdate()),	--创建时间
	sort int default(99),				--排序
	utime datetime default(getdate()),	--修改时间
)
--图片表
create table ImageInfo
(
	ImageInfoId int identity(1000,1),			--编号
	title nvarchar(50),					--图片标题
	url nvarchar(255) not null,			--路径
	ctime datetime default(getdate()),	--创建时间
)
--讲师表
create table Lecturer
(
	LecturerId int identity(1000,1),			--编号
	name nvarchar(50) not null,			--名称
	position nvarchar(50) not null,		--职位
	imageInfoId int,					--图片编号
	abstract nvarchar(255),				--摘要简介
	sort int default(99),				--排序
	introduce nvarchar(max),			--介绍
)
--问题表
create table Problem
(
	ProblemId int identity(1000,1),			--编号
	title nvarchar(50) not null,		--标题
	ProblemCategoryId int,				--类别分类
	belongId int,						--题目所属编号
	ChapterId int,						--章节分类
	isHot int,							--是否热门
	ctime datetime default(getdate()),	--创建时间
	sort int default(99),				--排序
	utime datetime default(getdate()),	--修改时间
)
--答案表
create table Answer
(
	AnswerId int identity(1000,1),			--编号
	title nvarchar(50) not null,		--标题
	ProblemId int,						--问题表编号
	isCorrect int,						--是否正确答案 0错误1正确
	
)
--题库临时表，用于存放抓取的数据
create table ProblemLibrary
(
	ProblemLibraryId int identity(1000,1),			--编号
	title nvarchar(50) not null,		--标题
	ProblemCategoryId int,				--类别分类
	BelongId int,						--题目所属编号
	ctime datetime default(getdate()),	--创建时间
)
--题目类别--单选，多选，判断，问答，
create table ProblemCategory
(
	ProblemCategoryId int identity(1000,1),			--编号
	title nvarchar(50) not null,		--分类标题
	ctime datetime default(getdate()),	--创建时间
	sort int default(99),				--排序
	utime datetime default(getdate()),	--修改时间
)
--题目所属--注会，初级，中级，高级，税务师
create table Belong
(
	BelongId int identity(1000,1),			--编号
	title nvarchar(50) not null,		--分类标题
	ctime datetime default(getdate()),	--创建时间
	sort int default(99),				--排序
	utime datetime default(getdate()),	--修改时间
)
--章节分类
create table Chapter
(
	ChapterId int identity(1000,1),			--编号
	title nvarchar(50) not null,		--分类标题
	ctime datetime default(getdate()),	--创建时间
	sort int default(99),				--排序
	utime datetime default(getdate()),	--修改时间
)
--提问表
create table Question
(
	QuestionId int identity(1000,1),			--编号
	title nvarchar(50) not null,		--标题
	content nvarchar(max) not null,		--内容
	UserInfoId int,							--用户编号
	sort int default(99),				--排序
	reads int default(0),				--阅读数
	isTop int default(0),				--是否置顶
	isHot int default(0),				--是否热门
	ctime datetime default(getdate()),	--创建时间
)
--回答表
create table Reply
(
	Replyid int identity(1000,1),			--编号
	content nvarchar(max) not null,		--内容
	userId int,							--用户编号
	QuestionId int,						--提问表编号
	sort int default(99),				--排序
	reads int default(0),				--阅读数
	ctime datetime default(getdate()),	--创建时间
)
--用户表
create table UserInfo
(
	UserInfoid int identity(1000,1),			--编号
	ctime datetime default(getdate()),	--创建时间
	imageId int,						--头像编号
	gradeid int,						--等级
	nikeName nvarchar(50) not null,		--昵称
	gender int,							--性别 0是女 1是男
	sysgroupId int,						--用户组Id
	isEnable int,						--是否启用0为启用，1为禁用
	
)
--等级表 学员，老师
create table Grade
(
	gradeid int identity(1000,1),			--编号
	title nvarchar(50) not null,		--标题
	ctime datetime default(getdate()),	--创建时间
	utime datetime default(getdate()),	--修改时间
)


--用户组表
create table SysGroup
(
	SysGroupId int identity(1000,1),			--编号
	name nvarchar(50) not null,			--组名
	sortNo int,							--排序		
	isEnable int,						--是否启用0为启用，1为禁用
	ctime datetime default(getdate()),	--创建时间
	utime datetime default(getdate()),	--修改时间
)
--菜单表
create table SysMenu
(
	SysMenuId int identity(1000,1),		--编号
	name nvarchar(50) not null,			--组名
	Fid int,							--父级菜单Id
	url nvarchar(200),					--菜单地址
	icon nvarchar(100),					--菜单图标
	remark nvarchar(300),				--说明
	sortNo int,							--排序		
	isEnable int,						--是否启用0为启用，1为禁用
	ctime datetime default(getdate()),	--创建时间
	utime datetime default(getdate()),	--修改时间
)

--菜单表
create table SysGroupMenu
(
	SysGroupMenuId int identity(1000,1),			--编号 
	SysMenuId int,							--菜单Id
	SysGroupId int,							--组Id 
	ctime datetime default(getdate()),	--创建时间
	utime datetime default(getdate()),	--修改时间
)