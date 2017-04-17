CREATE TABLE [dbo].[Measurements] (
    [Id]    INT      IDENTITY (1, 1) NOT NULL,
    [Value] INT      NOT NULL,
    [Date]  DATETIME NOT NULL,
    CONSTRAINT [PK_dbo.Measurements] PRIMARY KEY CLUSTERED ([Id] ASC)
);

