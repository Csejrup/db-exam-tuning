-- Remove index on the Products Category column
DROP INDEX IF EXISTS idx_products_category;

-- Remove index on the Orders OrderDate column
DROP INDEX IF EXISTS idx_orders_orderdate;

-- Remove composite index for OrderDetails (OrderID, ProductID)
DROP INDEX IF EXISTS idx_orderdetails_order_product;

-- Remove index for full-text search on Products Name
DROP INDEX IF EXISTS idx_products_name;

-- Remove index on OrderDetails for frequently accessed columns: ProductID, Quantity, Price
DROP INDEX IF EXISTS idx_orderdetails_product_quantity_price;

-- Remove a covering index for Orders to improve customer-specific queries
DROP INDEX IF EXISTS idx_orders_customer;

-- Remove an index for Customers' Name to speed up specific customer queries
DROP INDEX IF EXISTS idx_customers_name;

-- Remove a composite index for faster joins between OrderDetails and Products
DROP INDEX IF EXISTS idx_orderdetails_products;

-- Remove an index to improve performance for revenue calculations by product category
DROP INDEX IF EXISTS idx_products_category_revenue;