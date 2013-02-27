DROP TABLE StaffLogin
DROP TABLE Store
DROP TABLE DeliveryDrivers
DROP TABLE OrderItems
DROP TABLE Orders
DROP TABLE Delivery
DROP TABLE ExtraToppings
DROP TABLE MenuItems
DROP TABLE CustomerDetails
DROP TABLE AddressDetails
DROP TABLE Category

PRINT 'Create Table Category'
CREATE TABLE Category
(
		CategoryID int identity(1,1),
		CategoryName nvarchar(255) NOT NULL,
		Primary Key(CategoryID)
)
go

PRINT 'Create Table MenuItems'
CREATE TABLE MenuItems
(
		MenuItemsID int identity(1,1),
		FKCategoryID int,
		ProductName nvarchar(255) NOT NULL,
		ProductDescription text not null,
		PortionSize nvarchar (45) not null,
		Price money not null, 
		Primary Key(MenuItemsID),
		FOREIGN KEY (FKCategoryID) REFERENCES Category (CategoryID)
)
go

PRINT 'Create Table ExtraToppings'
CREATE TABLE ExtraToppings
(
		ExtraToppingsID int identity(1,1),
		FKMenuItemsID int,
		TopType nvarchar(255) NOT NULL,
		Quantity nvarchar (45) not null,
		Primary Key(ExtraToppingsID),
		FOREIGN KEY (FKMenuItemsID) REFERENCES MenuItems(MenuItemsID)
)
go

PRINT 'Create Table AddressDetails'
CREATE TABLE AddressDetails
(
		AddressID int identity(1,1),
		Address1 nvarchar(255) NOT NULL,
		Address2 nvarchar(255) NOT NULL,
		Address3 nvarchar(255) NOT NULL,
		County nvarchar (45) not null,
		Country nvarchar(255) NOT NULL,
		Primary Key(AddressID)
)
go

PRINT 'Create Table CustomerDetails'
CREATE TABLE CustomerDetails
(
		CustomerID int identity(1,1),
		FKAddress int,
		Title nvarchar(255),
		Firstname nvarchar(255) NOT NULL,
		Surname nvarchar(255) NOT NULL,
		ContactPhone nvarchar (45) not null,
		Email nvarchar(255),
		LoginPassword nvarchar(30) NOT NULL,
		Primary Key(CustomerID),
		FOREIGN KEY (FKAddress) REFERENCES AddressDetails(AddressID)
)
go

PRINT 'Create Table Delivery'
CREATE TABLE Delivery
(
		DeliveryID int identity(1,1),
		FKAddress int,
		Firstname nvarchar(255) NOT NULL,
		Surname nvarchar(255) NOT NULL,
		ContactPhone nvarchar (45) not null,
		Primary Key(DeliveryID),
		FOREIGN KEY (FKAddress) REFERENCES AddressDetails(AddressID)
)
go

PRINT 'Create Table DeliveryDrivers'
CREATE TABLE DeliveryDrivers
(
		DriverID int identity(1,1),
		FKDeliveryID int,
		Firstname nvarchar(255) NOT NULL,
		Surname nvarchar(255) NOT NULL,
		ContactPhone nvarchar (45) not null,
		Primary Key(DriverID),
		FOREIGN KEY (FKDeliveryID) REFERENCES Delivery(DeliveryID)
)
go

PRINT 'Create Table Store'
CREATE TABLE Store
(
		StoreID int identity(1,1),
		FKAddress int,
		StoreName nvarchar(255) NOT NULL,
		Phone nvarchar(20) NOT NULL,
		Email nvarchar (255) not null,
		Primary Key(StoreID),
		FOREIGN KEY (FKAddress) REFERENCES AddressDetails(AddressID)
)
go

PRINT 'Create Table StaffLogin'
CREATE TABLE StaffLogin
(
		StaffLoginID int identity(1,1),
		FKStore int,
		Firstname nvarchar(255) NOT NULL,
		Surname nvarchar(255) NOT NULL,
		Username nvarchar(255) NOT NULL,
		Staffpassword nvarchar(40) NOT NULL,
		Accesslevel nvarchar (20) not null,
		Primary Key(StaffLoginID),
		FOREIGN KEY (FKStore) REFERENCES Store(StoreID)
)
go

PRINT 'Create Table Orders'
CREATE TABLE Orders
(
		OrdersID int identity(1,1),
		FKMenuCustomerID int,
		FKDeliveryID int,
		DateOrder datetime NOT NULL,
		Primary Key(OrdersID),
		FOREIGN KEY (FKMenuCustomerID) REFERENCES CustomerDetails(CustomerID),
		FOREIGN KEY (FKDeliveryID) REFERENCES Delivery(DeliveryID)
)
go

PRINT 'Create Table OrderItems'
CREATE TABLE OrderItems
(
		OrderItemsID int identity(1,1),
		FKMenuItemsID int,
		FKOrdersID int,
		ProductName nvarchar(255) NOT NULL,
		ProductDescription text not null,
		PortionSize nvarchar (45) not null,
		Price money not null,
		Primary Key(OrderItemsID),
		FOREIGN KEY (FKMenuItemsID) REFERENCES MenuItems(MenuItemsID),
		FOREIGN KEY (FKOrdersID) REFERENCES Orders(OrdersID)
)
go