--1.	Employee Address

SELECT TOP(5) e.EmployeeID, e.JobTitle, e.AddressID, a.AddressText 
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
ORDER BY a.AddressID

--2.	Addresses with Towns

SELECT TOP(50) e.FirstName, e.LastName, t.[Name], a.AddressText 
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY e.FirstName ASC, e.LastName

--3.	Sales Employee

SELECT e.EmployeeID, e.FirstName, e.LastName, d.[Name] AS DepartmentName FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE d.[Name] = 'Sales'
ORDER BY e.EmployeeID ASC

--4.	Employee Departments

SELECT TOP(5) e.EmployeeID, e.FirstName, e.Salary, d.[Name] AS DepartmentName FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY d.DepartmentID ASC

--5.	Employees Without Project

SELECT TOP(3) e.EmployeeID, e.FirstName FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID ASC

--6.	Employees Hired After

SELECT e.FirstName, e.LastName, e.HireDate, d.[Name] AS DeptName 
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '1999-1-1' AND (d.[Name] = 'Sales' OR d.[Name] = 'Finance')
ORDER BY e.HireDate ASC

--7.	Employees with Project

SELECT TOP(5) e.EmployeeID, e.FirstName, p.[Name] AS ProjectName
FROM Employees AS e
JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
JOIN Projects AS p ON p.ProjectID = ep.ProjectID
WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL
ORDER BY e.EmployeeID

--8.	Employee 24

SELECT e.EmployeeID, e.FirstName,
CASE
	WHEN YEAR(p.StartDate) <= 2004 THEN p.[Name]
	ELSE NULL
END AS ProjectName
FROM Employees AS e
JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
JOIN Projects AS p ON p.ProjectID = ep.ProjectID
WHERE e.EmployeeID = 24

--9.	Employee Manager

SELECT e.EmployeeID, e.FirstName, m.EmployeeID, m.[FirstName] AS ManagerName
FROM Employees AS e
JOIN Employees AS m ON e.ManagerID = m.EmployeeID
WHERE m.EmployeeID = 3 OR m.EmployeeID = 7
ORDER BY e.EmployeeID ASC

--10.	Employees Summary

SELECT TOP(50) e.EmployeeID, 
	e.FirstName + ' ' + e.LastName AS EmployeeName, 
	m.FirstName + ' ' + m.LastName AS ManagerName, 
	d.[Name] AS DepartmentName
FROM Employees AS e
JOIN Employees AS m ON e.ManagerID = m.EmployeeID
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

--11.	Min Average Salary

SELECT MIN(ads.Salary) AS MinAverageSalary FROM
(
	SELECT AVG(Salary) AS Salary
	FROM Employees
	GROUP BY DepartmentID
) ads

--12.	Highest Peaks in Bulgaria

SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation
FROM Countries AS c
JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
JOIN Mountains AS m ON m.Id = mc.MountainId
JOIN Peaks AS p ON p.MountainId = m.Id
WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

--13.	Count Mountain Ranges

SELECT mc.CountryCode, COUNT(m.Id) FROM Mountains AS m
JOIN MountainsCountries AS mc ON m.Id = mc.MountainId
WHERE mc.CountryCode IN ('BG', 'RU', 'US')
GROUP BY mc.CountryCode

--14.	Countries With or Without Rivers

SELECT TOP(5) c.CountryName, r.RiverName FROM Countries AS c
LEFT JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers r ON r.Id = cr.RiverId
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName ASC

--15.	*Continents and Currencies

