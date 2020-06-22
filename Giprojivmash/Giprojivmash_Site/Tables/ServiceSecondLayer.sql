CREATE TABLE [dbo].[ServiceSecondLayer]
(
	[Id] INT NOT NULL  IDENTITY, 
    [Description] NVARCHAR(MAX) NULL, 
    [ServiceFirstLayerId] INT NOT NULL, 
    CONSTRAINT [FK_ServiceSecondLayer_ServiceFirstLayer] FOREIGN KEY ([ServiceFirstLayerId]) REFERENCES [ServiceFirstLayer]([Id])
    ON DELETE CASCADE, 
    CONSTRAINT [PK_ServiceSecondLayer] PRIMARY KEY ([Id])
)
