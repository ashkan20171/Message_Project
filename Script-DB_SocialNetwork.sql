USE [master]
GO
/****** Object:  Database [MsgDB]    Script Date: 16/01/2021 01:31:18 ب.ظ ******/
CREATE DATABASE [MsgDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MsgDB', FILENAME = N'G:\Program\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\MsgDB.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MsgDB_log', FILENAME = N'G:\Program\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\MsgDB_log.ldf' , SIZE = 3456KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MsgDB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MsgDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MsgDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MsgDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MsgDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MsgDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MsgDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [MsgDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MsgDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MsgDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MsgDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MsgDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MsgDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MsgDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MsgDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MsgDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MsgDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MsgDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MsgDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MsgDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MsgDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MsgDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MsgDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MsgDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MsgDB] SET RECOVERY FULL 
GO
ALTER DATABASE [MsgDB] SET  MULTI_USER 
GO
ALTER DATABASE [MsgDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MsgDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MsgDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MsgDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [MsgDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [MsgDB]
GO
/****** Object:  Table [dbo].[tbl_Admin]    Script Date: 16/01/2021 01:31:18 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Admin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](80) NULL,
	[Password] [nvarchar](80) NULL,
	[Name] [nvarchar](50) NULL,
	[Family] [nvarchar](50) NULL,
	[Email] [varchar](80) NULL,
	[LastLogin] [nvarchar](50) NULL,
	[Image] [nvarchar](300) NULL,
 CONSTRAINT [PK_tbl_Admin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Block]    Script Date: 16/01/2021 01:31:18 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Block](
	[UserId] [int] NOT NULL,
	[Username] [varchar](50) NULL,
	[UserBlock] [varchar](50) NULL,
	[IsBlock] [bit] NULL,
 CONSTRAINT [PK_tbl_Block] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Freinds]    Script Date: 16/01/2021 01:31:18 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Freinds](
	[FreindId] [int] NOT NULL,
	[CurrentUser] [nvarchar](70) NOT NULL,
	[Username] [nvarchar](70) NULL,
	[Name] [nvarchar](50) NULL,
	[Family] [nvarchar](50) NULL,
	[Email] [varchar](100) NULL,
	[Mobile] [varchar](50) NULL,
	[Picture] [nvarchar](200) NULL,
	[Online] [bit] NULL,
 CONSTRAINT [PK_tbl_Freinds] PRIMARY KEY CLUSTERED 
(
	[FreindId] ASC,
	[CurrentUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_FriendRequest]    Script Date: 16/01/2021 01:31:18 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_FriendRequest](
	[FriendId] [int] NOT NULL,
	[CurrentUser] [varchar](70) NULL,
	[Fusername] [varchar](70) NULL,
	[Fname] [nvarchar](50) NULL,
	[Ffamily] [nvarchar](50) NULL,
	[Fmobile] [varchar](50) NULL,
	[Femail] [varchar](100) NULL,
	[Fpicture] [nvarchar](max) NULL,
	[DoSendRequest] [bit] NULL,
	[Flag] [bit] NULL CONSTRAINT [DF_tbl_FriendRequest_Flag]  DEFAULT ((0)),
 CONSTRAINT [PK_tbl_FriendRequest] PRIMARY KEY CLUSTERED 
(
	[FriendId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_message]    Script Date: 16/01/2021 01:31:18 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_message](
	[msg_id] [bigint] IDENTITY(1,1) NOT NULL,
	[msg_sender] [nvarchar](50) NULL,
	[msg_recipient] [nvarchar](50) NULL,
	[msg_subject] [ntext] NULL,
	[msg_content] [ntext] NULL,
	[date] [nvarchar](50) NULL,
	[msg_read] [tinyint] NULL,
	[msg_deleted] [tinyint] NULL,
	[msg_status] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_message] PRIMARY KEY CLUSTERED 
(
	[msg_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Post]    Script Date: 16/01/2021 01:31:18 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Post](
	[PostId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NULL,
	[Content] [text] NULL,
	[Date] [nvarchar](70) NULL,
	[Publisher] [varchar](50) NULL,
	[State] [bit] NULL,
	[Picture] [nvarchar](100) NULL,
	[Like] [bigint] NULL,
	[DisLike] [bigint] NULL,
 CONSTRAINT [PK_tbl_Post] PRIMARY KEY CLUSTERED 
(
	[PostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Reply]    Script Date: 16/01/2021 01:31:18 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Reply](
	[ReplyId] [int] IDENTITY(1,1) NOT NULL,
	[Subject] [nvarchar](100) NULL,
	[Description] [nvarchar](max) NULL,
	[Reciver] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_Reply] PRIMARY KEY CLUSTERED 
(
	[ReplyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Request]    Script Date: 16/01/2021 01:31:18 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Request](
	[Reqid] [int] IDENTITY(1,1) NOT NULL,
	[Sender] [nvarchar](50) NULL,
	[Subject] [nvarchar](100) NULL,
	[Description] [nvarchar](max) NULL,
	[Date] [nvarchar](50) NULL,
	[Flag] [bit] NULL,
 CONSTRAINT [PK_tbl_Request] PRIMARY KEY CLUSTERED 
(
	[Reqid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_trash]    Script Date: 16/01/2021 01:31:18 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_trash](
	[msg_id] [int] NOT NULL,
	[msg_sender] [nvarchar](50) NULL,
	[msg_recipient] [nvarchar](50) NULL,
	[msg_subject] [ntext] NULL,
	[msg_content] [ntext] NULL,
 CONSTRAINT [PK_tbl_msgdeleted] PRIMARY KEY CLUSTERED 
(
	[msg_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_users]    Script Date: 16/01/2021 01:31:18 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_users](
	[User_Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Family] [nvarchar](50) NULL,
	[Mobile] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[LastLogin] [nvarchar](50) NULL,
	[Picture] [varbinary](max) NULL,
	[ActiveCode] [varchar](50) NULL,
	[ActiveMail] [bit] NULL CONSTRAINT [DF_tbl_users_ActiveMail]  DEFAULT ((0)),
	[TwoStepValidation] [bit] NULL,
	[Logined] [bit] NULL,
	[PicLocal] [nvarchar](200) NULL,
	[Flag] [bit] NULL,
	[CountFailedLogin] [int] NULL,
 CONSTRAINT [PK_tbl_users] PRIMARY KEY CLUSTERED 
(
	[User_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [MsgDB] SET  READ_WRITE 
GO
