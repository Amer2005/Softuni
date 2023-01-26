--1.	One-To-One Relationship

CREATE DATABASE [CustomDB]
USE CUSTOMDB

CREATE TABLE Persons(
	PersonID INT NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	Salary DECIMAL NOT NULL,
	PassportID INT
)

CREATE TABLE Passports(
	PassportID INT NOT NULL,
	PassportNumber CHAR(8) NOT NULL
)

ALTER TABLE Persons
ADD CONSTRAINT PK_Person PRIMARY KEY (PersonID);

ALTER TABLE Passports
ADD CONSTRAINT PK_Passport PRIMARY KEY (PassportID);

ALTER TABLE Persons
ADD FOREIGN KEY (PassportID) REFERENCES Passports(PassportID);

INSERT INTO Passports (PassportID, PassportNumber)
VALUES (101, 'N34FG21B'),
       (102, 'K65LO4R7'),
       (103, 'ZE657QP2')

INSERT INTO Persons (PersonID, FirstName, Salary, PassportID)
VALUES (1, 'Roberto', 43300.00, 102),
       (2, 'Tom', 56100.00, 103),
       (3, 'Yana', 60200.00, 101)

--2.	One-To-Many Relationship

CREATE TABLE [Manufacturers] (
    [ManufacturerID] INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) NOT NULL,
    [EstablishedOn] DATETIME2 NOT NULL
);

CREATE TABLE [Models] (
    [ModelID] INT PRIMARY KEY IDENTITY(101,1),
    [Name] VARCHAR(50) NOT NULL,
    [ManufacturerID] INT FOREIGN KEY REFERENCES [Manufacturers]([ManufacturerID]) NOT NULL
);

INSERT INTO Manufacturers ([Name], [EstablishedOn])
VALUES ('BMW', '07/03/1916'), 
		('Tesla', '01/01/2003'), 
		('Lada', '01/05/1966');

INSERT INTO [Models] ([Name], [ManufacturerID])
VALUES ('X1', 1), 
		('i6', 1), 
		('Model S', 2), 
		('Model X', 2), 
		('Model 3', 2), 
		('Nova', 3);

SELECT * FROM Manufacturers

--3.	Many-To-Many Relationship

CREATE TABLE Students(
	StudentID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Exams(
	ExamID INT PRIMARY KEY IDENTITY(101, 1),
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE StudentsExams(
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID) NOT NULL,
	ExamID INT FOREIGN KEY REFERENCES Exams(ExamID) NOT NULL
	PRIMARY KEY(StudentID, ExamID)
)

INSERT INTO Students([Name])
VALUES ('Mila'),
		('Toni'),
		('Ron')

INSERT INTO Exams([Name])
VALUES ('SpringMVC'),
		('Neo4j'),
		('Oracle 11g')

INSERT INTO StudentsExams([StudentID], [ExamID])
VALUES (1, 101),
		(1, 102),
		(2, 101),
		(3, 103),
		(2, 102),
		(2, 103)

--4.	Self-Referencing 

CREATE TABLE Teachers (
    TeacherID INT PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    ManagerID INT,
    FOREIGN KEY (ManagerID) REFERENCES Teachers(TeacherID)
);

--5.	Online Store Database

CREATE TABLE Cities(
	CityID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL
)

CREATE TABLE Customers(
	CustomerID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL,
	Birthday DATE NOT NULL,
	CityID INT NOT NULL,

	FOREIGN KEY (CityID) REFERENCES Cities(CityID)
)

CREATE TABLE Orders(
	OrderID INT PRIMARY KEY IDENTITY,
	CustomerID INT NOT NULL,

	FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
)

CREATE TABLE ItemTypes(
	ItemTypeID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL
)

CREATE TABLE Items(
	ItemID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL,
	ItemTypeID INT NOT NULL,

	FOREIGN KEY (ItemTypeID) REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE OrderItems(
	OrderID INT NOT NULL,
	ItemID INT NOT NULL,
	FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
	FOREIGN KEY (ItemID) REFERENCES Items(ItemID),
	PRIMARY KEY (OrderID, ItemID)
)

--6.	University Database

CREATE TABLE Subjects(
	SubjectID INT PRIMARY KEY IDENTITY,
	SubjectName NVARCHAR(100) NOT NULL
)

CREATE TABLE Majors(
	MajorID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL
)

CREATE TABLE Students(
	StudentID INT PRIMARY KEY IDENTITY,
	StudentNumber INT NOT NULL,
	StudentName NVARCHAR(100) NOT NULL,
	MajorID INT NOT NULL,

	FOREIGN KEY (MajorID) REFERENCES Majors(MajorID)
)

CREATE TABLE Payments(
	PaymentID INT PRIMARY KEY IDENTITY,
	PaymentDate DATETIME2 NOT NULL,
	PaymentAmount DECIMAL NOT NULL,
	StudentID INT NOT NULL,

	FOREIGN KEY (StudentID) REFERENCES Students(StudentID)
)

CREATE TABLE Agenda(
	StudentID INT NOT NULL,
	SubjectID INT NOT NULL,

	FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
	FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID),
	PRIMARY KEY (StudentID, SubjectID)

)

--9.	*Peaks in Rila

USE Geography

SELECT m.MountainRange, p.PeakName, p.Elevation FROM Mountains as m 
JOIN Peaks as p ON m.Id = p.MountainId
WHERE m.MountainRange = 'Rila'
ORDER BY p.Elevation DESC
