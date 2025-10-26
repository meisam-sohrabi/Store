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
CREATE PROCEDURE GetProductByDateAndTextSearch 
	-- ============================================
	--  Step 2: Parameters Declaration
	-- ============================================
	@startDate DATETIME2 = null ,
	@endDate DATETIME2 = null ,
	@textSearch NVARCHAR(100) = null
AS
BEGIN
	
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
exec GetProductByDateAndTextSearch @startDate = '2021-01-01',@endDate = '2025-12-30' 

