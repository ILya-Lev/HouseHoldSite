CREATE TABLE [dbo].[Ranges] (
    [Id]   INT IDENTITY (1, 1) NOT NULL,
    [From] INT NOT NULL,
    [To]   INT NULL,
    CONSTRAINT [PK_dbo.Ranges] PRIMARY KEY CLUSTERED ([Id] ASC)
);

