CREATE TABLE [dbo].[ServiceFirstLayer]
(
	[Id] INT NOT NULL  IDENTITY, 
    [Description] NVARCHAR(MAX) NULL, 
    [ServiceTitle] NVARCHAR(MAX) NULL, 
    [PhotoTitle] NCHAR(50) NULL, 
    [PhotoAlt] NCHAR(50) NULL, 
    CONSTRAINT [PK_ServiceFirstLayer] PRIMARY KEY ([Id])
)
