CREATE TABLE [dbo].[PortfolioPhoto]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PortfolioId] INT NULL, 
    [PhotoName] NVARCHAR(50) NULL
)
