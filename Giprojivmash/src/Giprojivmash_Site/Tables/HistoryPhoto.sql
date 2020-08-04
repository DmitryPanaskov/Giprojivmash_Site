CREATE TABLE [dbo].[HistoryPhoto]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [HistoryId] INT NULL, 
    [PhotoName] NVARCHAR(50) NULL
)
