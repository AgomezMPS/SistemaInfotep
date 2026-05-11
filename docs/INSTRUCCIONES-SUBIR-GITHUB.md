# Subir este proyecto a GitHub (`main`)

## 1. Crear el repositorio vacío en GitHub

Abre en el navegador (sesión iniciada en GitHub):

**[https://github.com/new](https://github.com/new)**

- **Repository name:** por ejemplo `mantenimiento-productos-csharp-curso` (sin espacios).
- **Public** o **Private** según prefieras.
- **No** marques “Add a README” ni .gitignore ni licencia (ya existen en local).

Tras crearlo, GitHub mostrará la URL HTTPS del repo, por ejemplo:

`https://github.com/TU_USUARIO/mantenimiento-productos-csharp-curso`

## 2. Conectar el remoto y subir a `main`

En PowerShell, desde la **raíz** de esta carpeta (donde está `README.md`):

```powershell
git remote add origin https://github.com/TU_USUARIO/mantenimiento-productos-csharp-curso.git
git branch -M main
git push -u origin main
```

Si GitHub te pide autenticación, usa un **Personal Access Token** (classic) con permiso `repo` en lugar de la contraseña, o **Git Credential Manager**.

## 3. Comprobar que `main` recibió el push

Sustituye usuario y nombre del repo:

**`https://github.com/TU_USUARIO/mantenimiento-productos-csharp-curso/tree/main`**

Deberías ver `README.md`, `docs/`, `codigo/`, los `.srt`, etc. La carpeta de vídeos solo contendrá este `README.md` (los `.mp4` están en `.gitignore`).

## 4. Reglas de rama en GitHub (opcional)

En el repo: **Settings → Branches → Branch protection rules** puedes proteger `main` (revisiones obligatorias, etc.). Eso no impide el primer push; solo afecta a pushes futuros según la regla.
