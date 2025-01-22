-- Добавление нового продукта

INSERT INTO products (name, description, price, quantity_in_stock) 
VALUES 
('Манго', 'Описание', 600.23, 300);

-- Обновление цены продукта

UPDATE products SET price = 20
WHERE NAME = 'Бананы';

-- Выбор всех заказов определенного пользователя

SELECT o.*, u.name FROM orders o
INNER JOIN users u ON o.user_id = u.id
WHERE u.id = '5b2b2321-62a9-45d5-9a6d-b628472d4f1b';

-- Выбор всех заказов не определенного пользователя

SELECT o.*, u.name FROM orders o
INNER JOIN users u ON o.user_id = u.id
WHERE u.name LIKE 'Петров%';

-- Расчет общей стоимости заказа

SELECT SUM(od.total_cost) FROM orders o
INNER JOIN order_details od ON o.id = od.order_id
WHERE o.id = 'b71ac771-8eea-44b5-8df7-e4fa892bf8ca';

-- Подсчет количества товаров на складе
-- Не понял вопроса

SELECT SUM(quantity_in_stock) FROM products;

-- Получение 5 самых дорогих товаров

SELECT p.id, p.name, p.price FROM products p
ORDER BY p.price DESC
LIMIT 5;

-- Список товаров с низким запасом (менее 5 штук)

SELECT p.id, p.name, p.quantity_in_stock FROM products p
WHERE p.quantity_in_stock < 5;