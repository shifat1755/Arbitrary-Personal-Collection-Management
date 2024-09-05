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

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240820183924_New1'
)
BEGIN
    CREATE TABLE [hashTags] (
        [Name] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_hashTags] PRIMARY KEY ([Name])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240820183924_New1'
)
BEGIN
    CREATE TABLE [Users] (
        [Id] uniqueidentifier NOT NULL,
        [ProfileImage] nvarchar(max) NULL,
        [FirstName] nvarchar(max) NOT NULL,
        [LastName] nvarchar(max) NULL,
        [Email] nvarchar(max) NOT NULL,
        [IsEmailVerified] bit NOT NULL,
        [Role] nvarchar(max) NOT NULL,
        [Password] nvarchar(max) NOT NULL,
        [DOB] date NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240820183924_New1'
)
BEGIN
    CREATE TABLE [Collections] (
        [Id] uniqueidentifier NOT NULL,
        [Title] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [UserId] uniqueidentifier NOT NULL,
        [Category] nvarchar(max) NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        CONSTRAINT [PK_Collections] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Collections_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240820183924_New1'
)
BEGIN
    CREATE TABLE [CustomFields] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Type] nvarchar(max) NOT NULL,
        [CollectionId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_CustomFields] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_CustomFields_Collections_CollectionId] FOREIGN KEY ([CollectionId]) REFERENCES [Collections] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240820183924_New1'
)
BEGIN
    CREATE TABLE [Items] (
        [Id] uniqueidentifier NOT NULL,
        [UserId] uniqueidentifier NOT NULL,
        [CollectionId] uniqueidentifier NOT NULL,
        [Title] nvarchar(max) NULL,
        [CreatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Items] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Items_Collections_CollectionId] FOREIGN KEY ([CollectionId]) REFERENCES [Collections] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240820183924_New1'
)
BEGIN
    CREATE TABLE [Comments] (
        [Id] uniqueidentifier NOT NULL,
        [Data] nvarchar(max) NULL,
        [ItemId] uniqueidentifier NOT NULL,
        [UserId] uniqueidentifier NOT NULL,
        [Created] datetime2 NOT NULL,
        CONSTRAINT [PK_Comments] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Comments_Items_ItemId] FOREIGN KEY ([ItemId]) REFERENCES [Items] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240820183924_New1'
)
BEGIN
    CREATE TABLE [CustomFieldValues] (
        [Id] uniqueidentifier NOT NULL,
        [FieldName] nvarchar(max) NULL,
        [Value] nvarchar(max) NULL,
        [Type] nvarchar(max) NULL,
        [ItemId] uniqueidentifier NULL,
        CONSTRAINT [PK_CustomFieldValues] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_CustomFieldValues_Items_ItemId] FOREIGN KEY ([ItemId]) REFERENCES [Items] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240820183924_New1'
)
BEGIN
    CREATE TABLE [ItemTag] (
        [TagsName] nvarchar(450) NOT NULL,
        [itemsId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_ItemTag] PRIMARY KEY ([TagsName], [itemsId]),
        CONSTRAINT [FK_ItemTag_Items_itemsId] FOREIGN KEY ([itemsId]) REFERENCES [Items] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ItemTag_hashTags_TagsName] FOREIGN KEY ([TagsName]) REFERENCES [hashTags] ([Name]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240820183924_New1'
)
BEGIN
    CREATE TABLE [Likes] (
        [Id] uniqueidentifier NOT NULL,
        [ItemId] uniqueidentifier NOT NULL,
        [UserId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Likes] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Likes_Items_ItemId] FOREIGN KEY ([ItemId]) REFERENCES [Items] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240820183924_New1'
)
BEGIN
    CREATE INDEX [IX_Collections_UserId] ON [Collections] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240820183924_New1'
)
BEGIN
    CREATE INDEX [IX_Comments_ItemId] ON [Comments] ([ItemId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240820183924_New1'
)
BEGIN
    CREATE INDEX [IX_CustomFields_CollectionId] ON [CustomFields] ([CollectionId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240820183924_New1'
)
BEGIN
    CREATE INDEX [IX_CustomFieldValues_ItemId] ON [CustomFieldValues] ([ItemId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240820183924_New1'
)
BEGIN
    CREATE INDEX [IX_Items_CollectionId] ON [Items] ([CollectionId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240820183924_New1'
)
BEGIN
    CREATE INDEX [IX_ItemTag_itemsId] ON [ItemTag] ([itemsId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240820183924_New1'
)
BEGIN
    CREATE INDEX [IX_Likes_ItemId] ON [Likes] ([ItemId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240820183924_New1'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240820183924_New1', N'8.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240820190938_New2'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240820190938_New2', N'8.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240823062230_db23-8-2024'
)
BEGIN
    ALTER TABLE [Comments] ADD [UserName] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240823062230_db23-8-2024'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240823062230_db23-8-2024', N'8.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240823110310_db 24-8-2024'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240823110310_db 24-8-2024', N'8.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240823135100_db2 24-8-2024'
)
BEGIN
    EXEC sp_rename N'[Comments].[UserName]', N'firstName', N'COLUMN';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240823135100_db2 24-8-2024'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240823135100_db2 24-8-2024', N'8.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240823154700_db3 24-8-2024'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240823154700_db3 24-8-2024', N'8.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240823210656_db 25-8-2024'
)
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'Password');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Users] ALTER COLUMN [Password] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240823210656_db 25-8-2024'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240823210656_db 25-8-2024', N'8.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240827190202_db8-28-2024'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240827190202_db8-28-2024', N'8.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240830203213_db-31-08-2024'
)
BEGIN
    CREATE TABLE [Ticket] (
        [Id] uniqueidentifier NOT NULL,
        [Summury] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [Priority] nvarchar(max) NOT NULL,
        [UserEmail] nvarchar(max) NOT NULL,
        [UserID] uniqueidentifier NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Ticket] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Ticket_Users_UserID] FOREIGN KEY ([UserID]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240830203213_db-31-08-2024'
)
BEGIN
    CREATE INDEX [IX_Ticket_UserID] ON [Ticket] ([UserID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240830203213_db-31-08-2024'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240830203213_db-31-08-2024', N'8.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240830203440_db2-31-08-2024'
)
BEGIN
    ALTER TABLE [Ticket] DROP CONSTRAINT [FK_Ticket_Users_UserID];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240830203440_db2-31-08-2024'
)
BEGIN
    ALTER TABLE [Ticket] ADD CONSTRAINT [FK_Ticket_Users_UserID] FOREIGN KEY ([UserID]) REFERENCES [Users] ([Id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240830203440_db2-31-08-2024'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240830203440_db2-31-08-2024', N'8.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240902195500_db 3-9-2024'
)
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Ticket]') AND [c].[name] = N'Description');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Ticket] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Ticket] DROP COLUMN [Description];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240902195500_db 3-9-2024'
)
BEGIN
    EXEC sp_rename N'[Ticket].[Summury]', N'Summary', N'COLUMN';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240902195500_db 3-9-2024'
)
BEGIN
    ALTER TABLE [Users] ADD [JiraAccountId] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240902195500_db 3-9-2024'
)
BEGIN
    ALTER TABLE [Ticket] ADD [CollectionName] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240902195500_db 3-9-2024'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240902195500_db 3-9-2024', N'8.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240905183616_5-9-2024'
)
BEGIN
    ALTER TABLE [Users] ADD [SFCompanyName] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240905183616_5-9-2024'
)
BEGIN
    ALTER TABLE [Users] ADD [SFContactName] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240905183616_5-9-2024'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240905183616_5-9-2024', N'8.0.7');
END;
GO

COMMIT;
GO

