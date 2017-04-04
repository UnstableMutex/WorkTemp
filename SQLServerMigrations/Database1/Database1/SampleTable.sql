CREATE TABLE [dbo].[SampleTable]
(
	[Id] INT identity(1,1) NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL, 
    [NewColV1] INT NOT NULL DEFAULT 3
)
