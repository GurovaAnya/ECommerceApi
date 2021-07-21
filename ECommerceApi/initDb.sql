create database if not exists ecommercedb ;

use ecommercedb;

create table item
(
    id int auto_increment
        primary key,
    sku varchar(255) not null,
    name varchar(255) not null,
    type varchar(255) not null,
    price decimal not null,
    constraint item_sku_uindex
        unique (sku)
);

create index ix_item_price
	on item (price)
    using BTREE;

create index ix_item_type
    on item(price)
    using HASH;

INSERT INTO item (sku, name, type, price) VALUES ('AA/01/001', 'iPhone 14', 'Phone', 999);
INSERT INTO item (sku, name, type, price) VALUES ('AA/01/002', 'Samsung Galaxy Note 50', 'Phone', 998);
INSERT INTO item (sku, name, type, price) VALUES ('BB/29/324', 'iPad 10', 'Tablet', 1499);
INSERT INTO item (sku, name, type, price) VALUES ('AB/93/485', 'miBand', 'Smart Watch', 9);

COMMIT;
