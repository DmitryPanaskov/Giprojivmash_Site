CREATE TABLE [dbo].[Vacancy]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Position] NVARCHAR(MAX) NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [Contact] NVARCHAR(MAX) NULL
)
