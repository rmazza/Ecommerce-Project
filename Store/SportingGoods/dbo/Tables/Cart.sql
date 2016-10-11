CREATE TABLE [dbo].[Cart]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ProductName] NVARCHAR(100) NULL, 
    [ProductPrice] DECIMAL NULL, 
    [Qty] INT NULL, 
    [CustomerID] INT NULL
)
