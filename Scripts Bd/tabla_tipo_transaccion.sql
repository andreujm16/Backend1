USE [PRUEBADB]
GO

/****** Object:  Table [dbo].[tipo_transaccion]    Script Date: 24/06/2021 12:50:12 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tipo_transaccion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tipo] [varchar](5) NULL,
	[nombre] [varchar](20) NULL,
	[pide_cuenta_destino] [bit] NULL,
 CONSTRAINT [PK_tipo_transaccion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tipo_transaccion] ADD  CONSTRAINT [DF_tipo_transaccion_pide_cuenta_destino]  DEFAULT ((0)) FOR [pide_cuenta_destino]
GO

