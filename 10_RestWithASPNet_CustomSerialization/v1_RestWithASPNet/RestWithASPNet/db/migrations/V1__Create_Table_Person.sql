CREATE TABLE person (
id bigint primary key identity,
first_name varchar(80) not null,
last_name varchar(80) not null,
adress varchar(100) not null,
gender varchar(6) not null
)