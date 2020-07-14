CREATE TABLE [dbo].[ServiceFirstLayer]
(
	[Id] INT NOT NULL  IDENTITY, 
    [Description] NVARCHAR(MAX) NULL, 
    [Title] NVARCHAR(MAX) NULL, 
    [PhotoTitle] NCHAR(50) NULL, 
    [DescriptionShort] NVARCHAR(MAX) NULL, 
    CONSTRAINT [PK_ServiceFirstLayer] PRIMARY KEY ([Id])
)
