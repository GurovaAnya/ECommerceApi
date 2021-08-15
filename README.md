# ECommerceApi

Приложение предоставляет api для управления товарами электронной коммерции. Выполнено в рамках тестового задания в Xsolla School.

Приложение выложено на публичный хостинг heroku: https://ayo-commerce-api.herokuapp.com.
Спецификация OpenApi: https://ayo-commerce-api.herokuapp.com/swagger.

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

## GraphQl эндпоинт /graphql

Получение списка товаров:
```
query{
  items{
    id
    name
    sku
    ...
  }
}
 ```
 Получение товара по идентификатору:
 ```
 query{
  item (id: "1"){
    id
    name
    sku
    ...
  }
}
 ```
