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
DocC INT,
FechaNacC DATE,
TelC VARCHAR(20),
DomicilioC VARCHAR(50),
EmailC VARCHAR(30),


CONSTRAINT pk_idCliente PRIMARY KEY(idCliente)
);

CREATE TABLE Actividad(
idActividad INT AUTO_INCREMENT,
NombreActividad VARCHAR(20),
HorarioActividad DATETIME,
DiasActividad DATETIME,
DuracionMinutos INT,
MaxParticipantes INT,
CantInscriptos INT,
CuposLibres INT,
CostoDiario float,

CONSTRAINT pk_idActividad PRIMARY KEY(idActividad)
);

CREATE TABLE Inscripcion (
    idInscripcion INT AUTO_INCREMENT,
    idCliente INT,
    idActividad INT,
    FechaInscripcion DATE,
    CONSTRAINT pk_idInscripcion PRIMARY KEY(idInscripcion),
    CONSTRAINT fk_idCliente FOREIGN KEY(idCliente) REFERENCES cliente(idCliente),
    CONSTRAINT fk_idActividad FOREIGN KEY(idActividad) REFERENCES Actividad(idActividad)
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
    IN Doc INT,
    IN FechaNac DATE,  
    IN Tel VARCHAR(20),  
    IN Domicilio VARCHAR(50),  
    IN Email VARCHAR(30),  
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
        INSERT INTO cliente (idCliente, NombreC, ApellidoC, TDocC, DocC, FechaNacC, TelC, DomicilioC, EmailC) 
        VALUES (filas, Nom, Ape, Tip, Doc, FechaNac, Tel, Domicilio, Email);

        -- Retornar el nuevo conteo de clientes
        SET rta = filas; 
    ELSE
        -- Retornar el conteo de clientes existentes
        SET rta = existe;  
    END IF;		 
END //
DELIMITER ;




