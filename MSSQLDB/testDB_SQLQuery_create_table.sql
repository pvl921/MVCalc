CREATE TABLE dbo.[TEST] (
ID int NOT NULL PRIMARY KEY IDENTITY,
Result nvarchar(max),
LogDateTime datetimeoffset 
)
GO

IF OBJECT_ID ( 'LogInsert', 'P' ) IS NOT NULL  
    DROP PROCEDURE dbo.LogInsert;
GO
IF OBJECT_ID ( 'LogDelete', 'P' ) IS NOT NULL  
    DROP PROCEDURE dbo.LogDelete;
GO
IF OBJECT_ID ( 'LogViewId', 'P' ) IS NOT NULL  
    DROP PROCEDURE dbo.LogViewId;
GO
IF OBJECT_ID ( 'LogView', 'P' ) IS NOT NULL  
    DROP PROCEDURE dbo.LogView;
GO


CREATE PROCEDURE LogInsert (@pResult nvarchar(max), @pDate datetimeoffset)
AS
INSERT INTO dbo.[TEST](Result,LogDateTime)
VALUES (@pResult, CAST(@pDate AS datetimeoffset));
GO

CREATE PROCEDURE LogDelete (@pID int)
AS
DELETE FROM dbo.[TEST]
WHERE ID = @pID
GO

CREATE PROCEDURE LogViewId (@pID int)
AS
SELECT * FROM dbo.[TEST] WHERE ID = @pID
GO

CREATE PROCEDURE LogView 
AS
SELECT * FROM dbo.[TEST]
GO

SELECT * FROM [TEST]
go

