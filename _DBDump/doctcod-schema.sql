-- DATABASE

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'doctcod')
BEGIN
CREATE DATABASE [doctcod]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'doctcod', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\doctcod.mdf' , SIZE = 75776KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'doctcod_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\doctcod_1.ldf' , SIZE = 833024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 COLLATE Latin1_General_CI_AS
END;
ALTER DATABASE [doctcod] SET COMPATIBILITY_LEVEL = 100;
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [doctcod].[dbo].[sp_fulltext_database] @action = 'enable'
end;
ALTER DATABASE [doctcod] SET ANSI_NULL_DEFAULT OFF;
ALTER DATABASE [doctcod] SET ANSI_NULLS OFF;
ALTER DATABASE [doctcod] SET ANSI_PADDING OFF;
ALTER DATABASE [doctcod] SET ANSI_WARNINGS OFF;
ALTER DATABASE [doctcod] SET ARITHABORT OFF;
ALTER DATABASE [doctcod] SET AUTO_CLOSE OFF;
ALTER DATABASE [doctcod] SET AUTO_SHRINK OFF;
ALTER DATABASE [doctcod] SET AUTO_UPDATE_STATISTICS ON;
ALTER DATABASE [doctcod] SET CURSOR_CLOSE_ON_COMMIT OFF;
ALTER DATABASE [doctcod] SET CURSOR_DEFAULT  GLOBAL;
ALTER DATABASE [doctcod] SET CONCAT_NULL_YIELDS_NULL OFF;
ALTER DATABASE [doctcod] SET NUMERIC_ROUNDABORT OFF;
ALTER DATABASE [doctcod] SET QUOTED_IDENTIFIER OFF;
ALTER DATABASE [doctcod] SET RECURSIVE_TRIGGERS OFF;
ALTER DATABASE [doctcod] SET  DISABLE_BROKER;
ALTER DATABASE [doctcod] SET AUTO_UPDATE_STATISTICS_ASYNC OFF;
ALTER DATABASE [doctcod] SET DATE_CORRELATION_OPTIMIZATION OFF;
ALTER DATABASE [doctcod] SET TRUSTWORTHY OFF;
ALTER DATABASE [doctcod] SET ALLOW_SNAPSHOT_ISOLATION OFF;
ALTER DATABASE [doctcod] SET PARAMETERIZATION SIMPLE;
ALTER DATABASE [doctcod] SET READ_COMMITTED_SNAPSHOT OFF;
ALTER DATABASE [doctcod] SET HONOR_BROKER_PRIORITY OFF;
ALTER DATABASE [doctcod] SET RECOVERY FULL;
ALTER DATABASE [doctcod] SET  MULTI_USER;
ALTER DATABASE [doctcod] SET PAGE_VERIFY CHECKSUM;
ALTER DATABASE [doctcod] SET DB_CHAINING OFF;
ALTER DATABASE [doctcod] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF );
ALTER DATABASE [doctcod] SET TARGET_RECOVERY_TIME = 0 SECONDS;
ALTER AUTHORIZATION ON DATABASE::[doctcod] TO [sa];
ALTER DATABASE [doctcod] SET  READ_WRITE;
USE doctcod;
-- TABLES

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[addressestypes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[addressestypes](
	[addressestypes_id] [int] IDENTITY(1,1) NOT NULL,
	[addressestypes_name] [varchar](16) COLLATE Latin1_General_CI_AS NOT NULL,
 CONSTRAINT [PK_addressestypes] PRIMARY KEY CLUSTERED 
(
	[addressestypes_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END;
ALTER AUTHORIZATION ON [dbo].[addressestypes] TO  SCHEMA OWNER;
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[appointments]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[appointments](
	[appointments_id] [int] IDENTITY(1,1) NOT NULL,
	[doctors_id] [int] NOT NULL,
	[patients_id] [int] NOT NULL,
	[rooms_id] [int] NOT NULL,
	[appointments_from] [datetime] NOT NULL,
	[appointments_to] [datetime] NOT NULL,
	[appointments_title] [varchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[appointments_notes] [varchar](max) COLLATE Latin1_General_CI_AS NULL,
	[appointments_color] [char](7) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [PK_appointments] PRIMARY KEY CLUSTERED 
(
	[appointments_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END;
ALTER AUTHORIZATION ON [dbo].[appointments] TO  SCHEMA OWNER;
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[computedlines]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[computedlines](
	[computedlines_id] [int] IDENTITY(1,1) NOT NULL,
	[taxes_id] [int] NULL,
	[computedlines_code] [char](3) COLLATE Latin1_General_CI_AS NOT NULL,
	[computedlines_name] [varchar](16) COLLATE Latin1_General_CI_AS NOT NULL,
	[computedlines_rate] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_computedlines] PRIMARY KEY CLUSTERED 
(
	[computedlines_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END;
ALTER AUTHORIZATION ON [dbo].[computedlines] TO  SCHEMA OWNER;
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[contactstypes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[contactstypes](
	[contactstypes_id] [int] IDENTITY(1,1) NOT NULL,
	[contactstypes_name] [varchar](16) COLLATE Latin1_General_CI_AS NOT NULL,
 CONSTRAINT [PK_contactstypes] PRIMARY KEY CLUSTERED 
(
	[contactstypes_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END;
ALTER AUTHORIZATION ON [dbo].[contactstypes] TO  SCHEMA OWNER;
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[descriptiontemplatestreatments]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[descriptiontemplatestreatments](
	[descriptiontemplatestreatments_id] [int] IDENTITY(1,1) NOT NULL,
	[descriptiontemplatestreatments_name] [varchar](32) COLLATE Latin1_General_CI_AS NOT NULL,
	[descriptiontemplatestreatments_template] [varchar](max) COLLATE Latin1_General_CI_AS NOT NULL,
 CONSTRAINT [PK_descriptiontemplatestreatments] PRIMARY KEY CLUSTERED 
(
	[descriptiontemplatestreatments_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END;
ALTER AUTHORIZATION ON [dbo].[descriptiontemplatestreatments] TO  SCHEMA OWNER;
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[doctors]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[doctors](
	[doctors_id] [int] IDENTITY(1,1) NOT NULL,
	[doctors_name] [varchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[doctors_surname] [varchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[doctors_doctext] [varchar](512) COLLATE Latin1_General_CI_AS NOT NULL,
	[doctors_username] [varchar](8) COLLATE Latin1_General_CI_AS NOT NULL,
	[doctors_password] [varchar](6) COLLATE Latin1_General_CI_AS NOT NULL,
	[doctors_token] [varchar](64) COLLATE Latin1_General_CI_AS NULL,
	[doctors_lastlogin] [datetime] NULL,
 CONSTRAINT [PK_doctors] PRIMARY KEY CLUSTERED 
(
	[doctors_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END;
ALTER AUTHORIZATION ON [dbo].[doctors] TO  SCHEMA OWNER;
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[estimates]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[estimates](
	[estimates_id] [int] IDENTITY(1,1) NOT NULL,
	[doctors_id] [int] NULL,
	[patients_id] [int] NULL,
	[invoices_id] [int] NULL,
	[estimates_number] [varchar](32) COLLATE Latin1_General_CI_AS NOT NULL,
	[estimates_date] [date] NOT NULL,
	[estimates_doctor] [varchar](512) COLLATE Latin1_General_CI_AS NOT NULL,
	[estimates_patient] [varchar](512) COLLATE Latin1_General_CI_AS NOT NULL,
	[estimates_payment] [varchar](512) COLLATE Latin1_General_CI_AS NOT NULL,
	[estimates_footer] [varchar](512) COLLATE Latin1_General_CI_AS NULL,
	[estimates_totalnet] [decimal](10, 2) NOT NULL,
	[estimates_totalgross] [decimal](10, 2) NOT NULL,
	[estimates_totaldue] [decimal](10, 2) NOT NULL,
	[estimates_deductiontaxrate] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_estimates] PRIMARY KEY CLUSTERED 
(
	[estimates_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END;
ALTER AUTHORIZATION ON [dbo].[estimates] TO  SCHEMA OWNER;
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[estimatesfooters]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[estimatesfooters](
	[estimatesfooters_id] [int] IDENTITY(1,1) NOT NULL,
	[estimatesfooters_name] [varchar](16) COLLATE Latin1_General_CI_AS NOT NULL,
	[estimatesfooters_doctext] [varchar](512) COLLATE Latin1_General_CI_AS NOT NULL,
	[estimatesfooters_isdefault] [bit] NOT NULL,
 CONSTRAINT [PK_estimatesfooters] PRIMARY KEY CLUSTERED 
(
	[estimatesfooters_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END;
ALTER AUTHORIZATION ON [dbo].[estimatesfooters] TO  SCHEMA OWNER;
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[estimateslines]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[estimateslines](
	[estimateslines_id] [int] IDENTITY(1,1) NOT NULL,
	[estimates_id] [int] NOT NULL,
	[patientstreatments_id] [int] NULL,
	[estimateslines_code] [char](3) COLLATE Latin1_General_CI_AS NOT NULL,
	[estimateslines_description] [varchar](max) COLLATE Latin1_General_CI_AS NOT NULL,
	[estimateslines_quantity] [int] NOT NULL,
	[estimateslines_unitprice] [decimal](10, 2) NOT NULL,
	[estimateslines_taxrate] [decimal](10, 2) NOT NULL,
	[estimateslines_istaxesdeductionsable] [bit] NOT NULL,
 CONSTRAINT [PK_estimateslines] PRIMARY KEY CLUSTERED 
(
	[estimateslines_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END;
ALTER AUTHORIZATION ON [dbo].[estimateslines] TO  SCHEMA OWNER;
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[invoices]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[invoices](
	[invoices_id] [int] IDENTITY(1,1) NOT NULL,
	[doctors_id] [int] NULL,
	[patients_id] [int] NULL,
	[invoices_number] [varchar](32) COLLATE Latin1_General_CI_AS NOT NULL,
	[invoices_date] [date] NOT NULL,
	[invoices_doctor] [varchar](512) COLLATE Latin1_General_CI_AS NOT NULL,
	[invoices_patient] [varchar](512) COLLATE Latin1_General_CI_AS NOT NULL,
	[invoices_payment] [varchar](512) COLLATE Latin1_General_CI_AS NOT NULL,
	[invoices_footer] [varchar](512) COLLATE Latin1_General_CI_AS NULL,
	[invoices_totalnet] [decimal](10, 2) NOT NULL,
	[invoices_totalgross] [decimal](10, 2) NOT NULL,
	[invoices_totaldue] [decimal](10, 2) NOT NULL,
	[invoices_deductiontaxrate] [decimal](10, 2) NOT NULL,
	[invoices_ispaid] [bit] NOT NULL,
 CONSTRAINT [PK_invoices] PRIMARY KEY CLUSTERED 
(
	[invoices_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END;
ALTER AUTHORIZATION ON [dbo].[invoices] TO  SCHEMA OWNER;
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[invoicesfooters]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[invoicesfooters](
	[invoicesfooters_id] [int] IDENTITY(1,1) NOT NULL,
	[invoicesfooters_name] [varchar](16) COLLATE Latin1_General_CI_AS NOT NULL,
	[invoicesfooters_doctext] [varchar](512) COLLATE Latin1_General_CI_AS NOT NULL,
	[invoicesfooters_isdefault] [bit] NOT NULL,
 CONSTRAINT [PK_invoicesfooters] PRIMARY KEY CLUSTERED 
(
	[invoicesfooters_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END;
ALTER AUTHORIZATION ON [dbo].[invoicesfooters] TO  SCHEMA OWNER;
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[invoiceslines]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[invoiceslines](
	[invoiceslines_id] [int] IDENTITY(1,1) NOT NULL,
	[invoices_id] [int] NOT NULL,
	[patientstreatments_id] [int] NULL,
	[invoiceslines_code] [char](3) COLLATE Latin1_General_CI_AS NOT NULL,
	[invoiceslines_description] [varchar](max) COLLATE Latin1_General_CI_AS NOT NULL,
	[invoiceslines_quantity] [int] NOT NULL,
	[invoiceslines_unitprice] [decimal](10, 2) NOT NULL,
	[invoiceslines_taxrate] [decimal](10, 2) NOT NULL,
	[invoiceslines_istaxesdeductionsable] [bit] NOT NULL,
 CONSTRAINT [PK_invoiceslines] PRIMARY KEY CLUSTERED 
(
	[invoiceslines_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END;
ALTER AUTHORIZATION ON [dbo].[invoiceslines] TO  SCHEMA OWNER;
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[medicalrecordstypes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[medicalrecordstypes](
	[medicalrecordstypes_id] [int] IDENTITY(1,1) NOT NULL,
	[medicalrecordstypes_name] [varchar](32) COLLATE Latin1_General_CI_AS NOT NULL,
 CONSTRAINT [PK_medicalrecordstypes] PRIMARY KEY CLUSTERED 
(
	[medicalrecordstypes_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END;
ALTER AUTHORIZATION ON [dbo].[medicalrecordstypes] TO  SCHEMA OWNER;
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[patients]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[patients](
	[patients_id] [int] IDENTITY(1,1) NOT NULL,
	[treatmentspriceslists_id] [int] NULL,
	[patients_name] [varchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[patients_surname] [varchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[patients_sex] [char](1) COLLATE Latin1_General_CI_AS NOT NULL,
	[patients_birthdate] [date] NOT NULL,
	[patients_birthcity] [varchar](64) COLLATE Latin1_General_CI_AS NOT NULL,
	[patients_doctext] [varchar](512) COLLATE Latin1_General_CI_AS NOT NULL,
	[patients_notes] [varchar](max) COLLATE Latin1_General_CI_AS NULL,
	[patients_isarchived] [bit] NOT NULL,
	[patients_username] [varchar](8) COLLATE Latin1_General_CI_AS NOT NULL,
	[patients_password] [varchar](6) COLLATE Latin1_General_CI_AS NOT NULL,
	[patients_token] [varchar](64) COLLATE Latin1_General_CI_AS NULL,
	[patients_lastlogin] [datetime] NULL,
 CONSTRAINT [PK_patients] PRIMARY KEY CLUSTERED 
(
	[patients_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END;
ALTER AUTHORIZATION ON [dbo].[patients] TO  SCHEMA OWNER;
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[patientsaddresses]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[patientsaddresses](
	[patientsaddresses_id] [int] IDENTITY(1,1) NOT NULL,
	[patients_id] [int] NOT NULL,
	[addressestypes_id] [int] NOT NULL,
	[patientsaddresses_state] [varchar](32) COLLATE Latin1_General_CI_AS NOT NULL,
	[patientsaddresses_city] [varchar](64) COLLATE Latin1_General_CI_AS NOT NULL,
	[patientsaddresses_zipcode] [varchar](6) COLLATE Latin1_General_CI_AS NOT NULL,
	[patientsaddresses_street] [varchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
 CONSTRAINT [PK_patientsaddresses] PRIMARY KEY CLUSTERED 
(
	[patientsaddresses_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END;
ALTER AUTHORIZATION ON [dbo].[patientsaddresses] TO  SCHEMA OWNER;
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[patientsattachments]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[patientsattachments](
	[patientsattachments_id] [int] IDENTITY(1,1) NOT NULL,
	[patients_id] [int] NOT NULL,
	[patientsattachmentstypes_id] [int] NOT NULL,
	[patientsattachments_value] [varchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[patientsattachments_date] [date] NOT NULL,
	[patientsattachments_filename] [varchar](64) COLLATE Latin1_General_CI_AS NULL,
	[patientsattachments_note] [varchar](max) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [PK_patientsattachments] PRIMARY KEY CLUSTERED 
(
	[patientsattachments_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END;
ALTER AUTHORIZATION ON [dbo].[patientsattachments] TO  SCHEMA OWNER;
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[patientsattachmentstypes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[patientsattachmentstypes](
	[patientsattachmentstypes_id] [int] IDENTITY(1,1) NOT NULL,
	[patientsattachmentstypes_name] [varchar](16) COLLATE Latin1_General_CI_AS NOT NULL,
	[patientsattachmentstypes_valueautofunc] [char](3) COLLATE Latin1_General_CI_AS NOT NULL,
 CONSTRAINT [PK_patientsattachmentstypes] PRIMARY KEY CLUSTERED 
(
	[patientsattachmentstypes_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END;
ALTER AUTHORIZATION ON [dbo].[patientsattachmentstypes] TO  SCHEMA OWNER;
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[patientsattributes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[patientsattributes](
	[patientsattributes_id] [int] IDENTITY(1,1) NOT NULL,
	[patients_id] [int] NOT NULL,
	[patientsattributestypes_id] [int] NOT NULL,
	[patientsattributes_value] [varchar](512) COLLATE Latin1_General_CI_AS NULL,
	[patientsattributes_note] [varchar](max) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [PK_patientsattributes] PRIMARY KEY CLUSTERED 
(
	[patientsattributes_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END;
ALTER AUTHORIZATION ON [dbo].[patientsattributes] TO  SCHEMA OWNER;
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[patientsattributestypes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[patientsattributestypes](
	[patientsattributestypes_id] [int] IDENTITY(1,1) NOT NULL,
	[patientsattributestypes_name] [varchar](32) COLLATE Latin1_General_CI_AS NOT NULL,
 CONSTRAINT [PK_patientsattributestypes] PRIMARY KEY CLUSTERED 
(
	[patientsattributestypes_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END;
ALTER AUTHORIZATION ON [dbo].[patientsattributestypes] TO  SCHEMA OWNER;
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[patientscontacts]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[patientscontacts](
	[patientscontacts_id] [int] IDENTITY(1,1) NOT NULL,
	[patients_id] [int] NOT NULL,
	[contactstypes_id] [int] NOT NULL,
	[patientscontacts_value] [varchar](256) COLLATE Latin1_General_CI_AS NOT NULL,
	[patientscontacts_note] [varchar](max) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [PK_patientscontacts] PRIMARY KEY CLUSTERED 
(
	[patientscontacts_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END;
ALTER AUTHORIZATION ON [dbo].[patientscontacts] TO  SCHEMA OWNER;
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[patientsmedicalrecords]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[patientsmedicalrecords](
	[patientsmedicalrecords_id] [int] IDENTITY(1,1) NOT NULL,
	[patients_id] [int] NOT NULL,
	[medicalrecordstypes_id] [int] NOT NULL,
	[patientsmedicalrecords_value] [varchar](128) COLLATE Latin1_General_CI_AS NULL,
	[patientsmedicalrecords_note] [varchar](max) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [PK_patientsmedicalrecords] PRIMARY KEY CLUSTERED 
(
	[patientsmedicalrecords_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END;
ALTER AUTHORIZATION ON [dbo].[patientsmedicalrecords] TO  SCHEMA OWNER;
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[patientsnotes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[patientsnotes](
	[patientsnotes_id] [int] IDENTITY(1,1) NOT NULL,
	[patients_id] [int] NOT NULL,
	[patientsnotes_date] [date] NOT NULL,
	[patientsnotes_text] [varchar](max) COLLATE Latin1_General_CI_AS NOT NULL,
 CONSTRAINT [PK_patientsnotes] PRIMARY KEY CLUSTERED 
(
	[patientsnotes_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END;
ALTER AUTHORIZATION ON [dbo].[patientsnotes] TO  SCHEMA OWNER;
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[patientstreatments]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[patientstreatments](
	[patientstreatments_id] [int] IDENTITY(1,1) NOT NULL,
	[doctors_id] [int] NOT NULL,
	[patients_id] [int] NOT NULL,
	[treatments_id] [int] NOT NULL,
	[patientstreatments_creationdate] [date] NOT NULL,
	[patientstreatments_fulfilldate] [date] NULL,
	[patientstreatments_ispaid] [bit] NOT NULL,
	[patientstreatments_price] [decimal](10, 2) NOT NULL,
	[patientstreatments_taxrate] [decimal](10, 2) NOT NULL,
	[patientstreatments_description] [varchar](max) COLLATE Latin1_General_CI_AS NULL,
	[patientstreatments_notes] [varchar](max) COLLATE Latin1_General_CI_AS NULL,
	[patientstreatments_expirationdate] [date] NULL,
 CONSTRAINT [PK_patientstreatments] PRIMARY KEY CLUSTERED 
(
	[patientstreatments_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END;
ALTER AUTHORIZATION ON [dbo].[patientstreatments] TO  SCHEMA OWNER;
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[payments]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[payments](
	[payments_id] [int] IDENTITY(1,1) NOT NULL,
	[patients_id] [int] NOT NULL,
	[payments_date] [date] NOT NULL,
	[payments_amount] [decimal](10, 2) NOT NULL,
	[payments_notes] [varchar](max) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [PK_payments] PRIMARY KEY CLUSTERED 
(
	[payments_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END;
ALTER AUTHORIZATION ON [dbo].[payments] TO  SCHEMA OWNER;
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[paymentstypes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[paymentstypes](
	[paymentstypes_id] [int] IDENTITY(1,1) NOT NULL,
	[paymentstypes_name] [varchar](16) COLLATE Latin1_General_CI_AS NOT NULL,
	[paymentstypes_doctext] [varchar](512) COLLATE Latin1_General_CI_AS NOT NULL,
	[paymentstypes_isdefault] [bit] NOT NULL,
 CONSTRAINT [PK_paymentstypes] PRIMARY KEY CLUSTERED 
(
	[paymentstypes_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END;
ALTER AUTHORIZATION ON [dbo].[paymentstypes] TO  SCHEMA OWNER;
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[reports]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[reports](
	[reports_id] [int] IDENTITY(1,1) NOT NULL,
	[reports_name] [varchar](64) COLLATE Latin1_General_CI_AS NOT NULL,
	[reports_query] [varchar](max) COLLATE Latin1_General_CI_AS NOT NULL,
	[reports_infotext] [varchar](max) COLLATE Latin1_General_CI_AS NULL,
	[reports_ispasswordprotected] [bit] NOT NULL CONSTRAINT [DF_reports_reports_ispasswordprotected]  DEFAULT ((0)),
 CONSTRAINT [PK_reports] PRIMARY KEY CLUSTERED 
(
	[reports_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END;
ALTER AUTHORIZATION ON [dbo].[reports] TO  SCHEMA OWNER;
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rooms]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[rooms](
	[rooms_id] [int] IDENTITY(1,1) NOT NULL,
	[rooms_name] [varchar](16) COLLATE Latin1_General_CI_AS NOT NULL,
	[rooms_color] [char](7) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [PK_rooms] PRIMARY KEY CLUSTERED 
(
	[rooms_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END;
ALTER AUTHORIZATION ON [dbo].[rooms] TO  SCHEMA OWNER;
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sysdiagrams]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sysdiagrams](
	[name] [sysname] COLLATE Latin1_General_CI_AS NOT NULL,
	[principal_id] [int] NOT NULL,
	[diagram_id] [int] IDENTITY(1,1) NOT NULL,
	[version] [int] NULL,
	[definition] [varbinary](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[diagram_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_principal_name] UNIQUE NONCLUSTERED 
(
	[principal_id] ASC,
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END;
ALTER AUTHORIZATION ON [dbo].[sysdiagrams] TO  SCHEMA OWNER;
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[taxes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[taxes](
	[taxes_id] [int] IDENTITY(1,1) NOT NULL,
	[taxes_name] [varchar](16) COLLATE Latin1_General_CI_AS NOT NULL,
	[taxes_rate] [decimal](10, 2) NOT NULL,
	[taxes_isdefault] [bit] NOT NULL,
 CONSTRAINT [PK_taxes] PRIMARY KEY CLUSTERED 
(
	[taxes_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END;
ALTER AUTHORIZATION ON [dbo].[taxes] TO  SCHEMA OWNER;
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[taxesdeductions]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[taxesdeductions](
	[taxesdeductions_id] [int] IDENTITY(1,1) NOT NULL,
	[taxesdeductions_name] [varchar](16) COLLATE Latin1_General_CI_AS NOT NULL,
	[taxesdeductions_rate] [decimal](10, 2) NOT NULL,
	[taxesdeductions_isdefault] [bit] NOT NULL,
 CONSTRAINT [PK_taxesdeductions] PRIMARY KEY CLUSTERED 
(
	[taxesdeductions_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END;
ALTER AUTHORIZATION ON [dbo].[taxesdeductions] TO  SCHEMA OWNER;
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[treatments]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[treatments](
	[treatments_id] [int] IDENTITY(1,1) NOT NULL,
	[taxes_id] [int] NULL,
	[treatmentstypes_id] [int] NOT NULL,
	[treatments_code] [char](3) COLLATE Latin1_General_CI_AS NOT NULL,
	[treatments_name] [varchar](32) COLLATE Latin1_General_CI_AS NOT NULL,
	[treatments_price] [decimal](10, 2) NOT NULL,
	[treatments_mexpiration] [tinyint] NULL,
	[treatments_notes] [varchar](max) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [PK_treatments] PRIMARY KEY CLUSTERED 
(
	[treatments_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END;
ALTER AUTHORIZATION ON [dbo].[treatments] TO  SCHEMA OWNER;
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[treatmentsprices]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[treatmentsprices](
	[treatmentsprices_id] [int] IDENTITY(1,1) NOT NULL,
	[treatments_id] [int] NOT NULL,
	[treatmentspriceslists_id] [int] NOT NULL,
	[treatmentsprices_price] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_treatmentsprices] PRIMARY KEY CLUSTERED 
(
	[treatmentsprices_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END;
ALTER AUTHORIZATION ON [dbo].[treatmentsprices] TO  SCHEMA OWNER;
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[treatmentspriceslists]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[treatmentspriceslists](
	[treatmentspriceslists_id] [int] IDENTITY(1,1) NOT NULL,
	[treatmentspriceslists_name] [varchar](16) COLLATE Latin1_General_CI_AS NOT NULL,
	[treatmentspriceslists_multiplier] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_treatmentspriceslists] PRIMARY KEY CLUSTERED 
(
	[treatmentspriceslists_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END;
ALTER AUTHORIZATION ON [dbo].[treatmentspriceslists] TO  SCHEMA OWNER;
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[treatmentstypes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[treatmentstypes](
	[treatmentstypes_id] [int] IDENTITY(1,1) NOT NULL,
	[treatmentstypes_name] [varchar](16) COLLATE Latin1_General_CI_AS NOT NULL,
 CONSTRAINT [PK_treatmentstypes] PRIMARY KEY CLUSTERED 
(
	[treatmentstypes_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END;
ALTER AUTHORIZATION ON [dbo].[treatmentstypes] TO  SCHEMA OWNER;
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_appointments_doctors]') AND parent_object_id = OBJECT_ID(N'[dbo].[appointments]'))
ALTER TABLE [dbo].[appointments]  WITH CHECK ADD  CONSTRAINT [FK_appointments_doctors] FOREIGN KEY([doctors_id])
REFERENCES [dbo].[doctors] ([doctors_id]);
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_appointments_doctors]') AND parent_object_id = OBJECT_ID(N'[dbo].[appointments]'))
ALTER TABLE [dbo].[appointments] CHECK CONSTRAINT [FK_appointments_doctors];
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_appointments_patients]') AND parent_object_id = OBJECT_ID(N'[dbo].[appointments]'))
ALTER TABLE [dbo].[appointments]  WITH CHECK ADD  CONSTRAINT [FK_appointments_patients] FOREIGN KEY([patients_id])
REFERENCES [dbo].[patients] ([patients_id]);
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_appointments_patients]') AND parent_object_id = OBJECT_ID(N'[dbo].[appointments]'))
ALTER TABLE [dbo].[appointments] CHECK CONSTRAINT [FK_appointments_patients];
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_appointments_rooms]') AND parent_object_id = OBJECT_ID(N'[dbo].[appointments]'))
ALTER TABLE [dbo].[appointments]  WITH CHECK ADD  CONSTRAINT [FK_appointments_rooms] FOREIGN KEY([rooms_id])
REFERENCES [dbo].[rooms] ([rooms_id]);
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_appointments_rooms]') AND parent_object_id = OBJECT_ID(N'[dbo].[appointments]'))
ALTER TABLE [dbo].[appointments] CHECK CONSTRAINT [FK_appointments_rooms];
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_computedlines_taxes]') AND parent_object_id = OBJECT_ID(N'[dbo].[computedlines]'))
ALTER TABLE [dbo].[computedlines]  WITH CHECK ADD  CONSTRAINT [FK_computedlines_taxes] FOREIGN KEY([taxes_id])
REFERENCES [dbo].[taxes] ([taxes_id]);
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_computedlines_taxes]') AND parent_object_id = OBJECT_ID(N'[dbo].[computedlines]'))
ALTER TABLE [dbo].[computedlines] CHECK CONSTRAINT [FK_computedlines_taxes];
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_estimates_doctors]') AND parent_object_id = OBJECT_ID(N'[dbo].[estimates]'))
ALTER TABLE [dbo].[estimates]  WITH CHECK ADD  CONSTRAINT [FK_estimates_doctors] FOREIGN KEY([doctors_id])
REFERENCES [dbo].[doctors] ([doctors_id]);
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_estimates_doctors]') AND parent_object_id = OBJECT_ID(N'[dbo].[estimates]'))
ALTER TABLE [dbo].[estimates] CHECK CONSTRAINT [FK_estimates_doctors];
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_estimates_invoices]') AND parent_object_id = OBJECT_ID(N'[dbo].[estimates]'))
ALTER TABLE [dbo].[estimates]  WITH CHECK ADD  CONSTRAINT [FK_estimates_invoices] FOREIGN KEY([invoices_id])
REFERENCES [dbo].[invoices] ([invoices_id]);
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_estimates_invoices]') AND parent_object_id = OBJECT_ID(N'[dbo].[estimates]'))
ALTER TABLE [dbo].[estimates] CHECK CONSTRAINT [FK_estimates_invoices];
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_estimates_patients]') AND parent_object_id = OBJECT_ID(N'[dbo].[estimates]'))
ALTER TABLE [dbo].[estimates]  WITH CHECK ADD  CONSTRAINT [FK_estimates_patients] FOREIGN KEY([patients_id])
REFERENCES [dbo].[patients] ([patients_id]);
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_estimates_patients]') AND parent_object_id = OBJECT_ID(N'[dbo].[estimates]'))
ALTER TABLE [dbo].[estimates] CHECK CONSTRAINT [FK_estimates_patients];
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_estimatesfooters_estimatesfooters_isdefault]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[estimatesfooters] ADD  CONSTRAINT [DF_estimatesfooters_estimatesfooters_isdefault]  DEFAULT ((0)) FOR [estimatesfooters_isdefault]
END;
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_estimateslines_estimateslines_istaxesdeductionsable]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[estimateslines] ADD  CONSTRAINT [DF_estimateslines_estimateslines_istaxesdeductionsable]  DEFAULT ((1)) FOR [estimateslines_istaxesdeductionsable]
END;
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_estimateslines_estimates]') AND parent_object_id = OBJECT_ID(N'[dbo].[estimateslines]'))
ALTER TABLE [dbo].[estimateslines]  WITH CHECK ADD  CONSTRAINT [FK_estimateslines_estimates] FOREIGN KEY([estimates_id])
REFERENCES [dbo].[estimates] ([estimates_id]);
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_estimateslines_estimates]') AND parent_object_id = OBJECT_ID(N'[dbo].[estimateslines]'))
ALTER TABLE [dbo].[estimateslines] CHECK CONSTRAINT [FK_estimateslines_estimates];
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_estimateslines_patientstreatments]') AND parent_object_id = OBJECT_ID(N'[dbo].[estimateslines]'))
ALTER TABLE [dbo].[estimateslines]  WITH CHECK ADD  CONSTRAINT [FK_estimateslines_patientstreatments] FOREIGN KEY([patientstreatments_id])
REFERENCES [dbo].[patientstreatments] ([patientstreatments_id]);
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_estimateslines_patientstreatments]') AND parent_object_id = OBJECT_ID(N'[dbo].[estimateslines]'))
ALTER TABLE [dbo].[estimateslines] CHECK CONSTRAINT [FK_estimateslines_patientstreatments];
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_invoices_doctors]') AND parent_object_id = OBJECT_ID(N'[dbo].[invoices]'))
ALTER TABLE [dbo].[invoices]  WITH CHECK ADD  CONSTRAINT [FK_invoices_doctors] FOREIGN KEY([doctors_id])
REFERENCES [dbo].[doctors] ([doctors_id]);
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_invoices_doctors]') AND parent_object_id = OBJECT_ID(N'[dbo].[invoices]'))
ALTER TABLE [dbo].[invoices] CHECK CONSTRAINT [FK_invoices_doctors];
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_invoices_patients]') AND parent_object_id = OBJECT_ID(N'[dbo].[invoices]'))
ALTER TABLE [dbo].[invoices]  WITH CHECK ADD  CONSTRAINT [FK_invoices_patients] FOREIGN KEY([patients_id])
REFERENCES [dbo].[patients] ([patients_id]);
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_invoices_patients]') AND parent_object_id = OBJECT_ID(N'[dbo].[invoices]'))
ALTER TABLE [dbo].[invoices] CHECK CONSTRAINT [FK_invoices_patients];
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_invoicesfooters_invoicesfooters_isdefault]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[invoicesfooters] ADD  CONSTRAINT [DF_invoicesfooters_invoicesfooters_isdefault]  DEFAULT ((0)) FOR [invoicesfooters_isdefault]
END;
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_invoiceslines_invoiceslines_istaxesdeductionsable]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[invoiceslines] ADD  CONSTRAINT [DF_invoiceslines_invoiceslines_istaxesdeductionsable]  DEFAULT ((1)) FOR [invoiceslines_istaxesdeductionsable]
END;
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_invoiceslines_invoices]') AND parent_object_id = OBJECT_ID(N'[dbo].[invoiceslines]'))
ALTER TABLE [dbo].[invoiceslines]  WITH CHECK ADD  CONSTRAINT [FK_invoiceslines_invoices] FOREIGN KEY([invoices_id])
REFERENCES [dbo].[invoices] ([invoices_id]);
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_invoiceslines_invoices]') AND parent_object_id = OBJECT_ID(N'[dbo].[invoiceslines]'))
ALTER TABLE [dbo].[invoiceslines] CHECK CONSTRAINT [FK_invoiceslines_invoices];
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_invoiceslines_patientstreatments]') AND parent_object_id = OBJECT_ID(N'[dbo].[invoiceslines]'))
ALTER TABLE [dbo].[invoiceslines]  WITH CHECK ADD  CONSTRAINT [FK_invoiceslines_patientstreatments] FOREIGN KEY([patientstreatments_id])
REFERENCES [dbo].[patientstreatments] ([patientstreatments_id]);
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_invoiceslines_patientstreatments]') AND parent_object_id = OBJECT_ID(N'[dbo].[invoiceslines]'))
ALTER TABLE [dbo].[invoiceslines] CHECK CONSTRAINT [FK_invoiceslines_patientstreatments];
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_patients_treatmentspriceslists]') AND parent_object_id = OBJECT_ID(N'[dbo].[patients]'))
ALTER TABLE [dbo].[patients]  WITH CHECK ADD  CONSTRAINT [FK_patients_treatmentspriceslists] FOREIGN KEY([treatmentspriceslists_id])
REFERENCES [dbo].[treatmentspriceslists] ([treatmentspriceslists_id]);
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_patients_treatmentspriceslists]') AND parent_object_id = OBJECT_ID(N'[dbo].[patients]'))
ALTER TABLE [dbo].[patients] CHECK CONSTRAINT [FK_patients_treatmentspriceslists];
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_patientsaddresses_addressestypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[patientsaddresses]'))
ALTER TABLE [dbo].[patientsaddresses]  WITH CHECK ADD  CONSTRAINT [FK_patientsaddresses_addressestypes] FOREIGN KEY([addressestypes_id])
REFERENCES [dbo].[addressestypes] ([addressestypes_id]);
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_patientsaddresses_addressestypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[patientsaddresses]'))
ALTER TABLE [dbo].[patientsaddresses] CHECK CONSTRAINT [FK_patientsaddresses_addressestypes];
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_patientsaddresses_patients]') AND parent_object_id = OBJECT_ID(N'[dbo].[patientsaddresses]'))
ALTER TABLE [dbo].[patientsaddresses]  WITH CHECK ADD  CONSTRAINT [FK_patientsaddresses_patients] FOREIGN KEY([patients_id])
REFERENCES [dbo].[patients] ([patients_id]);
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_patientsaddresses_patients]') AND parent_object_id = OBJECT_ID(N'[dbo].[patientsaddresses]'))
ALTER TABLE [dbo].[patientsaddresses] CHECK CONSTRAINT [FK_patientsaddresses_patients];
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_patientsattachments_patients]') AND parent_object_id = OBJECT_ID(N'[dbo].[patientsattachments]'))
ALTER TABLE [dbo].[patientsattachments]  WITH CHECK ADD  CONSTRAINT [FK_patientsattachments_patients] FOREIGN KEY([patients_id])
REFERENCES [dbo].[patients] ([patients_id]);
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_patientsattachments_patients]') AND parent_object_id = OBJECT_ID(N'[dbo].[patientsattachments]'))
ALTER TABLE [dbo].[patientsattachments] CHECK CONSTRAINT [FK_patientsattachments_patients];
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_patientsattachments_patientsattachmentstypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[patientsattachments]'))
ALTER TABLE [dbo].[patientsattachments]  WITH CHECK ADD  CONSTRAINT [FK_patientsattachments_patientsattachmentstypes] FOREIGN KEY([patientsattachmentstypes_id])
REFERENCES [dbo].[patientsattachmentstypes] ([patientsattachmentstypes_id]);
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_patientsattachments_patientsattachmentstypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[patientsattachments]'))
ALTER TABLE [dbo].[patientsattachments] CHECK CONSTRAINT [FK_patientsattachments_patientsattachmentstypes];
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_patientsattachmentstypes_patientsattachmentstypes_valuefunc]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[patientsattachmentstypes] ADD  CONSTRAINT [DF_patientsattachmentstypes_patientsattachmentstypes_valuefunc]  DEFAULT ('NUL') FOR [patientsattachmentstypes_valueautofunc]
END;
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_patientsattributes_patients]') AND parent_object_id = OBJECT_ID(N'[dbo].[patientsattributes]'))
ALTER TABLE [dbo].[patientsattributes]  WITH CHECK ADD  CONSTRAINT [FK_patientsattributes_patients] FOREIGN KEY([patients_id])
REFERENCES [dbo].[patients] ([patients_id]);
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_patientsattributes_patients]') AND parent_object_id = OBJECT_ID(N'[dbo].[patientsattributes]'))
ALTER TABLE [dbo].[patientsattributes] CHECK CONSTRAINT [FK_patientsattributes_patients];
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_patientsattributes_patientsattributestypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[patientsattributes]'))
ALTER TABLE [dbo].[patientsattributes]  WITH CHECK ADD  CONSTRAINT [FK_patientsattributes_patientsattributestypes] FOREIGN KEY([patientsattributestypes_id])
REFERENCES [dbo].[patientsattributestypes] ([patientsattributestypes_id]);
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_patientsattributes_patientsattributestypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[patientsattributes]'))
ALTER TABLE [dbo].[patientsattributes] CHECK CONSTRAINT [FK_patientsattributes_patientsattributestypes];
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_patientscontacts_contactstypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[patientscontacts]'))
ALTER TABLE [dbo].[patientscontacts]  WITH CHECK ADD  CONSTRAINT [FK_patientscontacts_contactstypes] FOREIGN KEY([contactstypes_id])
REFERENCES [dbo].[contactstypes] ([contactstypes_id]);
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_patientscontacts_contactstypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[patientscontacts]'))
ALTER TABLE [dbo].[patientscontacts] CHECK CONSTRAINT [FK_patientscontacts_contactstypes];
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_patientscontacts_patients]') AND parent_object_id = OBJECT_ID(N'[dbo].[patientscontacts]'))
ALTER TABLE [dbo].[patientscontacts]  WITH CHECK ADD  CONSTRAINT [FK_patientscontacts_patients] FOREIGN KEY([patients_id])
REFERENCES [dbo].[patients] ([patients_id]);
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_patientscontacts_patients]') AND parent_object_id = OBJECT_ID(N'[dbo].[patientscontacts]'))
ALTER TABLE [dbo].[patientscontacts] CHECK CONSTRAINT [FK_patientscontacts_patients];
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_patientsmedicalrecords_medicalrecordstypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[patientsmedicalrecords]'))
ALTER TABLE [dbo].[patientsmedicalrecords]  WITH CHECK ADD  CONSTRAINT [FK_patientsmedicalrecords_medicalrecordstypes] FOREIGN KEY([medicalrecordstypes_id])
REFERENCES [dbo].[medicalrecordstypes] ([medicalrecordstypes_id]);
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_patientsmedicalrecords_medicalrecordstypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[patientsmedicalrecords]'))
ALTER TABLE [dbo].[patientsmedicalrecords] CHECK CONSTRAINT [FK_patientsmedicalrecords_medicalrecordstypes];
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_patientsmedicalrecords_patients]') AND parent_object_id = OBJECT_ID(N'[dbo].[patientsmedicalrecords]'))
ALTER TABLE [dbo].[patientsmedicalrecords]  WITH CHECK ADD  CONSTRAINT [FK_patientsmedicalrecords_patients] FOREIGN KEY([patients_id])
REFERENCES [dbo].[patients] ([patients_id]);
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_patientsmedicalrecords_patients]') AND parent_object_id = OBJECT_ID(N'[dbo].[patientsmedicalrecords]'))
ALTER TABLE [dbo].[patientsmedicalrecords] CHECK CONSTRAINT [FK_patientsmedicalrecords_patients];
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_patientsnotes_patients]') AND parent_object_id = OBJECT_ID(N'[dbo].[patientsnotes]'))
ALTER TABLE [dbo].[patientsnotes]  WITH CHECK ADD  CONSTRAINT [FK_patientsnotes_patients] FOREIGN KEY([patients_id])
REFERENCES [dbo].[patients] ([patients_id]);
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_patientsnotes_patients]') AND parent_object_id = OBJECT_ID(N'[dbo].[patientsnotes]'))
ALTER TABLE [dbo].[patientsnotes] CHECK CONSTRAINT [FK_patientsnotes_patients];
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_patientstreatments_patientstreatments_ispayed]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[patientstreatments] ADD  CONSTRAINT [DF_patientstreatments_patientstreatments_ispayed]  DEFAULT ((0)) FOR [patientstreatments_ispaid]
END;
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_patientstreatments_doctors]') AND parent_object_id = OBJECT_ID(N'[dbo].[patientstreatments]'))
ALTER TABLE [dbo].[patientstreatments]  WITH CHECK ADD  CONSTRAINT [FK_patientstreatments_doctors] FOREIGN KEY([doctors_id])
REFERENCES [dbo].[doctors] ([doctors_id]);
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_patientstreatments_doctors]') AND parent_object_id = OBJECT_ID(N'[dbo].[patientstreatments]'))
ALTER TABLE [dbo].[patientstreatments] CHECK CONSTRAINT [FK_patientstreatments_doctors];
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_patientstreatments_patients]') AND parent_object_id = OBJECT_ID(N'[dbo].[patientstreatments]'))
ALTER TABLE [dbo].[patientstreatments]  WITH CHECK ADD  CONSTRAINT [FK_patientstreatments_patients] FOREIGN KEY([patients_id])
REFERENCES [dbo].[patients] ([patients_id]);
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_patientstreatments_patients]') AND parent_object_id = OBJECT_ID(N'[dbo].[patientstreatments]'))
ALTER TABLE [dbo].[patientstreatments] CHECK CONSTRAINT [FK_patientstreatments_patients];
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_patientstreatments_treatments]') AND parent_object_id = OBJECT_ID(N'[dbo].[patientstreatments]'))
ALTER TABLE [dbo].[patientstreatments]  WITH CHECK ADD  CONSTRAINT [FK_patientstreatments_treatments] FOREIGN KEY([treatments_id])
REFERENCES [dbo].[treatments] ([treatments_id]);
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_patientstreatments_treatments]') AND parent_object_id = OBJECT_ID(N'[dbo].[patientstreatments]'))
ALTER TABLE [dbo].[patientstreatments] CHECK CONSTRAINT [FK_patientstreatments_treatments];
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_payments_patients]') AND parent_object_id = OBJECT_ID(N'[dbo].[payments]'))
ALTER TABLE [dbo].[payments]  WITH CHECK ADD  CONSTRAINT [FK_payments_patients] FOREIGN KEY([patients_id])
REFERENCES [dbo].[patients] ([patients_id]);
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_payments_patients]') AND parent_object_id = OBJECT_ID(N'[dbo].[payments]'))
ALTER TABLE [dbo].[payments] CHECK CONSTRAINT [FK_payments_patients];
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_paymentstypes_paymentstypes_isdefault]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[paymentstypes] ADD  CONSTRAINT [DF_paymentstypes_paymentstypes_isdefault]  DEFAULT ((0)) FOR [paymentstypes_isdefault]
END;
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_taxes_taxes_isdefault]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[taxes] ADD  CONSTRAINT [DF_taxes_taxes_isdefault]  DEFAULT ((0)) FOR [taxes_isdefault]
END;
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_taxesdeductions_taxesdeductions_isdefault]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[taxesdeductions] ADD  CONSTRAINT [DF_taxesdeductions_taxesdeductions_isdefault]  DEFAULT ((0)) FOR [taxesdeductions_isdefault]
END;
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_treatments_taxes]') AND parent_object_id = OBJECT_ID(N'[dbo].[treatments]'))
ALTER TABLE [dbo].[treatments]  WITH CHECK ADD  CONSTRAINT [FK_treatments_taxes] FOREIGN KEY([taxes_id])
REFERENCES [dbo].[taxes] ([taxes_id]);
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_treatments_taxes]') AND parent_object_id = OBJECT_ID(N'[dbo].[treatments]'))
ALTER TABLE [dbo].[treatments] CHECK CONSTRAINT [FK_treatments_taxes];
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_treatments_treatmentstypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[treatments]'))
ALTER TABLE [dbo].[treatments]  WITH CHECK ADD  CONSTRAINT [FK_treatments_treatmentstypes] FOREIGN KEY([treatmentstypes_id])
REFERENCES [dbo].[treatmentstypes] ([treatmentstypes_id]);
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_treatments_treatmentstypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[treatments]'))
ALTER TABLE [dbo].[treatments] CHECK CONSTRAINT [FK_treatments_treatmentstypes];
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_treatmentsprices_treatments]') AND parent_object_id = OBJECT_ID(N'[dbo].[treatmentsprices]'))
ALTER TABLE [dbo].[treatmentsprices]  WITH CHECK ADD  CONSTRAINT [FK_treatmentsprices_treatments] FOREIGN KEY([treatments_id])
REFERENCES [dbo].[treatments] ([treatments_id]);
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_treatmentsprices_treatments]') AND parent_object_id = OBJECT_ID(N'[dbo].[treatmentsprices]'))
ALTER TABLE [dbo].[treatmentsprices] CHECK CONSTRAINT [FK_treatmentsprices_treatments];
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_treatmentsprices_treatmentspriceslists]') AND parent_object_id = OBJECT_ID(N'[dbo].[treatmentsprices]'))
ALTER TABLE [dbo].[treatmentsprices]  WITH CHECK ADD  CONSTRAINT [FK_treatmentsprices_treatmentspriceslists] FOREIGN KEY([treatmentspriceslists_id])
REFERENCES [dbo].[treatmentspriceslists] ([treatmentspriceslists_id]);
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_treatmentsprices_treatmentspriceslists]') AND parent_object_id = OBJECT_ID(N'[dbo].[treatmentsprices]'))
ALTER TABLE [dbo].[treatmentsprices] CHECK CONSTRAINT [FK_treatmentsprices_treatmentspriceslists];
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_treatmentspriceslists_treatmentspriceslists_multiplier]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[treatmentspriceslists] ADD  CONSTRAINT [DF_treatmentspriceslists_treatmentspriceslists_multiplier]  DEFAULT ((1)) FOR [treatmentspriceslists_multiplier]
END;
