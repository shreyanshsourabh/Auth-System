@echo off
setlocal

set "CSC_PATH=C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe"
set output=Run.exe

if exist "%output%" del "%output%"

echo.
echo ===========================================
echo Building the application...
echo ===========================================

%CSC_PATH% ^

/out:%output% ^
main.cs ^
services\AuthService\app.cs ^
services\AuthService\src\models\User.cs

if errorlevel 1 (
    echo Build failed.
    exit /b 1
)   

echo.
echo ===========================================
echo Build succeeded. Running...
echo ===========================================

.\%output%
endlocal
