CREATE TABLE [dbo].[CustomerAddress]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED ([Id] ASC), 
    [StreetName] NVARCHAR(MAX) NULL, 
    [City] NVARCHAR(100) NULL, 
    [StateProvince] NVARCHAR(100) NULL, 
    [ZipCode] INT NULL, 
    [CustomerID] INT NOT NULL,
	CONSTRAINT [fk_CustomerAddress] FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customers] ([Id]) ON DELETE CASCADE

)
