@REM This script assumes MSBuild is recognized. Otherwise, it will not work.
mkdir out >NUL
MSBuild ..\DbgSharp.sln /p:OutputPath=%~dp0out
