dotnet publish src\IXRay.Hub.Avalonia\IXRay.Hub.Avalonia.csproj ^
    --configuration Release ^
    --runtime win-x64 ^
    -p:PublishAot=true ^
    -p:InvariantGlobalization=true ^
    -p:IsAotCompatible=true
