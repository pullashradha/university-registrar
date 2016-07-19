USE [master]
GO
/****** Object:  Database [university_registrar_test]    Script Date: 7/19/2016 9:30:13 AM ******/
CREATE DATABASE [university_registrar_test]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'university_registrar', FILENAME = N'C:\Users\epicodus\university_registrar_test.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'university_registrar_log', FILENAME = N'C:\Users\epicodus\university_registrar_test_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [university_registrar_test] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [university_registrar_test].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [university_registrar_test] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [university_registrar_test] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [university_registrar_test] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [university_registrar_test] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [university_registrar_test] SET ARITHABORT OFF 
GO
ALTER DATABASE [university_registrar_test] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [university_registrar_test] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [university_registrar_test] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [university_registrar_test] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [university_registrar_test] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [university_registrar_test] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [university_registrar_test] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [university_registrar_test] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [university_registrar_test] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [university_registrar_test] SET  DISABLE_BROKER 
GO
ALTER DATABASE [university_registrar_test] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [university_registrar_test] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [university_registrar_test] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [university_registrar_test] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [university_registrar_test] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [university_registrar_test] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [university_registrar_test] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [university_registrar_test] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [university_registrar_test] SET  MULTI_USER 
GO
ALTER DATABASE [university_registrar_test] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [university_registrar_test] SET DB_CHAINING OFF 
GO
ALTER DATABASE [university_registrar_test] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [university_registrar_test] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [university_registrar_test] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [university_registrar_test] SET QUERY_STORE = OFF
GO
USE [university_registrar_test]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [university_registrar_test]
GO
/****** Object:  Table [dbo].[courses]    Script Date: 7/19/2016 9:30:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[courses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[course_code] [varchar](6) NULL,
	[course_number] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[students]    Script Date: 7/19/2016 9:30:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[students](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[enrollment_date] [date] NULL,
	[student_number] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [university_registrar_test] SET  READ_WRITE 
GO
