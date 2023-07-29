--- 1)müþteri sipariþ verdiði zaman müþterinin loyalty points'ini artýrmak, ürün stoklarýný güncellemek ve sipariþleri kaydetmek 
--- 2)müþterinin adýný veya adresini güncellemek ve müþterinin favori ürünlerinden birini silmek
--- 3)yeni bir müþteri eklemek ve bu müþteriye ait bir sipariþ kaydetmek

use eCommerce

BEGIN TRANSACTION;

DECLARE @CustomerID INT;
DECLARE @ProductID INT;
DECLARE @OrderID INT;

DECLARE @CustomerEmail VARCHAR(50) = 'musteri@email.com';
DECLARE @ProductPrice DECIMAL(5, 2);
DECLARE @ProductStock INT;
DECLARE @Quantity INT = 3;

SELECT @CustomerID = [id]
FROM [dbo].[customers]
WHERE [email] = @CustomerEmail;

UPDATE [dbo].[premium_customers]
SET [loyalty_points] = [loyalty_points] + 10
WHERE [id] = @CustomerID;

SELECT @ProductID = [id], @ProductPrice = [price], @ProductStock = [stock]
FROM [dbo].[products]
WHERE [name] = 'Ürün Adý';

IF @ProductStock >= @Quantity
BEGIN
    UPDATE [dbo].[products]
    SET [stock] = [stock] - @Quantity
    WHERE [id] = @ProductID;
    
    INSERT INTO [dbo].[orders] ([customers_id], [purchase_date])
    VALUES (@CustomerID, GETDATE());

    SET @OrderID = SCOPE_IDENTITY();

    INSERT INTO [dbo].[order_items] ([orders_id], [items_id])
    VALUES (@OrderID, @ProductID);

    INSERT INTO [dbo].[price_change_logs] ([product_id], [old_price], [new_price], [change_date])
    VALUES (@ProductID, @ProductPrice, @ProductPrice, GETDATE());

    COMMIT TRANSACTION;
END
ELSE
BEGIN
    ROLLBACK TRANSACTION;
    PRINT 'Ürün stoklarý yetersiz!';
END



BEGIN TRANSACTION;

DECLARE @CustomerID INT;
DECLARE @NewFirstName VARCHAR(50) = 'Yeni Ad';
DECLARE @NewAddress VARCHAR(50) = 'Yeni Adres';
DECLARE @ProductIDToRemove INT = 123;

SELECT @CustomerID = [id]
FROM [dbo].[customers]
WHERE [email] = 'musteri@email.com';

UPDATE [dbo].[customers]
SET [first_name] = @NewFirstName, [addresses_id] = (SELECT [id] FROM [dbo].[addresses] WHERE [street] = @NewAddress)
WHERE [id] = @CustomerID;

DELETE FROM [dbo].[customers_has_favorite_products]
WHERE [customers_id] = @CustomerID AND [products_id] = @ProductIDToRemove;

COMMIT TRANSACTION;



BEGIN TRANSACTION;

DECLARE @NewCustomerID INT;
DECLARE @NewCustomerEmail VARCHAR(50) = 'musteri@email.com';
DECLARE @NewCustomerFirstName VARCHAR(50) = 'Yeni Ad';
DECLARE @NewCustomerLastName VARCHAR(50) = 'Yeni Soyad';
DECLARE @ProductID INT = 456; 
DECLARE @Quantity INT = 2; 

INSERT INTO [dbo].[customers] ([email], [first_name], [last_name])
VALUES (@NewCustomerEmail, @NewCustomerFirstName, @NewCustomerLastName);

SET @NewCustomerID = SCOPE_IDENTITY();

INSERT INTO [dbo].[orders] ([customers_id], [purchase_date])
VALUES (@NewCustomerID, GETDATE());

DECLARE @NewOrderID INT;
SET @NewOrderID = SCOPE_IDENTITY();

INSERT INTO [dbo].[order_items] ([orders_id], [items_id], [quantity])
VALUES (@NewOrderID, @ProductID, @Quantity);

COMMIT TRANSACTION;
