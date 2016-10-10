CREATE TABLE [dbo].[Products] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [ProductName]        NCHAR (100)    NULL,
    [ProductPrice]       MONEY          NULL,
    [ProductDescription] NVARCHAR (MAX) NULL,
    [ModelNumber]        NVARCHAR (50)  NULL,
    [Size]               INT            NULL,
    [Position]           NCHAR (10)     NULL,
    [InStock]            BIT            NULL,
    [Sport]              NVARCHAR (50)  NULL,
    [ProductBrand]       NVARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

