Create Database BienesRaicesDB
GO

USE [BienesRaicesDB]
GO

CREATE TABLE [dbo].[Person](
	[Rut] VARCHAR(12) PRIMARY KEY NOT NULL,
)
GO

CREATE TABLE [dbo].[Property] (
    [Comunne] VARCHAR(50)NOT NULL,
    [Block] VARCHAR(50)NOT NULL,
    [Site] VARCHAR(50)NOT NULL,
    [Page] VARCHAR(50)NOT NULL,
    [InscriptionNumber] VARCHAR(50)NOT NULL,
    [InscriptionYear] INT NOT NULL,
    [InscriptionDate] DATE NOT NULL,
    PRIMARY KEY ([Comunne],[Block],[Site])
)
GO


CREATE TABLE [dbo].[Multyproperty] (
    [Comunne] VARCHAR(50)NOT NULL,
    [Block] VARCHAR(50)NOT NULL,
    [Site] VARCHAR(50)NOT NULL,
	[Rut] VARCHAR(12)NOT NULL,
	[Percentage] FLOAT NOT NULL,
    [Page] VARCHAR(50)NOT NULL,
    [InscriptionNumber] VARCHAR(50)NOT NULL,
    [InscriptionYear] INT NOT NULL,
    [InscriptionDate] DATE NOT NULL,
	[StartCurrencyYear] INT NOT NULL,
	[EndCurrencyYear] INT,
    PRIMARY KEY ([Comunne],[Block],[Site],[Rut]),
    --FOREIGN KEY ([Rut]) REFERENCES [dbo].[Person]([Rut]),
	--FOREIGN KEY ([Comunne],[Block],[Site],[Page],[InscriptionNumber],[InscriptionYear],[InscriptionDate]) REFERENCES [dbo].[Property]([Comunne],[Block],[Site],[Page],[InscriptionNumber],[InscriptionYear],[InscriptionDate])
)
GO

CREATE TABLE [dbo].[Inscription] (
	[AtentionNumber] INT IDENTITY(1,1) NOT NULL,
	[CNE] VARCHAR(29) CHECK ([CNE] IN ('Compraventa','Regularización de Patrimonio')),
	[Comunne] VARCHAR(50)NOT NULL,
    [Block] VARCHAR(50)NOT NULL,
    [Site] VARCHAR(50)NOT NULL,
	[Page] VARCHAR(50)NOT NULL,
	[InscriptionNumber] VARCHAR(50)NOT NULL,
    [InscriptionDate] DATE NOT NULL,
	CONSTRAINT [PK_Inscription] PRIMARY KEY CLUSTERED(
	[AtentionNumber] ASC)
)
GO

CREATE TABLE [dbo].[Alienator](
	[AtentionNumber] INT NOT NULL,
	[Rut] VARCHAR(12)NOT NULL,
	[Percentage] FLOAT NOT NULL,
	PRIMARY KEY ([AtentionNumber],[Rut]),
	FOREIGN KEY ([Rut]) REFERENCES [dbo].[Person]([Rut]),
	FOREIGN KEY ([AtentionNumber]) REFERENCES [dbo].[Inscription]([AtentionNumber])
)
GO

CREATE TABLE [dbo].[Acquirer](
	[AtentionNumber] INT NOT NULL,
	[Rut] VARCHAR(12)NOT NULL,
	[Percentage] FLOAT NOT NULL,
	PRIMARY KEY ([AtentionNumber],[Rut]),
	FOREIGN KEY ([Rut]) REFERENCES [dbo].[Person]([Rut]),
	FOREIGN KEY ([AtentionNumber]) REFERENCES [dbo].[Inscription]([AtentionNumber])
)
GO

USE [BienesRaicesDB]
GO


INSERT [dbo].[Person] ([Rut]) VALUES (N'10915348-6')
GO
