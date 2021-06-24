USE [PRUEBADB]
GO

/****** Object:  Table [dbo].[transaccion]    Script Date: 24/06/2021 12:50:25 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[transaccion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_tipo_transaccion] [int] NULL,
	[monto] [decimal](18, 2) NULL,
	[valor_gmf] [decimal](18, 2) NULL,
	[id_cuenta] [int] NULL,
	[saldo_operacion] [decimal](18, 2) NULL,
	[fecha_hora] [datetime] NULL,
	[id_cuenta_destino] [int] NULL,
	[id_usuario] [int] NULL,
 CONSTRAINT [PK_transaccion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[transaccion] ADD  CONSTRAINT [DF_transaccion_monto]  DEFAULT ((0)) FOR [monto]
GO

ALTER TABLE [dbo].[transaccion] ADD  CONSTRAINT [DF_transaccion_valor_gmf]  DEFAULT ((0)) FOR [valor_gmf]
GO

ALTER TABLE [dbo].[transaccion] ADD  CONSTRAINT [DF_transaccion_saldo_operacion]  DEFAULT ((0)) FOR [saldo_operacion]
GO

ALTER TABLE [dbo].[transaccion]  WITH CHECK ADD  CONSTRAINT [FK_transaccion_cuenta] FOREIGN KEY([id_cuenta])
REFERENCES [dbo].[cuenta] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[transaccion] CHECK CONSTRAINT [FK_transaccion_cuenta]
GO

ALTER TABLE [dbo].[transaccion]  WITH CHECK ADD  CONSTRAINT [FK_transaccion_cuenta_des] FOREIGN KEY([id_cuenta_destino])
REFERENCES [dbo].[cuenta] ([id])
GO

ALTER TABLE [dbo].[transaccion] CHECK CONSTRAINT [FK_transaccion_cuenta_des]
GO

ALTER TABLE [dbo].[transaccion]  WITH CHECK ADD  CONSTRAINT [FK_transaccion_usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuario] ([id])
GO

ALTER TABLE [dbo].[transaccion] CHECK CONSTRAINT [FK_transaccion_usuario]
GO

