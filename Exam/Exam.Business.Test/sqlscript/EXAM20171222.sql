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
	abstracts nvarchar(255),				--摘要简介
	sort int default(99),				--排序
	introduce nvarchar(max),			--介绍
	ctime datetime default(getdate()),	--创建时间
	utime datetime default(getdate()),	--修改时间
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
	isImportant int default(0),							--是否重要
	ctime datetime default(getdate()),	--创建时间
	sort int default(99),				--排序
	utime datetime default(getdate()),	--修改时间
	Score int,							--分数
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
	isEnable int,						--是否启用0为启用，1为禁用
	ctime datetime default(getdate()),	--创建时间
)
--回答表
create table Reply
(
	Replyid int identity(1000,1),			--编号
	content nvarchar(max) not null,		--内容
	UserInfoId int,							--用户编号
	QuestionId int,						--提问表编号
	sort int default(99),				--排序
	isEnable int,						--是否启用0为启用，1为禁用
	reads int default(0),				--阅读数
	ctime datetime default(getdate()),	--创建时间
)
--用户表
create table UserInfo
(
	UserInfoid int identity(1000,1),			--编号
	ctime datetime default(getdate()),	--创建时间
	phone varchar(20),					--手机号码
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
	[type] int,							--分组类型(后台，app)	
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
	[type] int,							--菜单类型(后台，app)
	remark nvarchar(300),				--说明
	sortNo int,							--排序		
	isEnable int,						--是否启用0为启用，1为禁用
	ctime datetime default(getdate()),	--创建时间
	utime datetime default(getdate()),	--修改时间
)

--组菜单表
create table SysGroupMenu
(
	SysGroupMenuId int identity(1000,1),			--编号 
	SysMenuId int,							--菜单Id
	SysGroupId int,							--组Id 
	ctime datetime default(getdate()),	--创建时间
	utime datetime default(getdate()),	--修改时间
)

--用户答题记录表
create table UserInfoAnswerRecord
(
	AnswerRecordId int identity(1000,1),			--编号 
	UserInfoId int,							--用户编号
	Score int,							--分数
	Title nvarchar(200),                --考试标题
	BelongId int,						--题目所属编号
	ChapterId int,						--章节分类
	CTime datetime default(getdate()),	--创建时间
	UTime datetime default(getdate()),	--修改时间
)

--问题记录表
create table ProblemRecord
(
	ProblemRecordId int identity(1000,1),	
	ProblemId int,			--编号
	Title nvarchar(50) not null,		--标题
	ProblemCategoryId int,				--类别分类
	CorrectAnswer nvarchar(50),			--正确答案
	ErrorAnswer nvarchar(50),			--错误答案
	UserInfoAnswerRecord int,			--用户答题记录表ID
	UserInfoId int,			--用户ID
	Analysis nvarchar(max),			--答案分析
	YesOrNo int,		--是否正确（1，2）
	CTime datetime default(getdate()),	--创建时间
	UTime datetime default(getdate()),	--修改时间
)
--答案记录表
create table AnswerRecord
(
	AnswerRecordId int identity(1000,1),  --编号
	ProblemRecordId int,				---问题记录表Id
	AnswerId int,						--答案id
	Title nvarchar(50) not null,		--标题
	ProblemId int,						--问题表编号
	IsCorrect int,						--是否正确答案 0错误1正确
	
)

--题目收藏表
create table ProblemCollect
(
	ProblemCollectId int identity(1000,1),  --编号
	ProblemId int,										--问题Id
	UserInfoId int,										--用户id
	ctime datetime default(getdate()),	--创建时间
	utime datetime default(getdate()),	--修改时间
	
)

--消息通知表
create table [Notification]
(
	NotificationId int identity(1000,1),  --编号
	ObjectId int,										--实体对象Id
	UserInfoId int,	--用户id
	Title nvarchar(500),								--标题
	TypeId int,										--消息类型id
	ctime datetime default(getdate()),	--创建时间
	utime datetime default(getdate()),	--修改时间
	
)



--广告表
create table Advertisement
(
	AdvertisementId int identity(1000,1),   --编号
	UserInfoId int,						    --用户id
	Title nvarchar(500),					--标题
	TypeId int,								--广告类型
	ImageInfoId	int,						--广告图片
	CTime datetime default(getdate()),		--创建时间
	UTime datetime default(getdate()),		--修改时间
	
)

--版本表VersionTable

create table VersionTable
(
	VersionTableId int identity(1000,1),   --编号
	Title nvarchar(50),						    --版本名称
	VersionText nvarchar(500),					--版本编号
	TypeId int,								--版本类型
	CTime datetime default(getdate()),		--创建时间
	
)

--科目表SubjectInfo
create table SubjectInfo
(
	SubjectInfoId int identity(1000,1),     --编号
	Title nvarchar(500),					--名称
	Sort int,								--排序
	CTime datetime default(getdate()),		--创建时间
	UTime datetime default(getdate()),		--修改时间
)
--考试分类记录表
create table UserExamClass
(
	UserExamClassId int identity(1000,1),			--编号
	UserInfoId int,								--用户id
	ExamClassId int,							--考试分类表Id
	Title nvarchar(500),						--标题
	StartTime datetime default(getdate()),		--考试开始时间
	EndTime  datetime default(getdate()),		--考试结束时间
	IsShow int default(1),						--是否显示考试
	Score decimal(18, 2),						--考试分数
	Sort int,									--排序
	CreateTime datetime default(getdate()),		--创建时间
	IsExam int	 default(1),					--是否改卷 1默认2是已经批卷
)
--考试问题记录表
create table UserExamProblem
(
	UserExamProblemId int identity(1000,1),	--编号
	title nvarchar(50) not null,		--标题
	ProblemCategoryId int,				--类别分类
	UserExamClassId int,					--考试分类表Id
	CTime datetime default(getdate()),	--创建时间
	Sort int default(99),				--排序
	UTime datetime default(getdate()),	--修改时间
	Score decimal(18, 2),				--分数
	CorrectAnswer nvarchar(2000),			--正确答案
	ErrorAnswer nvarchar(2000),			--错误答案
)

--考试问题表答案选项表
create table UserExamAnswer
(
	UserExamAnswerId int identity(1000,1),			--编号
	Title nvarchar(50) not null,		--标题
	ExamProblemId int,						--问题表编号
	isCorrect int,						--是否正确答案 0错误1正确
)


--考试分类表
create table ExamClass
(
	ExamClassId int identity(1000,1),			--编号
	Title nvarchar(500),						--标题
	StartTime datetime default(getdate()),		--考试开始时间
	EndTime  datetime default(getdate()),		--考试结束时间
	IsShow int default(1),						--是否显示考试
	Score decimal(18, 2),						--考试分数
	Sort int,									--排序
	CreateTime datetime default(getdate()),		--创建时间

)
--考试问题表
create table ExamProblem
(
	ExamProblemId int identity(1000,1),	--编号
	title nvarchar(50) not null,		--标题
	ProblemCategoryId int,				--类别分类
	ExamClassId int,					--考试分类表Id
	CTime datetime default(getdate()),	--创建时间
	Sort int default(99),				--排序
	UTime datetime default(getdate()),	--修改时间
	Score decimal(18, 2),				--分数
)

--考试问题表答案选项表
create table ExamAnswer
(
	ExamAnswerId int identity(1000,1),			--编号
	Title nvarchar(50) not null,		--标题
	ExamProblemId int,						--问题表编号
	isCorrect int,						--是否正确答案 0错误1正确
)
--视频表
create table Video
(
	VideoId int identity(1000,1),		--编号
	Title nvarchar(50),		--标题
	VideoClassId int,		--分类编号
	BelongId int,			--所属
	imageInfoId int,					--图片编号
	Url nvarchar(500),			--地址
	Ctime datetime default(getdate()),	--创建时间
	Sort int default(99),				--排序
	Utime datetime default(getdate()),	--修改时间
)
--视频分类表
create table VideoClass
(
	VideoClassId int identity(1000,1),		--编号
	Title nvarchar(50) not null,		--分类标题
	Ctime datetime default(getdate()),	--创建时间
	Sort int default(99),				--排序
	Utime datetime default(getdate()),	--修改时间
)