USE [PRUEBADB]
GO

/****** Object:  Table [dbo].[configuracion]    Script Date: 24/06/2021 12:49:45 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[configuracion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[porc_gmf] [decimal](5, 2) NULL,
	[divisor] [decimal](18, 2) NULL,
	[base_retiro_gmf] [decimal](18, 2) NULL,
 CONSTRAINT [PK_configuracion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

