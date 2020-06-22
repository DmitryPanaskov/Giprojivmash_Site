CREATE TABLE [dbo].[ServiceThirdLayer]
(
	[Id] INT NOT NULL  IDENTITY, 
    [Description] NVARCHAR(MAX) NULL, 
    [ServiceSecondLayerId] INT NOT NULL, 
    CONSTRAINT [FK_ServiceThirdLayer_ServiceSecondLayer] FOREIGN KEY ([ServiceSecondLayerId]) REFERENCES [ServiceFirstLayer]([Id])
    ON DELETE CASCADE, 
    CONSTRAINT [PK_ServiceThirdLayer] PRIMARY KEY ([Id])
)
