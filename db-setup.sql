-- USE firefund

-- CREATE TABLE rooms (
--     id int NOT NULL AUTO_INCREMENT,
--     name VARCHAR(255) NOT NULL,
--     description VARCHAR(255) NOT NULL,
--     imgUrl varchar(255),
--     userId VARCHAR(255),
--     INDEX userId (userId),
--     PRIMARY KEY (id)
-- );


--  CREATE TABLE categories (
--     id INT NOT NULL AUTO_INCREMENT,
--     name VARCHAR(255) NOT NULL,
--     description VARCHAR(255),
--     roomId INT NOT NULL,
--     imgUrl varchar(255),
--     userId VARCHAR(255),
--     INDEX userId (userId),
--     PRIMARY KEY (id),
--     FOREIGN KEY (roomId)
--       REFERENCES rooms(id)
--         ON DELETE CASCADE
-- )

-- CREATE TABLE items (
--     id int NOT NULL AUTO_INCREMENT,
--     name VARCHAR(255) NOT NULL,
--     description VARCHAR(255) NOT NULL,
--     userId VARCHAR(255),
--     imgUrl VARCHAR(255),
--     quantity INT,
--     acv INT,
--     rcv INT,
--     categoryId INT NOT NULL,
--     INDEX userId (userId),
--     PRIMARY KEY (id),

--     FOREIGN KEY (categoryId)
--         REFERENCES categories(id)
--         ON DELETE CASCADE
-- );

-- ALTER TABLE categories
-- ADD imgUrl varchar(255);

-- -- USE THIS TO CLEAN OUT YOUR DATABASE
-- DROP TABLE IF EXISTS rooms;
-- DROP TABLE IF EXISTS ;
-- DROP TABLE IF EXISTS categories;
-- DROP TABLE IF EXISTS items;
