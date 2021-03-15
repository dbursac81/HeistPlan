-- SQLINES DEMO *** sktop version to convert large SQL scripts,
-- SQLINES DEMO *** ny issues with Online conversion.

-- SQLINES DEMO *** act us at support@sqlines.com

USE master;
 
/* SQLINES DEMO *** abase [Ag04]    Script Date: 15.3.2021. 15:36:57 ******/
CREATE DATABASE [Ag04]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Ag04', FILENAME = N'C:Program FilesMicrosoft SQL ServerMSSQL15.SQL2019EXMSSQLDATAAg04.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Ag04_log', FILENAME = N'C:Program FilesMicrosoft SQL ServerMSSQL15.SQL2019EXMSSQLDATAAg04_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Ag04] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
then
EXECUTE Ag04.dbo.sp_fulltext_database; @action = 'enable'
end if;
 
ALTER DATABASE [Ag04] SET ANSI_NULL_DEFAULT OFF 
 
ALTER DATABASE [Ag04] /* SET ANSI_NULLS OFF */ 
 
ALTER DATABASE [Ag04] /* SET ANSI_PADDING OFF */ 
 
ALTER DATABASE [Ag04] SET ANSI_WARNINGS OFF 
 
ALTER DATABASE [Ag04] SET ARITHABORT OFF 
 
ALTER DATABASE [Ag04] SET AUTO_CLOSE OFF 
 
ALTER DATABASE [Ag04] SET AUTO_SHRINK OFF 
 
ALTER DATABASE [Ag04] SET AUTO_UPDATE_STATISTICS ON 
 
ALTER DATABASE [Ag04] SET CURSOR_CLOSE_ON_COMMIT OFF 
 
ALTER DATABASE [Ag04] SET CURSOR_DEFAULT  GLOBAL 
 
ALTER DATABASE [Ag04] SET CONCAT_NULL_YIELDS_NULL OFF 
 
ALTER DATABASE [Ag04] SET NUMERIC_ROUNDABORT OFF 
 
ALTER DATABASE [Ag04] /* SET QUOTED_IDENTIFIER OFF */ 
 
ALTER DATABASE [Ag04] SET RECURSIVE_TRIGGERS OFF 
 
ALTER DATABASE [Ag04] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Ag04] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
 
ALTER DATABASE [Ag04] SET DATE_CORRELATION_OPTIMIZATION OFF 
 
ALTER DATABASE [Ag04] SET TRUSTWORTHY OFF 
 
ALTER DATABASE [Ag04] SET ALLOW_SNAPSHOT_ISOLATION OFF 
 
ALTER DATABASE [Ag04] SET PARAMETERIZATION SIMPLE 
 
ALTER DATABASE [Ag04] SET READ_COMMITTED_SNAPSHOT OFF 
 
ALTER DATABASE [Ag04] SET HONOR_BROKER_PRIORITY OFF 
 
ALTER DATABASE [Ag04] SET RECOVERY SIMPLE 
 
ALTER DATABASE [Ag04] SET  MULTI_USER 
 
ALTER DATABASE [Ag04] SET PAGE_VERIFY CHECKSUM  
 
ALTER DATABASE [Ag04] SET DB_CHAINING OFF 
 
ALTER DATABASE [Ag04] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
 
ALTER DATABASE [Ag04] SET TARGET_RECOVERY_TIME = 60 SECONDS 
 
ALTER DATABASE [Ag04] SET DELAYED_DURABILITY = DISABLED 
 
ALTER DATABASE [Ag04] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Ag04] SET QUERY_STORE = OFF
 
USE Ag04;
 
/* SQLINES DEMO *** le [dbo].[tblHeist]    Script Date: 15.3.2021. 15:36:57 ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
CREATE SEQUENCE tblHeist_seq;

CREATE TABLE tblHeist(
	HeistID int DEFAULT NEXTVAL ('tblHeist_seq') NOT NULL,
	Name Varchar(50) NULL,
	Location Varchar(50) NULL,
	StartDate date NULL,
	StartTime Timestamp(3) NULL,
	EndDate date NULL,
	EndTime Timestamp(3) NULL,
	Active Boolean NULL,
 CONSTRAINT PK_tblHeist PRIMARY KEY 
(
	HeistID ASC
)  OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/* SQLINES DEMO *** le [dbo].[tblHeistMembers]    Script Date: 15.3.2021. 15:36:57 ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
CREATE SEQUENCE tblHeistMembers_seq;

CREATE TABLE tblHeistMembers(
	ID int DEFAULT NEXTVAL ('tblHeistMembers_seq') NOT NULL,
	HeistID int NULL,
	MemberID int NULL,
	Status Varchar(30) NULL,
	ActiveInHeist Boolean NULL,
 CONSTRAINT PK_tblHeistMembers PRIMARY KEY 
(
	ID ASC
)  OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/* SQLINES DEMO *** le [dbo].[tblHeistSkills]    Script Date: 15.3.2021. 15:36:57 ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
CREATE SEQUENCE tblHeistSkills_seq;

CREATE TABLE tblHeistSkills(
	SkillsID int DEFAULT NEXTVAL ('tblHeistSkills_seq') NOT NULL,
	HeistID int NOT NULL,
	Name Varchar(50) NULL,
	SkillLevel Varchar(10) NULL,
	MembersNo smallint NULL,
 CONSTRAINT PK_tblHeistSkills PRIMARY KEY 
(
	SkillsID ASC
)  OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/* SQLINES DEMO *** le [dbo].[tblMember]    Script Date: 15.3.2021. 15:36:57 ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
CREATE SEQUENCE tblMember_seq;

CREATE TABLE tblMember(
	MemberID int DEFAULT NEXTVAL ('tblMember_seq') NOT NULL,
	Name Varchar(50) NOT NULL,
	Email Varchar(50) NULL,
	Sex Char(1) NULL,
	Status Varchar(50) NULL,
	Active Boolean NULL,
	ActiveInHeist Boolean NULL,
 CONSTRAINT PK_tblHeistMember PRIMARY KEY 
(
	MemberID ASC
)  OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/* SQLINES DEMO *** le [dbo].[tblMemberSkills]    Script Date: 15.3.2021. 15:36:57 ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
CREATE SEQUENCE tblMemberSkills_seq;

CREATE TABLE tblMemberSkills(
	SkillID int DEFAULT NEXTVAL ('tblMemberSkills_seq') NOT NULL,
	MemberID int NOT NULL,
	Name Varchar(50) NOT NULL,
	SkillLevel Varchar(10) NOT NULL,
 CONSTRAINT PK_tblMemberSkills PRIMARY KEY 
(
	SkillID ASC
)  OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT dbo.tblHeist ON 

INSERT [dbo].[tblHeist] (HeistID, Name, Location, StartDate, StartTime, EndDate, EndTime, Active) SELECT (1, N'testtt', N'berlinnnnn', CAST(N'2021-03-08' AS Date), CAST(N'2021-03-09T18:39:00.000' AS TIMESTAMP(3)), CAST(N'2021-03-08' AS Date), CAST(N'2021-03-09T18:39:00.000' AS TIMESTAMP(3)), 0)
INSERT tblHeist (HeistID, Name, Location, StartDate, StartTime, EndDate, EndTime, Active) VALUES (2, N'test 2222', N'oslo', CAST(N'2021-03-08' AS Date), CAST(N'2021-03-09T18:42:00.000' AS TIMESTAMP(3)), CAST(N'2021-03-08' AS Date), CAST(N'2021-03-09T18:42:00.000' AS TIMESTAMP(3)), 0)
INSERT tblHeist (HeistID, Name, Location, StartDate, StartTime, EndDate, EndTime, Active) VALUES (3, N'test 33', N'london', CAST(N'2021-03-08' AS Date), CAST(N'2021-03-09T18:45:00.000' AS TIMESTAMP(3)), CAST(N'2021-03-08' AS Date), CAST(N'2021-03-09T18:45:00.000' AS TIMESTAMP(3)), 0)
INSERT tblHeist (HeistID, Name, Location, StartDate, StartTime, EndDate, EndTime, Active) VALUES (4, N'test 4', N'tokio', CAST(N'2021-03-08' AS Date), CAST(N'2021-03-08T19:01:00.000' AS TIMESTAMP(3)), CAST(N'2021-03-08' AS Date), CAST(N'2021-03-08T19:01:00.000' AS TIMESTAMP(3)), 0)
INSERT tblHeist (HeistID, Name, Location, StartDate, StartTime, EndDate, EndTime, Active) VALUES (5, N'test 5', N'paris', CAST(N'2021-03-08' AS Date), CAST(N'2021-03-08T19:03:00.000' AS TIMESTAMP(3)), CAST(N'2021-03-08' AS Date), CAST(N'2021-03-08T19:03:00.000' AS TIMESTAMP(3)), 0)
INSERT tblHeist (HeistID, Name, Location, StartDate, StartTime, EndDate, EndTime, Active) VALUES (6, N'test 6', N'nairobi', CAST(N'2021-03-09' AS Date), CAST(N'2021-03-09T10:08:00.000' AS TIMESTAMP(3)), CAST(N'2021-03-09' AS Date), CAST(N'2021-03-09T10:08:00.000' AS TIMESTAMP(3)), 0)
INSERT tblHeist (HeistID, Name, Location, StartDate, StartTime, EndDate, EndTime, Active) VALUES (7, N'test 7', N'marocco', CAST(N'2021-03-09' AS Date), CAST(N'2021-03-09T10:16:00.000' AS TIMESTAMP(3)), CAST(N'2021-03-09' AS Date), CAST(N'2021-03-09T10:16:00.000' AS TIMESTAMP(3)), 0)
INSERT tblHeist (HeistID, Name, Location, StartDate, StartTime, EndDate, EndTime, Active) VALUES (11, N'testttt', N'zagreb', CAST(N'2021-03-09' AS Date), CAST(N'2021-03-09T11:55:00.000' AS TIMESTAMP(3)), CAST(N'2021-03-09' AS Date), CAST(N'2021-03-09T11:55:00.000' AS TIMESTAMP(3)), 0)
INSERT tblHeist (HeistID, Name, Location, StartDate, StartTime, EndDate, EndTime, Active) VALUES (12, N'test 15', N'kairo', CAST(N'2021-03-09' AS Date), CAST(N'2021-03-09T12:03:00.000' AS TIMESTAMP(3)), CAST(N'2021-03-09' AS Date), CAST(N'2021-03-09T12:03:00.000' AS TIMESTAMP(3)), 0)
INSERT tblHeist (HeistID, Name, Location, StartDate, StartTime, EndDate, EndTime, Active) VALUES (13, N'test16', N'ssss', CAST(N'2021-03-09' AS Date), CAST(N'2021-03-09T12:05:00.000' AS TIMESTAMP(3)), CAST(N'2021-03-09' AS Date), CAST(N'2021-03-09T12:05:00.000' AS TIMESTAMP(3)), 0)
INSERT tblHeist (HeistID, Name, Location, StartDate, StartTime, EndDate, EndTime, Active) VALUES (31, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT dbo.tblHeist OFF
GO
SET IDENTITY_INSERT dbo.tblHeistMembers ON 

INSERT [dbo].[tblHeistMembers] (ID, HeistID, MemberID, Status, ActiveInHeist) SELECT (19, 1, 4, N'EXPIRED', 1)
INSERT tblHeistMembers (ID, HeistID, MemberID, Status, ActiveInHeist) VALUES (20, 1, 2007, N'SURVIVED', 1)
INSERT tblHeistMembers (ID, HeistID, MemberID, Status, ActiveInHeist) VALUES (26, 1, 1006, N'EXPIRED', 1)
INSERT tblHeistMembers (ID, HeistID, MemberID, Status, ActiveInHeist) VALUES (27, 1, 2006, N'SURVIVED', 1)
INSERT tblHeistMembers (ID, HeistID, MemberID, Status, ActiveInHeist) VALUES (29, 1, 2009, N'SURVIVED', 1)
SET IDENTITY_INSERT dbo.tblHeistMembers OFF
GO
SET IDENTITY_INSERT dbo.tblHeistSkills ON 

INSERT [dbo].[tblHeistSkills] (SkillsID, HeistID, Name, SkillLevel, MembersNo) SELECT (5, 1, N'STAMINA', N'****', 1)
INSERT tblHeistSkills (SkillsID, HeistID, Name, SkillLevel, MembersNo) VALUES (8, 1, N'STRENGTH', N'***', 1)
INSERT tblHeistSkills (SkillsID, HeistID, Name, SkillLevel, MembersNo) VALUES (15, 2, N'COMBAT', N'******', 2)
INSERT tblHeistSkills (SkillsID, HeistID, Name, SkillLevel, MembersNo) VALUES (1002, 1, N'LOCK PICKING', N'***', 1)
SET IDENTITY_INSERT dbo.tblHeistSkills OFF
GO
SET IDENTITY_INSERT dbo.tblMember ON 

INSERT [dbo].[tblMember] (MemberID, Name, Email, Sex, Status, Active, ActiveInHeist) SELECT (4, N'berlin', N'berlin@ag04.com', N'M', N'AVAILABLE', 1, 1)
INSERT tblMember (MemberID, Name, Email, Sex, Status, Active, ActiveInHeist) VALUES (1006, N'tokio', N'tokio@ag04.com', N'M', N'RETIRED', 1, 1)
INSERT tblMember (MemberID, Name, Email, Sex, Status, Active, ActiveInHeist) VALUES (2006, N'oslo', N'oslo@ag04.com', N'M', N'AVAILABLE', 1, 1)
INSERT tblMember (MemberID, Name, Email, Sex, Status, Active, ActiveInHeist) VALUES (2007, N'nairobi', N'nairobi@ag04.com', N'F', N'AVAILABLE', 1, 1)
INSERT tblMember (MemberID, Name, Email, Sex, Status, Active, ActiveInHeist) VALUES (2009, N'Denver', N'denver@ag04.com', N'M', N'AVAILABLE', 1, 1)
INSERT tblMember (MemberID, Name, Email, Sex, Status, Active, ActiveInHeist) VALUES (2010, N'Moscow', N'moscow@ag04', N'F', N'AVAILABLE', 1, NULL)
SET IDENTITY_INSERT dbo.tblMember OFF
GO
SET IDENTITY_INSERT dbo.tblMemberSkills ON 

INSERT [dbo].[tblMemberSkills] (SkillID, MemberID, Name, SkillLevel) SELECT (2, 4, N'DRIVING', N'**********')
INSERT tblMemberSkills (SkillID, MemberID, Name, SkillLevel) VALUES (3, 4, N'LOCK PICKING', N'*****')
INSERT tblMemberSkills (SkillID, MemberID, Name, SkillLevel) VALUES (17, 4, N'COMBAT', N'*******')
INSERT tblMemberSkills (SkillID, MemberID, Name, SkillLevel) VALUES (18, 4, N'STRENGTH', N'*****')
INSERT tblMemberSkills (SkillID, MemberID, Name, SkillLevel) VALUES (19, 4, N'MONEY LAUNDERING', N'****')
INSERT tblMemberSkills (SkillID, MemberID, Name, SkillLevel) VALUES (20, 4, N'STAMINA', N'*******')
INSERT tblMemberSkills (SkillID, MemberID, Name, SkillLevel) VALUES (1002, 1006, N'COMBAT', N'******')
INSERT tblMemberSkills (SkillID, MemberID, Name, SkillLevel) VALUES (2002, 1006, N'STRENGTH', N'*****')
INSERT tblMemberSkills (SkillID, MemberID, Name, SkillLevel) VALUES (2003, 1006, N'STAMINA', N'******')
INSERT tblMemberSkills (SkillID, MemberID, Name, SkillLevel) VALUES (2004, 1006, N'DRIVING', N'******')
INSERT tblMemberSkills (SkillID, MemberID, Name, SkillLevel) VALUES (2005, 1006, N'LOCK PICKING', N'*****')
INSERT tblMemberSkills (SkillID, MemberID, Name, SkillLevel) VALUES (2006, 1006, N'MONEY LAUNDERING', N'********')
INSERT tblMemberSkills (SkillID, MemberID, Name, SkillLevel) VALUES (2007, 2007, N'COMBAT', N'*****')
INSERT tblMemberSkills (SkillID, MemberID, Name, SkillLevel) VALUES (2008, 2007, N'STRENGTH', N'*******')
INSERT tblMemberSkills (SkillID, MemberID, Name, SkillLevel) VALUES (2009, 2007, N'STAMINA', N'********')
INSERT tblMemberSkills (SkillID, MemberID, Name, SkillLevel) VALUES (2010, 2007, N'DRIVING', N'****')
INSERT tblMemberSkills (SkillID, MemberID, Name, SkillLevel) VALUES (2011, 2007, N'LOCK PICKING', N'*******')
INSERT tblMemberSkills (SkillID, MemberID, Name, SkillLevel) VALUES (2012, 2007, N'CAR BOOSTING', N'****')
INSERT tblMemberSkills (SkillID, MemberID, Name, SkillLevel) VALUES (2013, 2007, N'MONEY LAUNDERING', N'*******')
INSERT tblMemberSkills (SkillID, MemberID, Name, SkillLevel) VALUES (2014, 2006, N'COMBAT', N'**********')
INSERT tblMemberSkills (SkillID, MemberID, Name, SkillLevel) VALUES (2015, 2006, N'STRENGTH', N'********')
INSERT tblMemberSkills (SkillID, MemberID, Name, SkillLevel) VALUES (2016, 2006, N'STAMINA', N'**********')
INSERT tblMemberSkills (SkillID, MemberID, Name, SkillLevel) VALUES (2017, 2006, N'DRIVING', N'********')
INSERT tblMemberSkills (SkillID, MemberID, Name, SkillLevel) VALUES (2018, 2006, N'LOCK PICKING', N'*********')
INSERT tblMemberSkills (SkillID, MemberID, Name, SkillLevel) VALUES (2019, 2009, N'COMBAT', N'********')
INSERT tblMemberSkills (SkillID, MemberID, Name, SkillLevel) VALUES (2020, 2009, N'STRENGTH', N'*********')
INSERT tblMemberSkills (SkillID, MemberID, Name, SkillLevel) VALUES (2021, 2009, N'STAMINA', N'*********')
INSERT tblMemberSkills (SkillID, MemberID, Name, SkillLevel) VALUES (2022, 2009, N'DRIVING', N'********')
SET IDENTITY_INSERT dbo.tblMemberSkills OFF
GO
ALTER TABLE dbo.tblHeistMembers  WITH CHECK ADD  CONSTRAINT FK_tblHeistMembers_tblHeist FOREIGN KEY(HeistID)
REFERENCES tblHeist (HeistID);
 
ALTER TABLE dbo.tblHeistMembers CHECK CONSTRAINT [FK_tblHeistMembers_tblHeist];
 
ALTER TABLE dbo.tblHeistMembers  WITH CHECK ADD  CONSTRAINT FK_tblHeistMembers_tblMember FOREIGN KEY(MemberID)
REFERENCES tblMember (MemberID);
 
ALTER TABLE dbo.tblHeistMembers CHECK CONSTRAINT [FK_tblHeistMembers_tblMember];
 
ALTER TABLE dbo.tblHeistSkills  WITH CHECK ADD  CONSTRAINT FK_tblHeistSkills_tblHeist FOREIGN KEY(HeistID)
REFERENCES tblHeist (HeistID);
 
ALTER TABLE dbo.tblHeistSkills CHECK CONSTRAINT [FK_tblHeistSkills_tblHeist];
 
ALTER TABLE dbo.tblMemberSkills  WITH CHECK ADD  CONSTRAINT FK_tblMemberSkills_tblMember FOREIGN KEY(MemberID)
REFERENCES tblMember (MemberID);
 
ALTER TABLE dbo.tblMemberSkills CHECK CONSTRAINT [FK_tblMemberSkills_tblMember];
 
USE master;
 
ALTER DATABASE [Ag04] SET  READ_WRITE 
 
