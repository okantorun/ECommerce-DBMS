CREATE TABLE [dbo].[brands] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [name]        VARCHAR (50)  NULL,
    [description] VARCHAR (300) NULL,
    CONSTRAINT [PK_brands] PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [dbo].[addresses] (
    [id]     INT          IDENTITY (1, 1) NOT NULL,
    [state]  VARCHAR (50) NULL,
    [city]   VARCHAR (50) NULL,
    [street] VARCHAR (50) NULL,
    [number] INT          NULL,
    CONSTRAINT [PK_addresses] PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [dbo].[categories] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [name]        VARCHAR (50)  NULL,
    [description] VARCHAR (300) NULL,
    CONSTRAINT [PK_categories] PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [dbo].[categories_has_products] (
    [categories_id] INT NULL,
    [products_id]   INT NULL,
    CONSTRAINT [FK_categories_has_products_products] FOREIGN KEY ([products_id]) REFERENCES [dbo].[products] ([id])
);

CREATE TABLE [dbo].[customer_orders_products] (
    [customers_id] INT NOT NULL,
    [orders_id]    INT NOT NULL,
    [products_id]  INT NOT NULL,
    CONSTRAINT [FK_customer_orders_products_customers] FOREIGN KEY ([customers_id]) REFERENCES [dbo].[customers] ([id]),
    CONSTRAINT [FK_customer_orders_products_orders] FOREIGN KEY ([orders_id]) REFERENCES [dbo].[orders] ([id]),
    CONSTRAINT [FK_customer_orders_products_products] FOREIGN KEY ([products_id]) REFERENCES [dbo].[products] ([id])
);

CREATE TABLE [dbo].[customers] (
    [id]           INT          IDENTITY (1, 1) NOT NULL,
    [email]        VARCHAR (50) NULL,
    [first_name]   VARCHAR (50) NULL,
    [last_name]    VARCHAR (50) NULL,
    [addresses_id] INT          NULL,
    CONSTRAINT [PK_customers] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_customers_addresses] FOREIGN KEY ([addresses_id]) REFERENCES [dbo].[addresses] ([id])
);

CREATE TABLE [dbo].[customers_has_favorite_products] (
    [customers_id] INT NULL,
    [products_id]  INT NULL,
    CONSTRAINT [FK_customers_has_favorite_products_customers] FOREIGN KEY ([customers_id]) REFERENCES [dbo].[customers] ([id]),
    CONSTRAINT [FK_customers_has_favorite_products_products] FOREIGN KEY ([products_id]) REFERENCES [dbo].[products] ([id])
);

CREATE TABLE [dbo].[items] (
    [id]              INT  IDENTITY (1, 1) NOT NULL,
    [production_date] DATE NULL,
    [products_id]     INT  NULL,
    CONSTRAINT [PK_items] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_items_products] FOREIGN KEY ([products_id]) REFERENCES [dbo].[products] ([id])
);

CREATE TABLE [dbo].[order_items] (
    [orders_id] INT NULL,
    [items_id]  INT NULL,
    CONSTRAINT [FK_order_items_items] FOREIGN KEY ([items_id]) REFERENCES [dbo].[items] ([id])
);

CREATE TABLE [dbo].[orders] (
    [id]            INT      IDENTITY (1, 1) NOT NULL,
    [customers_id]  INT      NULL,
    [purchase_date] DATETIME NULL,
    CONSTRAINT [PK_orders] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_orders_customers] FOREIGN KEY ([customers_id]) REFERENCES [dbo].[customers] ([id])
);
CREATE TABLE [dbo].[premium_customers] (
    [id]              INT NOT NULL,
    [loyalty_points]  INT NULL,
    [preferred_brand] INT NULL,
    CONSTRAINT [PK_premium_customers] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_premium_customers_customers] FOREIGN KEY ([id]) REFERENCES [dbo].[customers] ([id])
);

CREATE TABLE [dbo].[reviews] (
    [customers_id] INT          NOT NULL,
    [products_id]  INT          NULL,
    [rating]       INT          NULL,
    [description]  VARCHAR (50) NULL,
    CONSTRAINT [FK_reviews_customers] FOREIGN KEY ([customers_id]) REFERENCES [dbo].[customers] ([id]),
    CONSTRAINT [FK_reviews_products] FOREIGN KEY ([products_id]) REFERENCES [dbo].[products] ([id])
);

CREATE TABLE [dbo].[products] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [name]        VARCHAR (50)   NULL,
    [description] VARCHAR (50)   NULL,
    [price]       DECIMAL (5, 2) NULL,
    [warranty]    INT            NULL,
    [brands_id]   INT            NULL,
    CONSTRAINT [PK_products] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_products_brands] FOREIGN KEY ([brands_id]) REFERENCES [dbo].[brands] ([id])
);

CREATE TABLE [dbo].[product_details] (
    [product_id] INT          NOT NULL,
    [color]      VARCHAR (20) NULL,
    [size]       VARCHAR (10) NULL,
    CONSTRAINT [FK_product_details_products] FOREIGN KEY ([product_id]) REFERENCES [dbo].[products] ([id])
);

CREATE TABLE [dbo].[price_change_logs] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [product_id]  INT            NOT NULL,
    [old_price]   DECIMAL (5, 2) NOT NULL,
    [new_price]   DECIMAL (5, 2) NOT NULL,
    [change_date] DATETIME       NOT NULL,
    CONSTRAINT [PK_price_change_logs] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_price_change_logs_products] FOREIGN KEY ([product_id]) REFERENCES [dbo].[products] ([id])
);

