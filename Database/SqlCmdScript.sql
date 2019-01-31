IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190115164216_InitialCreate')
BEGIN
    IF SCHEMA_ID(N'WideWorldImporters') IS NULL EXEC(N'CREATE SCHEMA [WideWorldImporters];');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190115164216_InitialCreate')
BEGIN
    CREATE TABLE [WideWorldImporters].[StockItems] (
        [StockItemID] int NOT NULL,
        [StockItemName] nvarchar(200) NOT NULL,
        [SupplierID] int NOT NULL,
        [ColorID] int NULL,
        [UnitPackageID] int NOT NULL,
        [OuterPackageID] int NOT NULL,
        [Brand] nvarchar(100) NULL,
        [Size] nvarchar(40) NULL,
        [LeadTimeDays] int NOT NULL,
        [QuantityPerOuter] int NOT NULL,
        [IsChillerStock] bit NOT NULL,
        [Barcode] nvarchar(100) NULL,
        [TaxRate] decimal(18, 3) NOT NULL,
        [UnitPrice] decimal(18, 2) NOT NULL,
        [RecommendedRetailPrice] decimal(18, 2) NULL,
        [TypicalWeightPerUnit] decimal(18, 3) NOT NULL,
        [MarketingComments] nvarchar(max) NULL,
        [InternalComments] nvarchar(max) NULL,
        [CustomFields] nvarchar(max) NULL,
        [Tags] AS json_query([CustomFields],N'$.Tags'),
        [SearchDetails] AS concat([StockItemName],N' ',[MarketingComments]),
        [LastEditedBy] int NOT NULL,
        [ValidFrom] datetime2 NOT NULL,
        [ValidTo] datetime2 NOT NULL,
        CONSTRAINT [PK_StockItems] PRIMARY KEY ([StockItemID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190115164216_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190115164216_InitialCreate', N'2.1.4-rtm-31024');
END;

GO