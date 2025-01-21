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
