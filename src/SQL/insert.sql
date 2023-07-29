Use eCommerce
Go

INSERT INTO [dbo].[brands] ([name], [description])
VALUES
    ('Brand A', 'Description of Brand A'),
    ('Brand B', 'Description of Brand B');

Go

INSERT INTO [dbo].[addresses] ([state], [city], [street], [number])
VALUES
    ('State 1', 'City 1', 'Street 1', 123),
    ('State 2', 'City 2', 'Street 2', 456);

Go

INSERT INTO [dbo].[categories] ([name], [description])
VALUES
    ('Category 1', 'Description of Category 1'),
    ('Category 2', 'Description of Category 2');

Go

INSERT INTO [dbo].[products] ([name], [description], [price], [warranty], [brands_id])
VALUES
    ('Product 1', 'Description of Product 1', 50.00, 1, 1),
    ('Product 2', 'Description of Product 2', 75.00, 2, 2);

Go

INSERT INTO [dbo].[customers] ([email], [first_name], [last_name], [addresses_id])
VALUES
    ('customer1@example.com', 'John', 'Doe', 1),
    ('customer2@example.com', 'Jane', 'Smith', 2);

Go

INSERT INTO [dbo].[premium_customers] ([id], [loyalty_points], [preferred_brand])
VALUES
    (1, 100, 1);

Go

INSERT INTO [dbo].[categories_has_products] ([categories_id], [products_id])
VALUES
    (1, 1), 
    (2, 2);

Go

INSERT INTO [dbo].[items] ([production_date], [products_id])
VALUES
    ('2023-07-01', 1), 
    ('2023-07-15', 2);

Go

INSERT INTO [dbo].[order_items] ([orders_id], [items_id])
VALUES
    (1, 1),
    (2, 2);

Go

INSERT INTO [dbo].[orders] ([customers_id], [purchase_date])
VALUES
    (1, '2023-07-20 10:30:00'), 
    (2, '2023-07-25 14:45:00');

Go

INSERT INTO [dbo].[customers_has_favorite_products] ([customers_id], [products_id])
VALUES
    (1, 1), 
    (2, 2);

Go

INSERT INTO [dbo].[reviews] ([customers_id], [products_id], [rating], [description])
VALUES
    (1, 1, 5, 'Excellent product!'),
    (2, 2, 4, 'Good product, but could be better.');

Go

INSERT INTO [dbo].[product_details] ([product_id], [color], [size])
VALUES
    (1, 'Red', 'Medium'), 
    (2, 'Blue', 'Large');

Go

INSERT INTO [dbo].[price_change_logs] ([product_id], [old_price], [new_price], [change_date])
VALUES
    (1, 50.00, 45.00, '2023-07-10 12:00:00'),
    (2, 75.00, 80.00, '2023-07-18 15:30:00');







