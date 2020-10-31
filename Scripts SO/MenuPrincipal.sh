#!/bin/bash
#Version 3
#Hecho por Lucas Giffuni y José Arizaga
#Formato e indentaciones por José Arizaga


clear
let opc=10 
while [ $opc != 0 ] 
	do
		echo "############Menu#############"
		echo ""
		echo "Que desea hacer?"
		echo "1- Instalador"
		echo "2- ABM Usuarios"
		echo "3- Logs"
		echo "4- Gestor de backups"
		echo "5- Centro de computo"
		echo "0- Salir"
		echo -n "Ingrese opcion: "
		read opc
		case $opc in
			1) 
				echo "Iniciando gestor de instalacion"
				sleep 0.5
				clear
				source gestorInstall.sh	
			;;

			2)
				echo "Iniciando ABM Usuarios"
				sleep 0.5
				clear
				source ABMUsuarios.sh	

			;;
	
			3)
				echo "Iniciando Logs"
				sleep 0.5
				clear
				source Logs.sh	
			;;

			4)
				echo "Iniciando Gestor de backups"
				sleep 0.5
				clear
				source RestauradorBackup.sh	
			;;

			5)
				echo "Iniciando Centro de computo"
				sleep 0.5
				clear
				source centroComputo.sh
				;;	
			0)

			;;
			*)
				echo ""
				echo "Opcion incorrecta"
				echo "Volviendo al menu anterior"
				sleep 0.75
				clear
			;;

		esac
	done

