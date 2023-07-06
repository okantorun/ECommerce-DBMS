GO
CREATE TRIGGER trg_update_product_price
ON products
AFTER UPDATE
AS
BEGIN
    IF UPDATE(price)
    BEGIN
        DECLARE @oldPrice DECIMAL(5, 2), @newPrice DECIMAL(5, 2);
        
        SELECT @oldPrice = price FROM deleted;
        SELECT @newPrice = price FROM inserted;
        
        IF @oldPrice <> @newPrice
        BEGIN     
            INSERT INTO price_change_logs (product_id, old_price, new_price, change_date)
            SELECT id, @oldPrice, @newPrice, GETDATE() FROM products WHERE id IN (SELECT id FROM inserted);
        END
    END
END



GO
CREATE TRIGGER trg_delete_order
ON orders
INSTEAD OF DELETE
AS
BEGIN
    DECLARE @customerId INT;

    SELECT @customerId = customers_id
    FROM deleted;

    DELETE FROM order_items
    WHERE orders_id IN (SELECT id FROM deleted);

    DELETE FROM orders
    WHERE customers_id = @customerId;
END


GO
CREATE TRIGGER trg_delete_category
ON categories
AFTER DELETE
AS
BEGIN
    DECLARE @categoryId INT;

    SELECT @categoryId = id
    FROM deleted;

    DELETE FROM categories_has_products
   