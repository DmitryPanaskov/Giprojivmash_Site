CREATE TABLE [dbo].[Contact]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Photo] NVARCHAR(50) NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [Address] NVARCHAR(MAX) NULL
)
