CREATE TABLE [dbo].[Y_Product_Purchase] (
    [id_yuser]     INT      NOT NULL,
    [id_yproduct]  INT      NOT NULL,
    [purchaseDate] DATETIME NULL,
    [id] INT NOT NULL, 
    CONSTRAINT [PK_userproduct] PRIMARY KEY CLUSTERED ([id]),
    CONSTRAINT [FK_userproductpurchase] FOREIGN KEY ([id_yuser]) REFERENCES [dbo].[Y_User] ([id]),
    CONSTRAINT [FK_productproductpurchase] FOREIGN KEY ([id_yproduct]) REFERENCES [dbo].[Y_Product] ([id])
);

CREATE TABLE [dbo].[Y_Address] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [road]        VARCHAR (100) NULL,
    [city]        VARCHAR (100) NULL,
    [floor]       INT           NULL,
    [code_postal] VARCHAR (5)   NULL,
    CONSTRAINT [PK_address] PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [dbo].[Y_Phone] (
    [id]     INT           IDENTITY (1, 1) NOT NULL,
    [name]   VARCHAR (100) NULL,
    [number] VARCHAR (100) NULL,
    CONSTRAINT [PK_phone] PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [dbo].[Y_User] (
    [id]           INT           IDENTITY (1, 1) NOT NULL,
    [firstname]    VARCHAR (100) NULL,
    [lastname]     VARCHAR (100) NULL,
    [email]        NVARCHAR(100) NOT NULL UNIQUE,
    [passwordHash] VARCHAR (255) NULL,
    [salt]         VARCHAR (255) NULL,
    [registration] DATETIME      NULL,
    [isEnable]     BIT           NULL,
    [id_yaddress]  INT           NULL,
    [id_yphone]    INT           NULL,
    CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [dbo].[Y_Product] (
    [id]                INT           IDENTITY (1, 1) NOT NULL,
    [name]              VARCHAR (100) NULL,
    [descritption]      VARCHAR (255) NULL,
    [stock]             INT           NULL,
    [price]             FLOAT (53)    NULL,
    [replenishmentDate] DATETIME      NULL,
    CONSTRAINT [PK_product] PRIMARY KEY CLUSTERED ([id] ASC)
);


