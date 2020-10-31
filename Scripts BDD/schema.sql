grant dba to "jarizaga";


create role "administrador" ;
create role "opatio" ;
create role "opuerto" ;
create role "transportista" ;

grant "administrador" to "jarizaga" ;
grant "opuerto" to "cdebethencourt" ;
grant "opatio" to "lgiffuni" ;
grant "transportista" to "acaballero" ;

grant default role "administrador" to "jarizaga" ;
grant default role "opuerto" to "cdebethencourt" ;
grant default role "opatio" to "lgiffuni" ;
grant default role "transportista" to "acaballero" ;








{ TABLE "jarizaga".lote row size = 21 number of columns = 4 index size = 9 }

create table "jarizaga".lote 
  (
    idlote serial not null ,
    capacidad integer not null ,
    estado varchar(10) not null ,
    baja "informix".boolean 
        default 'f' not null ,
    
    check (((estado = 'Armado' ) OR (estado = 'En viaje' ) ) OR (estado = 'Arribado' ) 
              ),
    primary key (idlote)  constraint "jarizaga".pk_lote
  );

revoke all on "jarizaga".lote from "public" as "jarizaga";

{ TABLE "jarizaga".camion row size = 174 number of columns = 7 index size = 9 }

create table "jarizaga".camion 
  (
    idcamion serial not null ,
    capacidad integer not null ,
    matricula varchar(10) not null ,
    correo varchar(50) not null ,
    contrasenia varchar(50) not null ,
    telefono varchar(50) not null ,
    baja "informix".boolean 
        default 'f' not null ,
    primary key (idcamion)  constraint "jarizaga".pk_camion
  );

revoke all on "jarizaga".camion from "public" as "jarizaga";

{ TABLE "jarizaga".vehiculo row size = 126 number of columns = 10 index size = 41 }

create table "jarizaga".vehiculo 
  (
    vin varchar(17) not null ,
    idvehiculo serial not null ,
    marca varchar(20) not null ,
    modelo varchar(20) not null ,
    anio datetime year to year not null ,
    color varchar(10) not null ,
    pais varchar(25) not null ,
    tipo varchar(15) not null ,
    baja "informix".boolean 
        default 'f' not null ,
    idlote integer,
    unique (idvehiculo)  constraint "jarizaga".uq_vehiculo,
    
    check (LENGTH (vin ) = 17 ),
    
    check (((tipo = 'Auto' ) OR (tipo = 'Camioneta' ) ) OR (tipo = 'SUV' ) ),
    primary key (vin)  constraint "jarizaga".pk_vehiculo
  );

revoke all on "jarizaga".vehiculo from "public" as "jarizaga";

{ TABLE "jarizaga".lotecamion row size = 10 number of columns = 3 index size = 18 }

create table "jarizaga".lotecamion 
  (
    idcamion integer not null ,
    idlote integer not null ,
    baja "informix".boolean 
        default 'f' not null ,
    primary key (idlote)  constraint "jarizaga".pk_lotecamion
  );

revoke all on "jarizaga".lotecamion from "public" as "jarizaga";

{ TABLE "jarizaga".funcionario row size = 77 number of columns = 7 index size = 18 }

create table "jarizaga".funcionario 
  (
    ci integer not null ,
    nrofuncionario integer not null ,
    nombre varchar(20) not null ,
    apellido varchar(20) not null ,
    user varchar(20) not null ,
    telefono integer not null ,
    baja "informix".boolean 
        default 'f' not null ,
    unique (nrofuncionario)  constraint "jarizaga".uq_funcionario,
    primary key (ci)  constraint "jarizaga".pk_funcionario
  );

revoke all on "jarizaga".funcionario from "public" as "jarizaga";

{ TABLE "jarizaga".transportista row size = 6 number of columns = 2 index size = 9 }

create table "jarizaga".transportista 
  (
    ci integer not null ,
    baja "informix".boolean 
        default 'f' not null ,
    primary key (ci)  constraint "jarizaga".pk_transportista
  );

revoke all on "jarizaga".transportista from "public" as "jarizaga";

{ TABLE "jarizaga".opuerto row size = 6 number of columns = 2 index size = 9 }

create table "jarizaga".opuerto 
  (
    ci integer not null ,
    baja "informix".boolean 
        default 'f' not null ,
    primary key (ci)  constraint "jarizaga".pk_opuerto
  );

revoke all on "jarizaga".opuerto from "public" as "jarizaga";

{ TABLE "jarizaga".opatio row size = 6 number of columns = 2 index size = 9 }

create table "jarizaga".opatio 
  (
    ci integer not null ,
    baja "informix".boolean 
        default 'f' not null ,
    primary key (ci)  constraint "jarizaga".pk_opatio
  );

revoke all on "jarizaga".opatio from "public" as "jarizaga";

{ TABLE "jarizaga".administrador row size = 6 number of columns = 2 index size = 9 }

create table "jarizaga".administrador 
  (
    ci integer not null ,
    baja "informix".boolean 
        default 'f' not null ,
    primary key (ci)  constraint "jarizaga".pk_administrador
  );

revoke all on "jarizaga".administrador from "public" as "jarizaga";

{ TABLE "jarizaga".inspeccion row size = 29 number of columns = 4 index size = 30 }

create table "jarizaga".inspeccion 
  (
    idinspeccion smallint,
    fecha datetime year to minute not null ,
    vin varchar(17) not null ,
    baja "informix".boolean 
        default 'f' not null ,
    primary key (idinspeccion)  constraint "jarizaga".pk_inspeccion
  );

revoke all on "jarizaga".inspeccion from "public" as "jarizaga";

{ TABLE "jarizaga".inspeccionpatio row size = 8 number of columns = 3 index size = 7 }

create table "jarizaga".inspeccionpatio 
  (
    idinspeccion smallint not null ,
    ci integer not null ,
    baja "informix".boolean 
        default 'f' not null ,
    primary key (idinspeccion)  constraint "jarizaga".pk_inspeccionpatio
  );

revoke all on "jarizaga".inspeccionpatio from "public" as "jarizaga";

{ TABLE "jarizaga".inspeccionpuerto row size = 8 number of columns = 3 index size = 7 }

create table "jarizaga".inspeccionpuerto 
  (
    idinspeccion smallint not null ,
    ci integer not null ,
    baja "informix".boolean 
        default 'f' not null ,
    primary key (idinspeccion)  constraint "jarizaga".pk_inspeccionpuerto
  );

revoke all on "jarizaga".inspeccionpuerto from "public" as "jarizaga";

{ TABLE "jarizaga".danio row size = 210 number of columns = 5 index size = 16 }

create table "jarizaga".danio 
  (
    iddanio serial not null ,
    descripcion varchar(100) not null ,
    imagen varchar(100),
    baja "informix".boolean 
        default 'f' not null ,
    idinspeccion smallint not null ,
    primary key (iddanio)  constraint "jarizaga".pk_danio
  );

revoke all on "jarizaga".danio from "public" as "jarizaga";

{ TABLE "jarizaga".patio row size = 40 number of columns = 5 index size = 9 }

create table "jarizaga".patio 
  (
    idpatio serial not null ,
    nombre varchar(20) not null ,
    tipo varchar(10) not null ,
    capacidad smallint not null ,
    baja "informix".boolean 
        default 'f' not null ,
    
    check ((tipo = 'nacional' ) OR (tipo = 'fiscal' ) ),
    primary key (idpatio)  constraint "jarizaga".pk_patio
  );

revoke all on "jarizaga".patio from "public" as "jarizaga";

{ TABLE "jarizaga".patioempresa row size = 6 number of columns = 2 index size = 9 }

create table "jarizaga".patioempresa 
  (
    idpatio integer not null ,
    baja "informix".boolean 
        default 'f' not null ,
    primary key (idpatio)  constraint "jarizaga".pk_patioempresa
  );

revoke all on "jarizaga".patioempresa from "public" as "jarizaga";

{ TABLE "jarizaga".patiopuerto row size = 6 number of columns = 2 index size = 9 }

create table "jarizaga".patiopuerto 
  (
    idpatio integer not null ,
    baja "informix".boolean 
        default 'f' not null ,
    primary key (idpatio)  constraint "jarizaga".pk_patiopuerto
  );

revoke all on "jarizaga".patiopuerto from "public" as "jarizaga";

{ TABLE "jarizaga".zona row size = 65 number of columns = 7 index size = 16 }

create table "jarizaga".zona 
  (
    idzona smallint,
    capacidad smallint not null ,
    nombre varchar(50) not null ,
    idpatio integer not null ,
    estibas smallint not null ,
    filas smallint not null ,
    baja "informix".boolean 
        default 'f' not null ,
    primary key (idzona)  constraint "jarizaga".pk_zonas
  );

revoke all on "jarizaga".zona from "public" as "jarizaga";

{ TABLE "jarizaga".subzona row size = 63 number of columns = 7 index size = 16 }

create table "jarizaga".subzona 
  (
    idsubzona smallint,
    idzona smallint not null ,
    capacidad smallint not null ,
    nombre varchar(50) not null ,
    estibas smallint not null ,
    filas smallint not null ,
    baja "informix".boolean 
        default 'f' not null ,
    primary key (idsubzona,idzona)  constraint "jarizaga".pk_subzonas
  );

revoke all on "jarizaga".subzona from "public" as "jarizaga";

{ TABLE "jarizaga".viaje row size = 35 number of columns = 7 index size = 47 }

create table "jarizaga".viaje 
  (
    idlote integer not null ,
    idpatio integer not null ,
    fechainicio datetime year to minute not null ,
    fechaestimada datetime year to minute,
    fechafinal datetime year to minute,
    ci integer not null ,
    baja "informix".boolean 
        default 'f' not null ,
    primary key (idlote,idpatio,fechainicio)  constraint "jarizaga".pk_viaje
  );

revoke all on "jarizaga".viaje from "public" as "jarizaga";

{ TABLE "jarizaga".ubicacion row size = 24 number of columns = 4 index size = 23 }

create table "jarizaga".ubicacion 
  (
    vin varchar(17) not null ,
    estibas smallint not null ,
    filas smallint not null ,
    baja "informix".boolean 
        default 'f' not null ,
    
    check (LENGTH (vin ) = 17 ),
    primary key (vin)  constraint "jarizaga".pk_ubicacion
  );

revoke all on "jarizaga".ubicacion from "public" as "jarizaga";


grant select on "jarizaga".lote to "administrador" as "jarizaga";
grant update on "jarizaga".lote to "administrador" as "jarizaga";
grant insert on "jarizaga".lote to "administrador" as "jarizaga";
grant delete on "jarizaga".lote to "administrador" as "jarizaga";
grant index on "jarizaga".lote to "administrador" as "jarizaga";
grant alter on "jarizaga".lote to "administrador" as "jarizaga";
grant references on "jarizaga".lote to "administrador" as "jarizaga";
grant update on "jarizaga".lote to "opatio" as "jarizaga";
grant update on "jarizaga".lote to "opuerto" as "jarizaga";
grant insert on "jarizaga".lote to "opuerto" as "jarizaga";
grant delete on "jarizaga".lote to "opuerto" as "jarizaga";
grant select on "jarizaga".lote to "public" as "jarizaga";
grant update on "jarizaga".lote to "public" as "jarizaga";
grant insert on "jarizaga".lote to "public" as "jarizaga";
grant delete on "jarizaga".lote to "public" as "jarizaga";
grant index on "jarizaga".lote to "public" as "jarizaga";
grant select on "jarizaga".lote to "transportista" as "jarizaga";
grant update on "jarizaga".lote to "transportista" as "jarizaga";
grant select on "jarizaga".camion to "administrador" as "jarizaga";
grant update on "jarizaga".camion to "administrador" as "jarizaga";
grant insert on "jarizaga".camion to "administrador" as "jarizaga";
grant delete on "jarizaga".camion to "administrador" as "jarizaga";
grant index on "jarizaga".camion to "administrador" as "jarizaga";
grant alter on "jarizaga".camion to "administrador" as "jarizaga";
grant references on "jarizaga".camion to "administrador" as "jarizaga";
grant select on "jarizaga".camion to "public" as "jarizaga";
grant update on "jarizaga".camion to "public" as "jarizaga";
grant insert on "jarizaga".camion to "public" as "jarizaga";
grant delete on "jarizaga".camion to "public" as "jarizaga";
grant index on "jarizaga".camion to "public" as "jarizaga";
grant select on "jarizaga".vehiculo to "administrador" as "jarizaga";
grant update on "jarizaga".vehiculo to "administrador" as "jarizaga";
grant insert on "jarizaga".vehiculo to "administrador" as "jarizaga";
grant delete on "jarizaga".vehiculo to "administrador" as "jarizaga";
grant index on "jarizaga".vehiculo to "administrador" as "jarizaga";
grant alter on "jarizaga".vehiculo to "administrador" as "jarizaga";
grant references on "jarizaga".vehiculo to "administrador" as "jarizaga";
grant select on "jarizaga".vehiculo to "opatio" as "jarizaga";
grant update on "jarizaga".vehiculo to "opatio" as "jarizaga";
grant insert on "jarizaga".vehiculo to "opatio" as "jarizaga";
grant delete on "jarizaga".vehiculo to "opatio" as "jarizaga";
grant select on "jarizaga".vehiculo to "opuerto" as "jarizaga";
grant update on "jarizaga".vehiculo to "opuerto" as "jarizaga";
grant insert on "jarizaga".vehiculo to "opuerto" as "jarizaga";
grant delete on "jarizaga".vehiculo to "opuerto" as "jarizaga";
grant select on "jarizaga".vehiculo to "public" as "jarizaga";
grant update on "jarizaga".vehiculo to "public" as "jarizaga";
grant insert on "jarizaga".vehiculo to "public" as "jarizaga";
grant delete on "jarizaga".vehiculo to "public" as "jarizaga";
grant index on "jarizaga".vehiculo to "public" as "jarizaga";
grant select on "jarizaga".lotecamion to "administrador" as "jarizaga";
grant update on "jarizaga".lotecamion to "administrador" as "jarizaga";
grant insert on "jarizaga".lotecamion to "administrador" as "jarizaga";
grant delete on "jarizaga".lotecamion to "administrador" as "jarizaga";
grant index on "jarizaga".lotecamion to "administrador" as "jarizaga";
grant alter on "jarizaga".lotecamion to "administrador" as "jarizaga";
grant references on "jarizaga".lotecamion to "administrador" as "jarizaga";
grant select on "jarizaga".lotecamion to "public" as "jarizaga";
grant update on "jarizaga".lotecamion to "public" as "jarizaga";
grant insert on "jarizaga".lotecamion to "public" as "jarizaga";
grant delete on "jarizaga".lotecamion to "public" as "jarizaga";
grant index on "jarizaga".lotecamion to "public" as "jarizaga";
grant update on "jarizaga".lotecamion to "transportista" as "jarizaga";
grant insert on "jarizaga".lotecamion to "transportista" as "jarizaga";
grant select on "jarizaga".funcionario to "administrador" as "jarizaga";
grant update on "jarizaga".funcionario to "administrador" as "jarizaga";
grant insert on "jarizaga".funcionario to "administrador" as "jarizaga";
grant delete on "jarizaga".funcionario to "administrador" as "jarizaga";
grant index on "jarizaga".funcionario to "administrador" as "jarizaga";
grant alter on "jarizaga".funcionario to "administrador" as "jarizaga";
grant references on "jarizaga".funcionario to "administrador" as "jarizaga";
grant select on "jarizaga".funcionario to "public" as "jarizaga";
grant update on "jarizaga".funcionario to "public" as "jarizaga";
grant insert on "jarizaga".funcionario to "public" as "jarizaga";
grant delete on "jarizaga".funcionario to "public" as "jarizaga";
grant index on "jarizaga".funcionario to "public" as "jarizaga";
grant select on "jarizaga".transportista to "administrador" as "jarizaga";
grant update on "jarizaga".transportista to "administrador" as "jarizaga";
grant insert on "jarizaga".transportista to "administrador" as "jarizaga";
grant delete on "jarizaga".transportista to "administrador" as "jarizaga";
grant index on "jarizaga".transportista to "administrador" as "jarizaga";
grant alter on "jarizaga".transportista to "administrador" as "jarizaga";
grant references on "jarizaga".transportista to "administrador" as "jarizaga";
grant select on "jarizaga".transportista to "public" as "jarizaga";
grant update on "jarizaga".transportista to "public" as "jarizaga";
grant insert on "jarizaga".transportista to "public" as "jarizaga";
grant delete on "jarizaga".transportista to "public" as "jarizaga";
grant index on "jarizaga".transportista to "public" as "jarizaga";
grant select on "jarizaga".opuerto to "administrador" as "jarizaga";
grant update on "jarizaga".opuerto to "administrador" as "jarizaga";
grant insert on "jarizaga".opuerto to "administrador" as "jarizaga";
grant delete on "jarizaga".opuerto to "administrador" as "jarizaga";
grant index on "jarizaga".opuerto to "administrador" as "jarizaga";
grant alter on "jarizaga".opuerto to "administrador" as "jarizaga";
grant references on "jarizaga".opuerto to "administrador" as "jarizaga";
grant select on "jarizaga".opuerto to "public" as "jarizaga";
grant update on "jarizaga".opuerto to "public" as "jarizaga";
grant insert on "jarizaga".opuerto to "public" as "jarizaga";
grant delete on "jarizaga".opuerto to "public" as "jarizaga";
grant index on "jarizaga".opuerto to "public" as "jarizaga";
grant select on "jarizaga".opatio to "administrador" as "jarizaga";
grant update on "jarizaga".opatio to "administrador" as "jarizaga";
grant insert on "jarizaga".opatio to "administrador" as "jarizaga";
grant delete on "jarizaga".opatio to "administrador" as "jarizaga";
grant index on "jarizaga".opatio to "administrador" as "jarizaga";
grant alter on "jarizaga".opatio to "administrador" as "jarizaga";
grant references on "jarizaga".opatio to "administrador" as "jarizaga";
grant select on "jarizaga".opatio to "public" as "jarizaga";
grant update on "jarizaga".opatio to "public" as "jarizaga";
grant insert on "jarizaga".opatio to "public" as "jarizaga";
grant delete on "jarizaga".opatio to "public" as "jarizaga";
grant index on "jarizaga".opatio to "public" as "jarizaga";
grant select on "jarizaga".administrador to "administrador" as "jarizaga";
grant update on "jarizaga".administrador to "administrador" as "jarizaga";
grant insert on "jarizaga".administrador to "administrador" as "jarizaga";
grant delete on "jarizaga".administrador to "administrador" as "jarizaga";
grant index on "jarizaga".administrador to "administrador" as "jarizaga";
grant alter on "jarizaga".administrador to "administrador" as "jarizaga";
grant references on "jarizaga".administrador to "administrador" as "jarizaga";
grant select on "jarizaga".administrador to "public" as "jarizaga";
grant update on "jarizaga".administrador to "public" as "jarizaga";
grant insert on "jarizaga".administrador to "public" as "jarizaga";
grant delete on "jarizaga".administrador to "public" as "jarizaga";
grant index on "jarizaga".administrador to "public" as "jarizaga";
grant select on "jarizaga".inspeccion to "administrador" as "jarizaga";
grant update on "jarizaga".inspeccion to "administrador" as "jarizaga";
grant insert on "jarizaga".inspeccion to "administrador" as "jarizaga";
grant delete on "jarizaga".inspeccion to "administrador" as "jarizaga";
grant index on "jarizaga".inspeccion to "administrador" as "jarizaga";
grant alter on "jarizaga".inspeccion to "administrador" as "jarizaga";
grant references on "jarizaga".inspeccion to "administrador" as "jarizaga";
grant select on "jarizaga".inspeccion to "opuerto" as "jarizaga";
grant insert on "jarizaga".inspeccion to "opuerto" as "jarizaga";
grant select on "jarizaga".inspeccion to "public" as "jarizaga";
grant update on "jarizaga".inspeccion to "public" as "jarizaga";
grant insert on "jarizaga".inspeccion to "public" as "jarizaga";
grant delete on "jarizaga".inspeccion to "public" as "jarizaga";
grant index on "jarizaga".inspeccion to "public" as "jarizaga";
grant select on "jarizaga".inspeccionpatio to "administrador" as "jarizaga";
grant update on "jarizaga".inspeccionpatio to "administrador" as "jarizaga";
grant insert on "jarizaga".inspeccionpatio to "administrador" as "jarizaga";
grant delete on "jarizaga".inspeccionpatio to "administrador" as "jarizaga";
grant index on "jarizaga".inspeccionpatio to "administrador" as "jarizaga";
grant alter on "jarizaga".inspeccionpatio to "administrador" as "jarizaga";
grant references on "jarizaga".inspeccionpatio to "administrador" as "jarizaga";
grant select on "jarizaga".inspeccionpatio to "public" as "jarizaga";
grant update on "jarizaga".inspeccionpatio to "public" as "jarizaga";
grant insert on "jarizaga".inspeccionpatio to "public" as "jarizaga";
grant delete on "jarizaga".inspeccionpatio to "public" as "jarizaga";
grant index on "jarizaga".inspeccionpatio to "public" as "jarizaga";
grant select on "jarizaga".inspeccionpuerto to "administrador" as "jarizaga";
grant update on "jarizaga".inspeccionpuerto to "administrador" as "jarizaga";
grant insert on "jarizaga".inspeccionpuerto to "administrador" as "jarizaga";
grant delete on "jarizaga".inspeccionpuerto to "administrador" as "jarizaga";
grant index on "jarizaga".inspeccionpuerto to "administrador" as "jarizaga";
grant alter on "jarizaga".inspeccionpuerto to "administrador" as "jarizaga";
grant references on "jarizaga".inspeccionpuerto to "administrador" as "jarizaga";
grant select on "jarizaga".inspeccionpuerto to "public" as "jarizaga";
grant update on "jarizaga".inspeccionpuerto to "public" as "jarizaga";
grant insert on "jarizaga".inspeccionpuerto to "public" as "jarizaga";
grant delete on "jarizaga".inspeccionpuerto to "public" as "jarizaga";
grant index on "jarizaga".inspeccionpuerto to "public" as "jarizaga";
grant select on "jarizaga".danio to "administrador" as "jarizaga";
grant update on "jarizaga".danio to "administrador" as "jarizaga";
grant insert on "jarizaga".danio to "administrador" as "jarizaga";
grant delete on "jarizaga".danio to "administrador" as "jarizaga";
grant index on "jarizaga".danio to "administrador" as "jarizaga";
grant alter on "jarizaga".danio to "administrador" as "jarizaga";
grant references on "jarizaga".danio to "administrador" as "jarizaga";
grant select on "jarizaga".danio to "public" as "jarizaga";
grant update on "jarizaga".danio to "public" as "jarizaga";
grant insert on "jarizaga".danio to "public" as "jarizaga";
grant delete on "jarizaga".danio to "public" as "jarizaga";
grant index on "jarizaga".danio to "public" as "jarizaga";
grant select on "jarizaga".patio to "administrador" as "jarizaga";
grant update on "jarizaga".patio to "administrador" as "jarizaga";
grant insert on "jarizaga".patio to "administrador" as "jarizaga";
grant delete on "jarizaga".patio to "administrador" as "jarizaga";
grant index on "jarizaga".patio to "administrador" as "jarizaga";
grant alter on "jarizaga".patio to "administrador" as "jarizaga";
grant references on "jarizaga".patio to "administrador" as "jarizaga";
grant select on "jarizaga".patio to "public" as "jarizaga";
grant update on "jarizaga".patio to "public" as "jarizaga";
grant insert on "jarizaga".patio to "public" as "jarizaga";
grant delete on "jarizaga".patio to "public" as "jarizaga";
grant index on "jarizaga".patio to "public" as "jarizaga";
grant select on "jarizaga".patioempresa to "administrador" as "jarizaga";
grant update on "jarizaga".patioempresa to "administrador" as "jarizaga";
grant insert on "jarizaga".patioempresa to "administrador" as "jarizaga";
grant delete on "jarizaga".patioempresa to "administrador" as "jarizaga";
grant index on "jarizaga".patioempresa to "administrador" as "jarizaga";
grant alter on "jarizaga".patioempresa to "administrador" as "jarizaga";
grant references on "jarizaga".patioempresa to "administrador" as "jarizaga";
grant select on "jarizaga".patioempresa to "public" as "jarizaga";
grant update on "jarizaga".patioempresa to "public" as "jarizaga";
grant insert on "jarizaga".patioempresa to "public" as "jarizaga";
grant delete on "jarizaga".patioempresa to "public" as "jarizaga";
grant index on "jarizaga".patioempresa to "public" as "jarizaga";
grant select on "jarizaga".patiopuerto to "administrador" as "jarizaga";
grant update on "jarizaga".patiopuerto to "administrador" as "jarizaga";
grant insert on "jarizaga".patiopuerto to "administrador" as "jarizaga";
grant delete on "jarizaga".patiopuerto to "administrador" as "jarizaga";
grant index on "jarizaga".patiopuerto to "administrador" as "jarizaga";
grant alter on "jarizaga".patiopuerto to "administrador" as "jarizaga";
grant references on "jarizaga".patiopuerto to "administrador" as "jarizaga";
grant select on "jarizaga".patiopuerto to "public" as "jarizaga";
grant update on "jarizaga".patiopuerto to "public" as "jarizaga";
grant insert on "jarizaga".patiopuerto to "public" as "jarizaga";
grant delete on "jarizaga".patiopuerto to "public" as "jarizaga";
grant index on "jarizaga".patiopuerto to "public" as "jarizaga";
grant select on "jarizaga".zona to "administrador" as "jarizaga";
grant update on "jarizaga".zona to "administrador" as "jarizaga";
grant insert on "jarizaga".zona to "administrador" as "jarizaga";
grant delete on "jarizaga".zona to "administrador" as "jarizaga";
grant index on "jarizaga".zona to "administrador" as "jarizaga";
grant alter on "jarizaga".zona to "administrador" as "jarizaga";
grant references on "jarizaga".zona to "administrador" as "jarizaga";
grant select on "jarizaga".zona to "opatio" as "jarizaga";
grant update on "jarizaga".zona to "opatio" as "jarizaga";
grant insert on "jarizaga".zona to "opatio" as "jarizaga";
grant select on "jarizaga".zona to "public" as "jarizaga";
grant update on "jarizaga".zona to "public" as "jarizaga";
grant insert on "jarizaga".zona to "public" as "jarizaga";
grant delete on "jarizaga".zona to "public" as "jarizaga";
grant index on "jarizaga".zona to "public" as "jarizaga";
grant select on "jarizaga".subzona to "administrador" as "jarizaga";
grant update on "jarizaga".subzona to "administrador" as "jarizaga";
grant insert on "jarizaga".subzona to "administrador" as "jarizaga";
grant delete on "jarizaga".subzona to "administrador" as "jarizaga";
grant index on "jarizaga".subzona to "administrador" as "jarizaga";
grant alter on "jarizaga".subzona to "administrador" as "jarizaga";
grant references on "jarizaga".subzona to "administrador" as "jarizaga";
grant select on "jarizaga".subzona to "public" as "jarizaga";
grant update on "jarizaga".subzona to "public" as "jarizaga";
grant insert on "jarizaga".subzona to "public" as "jarizaga";
grant delete on "jarizaga".subzona to "public" as "jarizaga";
grant index on "jarizaga".subzona to "public" as "jarizaga";
grant select on "jarizaga".viaje to "administrador" as "jarizaga";
grant update on "jarizaga".viaje to "administrador" as "jarizaga";
grant insert on "jarizaga".viaje to "administrador" as "jarizaga";
grant delete on "jarizaga".viaje to "administrador" as "jarizaga";
grant index on "jarizaga".viaje to "administrador" as "jarizaga";
grant alter on "jarizaga".viaje to "administrador" as "jarizaga";
grant references on "jarizaga".viaje to "administrador" as "jarizaga";
grant select on "jarizaga".viaje to "public" as "jarizaga";
grant update on "jarizaga".viaje to "public" as "jarizaga";
grant insert on "jarizaga".viaje to "public" as "jarizaga";
grant delete on "jarizaga".viaje to "public" as "jarizaga";
grant index on "jarizaga".viaje to "public" as "jarizaga";
grant update on "jarizaga".viaje to "transportista" as "jarizaga";
grant insert on "jarizaga".viaje to "transportista" as "jarizaga";
grant select on "jarizaga".ubicacion to "administrador" as "jarizaga";
grant update on "jarizaga".ubicacion to "administrador" as "jarizaga";
grant insert on "jarizaga".ubicacion to "administrador" as "jarizaga";
grant delete on "jarizaga".ubicacion to "administrador" as "jarizaga";
grant index on "jarizaga".ubicacion to "administrador" as "jarizaga";
grant alter on "jarizaga".ubicacion to "administrador" as "jarizaga";
grant references on "jarizaga".ubicacion to "administrador" as "jarizaga";
grant select on "jarizaga".ubicacion to "opatio" as "jarizaga";
grant update on "jarizaga".ubicacion to "opatio" as "jarizaga";
grant insert on "jarizaga".ubicacion to "opatio" as "jarizaga";
grant select on "jarizaga".ubicacion to "public" as "jarizaga";
grant update on "jarizaga".ubicacion to "public" as "jarizaga";
grant insert on "jarizaga".ubicacion to "public" as "jarizaga";
grant delete on "jarizaga".ubicacion to "public" as "jarizaga";
grant index on "jarizaga".ubicacion to "public" as "jarizaga";


revoke usage on language SPL from public ;

grant usage on language SPL to public ;




alter table "jarizaga".vehiculo add constraint (foreign key (idlote) 
    references "jarizaga".lote  on delete cascade constraint "jarizaga"
    .fk_vehiculo);
alter table "jarizaga".lotecamion add constraint (foreign key 
    (idcamion) references "jarizaga".camion  on delete cascade 
    constraint "jarizaga".fk1_lotecamion);
alter table "jarizaga".lotecamion add constraint (foreign key 
    (idlote) references "jarizaga".lote  on delete cascade constraint 
    "jarizaga".fk2_lotecamion);
alter table "jarizaga".transportista add constraint (foreign 
    key (ci) references "jarizaga".funcionario  on delete cascade 
    constraint "jarizaga".fk_transportista);
alter table "jarizaga".opuerto add constraint (foreign key (ci) 
    references "jarizaga".funcionario  on delete cascade constraint 
    "jarizaga".fk_opuerto);
alter table "jarizaga".opatio add constraint (foreign key (ci) 
    references "jarizaga".funcionario  on delete cascade constraint 
    "jarizaga".fk_opatio);
alter table "jarizaga".administrador add constraint (foreign 
    key (ci) references "jarizaga".funcionario  on delete cascade 
    constraint "jarizaga".fk_administrador);
alter table "jarizaga".inspeccion add constraint (foreign key 
    (vin) references "jarizaga".vehiculo  on delete cascade constraint 
    "jarizaga".fk_inspeccion);
alter table "jarizaga".inspeccionpatio add constraint (foreign 
    key (idinspeccion) references "jarizaga".inspeccion  on delete 
    cascade constraint "jarizaga".fk_inspeccionpatio);
alter table "jarizaga".inspeccionpuerto add constraint (foreign 
    key (idinspeccion) references "jarizaga".inspeccion  on delete 
    cascade constraint "jarizaga".fk_inspeccionpuerto);
alter table "jarizaga".danio add constraint (foreign key (idinspeccion) 
    references "jarizaga".inspeccion  on delete cascade constraint 
    "jarizaga".fk_danio);
alter table "jarizaga".patioempresa add constraint (foreign key 
    (idpatio) references "jarizaga".patio  on delete cascade constraint 
    "jarizaga".fk_patioempresa);
alter table "jarizaga".patiopuerto add constraint (foreign key 
    (idpatio) references "jarizaga".patio  on delete cascade constraint 
    "jarizaga".fk_patiopuerto);
alter table "jarizaga".zona add constraint (foreign key (idpatio) 
    references "jarizaga".patio  on delete cascade constraint 
    "jarizaga".fk_zonas);
alter table "jarizaga".subzona add constraint (foreign key (idzona) 
    references "jarizaga".zona  on delete cascade constraint "jarizaga"
    .fk_subzonas);
alter table "jarizaga".viaje add constraint (foreign key (idlote) 
    references "jarizaga".lote  on delete cascade constraint "jarizaga"
    .fk1_viaje);
alter table "jarizaga".viaje add constraint (foreign key (idpatio) 
    references "jarizaga".patio  on delete cascade constraint 
    "jarizaga".fk2_viaje);
alter table "jarizaga".viaje add constraint (foreign key (ci) 
    references "jarizaga".transportista  on delete cascade constraint 
    "jarizaga".fk3_viaje);
alter table "jarizaga".ubicacion add constraint (foreign key 
    (vin) references "jarizaga".vehiculo  on delete cascade constraint 
    "jarizaga".fk_ubicacion);


