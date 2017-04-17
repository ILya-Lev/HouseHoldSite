CREATE TABLE [dbo].[Tariffs] (
    [Id]       INT             IDENTITY (1, 1) NOT NULL,
    [Price]    DECIMAL (18, 2) NOT NULL,
    [Since]    DATETIME        NULL,
    [Until]    DATETIME        NULL,
    [Range_Id] INT             NULL,
    CONSTRAINT [PK_dbo.Tariffs] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Tariffs_dbo.Ranges_Range_Id] FOREIGN KEY ([Range_Id]) REFERENCES [dbo].[Ranges] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Range_Id]
    ON [dbo].[Tariffs]([Range_Id] ASC);

