CREATE TABLE [dbo].[Contadores]
(
IdContador INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    IdContadorIdentity UNIQUEIDENTIFIER NULL,
    IdentificacionContador VARCHAR(10) NOT NULL,
    NombreContador VARCHAR(30) NOT NULL,
    PrimerApellidoContador VARCHAR(30) NOT NULL,
    SegundoApellidoContador VARCHAR(30) NOT NULL,
    NumeroDeColegio VARCHAR(20) NOT NULL,
    CorreoElectronico VARCHAR(50) NOT NULL,
    TelefonoCelular VARCHAR(10) NOT NULL,
    TelefonoSecundario VARCHAR(10) NOT NULL,
    MetodoDeContacto INT NOT NULL CHECK (MetodoDeContacto IN (1, 2, 3, 4)), -- 1-Llamada, 2-Mensaje, 3-Correo, 4-WhatsApp
    FechaDeRegistro DATETIME NOT NULL,
    FechaDeModificacion DATETIME NULL,
    Estado bit NOT NULL
);