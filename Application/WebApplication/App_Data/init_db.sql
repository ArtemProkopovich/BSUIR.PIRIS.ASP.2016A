IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Client_Citizenship]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Client] DROP CONSTRAINT [FK_Client_Citizenship]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Client_Disability]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Client] DROP CONSTRAINT [FK_Client_Disability]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Client_MartialStatus]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Client] DROP CONSTRAINT [FK_Client_MartialStatus]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Client_Town]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Client] DROP CONSTRAINT [FK_Client_Town]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Citizenship]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Citizenship]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Client]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Client]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Disability]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Disability]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[MartialStatus]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [MartialStatus]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Town]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Town]
;

CREATE TABLE [Citizenship]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[Country] nvarchar(50) NOT NULL
)
;

CREATE TABLE [Client]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[Surname] nvarchar(50) NOT NULL,
	[Name] nvarchar(50) NOT NULL,
	[FatherName] nvarchar(50) NOT NULL,
	[BirthDate] date NOT NULL,
	[Male] bit NOT NULL,
	[PassportSeries] nvarchar(2) NOT NULL,
	[PassportNumber] nvarchar(7) NOT NULL,
	[IssuedBy] nvarchar(100) NOT NULL,
	[IssueDate] date NOT NULL,
	[IdentificationNumber] nvarchar(50) NOT NULL,
	[BirthPlace] nvarchar(50) NOT NULL,
	[ResidenceActualPlaceId] int NOT NULL,
	[ResidenceActualAddress] nvarchar(50) NOT NULL,
	[HomePhoneNumber] nvarchar(50),
	[MobilePhoneNumber] nvarchar(50),
	[Email] nvarchar(50),
	[ResidenceAddress] nvarchar(100) NOT NULL,
	[MaritalStatusId] int NOT NULL,
	[CitezenshipId] int NOT NULL,
	[DisabilityId] int NOT NULL,
	[Pensioner] bit NOT NULL,
	[MonthlyIncome] money
)
;

CREATE TABLE [Disability]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[Status] nvarchar(50) NOT NULL
)
;

CREATE TABLE [MartialStatus]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[Status] nvarchar(50) NOT NULL
)
;

CREATE TABLE [Town]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[Name] nvarchar(50) NOT NULL,
	[Country] nvarchar(50) NOT NULL
)
;

ALTER TABLE [Citizenship] 
 ADD CONSTRAINT [PK_Citizenship]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [Client] 
 ADD CONSTRAINT [PK_Client]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [Client] 
 ADD CONSTRAINT [UQ_Client_Surname_Name_FatherName] UNIQUE NONCLUSTERED ([Surname],[Name],[FatherName])
;

ALTER TABLE [Client] 
 ADD CONSTRAINT [UQ_Client_PassportSeries_PassportNumber] UNIQUE NONCLUSTERED ([PassportSeries],[PassportNumber])
;

ALTER TABLE [Client] 
 ADD CONSTRAINT [UQ_Client_IdentificationNumber] UNIQUE NONCLUSTERED ([IdentificationNumber])
;

ALTER TABLE [Disability] 
 ADD CONSTRAINT [PK_Disability]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [MartialStatus] 
 ADD CONSTRAINT [PK_MartialStatus]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [Town] 
 ADD CONSTRAINT [PK_Town]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [Client] ADD CONSTRAINT [FK_Client_Citizenship]
	FOREIGN KEY ([CitezenshipId]) REFERENCES [Citizenship] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Client] ADD CONSTRAINT [FK_Client_Disability]
	FOREIGN KEY ([DisabilityId]) REFERENCES [Disability] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Client] ADD CONSTRAINT [FK_Client_MartialStatus]
	FOREIGN KEY ([MaritalStatusId]) REFERENCES [MartialStatus] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Client] ADD CONSTRAINT [FK_Client_Town]
	FOREIGN KEY ([ResidenceActualPlaceId]) REFERENCES [Town] ([Id]) ON DELETE No Action ON UPDATE No Action
;

INSERT INTO Town (Name,Country)  Values ('Minsk','Belarus'),('Gomel','Belarus'),
	('Grodno','Belarus'),('Vitebsk','Belarus'),('Brest','Belarus'),('Mogilev','Belarus')
INSERT INTO Citizenship (Country) VALUES('Belarus'),('Russia'),('Poland'),
	('Latvia'),('Lituenia'),('Ukraine')
INSERT INTO MartialStatus (Status) VALUES('married'),('not married'),('divorced')
INSERT INTO Disability (Status) VALUES('not disabled'),('disabled'),('partialy disabled')