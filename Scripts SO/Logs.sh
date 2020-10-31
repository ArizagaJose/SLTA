#!/bin/bash
#Version 3
#Hecho por José Arizaga
#Formato e indentaciones por José Arizaga

#Este script despliega los logs de intentos de sesion (exitosos o fallidos)

let opc=10
while [ $opc != 0 ]
	do
		clear	
		echo "Menu de Logs"
		echo "1- Ver historico de usuarios logeados"
		echo "2- Ver intentos de log fallidos"
		echo "3- Ver usuarios logeados actualemente"
		echo "0- Salir"
		read opc
		
		case $opc in
			
			1) 
				cat /root/logs.correctos| grep -v "still logged in" | grep -v "reboot" | more
				echo "Filtros:"
				echo "1- Por nombre de usuario"
				echo "2- Por fechas"
				read opc2
				
				case $opc2 in
					1)
						echo -n "Ingrese nombre de usuario: " 
						read usr
						cat /root/logs.correctos-F | head -n -1 | grep  -v "still logged in" | grep -v "reboot" | grep -w $usr | more
					;;
					
					2)
						#A continuacion se prepara el last y se lo manda a un archivo para su mejor manejo
						#Se cambian todos los espacios por ";" y se borran los ";" repetidos
						
						#Se eliminan los usuarios ya logueados y los reinicios de sistema para solo poder visualizar el historico, solo se manejan 
						#fechas de entrada y no de salida
						
						#Este archivo (aux) solo existira mientras el script se este ejecutando
						cat /root/logs.correctos-F| head -n -1 | grep -v "still logged in" | grep -v "reboot" | tr ' \t' ";" | tr -s ";" > aux
						echo -n "Ingrese fecha inicial (formato MM-DD-AAAA): "
						read fechaIni
						echo -n "Ingrese fecha final (formato MM-DD-AAAA): "
						read fechaFin
						#UTS por Unix Timestamp
						UTSIni=$(date -d$fechaIni +%s)
						UTSFin=$(date -d$fechaFin +%s)
						while IFS= read -r linea 
							do
								echo "$linea" > aux2
								dia=$(cut -d";" -f6 < aux2)
								mes=$(cut -d";" -f5 < aux2)
								anio=$(cut -d";" -f8 < aux2)
								rm aux2 
								fechaCompleta=($mes-$dia-$anio)
								fechaLineaUTS=$(date -d$fechaCompleta +%s)
								if [ $fechaLineaUTS -ge $UTSIni ] && [ $fechaLineaUTS -le $UTSFin ] 
									then
										echo "$linea" >> logsAux
								fi
								
							done < aux 
						cat logsAux | tr ";" ' \t' | more
						rm logsAux
						rm aux
					;;
					
				esac
			;;	
			2)
				lastb
				echo "Filtros:"
				echo "1- Por nombre de usuario"
				echo "2- Por fechas"
				read opc3
				
				case $opc3 in
					1)
					echo -n "Ingrese nombre de usuario: "
					read usr
					cat /root/logs.fallidos| head -n -1 | grep -w "$usr" | more
					;;

					2)
						#El codigo es casi el mismo para lastb
						cat /root/logs.fallidos| head -n -1 | tr ' \t' ";" | tr -s ";" > aux
						echo -n "Ingrese fecha inicial (formato MM-DD-AAAA): "
						read fechaIni
						echo -n "Ingrese fecha final (formato MM-DD-AAAA): "
						read fechaFin
						#UTS por Unix Timestamp
						UTSIni=$(date -d$fechaIni +%s)
						UTSFin=$(date -d$fechaFin +%s)
						while IFS= read -r linea 
							do
								echo "$linea" > aux2
								dia=$(cut -d";" -f6 < aux2)
								mes=$(cut -d";" -f5 < aux2)
								anio=$(cut -d";" -f8 < aux2)
								rm aux2 
								fechaCompleta=($mes-$dia-$anio)
								fechaLineaUTS=$(date -d$fechaCompleta +%s)
								if [ $fechaLineaUTS -ge $UTSIni ] && [ $fechaLineaUTS -le $UTSFin ] 
									then
										echo "$linea" >> logsAux
								fi
								
							done < aux 
						#Se devuelve a un formato mas "human-readable"
						cat logsAux | tr ";" ' \t' | more
						rm logsAux
						rm aux
					;;
					
				esac
			;;
			3)
				who
				echo ""
				echo "Presione cualquier tecla para salir"
				read -n1
			;;	
			0)
				let opc=0
				clear
			;;
			*)
				echo "Esa opción no es valida"
			;;
		esac
	done