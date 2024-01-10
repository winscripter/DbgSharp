@REM This script assumes x64 .NET 6.0 and later versions are in PATH. Otherwise, it may not work.
pushd ..\DbgSharp
dotnet build --output %~dp0out-dotnet
popd

copy-res out-dotnet
