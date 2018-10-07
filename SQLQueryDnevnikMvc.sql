create database eDnevnikMvc

use eDnevnikMvc

----tabela Godine------------

CREATE TABLE Godine (
	[GodinaID] [int] primary key NOT NULL,
	[Opis] nvarchar(10) NOT NULL,
 )
GO

----tabela Ocene-------

CREATE TABLE Ocene (
	[OcenaID] [int] identity primary key NOT NULL,
	[Ocena] int null,
	[OpisOcene] nvarchar(20),
	[TipOcene] nvarchar(20) NOT NULL default 'prosek',
	constraint chk_tip_ocene check( TipOcene in ('prosek','ne_ide_u_prosek','vladanje')))
 
GO

----tabela Odeljenja-----------------

CREATE TABLE Odeljenja(
	[OdeljenjeID] [int] identity primary key NOT NULL,
	[GodinaID] [int] NOT NULL,
	[BrojOdeljenja] [int] NOT NULL,
	[GodinaUpisa] [int] NOT NULL,
	[MatBrOdeljenja] as (SUBSTRING(convert(nvarchar(8),GodinaID),1,1)
	+
	'/'
	+
	SUBSTRING(convert(nvarchar(8),BrojOdeljenja),1,1)
	+
	'/'
	+
	SUBSTRING(convert(nvarchar(8),GodinaUpisa),1,4)),
	[ProfesorID] [int] NOT NULL)
	
GO
----tabela Predmeti------------------

CREATE TABLE [dbo].[Predmeti](
	[PredmetID] [int] identity primary key NOT NULL,
	[NazivPredmeta] [nvarchar](50) NOT NULL,
	[Redosled] [int] NOT NULL,
	[TipOcene] nvarchar(20) not null)

GO

----tabela Profesori------
 
CREATE TABLE Profesori(
	[ProfesorID] [int] primary key identity NOT NULL,
	[Ime] [nvarchar](20) NOT NULL,
	[Prezime] [nvarchar](20) NOT NULL,
	[KorisnickoIme] [nvarchar](10) NOT NULL,
	[Lozinka] [nvarchar](10) NOT NULL,
	[Status] [nvarchar](8) not null default 'profesor',
	constraint chk_status check (Status in('profesor','admin')))
 
 GO

 -----tabela Ucenici-----
 
 CREATE TABLE Ucenici(
	[UcenikID] [int] identity primary key not null,
	[Ime] [nvarchar](50) NOT NULL,
	[Prezime] [nvarchar](50) NOT NULL,
	[DatumRodjenja] [date] NOT NULL,
	[Adresa] [nvarchar](50) NOT NULL,
	[GodinaUpisa] [date] NOT NULL,
	[RedBrUOdeljenju] [int] not null,
	[MatBrOdeljenja] nvarchar(8) null,
	[MatBrUcenika] as (SUBSTRING(MatBrOdeljenja,1,8)
	+
	'/'
	+
	SUBSTRING(convert(nvarchar(15),RedBrUOdeljenju),1,2)),
	[Lozinka] [nvarchar](50) NOT NULL);
	
GO


	


