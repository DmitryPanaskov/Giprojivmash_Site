CREATE TABLE [dbo].[ContactPhone]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ContactId] INT NULL, 
    [Number] NVARCHAR(50) NULL, 
    [Type] INT NULL
)
