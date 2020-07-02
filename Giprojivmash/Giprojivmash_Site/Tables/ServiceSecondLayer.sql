CREATE TABLE [dbo].[ServiceSecondLayer]
(
	[Id] INT NOT NULL  IDENTITY, 
    [Description] NVARCHAR(MAX) NULL, 
    [ServiceFirstLayerId] INT NOT NULL, 
    CONSTRAINT [PK_ServiceSecondLayer] PRIMARY KEY ([Id])
)
