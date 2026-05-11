USE VentasMantenimiento;
GO

IF OBJECT_ID(N'dbo.usp_Categoria_Listar', N'P') IS NOT NULL DROP PROCEDURE dbo.usp_Categoria_Listar;
IF OBJECT_ID(N'dbo.usp_Categoria_ObtenerPorId', N'P') IS NOT NULL DROP PROCEDURE dbo.usp_Categoria_ObtenerPorId;
IF OBJECT_ID(N'dbo.usp_Categoria_Insertar', N'P') IS NOT NULL DROP PROCEDURE dbo.usp_Categoria_Insertar;
IF OBJECT_ID(N'dbo.usp_Categoria_Actualizar', N'P') IS NOT NULL DROP PROCEDURE dbo.usp_Categoria_Actualizar;
IF OBJECT_ID(N'dbo.usp_Categoria_Eliminar', N'P') IS NOT NULL DROP PROCEDURE dbo.usp_Categoria_Eliminar;
GO

CREATE PROCEDURE dbo.usp_Categoria_Listar
AS
    SELECT IdCategoria, Nombre, Estado, FechaRegistro
    FROM dbo.Categoria
    ORDER BY IdCategoria;
GO

CREATE PROCEDURE dbo.usp_Categoria_ObtenerPorId
    @IdCategoria INT
AS
    SELECT IdCategoria, Nombre, Estado, FechaRegistro
    FROM dbo.Categoria
    WHERE IdCategoria = @IdCategoria;
GO

CREATE PROCEDURE dbo.usp_Categoria_Insertar
    @Nombre NVARCHAR(120),
    @Estado BIT,
    @IdCategoria INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.Categoria (Nombre, Estado)
    VALUES (@Nombre, @Estado);
    SET @IdCategoria = CAST(SCOPE_IDENTITY() AS INT);
END
GO

CREATE PROCEDURE dbo.usp_Categoria_Actualizar
    @IdCategoria INT,
    @Nombre NVARCHAR(120),
    @Estado BIT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.Categoria
    SET Nombre = @Nombre,
        Estado = @Estado
    WHERE IdCategoria = @IdCategoria;
END
GO

CREATE PROCEDURE dbo.usp_Categoria_Eliminar
    @IdCategoria INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM dbo.Categoria WHERE IdCategoria = @IdCategoria;
END
GO
