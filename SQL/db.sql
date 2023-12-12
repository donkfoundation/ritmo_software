create database ritmo_software;
GO

use ritmo_software;
GO

create table Pais(
	cod_pais int primary key,
    nom_pais varchar(50) unique not null
);

create table Dpto(
	cod_dpto int primary key identity,
    nom_dpto varchar(50),
    cod_pais int,
    foreign key (cod_pais) references Pais(cod_pais)
);
	
create table Ciudad(
	cod_ciudad int primary key identity,
    nom_ciudad varchar(60),
    cod_dpto int,
    foreign key (cod_dpto) references Dpto(cod_dpto)
);

create table DescripHabitacion(
    tipo_hab varchar(50) primary key,
    descripcion varchar(200)
);

create table Habitaciones(
	num_hab int primary key,
    tipo_hab varchar(50),
    foreign key (tipo_hab) references DescripHabitacion (tipo_hab),
    estado char,
    capacidad int,
    precio int
);


create table Roles(
	cod_rol int primary key,
    tipo_rol varchar(50),
);

create table Usuarios(	
	tipo_doc varchar(30),
	num_doc  int primary key,
	apellidos varchar(80),
	nombres varchar(80),
	fecha_nac datetime,
	fecha_exp datetime,
	lug_nacimiento varchar(50),
	genero varchar(30),
	direccion varchar(30),
	correo text,
	telefono bigint,
	cargo int,
	foreign key (cargo) references Roles(cod_rol),
);

create table Ingreso(
	num_documento int,
	foreign key (num_documento) references Usuarios(num_doc),
	contrasena varchar(200),
);

create table Clientes(
	tipo_doc varchar(50),
    num_doc int primary key,
    apellidos varchar(80),
    nombres varchar(80),
    genero varchar(30),
    pais_residencia int,
	foreign key (pais_residencia) references Pais(cod_pais),
    direccion varchar(100),
	telefono bigint,
	correo varchar(50),
);

create table IngresoClientes (
	num_documento int,
	foreign key (num_documento) references Clientes(num_doc),
	contrasena varchar(200)
);

create table Reservas(
	cod_reserva int primary key identity,
    fecha_inicio datetime,
    fecha_fin datetime,
	fecha_reserva datetime,
    num_doc int,
    foreign key (num_doc) references Clientes(num_doc),
    tipo_pago text,
    pago_anti int default 0,
    cantidad_huespedes int
);

create table Paquetes(
	cod_paquete int primary key identity,
    nombre_paquete varchar(100),
    activo char,
    descripcion text,
    precio_costo int,
    iva int,
    precio_total int
);

create table Proveedores(
	nit_proveedor varchar(11) primary key,
	razon_social varchar(100),
	actividad text,
	direccion text,
	pais int,
	foreign key (pais) references Pais(cod_pais),
	telefono bigint,
	correo text,
	representante_legal varchar(150),
	cedula_representante_legal int,
	tipo_persona varchar(40),
);

create table Inventario(
    cod_prod int primary key identity,
	descripcion varchar(100),
    cantidad int,
	nit_proveedor varchar(11),
	foreign key (nit_proveedor) references Proveedores(nit_proveedor),
	fecha_ingreso datetime,
	fecha_egreso datetime
);

create table Cuenta(
	num_cuenta int primary key identity,
	num_doc int,
    foreign key(num_doc) references Clientes(num_doc),
	descripcion text,
    costo int,
	fecha_compra datetime
);

create table Factura(
	num_factura int primary key identity,
    num_doc_cliente int,
    foreign key(num_doc_cliente) references Clientes(num_doc),
    paquete_seleccionado int,
	foreign key(paquete_seleccionado) references Paquetes(cod_paquete),
    fecha_compra datetime,
    cod_reserva int,
    foreign key(cod_reserva) references Reservas(cod_reserva),
    num_hab int,
    foreign key(num_hab) references Habitaciones(num_hab),
    opcion_pago text,
    subtotal int,
    iva int,
    total int
);

create table Permisos (
	num_documento int,
	foreign key (num_documento) references Usuarios(num_doc),
	pais bit default 0,
	departamento bit default 0,
	ciudad bit default 0,
	roles bit default 0,
	habitaciones bit default 0,
	inventario bit default 0,
	paquetes bit default 0,
	proveedores bit default 0,
	registro bit default 0,
	reservas bit default 0,
	clientes bit default 0,
	reportes bit default 0,
	factura bit default 0,
	cuenta bit default 0,
);
GO

-- Trigger para manipular permisos de usuario nuevo.
CREATE TRIGGER trg_Usuario_Permisos
ON Usuarios
AFTER INSERT
AS
BEGIN
    INSERT INTO Permisos (num_documento)
    SELECT I.num_doc
    FROM INSERTED I;
END;
GO

-- trigger para que cambie estado de habitacion
CREATE TRIGGER trg_Ocupar_Habitacion
ON Factura
AFTER INSERT
AS
BEGIN
    UPDATE Habitaciones
    SET estado = 'O' -- Change state to 'O' (ocupado)
    WHERE num_hab IN (SELECT num_hab FROM INSERTED i
                      INNER JOIN Reservas r ON i.cod_reserva = r.cod_reserva
                      WHERE r.fecha_inicio <= GETDATE() AND r.fecha_fin >= GETDATE());
END;
GO

CREATE TRIGGER trg_Desocupar_Habitacion
ON Factura
AFTER DELETE
AS
BEGIN
    UPDATE Habitaciones
    SET estado = 'D' -- Change state to 'O' (ocupado)
    WHERE num_hab IN (SELECT num_hab FROM deleted i
                      INNER JOIN Reservas r ON i.cod_reserva = r.cod_reserva);
END;
GO

-- trigger para actualizar estado de habitación al actualizar reserva
CREATE TRIGGER trg_Actualizar_Habitacion
ON Factura
AFTER UPDATE
AS
BEGIN
    -- Actualizar el estado de la habitación para las reservas actualizadas
    UPDATE Habitaciones
    SET estado = CASE
                    WHEN r.fecha_inicio <= GETDATE() AND r.fecha_fin >= GETDATE() THEN 'O'  -- Ocupado
                    ELSE 'D'  -- Desocupado
                END
    FROM Habitaciones h
    INNER JOIN INSERTED i ON h.num_hab = i.num_hab
    INNER JOIN Reservas r ON i.cod_reserva = r.cod_reserva
    WHERE r.fecha_inicio <= GETDATE() AND r.fecha_fin >= GETDATE();
END;
GO

-- Para desocupar habitacion apenas la fecha fin expire
CREATE PROCEDURE DesocuparHabitacionesAutomaticamente
AS
BEGIN
    -- Supongamos que hoy es la fecha actual
	DECLARE @fecha_actual datetime = GETDATE();
	UPDATE h
    SET estado = 'D'
    FROM Habitaciones h
    INNER JOIN Factura f ON h.num_hab = f.num_hab
    INNER JOIN Reservas r ON f.cod_reserva = r.cod_reserva
    WHERE (r.fecha_fin) < @fecha_actual
    AND h.estado = 'O';
END;
GO

CREATE PROCEDURE OcuparHabitacionesAutomaticamente
AS
BEGIN
	DECLARE @fecha_actual datetime = GETDATE();
	UPDATE h
    SET estado = 'O'
    FROM Habitaciones h
    INNER JOIN Factura f ON h.num_hab = f.num_hab
    INNER JOIN Reservas r ON f.cod_reserva = r.cod_reserva
    WHERE (r.fecha_inicio) <= @fecha_actual
    AND h.estado = 'D';
END;
GO

-- Los siguientes procedimientos almacenados son para hacer los reportes y sacar la información de las reservas

CREATE PROCEDURE ObtenerReservasUltimoMes
AS
BEGIN
    -- Obtener la fecha actual
    DECLARE @fechaActual datetime = GETDATE();
    -- Calcular la fecha del primer día del mes actual
    DECLARE @primerDiaMesActual datetime = DATEADD(MONTH, DATEDIFF(MONTH, 0, @fechaActual), 0);
    -- Calcular la fecha del último día del mes actual
    DECLARE @ultimoDiaMesAnterior datetime = DATEADD(MONTH, 1, @primerDiaMesActual);

    -- Seleccionar las reservas y facturas del último mes
    SELECT TOP 7
        f.cod_reserva,
        f.num_hab,
        f.paquete_seleccionado,
        f.opcion_pago,
        r.pago_anti,
        r.fecha_reserva,
        r.fecha_inicio,
        r.fecha_fin,
        r.cantidad_huespedes,
		f.subtotal,
		f.total
    FROM
        Reservas r
        INNER JOIN Factura f ON r.cod_reserva = f.cod_reserva
    WHERE
        r.fecha_reserva >= @primerDiaMesActual
        AND r.fecha_reserva <= @ultimoDiaMesAnterior
	ORDER BY f.cod_reserva DESC;
END;
GO

CREATE PROCEDURE ObtenerFacturaCliente
	@CodReserva INT
AS
BEGIN
	SELECT
		f.num_doc_cliente,
		f.cod_reserva,
        f.num_hab,
        f.paquete_seleccionado,
        f.opcion_pago,
        r.pago_anti,
        r.fecha_reserva,
        r.fecha_inicio,
        r.fecha_fin,
        r.cantidad_huespedes,
		f.subtotal,
		f.iva,
		f.total
	FROM Factura f 
		INNER JOIN Reservas r ON r.cod_reserva = f.cod_reserva
	WHERE r.cod_reserva = @CodReserva
END;
GO

CREATE PROCEDURE ObtenerCuentaCliente
	@CodCuenta INT
AS
BEGIN
	SELECT
		c.num_doc,
		c.descripcion,
		c.costo,
		c.fecha_compra
	FROM Cuenta c
END;
GO

CREATE PROCEDURE ObtenerTotalUltimoMes
AS
BEGIN
    -- Obtener la fecha actual
    DECLARE @fechaActual datetime = GETDATE();
    -- Calcular la fecha del primer día del mes actual
    DECLARE @primerDiaMesActual datetime = DATEADD(MONTH, DATEDIFF(MONTH, 0, @fechaActual), 0);
    -- Calcular la fecha del último día del mes actual
    DECLARE @ultimoDiaMesAnterior datetime = DATEADD(MONTH, 1, @primerDiaMesActual);

    -- Seleccionar las reservas y facturas del último mes
    SELECT
		sum(f.iva),
		sum(f.subtotal),
		sum(f.total)
    FROM 
        Reservas r
        INNER JOIN Factura f ON r.cod_reserva = f.cod_reserva
    WHERE
        r.fecha_reserva >= @primerDiaMesActual
        AND r.fecha_reserva <= @ultimoDiaMesAnterior
END;
GO

CREATE PROCEDURE ObtenerInventarioDisponibles
AS
BEGIN
	SELECT 
		descripcion,
		cantidad,
		estado,
		nit_proveedor,
		fecha_ingreso,
		fecha_egreso
	FROM Inventario WHERE estado = 'D'
END;
GO

CREATE PROCEDURE ObtenerTotalCuentasUltimoMes
AS
BEGIN
    -- Obtener la fecha actual
    DECLARE @fechaActual datetime = GETDATE();
    -- Calcular la fecha del primer día del mes actual
    DECLARE @primerDiaMesActual datetime = DATEADD(MONTH, DATEDIFF(MONTH, 0, @fechaActual), 0);
    -- Calcular la fecha del último día del mes actual
    DECLARE @ultimoDiaMesAnterior datetime = DATEADD(MONTH, 1, @primerDiaMesActual);

    -- Seleccionar las reservas y facturas del último mes
    SELECT
		sum(Cuenta.costo)
    FROM
        Cuenta
    WHERE
        Cuenta.fecha_compra >= @primerDiaMesActual
        AND Cuenta.fecha_compra <= @ultimoDiaMesAnterior;
END;
GO

CREATE PROCEDURE ObtenerPaquetesPopulares
AS
BEGIN
	SELECT Paquetes.nombre_paquete, Paquetes.cod_paquete, COUNT(Factura.paquete_seleccionado) 
	AS CantidadSeleccionada FROM Paquetes LEFT JOIN Factura ON Paquetes.cod_paquete = Factura.paquete_seleccionado 
	GROUP BY Paquetes.cod_paquete, Paquetes.nombre_paquete ORDER BY CantidadSeleccionada DESC
END;
GO

CREATE PROCEDURE ObtenerHabitacionesPopulares
AS
BEGIN
	SELECT Habitaciones.num_hab, COUNT(Factura.num_hab) AS CantidadSeleccionada 
	FROM Habitaciones LEFT JOIN Factura ON Habitaciones.num_hab = Factura.num_hab 
	GROUP BY Habitaciones.num_hab ORDER BY CantidadSeleccionada DESC
END;
GO

CREATE FUNCTION func_DiasEstadia
(
 @cod_reserva INT
)
RETURNS INT
AS
BEGIN
	DECLARE @diferencia INT;
		SET @diferencia = DATEDIFF(DAY, (select fecha_inicio from Reservas where cod_reserva = @cod_reserva), (select fecha_fin from Reservas where cod_reserva = @cod_reserva));
	RETURN @diferencia
END;
GO