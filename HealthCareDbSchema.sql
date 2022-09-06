USE [master]
GO
/****** Object:  Database [HealthCareDb]    Script Date: 06-09-2022 19:18:57 ******/
CREATE DATABASE [HealthCareDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HealthCareDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\HealthCareDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HealthCareDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\HealthCareDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [HealthCareDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HealthCareDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HealthCareDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HealthCareDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HealthCareDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HealthCareDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HealthCareDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [HealthCareDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HealthCareDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HealthCareDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HealthCareDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HealthCareDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HealthCareDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HealthCareDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HealthCareDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HealthCareDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HealthCareDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HealthCareDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HealthCareDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HealthCareDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HealthCareDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HealthCareDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HealthCareDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HealthCareDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HealthCareDb] SET RECOVERY FULL 
GO
ALTER DATABASE [HealthCareDb] SET  MULTI_USER 
GO
ALTER DATABASE [HealthCareDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HealthCareDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HealthCareDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HealthCareDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HealthCareDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HealthCareDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'HealthCareDb', N'ON'
GO
ALTER DATABASE [HealthCareDb] SET QUERY_STORE = OFF
GO
USE [HealthCareDb]
GO
/****** Object:  Table [dbo].[tbl_Claims]    Script Date: 06-09-2022 19:18:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Claims](
	[MemberId] [nvarchar](30) NOT NULL,
	[ClaimId] [nvarchar](30) NOT NULL,
	[ClaimType] [nvarchar](500) NOT NULL,
	[ClaimAmount] [int] NOT NULL,
	[ClaimDate] [date] NULL,
	[Remarks] [nvarchar](500) NOT NULL,
	[CreatedBy] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Claims] PRIMARY KEY CLUSTERED 
(
	[ClaimId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_ClaimsMaster]    Script Date: 06-09-2022 19:18:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ClaimsMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_ClaimsMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Members]    Script Date: 06-09-2022 19:18:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Members](
	[MemberId] [nvarchar](30) NOT NULL,
	[FirstName] [nvarchar](500) NOT NULL,
	[LastName] [nvarchar](500) NOT NULL,
	[UserName] [nvarchar](500) NOT NULL,
	[DOB] [date] NULL,
	[Address] [nvarchar](500) NOT NULL,
	[City] [nvarchar](500) NOT NULL,
	[State] [nvarchar](500) NOT NULL,
	[Email] [nvarchar](500) NOT NULL,
	[PhysicianName] [nvarchar](30) NOT NULL,
	[CreatedDate] [date] NULL,
	[ModifiedDate] [date] NULL,
	[ModifiedBy] [nvarchar](30) NOT NULL,
	[Password] [nvarchar](500) NULL,
 CONSTRAINT [PK_Members] PRIMARY KEY CLUSTERED 
(
	[MemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Physicians]    Script Date: 06-09-2022 19:18:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Physicians](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PhysicianName] [nvarchar](30) NOT NULL,
	[PhysicianState] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Physicians] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Users]    Script Date: 06-09-2022 19:18:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Users](
	[UserId] [nvarchar](30) NOT NULL,
	[UserName] [nvarchar](500) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[UserType] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tbl_Claims] ([MemberId], [ClaimId], [ClaimType], [ClaimAmount], [ClaimDate], [Remarks], [CreatedBy]) VALUES (N'10IEQ2H2', N'61UOC74K', N'Medical', 100000, CAST(N'2022-10-06' AS Date), N'Amount claimed for Surgery', N'M5DH67JF')
INSERT [dbo].[tbl_Claims] ([MemberId], [ClaimId], [ClaimType], [ClaimAmount], [ClaimDate], [Remarks], [CreatedBy]) VALUES (N'STT93HOC', N'833KMMFD', N'Dental', 100000, CAST(N'2022-09-06' AS Date), N'Amount claimed for teeth implantation', N'')
GO
INSERT [dbo].[tbl_Members] ([MemberId], [FirstName], [LastName], [UserName], [DOB], [Address], [City], [State], [Email], [PhysicianName], [CreatedDate], [ModifiedDate], [ModifiedBy], [Password]) VALUES (N'10IEQ2H2', N'Raj', N'Rao', N'RajRao', CAST(N'2022-09-06' AS Date), N'Plot no:45,ydsaydadu,zdsdasyud', N'Hyderabad', N'Telangana', N'rajrao@gmail.com', N'John', CAST(N'2022-09-06' AS Date), CAST(N'2022-09-06' AS Date), N'', N'1234')
INSERT [dbo].[tbl_Members] ([MemberId], [FirstName], [LastName], [UserName], [DOB], [Address], [City], [State], [Email], [PhysicianName], [CreatedDate], [ModifiedDate], [ModifiedBy], [Password]) VALUES (N'STT93HOC', N'Sita', N'ram', N'test', CAST(N'2022-09-06' AS Date), N'Plot no:45,ydsaydadu,zdsdasyud', N'Hyderabad', N'Telangana', N'sitaram@gmail.com', N'John', CAST(N'2022-09-06' AS Date), CAST(N'2022-09-06' AS Date), N'', N'test')
GO
INSERT [dbo].[tbl_Users] ([UserId], [UserName], [Password], [UserType]) VALUES (N'ABC124EF', N'RajRao', N'1234', N'member')
INSERT [dbo].[tbl_Users] ([UserId], [UserName], [Password], [UserType]) VALUES (N'M5DH67JF', N'manasa', N'manasa', N'admin')
INSERT [dbo].[tbl_Users] ([UserId], [UserName], [Password], [UserType]) VALUES (N'STT93HOC', N'test', N'test', N'member')
GO
/****** Object:  StoredProcedure [dbo].[GetMemberDetails]    Script Date: 06-09-2022 19:18:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetMemberDetails] @MemberId varchar,@FirstName varchar,@LastName varchar,@ClaimId varchar,@PhysicianName varchar
AS
select members.MemberId,members.FirstName, members.LastName,members.PhysicianName,Claims.ClaimId,Claims.ClaimAmount,Claims.ClaimDate 
from tbl_Members as members inner join tbl_Claims as Claims on members.MemberId = Claims.MemberId
where (members.MemberId = @MemberId or @MemberId = '') and (members.FirstName like '%' + @FirstName + '%' or @FirstName = '') and (members.LastName like '%' + @LastName + '%' or @LastName = '') and (members.PhysicianName like '%' + @PhysicianName + '%' or @PhysicianName = '') and (Claims.ClaimId = @ClaimId or @ClaimId = '')
GO
USE [master]
GO
ALTER DATABASE [HealthCareDb] SET  READ_WRITE 
GO
