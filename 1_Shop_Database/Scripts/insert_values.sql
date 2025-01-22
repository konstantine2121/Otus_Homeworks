-- products

INSERT INTO products (id, name, description, price, quantity_in_stock) 
VALUES ('c3808380-2dab-4914-9831-bc869fc57f58', 'Bananas', 'Bananas Description', 10.23, 100);

-- users

/*
INSERT INTO users (name, email, registration_date) 
VALUES ('Иванов Иван Иванович', 'ivanov@mail.ru', '1994-11-29');
*/

INSERT INTO users (id, name, email, registration_date) 
VALUES ('230cf92e-95d6-404f-8eb2-c88762c05145', 'Иванов Иван Иванович', 'ivanov@mail.ru', '1994-11-29');


-- orders

INSERT INTO orders (id, user_id, date, status) 
VALUES ('1190b35b-114b-4582-9e36-30484a5c951f', '230cf92e-95d6-404f-8eb2-c88762c05145', '2024-01-01', 'Оплачен');

-- order_details

INSERT INTO order_details (order_id, product_id, quantity, total_cost) 
VALUES ('1190b35b-114b-4582-9e36-30484a5c951f', 'c3808380-2dab-4914-9831-bc869fc57f58', 101, 1000.51);