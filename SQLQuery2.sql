
CREATE TABLE [dbo].[users] (
    [id]    INT           IDENTITY (1, 1) NOT NULL,
    [email] NVARCHAR (50) NOT NULL,
    [name]  NVARCHAR (50) NOT NULL,
    [pas]   NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [dbo].[Autoes] (
    [id]         INT           IDENTITY (1, 1) NOT NULL,
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
    [kyzov]     NVARCHAR (50) NOT NULL,
    [colKyzov]  INT           NULL,
    [koleso]    NVARCHAR (50) NOT NULL,
    [colKoleso] INT           NULL,
    [motor]     NVARCHAR (50) NOT NULL,
    [colMotor]  INT           NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [dbo].[Utilits] (
    [id]      INT IDENTITY (1, 1) NOT NULL,
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
