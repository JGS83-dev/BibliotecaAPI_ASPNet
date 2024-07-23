--Creacion de la base de datos
CREATE DATABASE Biblioteca

--Usamos la base de datos
use Biblioteca

--Creacion de las tablas
--Tabla Editoriales
create table Editoriales(
Id bigint identity(1,1) primary key not null,
Nombre varchar(255) not null
);
go

--Tabla Autores
create table Autores(
Id bigint identity(1,1) primary key not null,
Nombre varchar(255) not null,
Apellido varchar(255) not null
);

--Tabla Usuarios
create table Usuarios(
Id bigint identity(1,1) primary key not null,
Nombre varchar(255) not null,
Apellido varchar(255) not null
);

--Tabla Libros
create table Libros(
Id bigint identity(1,1) primary key not null,
Nombre varchar(255) not null,
CodigoAutor bigint foreign key references Autores(Id),
CodigoEditorial bigint foreign key references Editoriales(Id),
FechaDeLanzamiento datetime2 not null default getdate()
);

--Tabla Prestamos
create table Prestamos(
Id bigint identity(1,1) primary key not null,
CodigoLibro bigint foreign key references Libros(Id),
CodigoUsuario bigint foreign key references Usuarios(Id),
FechaDePrestamo datetime2 not null default getdate()
);
