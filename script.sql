USE [eDnevnikMvc]
GO
/****** Object:  Table [dbo].[Godine]    Script Date: 7.10.2018. 22:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Godine](
	[GodinaID] [int] NOT NULL,
	[Opis] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[GodinaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ocene]    Script Date: 7.10.2018. 22:10:16 ******/
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
/****** Object:  Table [dbo].[Ocenjivanje]    Script Date: 7.10.2018. 22:10:16 ******/
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
/****** Object:  Table [dbo].[Odeljenja]    Script Date: 7.10.2018. 22:10:16 ******/
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
 CONSTRAINT [PK_Odeljenja] PRIMARY KEY CLUSTERED 
(
	[OdeljenjeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Predmeti]    Script Date: 7.10.2018. 22:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Predmeti](
	[PredmetID] [int] IDENTITY(1,1) NOT NULL,
	[NazivPredmeta] [nvarchar](50) NOT NULL,
	[Redosled] [int] NOT NULL,
	[TipOcene] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PredmetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prof_Predm]    Script Date: 7.10.2018. 22:10:17 ******/
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
/****** Object:  Table [dbo].[Profesori]    Script Date: 7.10.2018. 22:10:17 ******/
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
/****** Object:  Table [dbo].[Staresine]    Script Date: 7.10.2018. 22:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staresine](
	[StaresinaID] [int] NOT NULL,
	[ProfesorID] [int] NOT NULL,
	[OdeljenjeID] [int] NOT NULL,
 CONSTRAINT [PK_Staresina] PRIMARY KEY CLUSTERED 
(
	[StaresinaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ucenici]    Script Date: 7.10.2018. 22:10:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ucenici](
	[UcenikID] [int] IDENTITY(1,1) NOT NULL,
	[OdeljenjeID] [int] NOT NULL,
	[Ime] [nvarchar](50) NOT NULL,
	[Prezime] [nvarchar](50) NOT NULL,
	[DatumRodjenja] [date] NOT NULL,
	[Adresa] [nvarchar](50) NOT NULL,
	[GodinaUpisa] [date] NOT NULL,
	[RedBrUOdeljenju] [int] NOT NULL,
	[MatBrOdeljenja] [nvarchar](8) NULL,
	[MatBrUcenika]  AS ((substring([MatBrOdeljenja],(1),(8))+'/')+substring(CONVERT([nvarchar](15),[RedBrUOdeljenju]),(1),(2))),
	[Lozinka] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__Ucenici__7982582A8804A9DA] PRIMARY KEY CLUSTERED 
(
	[UcenikID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Ocene] ADD  DEFAULT ('prosek') FOR [TipOcene]
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
ALTER TABLE [dbo].[Ucenici]  WITH CHECK ADD  CONSTRAINT [FK_Ucenici_Odeljenja] FOREIGN KEY([OdeljenjeID])
REFERENCES [dbo].[Odeljenja] ([OdeljenjeID])
GO
ALTER TABLE [dbo].[Ucenici] CHECK CONSTRAINT [FK_Ucenici_Odeljenja]
GO
ALTER TABLE [dbo].[Ocene]  WITH CHECK ADD  CONSTRAINT [chk_tip_ocene] CHECK  (([TipOcene]='vladanje' OR [TipOcene]='ne_ide_u_prosek' OR [TipOcene]='prosek'))
GO
ALTER TABLE [dbo].[Ocene] CHECK CONSTRAINT [chk_tip_ocene]
GO
ALTER TABLE [dbo].[Profesori]  WITH CHECK ADD  CONSTRAINT [chk_status] CHECK  (([Status]='admin' OR [Status]='profesor'))
GO
ALTER TABLE [dbo].[Profesori] CHECK CONSTRAINT [chk_status]
GO
