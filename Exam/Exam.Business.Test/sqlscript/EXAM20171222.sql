create database ExamDB
go
use ExamDB
go
--��Ѷ��
create table NewsInfo
(
	NewsInfoid int identity(1000,1),			--���
	title nvarchar(50) not null,		--����
	content nvarchar(max) not null,		--����
	author nvarchar(50) not null,		--������Դ
	newsCategoryId int,				--��Ѷ������
	imageId int,					--����ͼ���
	sort int default(99),				--����
	reads int default(0),				--�Ķ���
	isTop int default(0),				--�Ƿ��ö�
	isHot int default(0),				--�Ƿ�����
	ctime datetime default(getdate()),	--����ʱ��
	utime datetime default(getdate()),	--�޸�ʱ��
)
--��Ѷ�����
create table NewsCategory
(
	NewsCategoryId int identity(1000,1),			--���
	title nvarchar(50) not null,		--�������
	ctime datetime default(getdate()),	--����ʱ��
	sort int default(99),				--����
	utime datetime default(getdate()),	--�޸�ʱ��
)
--ͼƬ��
create table ImageInfo
(
	ImageInfoId int identity(1000,1),			--���
	title nvarchar(50),					--ͼƬ����
	url nvarchar(255) not null,			--·��
	ctime datetime default(getdate()),	--����ʱ��
)
--��ʦ��
create table Lecturer
(
	LecturerId int identity(1000,1),			--���
	name nvarchar(50) not null,			--����
	position nvarchar(50) not null,		--ְλ
	imageInfoId int,					--ͼƬ���
	abstracts nvarchar(255),				--ժҪ���
	sort int default(99),				--����
	introduce nvarchar(max),			--����
	ctime datetime default(getdate()),	--����ʱ��
	utime datetime default(getdate()),	--�޸�ʱ��
)
--�����
create table Problem
(
	ProblemId int identity(1000,1),			--���
	title nvarchar(50) not null,		--����
	ProblemCategoryId int,				--������
	belongId int,						--��Ŀ�������
	ChapterId int,						--�½ڷ���
	isHot int,							--�Ƿ�����
	ctime datetime default(getdate()),	--����ʱ��
	sort int default(99),				--����
	utime datetime default(getdate()),	--�޸�ʱ��
	Score int,							--����
)
--�𰸱�
create table Answer
(
	AnswerId int identity(1000,1),			--���
	title nvarchar(50) not null,		--����
	ProblemId int,						--�������
	isCorrect int,						--�Ƿ���ȷ�� 0����1��ȷ
	
)
--�����ʱ�����ڴ��ץȡ������
create table ProblemLibrary
(
	ProblemLibraryId int identity(1000,1),			--���
	title nvarchar(50) not null,		--����
	ProblemCategoryId int,				--������
	BelongId int,						--��Ŀ�������
	ctime datetime default(getdate()),	--����ʱ��
)
--��Ŀ���--��ѡ����ѡ���жϣ��ʴ�
create table ProblemCategory
(
	ProblemCategoryId int identity(1000,1),			--���
	title nvarchar(50) not null,		--�������
	ctime datetime default(getdate()),	--����ʱ��
	sort int default(99),				--����
	utime datetime default(getdate()),	--�޸�ʱ��
)
--��Ŀ����--ע�ᣬ�������м����߼���˰��ʦ
create table Belong
(
	BelongId int identity(1000,1),			--���
	title nvarchar(50) not null,		--�������
	ctime datetime default(getdate()),	--����ʱ��
	sort int default(99),				--����
	utime datetime default(getdate()),	--�޸�ʱ��
)
--�½ڷ���
create table Chapter
(
	ChapterId int identity(1000,1),			--���
	title nvarchar(50) not null,		--�������
	ctime datetime default(getdate()),	--����ʱ��
	sort int default(99),				--����
	utime datetime default(getdate()),	--�޸�ʱ��
)
--���ʱ�
create table Question
(
	QuestionId int identity(1000,1),			--���
	title nvarchar(50) not null,		--����
	content nvarchar(max) not null,		--����
	UserInfoId int,							--�û����
	sort int default(99),				--����
	reads int default(0),				--�Ķ���
	isTop int default(0),				--�Ƿ��ö�
	isHot int default(0),				--�Ƿ�����
	ctime datetime default(getdate()),	--����ʱ��
)
--�ش��
create table Reply
(
	Replyid int identity(1000,1),			--���
	content nvarchar(max) not null,		--����
	UserInfoId int,							--�û����
	QuestionId int,						--���ʱ���
	sort int default(99),				--����
	reads int default(0),				--�Ķ���
	ctime datetime default(getdate()),	--����ʱ��
)
--�û���
create table UserInfo
(
	UserInfoid int identity(1000,1),			--���
	ctime datetime default(getdate()),	--����ʱ��
	phone varchar(20),					--�ֻ�����
	imageId int,						--ͷ����
	gradeid int,						--�ȼ�
	nikeName nvarchar(50) not null,		--�ǳ�
	gender int,							--�Ա� 0��Ů 1����
	sysgroupId int,						--�û���Id
	isEnable int,						--�Ƿ�����0Ϊ���ã�1Ϊ����
	
)
--�ȼ��� ѧԱ����ʦ
create table Grade
(
	gradeid int identity(1000,1),			--���
	title nvarchar(50) not null,		--����
	ctime datetime default(getdate()),	--����ʱ��
	utime datetime default(getdate()),	--�޸�ʱ��
)


--�û����
create table SysGroup
(
	SysGroupId int identity(1000,1),			--���
	name nvarchar(50) not null,			--����
	sortNo int,							--����		
	[type] int,							--��������(��̨��app)	
	isEnable int,						--�Ƿ�����0Ϊ���ã�1Ϊ����
	ctime datetime default(getdate()),	--����ʱ��
	utime datetime default(getdate()),	--�޸�ʱ��
)
--�˵���
create table SysMenu
(
	SysMenuId int identity(1000,1),		--���
	name nvarchar(50) not null,			--����
	Fid int,							--�����˵�Id
	url nvarchar(200),					--�˵���ַ
	icon nvarchar(100),					--�˵�ͼ��
	[type] int,							--�˵�����(��̨��app)
	remark nvarchar(300),				--˵��
	sortNo int,							--����		
	isEnable int,						--�Ƿ�����0Ϊ���ã�1Ϊ����
	ctime datetime default(getdate()),	--����ʱ��
	utime datetime default(getdate()),	--�޸�ʱ��
)

--��˵���
create table SysGroupMenu
(
	SysGroupMenuId int identity(1000,1),			--��� 
	SysMenuId int,							--�˵�Id
	SysGroupId int,							--��Id 
	ctime datetime default(getdate()),	--����ʱ��
	utime datetime default(getdate()),	--�޸�ʱ��
)

--�û������¼��
create table UserInfoAnswerRecord
(
	AnswerRecordId int identity(1000,1),			--��� 
	UserInfoId int,							--�û����
	Score int,							--����
	Title nvarchar(200),                --���Ա���
	belongId int,						--��Ŀ�������
	ChapterId int,						--�½ڷ���
	ctime datetime default(getdate()),	--����ʱ��
	utime datetime default(getdate()),	--�޸�ʱ��
)

--�����¼��
create table ProblemRecord
(
	ProblemRecordId int identity(1000,1),	
	ProblemId int,			--���
	title nvarchar(50) not null,		--����
	ProblemCategoryId int,				--������
	CorrectAnswer nvarchar(50),			--��ȷ��
	ErrorAnswer nvarchar(50),			--�����
	ctime datetime default(getdate()),	--����ʱ��
	utime datetime default(getdate()),	--�޸�ʱ��
)
--�𰸼�¼��
create table AnswerRecord
(
	AnswerRecordId int identity(1000,1),  --���
	ProblemRecordId int,				---�����¼��Id
	AnswerId int,						--��id
	title nvarchar(50) not null,		--����
	ProblemId int,						--�������
	isCorrect int,						--�Ƿ���ȷ�� 0����1��ȷ
	
)

--��Ŀ�ղر�
create table ProblemCollect
(
	ProblemCollectId int identity(1000,1),  --���
	ProblemId int,										--����Id
	UserInfoId int,										--�û�id
	ctime datetime default(getdate()),	--����ʱ��
	utime datetime default(getdate()),	--�޸�ʱ��
	
)
