namespace MantenimientoProductos.Dominio.Entidades;

public sealed class Categoria
{
    public int IdCategoria { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public bool Estado { get; set; }
    public DateTime FechaRegistro { get; set; }
}
