------------------------------------------------------------------
------------------------------------------------------------------
------------------------------------------------------------------

--- Script para crear la base de datos y las tablas necesarias ---

-- Crear la base de datos si no existe
IF NOT EXISTS (
    SELECT [name]
    FROM sys.databases
    WHERE [name] = N'pos_pizzeria'
)
CREATE DATABASE pos_pizzeria;
GO
USE pos_pizzeria;
GO

------------------------------------------------------------------
------------------------------------------------------------------
------------------------------------------------------------------
--Tabla de roles: OROL

USE [pos_pizzeria]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OROL](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NameRole] [varchar](40) NOT NULL,
	[Description] [nvarchar](60) NOT NULL,
	[status] [bit] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[DateUpdated] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[DateDeleted] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedStatus] [bit] NULL,
 CONSTRAINT [PK_OROL] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

------------------------------------------------------------------
------------------------------------------------------------------
------------------------------------------------------------------
--Tabla de usuarios: OUSR
USE [pos_pizzeria]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OUSR](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_Rol] [int] NOT NULL,
	[NameUser] [varchar](20) NOT NULL,
	[Name] [varchar](60) NOT NULL,
	[LastName] [varchar](60) NULL,
	[Email] [varchar](60) NOT NULL,
	[Password] [varchar](325) NOT NULL,
	[Comments] [nvarchar](50) NULL,
	[status] [bit] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[DateUpdated] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[DateDeleted] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedStatus] [bit] NULL,
 CONSTRAINT [PK_OUSR] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[OUSR]  WITH CHECK ADD  CONSTRAINT [FK_OUSR_OROL] FOREIGN KEY([ID_Rol])
REFERENCES [dbo].[OROL] ([ID])
GO

ALTER TABLE [dbo].[OUSR] CHECK CONSTRAINT [FK_OUSR_OROL]
GO

------------------------------------------------------------------
------------------------------------------------------------------
------------------------------------------------------------------
--Tabla de categorías: OPCT

USE [pos_pizzeria]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OPCT](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](60) NOT NULL,
	[Description] [nvarchar](150) NOT NULL,
	[Status] [bit] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[DateUpdated] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[DateDeleted] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedStatus] [bit] NULL,
 CONSTRAINT [PK_OPCT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

------------------------------------------------------------------
------------------------------------------------------------------
------------------------------------------------------------------
--Tabla de métodos de pago: OPMT

USE [pos_pizzeria]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OPMT](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Details] [nvarchar](200) NULL,
	[ServiceProvider] [varchar](70) NOT NULL,
	[Status] [bit] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[DateUpdated] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[DateDeleted] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedStatus] [bit] NULL,
 CONSTRAINT [PK_OPMT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[OPMT]  WITH CHECK ADD  CONSTRAINT [FK_OPMT_OUSR] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[OUSR] ([ID])
GO

ALTER TABLE [dbo].[OPMT] CHECK CONSTRAINT [FK_OPMT_OUSR]
GO

------------------------------------------------------------------
------------------------------------------------------------------
------------------------------------------------------------------
--Tabla de productos: OPRT

USE [pos_pizzeria]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OPRT](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_Category] [int] NOT NULL,
	[Code] [nvarchar](20) NOT NULL,
	[Description] [nvarchar](150) NULL,
	[Price] [decimal](10, 2) NOT NULL,
	[Image] [varchar](max) NULL,
	[AvailableStock] [int] NOT NULL,
	[Featured] [bit] NULL,
	[Status] [bit] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[DateUpdated] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[DateDeleted] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedStatus] [bit] NULL,
 CONSTRAINT [PK_OPRT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[OPRT]  WITH CHECK ADD  CONSTRAINT [FK_OPRT_OPCT] FOREIGN KEY([ID_Category])
REFERENCES [dbo].[OPCT] ([ID])
GO

ALTER TABLE [dbo].[OPRT] CHECK CONSTRAINT [FK_OPRT_OPCT]
GO

ALTER TABLE [dbo].[OPRT]  WITH CHECK ADD  CONSTRAINT [FK_OPRT_OUSR] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[OUSR] ([ID])
GO

ALTER TABLE [dbo].[OPRT] CHECK CONSTRAINT [FK_OPRT_OUSR]
GO

------------------------------------------------------------------
------------------------------------------------------------------
------------------------------------------------------------------
--Tabla de clientes: OCLI

USE [pos_pizzeria]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OCLI](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](120) NOT NULL,
	[Mobile] [varchar](20) NULL,
	[Email] [varchar](60) NULL,
	[NationalIdentification] [varbinary](35) NOT NULL,
	[status] [bit] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[DateUpdated] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[DateDeleted] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedStatus] [bit] NULL,
 CONSTRAINT [PK_OCLI] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[OCLI]  WITH CHECK ADD  CONSTRAINT [FK_OCLI_OUSR] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[OUSR] ([ID])
GO

ALTER TABLE [dbo].[OCLI] CHECK CONSTRAINT [FK_OCLI_OUSR]
GO

------------------------------------------------------------------
------------------------------------------------------------------
------------------------------------------------------------------
--Tabla de direcciones de entrega de los clientes: CLI1

USE [pos_pizzeria]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CLI1](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_Customer] [int] NOT NULL,
	[DeliveryAddress] [varchar](max) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[PostalCode] [nvarchar](20) NULL,
	[State] [nvarchar](40) NOT NULL,
	[ReferenceAddress] [varchar](200) NULL,
	[status] [bit] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[DateUpdated] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[DateDeleted] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedStatus] [bit] NULL,
 CONSTRAINT [PK_CLI1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[CLI1]  WITH CHECK ADD  CONSTRAINT [FK_CLI1_OCLI] FOREIGN KEY([ID_Customer])
REFERENCES [dbo].[OCLI] ([ID])
GO

ALTER TABLE [dbo].[CLI1] CHECK CONSTRAINT [FK_CLI1_OCLI]
GO

------------------------------------------------------------------
------------------------------------------------------------------
------------------------------------------------------------------
--Tabla de pedidos de cliente: OODR

USE [pos_pizzeria]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OODR](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_Customer] [int] NOT NULL,
	[ID_DeliveryAddress] [int] NOT NULL,
	[ID_PaymentMethod] [int] NOT NULL,
	[DateOrder] [datetime] NOT NULL,
	[DateDelivery] [datetime] NOT NULL,
	[OrderStatus] [varchar](30) NOT NULL,
	[OrderNotes] [nvarchar](200) NOT NULL,
	[TotalPrice] [decimal](10, 2) NOT NULL,
	[Taxes] [decimal](10, 2) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[DateUpdated] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[DateDeleted] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedStatus] [bit] NULL,
 CONSTRAINT [PK_OODR] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[OODR]  WITH CHECK ADD  CONSTRAINT [FK_OODR_CLI1] FOREIGN KEY([ID_DeliveryAddress])
REFERENCES [dbo].[CLI1] ([ID])
GO

ALTER TABLE [dbo].[OODR] CHECK CONSTRAINT [FK_OODR_CLI1]
GO

ALTER TABLE [dbo].[OODR]  WITH CHECK ADD  CONSTRAINT [FK_OODR_OCLI] FOREIGN KEY([ID_Customer])
REFERENCES [dbo].[OCLI] ([ID])
GO

ALTER TABLE [dbo].[OODR] CHECK CONSTRAINT [FK_OODR_OCLI]
GO

ALTER TABLE [dbo].[OODR]  WITH CHECK ADD  CONSTRAINT [FK_OODR_OPMT] FOREIGN KEY([ID_PaymentMethod])
REFERENCES [dbo].[OPMT] ([ID])
GO

ALTER TABLE [dbo].[OODR] CHECK CONSTRAINT [FK_OODR_OPMT]
GO

ALTER TABLE [dbo].[OODR]  WITH CHECK ADD  CONSTRAINT [FK_OODR_OUSR] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[OUSR] ([ID])
GO

ALTER TABLE [dbo].[OODR] CHECK CONSTRAINT [FK_OODR_OUSR]
GO

------------------------------------------------------------------
------------------------------------------------------------------
------------------------------------------------------------------
--Tabla detalles de pedidos: ODR1

USE [pos_pizzeria]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ODR1](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_Order] [int] NOT NULL,
	[ID_Products] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [decimal](10, 2) NOT NULL,
	[Subtotal] [decimal](10, 2) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[DateUpdated] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[DateDeleted] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedStatus] [bit] NULL,
 CONSTRAINT [PK_ODR1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ODR1]  WITH CHECK ADD  CONSTRAINT [FK_ODR1_OODR] FOREIGN KEY([ID_Order])
REFERENCES [dbo].[OODR] ([ID])
GO

ALTER TABLE [dbo].[ODR1] CHECK CONSTRAINT [FK_ODR1_OODR]
GO

ALTER TABLE [dbo].[ODR1]  WITH CHECK ADD  CONSTRAINT [FK_ODR1_OPRT] FOREIGN KEY([ID_Products])
REFERENCES [dbo].[OPRT] ([ID])
GO

ALTER TABLE [dbo].[ODR1] CHECK CONSTRAINT [FK_ODR1_OPRT]
GO

------------------------------------------------------------------
------------------------------------------------------------------
------------------------------------------------------------------
--Tabla de facturas:  OINV

USE [pos_pizzeria]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OINV](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_Order] [int] NOT NULL,
	[ID_Customer] [int] NOT NULL,
	[ID_PaymentMethod] [int] NOT NULL,
	[InvoiceDate] [datetime] NOT NULL,
	[Correlative] [varchar](30) NOT NULL,
	[TotalAmount] [decimal](10, 2) NOT NULL,
	[Taxes] [decimal](10, 2) NULL,
	[Discounts] [decimal](10, 2) NULL,
	[NetAmount] [decimal](10, 2) NOT NULL,
	[Status] [varchar](30) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[DateUpdated] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[DateDeleted] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedStatus] [bit] NULL,
 CONSTRAINT [PK_INV1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[OINV]  WITH CHECK ADD  CONSTRAINT [FK_OINV_OCLI] FOREIGN KEY([ID_Customer])
REFERENCES [dbo].[OCLI] ([ID])
GO

ALTER TABLE [dbo].[OINV] CHECK CONSTRAINT [FK_OINV_OCLI]
GO

ALTER TABLE [dbo].[OINV]  WITH CHECK ADD  CONSTRAINT [FK_OINV_OODR] FOREIGN KEY([ID_Order])
REFERENCES [dbo].[OODR] ([ID])
GO

ALTER TABLE [dbo].[OINV] CHECK CONSTRAINT [FK_OINV_OODR]
GO

ALTER TABLE [dbo].[OINV]  WITH CHECK ADD  CONSTRAINT [FK_OINV_OPMT] FOREIGN KEY([ID_PaymentMethod])
REFERENCES [dbo].[OPMT] ([ID])
GO

ALTER TABLE [dbo].[OINV] CHECK CONSTRAINT [FK_OINV_OPMT]
GO

