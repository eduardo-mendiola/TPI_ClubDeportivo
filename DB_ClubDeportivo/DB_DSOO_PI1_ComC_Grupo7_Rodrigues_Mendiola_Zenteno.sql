/* DB_DSOO_PI1_ComC_Grupo7_Rodrigues_Mendiola_Zenteno */

DROP DATABASE IF EXISTS ClubDeportivo;
CREATE DATABASE ClubDeportivo;
USE ClubDeportivo;

CREATE TABLE roles(
	RolUsu INT,
	NomRol VARCHAR(30),
CONSTRAINT PRIMARY KEY(RolUsu)
);

INSERT INTO roles VALUES
(120,'Administrador'),
(121,'Cliente');

CREATE TABLE usuario(
	IdUsu INT AUTO_INCREMENT,
NombreUsu VARCHAR (20),
  PassUsu VARCHAR (15),
   RolUsu INT,
   Activo BOOLEAN DEFAULT TRUE,
CONSTRAINT pk_usuario PRIMARY KEY (IdUsu),
CONSTRAINT fk_usuario FOREIGN KEY(RolUsu) REFERENCES roles(RolUsu)
);

INSERT INTO usuario(NombreUsu,PassUsu,RolUsu) VALUES
('Cari', '1234',120),
('Edu', '1234', 120),
('Joa', '1234', 120),
('Jose', '1234', '121');

CREATE TABLE cliente(
idCliente INT,
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
CONSTRAINT pk_idCliente PRIMARY KEY(idCliente)
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
(101, 'Tenis', 45, 4, DEFAULT, 3220),
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
    IdCliente INT,
    IdEdicion INT,
    FechaInscripcion DATE,
    Pagado BOOLEAN DEFAULT FALSE,
    CONSTRAINT pk_IdInscripcion PRIMARY KEY(IdInscripcion),
    CONSTRAINT fk_IdCliente FOREIGN KEY(IdCliente) REFERENCES Cliente(IdCliente),
    CONSTRAINT fk_Inscripcion_Actividad FOREIGN KEY(IdEdicion) REFERENCES Edicion(IdEdicion)
);

CREATE TABLE Pago(
	IdPago INT AUTO_INCREMENT,
	IdInscripcion INT,
	Monto FLOAT,
	Fecha DATE,
	CONSTRAINT pk_Pago PRIMARY KEY (IdPago),
	CONSTRAINT fk_Pago FOREIGN KEY (IdInscripcion) REFERENCES Inscripcion(IdInscripcion)
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

CREATE PROCEDURE InsActividad(IN NumCliente INT, IN IdEdi INT, OUT rta INT)
 BEGIN
     DECLARE Filas int default 0;
	 DECLARE Primer int default 0;
	 DECLARE Existe int default 0;
     DECLARE Fecha_Actual DATE;
     DECLARE Pago boolean default false;
     
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
		SET Existe = (SELECT count(*) FROM Inscripcion WHERE IdCliente = NumCliente and IdEdicion = IdEdi);
     END IF;
	 
	  IF Existe = 0 THEN	 
		 INSERT INTO Inscripcion VALUES(Filas, NumCliente, IdEdi, Fecha_Actual, Pago);
	  ELSE
		 SET rta = Existe;
      END IF;		 
     END //
DELIMITER ;
