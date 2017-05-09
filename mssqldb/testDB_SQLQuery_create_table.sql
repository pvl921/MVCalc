CREATE TABLE dbo.[TEST] (
ID int NOT NULL PRIMARY KEY IDENTITY,
Result nvarchar(max),
LogDateTime datetime 
)
GO

IF OBJECT_ID ( 'LogInsert', 'P' ) IS NOT NULL  
    DROP PROCEDURE dbo.LogInsert;
GO

CREATE PROCEDURE LogInsert (@pResult nvarchar(max))
AS
INSERT INTO dbo.[TEST](Result,LogDateTime)
VALUES (@pResult, GETDATE());
GO

SELECT * FROM [TEST]
go
