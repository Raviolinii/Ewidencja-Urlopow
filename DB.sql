DROP DATABASE IF EXISTS EwidencjaUrlopow;
GO

CREATE DATABASE EwidencjaUrlopow;
GO

USE [EwidencjaUrlopow]
GO

/****** Object:  Table [dbo].[Urlop]    Script Date: 29.03.2021 13:24:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Urlop]') AND type in (N'U'))
DROP TABLE [dbo].[Urlop]
GO

/****** Object:  Table [dbo].[Urlop]    Script Date: 29.03.2021 13:24:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Urlop](
	[IdUrlopu] [int] IDENTITY(1,1) NOT NULL,
	[DniUrlopu] [int] NULL,
	[DataRozpoczeciaUrlopu] [date] NOT NULL,
	[DataZakonczeniaUrlopu] [date] NOT NULL,
	[OpisUrlopu] [varchar](50) NOT NULL,
	[IdPracownika] [int] NOT NULL,
 CONSTRAINT [PK_Urlop] PRIMARY KEY CLUSTERED
(
	[IdUrlopu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

DROP TABLE IF EXISTS dbo.Pracownik;
GO

CREATE TABLE dbo.Pracownik (
						IdPracownika int IDENTITY(1,1) PRIMARY KEY,
						Imie varchar(15) NOT NULL,
						Nazwisko varchar(20) NOT NULL,
						StanowiskoPracy varchar(40) NOT NULL,
						LataPracy int NOT NULL,
						DostepnyUrlop int NULL
						);
GO


DROP TABLE IF EXISTS dbo.Kalendarz;
GO

CREATE TABLE dbo.Kalendarz (
							DzienRoku date PRIMARY KEY,
							DzienWolny bit NOT NULL
							);
GO

DECLARE @StartDate DATETIME
DECLARE @EndDate DATETIME
SET @StartDate = '01-01-2021'
SET @EndDate = DATEADD(d, 365, @StartDate)

WHILE @StartDate <= @EndDate
      BEGIN
             INSERT INTO [Kalendarz]
             (
                   DzienRoku,
				   DzienWolny
             )
             SELECT
                   @StartDate,
				   IIF ((SELECT DATEPART(dw, @StartDate)) IN (7,1), 1, 0)

             SET @StartDate = DATEADD(dd, 1, @StartDate)
      END;
GO


ALTER TABLE dbo.Urlop
ADD CONSTRAINT FK_Pracownik FOREIGN KEY (IdPracownika)
REFERENCES Pracownik(IdPracownika);
GO