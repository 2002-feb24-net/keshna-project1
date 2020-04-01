DROP TABLE Customer;
DROP TABLE Product;
DROP TABLE Location;
DROP TABLE Orders;
DROP TABLE Inventory;
DROP TABLE Customerss;
Drop table productss;


GO

CREATE TABLE Customer (
	CustomerID INT NOT NULL PRIMARY KEY IDENTITY (100, 1),
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL
);

CREATE TABLE Product (
	ProductID INT NOT NULL PRIMARY KEY IDENTITY(100, 1),
	Pname NVARCHAR(200) NOT NULL,
	Price MONEY NOT NULL
);

CREATE TABLE Location (
	LocationId INT NOT NULL PRIMARY KEY IDENTITY(100, 1),
	City NVARCHAR(50) NOT NULL
);

CREATE TABLE Inventory (
	InventoryId INT NOT NULL PRIMARY KEY IDENTITY(100, 1),
	LocationID INT NOT NULL FOREIGN KEY REFERENCES Location(LocationId),
	ProductId INT NOT NULL FOREIGN KEY REFERENCES Product(ProductId),
	Quantity INT NOT NULL
);

CREATE TABLE Orders (
	OrderID INT NOT NULL PRIMARY KEY IDENTITY (100, 1),
	CustomerID INT NOT NULL FOREIGN KEY REFERENCES Customer(CustomerID),
	LocationID INT NOT NULL FOREIGN KEY REFERENCES Location(LocationID),
	ProductId INT NOT NULL FOREIGN KEY REFERENCES Product(ProductId),
	Quantity INT NOT NULL,
	OrderTotal MONEY NOT NULL,
	OrderTime DATETIME NOT NULL
);

INSERT INTO Location (City)
Values
('Dallas'),
('Arlington'),
('Passaic');

INSERT INTO Product
Values
('Choclate', 7.99),
('Vanilla', 6.49), --now 7.99
('Pista', 9); --now 7.999

UPDATE Product
SET Price=7.99
WHERE PName='Vanilla';

UPDATE Product
SET Price=7.99
WHERE PName='Pista';


SELECT * FROM Customer;

SELECT * FROM Product;

SELECT * FROM Location;

SELECT * FROM Orders;