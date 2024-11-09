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


-- Ejemplo 1: Cliente nuevo con apto físico y socio
CALL NuevoCliente(
    'Juan',           -- Nombre
    'Pérez',          -- Apellido
    'DNI',            -- Tipo de Documento
    '12345678',       -- Documento
    '1985-04-15',     -- Fecha de Nacimiento
    '1122334455',     -- Teléfono
    'Calle Falsa 123',-- Domicilio
    'juan.perez@example.com', -- Email
    1,                -- EsSocio (1 = sí, 0 = no)
    1,                -- AptoFisico (1 = sí, 0 = no)
    @rta              -- Variable para recibir respuesta
);

-- Ejemplo 2: Cliente nuevo sin apto físico, no socio
CALL NuevoCliente(
    'María',          -- Nombre
    'Gómez',          -- Apellido
    'DNI',            -- Tipo de Documento
    '87654321',       -- Documento
    '1990-07-20',     -- Fecha de Nacimiento
    '1133445566',     -- Teléfono
    'Avenida Siempre Viva 742', -- Domicilio
    'maria.gomez@example.com',  -- Email
    0,                -- EsSocio
    0,                -- AptoFisico
    @rta
);

-- Ejemplo 3: Cliente nuevo con apto físico, socio
CALL NuevoCliente(
    'Carlos',         -- Nombre
    'López',          -- Apellido
    'Pasaporte',      -- Tipo de Documento
    'P1234567',       -- Documento
    '1978-11-25',     -- Fecha de Nacimiento
    '1155667788',     -- Teléfono
    'Calle Nueva 456',-- Domicilio
    'carlos.lopez@example.com', -- Email
    1,                -- EsSocio
    1,                -- AptoFisico
    @rta
);

-- Ejemplo 4: Cliente nuevo sin apto físico, socio
CALL NuevoCliente(
    'Ana',            -- Nombre
    'Martínez',       -- Apellido
    'CUIL',           -- Tipo de Documento
    '20304050',       -- Documento
    '1988-02-12',     -- Fecha de Nacimiento
    '1177889900',     -- Teléfono
    'Avenida Principal 1000', -- Domicilio
    'ana.martinez@example.com', -- Email
    1,                -- EsSocio
    0,                -- AptoFisico
    @rta
);

-- Ejemplo 5: Cliente nuevo con apto físico, no socio
CALL NuevoCliente(
    'Diego',          -- Nombre
    'Ríos',           -- Apellido
    'DNI',            -- Tipo de Documento
    '55667788',       -- Documento
    '2000-09-30',     -- Fecha de Nacimiento
    '1199887766',     -- Teléfono
    'Calle Sur 789',  -- Domicilio
    'diego.rios@example.com',  -- Email
    0,                -- EsSocio
    1,                -- AptoFisico
    @rta
);

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

UPDATE Actividad AS a
  INNER JOIN Edicion AS e ON e.NActividad = a.NActividad
   SET a.CantInscriptos = a.CantInscriptos + 1
 WHERE e.IdEdicion = 845;

SELECT * FROM Actividad;

SELECT COUNT(*) FROM Cliente WHERE TDocC = 'DNI' AND DocC = '12345678';
