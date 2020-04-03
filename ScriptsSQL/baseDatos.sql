CREATE DATABASE inventario;
USE  inventario;
CREATE TABLE producto(
    id INT IDENTITY (1,1) NOT NULL,
    identificador INT NOT NULL,
    nombre VARCHAR(30) NOT NULL,
    descripcion varchar(90) NOT NULL,
    CONSTRAINT PK_producto PRIMARY KEY(id)
);
CREATE TABLE provedor(
    id INT IDENTITY(1,1) NOT NULL,
    nombre VARCHAR(30) NOT NULL,
    telefono VARCHAR(12) NOT NULL,
    direccion VARCHAR(50) NOT NULL,
    CONSTRAINT PK_provedor PRIMARY KEY(id)
);
CREATE TABLE transaccion(
    id INT IDENTITY(1,1) NOT NULL,
    fecha DATETIME NOT NULL,
    idProducto INT NOT NULL,
    idProvedor int,
    cantidad INT NOT NULL,
    tipo VARCHAR(10) NOT NULL,
    CONSTRAINT PK_entrada PRIMARY KEY(id),
    CONSTRAINT FK_productoEntrada FOREIGN KEY(idProducto) REFERENCES producto(id),
    CONSTRAINT FK_provedor FOREIGN KEY(idProvedor) REFERENCES provedor(id)
);
CREATE TABLE almacen(
    id INT IDENTITY(1,1) NOT NULL,
    idProducto INT NOT NULL,
    cantidad INT NOT NULL,
    CONSTRAINT PK_almacen PRIMARY KEY(id),
    CONSTRAINT FK_productoAlmacen FOREIGN KEY(idProducto) REFERENCES producto(id)
);

CREATE TABLE usuarios(
    usuario VARCHAR(10) NOT NULL,
    contrasena VARCHAR(10) NOT NULL,
    CONSTRAINT PK_usuario PRIMARY KEY(usuario)
);