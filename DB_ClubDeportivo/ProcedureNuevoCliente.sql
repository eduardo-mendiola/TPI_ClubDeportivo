DROP PROCEDURE IF EXISTS NuevoCliente;

DELIMITER //
CREATE PROCEDURE NuevoCliente(IN Nom VARCHAR(30),IN Ape VARCHAR(40),IN Tip VARCHAR(20), IN Doc INT, OUT rta INT)
 BEGIN
     DECLARE filas INT DEFAULT 0;
	 DECLARE existe INT DEFAULT 0;
    
     SET filas = (SELECT count(*) FROM cliente);
     IF filas = 0 THEN
		SET filas = 0; 
     ELSE
		SET filas = (SELECT max(NCliente) + 1 FROM cliente);
		SET existe = (SELECT count(*) FROM cliente WHERE TdocC = Tip AND DocC = Doc);
     END IF;
	  IF existe = 0 THEN	 
		 INSERT INTO cliente VALUES(filas,Nom,Ape,Tip,Doc);
		 SET rta  = filas;
	  ELSE
		 SET rta = existe;
      END IF;		 
     END //
DELIMITER ;