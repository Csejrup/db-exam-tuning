-- Remove index on the Products Category column
DROP INDEX IF EXISTS idx_products_category;

-- Remove index on the Orders OrderDate column
DROP INDEX IF EXISTS idx_orders_orderdate;

-- Remove composite index for OrderDetails (OrderID, ProductID)
DROP INDEX IF EXISTS idx_orderdetails_order_product;

-- Remove index for full-text search on Products Name
DROP INDEX IF EXISTS idx_products_name;
