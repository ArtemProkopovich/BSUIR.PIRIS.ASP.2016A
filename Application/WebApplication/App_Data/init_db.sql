IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Account_PlanOfAccounts]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Account] DROP CONSTRAINT [FK_Account_PlanOfAccounts]
;

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

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Credit_Client]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Credit] DROP CONSTRAINT [FK_Credit_Client]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Credit_PlantOfCredits]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Credit] DROP CONSTRAINT [FK_Credit_PlantOfCredits]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Credit_Account_Account]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Credit_Account] DROP CONSTRAINT [FK_Credit_Account_Account]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Credit_Account_Credit]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Credit_Account] DROP CONSTRAINT [FK_Credit_Account_Credit]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_CreditCard_Credit]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [CreditCard] DROP CONSTRAINT [FK_CreditCard_Credit]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Deposit_Client]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Deposit] DROP CONSTRAINT [FK_Deposit_Client]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Deposit_PlanOfDeposits]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Deposit] DROP CONSTRAINT [FK_Deposit_PlanOfDeposits]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Deposit_Account_Account]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Deposit_Account] DROP CONSTRAINT [FK_Deposit_Account_Account]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Deposit_Account_Deposit]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Deposit_Account] DROP CONSTRAINT [FK_Deposit_Account_Deposit]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_PlanOfAccount_PlanOfCredit_PlanOfAccounts]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [PlanOfAccount_PlanOfCredit] DROP CONSTRAINT [FK_PlanOfAccount_PlanOfCredit_PlanOfAccounts]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_PlanOfAccount_PlanOfCredit_PlantOfCredits]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [PlanOfAccount_PlanOfCredit] DROP CONSTRAINT [FK_PlanOfAccount_PlanOfCredit_PlantOfCredits]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_PlanOfAccount_PlanOfDeposit_PlanOfAccounts]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [PlanOfAccount_PlanOfDeposit] DROP CONSTRAINT [FK_PlanOfAccount_PlanOfDeposit_PlanOfAccounts]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_PlanOfAccount_PlanOfDeposit_PlanOfDeposits]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [PlanOfAccount_PlanOfDeposit] DROP CONSTRAINT [FK_PlanOfAccount_PlanOfDeposit_PlanOfDeposits]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Transaction_Account]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Transaction] DROP CONSTRAINT [FK_Transaction_Account]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Transaction_Account_02]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Transaction] DROP CONSTRAINT [FK_Transaction_Account_02]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Account]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Account]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Citizenship]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Citizenship]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Client]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Client]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Credit]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Credit]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Credit_Account]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Credit_Account]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[CreditCard]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [CreditCard]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Deposit]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Deposit]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Deposit_Account]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Deposit_Account]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Disability]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Disability]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[MartialStatus]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [MartialStatus]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[PlanOfAccount]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [PlanOfAccount]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[PlanOfAccount_PlanOfCredit]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [PlanOfAccount_PlanOfCredit]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[PlanOfAccount_PlanOfDeposit]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [PlanOfAccount_PlanOfDeposit]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[PlanOfCredit]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [PlanOfCredit]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[PlanOfDeposit]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [PlanOfDeposit]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Town]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Town]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Transaction]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Transaction]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Procedure1]')) 
DROP PROCEDURE [Procedure1]
;

CREATE TABLE [Account]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[PlanId] int NOT NULL,
	[AccountNumber] varchar(13) NOT NULL,
	[DebitValue] money NOT NULL,
	[CreditValue] money NOT NULL,
	[Balance] money NOT NULL
)
;

CREATE TABLE [Citizenship]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[Country] varchar(50) NOT NULL
)
;

CREATE TABLE [Client]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[Surname] varchar(50) NOT NULL,
	[Name] varchar(50) NOT NULL,
	[FatherName] varchar(50) NOT NULL,
	[BirthDate] date NOT NULL,
	[Male] bit NOT NULL,
	[PassportSeries] varchar(2) NOT NULL,
	[PassportNumber] varchar(7) NOT NULL,
	[IssuedBy] varchar(100) NOT NULL,
	[IssueDate] date NOT NULL,
	[IdentificationNumber] varchar(50) NOT NULL,
	[BirthPlace] varchar(50) NOT NULL,
	[ResidenceActualPlaceId] int NOT NULL,
	[ResidenceActualAddress] varchar(50) NOT NULL,
	[HomePhoneNumber] varchar(50),
	[MobilePhoneNumber] varchar(50),
	[Email] varchar(50),
	[ResidenceAddress] varchar(100) NOT NULL,
	[MaritalStatusId] int NOT NULL,
	[CitezenshipId] int NOT NULL,
	[DisabilityId] int NOT NULL,
	[Pensioner] bit NOT NULL,
	[MonthlyIncome] money
)
;

CREATE TABLE [Credit]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[ClientId] int NOT NULL,
	[PlanId] int NOT NULL,
	[StartDate] date NOT NULL,
	[EndDate] date NOT NULL,
	[Amount] money NOT NULL
)
;

CREATE TABLE [Credit_Account]
(
	[AccountId] int NOT NULL,
	[CreditId] int NOT NULL
)
;

CREATE TABLE [CreditCard]
(
	[CreditId] int NOT NULL,
	[PinCode] varchar(4) NOT NULL
)
;

CREATE TABLE [Deposit]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[ClientId] int NOT NULL,
	[PlanId] int NOT NULL,
	[StartDate] money NOT NULL,
	[EndDate] money NOT NULL,
	[Amount] money NOT NULL
)
;

CREATE TABLE [Deposit_Account]
(
	[AccountId] int NOT NULL,
	[DepositId] int NOT NULL
)
;

CREATE TABLE [Disability]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[Status] varchar(50) NOT NULL
)
;

CREATE TABLE [MartialStatus]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[Status] varchar(50) NOT NULL
)
;

CREATE TABLE [PlanOfAccount]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[AccountNumber] nvarchar(4) NOT NULL,
	[AccountName] nvarchar(50) NOT NULL,
	[AccountType] nvarchar(1) NOT NULL
)
;

CREATE TABLE [PlanOfAccount_PlanOfCredit]
(
	[AccountId] int NOT NULL,
	[CreditId] int NOT NULL
)
;

CREATE TABLE [PlanOfAccount_PlanOfDeposit]
(
	[AccountId] int NOT NULL,
	[DepositId] int NOT NULL
)
;

CREATE TABLE [PlanOfCredit]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[Name] varchar(50) NOT NULL,
	[Period] date NOT NULL,
	[Percent] float NOT NULL,
	[Anuity] bit NOT NULL,
	[MinAmount] money
)
;

CREATE TABLE [PlanOfDeposit]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[Name] varchar(50) NOT NULL,
	[Period] date NOT NULL,
	[Percent] float NOT NULL,
	[Revocable] bit NOT NULL,
	[MinAmount] money
)
;

CREATE TABLE [Town]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[Name] varchar(50) NOT NULL,
	[Country] varchar(50) NOT NULL
)
;

CREATE TABLE [Transaction]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[DebetAccountId] int NOT NULL,
	[CreditAccountId] int NOT NULL,
	[Amount] money NOT NULL,
	[Time] datetime NOT NULL
)
;

ALTER TABLE [Account] 
 ADD CONSTRAINT [PK_Account]
	PRIMARY KEY CLUSTERED ([Id])
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
 ADD CONSTRAINT [UQ_Client_PassportSeries_PassportNumber] UNIQUE NONCLUSTERED ([PassportSeries],[PassportNumber])
;

ALTER TABLE [Client] 
 ADD CONSTRAINT [UQ_Client_IdentificationNumber] UNIQUE NONCLUSTERED ([IdentificationNumber])
;

ALTER TABLE [Credit] 
 ADD CONSTRAINT [PK_Credit]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [Credit_Account] 
 ADD CONSTRAINT [PK_Credit_Account]
	PRIMARY KEY CLUSTERED ([AccountId],[CreditId])
;

ALTER TABLE [CreditCard] 
 ADD CONSTRAINT [PK_CreditCard]
	PRIMARY KEY CLUSTERED ([CreditId])
;

ALTER TABLE [Deposit] 
 ADD CONSTRAINT [PK_Deposit]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [Deposit_Account] 
 ADD CONSTRAINT [PK_Deposit_Account]
	PRIMARY KEY CLUSTERED ([AccountId],[DepositId])
;

ALTER TABLE [Disability] 
 ADD CONSTRAINT [PK_Disability]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [MartialStatus] 
 ADD CONSTRAINT [PK_MartialStatus]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [PlanOfAccount] 
 ADD CONSTRAINT [PK_PlanOfAccount]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [PlanOfAccount_PlanOfCredit] 
 ADD CONSTRAINT [PK_PlanOfAccount_PlanOfCredit]
	PRIMARY KEY CLUSTERED ([AccountId],[CreditId])
;

ALTER TABLE [PlanOfAccount_PlanOfDeposit] 
 ADD CONSTRAINT [PK_PlanOfAccount_PlanOfDeposit]
	PRIMARY KEY CLUSTERED ([AccountId],[DepositId])
;

ALTER TABLE [PlanOfCredit] 
 ADD CONSTRAINT [PK_PlanOfCredit]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [PlanOfDeposit] 
 ADD CONSTRAINT [PK_PlanOfDeposit]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [Town] 
 ADD CONSTRAINT [PK_Town]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [Transaction] 
 ADD CONSTRAINT [PK_Transaction]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [Account] ADD CONSTRAINT [FK_Account_PlanOfAccounts]
	FOREIGN KEY ([PlanId]) REFERENCES [PlanOfAccount] ([Id]) ON DELETE No Action ON UPDATE No Action
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

ALTER TABLE [Credit] ADD CONSTRAINT [FK_Credit_Client]
	FOREIGN KEY ([ClientId]) REFERENCES [Client] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Credit] ADD CONSTRAINT [FK_Credit_PlantOfCredits]
	FOREIGN KEY ([PlanId]) REFERENCES [PlanOfCredit] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Credit_Account] ADD CONSTRAINT [FK_Credit_Account_Account]
	FOREIGN KEY ([AccountId]) REFERENCES [Account] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Credit_Account] ADD CONSTRAINT [FK_Credit_Account_Credit]
	FOREIGN KEY ([CreditId]) REFERENCES [Credit] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [CreditCard] ADD CONSTRAINT [FK_CreditCard_Credit]
	FOREIGN KEY ([CreditId]) REFERENCES [Credit] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Deposit] ADD CONSTRAINT [FK_Deposit_Client]
	FOREIGN KEY ([ClientId]) REFERENCES [Client] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Deposit] ADD CONSTRAINT [FK_Deposit_PlanOfDeposits]
	FOREIGN KEY ([PlanId]) REFERENCES [PlanOfDeposit] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Deposit_Account] ADD CONSTRAINT [FK_Deposit_Account_Account]
	FOREIGN KEY ([AccountId]) REFERENCES [Account] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Deposit_Account] ADD CONSTRAINT [FK_Deposit_Account_Deposit]
	FOREIGN KEY ([DepositId]) REFERENCES [Deposit] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [PlanOfAccount_PlanOfCredit] ADD CONSTRAINT [FK_PlanOfAccount_PlanOfCredit_PlanOfAccounts]
	FOREIGN KEY ([AccountId]) REFERENCES [PlanOfAccount] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [PlanOfAccount_PlanOfCredit] ADD CONSTRAINT [FK_PlanOfAccount_PlanOfCredit_PlantOfCredits]
	FOREIGN KEY ([CreditId]) REFERENCES [PlanOfCredit] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [PlanOfAccount_PlanOfDeposit] ADD CONSTRAINT [FK_PlanOfAccount_PlanOfDeposit_PlanOfAccounts]
	FOREIGN KEY ([AccountId]) REFERENCES [PlanOfAccount] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [PlanOfAccount_PlanOfDeposit] ADD CONSTRAINT [FK_PlanOfAccount_PlanOfDeposit_PlanOfDeposits]
	FOREIGN KEY ([DepositId]) REFERENCES [PlanOfDeposit] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Transaction] ADD CONSTRAINT [FK_Transaction_Account]
	FOREIGN KEY ([DebetAccountId]) REFERENCES [Account] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Transaction] ADD CONSTRAINT [FK_Transaction_Account_02]
	FOREIGN KEY ([CreditAccountId]) REFERENCES [Account] ([Id]) ON DELETE No Action ON UPDATE No Action
;


;
