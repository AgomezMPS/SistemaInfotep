using MantenimientoProductos.Aplicacion.Contratos;
using MantenimientoProductos.Aplicacion.Dtos;
using MantenimientoProductos.Dominio.Entidades;
using MantenimientoProductos.Dominio.Repositorios;

namespace MantenimientoProductos.Aplicacion.Servicios;

public sealed class CategoriaServicio : ICategoriaServicio
{
    private readonly ICategoriaRepositorio _repositorio;

    public CategoriaServicio(ICategoriaRepositorio repositorio) => _repositorio = repositorio;

    public async Task<IReadOnlyList<CategoriaDto>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var lista = await _repositorio.ListarAsync(cancellationToken).ConfigureAwait(false);
        return lista.Select(Mapear).ToList();
    }

    public async Task<CategoriaDto?> ObtenerAsync(int idCategoria, CancellationToken cancellationToken = default)
    {
        var entidad = await _repositorio.ObtenerPorIdAsync(idCategoria, cancellationToken).ConfigureAwait(false);
        return entidad is null ? null : Mapear(entidad);
    }

    public Task<int> CrearAsync(string nombre, bool estado, CancellationToken cancellationToken = default)
    {
        var entidad = new Categoria { Nombre = nombre.Trim(), Estado = estado };
        return _repositorio.InsertarAsync(entidad, cancellationToken);
    }

    public async Task<bool> ActualizarAsync(int idCategoria, string nombre, bool estado, CancellationToken cancellationToken = default)
    {
        var entidad = await _repositorio.ObtenerPorIdAsync(idCategoria, cancellationToken).ConfigureAwait(false);
        if (entidad is null) return false;
        entidad.Nombre = nombre.Trim();
        entidad.Estado = estado;
        var filas = await _repositorio.ActualizarAsync(entidad, cancellationToken).ConfigureAwait(false);
        return filas > 0;
    }

    public async Task<bool> EliminarAsync(int idCategoria, CancellationToken cancellationToken = default)
    {
        var filas = await _repositorio.EliminarAsync(idCategoria, cancellationToken).ConfigureAwait(false);
        return filas > 0;
    }

    private static CategoriaDto Mapear(Categoria c) =>
        new(c.IdCategoria, c.Nombre, c.Estado, c.FechaRegistro);
}
