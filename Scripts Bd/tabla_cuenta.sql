USE [PRUEBADB]
GO

/****** Object:  Table [dbo].[cuenta]    Script Date: 24/06/2021 12:49:54 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[cuenta](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NULL,
	[id_usuario] [int] NULL,
	[id_banco] [int] NULL,
	[saldo] [decimal](18, 2) NULL,
 CONSTRAINT [PK_cuenta] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[cuenta] ADD  CONSTRAINT [DF_cuenta_saldo]  DEFAULT ((0)) FOR [saldo]
GO

ALTER TABLE [dbo].[cuenta]  WITH CHECK ADD  CONSTRAINT [FK_cuenta_banco] FOREIGN KEY([id_banco])
REFERENCES [dbo].[banco] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[cuenta] CHECK CONSTRAINT [FK_cuenta_banco]
GO

ALTER TABLE [dbo].[cuenta]  WITH CHECK ADD  CONSTRAINT [FK_cuenta_usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuario] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[cuenta] CHECK CONSTRAINT [FK_cuenta_usuario]
GO

