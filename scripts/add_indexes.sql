-- Add index on the Products Category column
CREATE INDEX idx_products_category ON Products(Category);

-- Add index on the Orders OrderDate column
CREATE INDEX idx_orders_orderdate ON Orders(OrderDate);

-- Add a composite index for OrderDetails (OrderID, ProductID)
CREATE INDEX idx_orderdetails_order_product ON OrderDetails(OrderID, ProductID);

-- Add index for full-text search on Products Name
CREATE INDEX idx_products_name ON Products USING gin(to_tsvector('english', Name));

-- Add index on OrderDetails for frequently accessed columns: ProductID, Quantity, Price
CREATE INDEX idx_orderdetails_product_quantity_price ON OrderDetails(ProductID, Quantity, Price);

-- Add a covering index for Orders to improve customer-specific queries
CREATE INDEX idx_orders_customer ON Orders(CustomerID) INCLUDE (OrderID, OrderDate, Total);

-- Add index for Customers' Name to speed up specific customer queries
CREATE INDEX idx_customers_name ON Customers(Name);

-- Add a composite index for faster joins between OrderDetails and Products
CREATE INDEX idx_orderdetails_products ON OrderDetails(ProductID) INCLUDE (OrderID, Quantity, Price);

-- Add index to improve performance for revenue calculations by product category
CREATE INDEX idx_products_category_revenue ON Products(Category) INCLUDE (Price);
