using MantenimientoProductos.Aplicacion.Dtos;

namespace MantenimientoProductos.Aplicacion.Contratos;

public interface ICategoriaServicio
{
    Task<IReadOnlyList<CategoriaDto>> ListarAsync(CancellationToken cancellationToken = default);
    Task<CategoriaDto?> ObtenerAsync(int idCategoria, CancellationToken cancellationToken = default);
    Task<int> CrearAsync(string nombre, bool estado, CancellationToken cancellationToken = default);
    Task<bool> ActualizarAsync(int idCategoria, string nombre, bool estado, CancellationToken cancellationToken = default);
    Task<bool> EliminarAsync(int idCategoria, CancellationToken cancellationToken = default);
}
