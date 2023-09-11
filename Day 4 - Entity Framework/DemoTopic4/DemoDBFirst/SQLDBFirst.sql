create table Categories(
categoryID int primary key identity(1,1),
categoryName varchar(40)
)
go

create table Products(
productID int primary key identity(1,1),
productName varchar(40),
description varchar(50),
categoryID int references Categories(categoryID) on delete set null
)
go

insert into Categories values ('Appliances')
insert into Categories values ('Material')
go

insert into Products values ('Ricecooker','made by vietname',1)
insert into Products values ('Sand','used for construction',2)
go

select * from Products