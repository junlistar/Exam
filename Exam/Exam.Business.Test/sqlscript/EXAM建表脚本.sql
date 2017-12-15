USE [master]
GO
/****** Object:  Database [Exam]    Script Date: 12/15/2017 16:50:38 ******/
CREATE DATABASE [Exam] ON  PRIMARY 
( NAME = N'Exam', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Exam.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Exam_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Exam_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Exam] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Exam].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Exam] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Exam] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Exam] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Exam] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Exam] SET ARITHABORT OFF
GO
ALTER DATABASE [Exam] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [Exam] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Exam] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Exam] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Exam] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Exam] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [Exam] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Exam] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Exam] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Exam] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Exam] SET  DISABLE_BROKER
GO
ALTER DATABASE [Exam] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Exam] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Exam] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Exam] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Exam] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Exam] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [Exam] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [Exam] SET  READ_WRITE
GO
ALTER DATABASE [Exam] SET RECOVERY FULL
GO
ALTER DATABASE [Exam] SET  MULTI_USER
GO
ALTER DATABASE [Exam] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Exam] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'Exam', N'ON'
GO
USE [Exam]
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 12/15/2017 16:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Age] [int] NULL,
	[Comment] [nvarchar](1000) NULL,
	[CreateTime] [datetime] NULL,
 CONSTRAINT [PK_UserInfo_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
