CREATE PROCEDURE sp_GetProductImages
(
	@prodName NVARCHAR(100)
)
AS
SELECT 
	ImgLink,ProductName, ProductId
FROM
	Image
INNER JOIN
	Products
ON	
	Products.Id = Image.ProductId
WHERE
	ProductName = @prodName