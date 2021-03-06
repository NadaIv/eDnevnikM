USE [master]
GO
/****** Object:  Database [eDnevnikMvc]    Script Date: 22.10.2018. 2:00:46 ******/
CREATE DATABASE [eDnevnikMvc]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'eDnevnikMvc', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSSQL\MSSQL\DATA\eDnevnikMvc.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'eDnevnikMvc_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSSQL\MSSQL\DATA\eDnevnikMvc_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [eDnevnikMvc] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [eDnevnikMvc].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [eDnevnikMvc] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [eDnevnikMvc] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [eDnevnikMvc] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [eDnevnikMvc] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [eDnevnikMvc] SET ARITHABORT OFF 
GO
ALTER DATABASE [eDnevnikMvc] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [eDnevnikMvc] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [eDnevnikMvc] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [eDnevnikMvc] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [eDnevnikMvc] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [eDnevnikMvc] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [eDnevnikMvc] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [eDnevnikMvc] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [eDnevnikMvc] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [eDnevnikMvc] SET  ENABLE_BROKER 
GO
ALTER DATABASE [eDnevnikMvc] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [eDnevnikMvc] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [eDnevnikMvc] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [eDnevnikMvc] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [eDnevnikMvc] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [eDnevnikMvc] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [eDnevnikMvc] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [eDnevnikMvc] SET RECOVERY FULL 
GO
ALTER DATABASE [eDnevnikMvc] SET  MULTI_USER 
GO
ALTER DATABASE [eDnevnikMvc] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [eDnevnikMvc] SET DB_CHAINING OFF 
GO
ALTER DATABASE [eDnevnikMvc] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [eDnevnikMvc] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [eDnevnikMvc] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'eDnevnikMvc', N'ON'
GO
ALTER DATABASE [eDnevnikMvc] SET QUERY_STORE = OFF
GO
USE [eDnevnikMvc]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [eDnevnikMvc]
GO
/****** Object:  Table [dbo].[Godine]    Script Date: 22.10.2018. 2:00:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Godine](
	[GodinaID] [int] IDENTITY(1,1) NOT NULL,
	[Opis] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__Godine__83A986ECE4938074] PRIMARY KEY CLUSTERED 
(
	[GodinaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ocene]    Script Date: 22.10.2018. 2:00:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ocene](
	[OcenaID] [int] IDENTITY(1,1) NOT NULL,
	[Ocena] [int] NULL,
	[OpisOcene] [nvarchar](20) NULL,
	[TipOcene] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OcenaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ocenjivanje]    Script Date: 22.10.2018. 2:00:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ocenjivanje](
	[OcenjivanjeID] [int] NOT NULL,
	[PredmetID] [int] NOT NULL,
	[UcenikID] [int] NOT NULL,
	[OcenaID] [int] NOT NULL,
	[DatumOcenj] [date] NOT NULL,
	[Komentar] [nvarchar](50) NULL,
 CONSTRAINT [PK_Ocenjivanje] PRIMARY KEY CLUSTERED 
(
	[OcenjivanjeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Odeljenja]    Script Date: 22.10.2018. 2:00:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Odeljenja](
	[OdeljenjeID] [int] IDENTITY(1,1) NOT NULL,
	[GodinaID] [int] NOT NULL,
	[BrojOdeljenja] [int] NOT NULL,
	[GodinaUpisa] [int] NOT NULL,
	[MatBrOdeljenja]  AS ((((substring(CONVERT([nvarchar](8),[GodinaID]),(1),(1))+'/')+substring(CONVERT([nvarchar](8),[BrojOdeljenja]),(1),(1)))+'/')+substring(CONVERT([nvarchar](8),[GodinaUpisa]),(1),(4))),
	[ProfesorID] [int] NULL,
 CONSTRAINT [PK_Odeljenja] PRIMARY KEY CLUSTERED 
(
	[OdeljenjeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Predmeti]    Script Date: 22.10.2018. 2:00:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Predmeti](
	[PredmetID] [int] IDENTITY(1,1) NOT NULL,
	[NazivPredmeta] [nvarchar](50) NOT NULL,
	[Redosled] [int] NOT NULL,
	[TipOcene] [nvarchar](20) NOT NULL,
	[ProfesorID] [int] NOT NULL,
	[GodinaID] [int] NOT NULL,
 CONSTRAINT [PK__Predmeti__8EE1D60559B36103] PRIMARY KEY CLUSTERED 
(
	[PredmetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prof_Predm]    Script Date: 22.10.2018. 2:00:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prof_Predm](
	[ProfPredmID] [int] NOT NULL,
	[ProfesorID] [int] NOT NULL,
	[PredmetID] [int] NOT NULL,
 CONSTRAINT [PK_Prof_Predm] PRIMARY KEY CLUSTERED 
(
	[ProfPredmID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profesori]    Script Date: 22.10.2018. 2:00:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesori](
	[ProfesorID] [int] IDENTITY(1,1) NOT NULL,
	[Ime] [nvarchar](20) NOT NULL,
	[Prezime] [nvarchar](20) NOT NULL,
	[KorisnickoIme] [nvarchar](10) NOT NULL,
	[Lozinka] [nvarchar](10) NOT NULL,
	[Status] [nvarchar](8) NOT NULL,
 CONSTRAINT [PK__Profesor__4DF3F02837860D4C] PRIMARY KEY CLUSTERED 
(
	[ProfesorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staresine]    Script Date: 22.10.2018. 2:00:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staresine](
	[StaresinaID] [int] IDENTITY(1,1) NOT NULL,
	[ProfesorID] [int] NOT NULL,
	[OdeljenjeID] [int] NOT NULL,
 CONSTRAINT [PK_Staresina] PRIMARY KEY CLUSTERED 
(
	[StaresinaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ucenici]    Script Date: 22.10.2018. 2:00:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ucenici](
	[UcenikID] [int] IDENTITY(1,1) NOT NULL,
	[OdeljenjeID] [int] NOT NULL,
	[Ime] [nvarchar](50) NOT NULL,
	[Prezime] [nvarchar](50) NOT NULL,
	[DatumRodjenja] [datetime] NOT NULL,
	[Adresa] [nvarchar](50) NOT NULL,
	[GodinaUpisa] [int] NOT NULL,
	[RedBrUOdeljenju] [int] NOT NULL,
	[Lozinka] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__Ucenici__7982582A8804A9DA] PRIMARY KEY CLUSTERED 
(
	[UcenikID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Ocenjivanje] ADD  CONSTRAINT [DF_Ocenjivanje_DatumOcenj]  DEFAULT (getdate()) FOR [DatumOcenj]
GO
ALTER TABLE [dbo].[Profesori] ADD  CONSTRAINT [DF__Profesori__Statu__4D94879B]  DEFAULT ('profesor') FOR [Status]
GO
ALTER TABLE [dbo].[Ocenjivanje]  WITH CHECK ADD  CONSTRAINT [FK_Ocenjivanje_Ocene] FOREIGN KEY([OcenaID])
REFERENCES [dbo].[Ocene] ([OcenaID])
GO
ALTER TABLE [dbo].[Ocenjivanje] CHECK CONSTRAINT [FK_Ocenjivanje_Ocene]
GO
ALTER TABLE [dbo].[Ocenjivanje]  WITH CHECK ADD  CONSTRAINT [FK_Ocenjivanje_Predmeti] FOREIGN KEY([PredmetID])
REFERENCES [dbo].[Predmeti] ([PredmetID])
GO
ALTER TABLE [dbo].[Ocenjivanje] CHECK CONSTRAINT [FK_Ocenjivanje_Predmeti]
GO
ALTER TABLE [dbo].[Ocenjivanje]  WITH CHECK ADD  CONSTRAINT [FK_Ocenjivanje_Ucenici] FOREIGN KEY([UcenikID])
REFERENCES [dbo].[Ucenici] ([UcenikID])
GO
ALTER TABLE [dbo].[Ocenjivanje] CHECK CONSTRAINT [FK_Ocenjivanje_Ucenici]
GO
ALTER TABLE [dbo].[Odeljenja]  WITH CHECK ADD  CONSTRAINT [FK_Odeljenja_Godine] FOREIGN KEY([GodinaID])
REFERENCES [dbo].[Godine] ([GodinaID])
GO
ALTER TABLE [dbo].[Odeljenja] CHECK CONSTRAINT [FK_Odeljenja_Godine]
GO
ALTER TABLE [dbo].[Predmeti]  WITH CHECK ADD  CONSTRAINT [FK_Predmeti_Godine] FOREIGN KEY([GodinaID])
REFERENCES [dbo].[Godine] ([GodinaID])
GO
ALTER TABLE [dbo].[Predmeti] CHECK CONSTRAINT [FK_Predmeti_Godine]
GO
ALTER TABLE [dbo].[Prof_Predm]  WITH CHECK ADD  CONSTRAINT [FK_Prof_Predm_Predmeti] FOREIGN KEY([PredmetID])
REFERENCES [dbo].[Predmeti] ([PredmetID])
GO
ALTER TABLE [dbo].[Prof_Predm] CHECK CONSTRAINT [FK_Prof_Predm_Predmeti]
GO
ALTER TABLE [dbo].[Prof_Predm]  WITH CHECK ADD  CONSTRAINT [FK_Prof_Predm_Profesori] FOREIGN KEY([ProfesorID])
REFERENCES [dbo].[Profesori] ([ProfesorID])
GO
ALTER TABLE [dbo].[Prof_Predm] CHECK CONSTRAINT [FK_Prof_Predm_Profesori]
GO
ALTER TABLE [dbo].[Staresine]  WITH CHECK ADD  CONSTRAINT [FK_Staresina_Odeljenja] FOREIGN KEY([OdeljenjeID])
REFERENCES [dbo].[Odeljenja] ([OdeljenjeID])
GO
ALTER TABLE [dbo].[Staresine] CHECK CONSTRAINT [FK_Staresina_Odeljenja]
GO
ALTER TABLE [dbo].[Staresine]  WITH CHECK ADD  CONSTRAINT [FK_Staresina_Profesori] FOREIGN KEY([ProfesorID])
REFERENCES [dbo].[Profesori] ([ProfesorID])
GO
ALTER TABLE [dbo].[Staresine] CHECK CONSTRAINT [FK_Staresina_Profesori]
GO
ALTER TABLE [dbo].[Profesori]  WITH CHECK ADD  CONSTRAINT [chk_status] CHECK  (([Status]='admin' OR [Status]='profesor'))
GO
ALTER TABLE [dbo].[Profesori] CHECK CONSTRAINT [chk_status]
GO
USE [master]
GO
ALTER DATABASE [eDnevnikMvc] SET  READ_WRITE 
GO
