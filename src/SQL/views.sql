--- customer details
CREATE VIEW customer_details_view AS
SELECT customers.id, customers.email, customers.first_name, customers.last_name,
       addresses.state, addresses.city, addresses.street, addresses.number,
       reviews.rating, reviews.description
FROM customers
LEFT JOIN addresses ON customers.addresses_id = addresses.id
LEFT JOIN reviews ON customers.id = reviews.customers_id;

--- products detail
CREATE VIEW product_details_view AS
SELECT products.id, products.name, products.description, products.price, products.warranty,
       categories.name AS category, brands.name AS brand, items.production_date
FROM products
LEFT JOIN categories_has_products ON products.id = categories_has_products.products_id
LEFT JOIN categories ON categories_has_products.categories_id = categories.id
LEFT JOIN brands ON products.brands_id = brands.id
LEFT JOIN items ON products.id = items.products_id;

--- review details
CREATE VIEW product_details_with_cond_view AS
SELECT products.id, products.name, products.description, products.price, products.warranty,
       categories.name AS category, brands.name AS brand, items.production_date
FROM products
LEFT JOIN categories_has_products ON products.id = categories_has_products.products_id
LEFT JOIN categories ON categories_has_products.categories_id = categories.id
LEFT JOIN brands ON products.brands_id = brands.id
LEFT JOIN items ON products.id = items.products_id
WHERE items.production_date < '2022-01-01';

--- 2022 den küçük tarihler için Product details
CREATE VIEW review_details_view AS
SELECT products.id, products.name AS product_name, products.description AS product_description, products.price, products.warranty,
       customers.first_name, customers.last_name,
       reviews.rating, reviews.description AS review_description
FROM products
INNER JOIN reviews ON products.id = reviews.products_id
INNER JOIN customers ON reviews.customers_id = customers.id;










