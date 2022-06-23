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

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Desgination] nvarchar(max) NOT NULL,
    [JoiningDate] datetime2 NOT NULL,
    [Address] nvarchar(max) NOT NULL,
    [Street] nvarchar(max) NOT NULL,
    [City] nvarchar(max) NOT NULL,
    [State] nvarchar(max) NOT NULL,
    [PinCode] nvarchar(max) NOT NULL,
    [Country] nvarchar(max) NOT NULL,
    [ImagePath] nvarchar(max) NOT NULL,
    [Guid] uniqueidentifier NOT NULL,
    [CreateDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'City', N'Country', N'CreateDate', N'Desgination', N'Guid', N'ImagePath', N'JoiningDate', N'Name', N'PinCode', N'State', N'Street') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] ON;
INSERT INTO [Users] ([Id], [Address], [City], [Country], [CreateDate], [Desgination], [Guid], [ImagePath], [JoiningDate], [Name], [PinCode], [State], [Street])
VALUES (1, N'test1', N'', N'India', '2022-06-23T07:19:37.5030288+00:00', N'Test Engineer', 'a699939f-65fa-4de9-9599-bd9fff9e2e3c', N'', '2012-04-25T00:00:00.0000000', N'John', N'', N'', N'');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'City', N'Country', N'CreateDate', N'Desgination', N'Guid', N'ImagePath', N'JoiningDate', N'Name', N'PinCode', N'State', N'Street') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'City', N'Country', N'CreateDate', N'Desgination', N'Guid', N'ImagePath', N'JoiningDate', N'Name', N'PinCode', N'State', N'Street') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] ON;
INSERT INTO [Users] ([Id], [Address], [City], [Country], [CreateDate], [Desgination], [Guid], [ImagePath], [JoiningDate], [Name], [PinCode], [State], [Street])
VALUES (2, N'test1', N'', N'India', '2022-06-23T07:19:37.5030300+00:00', N'PMO', '355f110d-beb0-4704-92f1-8cf78cc0f03a', N'', '2019-09-12T00:00:00.0000000', N'Luther', N'', N'', N'');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'City', N'Country', N'CreateDate', N'Desgination', N'Guid', N'ImagePath', N'JoiningDate', N'Name', N'PinCode', N'State', N'Street') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220623071937_Initial', N'6.0.6');
GO

COMMIT;
GO

