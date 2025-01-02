-- Insert Products
INSERT INTO Products (Name, Category, Price, Stock) VALUES
                                                        ('Laptop', 'Electronics', 1200.00, 50),
                                                        ('Smartphone', 'Electronics', 800.00, 200),
                                                        ('Table', 'Furniture', 150.00, 20),
                                                        ('Chair', 'Furniture', 85.00, 100),
                                                        ('Headphones', 'Electronics', 150.00, 300);

-- Insert Customers
INSERT INTO Customers (Name, Email, Phone) VALUES
                                               ('John Doe', 'john.doe@example.com', '22334455'),
                                               ('Jane Smith', 'jane.smith@example.com', '12131415'),
                                               ('Bob Johnson', 'bob.johnson@example.com', '23242526');

-- Insert Orders
INSERT INTO Orders (CustomerID, OrderDate, Total) VALUES
                                                      (1, '2024-01-01 10:00:00', 1350.00),
                                                      (2, '2024-01-02 15:30:00', 950.00),
                                                      (1, '2023-12-25 09:00:00', 120.00);

-- Insert OrderDetails
INSERT INTO OrderDetails (OrderID, OrderDate, ProductID, Quantity, Price) VALUES
                                                                              (1, '2024-01-01 10:00:00', 1, 1, 1200.00),
                                                                              (1, '2024-01-01 10:00:00', 5, 1, 150.00),
                                                                              (2, '2024-01-02 15:30:00', 2, 1, 800.00),
                                                                              (2, '2024-01-02 15:30:00', 4, 2, 150.00),
                                                                              (3, '2023-12-25 09:00:00', 3, 1, 120.00);
