@REM This script assumes x64 .NET 6.0 and later versions are in PATH. Otherwise, it may not work.
build-sln-dotnet

pushd %~dp0out-dotnet
dotnet run
popd
