

use NORTHWIND

select * from dbo.region

select * from dbo.Territories

select Country, COUNT(0) N from dbo.Customers a
group by Country
order by Country

select a.*
	 , (select count(0) from dbo.Orders b
		where a.CustomerID=b.CustomerID) NOrders
from dbo.Customers a 
where 1=1
order by CustomerID

select * from dbo.Customers a
where UPPER(a.country) like UPPER('%France%')

select * from dbo.Orders a
where a.CustomerID = 'ANATR'




select * from dbo.webTracker

/*
delete dbo.webTracker
*/