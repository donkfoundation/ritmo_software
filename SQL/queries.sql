select * from Usuarios;
DBCC CHECKIDENT ('Inventario', RESEED, 0);

delete from Inventario;

insert into Pais(cod_pais, nom_pais) values(57, 'Colombia')

insert into Dpto(nom_dpto, cod_pais) values('Antioquia', 57);

insert into Ciudad(nom_ciudad, cod_dpto) values('Turbo', 1);

select Usuarios.nombres, Roles.tipo_rol, Ingreso.num_documento, Ingreso.perfil from Usuarios inner join Ingreso on Usuarios.num_doc = Ingreso.num_documento inner join Roles on Usuarios.cargo = Roles.cod_rol and Ingreso.num_documento = 12345678 and Ingreso.contrasena = 'contrasena1'

select cod_rol from Roles where tipo_rol='ADMIN';
select * from usuarios;

select tipo_rol from Roles where cod_rol=(select cargo from Usuarios where num_doc=1034923021);

select tipo_rol from Roles order by tipo_rol desc;

select nom_ciudad from Ciudad order by nom_ciudad desc

select * from usuarios;

insert into Clientes(tipo_doc

update Usuarios set cargo = 3 where num_doc=98765432;

insert into Reservas(fecha_inicio, fecha_fin, num_doc, tipo_pago, pago_anti) 
			Values(CONVERT(datetime, '01/01/2023', 101), CONVERT(datetime, '01/02/2023', 101)
select nom_pais from Pais where cod_pais=57
select * from Usuarios
-- ver valores dentro de un rango de domingo - domingo

DECLARE @FechaCorte DATETIME = GETDATE(); DECLARE @DiaSemanaCorte INT = DATEPART(WEEKDAY, @FechaCorte);
DECLARE @ProximoDomingo DATETIME = DATEADD(DAY, 1 + (7 - @DiaSemanaCorte), @FechaCorte);
DECLARE @DomingoAnterior DATETIME = DATEADD(DAY, -@DiaSemanaCorte, @FechaCorte);
SELECT *										
FROM Factura
WHERE fecha_compra <= @ProximoDomingo AND fecha_compra > @DomingoAnterior;

SELECT P.nombre_paquete, P.cod_paquete, COUNT(F.paquete_seleccionado) AS CantidadSeleccionada
FROM Paquetes P
LEFT JOIN Factura F ON P.cod_paquete = F.paquete_seleccionado
GROUP BY P.cod_paquete, P.nombre_paquete
ORDER BY CantidadSeleccionada DESC;


SELECT Habitaciones.num_hab, COUNT(Factura.num_hab) AS CantidadSeleccionada
FROM Habitaciones 
INNER JOIN Factura ON Habitaciones.num_hab = Factura.num_hab
GROUP BY Habitaciones.num_hab
ORDER BY CantidadSeleccionada DESC;

-- Obtén las habitaciones disponibles en las fechas seleccionadas
SELECT h.num_hab, h.precio
FROM Habitaciones h
WHERE h.estado = 'D' and h.capacidad >= 2-- Solo habitaciones disponibles
AND NOT EXISTS (
    -- Verifica que no haya reservas que se superpongan con el rango de fechas seleccionado
    SELECT 1
    FROM Reservas r
    JOIN Factura f ON r.cod_reserva = f.cod_reserva
    WHERE f.num_hab = h.num_hab
    AND (
        ('01/15/2023' BETWEEN r.fecha_inicio AND r.fecha_fin)
        OR ('01/20/2023' BETWEEN r.fecha_inicio AND r.fecha_fin)
        OR (r.fecha_inicio BETWEEN '01/15/2023' AND '01/20/2023')
        OR (r.fecha_fin BETWEEN '01/15/2023' AND '01/20/2023')
	)
);

INSERT INTO Factura (num_doc_cliente, paquete_seleccionado, fecha_compra, cod_reserva, num_hab, opcion_pago, num_doc_empleado, subtotal, iva, total)
SELECT 
	987654321,
	3,
	(select fecha_reserva from reservas where cod_reserva = 7),
	7,
	103,
	'EFECTIVO',
	555666777,
    (((SELECT precio FROM Habitaciones WHERE num_hab = 103) + (SELECT precio_total FROM Paquetes WHERE cod_paquete = 3)) * (select dbo.func_DiasEstadia(7) + 1)) AS subtotal,
    (0.1 * (((SELECT precio FROM Habitaciones WHERE num_hab = 103) + (SELECT precio_total FROM Paquetes WHERE cod_paquete = 3))  * (select dbo.func_DiasEstadia(7) + 1))) AS iva,
    ((1.1 * (((SELECT precio FROM Habitaciones WHERE num_hab = 103) + (SELECT precio_total FROM Paquetes WHERE cod_paquete = 3)) * (select dbo.func_DiasEstadia(7) + 1))) - (SELECT pago_anti FROM Reservas WHERE cod_reserva=7)) AS total;
GO
update Habitaciones set estado = 'D';
select * from Habitaciones;
delete from Reservas
select * from Reservas;
select * from Paquetes;
select Factura.cod_reserva, Factura.num_hab, Factura.paquete_seleccionado, Factura.opcion_pago, Reservas.pago_anti, Reservas.fecha_reserva, Reservas.fecha_inicio, Reservas.fecha_fin, Reservas.cantidad_huespedes from Reservas inner join Factura on Reservas.cod_reserva = Factura.cod_reserva;

select sum(total) + sum(pago_anti) as 'ventas' from Factura inner join Reservas on Factura.cod_reserva = Reservas.cod_reserva;

select (num_doc_empleado + subtotal) from Factura where num_factura = 1

SELECT Habitaciones.num_hab, Habitaciones.precio FROM Habitaciones 
WHERE Habitaciones.estado = 'D' and Habitaciones.capacidad >= @capacidad 
AND NOT EXISTS (SELECT 1 FROM Reservas JOIN Factura ON Reservas.cod_reserva = Factura.cod_reserva WHERE Factura.num_hab = Habitaciones.num_hab 
AND (Reservas.cod_reserva != 1)
AND ((@fecha_checkin BETWEEN Reservas.fecha_inicio AND Reservas.fecha_fin) 
OR (@fecha_checkout BETWEEN Reservas.fecha_inicio AND Reservas.fecha_fin) 
OR (Reservas.fecha_inicio BETWEEN @fecha_checkin AND @fecha_checkout) 
OR (Reservas.fecha_fin BETWEEN @fecha_checkin AND @fecha_checkout)));

SELECT Factura.cod_reserva, Factura.num_hab, Factura.paquete_seleccionado, Factura.opcion_pago, Reservas.pago_anti, Reservas.fecha_inicio, Reservas.fecha_fin, Reservas.cantidad_huespedes FROM Reservas INNER JOIN Factura ON Reservas.cod_reserva = Factura.cod_reserva WHERE Reservas.cod_reserva =
select * from cuenta;
select dbo.func_DiasEstadia(4);
select Factura.*, Reservas.*, Habitaciones.* from Reservas inner join Factura on Factura.cod_reserva = Reservas.cod_reserva inner join Habitaciones on Factura.num_hab = Habitaciones.num_hab;
DECLARE @FechaCorte DATETIME = GETDATE(); 
DECLARE @DiaSemanaCorte INT = DATEPART(WEEKDAY, @FechaCorte); 
DECLARE @ProximoDomingo DATETIME = DATEADD(DAY, 1 + (7 - @DiaSemanaCorte), @FechaCorte); 
DECLARE @DomingoAnterior DATETIME = DATEADD(DAY, -@DiaSemanaCorte, @FechaCorte); 
SELECT SUM(total) + sum(pago_anti) AS 'Ventas' FROM Factura inner join Reservas on Factura.cod_reserva = Reservas.cod_reserva WHERE Factura.fecha_compra <= @ProximoDomingo AND Factura.fecha_compra > @DomingoAnterior;