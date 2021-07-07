drop table Bazaars;
drop table Credits;
drop table Details;
drop table Moneys;
drop table NameOfMashins;
drop table TypeMashins;
drop table users;
drop table Utilits;
drop table Workers;
drop table Zakazs;

CREATE TABLE [dbo].[Autoes] (
    [id]         INT           IDENTITY (1, 1) NOT NULL,
    [userId]     INT           NOT NULL,
    [nameAuto]   NVARCHAR (50) NOT NULL,
    [services]   INT           NULL,
    [maxContent] INT           NULL,
    [content]    INT           NULL,
    [broken]     INT           NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [dbo].[Bazaars] (
    [id]    INT           IDENTITY (1, 1) NOT NULL,
    [name]  NVARCHAR (50) NOT NULL,
    [type]  NVARCHAR (50) NOT NULL,
    [money] INT           NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [dbo].[Credits] (
    [id]   INT IDENTITY (1, 1) NOT NULL,
    [cash] INT NULL,
    [day]  INT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [dbo].[Details] (
    [id]     INT           IDENTITY (1, 1) NOT NULL,
    [userId] INT           NOT NULL,
    [name]   NVARCHAR (50) NOT NULL,
    [type]   NVARCHAR (50) NOT NULL,
    [col]    INT           NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [dbo].[Moneys] (
    [id]           INT IDENTITY (1, 1) NOT NULL,
    [userid]       INT NOT NULL,
    [cash]         INT NULL,
    [credit]       INT NULL,
    [dayForCredit] INT NULL,
    CONSTRAINT [PK_dbo.Moneys] PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [dbo].[NameOfMashins] (
    [id]       INT           IDENTITY (1, 1) NOT NULL,
    [nameAuto] NVARCHAR (50) NOT NULL,
    [cost]     INT           NULL,
    [services] INT           NULL,
    [content]  INT           NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [dbo].[Orders] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Product]  NVARCHAR (MAX) NULL,
    [Customer] NVARCHAR (MAX) NULL,
    [Quantity] INT            NOT NULL,
    CONSTRAINT [PK_dbo.Orders] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[TypeMashins] (
    [id]        INT           IDENTITY (1, 1) NOT NULL,
    [nameAuto]  NVARCHAR (50) NOT NULL,
    [kyzov]     NVARCHAR (50) NOT NULL,
    [colKyzov]  INT           NULL,
    [koleso]    NVARCHAR (50) NOT NULL,
    [colKoleso] INT           NULL,
    [motor]     NVARCHAR (50) NOT NULL,
    [colMotor]  INT           NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [dbo].[users] (
    [id]    INT           IDENTITY (1, 1) NOT NULL,
    [name]  NVARCHAR (50) NOT NULL,
    [pas]   NVARCHAR (50) NULL,
    [email]   NVARCHAR (50) NULL,
    [correctEmail]   bit NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [dbo].[Utilits] (
    [id]      INT IDENTITY (1, 1) NOT NULL,
    [userId]  INT NULL,
    [gas]     INT NULL,
    [water]   INT NULL,
    [electro] INT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [dbo].[Workers] (
    [id]          INT IDENTITY (1, 1) NOT NULL,
    [userId]      INT NOT NULL,
    [colWorkers]  INT NULL,
    [zp]          INT NULL,
    [al]          INT NULL,
    [dayOfStrike] INT NULL,
    [strik]       BIT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [dbo].[Zakazs] (
    [id]    INT           IDENTITY (1, 1) NOT NULL,
    [name]  NVARCHAR (50) NOT NULL,
    [col]   INT           NULL,
    [money] INT           NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

SET IDENTITY_INSERT [dbo].[Bazaars] ON
INSERT INTO [dbo].[Bazaars] ([id], [name], [type], [money]) VALUES (1, N'кузов', N'Кузов для МАЗ', 10)
INSERT INTO [dbo].[Bazaars] ([id], [name], [type], [money]) VALUES (2, N'кузов', N'Кузов для КрАЗ', 20)
INSERT INTO [dbo].[Bazaars] ([id], [name], [type], [money]) VALUES (3, N'кузов', N'Кузов для БТР', 30)
INSERT INTO [dbo].[Bazaars] ([id], [name], [type], [money]) VALUES (4, N'колесо', N'260', 10)
INSERT INTO [dbo].[Bazaars] ([id], [name], [type], [money]) VALUES (5, N'колесо', N'320', 20)
INSERT INTO [dbo].[Bazaars] ([id], [name], [type], [money]) VALUES (6, N'мотор', N'Мотор для МАЗа', 10)
INSERT INTO [dbo].[Bazaars] ([id], [name], [type], [money]) VALUES (7, N'мотор', N'Мотор для КрАЗа', 20)
INSERT INTO [dbo].[Bazaars] ([id], [name], [type], [money]) VALUES (8, N'мотор', N'Мотор для ЗИЛа', 30)
SET IDENTITY_INSERT [dbo].[Bazaars] OFF

SET IDENTITY_INSERT [dbo].[NameOfMashins] ON
INSERT INTO [dbo].[NameOfMashins] ([id], [nameAuto], [cost], [services], [content]) VALUES (4, N'ЗИЛ', 1000, 100, 1000)
INSERT INTO [dbo].[NameOfMashins] ([id], [nameAuto], [cost], [services], [content]) VALUES (5, N'МАЗ', 5000, 150, 1500)
INSERT INTO [dbo].[NameOfMashins] ([id], [nameAuto], [cost], [services], [content]) VALUES (6, N'КрАЗ', 25000, 300, 3000)
SET IDENTITY_INSERT [dbo].[NameOfMashins] OFF

SET IDENTITY_INSERT [dbo].[TypeMashins] ON
INSERT INTO [dbo].[TypeMashins] ([id], [nameAuto], [kyzov], [colKyzov], [koleso], [colKoleso], [motor], [colMotor]) VALUES (6, N'КрАЗ', N'Кузов для КрАЗ', 1, N'320', 4, N'Мотор для КрАЗа', 1)
INSERT INTO [dbo].[TypeMashins] ([id], [nameAuto], [kyzov], [colKyzov], [koleso], [colKoleso], [motor], [colMotor]) VALUES (7, N'МАЗ', N'Кузов для МАЗ', 1, N'260', 4, N'Мотор для МАЗа', 1)
INSERT INTO [dbo].[TypeMashins] ([id], [nameAuto], [kyzov], [colKyzov], [koleso], [colKoleso], [motor], [colMotor]) VALUES (8, N'ЗИЛ', N'Кузов для ЗИЛ', 1, N'260', 4, N'Мотор для ЗИЛа', 1)
INSERT INTO [dbo].[TypeMashins] ([id], [nameAuto], [kyzov], [colKyzov], [koleso], [colKoleso], [motor], [colMotor]) VALUES (9, N'БТР', N'Кузов для БТР', 1, N'320', 8, N'Мотор для КрАЗа', 2)
SET IDENTITY_INSERT [dbo].[TypeMashins] OFF

SET IDENTITY_INSERT [dbo].[Credits] ON
INSERT INTO [dbo].[Credits] ([id], [cash], [day]) VALUES (4, 1000, 5)
INSERT INTO [dbo].[Credits] ([id], [cash], [day]) VALUES (5, 1500, 10)
INSERT INTO [dbo].[Credits] ([id], [cash], [day]) VALUES (6, 2000, 15)
SET IDENTITY_INSERT [dbo].[Credits] OFF

