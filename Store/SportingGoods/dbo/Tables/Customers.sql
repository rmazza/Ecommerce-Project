CREATE TABLE [dbo].[Customers] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]     NVARCHAR (100) NULL,
    [LastName]      NVARCHAR (100) NULL,
    [MiddleInitial] NVARCHAR (1)   NULL,
    [Email]         NVARCHAR (200) NOT NULL,
    [UserID]        INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [fk_UserCustomer] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
);




