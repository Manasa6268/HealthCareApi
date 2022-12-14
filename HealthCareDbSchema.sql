
USE [HealthCareDb]
GO
/****** Object:  Table [dbo].[tbl_Claims]    Script Date: 06-09-2022 19:18:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Claims](
	[MemberId] [nvarchar](30) NOT NULL,
	[Code] [nvarchar](30) NOT NULL,
	[Id] [int] IDENTITY(1000,1) NOT NULL,
	[ClaimType] [nvarchar](30) NOT NULL,
	[ClaimAmount] [int] NOT NULL,
	[ClaimDate] [date] NULL,
	[Remarks] [nvarchar](1000) NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Claims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
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
	[Code] [nvarchar](30) NOT NULL,
	[Id] [int] IDENTITY(1000,1) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[UserName] [nvarchar](20) NOT NULL,
	[DOB] [date] NULL,
	[Address] [nvarchar](100) NOT NULL,
	[City] [nvarchar](40) NOT NULL,
	[State] [nvarchar](40) NOT NULL,
	[Email] [nvarchar](30) NOT NULL,
	[PhysicianName] [nvarchar](20) NOT NULL,
	[CreatedDate] [date] NULL,
	[ModifiedDate] [date] NULL,
	[ModifiedBy] [nvarchar](30) NOT NULL,
	[UserType] [nvarchar](10) NOT NULL,
	[Password] [nvarchar](15) NULL,
 CONSTRAINT [PK_Members] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
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
	[PhysicianState] [nvarchar](5) NOT NULL,
 CONSTRAINT [PK_Physicians] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Users]    Script Date: 06-09-2022 19:18:58 ******/



/****** Object:  StoredProcedure [dbo].[GetMemberDetails]    Script Date: 06-09-2022 19:18:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


 USE [HealthCareDb]
GO
CREATE TABLE  state_list (
  id int  NOT NULL ,
  state varchar(50) NOT NULL,
CONSTRAINT [PK_States] PRIMARY KEY CLUSTERED 
(
	id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO 

USE [HealthCareDb]
GO
INSERT INTO state_list (id, state) VALUES
(1, 'ANDAMAN AND NICOBAR ISLANDS'),
(2, 'ANDHRA PRADESH'),
(3, 'ARUNACHAL PRADESH'),
(4, 'ASSAM'),
(5, 'BIHAR'),
(6, 'CHATTISGARH'),
(7, 'CHANDIGARH'),
(8, 'DAMAN AND DIU'),
(9, 'DELHI'),
(10, 'DADRA AND NAGAR HAVELI'),
(11, 'GOA'),
(12, 'GUJARAT'),
(13, 'HIMACHAL PRADESH'),
(14, 'HARYANA'),
(15, 'JAMMU AND KASHMIR'),
(16, 'JHARKHAND'),
(17, 'KERALA'),
(18, 'KARNATAKA'),
(19, 'LAKSHADWEEP'),
(20, 'MEGHALAYA'),
(21, 'MAHARASHTRA'),
(22, 'MANIPUR'),
(23, 'MADHYA PRADESH'),
(24, 'MIZORAM'),
(25, 'NAGALAND'),
(26, 'ORISSA'),
(27, 'PUNJAB'),
(28, 'PONDICHERRY'),
(29, 'RAJASTHAN'),
(30, 'SIKKIM'),
(31, 'TAMIL NADU'),
(32, 'TRIPURA'),
(33, 'UTTARAKHAND'),
(34, 'UTTAR PRADESH'),
(35, 'WEST BENGAL'),
(36, 'TELANGANA');

 USE [HealthCareDb]
GO

INSERT INTO [dbo].[tbl_ClaimsMaster]
           ([ClaimType])
     VALUES
('Vision'),
('Dental'),
('Medical')
GO

 USE [HealthCareDb]
GO
INSERT INTO [tbl_Physicians] (PhysicianName,PhysicianState) VALUES
('John','UT'),
('Hari','WA'),
('Mittal','TX'),
('Patrick',	'OH'),
('Mark','CA'),
('Jessica','NY'),
('Mary','IL'),
('Stacy','FL')
GO
USE [HealthCareDb]
GO
CREATE TABLE [dbo].[tbl_UsersMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserType] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_UsersMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT INTO [dbo].[tbl_UsersMaster]
           ([UserType])
     VALUES
('Admin'),
('Member')
GO
