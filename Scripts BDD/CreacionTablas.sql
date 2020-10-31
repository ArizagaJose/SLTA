/*creacion tabla lote*/
create table lote
(
	idlote serial,
	capacidad integer not null,
	estado varchar(10) not null check(estado="Armado" or estado="En viaje" or estado="Arribado"),
	baja boolean not null default 'f', 
	Primary Key (idlote) constraint pk_lote
);

/*creacion tabla camion*/
create table camion
(
	idcamion serial,
	capacidad integer not null,
	matricula varchar(10) not null,
	correo varchar(50) not null,
	contrasenia varchar(50) not null,
	telefono varchar(50) not null,
	baja boolean not null default 'f',
	Primary Key (idcamion) constraint pk_camion
);

/*creacion tabla vehiculo*/
create table vehiculo
(
	vin varchar(17) not null check(length(vin)=17),
	idvehiculo serial,
	marca varchar(20) not null,
	modelo varchar(20) not null,
	anio datetime year to year not null,
	color varchar(10) not null,
	pais varchar(25) not null,
	tipo varchar(15) not null check(tipo="Auto" or tipo="Camioneta" or tipo="SUV"),
	baja boolean not null default 'f',
	idlote integer,
	Primary Key (vin) constraint pk_vehiculo,
	Foreign Key (idlote) references lote constraint fk_vehiculo on delete cascade,
	Unique (idvehiculo) constraint uq_vehiculo
);

/*creacion tabla lotecamion*/
create table lotecamion
(
	idcamion integer not null,
	idlote integer not null,
	baja boolean not null default 'f',
	Primary Key (idlote) constraint pk_lotecamion,
	Foreign Key (idcamion) references camion constraint fk1_lotecamion on delete cascade,
	Foreign Key (idlote) references lote constraint fk2_lotecamion on delete cascade
);

/*creacion tabla funcionario*/
create table funcionario
(
	ci integer not null,
	nrofuncionario integer not null,
	nombre varchar(20) not null,
	apellido varchar(20) not null,
	user varchar(20) not null,	
	telefono integer not null,
	baja boolean not null default 'f',
	Primary Key (ci) constraint pk_funcionario,
	Unique (nrofuncionario) constraint uq_funcionario
);

/*creacion tabla transportista*/
create table transportista
(
	ci integer not null,
	baja boolean not null default 'f',
	Primary Key (ci) constraint pk_transportista,
	Foreign Key (ci) references funcionario constraint fk_transportista on delete cascade
);

/*creacion tabla operario puerto*/
create table opuerto
(
	ci integer not null,
	baja boolean not null default 'f',
	Primary Key (ci) constraint pk_opuerto,
	Foreign Key (ci) references funcionario constraint fk_opuerto on delete cascade
);

/*creacion tabla operario patio*/
create table opatio
(
	ci integer not null,
	baja boolean not null default 'f',
	Primary Key (ci) constraint pk_opatio,
	Foreign Key (ci) references funcionario constraint fk_opatio on delete cascade
);

/*creacion table administrador*/
create table administrador
(
	ci integer not null,
	baja boolean not null default 'f',
	Primary Key (ci) constraint pk_administrador,
	Foreign Key (ci) references funcionario constraint fk_administrador on delete cascade
);

/*creacion table inspeccion*/
create table inspeccion
(
	idinspeccion smallint,
	fecha datetime year to minute not null,
	vin varchar(17) not null,
	baja boolean not null default 'f',
	Primary Key (idinspeccion) constraint pk_inspeccion,
	Foreign Key (vin) references vehiculo constraint fk_inspeccion on delete cascade
);

/*creacion tabla inspeccion patio*/
create table inspeccionpatio
(
	idinspeccion smallint not null,
	ci integer not null,
	baja boolean not null default 'f',
	Primary Key(idinspeccion) constraint pk_inspeccionpatio,
	Foreign Key(idinspeccion) references inspeccion constraint fk_inspeccionpatio on delete cascade
);

/*creacion tabla inspeccion puerto*/
create table inspeccionpuerto
(
	idinspeccion smallint not null,
	ci integer not null,
	baja boolean not null default 'f',
	Primary Key(idinspeccion) constraint pk_inspeccionpuerto,
	Foreign Key(idinspeccion) references inspeccion constraint fk_inspeccionpuerto on delete cascade
); 

/*creacion tabla danio*/
create table danio
(
	iddanio serial,
	descripcion varchar(100) not null,
	imagen varchar(100),
	baja boolean not null default 'f',
	idinspeccion smallint not null,
	Primary Key (iddanio) constraint pk_danio,
	Foreign Key (idinspeccion) references inspeccion constraint fk_danio on delete cascade
);

/*creacion tabla patio*/
create table patio
(
	idpatio serial,
	nombre varchar(20) not null,
	tipo varchar(10) not null check(tipo="nacional" or tipo="fiscal"),
	capacidad smallint not null,
	baja boolean not null default 'f',
	Primary Key (idpatio) constraint pk_patio
);

/*creacion tabla patio empresa*/
create table patioempresa
(
	idpatio integer not null,
	baja boolean not null default 'f',
	Primary Key (idpatio) constraint pk_patioempresa,
	Foreign Key (idpatio) references patio constraint fk_patioempresa on delete cascade
);

/*creacion tabla patio puerto*/
create table patiopuerto
(
	idpatio integer not null,
	baja boolean not null default 'f',
	Primary Key (idpatio) constraint pk_patiopuerto,
	Foreign Key (idpatio) references patio constraint fk_patiopuerto on delete cascade
);

/*creacion tabla zona*/
create table zona
(
	idzona smallint,
	capacidad smallint not null,
	nombre varchar(50) not null,
	idpatio Integer not null,
	estibas smallint not null,
	filas smallint not null,
	baja boolean not null default 'f',
	Primary Key (idzona) constraint pk_zonas,
	Foreign Key (idpatio) references patio constraint fk_zonas on delete cascade
);

/*creacion tabla subzona*/
create table subzona
(
	idsubzona smallint,
	idzona smallint not null,
	capacidad smallint not null,
	nombre varchar(50) not null,
	estibas smallint not null,
	filas smallint not null,
	baja boolean not null default 'f',
	Primary Key (idsubzona, idzona) constraint pk_subzonas,
	Foreign Key (idzona) references zona constraint fk_subzonas on delete cascade
);

/*creacion tabla viaje*/
create table viaje
(
	idlote integer not null,
	idpatio integer not null,
	fechainicio datetime year to minute not null,
	fechaestimada datetime year to minute,
	fechafinal datetime year to minute,
	ci integer not null,
	baja boolean not null default 'f',
	Primary Key(idlote, idpatio, fechainicio) constraint pk_viaje,
	Foreign Key(idlote) references lote constraint fk1_viaje on delete cascade,
	Foreign Key(idpatio) references patio constraint fk2_viaje on delete cascade,
	Foreign Key(ci) references transportista constraint fk3_viaje on delete cascade
);

/*creacion tabla ubicacion*/
create table ubicacion
(
	vin varchar(17) not null check(length(vin)=17),
    estibas smallint not null,
    filas smallint not null,
	baja boolean not null default 'f',
    Primary Key (vin) constraint pk_ubicacion,
    Foreign Key (vin) references vehiculo constraint fk_ubicacion on delete cascade
);