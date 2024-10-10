Use ClubDeportivo;
select * from usuario;

call IngresoLogin('Cari', '1234');
call IngresoLogin('Edu', '1234');
call IngresoLogin('Joa', '1234');

UPDATE usuario
   SET Activo = FALSE
WHERE NombreUsu = 'Jose';

SELECT * FROM usuario;
call IngresoLogin('Jose', '1234'); # Como no esta activo no el procedimiento devuelve no devuelve el rol.

SELECT * FROM cliente;