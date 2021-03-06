USE [master]
GO
/****** Object:  Database [DeviceManagerDB]    Script Date: 09/03/2018 10:47:45 ******/
CREATE DATABASE [DeviceManagerDB] ON  PRIMARY 
( NAME = N'DeviceManagerDB', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\DeviceManagerDB.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DeviceManagerDB_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\DeviceManagerDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DeviceManagerDB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DeviceManagerDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DeviceManagerDB] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [DeviceManagerDB] SET ANSI_NULLS OFF
GO
ALTER DATABASE [DeviceManagerDB] SET ANSI_PADDING OFF
GO
ALTER DATABASE [DeviceManagerDB] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [DeviceManagerDB] SET ARITHABORT OFF
GO
ALTER DATABASE [DeviceManagerDB] SET AUTO_CLOSE ON
GO
ALTER DATABASE [DeviceManagerDB] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [DeviceManagerDB] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [DeviceManagerDB] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [DeviceManagerDB] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [DeviceManagerDB] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [DeviceManagerDB] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [DeviceManagerDB] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [DeviceManagerDB] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [DeviceManagerDB] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [DeviceManagerDB] SET  DISABLE_BROKER
GO
ALTER DATABASE [DeviceManagerDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [DeviceManagerDB] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [DeviceManagerDB] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [DeviceManagerDB] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [DeviceManagerDB] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [DeviceManagerDB] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [DeviceManagerDB] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [DeviceManagerDB] SET  READ_WRITE
GO
ALTER DATABASE [DeviceManagerDB] SET RECOVERY SIMPLE
GO
ALTER DATABASE [DeviceManagerDB] SET  MULTI_USER
GO
ALTER DATABASE [DeviceManagerDB] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [DeviceManagerDB] SET DB_CHAINING OFF
GO
USE [DeviceManagerDB]
GO
/****** Object:  Table [dbo].[Provider]    Script Date: 09/03/2018 10:47:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provider](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Provider] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 09/03/2018 10:47:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Unit]    Script Date: 09/03/2018 10:47:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unit](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Unit] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 09/03/2018 10:47:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 09/03/2018 10:47:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 09/03/2018 10:47:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 09/03/2018 10:47:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[Username] [varchar](100) NOT NULL,
	[Password] [nvarchar](200) NOT NULL,
	[FullName] [nvarchar](200) NOT NULL,
	[Address] [nvarchar](256) NOT NULL,
	[BirthDay] [date] NOT NULL,
	[IDDepartment] [int] NOT NULL,
	[IDRole] [int] NOT NULL,
	[Email] [varchar](100) NULL,
	[PhoneNumber] [varchar](11) NOT NULL,
 CONSTRAINT [Unique_PhoneNumber] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [Unique_Email] ON [dbo].[User] 
(
	[Email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Receipt]    Script Date: 09/03/2018 10:47:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Receipt](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UsernameReceipt] [varchar](100) NOT NULL,
	[IDProvider] [int] NOT NULL,
	[CreatedBy] [varchar](100) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NULL,
	[Note] [ntext] NULL,
	[UpdatedBy] [varchar](100) NULL,
 CONSTRAINT [PK_Receipt] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Delivery]    Script Date: 09/03/2018 10:47:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Delivery](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UsernameFromDelivery] [varchar](100) NOT NULL,
	[UsernameToDelivery] [varchar](100) NOT NULL,
	[CreatedBy] [varchar](100) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NULL,
	[Note] [ntext] NULL,
	[UpdatedBy] [varchar](100) NULL,
 CONSTRAINT [PK_Delivery] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Device]    Script Date: 09/03/2018 10:47:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Device](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Quantity] [int] NOT NULL,
	[IDCategory] [int] NOT NULL,
	[IDUnit] [int] NOT NULL,
	[IDStatus] [int] NOT NULL,
	[IDReceipt] [int] NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[Info] [ntext] NULL,
	[CreatedBy] [varchar](100) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NULL,
	[Note] [ntext] NULL,
	[UpdatedBy] [varchar](100) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DeliveryDetail]    Script Date: 09/03/2018 10:47:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DeliveryDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDDevice] [int] NOT NULL,
	[IDDelivery] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[DateExpires] [date] NOT NULL,
	[CreatedBy] [varchar](100) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NULL,
	[Note] [ntext] NULL,
	[UpdatedBy] [varchar](100) NULL,
 CONSTRAINT [PK_DeliveryDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_User_Department]    Script Date: 09/03/2018 10:47:46 ******/
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Department] FOREIGN KEY([IDDepartment])
REFERENCES [dbo].[Department] ([ID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Department]
GO
/****** Object:  ForeignKey [FK_User_Role]    Script Date: 09/03/2018 10:47:46 ******/
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([IDRole])
REFERENCES [dbo].[Role] ([ID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
/****** Object:  ForeignKey [FK_Receipt_Provider]    Script Date: 09/03/2018 10:47:46 ******/
ALTER TABLE [dbo].[Receipt]  WITH CHECK ADD  CONSTRAINT [FK_Receipt_Provider] FOREIGN KEY([IDProvider])
REFERENCES [dbo].[Provider] ([ID])
GO
ALTER TABLE [dbo].[Receipt] CHECK CONSTRAINT [FK_Receipt_Provider]
GO
/****** Object:  ForeignKey [FK_Receipt_User]    Script Date: 09/03/2018 10:47:46 ******/
ALTER TABLE [dbo].[Receipt]  WITH CHECK ADD  CONSTRAINT [FK_Receipt_User] FOREIGN KEY([UsernameReceipt])
REFERENCES [dbo].[User] ([Username])
GO
ALTER TABLE [dbo].[Receipt] CHECK CONSTRAINT [FK_Receipt_User]
GO
/****** Object:  ForeignKey [FK_Delivery_User]    Script Date: 09/03/2018 10:47:46 ******/
ALTER TABLE [dbo].[Delivery]  WITH CHECK ADD  CONSTRAINT [FK_Delivery_User] FOREIGN KEY([UsernameFromDelivery])
REFERENCES [dbo].[User] ([Username])
GO
ALTER TABLE [dbo].[Delivery] CHECK CONSTRAINT [FK_Delivery_User]
GO
/****** Object:  ForeignKey [FK_Delivery_User1]    Script Date: 09/03/2018 10:47:46 ******/
ALTER TABLE [dbo].[Delivery]  WITH CHECK ADD  CONSTRAINT [FK_Delivery_User1] FOREIGN KEY([UsernameToDelivery])
REFERENCES [dbo].[User] ([Username])
GO
ALTER TABLE [dbo].[Delivery] CHECK CONSTRAINT [FK_Delivery_User1]
GO
/****** Object:  ForeignKey [FK_Device_Category]    Script Date: 09/03/2018 10:47:46 ******/
ALTER TABLE [dbo].[Device]  WITH CHECK ADD  CONSTRAINT [FK_Device_Category] FOREIGN KEY([IDCategory])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[Device] CHECK CONSTRAINT [FK_Device_Category]
GO
/****** Object:  ForeignKey [FK_Device_Receipt]    Script Date: 09/03/2018 10:47:46 ******/
ALTER TABLE [dbo].[Device]  WITH CHECK ADD  CONSTRAINT [FK_Device_Receipt] FOREIGN KEY([IDReceipt])
REFERENCES [dbo].[Receipt] ([ID])
GO
ALTER TABLE [dbo].[Device] CHECK CONSTRAINT [FK_Device_Receipt]
GO
/****** Object:  ForeignKey [FK_Device_Status]    Script Date: 09/03/2018 10:47:46 ******/
ALTER TABLE [dbo].[Device]  WITH CHECK ADD  CONSTRAINT [FK_Device_Status] FOREIGN KEY([IDStatus])
REFERENCES [dbo].[Status] ([ID])
GO
ALTER TABLE [dbo].[Device] CHECK CONSTRAINT [FK_Device_Status]
GO
/****** Object:  ForeignKey [FK_Device_Unit]    Script Date: 09/03/2018 10:47:46 ******/
ALTER TABLE [dbo].[Device]  WITH CHECK ADD  CONSTRAINT [FK_Device_Unit] FOREIGN KEY([IDUnit])
REFERENCES [dbo].[Unit] ([ID])
GO
ALTER TABLE [dbo].[Device] CHECK CONSTRAINT [FK_Device_Unit]
GO
/****** Object:  ForeignKey [FK_DeliveryDetail_Delivery]    Script Date: 09/03/2018 10:47:46 ******/
ALTER TABLE [dbo].[DeliveryDetail]  WITH CHECK ADD  CONSTRAINT [FK_DeliveryDetail_Delivery] FOREIGN KEY([IDDelivery])
REFERENCES [dbo].[Delivery] ([ID])
GO
ALTER TABLE [dbo].[DeliveryDetail] CHECK CONSTRAINT [FK_DeliveryDetail_Delivery]
GO
/****** Object:  ForeignKey [FK_DeliveryDetail_Device]    Script Date: 09/03/2018 10:47:46 ******/
ALTER TABLE [dbo].[DeliveryDetail]  WITH CHECK ADD  CONSTRAINT [FK_DeliveryDetail_Device] FOREIGN KEY([IDDevice])
REFERENCES [dbo].[Device] ([ID])
GO
ALTER TABLE [dbo].[DeliveryDetail] CHECK CONSTRAINT [FK_DeliveryDetail_Device]
GO
