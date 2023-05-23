CREATE PROCEDURE sp_Agregar_categoria
(
@nombCate nvarchar(50),
@descripcionCate nvarchar(50)
)
AS
BEGIN
	INSERT INTO categoria (nombCate,descripcionCate,ESTADO)
	VALUES(@nombCate,@descripcionCate,'A')
END
go

CREATE PROCEDURE sp_Actualizar_categoria
(
@id_categoria int,
@nombCate nvarchar(50),
@descripcionCate nvarchar(50),
@ESTADO nvarchar(1)
)
AS
BEGIN
	UPDATE categoria SET nombCate= @nombCate,descripcionCate= @descripcionCate, ESTADO= @ESTADO WHERE id_categoria = @id_categoria
END
go

CREATE PROCEDURE sp_agregar_compra
(
@NUMERO varchar(20),
@PREFIJO varchar(20),
@TIPO_DOCUMENTO varchar(20),
@FECHA datetime,  --la obtengo de datos ingresados por el usuario yyyyMMdd
@PROVEEDOR varchar(6),
@DIRECCION text,
@SUMAS decimal(12, 2),
@IVA decimal(12, 2),
@CreatedBy varchar(20),
@CreateDate datetime -- = GETDATE()
)
AS
BEGIN
	INSERT INTO COMPRA(NUMERO,PREFIJO,TIPO_DOCUMENTO,FECHA,PROVEEDOR,DIRECCION,SUMAS,IVA,CreatedBy,CreateDate)
    VALUES(@NUMERO,@PREFIJO,@TIPO_DOCUMENTO,@FECHA,@PROVEEDOR,@DIRECCION,@SUMAS,@IVA,@CreatedBy,@CreateDate)
END



go

CREATE PROCEDURE sp_Insertar_Detalle_Compra
(
@NUMERO varchar(20),
@PREFIJO varchar(20),
@TIPO_DOCUMENTO varchar(20),
@PRODUCTO int,
@CANTIDAD decimal(12, 2),
@PRECIO_UNITARIO decimal(12, 2),
@TOTAL decimal(12, 2),
@LINEA int,
@CreatedBy varchar(20),
@CreateDate datetime, -- = GETDATE()
@DESCRIPCION text,
@IMPUESTO_PRODUCTO decimal(12, 8)
)
AS
BEGIN
	INSERT INTO Detalle_Compra(NUMERO,PREFIJO,TIPO_DOCUMENTO,PRODUCTO,CANTIDAD,PRECIO_UNITARIO,TOTAL,LINEA,CreatedBy,CreateDate,DESCRIPCION,IMPUESTO_PRODUCTO)
    VALUES(@NUMERO,@PREFIJO,@TIPO_DOCUMENTO,@PRODUCTO,@CANTIDAD,@PRECIO_UNITARIO,@TOTAL,@LINEA,@CreatedBy,@CreateDate,@DESCRIPCION,@IMPUESTO_PRODUCTO)
END
go

CREATE PROCEDURE sp_Insertar_Movimiento
(
@id_producto int,
@TipoMovi char(1),
@cantidad int,
@total money,
@fecha date --la obtengo de datos ingresados por el usuario yyyyMMdd
)
AS
BEGIN
	INSERT INTO MOVIMIENTO(id_producto,TipoMovi,cantidad,total,fecha)
    VALUES(@id_producto,@TipoMovi,@cantidad,@total,@fecha)
END
go

CREATE PROCEDURE sp_Insertar_Factura
(
@NUMERO varchar(20),
@PREFIJO varchar(20),
@TIPO_FACTURA varchar(20),
@FECHA datetime,--la obtengo de datos ingresados por el usuario yyyyMMdd
@CLIENTE varchar(6),
@DIRECCION text,
@SUMAS decimal(12, 2),
@IVA decimal(12, 2),
@CreatedBy varchar(20),
@CreateDate datetime -- = GETDATE()
)
AS
BEGIN
	INSERT INTO FACTURA(NUMERO,PREFIJO,TIPO_FACTURA,FECHA,CLIENTE,DIRECCION,SUMAS,IVA,CreatedBy,CreateDate)
    VALUES(@NUMERO,@PREFIJO,@TIPO_FACTURA,@FECHA,@CLIENTE,@DIRECCION,@SUMAS,@IVA,@CreatedBy,@CreateDate)
END




go

CREATE PROCEDURE sp_Insertar_Detalle_Factura
(
@NUMERO varchar(20),
@PREFIJO varchar(20),
@TIPO_FACTURA varchar(20),
@PRODUCTO int,
@CANTIDAD decimal(12, 2),
@PRECIO_UNITARIO decimal(12, 2),
@TOTAL decimal(12, 2),
@LINEA int,
@CreatedBy varchar(20),
@CreateDate datetime, -- = GETDATE()
@DESCRIPCION text,
@IMPUESTO_PRODUCTO decimal(12, 2)
)
AS
BEGIN
	INSERT INTO Detalle_Factura(NUMERO,PREFIJO,TIPO_FACTURA,PRODUCTO,CANTIDAD,PRECIO_UNITARIO,TOTAL,LINEA,CreatedBy,CreateDate,DESCRIPCION,IMPUESTO_PRODUCTO)
    VALUES(@NUMERO,@PREFIJO,@TIPO_FACTURA,@PRODUCTO,@CANTIDAD,@PRECIO_UNITARIO,@TOTAL,@LINEA,@CreatedBy,@CreateDate,@DESCRIPCION,@IMPUESTO_PRODUCTO)
END



go

CREATE PROCEDURE sp_Insertar_Cliente
(
@CODIGO varchar(6),
@NOMBRES varchar(50),
@APELLIDOS varchar(50),
@IDENTIFICACION varchar(15),
@TELEFONO varchar(15),
@DIRECCION text,
@ESTADO varchar(1),
@CreatedBy varchar(20),
@CreateDate datetime -- = GETDATE()
)
AS
BEGIN
	INSERT INTO Cliente(CODIGO,NOMBRES,APELLIDOS,IDENTIFICACION,TELEFONO,DIRECCION,ESTADO,CreatedBy,CreateDate)
    VALUES(@CODIGO,@NOMBRES,@APELLIDOS,@IDENTIFICACION,@TELEFONO,@DIRECCION,@ESTADO,@CreatedBy,@CreateDate)
END




go

CREATE PROCEDURE sp_Actualizar_Cliente
(
@CODIGO varchar(6),
@NOMBRES varchar(50),
@APELLIDOS varchar(50),
@IDENTIFICACION varchar(15),
@TELEFONO varchar(15),
@DIRECCION text,
@ESTADO varchar(1),
@UpdatedBy varchar(20),
@UpdateDate datetime -- = GETDATE()
)
AS
BEGIN
	UPDATE CLIENTE SET NOMBRES=@NOMBRES, APELLIDOS=@APELLIDOS,IDENTIFICACION=@IDENTIFICACION,TELEFONO=@TELEFONO,DIRECCION=@DIRECCION,ESTADO=@ESTADO,UpdatedBy=@UpdatedBy,UpdateDate=@UpdateDate WHERE CODIGO=@CODIGO
END




go

CREATE PROCEDURE Agregar_Producto
(
@nombre_producto varchar(100),
@id_categoria int,
@precio decimal,
@descripcion varchar(500),
@cantidad int,
@precio_venta decimal
)
AS
BEGIN
	INSERT INTO producto (nombre_producto,id_categoria,precio,descripcion,cantidad,ESTADO,precio_venta)
	VALUES(@nombre_producto,@id_categoria,@precio,@descripcion,@cantidad,'A',@precio_venta)
END



go

CREATE PROCEDURE sp_Actualizar_Producto
(
@id_producto int,
@nombre_producto varchar(100),
@id_categoria int,
@precio decimal,
@descripcion varchar(500),
@ESTADO varchar(1),
@cantidad int,
@precio_venta decimal
)
AS
BEGIN
	UPDATE producto SET nombre_producto=@nombre_producto,id_categoria=@id_categoria,precio=@precio,descripcion=@descripcion,ESTADO=@ESTADO, precio_venta=@cantidad WHERE id_producto=@id_producto
END
go

CREATE PROCEDURE sp_Insertar_Proveedor
(
@CODIGO varchar(6),
@NOMBRES varchar(50),
@APELLIDOS varchar(50),
@IDENTIFICACION varchar(15),
@TELEFONO varchar(15),
@DIRECCION text,
@ESTADO varchar(1),
@CreatedBy varchar(20),
@CreateDate datetime
)
AS
BEGIN
	INSERT INTO Proveedor(CODIGO,NOMBRES,APELLIDOS,IDENTIFICACION,TELEFONO,DIRECCION,ESTADO,CreatedBy,CreateDate)
    VALUES(@CODIGO,@NOMBRES,@APELLIDOS,@IDENTIFICACION,@TELEFONO,@DIRECCION,@ESTADO,@CreatedBy,@CreateDate)
END
go

CREATE PROCEDURE sp_Actualizar_Proveedor
(
@CODIGO varchar(6),
@NOMBRES varchar(50),
@APELLIDOS varchar(50),
@IDENTIFICACION varchar(15),
@TELEFONO varchar(15),
@DIRECCION text,
@ESTADO varchar(1),
@UpdatedBy varchar(20),
@UpdateDate datetime -- = GETDATE()
)
AS
BEGIN
	 UPDATE Proveedor SET NOMBRES=@NOMBRES, APELLIDOS=@APELLIDOS,IDENTIFICACION=@IDENTIFICACION
	 ,TELEFONO=@TELEFONO,DIRECCION=@DIRECCION,ESTADO=@ESTADO,UpdatedBy=@UpdatedBy,UpdateDate=@UpdateDate WHERE CODIGO=@CODIGO
END
go

CREATE PROCEDURE sp_ValidarLogin
--ESTE PROCEDIMIENTO VALIDA SI EXISTE O NO UN USUARIO Y SI LA CONTRASEÑA ES CORRECTA BIEN O NO
-- DA MENSAJE: USUARIO NO ENCONTRADO, CONTRASEÑA INVALIDA, en caso de USUARIO Y CONTRASEÑA CORRECTOS(retorno todos los datos de ese usuario)
(
@Usuario VARCHAR(25),
@Contrasena VARCHAR(25)
)
AS
BEGIN
    SET NOCOUNT ON;

    -- Verificar si el usuario existe
    IF EXISTS (SELECT 1 FROM USUARIO WHERE USUARIO = @Usuario)
    BEGIN
			-- Verificar la contraseña
		IF EXISTS (SELECT 1 FROM USUARIO WHERE CLAVE = @Contrasena)
			BEGIN 
				SELECT * FROM USUARIO WHERE USUARIO = @Usuario AND CLAVE = @Contrasena
			END
		ELSE
			SELECT 'Contraseña incorrecta.' AS Resultado;
	END
    ELSE
    BEGIN
        SELECT 'Usuario no encontrado.' AS Resultado;
    END
END;
go














































