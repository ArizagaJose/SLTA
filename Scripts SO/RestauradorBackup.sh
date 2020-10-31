#!/bin/bash
#Version 3
#Hecho por Lucas Giffuni
#Formato e indentaciones por Lucas Giffuni

cd ~/backups | ls -tr | cat -b

echo -n"Ingrese dia de la semana para restarurar backup ,0 para salir: "
read NumSemana

#lunes
if [ $NumSemana = 1 ] then;
 	cd ~/backups/lunes | lista =('ls -tr')
	echo "restaurando backups del dia lunes..."
	sleep 1.5
	for LINEA in $lista ; do	
		tar -xvf $LINEA
	done

fi
#martes
if [ $NumSemana = 2 ] then;
 	cd ~/backups/martes | lista =('ls -tr')
	echo "restaurando backups del dia martes..."
	sleep 1.5
	for LINEA in $lista ; do	
		tar -xvf $LINEA
	done

fi
#miercoles
if [ $NumSemana = 3 ] then;
 	cd ~/backups/miercoles | lista =('ls -tr')
	echo "restaurando backups del dia miercoles..."
	sleep 1.5
	for LINEA in $lista ; do	
		tar -xvf $LINEA
	done

fi
#jueves
if [ $NumSemana = 4 ] then;
 	cd ~/backups/jueves | lista =('ls -tr')
	echo "restaurando backups del dia jueves..."
	sleep 1.5
	for LINEA in $lista ; do	
		tar -xvf $LINEA
	done

fi
#viernes
if [ $NumSemana = 5 ] then;
 	cd ~/backups/viernes | lista =('ls -tr')
	echo "restaurando backups del dia viernes..."
	sleep 1.5
	for LINEA in $lista ; do	
		tar -xvf $LINEA
	done

fi
#sabado
if [ $NumSemana = 6 ] then;
 	cd ~/backups/sabado | lista =('ls -tr')
	echo "restaurando backups del dia sabado..."
	sleep 1.5
	for LINEA in $lista ; do	
		tar -xvf $LINEA
	done

fi
#domingo
if [ $NumSemana = 7 ] then;
 	cd ~/backups/domingo | lista =('ls -tr')
	echo "restaurando backups del dia domingo..."
	sleep 1.5
	for LINEA in $lista ; do	
		tar -xvf $LINEA
	done

fi


