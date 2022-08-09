USE [CampeonatoBrasileiro]
GO

IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Times] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] VARCHAR(200) NOT NULL,
    [Localidade] VARCHAR(100) NOT NULL,
    CONSTRAINT [PK_Times] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Torneios] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] VARCHAR(200) NOT NULL,
    CONSTRAINT [PK_Torneios] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Jogadores] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] VARCHAR(200) NOT NULL,
    [DataNascimento] DATETIME NOT NULL,
    [Pais] VARCHAR(100) NOT NULL,
    [TimeId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Jogadores] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Jogadores_Times_TimeId] FOREIGN KEY ([TimeId]) REFERENCES [Times] ([Id])
);
GO

CREATE TABLE [Partidas] (
    [Id] uniqueidentifier NOT NULL,
    [TorneioId] uniqueidentifier NOT NULL,
    [TimeMandanteId] uniqueidentifier NOT NULL,
    [TimeVisitanteId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Partidas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Partidas_Times_TimeMandanteId] FOREIGN KEY ([TimeMandanteId]) REFERENCES [Times] ([Id]),
	CONSTRAINT [FK_Partidas_Times_TimeVisitanteId] FOREIGN KEY ([TimeVisitanteId]) REFERENCES [Times] ([Id]),
	CONSTRAINT [FK_Partidas_Torneios_TorneioId] FOREIGN KEY ([TorneioId]) REFERENCES [Torneios] ([Id])
);
GO

CREATE TABLE [TimeTorneio] (
    [TimesId] uniqueidentifier NOT NULL,
    [TorneiosId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_TimeTorneio] PRIMARY KEY ([TimesId], [TorneiosId]),
    CONSTRAINT [FK_TimeTorneio_Times_TimesId] FOREIGN KEY ([TimesId]) REFERENCES [Times] ([Id]),
    CONSTRAINT [FK_TimeTorneio_Torneios_TorneiosId] FOREIGN KEY ([TorneiosId]) REFERENCES [Torneios] ([Id])
);
GO

CREATE TABLE [Transferencias] (
    [Id] uniqueidentifier NOT NULL,
    [Data] DATETIME NOT NULL,
    [Valor] decimal(18,2) NOT NULL,
    [JogadorId] uniqueidentifier NOT NULL,
    [TimeOrigemId] uniqueidentifier NOT NULL,
    [TimeDestinoId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Transferencias] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Transferencias_Jogadores_JogadorId] FOREIGN KEY ([JogadorId]) REFERENCES [Jogadores] ([Id]),
    CONSTRAINT [FK_Transferencias_Times_TimeDestinoId] FOREIGN KEY ([TimeDestinoId]) REFERENCES [Times] ([Id]),
	CONSTRAINT [FK_Transferencias_Times_TimeOrigemId] FOREIGN KEY ([TimeOrigemId]) REFERENCES [Times] ([Id])
);
GO

CREATE TABLE [Eventos] (
    [Id] uniqueidentifier NOT NULL,
    [TipoEvento] int NOT NULL,
    [Data] datetime2 NOT NULL,
    [PartidaId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Eventos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Eventos_Partidas_PartidaId] FOREIGN KEY ([PartidaId]) REFERENCES [Partidas] ([Id])
);
GO

CREATE INDEX [IX_Eventos_PartidaId] ON [Eventos] ([PartidaId]);
GO

CREATE INDEX [IX_Jogadores_TimeId] ON [Jogadores] ([TimeId]);
GO

CREATE INDEX [IX_Partidas_TimeMandanteId] ON [Partidas] ([TimeMandanteId]);
GO

CREATE INDEX [IX_Partidas_TimeVisitanteId] ON [Partidas] ([TimeVisitanteId]);
GO

CREATE INDEX [IX_Partidas_TorneioId] ON [Partidas] ([TorneioId]);
GO

CREATE INDEX [IX_TimeTorneio_TorneiosId] ON [TimeTorneio] ([TorneiosId]);
GO

CREATE INDEX [IX_Transferencias_JogadorId] ON [Transferencias] ([JogadorId]);
GO

CREATE INDEX [IX_Transferencias_TimeDestinoId] ON [Transferencias] ([TimeDestinoId]);
GO

CREATE INDEX [IX_Transferencias_TimeOrigemId] ON [Transferencias] ([TimeOrigemId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220724221127_Initial', N'6.0.7');
GO

COMMIT;
GO

