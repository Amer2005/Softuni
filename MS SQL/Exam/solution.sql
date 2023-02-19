--1.	Database design
CREATE DATABASE Boardgames

USE Boardgames

CREATE TABLE Categories(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Addresses(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	StreetName NVARCHAR(100) NOT NULL,
	StreetNumber INT NOT NULL,
	Town NVARCHAR(30) NOT NULL,
	Country NVARCHAR(50) NOT NULL,
	ZIP INT NOT NULL
)

CREATE TABLE Publishers(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	AddressId INT NOT NULL FOREIGN KEY REFERENCES Addresses(Id),
	Website NVARCHAR(30) NULL,
	Phone NVARCHAR(20) NULL
)

CREATE TABLE PlayersRanges(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	PlayersMin INT NOT NULL,
	PlayersMax INT NOT NULL,
)

CREATE TABLE Boardgames(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	YearPublished INT NOT NULL,
	Rating Decimal(10, 3) NOT NULL,
	CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
	PublisherId INT NOT NULL FOREIGN KEY REFERENCES Publishers(Id),
	PlayersRangeId INT NOT NULL FOREIGN KEY REFERENCES PlayersRanges(Id),
)

CREATE TABLE Creators(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Email NVARCHAR(30) NOT NULL,
)

CREATE TABLE CreatorsBoardgames(
	CreatorId INT NOT NULL FOREIGN KEY REFERENCES Creators(Id),
	BoardgameId INT NOT NULL FOREIGN KEY REFERENCES Boardgames(Id),
	CONSTRAINT PK_CreatorsBoardgames PRIMARY KEY (CreatorId,BoardgameId)
)

--2.	Insert

INSERT INTO Boardgames (Name, YearPublished, Rating, CategoryId, PublisherId, PlayersRangeId)
VALUES
('Deep Blue', 2019, 5.67, 1, 15, 7),
('Paris', 2016, 9.78, 7, 1, 5),
('Catan: Starfarers', 2021, 9.87, 7, 13, 6),
('Bleeding Kansas', 2020, 3.25, 3, 7, 4),
('One Small Step', 2019, 5.75, 5, 9, 2);

INSERT INTO Publishers (Name, AddressId, Website, Phone)
VALUES
('Agman Games', 5, 'www.agmangames.com', '+16546135542'),
('Amethyst Games', 7, 'www.amethystgames.com', '+15558889992'),
('BattleBooks', 13, 'www.battlebooks.com', '+12345678907');

--3. Udpate

UPDATE PlayersRanges 
SET PlayersMax = PlayersMax + 1
WHERE PlayersMin = 2 AND PlayersMax = 2

UPDATE Boardgames
SET [Name] = [Name] + 'V2'
WHERE YearPublished >= 2020

--4. Delete

DELETE cb FROM CreatorsBoardgames AS cb
WHERE cb.BoardgameId IN (
	SELECT b.Id FROM Boardgames AS b
	WHERE b.PublisherId IN (
		SELECT p.Id FROM Publishers AS p
		WHERE p.AddressId IN (
		SELECT Id
		FROM Addresses
		WHERE Town LIKE 'L%')))

DELETE b FROM Boardgames AS b
WHERE b.PublisherId IN (
	SELECT p.Id FROM Publishers AS p
	WHERE p.AddressId IN (
	SELECT Id
    FROM Addresses
    WHERE Town LIKE 'L%'))

DELETE p FROM Publishers AS p
WHERE p.AddressId IN (
	SELECT Id
    FROM Addresses
    WHERE Town LIKE 'L%')

DELETE
FROM Addresses
WHERE Town LIKE 'L%'

--5.	Boardgames by Year of Publication

SELECT [Name], Rating 
FROM Boardgames
ORDER BY YearPublished ASC, [Name] DESC

--6.	Boardgames by Category

SELECT b.Id, b.[Name], YearPublished, c.[Name] 
FROM Boardgames AS b
JOIN Categories AS c ON c.Id = b.CategoryId
WHERE c.[Name] = 'Strategy Games' OR c.[Name] = 'Wargames'
ORDER BY YearPublished DESC

--7.	Creators without Boardgames

SELECT Id, FirstName + ' ' + LastName AS CreatorName, Email
FROM Creators
WHERE Id NOT IN(
	SELECT DISTINCT cb.CreatorId
	FROM CreatorsBoardgames AS cb
)
ORDER BY CreatorName ASC

--8.	First 5 Boardgames

SELECT TOP(5) b.[Name], b.Rating, c.[Name] AS CategoryName
FROM Boardgames AS b
JOIN Categories AS c ON c.Id = b.CategoryId
JOIN PlayersRanges AS p ON p.Id = b.PlayersRangeId
WHERE (Rating > 7 AND b.[Name] LIKE '%a%') OR (Rating > 7.5 AND p.PlayersMin = 2 AND p.PlayersMax = 5)
ORDER BY b.[Name] ASC, b.Rating DESC

--9.	Creators with Emails

SELECT c.FirstName + ' ' + c.LastName AS FullName, c.Email, MAX(b.Rating) AS Rating
FROM Creators AS c
JOIN CreatorsBoardgames AS cb ON cb.CreatorId = c.Id
JOIN Boardgames AS b ON b.Id = cb.BoardgameId
WHERE c.Email LIKE '%.com'
GROUP BY c.Id, c.FirstName, c.LastName, c.Email
ORDER BY FullName ASC

--10.	Creators by Rating

SELECT c.LastName, CAST(CEILING(AVG(b.Rating)) AS INT) AS AverageRating, p.[Name] AS PublisherName
FROM Creators AS c
JOIN CreatorsBoardgames AS cb ON cb.CreatorId = c.Id
JOIN Boardgames AS b ON b.Id = cb.BoardgameId
JOIN Publishers AS p ON p.Id = b.PublisherId
WHERE p.[Name] = 'Stonemaier Games'
GROUP BY c.Id, c.LastName, p.[Name]
ORDER BY AVG(b.Rating) DESC

--11.	Creator with Boardgames

GO

CREATE FUNCTION udf_CreatorWithBoardgames (@name NVARCHAR(30))
RETURNS INT AS
BEGIN
	DECLARE @returnvalue INT;

    SELECT @returnvalue = COUNT(b.Id)
	FROM Boardgames AS b
	JOIN CreatorsBoardgames AS cb ON b.Id = cb.BoardgameId
	JOIN Creators AS c ON c.Id = cb.CreatorId
	WHERE c.FirstName = @name
	GROUP BY c.Id

	RETURN(COALESCE(@returnvalue,0));
END;

GO

DROP FUNCTION udf_CreatorWithBoardgames

SELECT dbo.udf_CreatorWithBoardgames('Corey')

--12.	Search for Boardgame with Specific Category

GO

CREATE PROCEDURE usp_SearchByCategory @category nvarchar(50)
AS
SELECT DISTINCT b.[Name], b.YearPublished, b.Rating, c.[Name] AS CategoryName, p.[Name] AS PublisherName, CAST(pr.PlayersMin AS NVARCHAR) + ' people' AS MinPlayers,  CAST(pr.PlayersMax AS NVARCHAR) + ' people' AS MaxPlayers
FROM Categories AS c
JOIN Boardgames AS b ON b.CategoryId = c.Id
JOIN CreatorsBoardgames AS cb ON cb.BoardgameId = cb.BoardgameId
JOIN Creators AS cr ON cr.Id = cb.CreatorId
JOIN Publishers AS p ON p.Id = b.PublisherId
JOIN PlayersRanges AS pr ON pr.Id = b.PlayersRangeId
WHERE c.[Name] = @category
ORDER BY p.[Name] ASC, b.YearPublished DESC
GO


EXEC usp_SearchByCategory 'Wargames'
