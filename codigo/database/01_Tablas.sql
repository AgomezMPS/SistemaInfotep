/*
  Esquema base alineado al curso: Categoría, Marca, Producto (SQL Server).
  Ejecutar en una base nueva o ajustar USE.
*/
SET NOCOUNT ON;
GO

IF DB_ID(N'VentasMantenimiento') IS NULL
BEGIN
    CREATE DATABASE VentasMantenimiento;
END
GO

USE VentasMantenimiento;
GO

IF OBJECT_ID(N'dbo.Producto', N'U') IS NOT NULL DROP TABLE dbo.Producto;
IF OBJECT_ID(N'dbo.Marca', N'U') IS NOT NULL DROP TABLE dbo.Marca;
IF OBJECT_ID(N'dbo.Categoria', N'U') IS NOT NULL DROP TABLE dbo.Categoria;
GO

CREATE TABLE dbo.Categoria
(
    IdCategoria    INT IDENTITY(1, 1) NOT NULL CONSTRAINT PK_Categoria PRIMARY KEY,
    Nombre         NVARCHAR(120)      NOT NULL,
    Estado         BIT                NOT NULL CONSTRAINT DF_Categoria_Estado DEFAULT (1),
    FechaRegistro DATETIME2          NOT NULL CONSTRAINT DF_Categoria_Fecha DEFAULT (SYSUTCDATETIME())
);
GO

CREATE TABLE dbo.Marca
(
    IdMarca       INT IDENTITY(1, 1) NOT NULL CONSTRAINT PK_Marca PRIMARY KEY,
    Nombre        NVARCHAR(120)      NOT NULL,
    Estado        BIT                NOT NULL CONSTRAINT DF_Marca_Estado DEFAULT (1),
    FechaRegistro DATETIME2          NOT NULL CONSTRAINT DF_Marca_Fecha DEFAULT (SYSUTCDATETIME())
);
GO

CREATE TABLE dbo.Producto
(
    IdProducto    INT IDENTITY(1, 1) NOT NULL CONSTRAINT PK_Producto PRIMARY KEY,
    IdCategoria   INT                NOT NULL,
    IdMarca       INT                NOT NULL,
    Nombre        NVARCHAR(200)      NOT NULL,
    Precio        DECIMAL(12, 2)     NOT NULL CONSTRAINT DF_Producto_Precio DEFAULT (0),
    Stock         INT                NOT NULL CONSTRAINT DF_Producto_Stock DEFAULT (0),
    Estado        BIT                NOT NULL CONSTRAINT DF_Producto_Estado DEFAULT (1),
    FechaRegistro DATETIME2          NOT NULL CONSTRAINT DF_Producto_Fecha DEFAULT (SYSUTCDATETIME()),
    CONSTRAINT FK_Producto_Categoria FOREIGN KEY (IdCategoria) REFERENCES dbo.Categoria (IdCategoria),
    CONSTRAINT FK_Producto_Marca FOREIGN KEY (IdMarca) REFERENCES dbo.Marca (IdMarca)
);
GO

CREATE INDEX IX_Producto_Categoria ON dbo.Producto (IdCategoria);
CREATE INDEX IX_Producto_Marca ON dbo.Producto (IdMarca);
GO

INSERT INTO dbo.Categoria (Nombre, Estado) VALUES (N'General', 1), (N'Bebidas', 1);
INSERT INTO dbo.Marca (Nombre, Estado) VALUES (N'Sin marca', 1);
GO
