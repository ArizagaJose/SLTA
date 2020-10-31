#!/bin/bash
#Version 3
#Hecho por Lucas Giffuni
#Formato e indentaciones por José Arizaga

#Este script pone a punto el sistema para su correcto funcionamiento
clear 
let opc=10 
while [ $opc != 0 ] 
	do
		clear 

		echo ""
		echo "GESTOR DE INSTALACION"
		echo ""
		echo "#CONFIGURACION INICIAL AUTOMATICA#"
		echo "1- Instalacion inicial"
		echo ""
		echo "#INSTALACION MANUAL#"
		echo "2- Instalar paquetes necesarios"
		echo "3- Desinstalar servicios innecesarios"
		echo "4- Instalar SGBD Informix 12.10"
		echo "5- Desinstalar SGBD Informix 12.10"
		echo "0- Volver al menu anterior"
		echo ""
		echo -n "Seleccione opcion: "
		read opc
	
		case $opc in
			1)
				#Esta opcion realiza la configuracion inicial del servidor
				sudo yum -y remove NetworkManager
				sudo yum -y remove firewalld

				sudo yum -y install iptables
				sudo yum -y install rsync
				sudo yum -y install openssh openssh-server openssh-clients
				sudo yum -y install tar
				sudo yum -y install java-1.8.0-openjdk
				
				source /root/scripts/InstaladorInformix.sh

				echo "59 23 * * * root sh /root/scripts/Backup.sh" >> /etc/cron.d
				echo "30 * * * *  root last -i >> /root/logs.correctos" >> /etc/cron.d
				echo "30 * * * *  root lastb -i -F >> /root/logs.fallidos" >> /etc/cron.d
			;;
			
			
			2)
				echo ""
				echo "Instalando paquetes"
				echo ""
				sudo yum -y install rsync
				sudo yum -y install openssh openssh-server openssh-clients
				sudo yum -y install tar
				sudo yum -y install java-1.8.0-openjdk
				sudo yum -y install ncurses-compat-libs
				echo ""
				echo "Paquetes instalados de forma correcta"
				echo "Volviendo al menu"
				sleep 1.2
				clear
			;;
			3)
				echo ""
				echo "Desinstalando servicios innecesarios"
				echo ""	
				sudo yum remove NetworkManager 
				sudo yum remove firewalld
				echo ""
				echo "Servicios desintalados correctamente"
				echo "Volviendo al menu"
				sleep 1.2
				clear
			;;
			4)
				source /root/scripts/InstaladorInformix.sh
			;;

			0)
				clear
			;;
			*)
				echo "Opcion incorrecta"
				echo "Volviendo al menu"	
				sleep 0.75
				clear
			;;
		esac
	done
