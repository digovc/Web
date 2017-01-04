@ECHO OFF

REM Diretório para .NET 4.0.
set DOTNETFX4=%SystemRoot%\Microsoft.NET\Framework\v4.0.30319
set PATH=%PATH%;%DOTNETFX4%

echo Instalando servidor WEB...
echo ---------------------------------------------------
InstallUtil /i <aplicacao_diretorio_completo>.exe
echo ---------------------------------------------------
echo Concluído.
pause