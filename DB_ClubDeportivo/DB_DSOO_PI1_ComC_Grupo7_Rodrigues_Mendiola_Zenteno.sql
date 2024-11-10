/* DB_DSOO_PI1_ComC_Grupo7_Rodrigues_Mendiola_Zenteno */

DROP DATABASE IF EXISTS ClubDeportivo;
CREATE DATABASE ClubDeportivo;
USE ClubDeportivo;

CREATE TABLE Roles(
	RolUsu INT,
	NomRol VARCHAR(30),
CONSTRAINT PRIMARY KEY(RolUsu)
);

INSERT INTO Roles VALUES
(120,'Administrador'),
(121,'Cliente');

CREATE TABLE Usuario(
	IdUsu INT AUTO_INCREMENT,
NombreUsu VARCHAR (20),
  PassUsu VARCHAR (15),
   RolUsu INT,
   Activo BOOLEAN DEFAULT TRUE,
CONSTRAINT pk_usuario PRIMARY KEY (IdUsu),
CONSTRAINT fk_usuario FOREIGN KEY(RolUsu) REFERENCES Roles(RolUsu)
);

INSERT INTO usuario(NombreUsu,PassUsu,RolUsu) VALUES
('a', 'a', 120),
('Cari', '1234',120),
('Edu', '1234', 120),
('Jose', '1234', '121');

CREATE TABLE Cliente (
    IdCliente INT,
    NombreC VARCHAR(30),
    ApellidoC VARCHAR(40),
    TDocC VARCHAR(20),
    DocC VARCHAR(20),
    FechaNacC DATE,
    TelC VARCHAR(20),
    DomicilioC VARCHAR(50),
    EmailC VARCHAR(30),
    EsSocio TINYINT,
    AptoFisico TINYINT,
    CONSTRAINT pk_IdCliente PRIMARY KEY (IdCliente),
    CONSTRAINT uq_TDocC_DocC UNIQUE (TDocC, DocC)  
);

CREATE TABLE Instructor(
NInstructor INT,
NombreInst VARCHAR(30),
ApellidoInst VARCHAR(40),
TDocInst VARCHAR(20),
DocInst INT,
DomiInt VARCHAR(60),
CONSTRAINT pk_Instructor PRIMARY KEY(NInstructor)
);

INSERT INTO Instructor VALUES
(200,"Nilda","Perez","DNI",21021021,"Yerbal 3456 Ramos Mejia Pcia Bs.As."),
(201,"Carlos","Lipis","DNI",19452452,"Ramon Falcon 784 CABA"),
(202,"Walter","Rodriguez","DNI",12123123,"Cucha Cucha 2345 CABA"),
(203,"Marai Olivia","Quiroz","DNI",23120120,"Av. Rivadavia 10120 CABA"),
(204,"Marianela Ines","Urtufart","DNI",24111000,"Laprida 152 Florida Pcia Bs. As."),
(205,"Miriam","Rojas","DNI",21000000,"Nueva Cruz 203 Haedo  Pcia Bs. As."),
(206,"Josefina","Juarez","DNI",35896698,"Olmos 1250 CABA");

CREATE TABLE Actividad(
NActividad INT,
NombreActividad VARCHAR(40),
DuracionMinutos INT,
MaxParticipantes INT,
CantInscriptos INT DEFAULT 0,
CostoDiario float,

CONSTRAINT pk_NActividad PRIMARY KEY(NActividad)
);

INSERT INTO Actividad (NActividad, NombreActividad, DuracionMinutos, MaxParticipantes, CantInscriptos, CostoDiario) VALUES
(100, 'Futbol', 45, 20, DEFAULT, 2350),
(101, 'Tenis', 45, 1, DEFAULT, 3220),
(102, 'Natacion', 30, 10, DEFAULT, 3800),
(103, 'Gimnasio', 25, 15, DEFAULT, 1560),
(104, 'Basquet', 20, 10, DEFAULT, 2100);

CREATE TABLE Edicion (
    IdEdicion INT AUTO_INCREMENT,
    NActividad INT,
    Fecha DATE,
    HorarioActividad TIME,
    DiasActividad VARCHAR(50),
    Instructor INT,
    CONSTRAINT pk_Edicion PRIMARY KEY (IdEdicion),
    CONSTRAINT fk_Edicion_Instructor FOREIGN KEY (Instructor) REFERENCES Instructor(NInstructor),
    CONSTRAINT fk_Edicion_Actividad FOREIGN KEY (NActividad) REFERENCES Actividad(NActividad)
);

INSERT INTO Edicion (IdEdicion, NActividad, Fecha, HorarioActividad, DiasActividad, Instructor) VALUES
(845, 100, '2024-12-04', '08:30:00', 'Lunes, Miércoles', 200),
(NULL, 101, '2024-12-04', '10:00:00', 'Martes, Jueves', 201),
(NULL, 102, '2024-12-06', '14:00:00', 'Viernes', 202),
(NULL, 103, '2024-12-04', '16:30:00', 'Lunes, Miércoles, Viernes', 203),
(NULL, 104, '2024-12-11', '09:00:00', 'Miércoles', 204);


CREATE TABLE Inscripcion (
    IdInscripcion INT AUTO_INCREMENT,
    TipoDocCliente VARCHAR(20),
    DocCliente VARCHAR(20),
    IdEdicion INT,
    FechaInscripcion DATE,
    Pagado BOOLEAN DEFAULT FALSE,
    CONSTRAINT pk_IdInscripcion PRIMARY KEY (IdInscripcion),
    CONSTRAINT fk_TipoDoc_DocCliente FOREIGN KEY (TipoDocCliente, DocCliente) REFERENCES Cliente (TDocC, DocC),
    CONSTRAINT fk_Inscripcion_Actividad FOREIGN KEY (IdEdicion) REFERENCES Edicion (IdEdicion)
);

/*
CREATE TABLE Pago(
	IdPago INT AUTO_INCREMENT,
	IdInscripcion INT,
	Monto FLOAT,
	Fecha DATE,
	CONSTRAINT pk_Pago PRIMARY KEY (IdPago),
	CONSTRAINT fk_Pago FOREIGN KEY (IdInscripcion) REFERENCES Inscripcion(IdInscripcion)
);
*/

CREATE TABLE Socio(
	IdSocio VARCHAR(20),
    IdCliente INT,
    CONSTRAINT pk_IdSocio PRIMARY KEY (IdSocio),
    CONSTRAINT fk_IdSocioCliente FOREIGN KEY (IdCliente) REFERENCES Cliente(IdCliente)
);

CREATE TABLE CuotaMensual(
    IdPago INT AUTO_INCREMENT,
    IdSocio VARCHAR(20),
    Monto FLOAT,
    FechaGeneracion DATE, -- Fecha en que se genera la cuota
    FechaVencimiento DATE, -- Fecha de vencimiento de la cuota
    EstadoPago BOOLEAN DEFAULT 0, -- 0 = Pendiente, 1 = Pagado
    CONSTRAINT pk_IdPago PRIMARY KEY (IdPago),
    CONSTRAINT fk_IdSocioCuota FOREIGN KEY (IdSocio) REFERENCES Socio(IdSocio)
);

    

/*Procedimiento para verificar si un usuario existe, es correcta la contraseña y si esta activo*/

DELIMITER //  
CREATE PROCEDURE IngresoLogin(IN Usu VARCHAR(20),IN Pass VARCHAR(15))
 BEGIN
 
	SELECT NomRol
	  FROM usuario AS u 
	 INNER JOIN roles AS r ON u.RolUsu = r.RolUsu
	 WHERE NombreUsu = Usu 
       AND PassUsu = Pass 
	   AND Activo = 1; 
END 
//
DELIMITER ;

# call IngresoLogin('dato1', 'dato2');


/*Procedimiento para crear un nuevo cliente*/
DROP PROCEDURE IF EXISTS NuevoCliente;

DELIMITER //
CREATE PROCEDURE NuevoCliente(
    IN Nom VARCHAR(30),
    IN Ape VARCHAR(40),
    IN Tip VARCHAR(20),
    IN Doc VARCHAR(20),
    IN FechaNac DATE,  
    IN Tel VARCHAR(20),  
    IN Domicilio VARCHAR(50),  
    IN Email VARCHAR(30),  
    IN EsSocio TINYINT,
    IN AptoFisico TINYINT,
    OUT rta INT
)
BEGIN
    DECLARE filas INT DEFAULT 0;
    DECLARE existe INT DEFAULT 0;

    SET filas = (SELECT COUNT(*) FROM cliente);

    IF filas = 0 THEN
        SET filas = 0; 
    ELSE
        SET filas = (SELECT MAX(idCliente) + 1 FROM cliente);  
    END IF;

    SET existe = (SELECT COUNT(*) FROM cliente WHERE TDocC = Tip AND DocC = Doc);

    IF existe = 0 THEN
        -- Insertar el nuevo cliente con todos los campos
        INSERT INTO cliente (idCliente, NombreC, ApellidoC, TDocC, DocC, FechaNacC, TelC, DomicilioC, EmailC, EsSocio, AptoFisico) 
        VALUES (filas, Nom, Ape, Tip, Doc, FechaNac, Tel, Domicilio, Email, EsSocio, AptoFisico);

        -- Retornar el nuevo conteo de clientes
        SET rta = filas; 
    ELSE
        -- Retornar el conteo de clientes existentes
        SET rta = existe;  
    END IF;		 
END //
DELIMITER ;

DELIMITER //
DROP PROCEDURE IF EXISTS InsActividad //

CREATE PROCEDURE InsActividad(IN TipoDoc VARCHAR(20), IN NumDocCliente VARCHAR(20), IN IdEdi INT, OUT rta INT)
 BEGIN
     DECLARE Filas INT DEFAULT 0;
	 DECLARE Existe INT DEFAULT 0;
     DECLARE Fecha_Actual DATE;
     DECLARE EsSocioC BOOLEAN DEFAULT FALSE;
     DECLARE Pago BOOLEAN DEFAULT FALSE;
     
	 SET Fecha_Actual = CURDATE();  -- Asigna la fecha actual (solo la fecha, sin la hora)
     SET rta = 0;  -- Asignar un valor predeterminado a 'rta'

     SET Filas = (SELECT count(*) FROM Inscripcion);
     IF Filas = 0 THEN
		SET Filas = 200; /* consideramos a este numero como el primer numero de postulante */
     ELSE
     /* -------------------------------------------------------------------------------
		buscamos el ultimo numero de inscripción almacenado para sumarle una unidad y
		considerarla como PRIMARY KEY de la tabla
		Lo mismo hacemos para alumno
   ___________________________________________________________________________ */
		SET Filas = (SELECT max(IdInscripcion) + 1 FROM Inscripcion);

		/* ---------------------------------------------------------
			para saber si ya esta almacenado el postulante
		------------------------------------------------------- */	
		SET Existe = (SELECT count(*) FROM Inscripcion WHERE TipoDocCliente = TipoDoc AND DocCliente = NumDocCliente AND IdEdicion = IdEdi);
     END IF;
     
      -- Determina si el cliente es socio
      SELECT EsSocio INTO EsSocioC FROM Cliente
      WHERE TDocC = TipoDoc AND DocC = NumDocCliente;

      -- Si es socio, entonces 'Pago' se establece en TRUE
      IF EsSocioC = TRUE THEN
        SET Pago = TRUE;
      END IF;
	 
	  IF Existe = 0 THEN	 
		 INSERT INTO Inscripcion VALUES(Filas, TipoDoc, NumDocCliente, IdEdi, Fecha_Actual, Pago);
         
         UPDATE Actividad AS a
		  INNER JOIN Edicion AS e ON e.NActividad = a.NActividad
            SET a.CantInscriptos = a.CantInscriptos + 1
          WHERE e.IdEdicion = IdEdi;
          
	  ELSE
		 SET rta = Existe;
      END IF;		 
     END //
DELIMITER ;


DELIMITER //
DROP PROCEDURE IF EXISTS RegCuotaSocio //

CREATE PROCEDURE RegCuotaSocio(
    IN P_IdCliente INT, -- Cambié el nombre del parámetro para evitar confusión
    IN Monto FLOAT,
    OUT rta INT
)
BEGIN
    DECLARE IdSocio VARCHAR(20);
    DECLARE Fecha_Actual DATE;
    DECLARE Fecha_Vencimiento DATE;
    DECLARE Existe INT DEFAULT 0;
    DECLARE Prefijo VARCHAR(20);
    DECLARE DocCliente VARCHAR(20);

    -- Obtener el DocCliente asociado al p_IdCliente
    SET DocCliente = (SELECT DocC FROM Cliente WHERE IdCliente = P_IdCliente LIMIT 1);
	SET Prefijo = "20-";
    -- Convertir p_IdCliente a VARCHAR, concatenarle el prefijo y luego convertir todo a INT
    SET IdSocio = concat(Prefijo,DocCliente);

    -- Asignar la fecha actual y una fecha de vencimiento (por ejemplo, 30 días después)
    SET Fecha_Actual = CURDATE();
    SET Fecha_Vencimiento = DATE_ADD(Fecha_Actual, INTERVAL 30 DAY);
    SET rta = 0;  -- Valor predeterminado de respuesta

    -- Insertar en la tabla Socio
    INSERT INTO Socio (IdSocio, IdCliente)
        VALUES (IdSocio, p_IdCliente);

    -- Insertar en la tabla CuotaMensual
    INSERT INTO CuotaMensual (IdSocio, Monto, FechaGeneracion, FechaVencimiento, EstadoPago)
        VALUES (IdSocio, Monto, Fecha_Actual, Fecha_Vencimiento, 0);

    -- Ajustar el valor de respuesta (puede representar éxito)
    SET rta = 1;

END //
DELIMITER ;



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
    'EXTRANJERO',     -- Tipo de Documento
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

-- Ejemplo 6: Cliente nuevo con apto físico, socio
CALL NuevoCliente(
    'Lucía',          -- Nombre
    'Fernández',      -- Apellido
    'DNI',            -- Tipo de Documento
    '33445566',       -- Documento
    '1995-03-22',     -- Fecha de Nacimiento
    '1144556677',     -- Teléfono
    'Calle Norte 456',-- Domicilio
    'lucia.fernandez@example.com', -- Email
    1,                -- EsSocio
    1,                -- AptoFisico
    @rta
);

-- Ejemplo 7: Cliente nuevo sin apto físico, no socio
CALL NuevoCliente(
    'Tomás',          -- Nombre
    'Sánchez',        -- Apellido
    'DNI',            -- Tipo de Documento
    '11223344',       -- Documento
    '1982-06-18',     -- Fecha de Nacimiento
    '1122113344',     -- Teléfono
    'Pasaje Central 202', -- Domicilio
    'tomas.sanchez@example.com', -- Email
    0,                -- EsSocio
    0,                -- AptoFisico
    @rta
);

-- Ejemplo 8: Cliente nuevo con apto físico, no socio
CALL NuevoCliente(
    'Valeria',        -- Nombre
    'Duarte',         -- Apellido
    'DNI',            -- Tipo de Documento
    '44556677',       -- Documento
    '2001-01-15',     -- Fecha de Nacimiento
    '1155778899',     -- Teléfono
    'Calle Oeste 123',-- Domicilio
    'valeria.duarte@example.com', -- Email
    0,                -- EsSocio
    1,                -- AptoFisico
    @rta
);

-- Ejemplo 9: Cliente nuevo sin apto físico, socio
CALL NuevoCliente(
    'Federico',       -- Nombre
    'Méndez',         -- Apellido
    'Pasaporte',      -- Tipo de Documento
    'F778899',        -- Documento
    '1975-12-05',     -- Fecha de Nacimiento
    '1144667788',     -- Teléfono
    'Bulevar Este 450', -- Domicilio
    'federico.mendez@example.com', -- Email
    1,                -- EsSocio
    0,                -- AptoFisico
    @rta
);

-- Ejemplo 10: Cliente nuevo con apto físico, socio
CALL NuevoCliente(
    'Elena',          -- Nombre
    'Quiroga',        -- Apellido
    'EXTRANJERO',     -- Tipo de Documento
    '67890123',       -- Documento
    '1992-10-29',     -- Fecha de Nacimiento
    '1133665544',     -- Teléfono
    'Av. del Centro 305', -- Domicilio
    'elena.quiroga@example.com', -- Email
    0,                -- EsSocio
    1,                -- AptoFisico
    @rta
);

-- Ejemplo 1: Registrar cuota para un cliente existente
CALL RegCuotaSocio(
    0,              -- P_IdCliente (Id de un cliente existente)
    9999.88,        -- Monto de la cuota
    @rta            -- Variable para recibir respuesta
);

-- Ejemplo 2: Registrar cuota para un cliente existente
CALL RegCuotaSocio(
    2,              -- P_IdCliente
	9999.88,        -- Monto de la cuota
    @rta
);

-- Ejemplo 3: Registrar cuota para un cliente existente
CALL RegCuotaSocio(
    3,              -- P_IdCliente
	9999.88,        -- Monto de la cuota
    @rta
);

-- Ejemplo 4: Registrar cuota para un cliente existente
CALL RegCuotaSocio(
    5,              -- P_IdCliente
	9999.88,        -- Monto de la cuota
    @rta
);

-- Ejemplo 5: Registrar cuota para un cliente existente
CALL RegCuotaSocio(
    8,              -- P_IdCliente
    9999.88,        -- Monto de la cuota
    @rta
);

-- Cambia la fecha de vencimiento al día actual para poder realizar las pruebas
UPDATE CuotaMensual
	SET 
		FechaGeneracion = DATE_SUB(CURDATE(), INTERVAL 1 MONTH),  -- Establece la fecha de inscripción como hace un mes
		FechaVencimiento = CURDATE()  -- Establece la fecha de vencimiento al día de hoy
  WHERE IdSocio IN ('20-12345678', '20-20304050', '20-33445566');  -- Usa los IdSocio con formato VARCHAR


