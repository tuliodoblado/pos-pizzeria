USE pos_pizzeria;
GO

-- Insertar en la tabla de roles (OROL)
INSERT INTO dbo.OROL (NameRole, Description, status, DateCreated, CreatedBy) VALUES
('Administrador', 'Tiene acceso completo al sistema', 1, GETDATE(), 1),
('Empleado', 'Puede realizar ventas y registrar pedidos', 1, GETDATE(), 1),
('Gerente', 'Maneja operaciones y reportes', 1, GETDATE(), 1);
GO

-- Insertar en la tabla de usuarios (OUSR) después de que los roles estén establecidos
INSERT INTO dbo.OUSR (ID_Rol, NameUser, Name, LastName, Email, Password, status, DateCreated, CreatedBy) VALUES
(1, 'admin', 'Juan', 'Perez', 'admin@pizzeria.com', '$2a$11$B/wZePJ.zO/pWdK5e7xav./6YYqHvgCgihbN7eeFKfuqUKgnjm7p2', 1, GETDATE(), 1),
(2, 'vendedor1', 'Ana', 'Lopez', 'vendedor1@pizzeria.com', '$2a$11$B/wZePJ.zO/pWdK5e7xav./6YYqHvgCgihbN7eeFKfuqUKgnjm7p2', 1, GETDATE(), 1),
(3, 'gerente1', 'Carlos', 'Mora', 'gerente1@pizzeria.com', '$2a$11$B/wZePJ.zO/pWdK5e7xav./6YYqHvgCgihbN7eeFKfuqUKgnjm7p2', 1, GETDATE(), 1);
GO

-- Insertar en la tabla de categorías (OPCT)
INSERT INTO dbo.OPCT (Name, Description, Status, DateCreated, CreatedBy) VALUES
('Pizzas', 'Incluye todas nuestras pizzas', 1, GETDATE(), 1),
('Bebidas', 'Refrescos y otras bebidas', 1, GETDATE(), 1),
('Postres', 'Dulces y pasteles', 1, GETDATE(), 1);
GO

-- Insertar en la tabla de métodos de pago (OPMT)
INSERT INTO dbo.OPMT (Name, Details, ServiceProvider, Status, DateCreated, CreatedBy) VALUES
('Efectivo', NULL, 'Propio', 1, GETDATE(), 1),
('Tarjeta de Crédito', 'Visa, MasterCard', 'Visa/MasterCard', 1, GETDATE(), 1),
('PayPal', 'Pago en línea', 'PayPal', 1, GETDATE(), 1);
GO

-- Insertar en la tabla de productos (OPRT)
INSERT INTO dbo.OPRT (ID_Category, Code, Description, Price, Image, AvailableStock, Featured, Status, DateCreated, CreatedBy) VALUES
(1, 'PZ001', 'Pizza Clasic', 10.00, NULL, 100, 1, 1, GETDATE(), 1),
(1, 'PZ002', 'Pizza Pepperoni', 12.50, NULL, 100, 0, 1, GETDATE(), 1),
(2, 'BD001', 'Coca Cola 500ml', 2.00, NULL, 150, 0, 1, GETDATE(), 1);
GO

-- Insertar en la tabla de clientes (OCLI)
INSERT INTO dbo.OCLI (Name, Mobile, Email, NationalIdentification, status, DateCreated, CreatedBy) VALUES
('María González', '9876543210', 'maria@gmail.com', 0801199945587, 1, GETDATE(), 1),
('Luis Ramirez', '1234567890', 'luis@gmail.com', 0801200066598, 1, GETDATE(), 1);
GO

-- Insertar en la tabla de direcciones de entrega (CLI1)
INSERT INTO dbo.CLI1 (ID_Customer, DeliveryAddress, City, PostalCode, State, ReferenceAddress, status, DateCreated, CreatedBy) VALUES
(1, 'Calle 123', 'Ciudad de SPS', '5000', 'Estado', 'Al lado del supermercado', 1, GETDATE(), 1),
(2, 'Avenida Real 456', 'Ciudad de la Lima', '7000', 'Estado', 'Frente al parque central', 1, GETDATE(), 1);
GO

-- Insertar en la tabla de pedidos de clientes (OODR)
INSERT INTO dbo.OODR (ID_Customer, ID_DeliveryAddress, ID_PaymentMethod, DateOrder, DateDelivery, OrderStatus, OrderNotes, TotalPrice, Taxes, DateCreated, CreatedBy) VALUES
(1, 1, 1, GETDATE(), GETDATE(), 'Entregado', 'Sin comentarios adicionales', 15.00, 1.50, GETDATE(), 1),
(2, 2, 2, GETDATE(), GETDATE(), 'En preparación', 'Por favor, sin cebolla', 20.00, 2.00, GETDATE(), 1);
GO

-- Insertar en la tabla detalles de pedidos (ODR1)
INSERT INTO dbo.ODR1 (ID_Order, ID_Products, Quantity, UnitPrice, Subtotal, DateCreated, CreatedBy) VALUES
(1, 1, 2, 10.00, 20.00, GETDATE(), 1),
(2, 2, 1, 12.50, 12.50, GETDATE(), 1);
GO

-- Insertar en la tabla de facturas (OINV)
INSERT INTO dbo.OINV (ID_Order, ID_Customer, ID_PaymentMethod, InvoiceDate, Correlative, TotalAmount, Taxes, Discounts, NetAmount, Status, DateCreated, CreatedBy) VALUES
(1, 1, 1, GETDATE(), '000-001-00000001', 15.00, 1.50, 0.00, 16.50, 'Pagada', GETDATE(), 1),
(2, 2, 2, GETDATE(), '000-001-00000002', 20.00, 2.00, 0.00, 22.00, 'Pagada', GETDATE(), 1);
GO

