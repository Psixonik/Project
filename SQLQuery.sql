DROP TABLE users;
CREATE TABLE [dbo].[users] (
    [id]    INT           IDENTITY (1, 1) NOT NULL,
    [name]  NVARCHAR (50) NOT NULL,
    [pas]   NVARCHAR (50) NULL,
    [email]   NVARCHAR (50) NULL,
    [correctEmail]   bit NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);