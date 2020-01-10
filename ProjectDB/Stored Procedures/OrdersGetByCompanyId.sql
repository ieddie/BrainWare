CREATE PROCEDURE [dbo].[OrdersGetByCompanyId]
	@companyId int 
AS
BEGIN
	DECLARE @OrderDetails TABLE
	(
	  OrderId int NOT NULL, 
	  Description nvarchar(1000) NOT NULL
	);
	-- in first result set, return information about all orders for a given company Id
	INSERT INTO @OrderDetails
	SELECT 
		o.order_id, o.description 
	FROM company c 
		INNER JOIN [order] o on c.company_id=o.company_id
	WHERE c.company_id=1

	SELECT * from @OrderDetails

	-- in the second result set, return all order products for all orders for this given company
	SELECT 
		op.price, op.order_id, op.product_id, op.quantity, p.name, p.price 
	FROM orderproduct op 
		INNER JOIN product p on op.product_id=p.product_id
		INNER JOIN @OrderDetails od on od.OrderId=op.order_id
END
