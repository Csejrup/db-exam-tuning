-- Add index on the Products Category column
CREATE INDEX idx_products_category ON Products(Category);

-- Add index on the Orders OrderDate column
CREATE INDEX idx_orders_orderdate ON Orders(OrderDate);

-- Add a composite index for OrderDetails (OrderID, ProductID)
CREATE INDEX idx_orderdetails_order_product ON OrderDetails(OrderID, ProductID);

-- Add index for full-text search on Products Name
CREATE INDEX idx_products_name ON Products USING gin(to_tsvector('english', Name));

-- Add index on orderdetails Product Price

CREATE INDEX idx_orderdetails_product_quantity_price ON orderdetails(productid, quantity, price);
