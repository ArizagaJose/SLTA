#!/bin/bash
#Version 3
#Hecho por José Arizaga
#Formato e indentaciones por José Arizaga

#Este script realiza la instalacion del SGBD Informix Dynamic Server 12.10
clear

echo "¿En que puerto quiere que corra el servicio Informix?"
read puerto
echo -e "\n ¿En que directorio quiere instalar Informix? INGRESE RUTA ABSOLUTA"
echo "Recomendamos /opt/Informix"
echo "Luego tendrá que ingresar la misma ruta"
read ruta
echo -e "\n ¿Que nombre quiere que tenga el servidor?"
read nombreSV

groupadd informix
useradd -g informix -d /dev/null informix
passwd informix
mkdir -p $ruta
chown informix:informix $ruta
touch /etc/profile.d/informix.sh

echo "SQLHOSTS=$rutaetc/sqlhosts" >> /etc/profile.d/informix.sh
echo "INFORMIXDIR=$ruta" >> /etc/profile.d/informix.sh
echo "INFORMIXSERVER=$nombreSV" >> /etc/profile.d/informix.sh
echo "ONCONFIG=onconfig.std" >> /etc/profile.d/informix.sh
echo "PATH=$INFORMIX/bin:$PATH:$ruta/bin" >> /etc/profile.d/informix.sh
echo "export INFORMIXDIR PATH INFORMIXSERVER ONCONFIG SQLHOSTS" >> /etc/profile.d/informix.sh

mv /root/iif*.tar $ruta
cd $ruta
su informix -c "tar xvf $ruta/iif*.tar" 
./ids_install

touch $ruta/etc/sqlhosts
chown informix:informix $ruta/etc/sqlhosts
echo "#dbservername		nettype		hostname	servicename		options" >> $ruta/etc/sqlhosts
echo "$nombreSV		onsoctcp	192.168.1.5	informix" >> $ruta/etc/sqlhosts


sed -i "s@DBSERVERNAME.*@DBSERVERNAME ${nombreSV}@" $ruta/etc/onconfig.std
sed -i "s@ROOTPATH.*@ROOTPATH ${ruta}/logdir/rootdbs@" $ruta/etc/onconfig.std

su informix -c "mkdir $ruta/logdir"	
chown informix:informix $ruta/logdir
su informix -c "chmod 770 $ruta/logdir"
su informix -c "touch $ruta/logdir/rootdbs"
su informix -c "chmod 660 $ruta/logdir/rootdbs"
chown informix:informix $ruta/logdir/rootdbs

echo "informix		$puerto/tcp		#Servidor de Informix">> /etc/services

mkdir $ruta/dbspaces
chown informix:informix $ruta/dbspaces
cd $ruta
source /etc/profile.d/informix.sh

oninit -ivy

touch $ruta/dbspaces/datosdbs.dbspace 
chown informix:informix $ruta/dbspaces/datosdbs.dbspace
chmod 660 $ruta/dbspaces/datosdbs.dbspace

onspaces -c -d datosdbs -p $ruta/dbspaces/datosdbs.dbspace -o 0 -s 1000000
clear

onstat -
echo "Instalacion completa"

