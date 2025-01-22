-- подключаем модуль pgcrypto для использования функции gen_random_uuid
CREATE EXTENSION IF NOT EXISTS pgcrypto;


/*
1. Таблица "Products" (Продукты):

- ProductID (Основной ключ)
- ProductName (Название продукта)
- Description (Описание)
- Price (Цена)
- QuantityInStock (Количество на складе)  
*/
DROP TABLE IF EXISTS products CASCADE;

CREATE TABLE products
(
id                  UUID             PRIMARY KEY NOT NULL DEFAULT gen_random_uuid(),
name                varchar(255),
description         varchar(255),
price               numeric          NOT NULL,
quantity_in_stock   BIGINT           NOT NULL
);


/*
Таблица "Users" (Пользователи):

- UserID (Основной ключ)
- UserName (Имя пользователя)
- Email (Электронная почта)
- RegistrationDate (Дата регистрации)  
*/

DROP TABLE IF EXISTS users CASCADE;

CREATE TABLE users
(
id                  UUID             PRIMARY KEY NOT NULL DEFAULT gen_random_uuid(),
name                varchar(255)     NOT NULL,
email               varchar(255)     NOT NULL,
registration_date   date
);


/*
Таблица "Orders" (Заказы):

- OrderID (Основной ключ)
- UserID (Внешний ключ)
- OrderDate (Дата заказа)
- Status (Статус)   
*/

DROP TABLE IF EXISTS orders CASCADE;

CREATE TABLE orders
(
id                  UUID             PRIMARY KEY NOT NULL DEFAULT gen_random_uuid(),
user_id             UUID             REFERENCES users (id),
date                date,
status              varchar(255)
);


/*
Таблица "OrderDetails" (Детали заказа):

- OrderDetailID (Основной ключ)
- OrderID (Внешний ключ)
- ProductID (Внешний ключ)
- Quantity (Количество)
- TotalCost (Общая стоимость)  
*/

DROP TABLE IF EXISTS order_details CASCADE;

CREATE TABLE order_details
(
id                  UUID             PRIMARY KEY NOT NULL DEFAULT gen_random_uuid(),
order_id            UUID             REFERENCES orders (id),
product_id          UUID             REFERENCES products (id),
quantity            BIGINT           NOT NULL,
total_cost          numeric          NOT NULL
);