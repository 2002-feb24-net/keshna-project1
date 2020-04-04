Drop Table OrderDetails
Drop Table Order_item
Drop Table Orders
Drop Table Inventory
Drop Table Products
Drop Table Customers
Drop Table Stores

select * from customers;
select * from orders;
select * from orderdetails;
select * from inventory;
Create Table Stores (
	LocationID INT NOT NULL Identity Primary Key,
	City NVARCHAR(60) NOT NULL,
	State NVARCHAR(60) NOT NULL,
	)

Create Table Customers (
	CustomerID INT NOT NULL Identity Primary Key,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL
)

Create Table Products (
	ProductID INT NOT NULL Identity Primary Key,
	Pname NVARCHAR(80) NOT NULL,	
	Price Money NOT NULL,
)

Create Table Inventory (
	InventoryID INT NOT NULL Identity Primary Key,
	ProductID INT NOT NULL Foreign Key References Products(ProductID),
	LocationID INT NOT NULL Foreign Key References Stores(LocationID),
	InventoryAmount INT NOT NULL
)

Create Table Orders (
	OrderID INT NOT NULL Identity Primary Key,
	CustomerID INT NOT NULL Foreign Key References Customers(CustomerID),
	LocationID INT NOT NULL Foreign Key References Stores(LocationID),
	Date Datetime2 NOT NULL
)

Create Table OrderDetails (
	OrderDetailID INT NOT NULL Identity Primary Key,
	OrderID INT NOT NULL Foreign Key References Orders(OrderID),
	InventoryID INT NOT NULL Foreign Key References Inventory(InventoryID) ON Delete Cascade
)

Insert Into Stores (City, State) Values ('Arlington', 'Texas')

Insert Into Stores (City, State) Values ('Dallas', 'Texas')

Insert Into Stores (City, State) Values ('Houston', 'Texas')


Insert Into Products (Pname, Price) Values 
	('Choclate', $7.99)

Insert Into Products (Pname, Price) Values 
('Vanilla', $6.49)
	

Insert Into Products (Pname, Price) Values 
('Pista', $9);
Insert Into customers Values 
('kesh', 'r');

Insert Into Inventory (ProductID, LocationID, InventoryAmount) Values 

	(1,1,20)

Insert Into Inventory (ProductID, LocationID, InventoryAmount) Values 
	(2,1,10)

Insert Into Inventory (ProductID, LocationID, InventoryAmount) Values 
	(3,1,15)


	Insert Into Inventory (ProductID, LocationID, InventoryAmount) Values 

	(1,2,20)

Insert Into Inventory (ProductID, LocationID, InventoryAmount) Values 
	(2,2,10)

Insert Into Inventory (ProductID, LocationID, InventoryAmount) Values 
	(3,2,15)


	Insert Into Inventory (ProductID, LocationID, InventoryAmount) Values 

	(1,3,20)

Insert Into Inventory (ProductID, LocationID, InventoryAmount) Values 
	(2,3,10)

Insert Into Inventory (ProductID, LocationID, InventoryAmount) Values 
	(3,3,15)
select o.OrderID, c.FirstName, c.LastName, p.Pname, p.Price, o.LocationID, o.Date from Customers as c
	Inner Join Orders as o ON c.CustomerID = o.CustomerID
	Inner Join OrderDetails as od ON o.OrderID = od.OrderID
	Inner Join Inventory as i ON od.InventoryID = i.InventoryID
	Inner Join Products as p ON i.ProductID = p.ProductID
	where c.FirstName = 'keshna'

select s.City, s.State, o.OrderID, c.FirstName, c.LastName, p.Pname, p.Price, i.InventoryAmount, o.Date from Stores as s
	Inner Join Orders as o ON s.LocationID = o.LocationID
	inner Join Customers as c ON o.CustomerID = c.CustomerID
	Inner Join OrderDetails as od ON o.OrderID = od.OrderID
	Inner Join Inventory as i ON od.InventoryID = i.InventoryID
	Inner Join Products as p ON i.ProductID = p.ProductID


select * from Stores