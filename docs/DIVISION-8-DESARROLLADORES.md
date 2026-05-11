# División del curso (20 partes) entre 8 desarrolladores

Para el detalle pedagógico y técnico de **cada lección** (según subtítulos), ver **`GUIA-DETALLADA-POR-LECCION.md`** en esta misma carpeta `docs/`.

Este documento reparte las **20 lecciones en vídeo** del material original en **8 frentes** paralelos, alineados con el repositorio de código en `codigo/` y los scripts SQL en `codigo/database/`.

| Frente | Desarrollador sugerido | Partes del curso (vídeo) | Entregables principales |
|--------|-------------------------|---------------------------|-------------------------|
| **1** | Dev 1 — Fundamentos | **1–3** | Alcance funcional, glosario de dominio, revisión del esquema `01_Tablas.sql` (Categoría, Marca, Producto), datos semilla y convenciones de nombres. |
| **2** | Dev 2 — SQL y arranque | **4–5** | Procedimientos almacenados (CRUD Categoría y futuros), cadena de conexión, documentación de despliegue de BD, validación de scripts en SQL Server. |
| **3** | Dev 3 — Slice vertical Categoría | **6–9** | Completar/refinar **Dominio**, **Aplicación**, **Infraestructura** y **Presentación** para Categoría (ya iniciado en Onion), pruebas manuales del formulario. |
| **4** | Dev 4 — CRUD Categoría + Marcas | **10–11** | `ICategoriaServicio` estabilizado, repositorio y UI de **Marca** (mismo patrón Onion), manejo de errores y mensajes de usuario. |
| **5** | Dev 5 — Formularios transversales | **12–14** | Validaciones reutilizables, formulario de información, **shell** del formulario principal (menús / navegación a módulos). |
| **6** | Dev 6 — Productos consulta | **15** | Modelos de lectura con **INNER JOIN**, consultas/listados de producto, mapeo DTO sin lógica de negocio en UI. |
| **7** | Dev 7 — Panel productos (UI) | **16–17** | Grillas, filtros, estados de carga; integración con servicios de aplicación ya expuestos por Dev 6/8. |
| **8** | Dev 8 — Productos persistencia y cierre | **18–20** | SP y CRUD de producto, transacciones si aplica, **exportación a Excel** y pantalla de totales/resumen. |

## Dependencias entre frentes

- **2** depende de **1** (esquema estable).
- **3** depende de **2** (SP y conexión listos).
- **4** depende de **3** (patrón Categoría cerrado).
- **6** depende de **1** y conviene coordinación con **4** (Marca/Categoría usadas por Producto).
- **7** depende de **6** (contratos de listado).
- **8** depende de **6–7** (contratos de UI y lectura).

Los frentes **1** y **5** pueden avanzar en paralelo temprano (documentación / formularios genéricos).

## Estado actual del repositorio `codigo/`

- Solución **Onion** con **CRUD de Categoría** implementado (WinForms + procedimientos almacenados SQL Server).
- Scripts: `database/01_Tablas.sql`, `database/02_usp_Categoria_CRUD.sql`.
- Los demás módulos (Marca, Producto, Excel) quedan asignados a los frentes **4–8** según la tabla.
