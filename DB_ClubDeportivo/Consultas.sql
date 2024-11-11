USE ClubDeportivo;

SELECT * FROM cliente;

-- Primero define la variable de salida rta
SET @rta = 0;

-- Llama al procedimiento con valores de ejemplo
CALL InsActividad("DNI","12345678", 846, @rta);


SELECT * FROM inscripcion;

-- OBTENER DATOS DE LA INSCRIPCION
SELECT IdInscripcion, NombreActividad, CONCAT(NombreC, ' ', ApellidoC), EsSocio, CostoDiario, e.Fecha 
FROM Inscripcion i 
inner join Edicion e on i.IdEdicion = e.IdEdicion
inner join Actividad a on a.Nactividad = e.Nactividad 
inner join Cliente c on c.Idcliente = i.Idcliente
where c.DocC = 1234343;

-- ELIMINAR UNA INSCRIPCIÓN
DELETE FROM Inscripcion WHERE IdInscri = 1;


SELECT i.IdInscripcion, a.NombreActividad, i.FechaInscripcion, a.CostoDiario, i.Pagado 
	FROM Inscripcion i 
	INNER JOIN Edicion e ON i.IdEdicion = e.IdEdicion 
    INNER JOIN Actividad a ON a.Nactividad = e.Nactividad 
    INNER JOIN Cliente c on c.Idcliente = i.Idcliente 
    WHERE c.DocC = 454543353 AND i.Pagado = 0;
    
UPDATE Inscripcion
SET Pagado = 0
WHERE IdInscripcion = 201;

SELECT * FROM Inscripcion;
SELECT * FROM Cliente;
SELECT * FROM CuotaMensual;
SELECT * FROM Socio;

UPDATE Actividad AS a
  INNER JOIN Edicion AS e ON e.NActividad = a.NActividad
   SET a.CantInscriptos = a.CantInscriptos + 1
 WHERE e.IdEdicion = 845;

SELECT * FROM Actividad;

SELECT COUNT(*) FROM Cliente WHERE TDocC = 'DNI' AND DocC = '12345678';


SELECT cm.IdPago, cm.IdSocio, cm.FechaVencimiento, cm.Monto 
  FROM CuotaMensual AS cm 
 INNER JOIN Socio AS s ON s.IdSocio = cm.IdSocio 
 INNER JOIN Cliente AS c ON c.IdCliente = s.IdCliente 
 WHERE c.TDocC = "EXTRANJERO" 
   AND c.DocC = '20304050'  -- DocC entre comillas si es VARCHAR
   AND cm.EstadoPago = 0;  -- EstadoPago, si este es el nombre correcto


SELECT cm.IdPago, cm.FechaGeneracion, cm.FechaVencimiento, s.IdSocio,
    c.NombreC, c.ApellidoC, c.TDocC, c.DocC, cm.Monto, cm.EstadoPago
FROM CuotaMensual cm
INNER JOIN Socio s ON cm.IdSocio = s.IdSocio
INNER JOIN Cliente c ON s.IdCliente = c.IdCliente
WHERE cm.FechaVencimiento = CURDATE(); 

SELECT EsSocio FROM Cliente WHERE TDocC = 'DNI' AND DocC = '44555666';

