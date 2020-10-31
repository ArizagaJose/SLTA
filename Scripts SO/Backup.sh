#!/bin/bash
#Version 3
#Hecho por Lucas Giffuni
#Formato e indentaciones por José Arizaga

#Este script realiza los backups
clear
echo "Creando directorios necesarios"

mkdir backups
mkdir backups/lunes
mkdir backups/martes
mkdir backups/miercoles
mkdir backups/jueves
mkdir backups/viernes
mkdir backups/sabado
mkdir backups/domingo

echo "Realizando backup...."
dia=$(date +%d%m%Y)/
NombreDia=$(date +%A)

if [ $NombreDia = "Monday" ] then;
cd backups/lunes | tar -zcvf backup_`$dia`.tgz -g /regBackup/reg.snap /root/ /home/*

elif [ $NombreDia = "Tuesday" ] then;
cd backups/martes | tar -zcvf backup_`$dia`.tgz -g /regBackup/reg.snap /root/ /home/*

elif [ $NombreDia = "Wednesday" ] then;
cd backups/miercoles | tar -zcvf backup_`$dia`.tgz -g /regBackup/reg.snap /root/ /home/*

elif [ $NombreDia = "Thursday" ] then;
cd backups/jueves | tar -zcvf backup_`$dia`.tgz -g /regBackup/reg.snap /root/ /home/*

elif [ $NombreDia = "Friday" ] then;
cd backups/viernes | tar -zcvf backup_`$dia`.tgz -g /regBackup/reg.snap /root/ /home/*

elif [ $NombreDia = "Saturday" ] then;
cd backups/sabado | tar -zcvf backup_`$dia`.tgz -g /regBackup/reg.snap /root/ /home/*

elif [ $NombreDia = "Sunday" ] then;
cd backups/domingo | tar -zcvf backup_`$dia`.tgz -g /regBackup/reg.snap /root/ /home/*

fi
sleep 1.5
echo "Backup realizado"
sleep 0.5
echo "Los directorios root y Home de cada usuario han sido respaldados." 
