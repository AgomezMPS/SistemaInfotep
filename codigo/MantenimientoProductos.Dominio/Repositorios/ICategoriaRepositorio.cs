using MantenimientoProductos.Dominio.Entidades;

namespace MantenimientoProductos.Dominio.Repositorios;

public interface ICategoriaRepositorio
{
    Task<IReadOnlyList<Categoria>> ListarAsync(CancellationToken cancellationToken = default);
    Task<Categoria?> ObtenerPorIdAsync(int idCategoria, CancellationToken cancellationToken = default);
    Task<int> InsertarAsync(Categoria entidad, CancellationToken cancellationToken = default);
    Task<int> ActualizarAsync(Categoria entidad, CancellationToken cancellationToken = default);
    Task<int> EliminarAsync(int idCategoria, CancellationToken cancellationToken = default);
}
