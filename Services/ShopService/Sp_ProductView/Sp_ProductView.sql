	-- ============================================
	--  Step 1: View
	-- ============================================
CREATE VIEW ProductView
AS
	-- ============================================
	--  Step 2: Product,Brand,Category
	-- ============================================
	SELECT
	p.Id [ProductID],
	p.Name [ProductName],
	p.description [ProductDescription],
	p.quantity [ProductQuantity],
	c.Name [CategoryName],
	c.IsActive [CategoryStatus],
	pb.Name [ProductBrand],
	pb.Description [ProductBrandDescription]

FROM Products AS p
INNER JOIN Categories AS c ON p.CategoryId = c.id
INNER JOIN ProductBrands AS pb ON p.ProductBrandId = pb.id
GO


 	-- ============================================
	--  Step 1: Prodcedure
	-- ============================================
ALTER PROCEDURE GetProductByDateAndTextSearch 
	-- ============================================
	--  Step 2: Parameters Declaration
	-- ============================================
	@startDate DATETIME2 = null ,
	@endDate DATETIME2 = null ,
	@textSearch NVARCHAR(100) = null
AS
BEGIN
	


	IF	@startDate IS NULL AND @endDate IS NULL AND @textSearch IS NULL
	BEGIN
		RETURN 
	END
	-- ============================================
	--  Step 3 : Left join using the view
	-- ============================================

	SELECT 
		pv.* , i.QuantityChange,i.ChangeDate 
		FROM ProductView AS pv
		LEFT JOIN productInventories AS i ON pv.ProductID = i.ProductId
	WHERE 
		-- 1. Date Filtering Group
    (    
        @startDate IS NULL OR @endDate	IS NULL  -- If no date is provided, this group is always TRUE
        OR i.ChangeDate BETWEEN @startDate AND @endDate -- Otherwise, filter by date
    ) 
    AND
    -- 2. Text Filtering Group
    (
        @textSearch IS NULL -- If no text is provided, this group is always TRUE
        OR pv.ProductName LIKE '%' + @textSearch + '%'
        OR pv.ProductDescription LIKE '%' + @textSearch + '%'
		OR pv.CategoryName LIKE '%' + @textSearch + '%' 
		OR pv.ProductBrand LIKE '%' + @textSearch + '%'
		OR pv.ProductBrandDescription LIKE '%' + @textSearch + '%'
      
    );
END
exec GetProductByDateAndTextSearch 

-----------------------------------------------------------------------------------------------


GO
CREATE FUNCTION ArabicToPersian(@Name NVARCHAR(50))
RETURNS NVARCHAR(50)
BEGIN

	
	SET @Name = REPLACE(@Name,N'ي',N'ی')
	SET @Name = REPLACE(@Name,N'ك',N'ک')
	RETURN @Name  

END
Go

CREATE PROCEDURE ProductArabicRevision
@start datetime2,
@end   datetime2 
AS
BEGIN
	
		UPDATE P
		SET [P].[Name] = dbo.ArabicToPersian(P.Name)
		,[P].[Description] = dbo.ArabicToPersian(P.Description)
		FROM Products AS P
		WHERE CreateDate BETWEEN @start AND @end
			AND ([P].[Name]!= dbo.ArabicToPersian(P.Name)
			OR [P].[Description] != dbo.ArabicToPersian(P.Description)
				)
END
GO

EXEC .ProductArabicRevision '2012-01-06' , '2025-08-03'
GO