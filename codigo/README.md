# Mantenimiento de productos — solución C# (Onion + SQL Server)

Alineado al curso en vídeo del repositorio padre: sistema de **ventas / mantenimiento** con **Categoría**, **Marca** y **Producto**.

## Estructura (cebolla / Onion)

Las dependencias apuntan **hacia dentro** (el dominio no conoce infraestructura ni UI).

```
Presentacion (WinForms)
    -> Aplicacion, Infraestructura, Dominio
Aplicacion (casos de uso, DTOs, servicios)
    -> Dominio
Infraestructura (ADO.NET + procedimientos almacenados)
    -> Dominio
Dominio (entidades, contratos de repositorio)
    -> (sin referencias a otros proyectos)
```

| Proyecto | Rol |
|----------|-----|
| `MantenimientoProductos.Dominio` | Entidades y `ICategoriaRepositorio`. |
| `MantenimientoProductos.Aplicacion` | `ICategoriaServicio`, `CategoriaServicio`, `CategoriaDto`. |
| `MantenimientoProductos.Infraestructura` | `CategoriaRepositorio` ejecutando `usp_Categoria_*`. |
| `MantenimientoProductos.Presentacion` | WinForms, composición raíz (`Program.cs`), formularios. |

## Base de datos

1. Ejecutar `database/01_Tablas.sql` (crea la base `VentasMantenimiento` si no existe, tablas e índices mínimos).
2. Ejecutar `database/02_usp_Categoria_CRUD.sql`.

## Ejecutar la aplicación

1. Ajustar `MantenimientoProductos.Presentacion/appsettings.json` → `ConnectionStrings:DefaultConnection`.
2. Desde esta carpeta:

```powershell
dotnet run --project MantenimientoProductos.Presentacion
```

## División de trabajo en equipo

Ver `../docs/DIVISION-8-DESARROLLADORES.md` (reparto de las **20** partes del curso entre **8** desarrolladores).

Ver `../docs/GUIA-DETALLADA-POR-LECCION.md` para **objetivos, tareas y entregables por lección** según el texto de los subtítulos (útil para implementar Marca, Producto, Excel, etc.).
