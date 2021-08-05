CREATE TABLE books (
  id BIGINT IDENTITY PRIMARY KEY,
  author VARCHAR(255),
  launch_date DATETIME NOT NULL,
  price decimal(10,2) NOT NULL,
  title VARCHAR(300)
) 
