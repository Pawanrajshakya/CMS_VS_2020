
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Businesses] (
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
    [Name] nvarchar(255) NOT NULL,
    [Address1] nvarchar(255) NOT NULL,
    [Address2] nvarchar(255) NOT NULL,
    [State] nvarchar(2) NOT NULL,
    [ZipCode] nvarchar(5) NOT NULL,
    [Description] nvarchar(255) NOT NULL,
    CONSTRAINT [PK_Businesses] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Groups] (
    [GroupId] int NOT NULL IDENTITY,
    [Description] nvarchar(max) NOT NULL,
    [Order] int NOT NULL,
    CONSTRAINT [PK_Groups] PRIMARY KEY ([GroupId])
);

GO

CREATE TABLE [Relationships] (
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
    [Description] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Relationships] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Roles] (
    [RoleId] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY ([RoleId])
);

GO

CREATE TABLE [Users] (
    [UserId] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
    [Username] nvarchar(max) NULL,
    [PasswordHash] varbinary(max) NULL,
    [PasswordSalt] varbinary(max) NULL,
    [Gender] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([UserId])
);

GO

CREATE TABLE [Clients] (
    [ClientId] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
    [Name] nvarchar(max) NULL,
    [BusinessId] int NOT NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY ([ClientId]),
    CONSTRAINT [FK_Clients_Businesses_BusinessId] FOREIGN KEY ([BusinessId]) REFERENCES [Businesses] ([Id]) 
);

GO

CREATE TABLE [AccountTypes] (
    [TypeId] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
    [Description] nvarchar(max) NULL,
    [Order] int NOT NULL,
    [GroupId] int NULL,
    CONSTRAINT [PK_AccountTypes] PRIMARY KEY ([TypeId]),
    CONSTRAINT [FK_AccountTypes_Groups_GroupId] FOREIGN KEY ([GroupId]) REFERENCES [Groups] ([GroupId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [UserRole] (
    [RoleId] int NOT NULL,
    [UserId] int NOT NULL,
    CONSTRAINT [PK_UserRole] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_UserRole_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([RoleId]) ,
    CONSTRAINT [FK_UserRole_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([UserId]) 
);

GO

CREATE TABLE [Account] (
    [AccountNo] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
    [ClientId] int NOT NULL,
    [Name] nvarchar(max) NULL,
    [Balance] float NOT NULL,
    [AccountTypeId] int NOT NULL,
    [IsMain] bit NOT NULL,
    [FirstName] nvarchar(255) NOT NULL,
    [MiddleName] nvarchar(50) NULL,
    [LastName] nvarchar(255) NOT NULL,
    [Phone] nvarchar(12) NULL,
    [Email] nvarchar(55) NULL,
    [Address1] nvarchar(255) NULL,
    [Address2] nvarchar(255) NULL,
    [State] nvarchar(2) NULL,
    [ZipCode] nvarchar(20) NULL,
    [RelationshipId] int NOT NULL,
    [Order] int NOT NULL,
    CONSTRAINT [PK_Account] PRIMARY KEY ([AccountNo]),
    CONSTRAINT [FK_Account_AccountTypes_AccountTypeId] FOREIGN KEY ([AccountTypeId]) REFERENCES [AccountTypes] ([TypeId]) ,
    CONSTRAINT [FK_Account_Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [Clients] ([ClientId]) ,
    CONSTRAINT [FK_Account_Relationships_RelationshipId] FOREIGN KEY ([RelationshipId]) REFERENCES [Relationships] ([Id]) 
);

GO

CREATE TABLE [TransactionTypes] (
    [TranType] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
    [Description] nvarchar(255) NOT NULL,
    [AccountNo] int NOT NULL,
    CONSTRAINT [PK_TransactionTypes] PRIMARY KEY ([TranType]),
    CONSTRAINT [FK_TransactionTypes_Account_AccountNo] FOREIGN KEY ([AccountNo]) REFERENCES [Account] ([AccountNo]) 
);

GO

CREATE TABLE [Transactions] (
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
    [TransactionDate] datetime2 NOT NULL,
    [Amount] float NOT NULL,
    [Description1] nvarchar(255) NULL,
    [Description2] nvarchar(255) NULL,
    [TranType] int NOT NULL,
    [AccountNo] int NOT NULL,
    CONSTRAINT [PK_Transactions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Transactions_Account_AccountNo] FOREIGN KEY ([AccountNo]) REFERENCES [Account] ([AccountNo]) ,
    CONSTRAINT [FK_Transactions_TransactionTypes_TranType] FOREIGN KEY ([TranType]) REFERENCES [TransactionTypes] ([TranType]) 
);

GO

CREATE INDEX [IX_Account_AccountTypeId] ON [Account] ([AccountTypeId]);

GO

CREATE INDEX [IX_Account_ClientId] ON [Account] ([ClientId]);

GO

CREATE INDEX [IX_Account_RelationshipId] ON [Account] ([RelationshipId]);

GO

CREATE INDEX [IX_AccountTypes_GroupId] ON [AccountTypes] ([GroupId]);

GO

CREATE INDEX [IX_Clients_BusinessId] ON [Clients] ([BusinessId]);

GO

CREATE INDEX [IX_Transactions_AccountNo] ON [Transactions] ([AccountNo]);

GO

CREATE INDEX [IX_Transactions_TranType] ON [Transactions] ([TranType]);

GO

CREATE INDEX [IX_TransactionTypes_AccountNo] ON [TransactionTypes] ([AccountNo]);

GO

CREATE INDEX [IX_UserRole_RoleId] ON [UserRole] ([RoleId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200326133329_InitalCreate', N'3.1.2');

GO


