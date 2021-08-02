CREATE TABLE users (
id int primary key identity,
users varchar(255) unique not null default '0',
pass varchar(100) not null default '0',
full_name varchar(300) not null,
refresh_token varchar(500) not null default '0',
refresh_token_expiry_time datetime default null
)