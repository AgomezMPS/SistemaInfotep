using System.Data;
using MantenimientoProductos.Dominio.Entidades;
using MantenimientoProductos.Dominio.Repositorios;
using Microsoft.Data.SqlClient;

namespace MantenimientoProductos.Infraestructura.Persistencia;

public sealed class CategoriaRepositorio : ICategoriaRepositorio
{
    private readonly string _cadenaConexion;

    public CategoriaRepositorio(string cadenaConexion) =>
        _cadenaConexion = cadenaConexion ?? throw new ArgumentNullException(nameof(cadenaConexion));

    public async Task<IReadOnlyList<Categoria>> ListarAsync(CancellationToken cancellationToken = default)
    {
        await using var cn = new SqlConnection(_cadenaConexion);
        await cn.OpenAsync(cancellationToken).ConfigureAwait(false);
        await using var cmd = new SqlCommand("dbo.usp_Categoria_Listar", cn) { CommandType = CommandType.StoredProcedure };
        await using var rd = await cmd.ExecuteReaderAsync(cancellationToken).ConfigureAwait(false);
        var lista = new List<Categoria>();
        while (await rd.ReadAsync(cancellationToken).ConfigureAwait(false))
            lista.Add(LeerEntidad(rd));
        return lista;
    }

    public async Task<Categoria?> ObtenerPorIdAsync(int idCategoria, CancellationToken cancellationToken = default)
    {
        await using var cn = new SqlConnection(_cadenaConexion);
        await cn.OpenAsync(cancellationToken).ConfigureAwait(false);
        await using var cmd = new SqlCommand("dbo.usp_Categoria_ObtenerPorId", cn) { CommandType = CommandType.StoredProcedure };
        cmd.Parameters.Add("@IdCategoria", SqlDbType.Int).Value = idCategoria;
        await using var rd = await cmd.ExecuteReaderAsync(cancellationToken).ConfigureAwait(false);
        if (!await rd.ReadAsync(cancellationToken).ConfigureAwait(false)) return null;
        return LeerEntidad(rd);
    }

    public async Task<int> InsertarAsync(Categoria entidad, CancellationToken cancellationToken = default)
    {
        await using var cn = new SqlConnection(_cadenaConexion);
        await cn.OpenAsync(cancellationToken).ConfigureAwait(false);
        await using var cmd = new SqlCommand("dbo.usp_Categoria_Insertar", cn) { CommandType = CommandType.StoredProcedure };
        cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 120).Value = entidad.Nombre;
        cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = entidad.Estado;
        var pId = new SqlParameter("@IdCategoria", SqlDbType.Int) { Direction = ParameterDirection.Output };
        cmd.Parameters.Add(pId);
        await cmd.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
        return (int)pId.Value!;
    }

    public async Task<int> ActualizarAsync(Categoria entidad, CancellationToken cancellationToken = default)
    {
        await using var cn = new SqlConnection(_cadenaConexion);
        await cn.OpenAsync(cancellationToken).ConfigureAwait(false);
        await using var cmd = new SqlCommand("dbo.usp_Categoria_Actualizar", cn) { CommandType = CommandType.StoredProcedure };
        cmd.Parameters.Add("@IdCategoria", SqlDbType.Int).Value = entidad.IdCategoria;
        cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 120).Value = entidad.Nombre;
        cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = entidad.Estado;
        return await cmd.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
    }

    public async Task<int> EliminarAsync(int idCategoria, CancellationToken cancellationToken = default)
    {
        await using var cn = new SqlConnection(_cadenaConexion);
        await cn.OpenAsync(cancellationToken).ConfigureAwait(false);
        await using var cmd = new SqlCommand("dbo.usp_Categoria_Eliminar", cn) { CommandType = CommandType.StoredProcedure };
        cmd.Parameters.Add("@IdCategoria", SqlDbType.Int).Value = idCategoria;
        return await cmd.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
    }

    private static Categoria LeerEntidad(SqlDataReader rd) => new()
    {
        IdCategoria = rd.GetInt32(0),
        Nombre = rd.GetString(1),
        Estado = rd.GetBoolean(2),
        FechaRegistro = rd.GetDateTime(3)
    };
}
