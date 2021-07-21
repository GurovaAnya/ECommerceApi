# ECommerceApi

Приложение предоставляет api для управления товарами электронной коммерции. Выполнено в рамках тестового задания в Xsolla School.

Приложение выложено на публичный хостинг heroku: https://ayo-commerce-api.herokuapp.com.

Спецификация OpenApi: https://ayo-commerce-api.herokuapp.com/swagger.

## Что интересного

- Бытрое развертывание приложения через docker compose ([docker-compose.yml](ECommerceApi/docker-compose.yml)).
- Создание базы данных при установке через docker compose (начальные миграции в файле [ititDb.sql](ECommerceApi/initDb.sql)).
- Созданы индексы на элементы фильтрации: первичный - идентификатор; уникальный - SKU; hash - тип (быстрый, но работает только с выражением =); b-tree (помедленнее и побольше, но хорош при поиске по диапазону).
- Добавлен pipeline деплоя на heroku в файле [main.yml](.github/workflows/main.yml).

## Технологии

Используемые технологии:

- .NET 5.0
- Entity Framework
- MySql
- Docker

## Установка

Для установки необходим [Docker](https://www.docker.com/products/docker-desktop) .

1. Перейти в папку проекта
```
cd ECommerceApi
```
2. Запустить docker compose
```
docker-compose up
```
