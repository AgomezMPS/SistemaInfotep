# Genera subtitles4.srt ... subtitles20.srt con auto-subs (Whisper).
# Omite si ya existe el .srt correspondiente. Requiere: pip install "auto-subs[transcribe]", FFmpeg en PATH.

$ErrorActionPreference = "Stop"
$env:Path = [System.Environment]::GetEnvironmentVariable("Path", "Machine") + ";" + [System.Environment]::GetEnvironmentVariable("Path", "User")

$ProjectRoot = $PSScriptRoot
# Evita depender de un literal con tildes (fallos de codificación en algunas consolas).
$VideosDir = (
    Get-ChildItem -LiteralPath $ProjectRoot -Directory -ErrorAction SilentlyContinue |
    Where-Object { (Get-ChildItem -LiteralPath $_.FullName -Filter "*.mp4" -File -ErrorAction SilentlyContinue).Count -gt 0 } |
    Select-Object -First 1
).FullName
$AutoSubs = "C:\Users\mpsdo\AppData\Roaming\Python\Python314\Scripts\auto-subs.exe"

if (-not (Test-Path $AutoSubs)) { throw "No se encuentra auto-subs.exe: $AutoSubs" }
if (-not $VideosDir -or -not (Test-Path -LiteralPath $VideosDir)) { throw "No se encuentra carpeta de videos con .mp4 bajo: $ProjectRoot" }

$items = Get-ChildItem -Path $VideosDir -Filter "*.mp4" -File | ForEach-Object {
    if ($_.Name -match '^(\d+)\s') {
        [pscustomobject]@{ Num = [int]$Matches[1]; Path = $_.FullName; Name = $_.Name }
    }
} | Sort-Object Num

$targets = $items | Where-Object { $_.Num -ge 4 -and $_.Num -le 20 }
if (-not $targets) { throw "No se encontraron videos numerados del 4 al 20." }

foreach ($t in $targets) {
    $out = Join-Path $ProjectRoot ("subtitles{0}.srt" -f $t.Num)
    if (Test-Path $out) {
        Write-Host "[omitir] Ya existe $out"
        continue
    }
    Write-Host "[transcribir] #$($t.Num) -> $out"
    & $AutoSubs transcribe --format srt -o $out --model base --stream $t.Path
    if ($LASTEXITCODE -ne 0) { throw "Fallo transcribe en video $($t.Num): $($t.Name)" }
}

Write-Host "Listo: subtitulos 4-20 generados en $ProjectRoot"
