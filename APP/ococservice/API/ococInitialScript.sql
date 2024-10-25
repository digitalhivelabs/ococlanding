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

CREATE TABLE [ClassificationItems] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Abbr] nvarchar(max) NULL,
    CONSTRAINT [PK_ClassificationItems] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [QualityStandards] (
    [QSId] int NOT NULL IDENTITY,
    [Organization] nvarchar(max) NULL,
    [Abbr] nvarchar(max) NULL,
    [Country] nvarchar(max) NULL,
    [MDate] datetime2 NOT NULL,
    CONSTRAINT [PK_QualityStandards] PRIMARY KEY ([QSId])
);
GO

CREATE TABLE [Semaphore] (
    [SemaphoreId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Color] nvarchar(max) NULL,
    [Hex] nvarchar(max) NULL,
    CONSTRAINT [PK_Semaphore] PRIMARY KEY ([SemaphoreId])
);
GO

CREATE TABLE [surveys] (
    [SurveyId] int NOT NULL IDENTITY,
    [CDate] datetime2 NOT NULL,
    [LocationName] nvarchar(max) NULL,
    [LocationLatLon] nvarchar(max) NULL,
    CONSTRAINT [PK_surveys] PRIMARY KEY ([SurveyId])
);
GO

CREATE TABLE [Units] (
    [UnitId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Abbr] nvarchar(max) NULL,
    [BaseUnitId] int NULL,
    CONSTRAINT [PK_Units] PRIMARY KEY ([UnitId]),
    CONSTRAINT [FK_Units_Units_BaseUnitId] FOREIGN KEY ([BaseUnitId]) REFERENCES [Units] ([UnitId])
);
GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [UserName] nvarchar(max) NOT NULL,
    [PasswordHash] varbinary(max) NULL,
    [PasswordSalt] varbinary(max) NULL,
    [Email] nvarchar(max) NULL,
    [Status] nvarchar(max) NULL,
    [Country] nvarchar(max) NULL,
    [Role] nvarchar(max) NULL,
    [Job] nvarchar(max) NULL,
    [Gender] nvarchar(max) NULL,
    [StartDate] datetime2 NOT NULL,
    [RegistrationDate] datetime2 NOT NULL,
    [IsActive] bit NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Conversions] (
    [Id] int NOT NULL IDENTITY,
    [Operator] nvarchar(max) NULL,
    [Factor] real NOT NULL,
    [Formula] nvarchar(max) NULL,
    [SourceUnitId] int NOT NULL,
    [TargetUnitId] int NOT NULL,
    CONSTRAINT [PK_Conversions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Conversions_Units_SourceUnitId] FOREIGN KEY ([SourceUnitId]) REFERENCES [Units] ([UnitId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Conversions_Units_TargetUnitId] FOREIGN KEY ([TargetUnitId]) REFERENCES [Units] ([UnitId]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Items] (
    [itemId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Abbr] nvarchar(max) NULL,
    [MoreInfo] nvarchar(max) NULL,
    [UnitId] int NOT NULL,
    [ClassificationItemId] int NULL,
    CONSTRAINT [PK_Items] PRIMARY KEY ([itemId]),
    CONSTRAINT [FK_Items_ClassificationItems_ClassificationItemId] FOREIGN KEY ([ClassificationItemId]) REFERENCES [ClassificationItems] ([Id]),
    CONSTRAINT [FK_Items_Units_UnitId] FOREIGN KEY ([UnitId]) REFERENCES [Units] ([UnitId]) ON DELETE NO ACTION
);
GO

CREATE TABLE [QualityStandardItems] (
    [QSIId] int NOT NULL IDENTITY,
    [QualityStandardQSId] int NULL,
    [LowerLim] real NOT NULL,
    [UpperLim] real NOT NULL,
    [LatLog] nvarchar(max) NULL,
    [QSId] int NOT NULL,
    [ItemId] int NOT NULL,
    [UnitId] int NOT NULL,
    [SemaphoreId] int NOT NULL,
    CONSTRAINT [PK_QualityStandardItems] PRIMARY KEY ([QSIId]),
    CONSTRAINT [FK_QualityStandardItems_Items_ItemId] FOREIGN KEY ([ItemId]) REFERENCES [Items] ([itemId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_QualityStandardItems_QualityStandards_QualityStandardQSId] FOREIGN KEY ([QualityStandardQSId]) REFERENCES [QualityStandards] ([QSId]),
    CONSTRAINT [FK_QualityStandardItems_Semaphore_SemaphoreId] FOREIGN KEY ([SemaphoreId]) REFERENCES [Semaphore] ([SemaphoreId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_QualityStandardItems_Units_UnitId] FOREIGN KEY ([UnitId]) REFERENCES [Units] ([UnitId]) ON DELETE NO ACTION
);
GO

CREATE TABLE [surveyItems] (
    [SIId] int NOT NULL IDENTITY,
    [Value] real NOT NULL,
    [ValueBase] real NOT NULL,
    [Method] nvarchar(max) NULL,
    [LabName] nvarchar(max) NULL,
    [Responsible] int NOT NULL,
    [Preferent] bit NOT NULL,
    [Notes] nvarchar(max) NULL,
    [SurveyId] int NOT NULL,
    [ItemId] int NOT NULL,
    [UnitId] int NOT NULL,
    [UnitBaseId] int NOT NULL,
    CONSTRAINT [PK_surveyItems] PRIMARY KEY ([SIId]),
    CONSTRAINT [FK_surveyItems_Items_ItemId] FOREIGN KEY ([ItemId]) REFERENCES [Items] ([itemId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_surveyItems_Units_UnitBaseId] FOREIGN KEY ([UnitBaseId]) REFERENCES [Units] ([UnitId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_surveyItems_Units_UnitId] FOREIGN KEY ([UnitId]) REFERENCES [Units] ([UnitId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_surveyItems_surveys_SurveyId] FOREIGN KEY ([SurveyId]) REFERENCES [surveys] ([SurveyId]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_Conversions_SourceUnitId] ON [Conversions] ([SourceUnitId]);
GO

CREATE INDEX [IX_Conversions_TargetUnitId] ON [Conversions] ([TargetUnitId]);
GO

CREATE INDEX [IX_Items_ClassificationItemId] ON [Items] ([ClassificationItemId]);
GO

CREATE INDEX [IX_Items_UnitId] ON [Items] ([UnitId]);
GO

CREATE INDEX [IX_QualityStandardItems_ItemId] ON [QualityStandardItems] ([ItemId]);
GO

CREATE INDEX [IX_QualityStandardItems_QualityStandardQSId] ON [QualityStandardItems] ([QualityStandardQSId]);
GO

CREATE INDEX [IX_QualityStandardItems_SemaphoreId] ON [QualityStandardItems] ([SemaphoreId]);
GO

CREATE INDEX [IX_QualityStandardItems_UnitId] ON [QualityStandardItems] ([UnitId]);
GO

CREATE INDEX [IX_surveyItems_ItemId] ON [surveyItems] ([ItemId]);
GO

CREATE INDEX [IX_surveyItems_SurveyId] ON [surveyItems] ([SurveyId]);
GO

CREATE INDEX [IX_surveyItems_UnitBaseId] ON [surveyItems] ([UnitBaseId]);
GO

CREATE INDEX [IX_surveyItems_UnitId] ON [surveyItems] ([UnitId]);
GO

CREATE INDEX [IX_Units_BaseUnitId] ON [Units] ([BaseUnitId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240316224616_InitialCreate', N'7.0.15');
GO

COMMIT;
GO

