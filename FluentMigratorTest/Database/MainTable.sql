CREATE TABLE [dbo].[MainTable]
(
	[ID] INT NOT NULL PRIMARY KEY DEFAULT next value for MainTablePKSeq, 
    [Name] VARCHAR(50) NOT NULL
)
