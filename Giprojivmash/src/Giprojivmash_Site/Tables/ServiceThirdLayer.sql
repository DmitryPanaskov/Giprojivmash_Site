CREATE TABLE [dbo].[ServiceThirdLayer]
(
	[Id] INT NOT NULL IDENTITY, 
    [Description] NVARCHAR(MAX) NULL, 
    [ServiceSecondLayerId] INT NOT NULL, 
    CONSTRAINT [PK_ServiceThirdLayer] PRIMARY KEY ([Id])
)
