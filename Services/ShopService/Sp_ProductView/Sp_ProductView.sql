CREATE VIEW ProductView
AS

SELECT
p.Id AS ProductID,
p.Name AS ProductName,
p.description AS ProductDescription,
p.quantity  AS ProductQuantity,
c.Name AS CategoryName,
c.IsActive AS CategoryStatus ,
pb.Name AS ProductBrand ,
pb.Description AS ProductBrandDescription

FROM Products AS p
INNER JOIN Categories AS c ON p.CategoryId = c.id
INNER JOIN ProductBrands AS pb ON p.ProductBrandId = pb.id

 GO

CREATE PROCEDURE GetProductByDateAndTextSearch 
@startDate DATETIME = null ,
@endDate DATETIME = null ,
@textSearch NVARCHAR(100) = null
AS
SET NOCOUNT ON;
SELECT pv.* , i.QuantityChange,i.ChangeDate 
FROM ProductView AS pv
LEFT JOIN productInventories AS i ON pv.ProductID = i.ProductId
WHERE 
(@startDate is null  or i.ChangeDate between @startDate and @endDate) 
and 
(
@textSearch is null  or
(pv.ProductName like '%'+@textSearch+'%'
or pv.ProductDescription like '%'+@textSearch+'%'
or pv.CategoryName like '%'+@textSearch+'%'
or pv.ProductBrand like '%'+@textSearch+'%'
or pv.ProductBrandDescription like '%'+@textSearch+'%'
));

exec GetProductByDateAndTextSearch @textSearch = 'IPhone'

