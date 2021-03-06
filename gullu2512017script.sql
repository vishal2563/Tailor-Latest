USE [master]
GO
/****** Object:  Database [gullu]    Script Date: 01/25/2017 11:49:25 ******/
CREATE DATABASE [gullu] ON  PRIMARY 
( NAME = N'gullu', FILENAME = N'E:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\gullu.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'gullu_log', FILENAME = N'E:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\gullu_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [gullu] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [gullu].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [gullu] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [gullu] SET ANSI_NULLS OFF
GO
ALTER DATABASE [gullu] SET ANSI_PADDING OFF
GO
ALTER DATABASE [gullu] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [gullu] SET ARITHABORT OFF
GO
ALTER DATABASE [gullu] SET AUTO_CLOSE ON
GO
ALTER DATABASE [gullu] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [gullu] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [gullu] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [gullu] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [gullu] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [gullu] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [gullu] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [gullu] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [gullu] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [gullu] SET  DISABLE_BROKER
GO
ALTER DATABASE [gullu] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [gullu] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [gullu] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [gullu] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [gullu] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [gullu] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [gullu] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [gullu] SET  READ_WRITE
GO
ALTER DATABASE [gullu] SET RECOVERY SIMPLE
GO
ALTER DATABASE [gullu] SET  MULTI_USER
GO
ALTER DATABASE [gullu] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [gullu] SET DB_CHAINING OFF
GO
USE [gullu]
GO
/****** Object:  Table [dbo].[UserMaster]    Script Date: 01/25/2017 11:49:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserMaster](
	[UserId] [int] NULL,
	[UserName] [varchar](200) NULL,
	[Password] [varchar](200) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tailor]    Script Date: 01/25/2017 11:49:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tailor](
	[tid] [int] NULL,
	[tname] [varchar](300) NULL,
	[compname] [varchar](300) NULL,
	[mobile] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[salesman]    Script Date: 01/25/2017 11:49:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[salesman](
	[smid] [int] NULL,
	[smname] [varchar](200) NULL,
	[mobile] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ratemaster]    Script Date: 01/25/2017 11:49:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ratemaster](
	[id] [int] NULL,
	[itemid] [int] NULL,
	[itemname] [varchar](50) NULL,
	[did] [int] NULL,
	[des] [varchar](500) NULL,
	[rate] [float] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[itemmaster]    Script Date: 01/25/2017 11:49:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[itemmaster](
	[itemid] [int] NULL,
	[itemname] [varchar](50) NULL,
	[charges] [float] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[financeyear]    Script Date: 01/25/2017 11:49:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[financeyear](
	[date1] [datetime] NULL,
	[date2] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[description]    Script Date: 01/25/2017 11:49:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[description](
	[did] [int] IDENTITY(1,1) NOT NULL,
	[des] [varchar](500) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[deliverystatus]    Script Date: 01/25/2017 11:49:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[deliverystatus](
	[entryno] [int] NULL,
	[billno] [int] NULL,
	[billdate] [datetime] NULL,
	[cstbillno] [int] NULL,
	[cstname] [varchar](300) NULL,
	[mobile] [varchar](50) NULL,
	[deliveryon] [datetime] NULL,
	[itemid] [int] NULL,
	[item] [varchar](50) NULL,
	[did] [int] NULL,
	[description] [varchar](300) NULL,
	[totalqty] [float] NULL,
	[alreadydelivered] [float] NULL,
	[qty] [float] NULL,
	[stitchingcharges] [float] NULL,
	[tid] [int] NULL,
	[tname] [varchar](300) NULL,
	[totalamt] [float] NULL,
	[alreadyrec] [float] NULL,
	[amountrec] [float] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[delivery]    Script Date: 01/25/2017 11:49:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[delivery](
	[billno] [int] NULL,
	[billdate] [datetime] NULL,
	[cstbillno] [int] NULL,
	[anybalance] [float] NULL,
	[cstname] [varchar](300) NULL,
	[mobile] [varchar](50) NULL,
	[smid] [int] NULL,
	[smname] [varchar](300) NULL,
	[deliverydate] [datetime] NULL,
	[itemid] [int] NULL,
	[item] [varchar](50) NULL,
	[did] [int] NULL,
	[description] [varchar](300) NULL,
	[qty] [float] NULL,
	[totalqty] [float] NULL,
	[tid] [int] NULL,
	[tname] [varchar](300) NULL,
	[stitchingcharges] [float] NULL,
	[totalstitching] [float] NULL,
	[stitchingrec] [float] NULL,
	[stitchingbal] [float] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Bindeliverystatus]    Script Date: 01/25/2017 11:49:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bindeliverystatus](
	[entryno] [int] NULL,
	[billno] [int] NULL,
	[billdate] [datetime] NULL,
	[cstbillno] [int] NULL,
	[cstname] [varchar](300) NULL,
	[mobile] [varchar](50) NULL,
	[deliveryon] [datetime] NULL,
	[itemid] [int] NULL,
	[item] [varchar](50) NULL,
	[did] [int] NULL,
	[description] [varchar](300) NULL,
	[totalqty] [float] NULL,
	[alreadydelivered] [float] NULL,
	[qty] [float] NULL,
	[stitchingcharges] [float] NULL,
	[tid] [int] NULL,
	[tname] [varchar](300) NULL,
	[totalamt] [float] NULL,
	[alreadyrec] [float] NULL,
	[amountrec] [float] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
