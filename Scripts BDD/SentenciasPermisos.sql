/* Eliminacion de permisos para publico */
revoke connect from public;

/* Creacion de roles*/
Create role administrador;
Create role opatio;
Create role opuerto;
Create role transportista;

/* Asignacion de roles para las pruebas de los docentes en nuestro sistema */
/* grant default role administrador to jarizaga; */
/* grant default role opuerto to cdebethencourt; */
/* grant default role opatio to lgiffuni; */
/* grant default role transportista to acaballero; */

/* Permisos para administrador */
Grant all on lote to administrador;
Grant all on camion to administrador;
Grant all on vehiculo to administrador;
Grant all on lotecamion to administrador;
Grant all on funcionario to administrador;
Grant all on transportista to administrador;
Grant all on opuerto to administrador;
Grant all on opatio to administrador;
Grant all on administrador to administrador;
Grant all on inspeccion to administrador;
Grant all on inspeccionpatio to administrador;
Grant all on inspeccionpuerto to administrador;
Grant all on danio to administrador;
Grant all on patio to administrador;
Grant all on patioempresa to administrador;
Grant all on patiopuerto to administrador;
Grant all on zona to administrador;
Grant all on subzona to administrador;
Grant all on viaje to administrador;
Grant all on ubicacion to administrador;

/* Permisos para empleados*/
Grant insert, delete, update, select on vehiculo to opatio, opuerto;
Grant insert, select on inspeccion to opuerto;
Grant insert, delete, update on lote to opuerto;
Grant update on lote to opatio;
Grant insert, select, update on zona to opatio;
Grant select,update on lote to transportista;
Grant insert,update on lotecamion to transportista;
Grant insert,update on viaje to transportista;
Grant insert, select, update on ubicacion to  opatio;