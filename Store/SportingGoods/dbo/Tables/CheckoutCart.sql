CREATE TABLE [dbo].[CheckoutCart]
(
	[Id] INT  IDENTITY (1,1) NOT NULL PRIMARY KEY CLUSTERED, 
    [Qty] INT NOT NULL, 
    [SalesOrderID] INT NOT NULL, 
	[ProductID] INT NOT NULL,
    CONSTRAINT [fk_CartProduct] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]) ON DELETE CASCADE
)
