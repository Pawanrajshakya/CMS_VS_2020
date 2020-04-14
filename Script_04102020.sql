IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [AccountHistories] (
    [Id] int NOT NULL IDENTITY,
    [AccountNo] nvarchar(max) NULL,
    [ClientId] int NOT NULL,
    [Name] nvarchar(max) NULL,
    [Balance] decimal(18,2) NOT NULL,
    [AccountTypeId] int NOT NULL,
    [IsMain] bit NOT NULL,
    [FirstName] nvarchar(255) NULL,
    [MiddleName] nvarchar(50) NULL,
    [LastName] nvarchar(255) NULL,
    [Phone] nvarchar(12) NULL,
    [Email] nvarchar(55) NULL,
    [Address1] nvarchar(255) NULL,
    [Address2] nvarchar(255) NULL,
    [State] nvarchar(2) NULL,
    [ZipCode] nvarchar(20) NULL,
    [RelationshipId] int NOT NULL,
    [Order] int NOT NULL,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] varbinary(max) NULL,
    CONSTRAINT [PK_AccountHistories] PRIMARY KEY ([Id])
);

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
    [Name] nvarchar(255) NULL,
    [Address1] nvarchar(255) NULL,
    [Address2] nvarchar(255) NULL,
    [State] nvarchar(2) NULL,
    [ZipCode] nvarchar(5) NULL,
    [Description] nvarchar(255) NULL,
    CONSTRAINT [PK_Businesses] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Groups] (
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
    [Description] nvarchar(max) NOT NULL,
    [Order] int NOT NULL,
    CONSTRAINT [PK_Groups] PRIMARY KEY ([Id])
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
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [UserHistories] (
    [Id] int NOT NULL IDENTITY,
    [Username] nvarchar(max) NULL,
    [PasswordHash] varbinary(max) NULL,
    [PasswordSalt] varbinary(max) NULL,
    [Name] nvarchar(max) NULL,
    [Gender] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [UserRole] nvarchar(max) NULL,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] varbinary(max) NULL,
    CONSTRAINT [PK_UserHistories] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
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
    [Name] nvarchar(max) NULL,
    [Gender] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Clients] (
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
    [Name] nvarchar(max) NULL,
    [BusinessId] int NOT NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Clients_Businesses_BusinessId] FOREIGN KEY ([BusinessId]) REFERENCES [Businesses] ([Id])
);

GO

CREATE TABLE [AccountTypes] (
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
    [Description] nvarchar(max) NULL,
    [Order] int NOT NULL,
    [GroupId] int NOT NULL,
    CONSTRAINT [PK_AccountTypes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AccountTypes_Groups_GroupId] FOREIGN KEY ([GroupId]) REFERENCES [Groups] ([Id])
);

GO

CREATE TABLE [UserRole] (
    [RoleId] int NOT NULL,
    [UserId] int NOT NULL,
    CONSTRAINT [PK_UserRole] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_UserRole_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([Id]),
    CONSTRAINT [FK_UserRole_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id])
);

GO

CREATE TABLE [Account] (
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
    [AccountNo] nvarchar(max) NULL,
    [ClientId] int NOT NULL,
    [Name] nvarchar(max) NULL,
    [Balance] decimal(18,2) NOT NULL,
    [AccountTypeId] int NOT NULL,
    [IsMain] bit NOT NULL,
    [FirstName] nvarchar(255) NULL,
    [MiddleName] nvarchar(50) NULL,
    [LastName] nvarchar(255) NULL,
    [Phone] nvarchar(12) NULL,
    [Email] nvarchar(55) NULL,
    [Address1] nvarchar(255) NULL,
    [Address2] nvarchar(255) NULL,
    [State] nvarchar(2) NULL,
    [ZipCode] nvarchar(20) NULL,
    [RelationshipId] int NOT NULL,
    [Order] int NOT NULL,
    CONSTRAINT [PK_Account] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Account_AccountTypes_AccountTypeId] FOREIGN KEY ([AccountTypeId]) REFERENCES [AccountTypes] ([Id]),
    CONSTRAINT [FK_Account_Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [Clients] ([Id]),
    CONSTRAINT [FK_Account_Relationships_RelationshipId] FOREIGN KEY ([RelationshipId]) REFERENCES [Relationships] ([Id])
);

GO

CREATE TABLE [TransactionTypes] (
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
    [Description] nvarchar(max) NULL,
    [AccountId] int NOT NULL,
    CONSTRAINT [PK_TransactionTypes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TransactionTypes_Account_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [Account] ([Id])
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
    [Amount] decimal(18,2) NOT NULL,
    [Description1] nvarchar(255) NULL,
    [Description2] nvarchar(255) NULL,
    [TransactionTypeId] int NOT NULL,
    [AccountId] int NOT NULL,
    CONSTRAINT [PK_Transactions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Transactions_Account_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [Account] ([Id]),
    CONSTRAINT [FK_Transactions_TransactionTypes_TransactionTypeId] FOREIGN KEY ([TransactionTypeId]) REFERENCES [TransactionTypes] ([Id])
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

CREATE INDEX [IX_Transactions_AccountId] ON [Transactions] ([AccountId]);

GO

CREATE INDEX [IX_Transactions_TransactionTypeId] ON [Transactions] ([TransactionTypeId]);

GO

CREATE INDEX [IX_TransactionTypes_AccountId] ON [TransactionTypes] ([AccountId]);

GO

CREATE INDEX [IX_UserRole_RoleId] ON [UserRole] ([RoleId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200410160225_initial_1', N'3.1.2');

GO
INSERT INTO [Roles] (Description, CreatedBy, CreatedDate, LastModifiedBy, LastModifiedDate, IsVisible, IsActive) VALUES ('Admin', 0, GetDate(), 0, GetDate(), 1,1);
GO
INSERT INTO [Roles] (Description, CreatedBy, CreatedDate, LastModifiedBy, LastModifiedDate, IsVisible, IsActive) VALUES ('User', 0, GetDate(), 0, GetDate(), 1,1);
GO
INSERT INTO [Users] (Username, Name, PasswordHash,  PasswordSalt, CreatedBy, CreatedDate, LastModifiedBy, LastModifiedDate, IsVisible, IsActive) VALUES ('sa', 'Sys Admin', '619cba5cc7a06c34a8dc43f89a97b55184b43390745ebf87eec7dfd9cf57bb35749796933f28f522077665bebc711e45bc5d6b6976576e02351be70eccf8bbec', 'a102fe31a14c1000709d01231e2d63eaff8a6c27094800fbab7d9a3956a70b79710b3d79fea364541082b92acb36d335dc2157290c7be6f798b5673d3ad7a4fdf4f9dea8a4f3c161366c98a227809b6d8422a55985e9af18494a8d1decba629cd0acdd530d7d54342ab10fcaba2182cdeeb5ab7cadb1d25ca48624fd3b4ac4a5', 0, GetDate(), 0, GetDate(), 1,1); 
