--verifica si existe o no el procedimiento almacenado,si existe entonces solo lo actualiza,
--pero si no existe entonces lo va a crear
--SOLO DAR CLIC EN EJECUTAR
--La subconsulta SELECT busca en la tabla "sys.objects" todos los objetos de tipo 'P' (procedimiento almacenado) que tengan el nombre de ese procedimiento almacenado'.
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_ver_categorias')
BEGIN
    EXEC('
    CREATE PROCEDURE sp_ver_categorias
    AS
    BEGIN
        SELECT * FROM categoria
    END
    ')
END
ELSE
BEGIN
    EXEC('
    ALTER PROCEDURE sp_ver_categorias
    AS
    BEGIN
        SELECT * FROM categoria
    END
    ')
END
go

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Agregar_categoria')
BEGIN
    EXEC('
    CREATE PROCEDURE sp_Agregar_categoria
    (
		@nombCate nvarchar(50),
		@descripcionCate nvarchar(50)
	)
	AS
	BEGIN
		INSERT INTO categoria (nombCate,descripcionCate,ESTADO)
		VALUES(@nombCate,@descripcionCate,''A'')
	END
    ')
END
ELSE
BEGIN
    EXEC('
    ALTER PROCEDURE sp_Agregar_categoria
    (
	@nombCate nvarchar(50),
	@descripcionCate nvarchar(50)
	)
	AS
	BEGIN
		INSERT INTO categoria (nombCate,descripcionCate,ESTADO)
		VALUES(@nombCate,@descripcionCate,''A'')
	END
    ')
END
go

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Actualizar_categoria')
BEGIN
    EXEC('
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
    ')
END
ELSE
BEGIN
    EXEC('
    ALTER PROCEDURE sp_Actualizar_categoria
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
    ')
END
go

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Eliminar_Categoria')
BEGIN
    EXEC('
    CREATE PROCEDURE sp_Eliminar_Categoria
    @id int
	as
	begin
		delete from categoria where id_categoria = @id;
	END
    ')
END
ELSE
BEGIN
    EXEC('
    ALTER PROCEDURE sp_Eliminar_Categoria
    @id int
	as
	begin
		delete from categoria where id_categoria = @id;
	END
    ')
END
go

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_agregar_compra')
BEGIN
    EXEC('
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
    ')
END
ELSE
BEGIN
    EXEC('
    ALTER PROCEDURE sp_agregar_compra
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
    ')
END
go

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Insertar_Detalle_Compra')
BEGIN
    EXEC('
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
    ')
END
ELSE
BEGIN
    EXEC('
    ALTER PROCEDURE sp_Insertar_Detalle_Compra
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
    ')
END
go

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_listarMovimientos')
BEGIN
    EXEC('
    CREATE PROCEDURE sp_listarMovimientos
    AS
	BEGIN
		SELECT * FROM Movimiento
	END
    ')
END
ELSE
BEGIN
    EXEC('
    ALTER PROCEDURE sp_listarMovimientos
    AS
	BEGIN
		SELECT * FROM Movimiento
	END
    ')
END
go

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_listarMovimientosConProductos')
BEGIN
    EXEC('
    CREATE PROCEDURE sp_listarMovimientosConProductos
    AS
	BEGIN
		SELECT b.*, a.nombre_producto,a.precio FROM producto AS a inner join Movimiento AS b ON b.id_producto = a.id_producto;
	END
    ')
END
ELSE
BEGIN
    EXEC('
    ALTER PROCEDURE sp_listarMovimientosConProductos
    AS
	BEGIN
		SELECT b.*, a.nombre_producto,a.precio FROM producto AS a inner join Movimiento AS b ON b.id_producto = a.id_producto;
	END
    ')
END
go

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Insertar_Movimiento')
BEGIN
    EXEC('
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
    ')
END
ELSE
BEGIN
    EXEC('
    ALTER PROCEDURE sp_Insertar_Movimiento
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
    ')
END
go

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Eliminar_Movimiento')
BEGIN
    EXEC('
    CREATE PROCEDURE sp_Eliminar_Movimiento
    @id int
	as
	begin
		delete from Movimiento where Id_Movimiento = @id;
	END
    ')
END
ELSE
BEGIN
    EXEC('
    ALTER PROCEDURE sp_Eliminar_Movimiento
    @id int
	as
	begin
		delete from Movimiento where Id_Movimiento = @id;
	END
    ')
END
go

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Insertar_Factura')
BEGIN
    EXEC('
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
    ')
END
ELSE
BEGIN
    EXEC('
    ALTER PROCEDURE sp_Insertar_Factura
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
    ')
END
go

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Insertar_Detalle_Factura')
BEGIN
    EXEC('
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
    ')
END
ELSE
BEGIN
    EXEC('
    ALTER PROCEDURE sp_Insertar_Detalle_Factura
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
    ')
END
go

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Insertar_Cliente')
BEGIN
    EXEC('
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
    ')
END
ELSE
BEGIN
    EXEC('
    ALTER PROCEDURE sp_Insertar_Cliente
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
    ')
END
go

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Actualizar_Cliente')
BEGIN
    EXEC('
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
    ')
END
ELSE
BEGIN
    EXEC('
    ALTER PROCEDURE sp_Actualizar_Cliente
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
    ')
END

go

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'Agregar_Producto')
BEGIN
    EXEC('
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
		VALUES(@nombre_producto,@id_categoria,@precio,@descripcion,@cantidad,''A'',@precio_venta)
	END
    ')
END
ELSE
BEGIN
    EXEC('
    ALTER PROCEDURE Agregar_Producto
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
		VALUES(@nombre_producto,@id_categoria,@precio,@descripcion,@cantidad,''A'',@precio_venta)
	END
    ')
END

go

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Actualizar_Producto')
BEGIN
    EXEC('
    CREATE PROCEDURE sp_Actualizar_Producto
    (
	@id_producto int,
	@nombre_producto varchar(50),
	@id_categoria int,
	@precio money,
	@descripcion varchar(100),
	@ESTADO varchar(1),
	@cantidad int,
	@precio_venta money
	)
	AS
	BEGIN

		UPDATE producto SET nombre_producto=@nombre_producto,id_categoria=@id_categoria,precio=@precio,descripcion=@descripcion,ESTADO=@ESTADO ,cantidad=@cantidad ,precio_venta=@precio_venta WHERE id_producto=@id_producto
		select @precio
	END
    ')
END
ELSE
BEGIN
    EXEC('
    ALTER PROCEDURE sp_Actualizar_Producto
    (
	@id_producto int,
	@nombre_producto varchar(50),
	@id_categoria int,
	@precio money,
	@descripcion varchar(100),
	@ESTADO varchar(1),
	@cantidad int,
	@precio_venta money
	)
	AS
	BEGIN

		UPDATE producto SET nombre_producto=@nombre_producto,id_categoria=@id_categoria,precio=@precio,descripcion=@descripcion,ESTADO=@ESTADO ,cantidad=@cantidad ,precio_venta=@precio_venta WHERE id_producto=@id_producto
		select @precio
	END
    ')
END

go

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Insertar_Proveedor')
BEGIN
    EXEC('
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
    ')
END
ELSE
BEGIN
    EXEC('
    ALTER PROCEDURE sp_Insertar_Proveedor
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
    ')
END

go

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_Actualizar_Proveedor')
BEGIN
    EXEC('
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
    ')
END
ELSE
BEGIN
    EXEC('
    ALTER PROCEDURE sp_Actualizar_Proveedor
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
    ')
END

go

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_ValidarLogin')
BEGIN
    EXEC('
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
				SELECT ''Contraseña incorrecta.'' AS Resultado;
		END
		ELSE
		BEGIN
			SELECT ''Usuario no encontrado.'' AS Resultado;
		END
	END;
    ')
END
ELSE
BEGIN
    EXEC('
    ALTER PROCEDURE sp_ValidarLogin
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
				SELECT ''Contraseña incorrecta.'' AS Resultado;
		END
		ELSE
		BEGIN
			SELECT ''Usuario no encontrado.'' AS Resultado;
		END
	END;
    ')
END
go
