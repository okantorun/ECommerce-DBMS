SELECT * FROM addresses
GO
INSERT INTO addresses (state, city, street, number) VALUES (@State, @City, @Street, @Number)
GO
SELECT * FROM addresses



UPDATE addresses SET city = @NewCity WHERE id = @Id
GO
SELECT * FROM addresses


DELETE FROM addresses WHERE id = @Id
GO
SELECT * FROM addresses



INSERT INTO customers (email, first_name, last_name, addresses_id) VALUES (@Email, @FirstName, @LastName, @AddressId)
GO
SELECT * FROM customers


UPDATE customers SET first_name = @NewFirstName WHERE id = @CustomerId
GO
SELECT * FROM customers



DELETE FROM customers WHERE id = @Id
GO
SELECT * FROM customers


SELECT * FROM brands


INSERT INTO brands (name, description) VALUES (@Name, @Description)
GO
SELECT * FROM brands

UPDATE brands SET description = @NewDescription WHERE id = @Id
GO


SELECT * FROM brands


DELETE FROM brands WHERE id = @Id
GO
SELECT * FROM brands



CREATE TABLE [dbo].[customers] (
    [id]           INT          IDENTITY (1, 1) NOT NULL,
    [email]        VARCHAR (50) NULL,
    [first_name]   VARCHAR (50) NULL,
    [last_name]    VARCHAR (50) NULL,
    [addresses_id] INT          NULL,
    CONSTRAINT [PK_customers] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_customers_addresses] FOREIGN KEY ([addresses_id]) REFERENCES [dbo].[addresses] ([id])
);



SELECT *From reviews
GO
SELECT *From review_details_view



SELECT *From customers
GO
SELECT * FROM customer_details_view




SELECT *From products
GO
SELECT * FROM product_details_view



SELECT *From products
GO
SELECT *FROM product_details_with_cond_view


UPDATE products SET price = 19.99 WHERE id = 7
UPDATE products SET price = 29.99 WHERE id = 8
SELECT *FROM price_change_logs

--------------------------------------------------

SELECT *FROM categories_has_products
DELETE FROM categories WHERE id = 7
SELECT *FROM categories_has_products

---------------------------------------------------

SELECT *FROM order_items
DELETE FROM orders WHERE id = 2
SELECT *FROM order_items


