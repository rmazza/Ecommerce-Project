CREATE TABLE [dbo].[Image] (
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [ImgLink]   NVARCHAR (1000) NULL,
    [ProductId] INT             NOT NULL,
    CONSTRAINT [pk_Image] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [fk_ImageProduct] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]) ON DELETE CASCADE
);

