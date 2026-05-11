using MantenimientoProductos.Aplicacion.Contratos;
using MantenimientoProductos.Aplicacion.Servicios;
using MantenimientoProductos.Dominio.Repositorios;
using MantenimientoProductos.Infraestructura.Persistencia;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MantenimientoProductos.Presentacion;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        HostApplicationBuilder builder = Host.CreateApplicationBuilder();
        builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        string? cs = builder.Configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrWhiteSpace(cs))
            throw new InvalidOperationException("Falta ConnectionStrings:DefaultConnection en appsettings.json.");

        builder.Services.AddScoped<ICategoriaRepositorio>(_ => new CategoriaRepositorio(cs));
        builder.Services.AddScoped<ICategoriaServicio, CategoriaServicio>();
        builder.Services.AddTransient<FormCategorias>();

        using IHost host = builder.Build();

        using IServiceScope scope = host.Services.CreateScope();
        FormCategorias formulario = scope.ServiceProvider.GetRequiredService<FormCategorias>();
        Application.Run(formulario);
    }
}
