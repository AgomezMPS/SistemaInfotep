# Diseño y programación de un mantenimiento de productos en C#

Material del curso en vídeo (720p) con subtítulos en formato **SubRip (`.srt`)**, pensado para publicar el repositorio en GitHub con una guía clara **parte por parte**. Las **20 clases** cuentan ya con su archivo `subtitlesN.srt` correspondiente.

---

## Contenido del repositorio

| Elemento | Descripción |
|----------|-------------|
| Carpeta de vídeos | `Diseño y Programación de un mantenimiento de Productos en C#/` — contiene los `.mp4` numerados del **1** al **20**. |
| Subtítulos | `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles1.srt` … `subtitles20.srt` (un archivo por clase). |
| Generación automática | Script y log en la misma carpeta `transcripciones/`: `transcribe-subtitles-4-20.ps1`, `transcribe-subtitles-log.txt`. |
| **Código (C# / Onion)** | Carpeta **`codigo/`** — solución `MantenimientoProductos.sln`, WinForms + SQL Server. Guía: **`codigo/README.md`**. |
| **Reparto 8 desarrolladores** | **`docs/DIVISION-8-DESARROLLADORES.md`** — las 20 partes del curso agrupadas en 8 frentes. |
| **Guía técnica por lección** | **`docs/GUIA-DETALLADA-POR-LECCION.md`** — qué hace cada parte del curso (objetivos, BD, capas, UI, entregables) según el texto completo de los subtítulos. |
| **Publicar en GitHub** | **`docs/INSTRUCCIONES-SUBIR-GITHUB.md`** — crear el remoto, `git push` a `main` y enlace para comprobar el árbol en GitHub. |

> Los **vídeos `.mp4`** no se incluyen en Git por tamaño; la carpeta de lecciones conserva un `README.md` para uso local. Los subtítulos `.srt` viven en **`…/transcripciones/`** junto al material del curso.

---

## Verificación de subtítulos (estado actual)

Revisión realizada sobre los archivos presentes en disco: formato **SRT válido** (bloques numerados, marcas de tiempo `HH:MM:SS,mmm --> …`, texto en español legible). Hay **20 archivos** bajo `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitlesN.srt` con métricas de tamaño y número de cuadros comprobados en disco.

### Resumen por archivo (ruta: `…/transcripciones/`)

| Archivo | Origen | Tamaño (aprox.) | Cuadros de subtítulo (`-->`) | Observación |
|---------|--------|-----------------|------------------------------|-------------|
| `subtitles1.srt` | Curso (manual / previo) | 6,7 KB | 117 | Introducción; texto fluido. |
| `subtitles2.srt` | Curso (manual / previo) | 14,5 KB | 246 | Patrones de arquitectura. |
| `subtitles3.srt` | Curso (manual / previo) | 18,7 KB | 322 | Base de datos, tabla categoría. |
| `subtitles4.srt` | **Whisper** (`auto-subs`, modelo `base`) | 9,7 KB | 155 | Generado localmente; español detectado. |
| `subtitles5.srt` | Whisper | 12,0 KB | 185 | |
| `subtitles6.srt` | Whisper | 6,5 KB | 103 | |
| `subtitles7.srt` | Whisper | 23,8 KB | 377 | Lección larga; más cuadros. |
| `subtitles8.srt` | Whisper | 10,2 KB | 154 | |
| `subtitles9.srt` | Whisper | 23,2 KB | 358 | |
| `subtitles10.srt` | Whisper | 26,6 KB | 424 | |
| `subtitles11.srt` | Whisper | 27,3 KB | 411 | |
| `subtitles12.srt` | Whisper | 18,9 KB | 304 | |
| `subtitles13.srt` | Whisper | 23,3 KB | 348 | |
| `subtitles14.srt` | Whisper | 31,1 KB | 465 | |
| `subtitles15.srt` | Whisper | 27,6 KB | 439 | |
| `subtitles16.srt` | Whisper | 17,8 KB | 270 | |
| `subtitles17.srt` | Whisper | 16,0 KB | 251 | |
| `subtitles18.srt` | Whisper | 46,3 KB | 729 | Lección muy larga; más cuadros. |
| `subtitles19.srt` | Whisper | 42,4 KB | 661 | |
| `subtitles20.srt` | Whisper | 36,8 KB | 537 | |

### Notas de calidad (automáticos 4–20)

- **Ventaja:** coherencia temporal con el audio, español reconocido automáticamente.
- **Revisión recomendada:** términos técnicos (`CRUD`, nombres de tablas, código en pantalla) pueden aparecer con grafías alternativas; conviene repasar antes de usar los `.srt` en producción o traducción.

---

## Índice del curso parte por parte

Cada parte corresponde al vídeo homónimo en la carpeta de materiales. El subtítulo asociado es `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles{n}.srt` (**n = 1 … 20**).

### Parte 1 — Introducción del curso

Presentación del alcance del mini curso y del sistema de ejemplo (p. ej. enfoque en ventas / mantenimiento).

- **Vídeo:** `1 Introducción del Curso_720p.mp4`
- **Subtítulos:** `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles1.srt`

### Parte 2 — Patrones de arquitectura

Conceptos de organización del código y capas típicas en aplicaciones de escritorio.

- **Vídeo:** `2 Patrones de Arquitéctura_720p.mp4`
- **Subtítulos:** `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles2.srt`

### Parte 3 — Creando la base de datos (tabla categoría)

Modelado inicial en base de datos orientado al mantenimiento de categorías.

- **Vídeo:** `3 Creando nuestra Base de Datos - Tabla Categoría_720p.mp4`
- **Subtítulos:** `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles3.srt`

### Parte 4 — Procedimientos almacenados (tabla categoría)

Uso de procedimientos almacenados sobre la tabla categoría.

- **Vídeo:** `4 Procedimientos Almacenados-Tabla Categoría_720p.mp4`
- **Subtítulos:** `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles4.srt` (Whisper)

### Parte 5 — Proyecto en N capas y conexión a la base de datos

Creación del proyecto por capas y cadena de conexión.

- **Vídeo:** `5 Creación del proyecto en N Capas - Conexión a la base de datos_720p.mp4`
- **Subtítulos:** `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles5.srt` (Whisper)

### Parte 6 — Capa entidades (categoría)

Definición de entidades para categoría.

- **Vídeo:** `6 Capa Entidades - Categoría_720p.mp4`
- **Subtítulos:** `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles6.srt` (Whisper)

### Parte 7 — Capa datos (categoría)

Acceso a datos y operaciones contra categoría.

- **Vídeo:** `7 Capa Datos - Categoría_720p.mp4`
- **Subtítulos:** `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles7.srt` (Whisper)

### Parte 8 — Capa negocio (categoría)

Reglas de negocio para categoría.

- **Vídeo:** `8 Capa Negocio - Categoría_720p.mp4`
- **Subtítulos:** `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles8.srt` (Whisper)

### Parte 9 — Capa presentación: formulario de categoría

Diseño de interfaz para el mantenimiento de categoría.

- **Vídeo:** `9 Capa Presentación - Diseño del Formulario de Categoría_720p.mp4`
- **Subtítulos:** `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles9.srt` (Whisper)

### Parte 10 — CRUD: mantenimiento de categoría

Operaciones CRUD completas sobre categoría.

- **Vídeo:** `10 CRUD - Mantenimiento de Categoría_720p.mp4`
- **Subtítulos:** `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles10.srt` (Whisper)

### Parte 11 — CRUD: mantenimiento de marcas

Extensión del mantenimiento al dominio de marcas.

- **Vídeo:** `11 CRUD - Mantenimiento Marcas_720p.mp4`
- **Subtítulos:** `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles11.srt` (Whisper)

### Parte 12 — Formulario de validaciones

Validación de datos en formularios.

- **Vídeo:** `12 Formulario de Validaciones_720p.mp4`
- **Subtítulos:** `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles12.srt` (Whisper)

### Parte 13 — Formulario de información

Formularios de captura o ficha de información.

- **Vídeo:** `13 Formulario de Información_720p.mp4`
- **Subtítulos:** `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles13.srt` (Whisper)

### Parte 14 — Diseño del formulario principal

Estructura de la ventana principal de la aplicación.

- **Vídeo:** `14 Diseño del Formulario Principal_720p.mp4`
- **Subtítulos:** `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles14.srt` (Whisper)

### Parte 15 — Tabla de productos e Inner Join

Consultas con `INNER JOIN` para productos.

- **Vídeo:** `15 Creación de tabla de productos - Aplicando Inner Join_720p.mp4`
- **Subtítulos:** `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles15.srt` (Whisper)

### Parte 16 — Panel de productos (primera parte)

Primera iteración del panel de gestión de productos.

- **Vídeo:** `16 Diseñando el panel de productos - Primera Parte_720p.mp4`
- **Subtítulos:** `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles16.srt` (Whisper)

### Parte 17 — Panel de productos (segunda parte)

Continuación del panel de productos.

- **Vídeo:** `17 Diseñando el panel de productos - Segunda Parte_720p.mp4`
- **Subtítulos:** `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles17.srt` (Whisper)

### Parte 18 — Procedimientos almacenados y CRUD de productos (I)

Primera parte del CRUD de productos con procedimientos almacenados.

- **Vídeo:** `18 Procedimientos almacenados y CRUD de Productos (Primera Parte)_720p.mp4`
- **Subtítulos:** `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles18.srt` (Whisper)

### Parte 19 — Procedimientos almacenados y CRUD de productos (II)

Segunda parte del CRUD de productos.

- **Vídeo:** `19 Procedimientos almacenados y CRUD de Productos (Segunda Parte)_720p.mp4`
- **Subtítulos:** `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles19.srt` (Whisper)

### Parte 20 — Resumen y exportación a Excel

Totales y exportación desde `DataGridView` hacia Excel.

- **Vídeo:** `20 Resumen de totales - Exportar datos de datagridview a Excel_720p.mp4`
- **Subtítulos:** `Diseño y Programación de un mantenimiento de Productos en C#/transcripciones/subtitles20.srt` (Whisper)

---

## Regenerar subtítulos (opcional)

Si borras algún `subtitlesN.srt` en `transcripciones/` (por ejemplo para volver a transcribir con otro modelo de Whisper) o añades nuevos vídeos, puedes ejecutar de nuevo el script desde PowerShell:

```powershell
Set-Location -LiteralPath "ruta\al\proyecto\Diseño y Programación de un mantenimiento de Productos en C#\transcripciones"
.\transcribe-subtitles-4-20.ps1
```

El script **omite** los `.srt` que ya existan y solo procesa los faltantes (numeración **4–20** según el script actual). Requisitos: Python con `auto-subs[transcribe]`, FFmpeg y descarga del modelo en la primera ejecución.

---

## Licencia y uso

Añade aquí la licencia que corresponda al material (propiedad del autor del curso, uso educativo, etc.). Si este repositorio es solo para organización personal o portafolio, indícalo también en esta sección.
