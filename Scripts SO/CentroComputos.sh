#!/bin/bash
#Version 3
#Hecho por Lucas Giffuni
#Formato e indentaciones por José Arizaga

#Este script permite desplegar servicios y procesos, encenderlos, apagarlos, activarlos
#desactivarlos y matarlos
clear 
let opc=10 
while [ $opc != 0 ] 
	do
		clear
		echo "Bienvenido al centro de computo"
		echo ""
		echo "Posibles operaciones:"
		echo ""
		echo "            SERVICIOS           "
		echo ""
		echo "1- Mostrar servicios disponibles"
		echo "2- Encender / apagar un servicio"
		echo "3- Activar / desactivar un servicio"
		echo "4- Mostrar informacion de los servicios activos"
		echo ""
		echo "            PROCESOS"
		echo ""
		echo "5- Mostrar procesos activos"
		echo "6- Eliminar procesos activos"
		echo "0- Salir"
		echo ""
		echo -n "Ingrese opcion: "
		read opc

		case $opc in

			1) 
				systemctl list-units --type service
				echo ""
				echo "Presione cualquier tecla para salir"
				read aux
			;;
			2)
				echo ""
				echo -n "Ingrese nombre del servicio el cual quiere iniciar/detener: "
				read serv
				echo ""
				echo "Que desea hacer con ese servicio?"
				echo -n "On/Off: "
				read opcServ

				if [ $opcServ == "On" ] 
					then 
						systemctl start $serv
						echo "Iniciando servicio...."
						echo ""
						sleep 0.75
						echo "El servicio ya ha iniciado" 
				fi
				if [ $opcServ == "Off" ]
					then
						systemctl stop $serv
						echo "Deteniendo servicio...."
						echo ""
						sleep 0.75
						echo "El servicio ha sido detenido"
				fi
			;;
			3)
				echo ""
		        echo -n"Ingrese nombre del servicio el cual quiere activar/desactivar: "
		        read serv
		        echo ""
		        echo "Que desea hacer con ese servicio?"
		        echo -n "On/Off: "
		        read opcServ

	        if [ $opcServ == "On" ]
	        	then
		            systemctl enable $serv
		            echo "Activando  servicio...."
		            echo ""
		            sleep 0.75
		            echo "El servicio ya esta activado"
	        fi
	        if [ $opcServ == "Off" ]
	            then
		            systemctl stop $serv
		            echo "Desactivando servicio...."
		            echo ""
		            sleep 0.75
		            echo "El servicio ha sido desactivado"
	    	fi
	    	;;
			4)
				systemd-cgtop
				echo ""
				echo "Presione cualquier tecla para salir"
				read aux
			;;
			5)
				clear
			 	echo ""
				echo "Listando lista de procesos activos"
				echo ""
				sleep 1.5
				ps -aux | grep whoami | more
				sleep 1.2
			;;
			6)
				clear
				echo ""
				echo -n "Ingrese el PID del proceso que quiera eliminar: "
				read proc
				echo ""
				echo "Elimando proceso."
				kill $proc
				sleep 1.2
				echo ""
				echo "Proceso elimiando correctamente."
			;;
			0)
				echo ""
				echo "Volviendo al menu anterior..."
				sleep 1.5
				clear
			;;
			*)
				echo ""
				echo "Opcion ingresada incorrectamente"
				echo "Volviendo al menu "
				sleep 1.5
				clear
			;;
		esac
	done
