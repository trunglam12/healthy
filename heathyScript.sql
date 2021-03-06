USE [master]
GO
/****** Object:  Database [Healthy]    Script Date: 18/01/2018 6:00:20 PM ******/
CREATE DATABASE [Healthy]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Healthy', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.LAMNT2016\MSSQL\DATA\Healthy.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Healthy_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.LAMNT2016\MSSQL\DATA\Healthy_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Healthy].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Healthy] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Healthy] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Healthy] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Healthy] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Healthy] SET ARITHABORT OFF 
GO
ALTER DATABASE [Healthy] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Healthy] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Healthy] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Healthy] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Healthy] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Healthy] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Healthy] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Healthy] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Healthy] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Healthy] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Healthy] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Healthy] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Healthy] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Healthy] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Healthy] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Healthy] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Healthy] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Healthy] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Healthy] SET  MULTI_USER 
GO
ALTER DATABASE [Healthy] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Healthy] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Healthy] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Healthy] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Healthy] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Healthy]
GO
/****** Object:  Table [dbo].[HealthyInformation]    Script Date: 18/01/2018 6:00:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HealthyInformation](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HeartBeat] [int] NOT NULL,
	[Oxy] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_HealthyInformation] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 18/01/2018 6:00:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](150) NULL,
	[Email] [nvarchar](150) NULL,
	[Mobile] [nvarchar](150) NULL,
	[Address] [nvarchar](max) NULL,
	[FullName] [nvarchar](max) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRelationship]    Script Date: 18/01/2018 6:00:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRelationship](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](150) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](150) NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_UserRelationship] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[HealthyInformation] ON 

INSERT [dbo].[HealthyInformation] ([ID], [HeartBeat], [Oxy], [UserID], [CreateDate]) VALUES (1, 60, 60, 1, CAST(N'2017-12-29 11:32:38.483' AS DateTime))
INSERT [dbo].[HealthyInformation] ([ID], [HeartBeat], [Oxy], [UserID], [CreateDate]) VALUES (2, 70, 7, 1, CAST(N'2017-12-29 11:32:38.483' AS DateTime))
INSERT [dbo].[HealthyInformation] ([ID], [HeartBeat], [Oxy], [UserID], [CreateDate]) VALUES (3, 1, 90, 1, CAST(N'2017-12-29 12:18:09.020' AS DateTime))
INSERT [dbo].[HealthyInformation] ([ID], [HeartBeat], [Oxy], [UserID], [CreateDate]) VALUES (4, 1, 100, 1, CAST(N'2017-12-29 12:18:34.380' AS DateTime))
INSERT [dbo].[HealthyInformation] ([ID], [HeartBeat], [Oxy], [UserID], [CreateDate]) VALUES (7, 98, 98, 1, CAST(N'2018-01-16 00:00:00.000' AS DateTime))
INSERT [dbo].[HealthyInformation] ([ID], [HeartBeat], [Oxy], [UserID], [CreateDate]) VALUES (8, 96, 95, 2, CAST(N'2018-01-18 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[HealthyInformation] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [UserName], [Password], [Email], [Mobile], [Address], [FullName]) VALUES (1, N'admin', N'AQAAAAEAACcQAAAAEN4RCXrqTT0vugMpAP1kAwVhGfWrs424CH8KBk81lBLOdeWpcX1k20IkstoU1+Y7FA==', N'admin1@gmail.com', N'0965198668', N'Q1,HCM', N'Bui Trung Tá')
INSERT [dbo].[User] ([ID], [UserName], [Password], [Email], [Mobile], [Address], [FullName]) VALUES (2, N'user', N'AQAAAAEAACcQAAAAEN4RCXrqTT0vugMpAP1kAwVhGfWrs424CH8KBk81lBLOdeWpcX1k20IkstoU1+Y7FA==', N'user@gmail.com', N'0968987545', N'HCM', NULL)
INSERT [dbo].[User] ([ID], [UserName], [Password], [Email], [Mobile], [Address], [FullName]) VALUES (3, N'user12', N'AQAAAAEAACcQAAAAEKzfSODNTzHrmyNk03RyuF4wslmXSXf909iirkkF4043/sVmK7d2ALfHFgS3GyFnow==', N'user2@gmail.com', NULL, NULL, NULL)
INSERT [dbo].[User] ([ID], [UserName], [Password], [Email], [Mobile], [Address], [FullName]) VALUES (4, N'user121', N'AQAAAAEAACcQAAAAEI5PSBPGchMjHzQK0Tbz0C9uIOy5d5/giHIOUYWQ0heFsGRgChicfmCTskGoiwNhuA==', N'user2@gmail.com', NULL, NULL, NULL)
INSERT [dbo].[User] ([ID], [UserName], [Password], [Email], [Mobile], [Address], [FullName]) VALUES (5, N'usertest', N'AQAAAAEAACcQAAAAECJzxdk2LfMNAncYGn2ttojEF0mrRzFwvYj8sSLeOeNMuxyvBp7s/SgP1O9+VhtJPQ==', N'user2@gmail.com', NULL, NULL, NULL)
INSERT [dbo].[User] ([ID], [UserName], [Password], [Email], [Mobile], [Address], [FullName]) VALUES (6, N'usertest1', N'AQAAAAEAACcQAAAAEM9TdTfy1/ELfxBrc4KEbOgW8XW4H0/R81Cd1eu3cKUF7HTTLnFVT1MClz+TJ9Isog==', N'admin@gmail.com', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[UserRelationship] ON 

INSERT [dbo].[UserRelationship] ([ID], [FullName], [Address], [Phone], [UserID]) VALUES (1, N'Nguyen Van F', N'Thu Duc, TPHCM, VietNam', N'0966199630', 1)
INSERT [dbo].[UserRelationship] ([ID], [FullName], [Address], [Phone], [UserID]) VALUES (2, N'Nguyen Van B', N'Da Dang', N'0968196535', 1)
SET IDENTITY_INSERT [dbo].[UserRelationship] OFF
ALTER TABLE [dbo].[HealthyInformation]  WITH CHECK ADD  CONSTRAINT [FK_User_Information] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[HealthyInformation] CHECK CONSTRAINT [FK_User_Information]
GO
ALTER TABLE [dbo].[UserRelationship]  WITH CHECK ADD  CONSTRAINT [FK_UserRelationship_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[UserRelationship] CHECK CONSTRAINT [FK_UserRelationship_User]
GO
USE [master]
GO
ALTER DATABASE [Healthy] SET  READ_WRITE 
GO
