CREATE TABLE Y_Address
(
    id INT NOT NULL IDENTITY(1,1),
    road VARCHAR(100),
    city VARCHAR(100),
    floor INT,
    code_postal VARCHAR(5),
    CONSTRAINT PK_address PRIMARY KEY (id)
);

CREATE TABLE Y_Phone
(
    id INT NOT NULL IDENTITY(1,1),
    name VARCHAR(100),
    number VARCHAR(100),
    CONSTRAINT PK_phone PRIMARY KEY (id)
);

CREATE TABLE Y_Product
(
    id INT NOT NULL IDENTITY(1,1),
    name VARCHAR(100),
    descritption VARCHAR(255),
    stock INT,
    price FLOAT,
    replenishmentDate DateTime,
    CONSTRAINT PK_product PRIMARY KEY (id)
);

	 CREATE TABLE Y_User(
    id INT NOT NULL IDENTITY(1,1),
    firstname VARCHAR(100),
    lastname VARCHAR(100),
    email VARCHAR(100),
    passwordHash varchar (255),
    salt varchar (255),
    registration DateTime,
    isEnable bit,
    id_yaddress INT NOT NULL,
    id_yphone INT NOT NULL,

    CONSTRAINT PK_user PRIMARY KEY (id),
    CONSTRAINT FK_yuseryphone FOREIGN KEY (id_yphone) REFERENCES Y_Phone(id),
    CONSTRAINT FK_yuseryaddress FOREIGN KEY (id_yaddress) REFERENCES Y_Address(id)
);

CREATE TABLE Y_Product_Purchase
(
    id_yuser INT NOT NULL,
    id_yproduct INT NOT NULL,
    purchaseDate DateTime,
    CONSTRAINT PK_userproduct PRIMARY KEY (id_yuser,id_yproduct),
    CONSTRAINT FK_userproductpurchase FOREIGN KEY (id_yuser) REFERENCES Y_User(id),
    CONSTRAINT FK_productproductpurchase FOREIGN KEY (id_yproduct) REFERENCES Y_Product(id)
);

