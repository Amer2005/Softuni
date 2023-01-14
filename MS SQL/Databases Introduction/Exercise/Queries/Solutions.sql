--1. Create Database
CREATE DATABASE Minions

--2. Create Tables
CREATE TABLE [Minions](
	Id INT NOT NULL,
	[Name] VARCHAR(100),
	[Age] INT
)

CREATE TABLE [Towns](
	[Id] INT NOT NULL,
	[Name] VARCHAR(100)
)

ALTER TABLE Towns
ADD PRIMARY KEY (Id);

ALTER TABLE Minions
ADD PRIMARY KEY (Id);

--3. Alter Minions Table

ALTER TABLE Minions
ADD TownId INT;

ALTER TABLE Minions
ADD FOREIGN KEY (TownId) REFERENCES Towns(Id);

--4. Insert Records in Both Tables

INSERT INTO Towns
Values	(1, 'Sofia'),
		(2, 'Plovdiv'),
		(3, 'Varna');

INSERT INTO Minions
VALUES	(1 , 'Kevin', 22, 1),
		(2 , 'Bob', 15, 3),
		(3 , 'Steward', NULL, 2);

--5. Truncate Table Minions

DELETE FROM Minions
DELETE FROM Towns

--6. Drop All Tables

DROP TABLE Minions
DROP TABLE Towns

--7. Create Table People

CREATE TABLE People (
Id INT IDENTITY(1,1) PRIMARY KEY,
[Name] NVARCHAR(200) NOT NULL,
Picture VARBINARY(MAX) NULL,
Height FLOAT(2) NULL,
[Weight] FLOAT(2) NULL,
Gender CHAR(1) NOT NULL,
Birthdate DATE NOT NULL,
Biography NVARCHAR(MAX) NULL
);

INSERT INTO People (Name, Picture, Height, Weight, Gender, Birthdate, Biography)
VALUES
('John Doe', null, 1.83, 78, 'm', '1990-01-01', 'A man of mystery'),
('Jane Smith', null, 1.65, 56, 'f', '1995-03-08', 'A woman of many talents'),
('Bob Johnson', null, 1.91, 92, 'm', '1985-07-12', 'A man of many accomplishments'),
('Emily Davis', null, 1.68, 60, 'f', '1992-11-24', 'A woman of great intelligence'),
('Michael Brown', null, 1.75, 72, 'm', '1988-05-16', 'A man of humble beginnings');

--8. Create Table Users

CREATE TABLE Users (
Id BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY,
Username VARCHAR(30) NOT NULL,
[Password] VARCHAR(26) NOT NULL,
ProfilePicture VARBINARY(MAX) NULL,
LastLoginTime DATETIME2,
IsDeleted BIT
);

INSERT INTO Users (Username, [Password], ProfilePicture, LastLoginTime, IsDeleted)
VALUES
('John Doe', 'asdasd2', NULL, NULL, 0),
('John Doe1', 'asdasd25', NULL, NULL, 1),
('John Doe2', 'asdasd24', NULL, NULL, 0),
('John Doe3', 'asdasd21', NULL, NULL, 1),
('John Doe4', 'asdasd23', NULL, NULL, 0);

--9. Change Primary Key

ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07CF812DA9;

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY (Id, Username);

--10. Add Check Constraint
ALTER TABLE Users
ADD CHECK (LEN([Password])>=5);

--11. Set Default Value of a Field

ALTER TABLE Users
ADD CONSTRAINT df_LastLoginTime
DEFAULT GETDATE() FOR [LastLoginTime];

--12. Set Unique Field

ALTER TABLE Users
DROP CONSTRAINT PK_Users;

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY (Id);

ALTER TABLE Users
ADD CHECK (LEN([Username])>=3);

--13. Movies Database

CREATE DATABASE [Movies]

CREATE TABLE Directors (
Id INT NOT NULL IDENTITY PRIMARY KEY,
DirectorName NVARCHAR(30),
Notes TEXT
);

CREATE TABLE Genres  (
Id INT NOT NULL IDENTITY PRIMARY KEY,
GenreName NVARCHAR(30),
Notes TEXT
);

CREATE TABLE Categories (
Id INT NOT NULL IDENTITY PRIMARY KEY,
CategoryName NVARCHAR(30),
Notes TEXT
);

CREATE TABLE Movies (
Id INT NOT NULL IDENTITY PRIMARY KEY,
Title NVARCHAR(30),
DirectorId INT NOT NULL,
CopyrightYear INT,
[Length] FLOAT,
[GenreId] INT NOT NULL,
[CategoryId] INT NOT NULL,
[Rating] FLOAT,
Notes TEXT,
FOREIGN KEY ([DirectorId]) REFERENCES Directors(Id),
FOREIGN KEY ([GenreId]) REFERENCES Genres(Id),
FOREIGN KEY ([CategoryId]) REFERENCES Categories(Id)
)


INSERT INTO Directors (DirectorName, Notes) VALUES
    ('Christopher Nolan', 'The Dark Knight trilogy'),
    ('Martin Scorsese', 'Goodfellas, The Departed'),
    ('Steven Spielberg', 'Jaws, E.T.'),
    ('James Cameron', 'Avatar, Titanic'),
    ('Quentin Tarantino', 'Pulp Fiction, Kill Bill');

INSERT INTO Genres (GenreName, Notes) VALUES
    ('Drama', 'A serious and meaningful film'),
    ('Action', 'A film with exciting action scenes'),
    ('Comedy', 'A film that is meant to make the audience laugh'),
    ('Horror', 'A film that is meant to scare the audience'),
    ('Thriller', 'A film that is meant to make the audience feel suspense or tension');

INSERT INTO Categories (CategoryName, Notes) VALUES
    ('Blockbuster', 'A film that is expected to be a commercial success'),
    ('Indie', 'A film that is produced independently'),
    ('Foreign', 'A film that is not produced in the country'),
    ('Documentary', 'A film that is factual, non-fictional'),
    ('Animated', 'A film that is animated');

INSERT INTO Movies (Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes) VALUES
    ('Inception', 1, 2010, 148, 2, 1, 8.8, 'A mind-bending thriller'),
    ('The Departed', 2, 2006, 151, 1, 1, 8.5, 'A crime-drama film'),
    ('Jurassic Park', 3, 1993, 127, 2, 1, 8.1, 'A science-fiction film'),
    ('Titanic', 4, 1997, 194, 1, 1, 7.8, 'A romantic-disaster film'),
	('Pulp Fiction', 5, 1994, 154, 1, 1, 8.9, 'A crime film with non-linear narrative structure');

--14. Car Rental Database

CREATE DATABASE CarRental

CREATE TABLE [Categories] (
    Id INT PRIMARY KEY,
    CategoryName VARCHAR(255) NOT NULL,
    DailyRate DECIMAL(10,2) NOT NULL,
    WeeklyRate DECIMAL(10,2) NOT NULL,
    MonthlyRate DECIMAL(10,2) NOT NULL,
    WeekendRate DECIMAL(10,2) NOT NULL
);

CREATE TABLE Cars (
    Id INT PRIMARY KEY,
    PlateNumber VARCHAR(255) NOT NULL,
    Manufacturer VARCHAR(255) NOT NULL,
    Model VARCHAR(255) NOT NULL,
    CarYear INT NOT NULL,
    CategoryId INT NOT NULL,
    Doors INT NOT NULL,
    Picture VARCHAR(255),
    Condition VARCHAR(255) NOT NULL,
    Available BIT NOT NULL,
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);

CREATE TABLE Employees (
    Id INT PRIMARY KEY,
    FirstName VARCHAR(255) NOT NULL,
    LastName VARCHAR(255) NOT NULL,
    Title VARCHAR(255) NOT NULL,
    Notes TEXT
);

CREATE TABLE Customers (
    Id INT PRIMARY KEY,
    DriverLicenceNumber VARCHAR(255) NOT NULL,
    FullName VARCHAR(255) NOT NULL,
    Address VARCHAR(255) NOT NULL,
    City VARCHAR(255) NOT NULL,
    ZIPCode VARCHAR(255) NOT NULL,
    Notes TEXT
);

CREATE TABLE RentalOrders (
    Id INT PRIMARY KEY,
    EmployeeId INT NOT NULL,
    CustomerId INT NOT NULL,
    CarId INT NOT NULL,
    TankLevel NVARCHAR(25) NOT NULL,
    KilometrageStart INT NOT NULL,
    KilometrageEnd INT NOT NULL,
    TotalKilometrage INT NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    TotalDays INT NOT NULL,
    RateApplied DECIMAL(10,2) NOT NULL,
    TaxRate DECIMAL(10,2) NOT NULL,
    OrderStatus VARCHAR(255) NOT NULL,
    Notes TEXT,
    FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
    FOREIGN KEY (CustomerId) REFERENCES Customers(Id),
    FOREIGN KEY (CarId) REFERENCES Cars(Id)
);

INSERT INTO Categories (Id, CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate) VALUES
    (1, 'Economy', 50, 250, 600, 80),
    (2, 'Luxury', 150, 750, 2000, 200),
    (3, 'SUV', 100, 500, 1200, 120);

INSERT INTO Cars (Id, PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available) VALUES
    (1, 'ABC123', 'Toyota', 'Camry', 2015, 1, 4, '', 'Good', 1),
    (2, 'DEF456', 'Mercedes','S-Class', 2020, 2, 4, '', 'Excellent', 1),
(3, 'GHI789', 'Chevrolet', 'Suburban', 2019, 3, 4, '', 'Good', 0);

INSERT INTO Employees (Id, FirstName, LastName, Title, Notes) VALUES
(1, 'John', 'Smith', 'Manager', 'Manager of the rental department'),
(2, 'Jane', 'Doe', 'Clerk', 'Clerk in charge of rentals'),
(3, 'Bob', 'Johnson', 'Mechanic', 'In charge of vehicle maintenance');

INSERT INTO Customers (Id, DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes) VALUES
(1, '123456789', 'John Smith', '123 Main St', 'New York', '12345', 'Regular customer'),
(2, '987654321', 'Jane Doe', '456 Park Ave', 'Los Angeles', '67890', 'First time rental'),
(3, '121212121', 'Bob Johnson', '789 Elm St', 'Chicago', '13579', 'Corporate account');

INSERT INTO RentalOrders (Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes) VALUES
(1, 1, 1, 1, 'Full', 0, 100, 100, '2022-01-01', '2022-01-03', 3, 150, 0.1, 'Completed', 'Returned on time'),
(2, 2, 2, 2, 'Full', 0, 200, 200, '2022-02-01', '2022-02-05', 5, 750, 0.1, 'Completed', 'Returned with a scratch'),
(3, 3, 3, 3, 'Full', 0, 0, 0, '2022-03-01', '2022-03-01', 1, 100, 0.1, 'Pending', 'Not returned yet');

--15. Hotel Database

CREATE DATABASE Hotel

CREATE TABLE Employees (
    Id INT PRIMARY KEY,
    FirstName VARCHAR(255) NOT NULL,
    LastName VARCHAR(255) NOT NULL,
    Title VARCHAR(255) NOT NULL,
    Notes TEXT
);

CREATE TABLE Customers (
    AccountNumber INT PRIMARY KEY,
    FirstName VARCHAR(255) NOT NULL,
    LastName VARCHAR(255) NOT NULL,
    PhoneNumber VARCHAR(255) NOT NULL,
    EmergencyName VARCHAR(255) NOT NULL,
    EmergencyNumber VARCHAR(255) NOT NULL,
    Notes TEXT
);

CREATE TABLE RoomStatus (
    RoomStatus VARCHAR(255) PRIMARY KEY,
    Notes TEXT
);

CREATE TABLE RoomTypes (
    RoomType VARCHAR(255) PRIMARY KEY,
    Notes TEXT
);

CREATE TABLE BedTypes (
    BedType VARCHAR(255) PRIMARY KEY,
    Notes TEXT
);

CREATE TABLE Rooms (
    RoomNumber INT PRIMARY KEY,
    RoomType VARCHAR(255) NOT NULL,
    BedType VARCHAR(255) NOT NULL,
    Rate DECIMAL(10,2) NOT NULL,
    RoomStatus VARCHAR(255) NOT NULL,
    Notes TEXT,
    FOREIGN KEY (RoomType) REFERENCES RoomTypes(RoomType),
    FOREIGN KEY (BedType) REFERENCES BedTypes(BedType),
    FOREIGN KEY (RoomStatus) REFERENCES RoomStatus(RoomStatus)
);

CREATE TABLE Payments (
    Id INT PRIMARY KEY,
    EmployeeId INT NOT NULL,
    PaymentDate DATE NOT NULL,
    AccountNumber INT NOT NULL,
    FirstDateOccupied DATE NOT NULL,
    LastDateOccupied DATE NOT NULL,
    TotalDays INT NOT NULL,
    AmountCharged DECIMAL(10,2) NOT NULL,
    TaxRate DECIMAL(10,2) NOT NULL,
    TaxAmount DECIMAL(10,2) NOT NULL,
    PaymentTotal DECIMAL(10,2) NOT NULL,
    Notes TEXT,
    FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
    FOREIGN KEY (AccountNumber) REFERENCES Customers(AccountNumber)
);

CREATE TABLE Occupancies (
    Id INT PRIMARY KEY,
    EmployeeId INT NOT NULL,
    DateOccupied DATE NOT NULL,
    AccountNumber INT NOT NULL,
    RoomNumber INT NOT NULL,
    RateApplied DECIMAL(10,2) NOT NULL,
    PhoneCharge DECIMAL(10,2) NOT NULL,
    Notes TEXT,
    FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
    FOREIGN KEY (AccountNumber) REFERENCES Customers(AccountNumber),
    FOREIGN KEY (RoomNumber) REFERENCES Rooms(RoomNumber)
);

INSERT INTO Employees (Id, FirstName, LastName, Title, Notes) VALUES
    (1, 'John', 'Smith', 'Manager','Manager of the hotel'),
	(2, 'Jane', 'Doe', 'Receptionist', 'Receptionist in charge of check-ins and check-outs'),
	(3, 'Bob', 'Johnson', 'Housekeeping', 'In charge of maintaining room cleanliness');

INSERT INTO Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes) VALUES
	(1, 'John', 'Smith', '555-555-5555', 'Jane Smith', '555-555-5556', 'Regular customer'),
	(2, 'Jane', 'Doe', '555-555-5557', 'Bob Johnson', '555-555-5558', 'First time customer'),
	(3, 'Bob', 'Johnson', '555-555-5559', 'John Smith', '555-555-5560', 'Corporate account');

INSERT INTO RoomStatus (RoomStatus, Notes) VALUES
('Clean', 'Room has been cleaned and is ready for occupancy'),
('Dirty', 'Room needs to be cleaned'),
('Maintenance', 'Room is under maintenance');

INSERT INTO RoomTypes (RoomType, Notes) VALUES
('Single', 'Room with one single bed'),
('Double', 'Room with one double bed'),
('Suite', 'Room with one suite bed');

INSERT INTO BedTypes (BedType, Notes) VALUES
('Single', 'One single bed'),
('Double', 'One double bed'),
('Queen', 'One queen size bed');

INSERT INTO Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes) VALUES
(101, 'Single', 'Single', 50, 'Clean', 'Single occupancy room'),
(102, 'Double', 'Double', 75, 'Dirty', 'Double occupancy room'),
(103, 'Suite', 'Queen', 100, 'Maintenance', 'Suite room');

INSERT INTO Payments (Id, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes) VALUES
(1, 1, '2022-01-01', 1, '2021-12-29', '2022-01-01', 3, 150, 0.08, 12, 162, 'Paid in full'),
(2, 2, '2022-01-05', 2, '2022-01-03', '2022-01-05', 2, 100, 0.08, 8, 108, 'Paid in full'),
(3, 3, '2022-01-10', 3, '2022-01-08', '2022-01-10', 2, 150, 0.08, 12, 162, 'Paid in full');

INSERT INTO Occupancies (Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes) VALUES
(1, 1, '2021-12-29', 1, 101, 50, 10, 'Checked-in on time'),
(2, 2, '2022-01-03', 2, 102, 75, 15, 'Checked-in late'),
(3, 3, '2022-01-08', 3, 103, 100, 20, 'Checked-in on time');