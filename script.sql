CREATE database Comunicaciones
go 
use Comunicaciones
go 
CREATE TABLE Roles(
        Id int IDENTITY(1, 1) NOT NULL,
        Nombre varchar(50) UNIQUE,
        PRIMARY KEY (Id)
    );
go
INSERT INTO Roles(Nombre)
values('Administrador'),
    ('Gestor'),
    ('Destinatario');
go 
CREATE TABLE Usuarios(
        Id int IDENTITY(1, 1) NOT NULL,
        Nombre varchar(50),
        Apellido varchar(50),
        Rol int NOT NULL,
        Email varchar(50),
        Password varchar(50),
        PRIMARY KEY (Id),
        Constraint FK_USUARIO_ROL FOREIGN KEY (Rol) REFERENCES Roles(Id)
    );
go
INSERT INTO Usuarios(Nombre, Rol, Email, Password)
values('admin', 1, 'admin@mail.co', 'a'),
    ('gestor1', 1, 'gestor1@mail.co', 'a'),
    ('destinatario1', 1, 'destinatario1@mail.co', 'a');
go
CREATE TABLE TiposCorrespondencia(
        Id int IDENTITY(1, 1) NOT NULL,
        Nombre varchar(50) Not Null,
        PRIMARY KEY (Id)
    );
go
INSERT INTO TiposCorrespondencia(Nombre)
values('Interno'),
    ('Externo');
go
CREATE TABLE Comunicaciones(
        Id bigint IDENTITY(1, 1) NOT NULL,
        Contenido varchar(MAX),
        Remitente int NOT NULL,
        Destinatario int NOT NULL,
        Consecutivo varchar(10),
        TipoCorrespondencia int NOT NULL PRIMARY KEY (Id),
        CONSTRAINT FK_COMUNICACION_REMITENTE FOREIGN KEY (Remitente) REFERENCES Usuarios(Id),
        CONSTRAINT FK_COMUNICACION_DESTINATARIO FOREIGN KEY (Destinatario) REFERENCES Usuarios(Id),
        CONSTRAINT FK_COMUNICACION_TIPOCORRESPONDENCIA FOREIGN KEY (TipoCorrespondencia) REFERENCES TiposCorrespondencia(Id)
    );
go
CREATE SEQUENCE ExternosCount AS bigint START WITH 1 INCREMENT BY 1;
go
CREATE SEQUENCE InternosCount AS bigint START WITH 1 INCREMENT BY 1;
go
CREATE PROCEDURE InsertarComunicacion 
    @Contenido varchar(max),
    @Remitente int,
    @Destinatario int,
    @TipoCorrespondencia int AS
DECLARE @Consecutivo varchar(10)
DECLARE @Categoria varchar(50)
SET @Categoria = (
        SELECT Nombre
        FROM TiposCorrespondencia
        WHERE @TipoCorrespondencia = Id
    )
IF(@Categoria = 'Externo') begin
SET @Consecutivo = 'CE' + RIGHT(
        '00000000' + CAST((next value for ExternosCount) AS varchar(8)),
        8
    )
end
Else 
begin
SET @Consecutivo = 'CI' + RIGHT(
        '00000000' + CAST((next value for InternosCount) AS varchar(8)),
        8
    )
end
insert into Comunicaciones(
        Contenido,
        Remitente,
        Destinatario,
        TipoCorrespondencia,
        Consecutivo
    )
values(
        @Contenido,
        @Remitente,
        @Destinatario,
        @TipoCorrespondencia,
        @Consecutivo
    );
go 
execute InsertarComunicacion 'interno',
    1,
    1,
    1;
execute InsertarComunicacion 'externo',
1,
1,
2;
go
select *
from Comunicaciones
select Nombre
from TiposCorrespondencia

USE master;
GO
ALTER DATABASE Comunicaciones 
SET SINGLE_USER 
WITH ROLLBACK IMMEDIATE;
GO
DROP DATABASE Comunicaciones;