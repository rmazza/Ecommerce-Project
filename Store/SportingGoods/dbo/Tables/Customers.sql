CREATE TABLE [dbo].[Customers] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]     NVARCHAR (100) NULL,
    [LastName]      NVARCHAR (100) NULL,
    [MiddleInitial] NVARCHAR (1)   NULL,
    [Email]         NVARCHAR (200) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


