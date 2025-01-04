-- Create Products Table
CREATE TABLE Products (
   ProductID SERIAL PRIMARY KEY,
   Name TEXT NOT NULL,
   Category TEXT NOT NULL,
   Price NUMERIC(10, 2) NOT NULL,
   Stock INT NOT NULL
);

-- Create Customers Table
CREATE TABLE Customers (
    CustomerID SERIAL PRIMARY KEY,
    Name TEXT NOT NULL,
    Email TEXT NOT NULL,
    Phone TEXT
);

-- Create Partitioned Orders Table
CREATE TABLE Orders (
   OrderID SERIAL,
   CustomerID INT NOT NULL REFERENCES Customers(CustomerID) ON DELETE CASCADE,
   OrderDate TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
   Total NUMERIC(10, 2) NOT NULL,
   PRIMARY KEY (OrderID, OrderDate)
) PARTITION BY RANGE (OrderDate);

-- Create Partitions for Orders Table
CREATE TABLE Orders_2023 PARTITION OF Orders FOR VALUES FROM ('2023-01-01') TO ('2024-01-01');
CREATE TABLE Orders_2024 PARTITION OF Orders FOR VALUES FROM ('2024-01-01') TO ('2025-01-01');

-- Create OrderDetails Table
CREATE TABLE OrderDetails (
    OrderID INT NOT NULL,
    OrderDate TIMESTAMP NOT NULL,
    ProductID INT NOT NULL REFERENCES Products(ProductID) ON DELETE CASCADE,
    Quantity INT NOT NULL,
    Price NUMERIC(10, 2) NOT NULL,
    PRIMARY KEY (OrderID, OrderDate, ProductID),
    FOREIGN KEY (OrderID, OrderDate) REFERENCES Orders(OrderID, OrderDate) ON DELETE CASCADE
);
