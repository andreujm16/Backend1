USE [PRUEBADB]
GO

/****** Object:  StoredProcedure [dbo].[guardar_transaccion]    Script Date: 24/06/2021 12:51:59 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Jaime Martinez>
-- Create date: <23 Jun 2021>
-- Description:	<Procedimiento para guardar una transaccion>
-- =============================================
CREATE PROCEDURE [dbo].[guardar_transaccion] 
	@id_tipo_transaccion int,
	@monto decimal,
	@id_cuenta int,
	@id_cuenta_destino int,
	@id_usuario int
AS
BEGIN
	-- CONSULTA CONFIGURACION DE VALORES DE GMF, BASE, DIVISOR, PORCENTAJE
	declare @porc_gmf decimal
	declare @divisor decimal
	declare @base_retiro_gmf decimal
	SELECT @porc_gmf = porc_gmf, @divisor = divisor, @base_retiro_gmf = base_retiro_gmf
	FROM configuracion WHERE id = 1

	-- CONSUTAMOS SI EL USUARIO ES EXENTO
	declare @exento bit
	SELECT @exento = exento 
	FROM usuario WHERE id = @id_usuario

	-- CONSULTAMOS EL TIPO DE TRANSACCION
	declare @tipo_tran varchar(5)
	declare @pide_cuenta_destino bit
	SELECT @tipo_tran = tipo , @pide_cuenta_destino = pide_cuenta_destino
	FROM tipo_transaccion WHERE id = @id_tipo_transaccion

	-- CALCULAMOS EL VALOR DEL GMF
	declare @valor_gmf decimal

	IF ((@tipo_tran = 'TR' AND @exento = 0) OR (@tipo_tran = 'RE' AND @monto >= @base_retiro_gmf))
		SET @valor_gmf = (@monto * @porc_gmf) / @divisor
	ELSE
		SET @valor_gmf = 0

	
	--CONSULTAMOS EL SALDO DE LA CUENTA
	declare @saldo_actual decimal
	SELECT @saldo_actual = saldo 
	FROM cuenta WHERE id = @id_cuenta

	declare @saldo_nuevo decimal

	set @saldo_nuevo = @saldo_actual - @monto - @valor_gmf


	-- VALIDAMOS SI PIDE DESTINO EL TIPO DE TRANSACCION
	IF @pide_cuenta_destino = 0 
		SET @id_cuenta_destino = null

	-- INSERTAMOS EL REGISTRO EN LA TRABLA TRANSACCION
	INSERT INTO transaccion ([id_tipo_transaccion], [monto], [valor_gmf], [id_cuenta], [saldo_operacion],[fecha_hora], [id_cuenta_destino], [id_usuario])
	VALUES (@id_tipo_transaccion, @monto, @valor_gmf, @id_cuenta, @saldo_nuevo, GETDATE(), @id_cuenta_destino, @id_usuario)

	-- INSERTAMOS UN REGISTRO DE AUDITORIA
	INSERT INTO auditoria ([fecha_hora], [descripcion])
	VALUES (GETDATE(), CONCAT('Crea Transaccion. Usuario: ', @id_usuario))

	-- ACTUALIZAMOS EL SALDO DE LA CUENTA

	UPDATE cuenta SET saldo = @saldo_nuevo
	WHERE id = @id_cuenta

	--ACTUALIAMOS LA CUENTA DESTINO SI TIENE

	declare @uno int
	IF @id_cuenta_destino IS NULL
		SET @uno = 1
	ELSE
		UPDATE cuenta SET saldo = saldo + @monto
		WHERE id = @id_cuenta_destino

END
GO

