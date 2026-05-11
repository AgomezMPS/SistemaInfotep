namespace MantenimientoProductos.Aplicacion.Dtos;

public sealed record CategoriaDto(int IdCategoria, string Nombre, bool Estado, DateTime FechaRegistro);
