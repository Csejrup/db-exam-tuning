-- Query 1: Retrieve all products in the 'Electronics' category
EXPLAIN ANALYZE
SELECT *
FROM Products
WHERE Category = 'Electronics';

-- Query 2: Calculate total sales by product
EXPLAIN ANALYZE
SELECT p.Name, SUM(od.Quantity * od.Price) AS TotalSales
FROM OrderDetails od
         JOIN Products p ON od.ProductID = p.ProductID
GROUP BY p.Name
ORDER BY TotalSales DESC;

-- Query 3: Retrieve all orders placed by a specific customer
EXPLAIN ANALYZE
SELECT o.OrderID, o.OrderDate, o.Total
FROM Orders o
         JOIN Customers c ON o.CustomerID = c.CustomerID
WHERE c.Name = 'John Doe';

-- Query 4: Retrieve detailed order information
EXPLAIN ANALYZE
SELECT o.OrderID, o.OrderDate, c.Name AS Customer, p.Name AS Product, od.Quantity, od.Price
FROM Orders o
         JOIN Customers c ON o.CustomerID = c.CustomerID
         JOIN OrderDetails od ON o.OrderID = od.OrderID
         JOIN Products p ON od.ProductID = p.ProductID;

-- Query 5: Calculate total spending by customer
EXPLAIN ANALYZE
SELECT c.Name AS Customer, SUM(od.Quantity * od.Price) AS TotalSpent
FROM OrderDetails od
         JOIN Orders o ON od.OrderID = o.OrderID
         JOIN Customers c ON o.CustomerID = c.CustomerID
GROUP BY c.Name
ORDER BY TotalSpent DESC;

-- Query 6: Identify the top 3 most sold products
EXPLAIN ANALYZE
SELECT p.Name AS Product, SUM(od.Quantity) AS TotalQuantity
FROM OrderDetails od
         JOIN Products p ON od.ProductID = p.ProductID
GROUP BY p.Name
ORDER BY TotalQuantity DESC
    LIMIT 3;

-- Query 7: Perform full-text search for products containing 'Laptop'
EXPLAIN ANALYZE
SELECT *
FROM Products
WHERE to_tsvector('english', Name) @@ to_tsquery('Laptop');

-- Query 8: Retrieve the total number of orders per month
EXPLAIN ANALYZE
SELECT DATE_TRUNC('month', OrderDate) AS OrderMonth, COUNT(*) AS TotalOrders
FROM Orders
GROUP BY OrderMonth
ORDER BY OrderMonth;

-- Query 9: Identify customers who have not placed any orders
EXPLAIN ANALYZE
SELECT c.CustomerID, c.Name, c.Email
FROM Customers c
         LEFT JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE o.OrderID IS NULL;

-- Query 10: Retrieve the total revenue generated per product category
EXPLAIN ANALYZE
SELECT p.Category, SUM(od.Quantity * od.Price) AS TotalRevenue
FROM OrderDetails od
         JOIN Products p ON od.ProductID = p.ProductID
GROUP BY p.Category
ORDER BY TotalRevenue DESC;