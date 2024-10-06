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

