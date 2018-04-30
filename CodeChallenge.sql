create database MyDb
go

use myDb
go

create schema Sales
go

create table Sales.Products
(
	ID int primary key,
	[Name] nvarchar(40) not null,
	Price money not null,
)
go

create table Sales.Customers
(
	ID int primary key,
	Firstname nvarchar(40) not null,
	Lastname nvarchar(40) not null,
	Cardnumber char(16) null check (len(Cardnumber) = 16)
)
go

create table Sales.Orders
(
	ID int primary key,
	ProductID int foreign key references Sales.Products (ID),
	CustomerID int foreign key references Sales.Customers (ID)
)
go

insert into Sales.Products (ID, [Name], Price)
values
(1, N'iPhone', $200),
(2, N'Cardboard_Box', $1),
(3, N'Sandwich', $5)

insert into Sales.Customers (ID, Firstname, Lastname, Cardnumber)
values
(1, 'Tina', 'Smith', '1234123412341234'),
(2, 'John', 'Doe', '4321432143214321'),
(3, 'John', 'Dear', '1111222233334444')
go

insert into Sales.Orders (ID, ProductID, CustomerID)
values
(1, 1, 1),
(2, 3, 1),
(3, 2, 2)
go

select *
from Sales.Orders
where CustomerID = 1

select sum(Price)
from Sales.Products as p
inner join Sales.Orders as o
on o.ProductID = 1
go

update Sales.Products
set Price = $250
where [Name] = 'iPhone'
go