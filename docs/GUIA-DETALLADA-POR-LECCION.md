# Guía detallada por lección (según subtítulos del curso)

Documento orientado a **desarrolladores**: resume **qué se hace en cada parte** del curso según el texto de los archivos `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles1.srt` … `subtitles20.srt`. Los nombres de vídeo del proyecto pueden no coincidir al 100 % con el audio (p. ej. lección 12); aquí prima el **contenido hablado**.

**Stack del curso:** C# (WinForms), SQL Server, arquitectura en **capas** (entidades, datos, negocio, presentación), procedimientos almacenados, **Bunifu** / Uniform UI, iconos (**Icons8**), colores (**Just Color Picker**), recursos gráficos con **PowerPoint**, exportación a **Excel** (interop).

---

## Parte 1 — Introducción del curso

**Objetivo:** Presentar el sistema de ejemplo (ferretería / ventas) y los requisitos.

**Qué se hace (acciones concretas):**

- Se muestra un **dashboard** de productos con totales dinámicos (productos, categorías, marcas, mayor stock).
- Se anuncia el alcance: **mantenimiento de productos**, categorías y marcas; **base de datos desde cero**; uso de **INNER JOIN** entre productos, categorías y marcas; **procedimientos almacenados** para consultas y mantenimiento.
- **Patrón en capas** + POO (abstracción, encapsulamiento, herencia, polimorfismo); distintas formas de **guardar, eliminar, editar, listar y buscar**.
- UI: estilo tipo web, **Bunifu** (en el curso principalmente botones; el resto es diseño manual).
- **Requisitos:** bases de C# y POO, **Visual Studio**, **SQL Server**, **Just Color Picker**, **Icons8**, **PowerPoint** (para mockups/recortes de UI), **Bunifu** (enlace en descripción del vídeo).

**Entregables / checklist Dev:** entorno instalado; lista de herramientas de diseño; comprensión del dominio (producto ↔ categoría ↔ marca).

---

## Parte 2 — Patrones de arquitectura (introducción teórica)

**Objetivo:** Justificar **arquitectura en capas** y el rol de cada capa.

**Qué se hace:**

- Define **patrón de arquitectura** como solución recurrente a problemas de estructura; menciona varios patrones comunes y el **MVC** (en el audio aparece como “MBC”).
- **Tres capas clásicas:** Datos (conexiones, consultas, SP; SQL Server/MySQL/PostgreSQL), Negocio (reglas, abstracción, intermediario), Presentación (WinForms/WebForms/web).
- Flujo: usuario en **vista** → **negocio** → **datos** → BD y vuelta.
- **Cuatro capas:** se suma **capa Entidades** (atributos, getters/setters, seguridad de datos) comunicada con todas; ventajas (flexibilidad, reutilización); límites (evolución hasta cierto punto, poca lógica de negocio en el patrón descrito).
- Cita a **Martin Fowler:** no hay una sola arquitectura correcta; importa coherencia y POO.

**Para implementación:** decidir si el equipo replica **N capas clásicas** del curso u **Onion/Clean** (como en `codigo/`); mapear Entidades=Dominio, etc., y documentar la decisión en el README del repo.

---

## Parte 3 — Base de datos: crear BD y tabla `Categoria`

**Objetivo:** Crear la base y la primera tabla con **código autogenerado** distinto del `IDENTITY`.

**Qué se hace en SQL Server:**

- Conectar al servidor; **CREATE DATABASE** (ej. `mantenimiento.Productos` en el audio); **USE** la BD.
- Tabla **Categoría** con columnas: **IdCategoria** (`INT IDENTITY`, PK), **código** (generado con prefijo tipo **“CT”** + `CONVERT` sobre ceros + referencia a `IdCategoria` para autoincremento “visible” comercial), **nombre** (`NVARCHAR`, obligatorio), **descripción** (opcional, `NULL`).
- **INSERT** de filas de ejemplo (solo nombre/descripcion obligatorios donde aplica); **SELECT *** para verificar Id y código autogenerados.
- Se explica que en UI solo se mostrará el **código**, no el Id (oculto en grillas).

**Nota de migración:** el proyecto de ejemplo en `codigo/` usa otro esquema simplificado (`Estado`, `FechaRegistro`). Si alineas 100 % al vídeo, adapta scripts y entidades a **código + descripción**.

---

## Parte 4 — Procedimientos almacenados para `Categoria`

**Objetivo:** SP para **buscar, insertar, editar, eliminar** categorías.

**Qué se hace:**

- Motiva SP: menos tráfico, reutilización, rendimiento, validación previa; prefijo **“SCP”** (convención del instructor) en nombres.
- **Buscar:** parámetro de búsqueda; lista/filtra por nombre (patrón tipo `LIKE` con comodín al inicio según el audio).
- **Insertar:** parámetros **nombre**, **descripción** (Id y código autogenerados en tabla).
- **Editar:** parámetros **IdCategoria**, nombre, descripción; `UPDATE` por PK.
- **Eliminar:** parámetro **IdCategoria**; `DELETE` por PK.
- Ejecutar scripts y verificar en **Programación → Procedimientos almacenados**.

**Dev:** definir nombres finales de SP (`usp_*` vs `SCP_*`) y convención única en el equipo; pruebas en SSMS antes de conectar capa Datos.

---

## Parte 5 — Solución en capas y cadena de conexión

**Objetivo:** Crear la solución Visual Studio y **App.config** con **connectionStrings**.

**Qué se hace:**

- Nueva **solución en blanco**; proyectos: **Capa Datos** (biblioteca de clases), **Capa Negocio**, **Capa Entidades**, **Presentación** (WinForms).
- **Referencias:** Datos → Entidades; Negocio → Datos + Entidades; Presentación → Negocio + Entidades (Entidades no referencia a nadie).
- Eliminar clases/formulario por defecto.
- **App.config:** `<connectionStrings><add name="..." connectionString="Server=...;Integrated Security=...;Database=..."/>` (ajustar servidor y BD exactos).
- En **Capa Datos**, clase por entidad (ej. categoría): `using System.Data.SqlClient`, `using System.Configuration`; instancia **`SqlConnection`** con `ConfigurationManager.ConnectionStrings["..."].ConnectionString`.

**Dev:** externalizar secretos en producción; equivalente en .NET moderno: `appsettings.json` + `IConfiguration` (como en `codigo/MantenimientoProductos.Presentacion`).

---

## Parte 6 — Capa Entidades: clase `E_Categoria`

**Objetivo:** Modelar columnas como propiedades y **encapsular**.

**Qué se hace:**

- Clase pública con campos/atributos: **IdCategoria**, **código**, **nombre**, **descripción** (tipos acordes a BD).
- **Refactor → Encapsular campo** (propiedades públicas con get/set).

**Dev:** mantener nombres 1:1 con columnas/SP para evitar errores en mapeo.

---

## Parte 7 — Capa Datos: métodos contra SP (`SqlCommand`, `SqlDataReader`)

**Objetivo:** Llamar a los SP de categoría y devolver colecciones / ejecutar comandos.

**Qué se hace:**

- Referencias: **Entidades**, **System.Data**, **SqlClient**, **Configuration**.
- **Listar/Buscar:** método que recibe `string buscar`; `SqlCommand` con nombre del SP, `CommandType.StoredProcedure`, abrir conexión, **parámetros** alineados al SP, `ExecuteReader`, bucle `while (reader.Read())`, llenar **`List<E_Categoria>`** con índices de columnas (0 = primera columna, etc.), cerrar reader y conexión.
- **Insertar / Editar:** parámetros según SP; **`ExecuteNonQuery`**; cerrar conexión.
- **Eliminar:** parámetro Id; `ExecuteNonQuery`.
- Menciona alternativa **DataTable** (menos rendimiento con muchos registros, según el audio).

**Dev:** patrón repetible para Marca y Producto; considerar Dapper o repositorios (como en Onion del repo `codigo/`).

---

## Parte 8 — Capa Negocio: clase `N_Categoria`

**Objetivo:** Delegación simple hacia Capa Datos.

**Qué se hace:**

- Clase `N_Categoria` con referencias a **Entidades** y **Datos**.
- Instancia del objeto de la clase de **Datos** (ej. `objetoDatos`).
- Métodos **`void`** o con retorno: **listar** (retorna `List<E_Categoria>`), **insertar**, **editar**, **eliminar** — cada uno llama al método homólogo de Datos pasando los mismos parámetros.

**Dev:** aquí podrías añadir validaciones de negocio si el sistema crece.

---

## Parte 9 — Capa Presentación: diseño del formulario de categoría (`MFrmCategoria`)

**Objetivo:** UI sin bordes, panel superior, búsqueda, grilla estilo “web”, botones de acción.

**Qué se hace:**

- Nuevo formulario WinForms; agregar **Uniform UI** al cuadro de herramientas (DLL desde descripción del vídeo).
- Form **sin borde**; **panel** superior (`Dock Top`), color con **Just Color Picker**; **PictureBox** (logo), **Label** título, icono **cerrar** (Icons8).
- **Uniform Drag Control** para mover el formulario arrastrando el panel.
- Establecer **formulario de inicio** en `Program.cs` → `MFrmCategoria`; doble clic en cerrar → `Application.Exit`.
- Caja de búsqueda: forma redondeada hecha en **PowerPoint**, exportada como imagen, **PictureBox** de fondo + **TextBox** encima (fuente Poppins, sin borde).
- **DataGridView** “tabla categoría”: sin cabecera de fila, estilos (colores selección), `AutoSizeColumnsMode` / filas según diseño.
- Botones: **Nuevo, Editar, Eliminar, Imprimir, Excel, Guardar** (Bunifu/Uniform, iconos Icons8, colores y radios de esquina).
- Cajas para **código, nombre, descripción** (descripción multilínea); **Beautiful Border** (esquinas redondeadas del form); imagen de fondo opcional.
- **Nombrar todos los controles** de forma consistente.

**Dev:** checklist de UX (fuentes, contraste, accesibilidad); convención de nombres (`txt*`, `btn*`, `dgv*`).

---

## Parte 10 — CRUD categoría en el formulario (lógica)

**Objetivo:** Conectar UI con Negocio/Entidades: listar, buscar, nuevo, editar, guardar, eliminar.

**Qué se hace:**

- **`Form_Load`:** referencias/usings a capas; método **`MostrarBuscarTabla(string buscar)`** asigna `DataSource` de la grilla al resultado de **`listandoCategoria(buscar)`** del objeto de negocio; primera carga con cadena vacía.
- Ocultar columna **Id** (índice 0 `Visible = false`); ajustar **anchos** de columnas.
- **Búsqueda en tiempo real:** evento **`TextChanged`** del cuadro de búsqueda → `MostrarBuscarTabla(texto)`.
- **Nuevo:** limpiar textboxes (`Text = ""`); foco en nombre; opcional método **`LimpiarCajas`**.
- **Editar:** variable `string` para “reflejar” Id seleccionado (o control oculto); si hay fila seleccionada, copiar celdas a textboxes; si no, mensaje. **`ClearSelection()`** en carga para forzar selección explícita.
- **Guardar:** flag **`editarse` (bool)**. Si `false` → **insertar** (instancia **Entidad**, mapear controles, `ToUpper()` en nombre si aplica); llamar **`insertandoCategoria`**; mensaje éxito; refrescar tabla; limpiar. Si `true` → asignar **Id** a entidad (conversión **string→int**), **`editandoCategoria`**; mensaje; refrescar; `editarse = false`. **`try/catch`** con mensajes de error.
- **Eliminar:** si hay fila, mapear Id a entidad, **`eliminandoCategoria`**, mensaje, refrescar; si no, avisar.

**Dev:** extraer validaciones (campos obligatorios); sustituir `MessageBox` por notificaciones custom (partes 12–13).

---

## Parte 11 — Tabla y CRUD de **Marcas** (repaso + mismo patrón)

**Objetivo:** Repetir el patrón de Categoría para **Marca** (BD + capas + formulario).

**Qué se hace:**

- Tabla **Marca** análoga: **Id**, **código** con prefijo **“MR”** + misma técnica de autogeneración, nombre, descripción.
- SP: **buscar, insertar, editar, eliminar** (misma lógica que categoría).
- **Entidades:** `E_Marca` con propiedades encapsuladas.
- **Datos:** conexión + métodos que llaman SP (lista con **reader** o alternativa **DataTable** según volumen).
- **Negocio:** `N_Marca` delegando en Datos.
- **Presentación:** formulario copiado del de categoría; `Program.cs` arranca **`FrmMarca`** para probar; mismos eventos (load, búsqueda, CRUD, `editarse`, etc.).

**Dev:** plantilla “copiar y renombrar” documentada; pruebas de regresión en ambos módulos.

---

## Parte 12 — Notificación de éxito (formulario “FRM success” + método estático)

**Objetivo:** Sustituir parte de los `MessageBox` por un **formulario modal** con animación.

**Qué se hace:**

- Formulario de notificación **éxito/aprobado**: sin borde, tamaño fijo, fondo blanco, centrado; **Bunifu Form Dock** + **Fade** en `Form_Load` (`Show` sobre `this`).
- Panel superior, icono check (PNG), **labels** (mensaje dinámico + texto fijo opcional), botón Aceptar (cierra).
- **Método estático** en el formulario de éxito, p. ej. **`ConfirmacionForm(string mensaje)`**: instancia el form, asigna texto al label, **`ShowDialog()`**.
- Constructor del form recibe **`mensaje`** y lo asigna al control.
- En **Marca/Categoría**, reemplazar mensajes de guardado/editado por llamada al método estático.

**Nota:** el archivo de vídeo puede llamarse “Formulario de Validaciones”; el **audio** trata **notificaciones**, no validaciones de negocio.

---

## Parte 13 — Notificación de confirmación (eliminar) + `DialogResult`

**Objetivo:** Confirmar **eliminar** con segundo formulario (`FrmInformacion`) y **OK/Cancel**.

**Qué se hace:**

- Duplicar diseño base del form de notificación; panel, icono información, mensaje tipo “piensa bien la acción…”, botones **Aceptar** y **Cancelar** (colores distintos); `Form_Load` con fade.
- **Aceptar:** `DialogResult = OK`; **Cancelar:** `DialogResult = Cancel`.
- Constructor con **`string mensaje`** para personalizar texto (sin método estático obligatorio; se instancia con `new`).
- En **Eliminar:** `DialogResult resultado = new FrmInformacion("...").ShowDialog();` si **`resultado == OK`** → ejecutar eliminación + notificación de éxito; si cancela, no borrar.

**Dev:** centralizar textos; i18n si aplica.

---

## Parte 14 — Formulario principal (MDI/dashboard): layout, navegación, MDI child

**Objetivo:** Shell principal con **sidebar**, **header** y **contenedor** de formularios hijos.

**Qué se hace:**

- Form principal sin borde; tamaño grande (ej. 1440×940); **tres paneles:** **Sidebar** (`Dock Left`, ancho ~270), **Header** (`Dock Top`, altura ~60), **Wrapper** (`Dock Fill`) para hijos.
- Botón **salir** con confirmación (`FrmInformacion` + `Application.Exit` o lógica de login si existiera).
- **Sidebar:** logo, título “dashboard”, línea divisoria; botones **Uniform Flat Button** (transparentes, iconos normal/seleccionado), efecto hover; método **`SeleccionandoBotones(Button sender)`** pone texto en blanco y color verde al botón seleccionado; resto en blanco.
- **PictureBox “flecha”:** método **`SeguirBotón(Button sender)`** mueve la flecha al `Top` del botón clicado.
- **Abrir formulario en panel:** método con parámetro `Form hijo`: si `Tag` u objeto actual ≠ null, cerrar formulario previo; `TopLevel = false`, `FormBorderStyle = None`, `Dock = Fill`; asignar a `panelWrapper.Controls` y `BringToFront()`.
- Botones **Dashboard** y **Productos** abren formularios de prueba distintos.

**Dev:** siguiente lección conecta BD de productos e **INNER JOIN**.

---

## Parte 15 — Tabla `Producto`, claves foráneas e **INNER JOIN** en SP `ListarProductos`

**Objetivo:** Modelar productos ligados a categoría y marca; listar con nombres resueltos.

**Qué se hace:**

- **CREATE TABLE Producto:** `IdProducto` IDENTITY PK, **código** (prefijo **PR** + patrón `CONVERT`…), nombre producto, precio compra/venta, stock, **IdCategoria**, **IdMarca**; **FOREIGN KEY** a `Categoria` y `Marca`.
- **SP listar productos:** `SELECT` con columnas de producto + **nombres** de categoría y marca; explicación de **INNER JOIN**: unir `Producto` con `Categoria` y `Marca` por sus Ids para mostrar **categoría** y **marca** como columnas derivadas (alias); `ORDER BY` descendente según ejemplo.
- **INSERT** masivo de datos de prueba con **IdCategoria** e **IdMarca** válidos; verificar con `SELECT` que los nombres coinciden con las tablas padre.

**Dev:** índices en FK; integridad referencial antes de borrar categorías/marcas usadas.

---

## Parte 16 — Panel de productos (diseño I)

**Objetivo:** Layout tipo dashboard dentro del form de productos.

**Qué se hace:**

- `FLMProductos` (form productos): **FlowLayoutPanel** con “cajas” (paneles) para **resumen**: productos, categorías, marcas (números estáticos al inicio; luego dinámicos).
- Imágenes / degradados (PowerPoint → PNG); **LineShape**; labels y totales.
- Panel inferior con imagen de fondo; botones **Beautiful Button**: nuevo producto, categorías, marcas, imprimir, exportar Excel (colores distintos).
- Reutilizar diseño de **búsqueda** de categorías/marcas.
- **DataGridView** `tablaProductos` para listar.
- **Capas:** crear **Entidad/Datos/Negocio Producto**; en Datos método **listar** usando SP y **`DataTable.Load(reader)`** (alternativa a `List<>`); en formulario instanciar negocio y enlazar grilla en `Load`.

**Dev:** separar “diseño” de “carga de datos” en métodos (`CargarProductos()`).

---

## Parte 17 — Panel de productos (diseño II + columnas imagen)

**Objetivo:** Pulir grilla y columnas **Editar / Eliminar** con iconos.

**Qué se hace:**

- Ajustar `Dock`/`Anchor` de grilla y botones; estilos DataGridView (fondo, sin borde de cabecera, fuente, selección, padding, `AutoSizeColumnsMode = Fill`, etc.).
- **Columnas tipo imagen** para editar y eliminar (`DataGridViewImageColumn`); asignar iconos.
- Ocultar columnas de **identidad/PK** no deseadas (`Visible = false` en índices concretos); método **`OcultarMoverAncharColumnas`**; **`DisplayIndex`** para mover columnas de acción al final.
- Añadir **labels** de cabecera alineados manualmente sobre la grilla.

**Dev:** `SelectionMode` adecuado (en parte 19 se ajusta a celda para clic en iconos).

---

## Parte 18 — SP de producto (buscar aparte, CRUD) + capas + combos categoría/marca

**Objetivo:** Completar backend y UX de productos: **buscar** sin perder columnas de JOIN; form **mantenimiento producto** (nuevo/editar).

**Qué se hace:**

- Motivo de un SP **`BuscarProductos`** separado: si se reutiliza solo el `SELECT` de producto sin JOIN, al filtrar **desaparecen** columnas categoría/marca; el SP de búsqueda repite el **SELECT con JOIN** y filtra por nombre producto.
- SP **crear / editar / eliminar** producto (parámetros análogos a categoría/marca; editar incluye Id).
- **Capas Producto:** entidad con propiedades; datos con **SqlCommand** + parámetros; negocio reexpone métodos (`buscando`, `insertando`, `editando`, `eliminando`); uso de **`DataTable`** donde aplica.
- **Form productos:** `MostrarProductos` / búsqueda con `TextChanged` llamando a capa negocio con parámetro.
- **Corrección del curso:** columnas **código** en categoría/marca debían ser **solo lectura** (`ReadOnly`) en el diseño.
- **Nuevo producto:** form `mantenimiento de producto` con **ComboBox** (`DropDownList`, `FlatStyle`) para **categoría** y **marca**; métodos **`ListarCategorias`** / **`ListarMarcas`** al cargar form: `DataSource = negocio.Listar...("")`; **`ValueMember = Id`**, **`DisplayMember = Nombre`** (o nombres en inglés si BD en inglés) para guardar **Id** aunque el usuario vea nombre.
- Abrir form con `ShowDialog()` desde botón nuevo.

**Dev:** coherencia de idioma BD/UI; pruebas con BD en inglés vs español.

---

## Parte 19 — `CellContentClick` en grilla: editar / eliminar con confirmación y `bool` público `Update`

**Objetivo:** Interacción por **celda** (iconos), traspaso de fila al form de mantenimiento, guardar o editar.

**Qué se hace:**

- Ajustar **`SelectionMode`** para no seleccionar fila completa al pulsar icono (trabajo por **celda**).
- Evento **`CellContentClick`**: si columna = **Eliminar** → `FrmInformacion` + si OK → leer **Id** desde índice de celda correcto, convertir, llamar **eliminar**, notificación, refrescar grilla; si columna = **Editar** → instanciar form mantenimiento, copiar valores de **celdas** a textboxes/combos (nombres de columnas deben coincidir con cabeceras/minúsculas según BD), **`Update = true`** en form hijo **público** para saber modo edición.
- Controles del form de mantenimiento deben ser **públicos** o exponer setters si se asignan desde el padre.
- **Guardar:** si `Update` false → insertar; si true → actualizar (incluye Id producto); conversiones **string→decimal/int** para precios/stock/ids; refrescar grilla al cerrar; volver `Update` a `false`.
- Botones **nueva categoría / nueva marca** abren formularios correspondientes y deben llamar a **refrescar totales/listas** donde corresponda (enlazado a parte 20).

**Dev:** encapsular mejor que controles públicos (propiedades/métodos en el form).

---

## Parte 20 — Totales (COUNT/SUM) + SP con parámetros **OUTPUT** + exportar Excel

**Objetivo:** KPIs en labels del panel y exportación **Excel** desde la grilla.

**Qué se hace:**

- Consultas **`COUNT(*)`** por tabla (categorías, marcas, productos) y **`SUM(stock)`**; alias de columnas.
- **SP `SumarYProductos` (ejemplo):** cuatro parámetros **OUTPUT** (`totalCategorias`, `totalMarcas`, `totalProductos`, `sumaStock`) poblados con `SELECT` agregados.
- **Capa Datos:** método **`ShowTotales`** / similar: `SqlCommand` SP, registrar parámetros **Output**, `ExecuteNonQuery`, leer **`Parameter.Value`**, convertir a string para **labels**.
- **Capa Negocio:** método que delega.
- **Presentación:** asignar `label.Text` desde entidad/objeto de totales; llamar método de totales en **Load** y después de **guardar/editar/eliminar** producto y al cerrar **nuevo producto** / al agregar categoría o marca para refrescar **en “tiempo real”**.
- **Excel:** referencia **Microsoft.Office.Interop.Excel** (vía NuGet “Microsoft.Office.Interop.Excel” si no está en referencias locales); instanciar `Application`, `Workbook`, `Worksheet`; bucles anidados para copiar cabeceras y celdas del **DataGridView** (saltando columnas de iconos editar/eliminar, índice inicial según diseño); `Visible = true`.
- Limpieza manual en Excel de columnas no deseadas si quedaron iconos.

**Dev:** en servidores sin Office, sustituir por **ClosedXML** / **EPPlus**; no depender de interop en producción headless.

---

## Referencia rápida: archivos de subtítulo y vídeo

| Parte | Subtítulo | Tema principal |
|------:|-----------|----------------|
| 1 | `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles1.srt` | Intro, requisitos, alcance |
| 2 | `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles2.srt` | Teoría de capas y entidades |
| 3 | `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles3.srt` | BD + tabla Categoría |
| 4 | `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles4.srt` | SP Categoría |
| 5 | `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles5.srt` | Solución VS + conexión |
| 6 | `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles6.srt` | Entidad Categoría |
| 7 | `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles7.srt` | Datos Categoría |
| 8 | `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles8.srt` | Negocio Categoría |
| 9 | `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles9.srt` | UI Categoría |
| 10 | `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles10.srt` | CRUD Categoría |
| 11 | `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles11.srt` | Marca (todo el stack) |
| 12 | `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles12.srt` | Notificación éxito |
| 13 | `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles13.srt` | Confirmación eliminar |
| 14 | `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles14.srt` | Form principal / MDI |
| 15 | `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles15.srt` | Producto + INNER JOIN |
| 16 | `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles16.srt` | Panel productos (I) |
| 17 | `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles17.srt` | Panel productos (II) |
| 18 | `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles18.srt` | SP buscar + combos + form |
| 19 | `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles19.srt` | Clicks grilla + guardar/editar |
| 20 | `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles20.srt` | Totales OUTPUT + Excel |

---

## Texto plano extraído (trazabilidad)

Los guiones línea a línea usados para esta guía están en:

`docs/subtitulos-texto-plano/parte-01.txt` … `parte-20.txt`

(pueden regenerarse con el mismo script de extracción si actualizas los `.srt`).

---

## Relación con el código Onion del repositorio (`codigo/`)

La carpeta **`codigo/`** implementa un **vertical slice** de **Categoría** con **Onion** + `appsettings.json`, distinto en detalle al esquema del vídeo 3 (código/descripcion). Usa esta guía como **especificación funcional del curso** y el proyecto `codigo/` como **base arquitectónica moderna**; alinear nombres de columnas/SP es tarea de migración explícita.

Para reparto en equipo, ver también **`docs/DIVISION-8-DESARROLLADORES.md`**.
