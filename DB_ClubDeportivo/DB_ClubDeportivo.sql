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



/*  a partir de la semana 9  */


create table cliente(
NCliente int,
NombreC varchar(30),
ApellidoC varchar(40),
TDocC varchar(20),
DocC int,
constraint pk_postulante primary key(NCliente)
);


