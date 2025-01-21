-- products

INSERT INTO products (name, description, price, quantity_in_stock) 
VALUES ('Bananas', 'Bananas Description', 10.23, 100);

-- users

/*
INSERT INTO users (name, email, registration_date) 
VALUES ('Иванов Иван Иванович', 'ivanov@mail.ru', '1994-11-29');
*/

INSERT INTO users (id, name, email, registration_date) 
VALUES ('230cf92e-95d6-404f-8eb2-c88762c05145', 'Иванов Иван Иванович', 'ivanov@mail.ru', '1994-11-29');


-- orders

INSERT INTO orders (user_id, date, status) 
VALUES ('230cf92e-95d6-404f-8eb2-c88762c05145', '2024-01-01', 'Оплачен');

-- order_details

INSERT INTO order_details (order_id, product_id, quantity, total_cost) 
VALUES ('80318147-c108-4c7b-8b09-28d45c950ef4', '73d60476-4ad5-4e6e-88f1-92a79553bed4', 101, 1000.51);