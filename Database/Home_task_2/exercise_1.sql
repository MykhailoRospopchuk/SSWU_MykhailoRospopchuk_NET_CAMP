--23. ������� ���������� ��� ���������� � ������: 
--ϲ� �볺���, ����� ����������, ����� ����, ������� ������� �� ����.
SELECT Client.CName, 
	Orders.OrdersID, 
	Car.Car_model, 
	Car.Price_per_day 
FROM Orders
	INNER JOIN Client ON Client.ClientID = Orders.ClientID
	INNER JOIN Car ON Car.CarID = Orders.CarID;

--24. ������� ���������� ��� ���� ��������� ������ �볺��� � ������: 
--����� �볺���, ���� ������� ������� �� ����� ���� � 1, ���� ������� ������� �� ����� ���� � 2.
SELECT O1.ClientID,
	O1.Start_date AS StartDate_1, 
	O1.CarID AS CarId_1, 
	O2.Start_date AS StartDate_2, 
	O2.CarID AS CarId_2
FROM Orders O1 
	INNER JOIN Orders O2 ON O1.ClientID = O2.ClientID
WHERE O1.OrdersID <> O2.OrdersID
	AND O1.Start_date < O2.Start_date;

--25. ������� ���������� ��� ���������� � ������: 
--����� �볺���, ϲ� �볺���, ����������� ���� �� ���� ���� ����������.
SELECT c.ClientID AS 'Customer Number',
	c.CName AS 'Customer Name',
    MAX(car.Price_per_day) AS 'Maximum Price per Day'
FROM Client c
	INNER JOIN Orders o ON c.ClientID = o.ClientID
	INNER JOIN Car car ON o.CarID = car.CarID
GROUP BY c.ClientID, c.CName;

--26. ������� ���������� � ������: 
--����� ����, ����� �볺���, ������� ��������� �� �� ������ � �볺���
SELECT Orders.CarID, 
	Orders.ClientID, 
	COUNT(ClientID) AS 'Number of orders'
FROM Orders
GROUP BY Orders.CarID, Orders.ClientID
ORDER BY Orders.CarID;

--27. ��� ����� ���� ���������� ������� ��������� � ��� ����, 
--�� �������, ���� ������� ����� ��� ������� 2. 
--������� � ������: ���� ������� �������, ������� ���������
SELECT Orders.Start_date, 
	COUNT(Orders.Start_date) 'Number of Orders'
FROM Orders
GROUP BY Orders.Start_date
HAVING COUNT(Orders.Start_date) >= 2;

--28. ��� ����� ������ ������ �������� ����� �� �� ������ �� �������, 
--���� �� ������� ����� �� 5000 ��.
SELECT Orders.CarID, Car.Car_model, SUM(Orders.End_km - Orders.Start_km) 'Mileage of Venicle'
FROM Orders
INNER JOIN CAR ON CAR.CarID = Orders.CarID
GROUP BY Orders.CarID, 
	Car.Car_model
HAVING SUM(Orders.End_km - Orders.Start_km) > 5000

--29. ������� ���������� ��� ���������� � ������: 
--����� ����������, ����� �� ϲ� �볺���, ���� ������� ����������, ���� ����������; 
--�������, ���� ���� ����� �� 2000.
SELECT DISTINCT Orders.OrdersID,
	Orders.ClientID,
	Client.CName,
	Orders.Start_date,
	SUM(Damage.Price + Jobs.Cost) DamageCost
FROM Orders
INNER JOIN Client ON Orders.ClientID = Client.ClientID
INNER JOIN Damage ON Orders.OrdersID = Damage.OrdersID
INNER JOIN Jobs ON Damage.DamageID = Jobs.DamageID
GROUP BY Orders.OrdersID,
	Orders.ClientID,
	Client.CName,
	Orders.Start_date
HAVING(SUM(Damage.Price + Jobs.Cost)) > 2000;

--30. ������� ���������� ��� ���������� �볺��� � ���� � ������: 
--ϲ� �볺���, ����� ����������, ������� ���� ����������, ������� ������� ����������; 
--�������, ���� ���� ����� �� 1000.
SELECT c.CName AS 'Customer Name',
       o.OrdersID AS 'Order Number',
       DATEDIFF(day, o.Start_date, o.End_date) AS 'Number of Days',
       (DATEDIFF(day, o.Start_date, o.End_date) * (1 - c.Discount) * car.Price_per_day) AS 'Total Cost'
FROM Orders o
JOIN Client c ON o.ClientID = c.ClientID
JOIN Car car ON o.CarID = car.CarID
WHERE c.Address LIKE '%Kyiv%'
	AND (DATEDIFF(day, o.Start_date, o.End_date) * (1 - c.Discount) * car.Price_per_day) > 1000;

--31.������� �볺��� � ���������� �������.
SELECT *
FROM Client
WHERE Client.Discount = (SELECT MIN(Client.Discount) FROM Client);

--32. ������� ���������� ��� ����������, �� ������� ��� ���������.
SELECT Orders.*
FROM Orders
LEFT JOIN Damage ON Damage.OrdersID = Orders.OrdersID
WHERE Damage.OrdersID IS NULL;