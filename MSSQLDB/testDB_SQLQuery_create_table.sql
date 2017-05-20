CREATE TABLE dbo.[TEST] (
ID int NOT NULL IDENTITY,
Result nvarchar(max),
LogDateTime datetimeoffset,
CONSTRAINT PK#TEST@ID PRIMARY KEY (ID) 
)
GO

IF OBJECT_ID ( '[Add]', 'P' ) IS NOT NULL  
    DROP PROCEDURE dbo.[Add]
GO
IF OBJECT_ID ( '[Delete]', 'P' ) IS NOT NULL  
    DROP PROCEDURE dbo.[Delete];
GO
IF OBJECT_ID ( '[Get]', 'P' ) IS NOT NULL  
    DROP PROCEDURE dbo.[Get];
GO
IF OBJECT_ID ( '[List]', 'P' ) IS NOT NULL  
    DROP PROCEDURE dbo.[List];
GO


CREATE PROCEDURE [Add] (@pResult nvarchar(max), @pDate datetimeoffset, @pID int output)
AS
BEGIN
INSERT INTO dbo.[TEST](Result,LogDateTime)
VALUES (@pResult, @pDate);
SELECT @pID = @@IDENTITY FROM dbo.[TEST]
END
GO

CREATE PROCEDURE [Delete] (@pID int)
AS
BEGIN
DELETE FROM dbo.[TEST]
WHERE ID = @pID
END
GO

CREATE PROCEDURE [Get] (@pID int)
AS
BEGIN
SELECT * FROM dbo.[TEST] WHERE ID = @pID
END
GO

CREATE PROCEDURE [List]
AS
BEGIN
SELECT * FROM dbo.[TEST]
END
GO

SELECT * FROM [TEST]
go

drop table TEST