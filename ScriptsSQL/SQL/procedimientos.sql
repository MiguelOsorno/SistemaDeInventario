use inventario;
CREATE PROCEDURE INSERTAR_PRODUCTO
@ID AS INT, 
@Nombre AS VARCHAR(30),
@descripcion as VARCHAR(90)
AS 
BEGIN 
INSERT producto (identificador,nombre,descripcion)
VALUES(@ID, @Nombre,@descripcion)
END
GO
EXEC INSERTAR_PRODUCTO @ID= 102, @Nombre='paleta',@descripcion='sabor a fresa';

CREATE PROCEDURE INSERTAR_PROVEDOR
@Nombre AS VARCHAR(30),
@Telefono AS VARCHAR(12),
@Direccion AS VARCHAR(50)
AS 
BEGIN
INSERT provedor(nombre, telefono,direccion)
VALUES (@Nombre,@Telefono,@Direccion)
END 
GO 
EXEC INSERTAR_PROVEDOR @Nombre='Marinela', @Telefono='916123458098',@Direccion='col-manzana';

CREATE PROCEDURE INSERTAR_TRANSACCION
@Fecha AS DATETIME,
@IdProducto AS INT,
@IdProvedor AS INT,
@Cantidad AS INT,
@Tipo AS VARCHAR(10)
AS 
BEGIN
IF(@Tipo = 'Salida' and (select cantidad from almacen WHERE idProducto= @IdProducto)>= @Cantidad)
    BEGIN
    INSERT transaccion(fecha,idProducto,idProvedor,cantidad,tipo)
    VALUES(@Fecha,@IdProducto,@idProvedor,@Cantidad,@Tipo)
	END
ELSE
    IF(@Tipo = 'Entrada')
    BEGIN
    INSERT transaccion(fecha,idProducto,idProvedor,cantidad,tipo)
    VALUES(@Fecha,@IdProducto,@idProvedor,@Cantidad,@Tipo)
	END
END
GO
EXEC INSERTAR_TRANSACCION @Fecha='1900-01-01 00:00:00',@IdProducto=20,@IdProvedor=1, @Cantidad=200,@Tipo='Entrada';

CREATE PROCEDURE INSERTAR_ALMACEN
@IdProducto AS INT,
@Cantidad AS INT
AS 
BEGIN
INSERT almacen(idProducto,cantidad)
VALUES(@IdProducto,@Cantidad)
END
GO
EXEC INSERTAR_ALMACEN @IdProducto=20, @Cantidad=200;
////////////////////////////////////////////////////////////////////////////////////////////////
CREATE PROCEDURE MODIFICAR_PRODUCTO
@ID AS INT,
@Nombre AS VARCHAR(30),
@descripcion AS VARCHAR(90)
AS 
BEGIN
UPDATE producto SET nombre=@Nombre, descripcion=@descripcion WHERE identificador=@ID
END
GO
EXEC MODIFICAR_PRODUCTO @Nombre='fritura', @descripcion='papas fritas sabor a limon', @ID=102;

CREATE PROCEDURE MODIFICAR_PROVEDOR
@identificador as int,
@Nombre AS VARCHAR(30),
@Telefono AS VARCHAR(12),
@Direccion AS VARCHAR(50)
AS 
BEGIN
UPDATE provedor SET nombre=@Nombre, telefono=@Telefono, direccion=@Direccion WHERE id=@identificador
END 
GO
EXEC MODIFICAR_PROVEDOR @Telefono='999123456999', @Direccion='Col-Pera', @Nombre='Marinela';

CREATE PROCEDURE MODIFICAR_TRANSACCION
@ID AS INT,
@Fecha AS DATETIME,
@IdProducto AS INT,
@IdProvedor AS INT,
@Cantidad AS INT,
@Tipo AS VARCHAR(10)
AS 
BEGIN
  IF(@Cantidad > (SELECT cantidad FROM almacen WHERE idProducto= @IdProducto) AND @Tipo = 'Salida')
  BEGIN
  PRINT 'no se pudo'
  END
ELSE IF(@cantidad >=0)
  BEGIN
  UPDATE transaccion SET fecha=@Fecha, idProducto=@IdProducto,idProvedor=@IdProvedor, cantidad=@Cantidad, tipo=@Tipo WHERE id=@ID
  END
END 
GO
EXEC MODIFICAR_TRANSACCION @Fecha='2019-12-12 01:00:40', @IdProducto=20,@IdProvedor=1, @Cantidad=400,@Tipo='Salida', @ID=4;

CREATE PROCEDURE MODIFICAR_ALMACEN
@ID AS INT,
@IdProducto AS INT,
@Cantidad AS INT
AS 
BEGIN
UPDATE almacen SET idProducto=@IdProducto, cantidad=@Cantidad WHERE id=@ID
END
GO
EXEC MODIFICAR_ALMACEN @IdProducto=20,@Cantidad=500,@ID=1;
////////////////////////////////////////////////////////////////////////////////////////////////
CREATE PROCEDURE ELIMINAR_PRODUCTO
@ID AS INT 
AS 
BEGIN
DELETE FROM producto WHERE identificador= @ID
END
GO
EXEC ELIMINAR_PRODUCTO @ID=102;

CREATE PROCEDURE ELIMINAR_PROVEDOR
@ID AS INT 
AS 
BEGIN
DELETE FROM provedor WHERE id=@ID
END
GO
EXEC ELIMINAR_PROVEDOR @ID=1;

CREATE PROCEDURE ELIMINAR_TRANSACCION
@ID AS INT 
AS 
BEGIN
DELETE FROM transaccion WHERE id=@ID
END
GO
EXEC ELIMINAR_TRANSACCION @ID=1;

CREATE PROCEDURE ELIMINAR_ALMACEN
@ID AS INT
AS
BEGIN 
DELETE FROM almacen WHERE id=@ID
END
GO
EXEC ELIMINAR_ALMACEN @ID=1;
//////////////////////////////
CREATE PROCEDURE CONSULTA_PRODUCTO
@Identificador AS INT, 
AS 
BEGIN 
select (nombre,descripcion)
from producto
where identificador=@Identificador
END
GO

CREATE PROCEDURE CONSULTA_PRODUCTODOS
@Id AS INT
AS 
BEGIN 
select *
from almacen
where idProducto = @Id
END
GO


///////////////
CREATE PROCEDURE logueo
@usuario AS VARCHAR(10),
@contrasena AS VARCHAR(10)
as
BEGIN
select * from usuarios
where usuario= @usuario and contrasena = @contrasena
END
GO

//////////////////////////////////////// disparadores


CREATE TRIGGER modificarAlmacen
ON transaccion
AFTER INSERT
AS 
BEGIN
DECLARE 
@cantidad AS INT,
@tipo AS VARCHAR(10),
@idProducto AS INT 
SET @cantidad = (SELECT cantidad FROM INSERTED)
print @cantidad
SET @tipo = (SELECT tipo FROM INSERTED)
print @tipo
SET @idProducto = (SELECT idProducto FROM INSERTED)
  IF(@tipo = 'Entrada')
    BEGIN
    UPDATE almacen SET cantidad = (cantidad+@cantidad) where idProducto = @idProducto
    END
  ELSE
    IF(@tipo = 'Salida')
    BEGIN
    UPDATE almacen SET cantidad = (cantidad - @cantidad) WHERE idProducto = @idProducto
    END
END
GO    


CREATE TRIGGER modificarAlmacenActualizacion
ON transaccion
AFTER UPDATE
AS 
BEGIN
DECLARE 
@cantidadAnterior AS INT,
@tipoAnterior AS VARCHAR(10),
@idProductoAnterior AS INT,
@cantidadNueva AS INT,
@tipoNuevo AS VARCHAR(10),
@idProductoNuevo AS INT
SET @cantidadAnterior = (SELECT cantidad FROM DELETED)
SET @tipoAnterior = (SELECT tipo FROM DELETED)
SET @idProductoAnterior = (SELECT idProducto FROM DELETED)
SET @cantidadNueva = (SELECT cantidad FROM INSERTED)
SET @tipoNuevo = (SELECT tipo FROM INSERTED)
SET @idProductoNuevo = (SELECT idProducto FROM INSERTED)
  IF(@tipoAnterior = 'Entrada')
    BEGIN
    UPDATE almacen SET cantidad = (cantidad - @cantidadAnterior) WHERE idProducto = @idProductoAnterior
    END
  ELSE
    IF(@tipoAnterior = 'Salida')
      BEGIN
      UPDATE almacen SET cantidad = (cantidad + @cantidadAnterior) WHERE idProducto = @idProductoAnterior
      END 
 
  IF(@tipoNuevo = 'Entrada')
    BEGIN
    UPDATE almacen SET cantidad = (cantidad + @cantidadNueva) WHERE idProducto = @idProductoNuevo
    END 
  ELSE
    IF(@tipoNuevo = 'Salida')
    BEGIN
    UPDATE almacen SET cantidad = (cantidad - @cantidadNueva) WHERE idProducto = @idProductoNuevo
    END
END
GO