CREATE DATABASE ARSCODEX;
GO

use ARSCODEX
go


CREATE TABLE TipoEntidad (
    IdTipoEntidad INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    NombreTipoEntidad VARCHAR(30) NOT NULL,
    Descripcion VARCHAR(150) NOT NULL,
    FechaDeRegistro DATETIME NOT NULL,
    FechaDeModificacion DATETIME NULL,
    Estado BIT NOT NULL -- 1: Activo, 0: Inactivo
);
GO

-- 2. Tabla: Entidad
CREATE TABLE Entidad (
    IdEntidad INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    CodigoEntidad VARCHAR(30) NOT NULL,
    NombreEntidad VARCHAR(100) NOT NULL,
    TelefonoEntidad VARCHAR(50) NOT NULL,
    CorreoElectronico VARCHAR(100) NOT NULL,
    Direccion VARCHAR(400) NOT NULL,
    FechaDeRegistro DATETIME NOT NULL,
    FechaDeModificacion DATETIME NOT NULL,
    IdTipoEntidad INT NOT NULL,
    Estado BIT NOT NULL, -- 1: Activo, 0: Inactivo
    CONSTRAINT FK_Entidad_TipoEntidad FOREIGN KEY (IdTipoEntidad)
        REFERENCES TipoEntidad(IdTipoEntidad)
);
GO

-- 3. Tabla: Contador
CREATE TABLE Contador (
    IdContador INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    IdContadorIdentity UNIQUEIDENTIFIER NULL,
    IdentificacionContador VARCHAR(10) NOT NULL,
    NombreContador VARCHAR(30) NOT NULL,
    PrimerApellidoContador VARCHAR(30) NOT NULL,
    SegundoApellidoContador VARCHAR(30) NOT NULL,
    NumeroDeColegio VARCHAR(20) NOT NULL,
    CorreoElectronico VARCHAR(50) NOT NULL,
    TelefonoCelular VARCHAR(10) NOT NULL,
    TelefonoSecundario VARCHAR(10) NOT NULL,
    MetodoDeContacto INT NOT NULL,
    FechaDeRegistro DATETIME NOT NULL,
    FechaDeModificacion DATETIME NULL,
    Estado BIT NOT NULL -- 1: Activo, 0: Inactivo
);
GO

-- 4. Tabla: Bitacora
CREATE TABLE Bitacora (
    IdEvento INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    TablaDeEvento VARCHAR(20) NOT NULL,
    TipoDeEvento VARCHAR(20) NOT NULL,
    FechaDeEvento DATETIME NOT NULL,
    DescripcionDeEvento VARCHAR(MAX) NOT NULL,
    StackTrace VARCHAR(MAX) NOT NULL,
    DatosAnteriores VARCHAR(MAX) NULL,
    DatosPosteriores VARCHAR(MAX) NULL
);
GO

--5. Tabla: Reserva de Liquidez
CREATE TABLE ReservaLiquidez (
	IdReservaLiquidez INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    IdEntidad INT NOT NULL,
    MotoDeReserva DECIMAL (18,2) NOT NULL,
	CantidadDeBeneficiarios INT NOT NULL,
	MontoDeSeguroBancario DECIMAL (18,2) NOT NULL,
    Periodo DATETIME NOT NULL,
	IdContador INT NOT NULL,
	FechaDeRegistro DATETIME NOT NULL,
	FechaDeModificacion DATETIME NOT NULL,
	CONSTRAINT FK_ReservaLiquidez_Entidad FOREIGN KEY (IdEntidad)
    REFERENCES Entidad(IdEntidad),
	CONSTRAINT FK_ReservaLiquidez_Contador FOREIGN KEY (IdContador)
    REFERENCES Contador(IdContador),
	Estado INT NOT NULL
);

GO

-- 6. Tabla: Regla

CREATE TABLE Regla (
    IdRegla INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    Nombre VARCHAR(30) NOT NULL,
    Descripcion VARCHAR(100) NOT NULL,
    Valor DECIMAL(18,2) NOT NULL,
    TipoDeAccion INT NOT NULL,
    FechaDeRegistro DATETIME NOT NULL,
    FechaDeModificacion DATETIME NOT NULL,
    IdTipoEntidad INT NOT NULL,
    Estado BIT NOT NULL, -- 1 = Activo, 0 = Inactivo
    CONSTRAINT FK_Regla_TipoEntidad FOREIGN KEY (IdTipoEntidad)
        REFERENCES TipoEntidad(IdTipoEntidad)
);
Go

CREATE TABLE Alerta (
    -- Clave primaria autonumérica
    IdAlerta                    INT             IDENTITY(1,1)    NOT NULL
        CONSTRAINT PK_Alerta PRIMARY KEY,

    -- Columnas obligatorias
    IdEntidad                   INT             NOT NULL,
    IdContador                  INT             NOT NULL,
    Periodo                     NVARCHAR(50)    NOT NULL,
    CantidadDeReglasIncumplidas INT             NOT NULL,
    IdReservaLiquidez           INT             NOT NULL,
    FechaDeRegistro             DATETIME2(3)    NOT NULL,
    FechaDeModificacion         DATETIME2(3)    NOT NULL,
    Estado                      BIT             NOT NULL,

    -- Claves foráneas
    CONSTRAINT FK_Alerta_Entidad 
        FOREIGN KEY (IdEntidad) 
        REFERENCES Entidad(IdEntidad),

    CONSTRAINT FK_Alerta_Contador 
        FOREIGN KEY (IdContador) 
        REFERENCES Contador(IdContador),

    CONSTRAINT FK_Alerta_ReservaLiquidez 
        FOREIGN KEY (IdReservaLiquidez) 
        REFERENCES ReservaLiquidez(IdReservaLiquidez)
);

ALTER TABLE Regla
  ALTER COLUMN FechaDeModificacion DATETIME NULL;


/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 12/11/2024 13:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 12/11/2024 13:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO


INSERT INTO TipoEntidad (NombreTipoEntidad, Descripcion, FechaDeRegistro, FechaDeModificacion, Estado)
VALUES ('Banco', 'Entidad financiera bancaria', GETDATE(), NULL, 1);
INSERT INTO Entidad (CodigoEntidad, NombreEntidad, TelefonoEntidad, CorreoElectronico, Direccion, FechaDeRegistro, FechaDeModificacion, IdTipoEntidad, Estado)
VALUES ('ENT001', 'Banco de Desarrollo', '2222-3333', 'contacto@bd.cr', 'Calle 123, San José', GETDATE(), GETDATE(), 1, 1);
INSERT INTO Contador (IdContadorIdentity, IdentificacionContador, NombreContador, PrimerApellidoContador, SegundoApellidoContador, NumeroDeColegio, CorreoElectronico, TelefonoCelular, TelefonoSecundario, MetodoDeContacto, FechaDeRegistro, FechaDeModificacion, Estado)
VALUES (NEWID(), '123456789', 'Juan', 'Pérez', 'Soto', 'COL-987', 'juan.perez@contadores.cr', '88889999', '22223333', 1, GETDATE(), GETDATE(), 1);
INSERT INTO ReservaLiquidez (IdEntidad, MotoDeReserva, CantidadDeBeneficiarios, MontoDeSeguroBancario, Periodo, IdContador, FechaDeRegistro, FechaDeModificacion, Estado)
VALUES (1, 5000000.00, 250, 3000000.00, '2024-12-31', 1, GETDATE(), GETDATE(), 1);
