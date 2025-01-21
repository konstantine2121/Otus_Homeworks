-- подключаем модуль pgcrypto для использования функции gen_random_uuid
CREATE EXTENSION IF NOT EXISTS pgcrypto;

DROP TABLE IF EXISTS products;
/*
1. Таблица "Products" (Продукты):

- ProductID (Основной ключ)
- ProductName (Название продукта)
- Description (Описание)
- Price (Цена)
- QuantityInStock (Количество на складе)  
*/

CREATE TABLE products
(
id                  UUID             PRIMARY KEY DEFAULT gen_random_uuid(),
name                varchar(255),
description         varchar(255),
price               money            NOT NULL,
quantity_in_stock   BIGINT           NOT NULL
);


/*
Таблица "Users" (Пользователи):

- UserID (Основной ключ)
- UserName (Имя пользователя)
- Email (Электронная почта)
- RegistrationDate (Дата регистрации)  
*/

DROP TABLE IF EXISTS users;
CREATE TABLE users
(
id                  UUID             PRIMARY KEY DEFAULT gen_random_uuid(),
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

DROP TABLE IF EXISTS orders;
CREATE TABLE orders
(
id                  UUID             PRIMARY KEY DEFAULT gen_random_uuid(),
user_id             UUID             NOT NULL,
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

DROP TABLE IF EXISTS order_details;
CREATE TABLE order_details
(
id                  UUID             PRIMARY KEY DEFAULT gen_random_uuid(),
order_id            UUID             NOT NULL,
product_id          UUID             NOT NULL,
quantity            BIGINT           NOT NULL,
total_cost          money            NOT NULL
);