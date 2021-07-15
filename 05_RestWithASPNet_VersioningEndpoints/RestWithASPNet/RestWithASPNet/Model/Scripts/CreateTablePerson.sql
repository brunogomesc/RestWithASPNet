CREATE TABLE person (
id bigint primary key identity,
adress varchar(100) not null,
first_name varchar(80) not null,
last_name varchar(80) not null,
gender varchar(6) not null
)