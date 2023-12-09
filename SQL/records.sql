use ritmo_software;
GO

INSERT INTO Pais (cod_pais, nom_pais)
VALUES
    (57, 'COLOMBIA'),
    (1, 'USA'),
    (34, 'SPAIN'),
    (86, 'CHINA'),
	(38, 'YUGOSLAVIA');

INSERT INTO DescripHabitacion ( tipo_hab, descripcion)
VALUES
    ( 'INDIVIDUAL', 'UNA CAMA SIMPLE, TELEVISOR, MESA'),
    ( 'PAREJA', 'UNA CAMA DOBLE, TELEVISOR, COMEDOR, MESA'),
    ( 'FAMILIAR', 'DOS CAMAS SIMPLES Y UNA DOBLE, COMEDOR, DOS BAÑOS');

INSERT INTO Habitaciones (num_hab, tipo_hab, estado, capacidad, precio)
VALUES
	(101, 'INDIVIDUAL', 'D', 1, 10000),
	(102, 'PAREJA', 'D', 2, 20000),
	(103, 'FAMILIAR', 'D', 5, 30000),
	(104, 'INDIVIDUAL', 'D', 5, 30000);

INSERT INTO Roles (cod_rol, tipo_rol)
VALUES
	(1, 'ADMIN'),
	(2, 'MANAGER'),
	(3, 'STAFF'),
	(4, 'RECEPCIONISTA');
GO

INSERT INTO Usuarios (tipo_doc, num_doc, apellidos, nombres, fecha_nac, fecha_exp, lug_nacimiento, genero, direccion, correo, telefono, cargo)
VALUES
    ('C.C', 12345678, 'PEREZ', 'PEPITO', CONVERT(datetime, '01/01/1990', 101), CONVERT(datetime, '01/01/2000', 101), 'CIUDAD1', 'MASCULINO', 'DIRECCION1', 'CORREO1@EXAMPLE.COM', 123456789, 1)

INSERT INTO Ingreso (num_documento, contrasena) VALUES (12345678, 'd48b165d1e5a63b56c7601e4269642e6a71fa90b2178a0212a1da5f7ee54255f');

INSERT INTO Clientes (tipo_doc, num_doc, apellidos, nombres, genero, pais_residencia, direccion, telefono, correo)
VALUES
    ('C.C', 123456789, 'GOMEZ', 'ANA', 'FEMENINO', 57, 'CALLE 123', 987654321, 'ANA@EXAMPLE.COM'),
    ('PASAPORTE', 987654321, 'SMITH', 'JOHN', 'MASCULINO', 1, '123 MAIN ST', 123456789, 'JOHN@EXAMPLE.COM'),
    ('PASAPORTE', 112233445, 'FERNANDEZ', 'MARIA', 'FEMENINO', 34, 'CALLE PRINCIPAL', 555666777, 'MARIA@EXAMPLE.COM'),
    ('PASAPORTE', 555666777, 'WANG', 'LI', 'FEMENINO', 86, 'ZHONGGUANCUN STREET', 999888777, 'LI@EXAMPLE.COM'),
	('C.C', 111111111, 'DOE', 'JOHN', 'MASCULINO', 57, 'CALLE A CON A', 111222444, 'JOHNDOE@GMAIL.COM')

INSERT INTO Paquetes (nombre_paquete, activo, descripcion, precio_costo, iva, precio_total)
VALUES
    ('BASICO', 'S', 'DESAYUNO, ALMUERZO, CENA', 50000, 10000, 60000),	
    ('ESTANDAR', 'S', 'DESAYUNO, ALMUERZO, CENA, ACCESO A COMODIDADES', 100000, 20000, 120000),
    ('PREMIUM', 'S', 'DESAYUNO, ALMUERZO, CENA, ACCESO A COMODIDADES, MASAJES INCLUIDOS', 120000, 24000, 160000);
GO

-- select num_factura, num_doc_cliente, paquete_seleccionado, Factura.cod_reserva, num_hab, num_cuenta, opcion_pago, subtotal, iva, total, pago_anti from Factura inner join Reservas on Factura.cod_reserva = Reservas.cod_reserva and Factura.cod_reserva = 1;
-- select Clientes.num_doc, Reservas.fecha_inicio, Reservas.fecha_fin from Clientes inner join Reservas on Clientes.num_doc = Reservas.num_doc where (Reservas.fecha_fin >= GETDATE() and Reservas.fecha_inicio <= GETDATE())-- PARA GENERAR FACTURAS --