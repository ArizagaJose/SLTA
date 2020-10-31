#!/bin/bash
#Version 3
#Hecho por Lucas Giffuni
#Formato e indentaciones por José Arizaga

#Este script fue realizado para realizar Altas, Bajas y Modificaciones
#de los usuarios del sistema
clear 
let opc=10 
while [ $opc != 0 ] 
	do
		clear 
		echo "ABM Usuarios" 
		echo "1) Crear grupos correspondientes" 
		echo "2) Alta Usuarios" 
		echo "3) Modificar Usuarios" 
		echo "4) Baja usuarios" 
		echo "0) Salir" 
		echo "" 
		echo -n "Ingrese option: "
		read opc

		case $opc in
			1) 
				clear 
				echo "Crear grupos" 
				echo "Creando grupos de:" 
				echo "Administrador" 
				echo "Transportista" 
				echo "Operario.puerto" 
				echo "Operario.patio" 
				sleep 0.5 
				groupadd Administrador 
				groupadd Transportista 
				groupadd Operario.puerto 
				groupadd Operario.patio 
				echo "" 
				echo "Grupos creados"
			;;
			2) 
				clear 
				echo "Alta Usuarios" 
				echo "" echo -n "ingrese nombre usuario: "
				read Name

				echo "Ingrese grupo del usuario" 
				echo "" 
				echo "A) Administrador" 
				echo "B) Transportista" 
				echo "C) Operario.puerto" 
				echo "D) Operario.patio" 
				echo -n "Ingrese opcion: " 
				read opcG 
				case $opcG in 
					A) 
						Group="Administrador" 
					;;
					B)
						Group="Transportista"
					;; 
					C)
						Group="Operario.puerto"
					;;
					D) 
						Group="Operario.patio"
					;;
				esac
 
				echo "" 
				echo "Creando usuario..." 
				sleep 0.5 
				useradd -d /home/$Name -g $Group -m -s /bin/bash $Name
				echo "Usuario creado" 
				echo "" 
				echo "Desea cambiarle la contraseña? s/n" 
				read opcP 
				if [ $opcP == "s" ] 
					then 
						passwd $Name 
						echo "" 
						echo "Presione cualquier tecla"
						read aux 
				fi
				if [ $opcP == "n" ] 
					then 
						echo "Contraseña por defecto: $Name" 
				fi
			;;
			3) 
				clear 
				echo "Modificar Usuario" 
				echo "" 
				echo "Mostrando lista de usuarios"
				echo "" 
				cat /etc/passwd | sort | cut -d ":" -fl | column 
				echo "" 
				echo "" 
				echo "" 
				echo -n "Ingrese Nombre del usuario a modificar: "
				read Name 
				echo ""
				let opcM=10 
				while [ $opcM != 0 ] 
					do
						echo "1) Modificar Nombre"
						echo "2) Modificar Contraseña" 
						echo "3) Modificar Grupo"
						echo "0) Volver al menu anterior"
						echo "" 
						echo -n "Seleccione opcion: "
						read opcM 
						case $opcM in 
							1) 
								clear 
								echo -n "Ingrese nuevo nombre de usuario: "
								read newName 
								usermod -1 $newName -d /home/$newName -m $Name 
								echo "Nombre de usuario modificado exitosamente" 
								sleep 1
							;;
							2) 
								clear 
								passwd $name 
								echo "Contraseña del usuario modificada exitosamente"
							;; 
							3) 
								clear 
								echo "Ingrese nuevo grupo" 
								echo "" 
								echo "Lista de grupos"
								echo "" 
								echo "A) Administrador" 
								echo "B) Transportista" 
								echo "C) Operario.puerto" 
								echo "D) Operario.patio" 
								echo ""
								echo -n "Ingrese opcion: " 
								read opcG 
								if [ $opcG == "A" ] 
									then 
										newGroup="1001"
								fi 
								if [ $opcG == "B" ] 
									then 
										newGroup="1002" 
								fi
								if [ $opcG == "C" ]
									then 
										newGroup="1003" 
								fi 
								if [ $opcG == "D" ] 
									then 
										newGroup="1004" 
								fi 
								echo "Modificando grupo.."
								sleep 0.5 
								usermod -g $newGroup $Name 
								echo "" 
								echo "Grupo del usuario modificado exitosamente" 
							;;
						esac 
					done

			;;
			4)
				clear 
				echo "Baja Usuarios" 
				echo "" 
				cat /etc/passwd | sort | cut -d ":" -f1 | column 
				echo "" 
				echo "" 
				echo "" 
				echo -n "Ingrese nombre del usuario a borrar: "
				read delName 
				/usr/sbin/userdel -r $delName 
				echo "Usuario borrado exitosamente" 
				sleep 1 
			;;
		esac
	done
