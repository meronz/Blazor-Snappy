#!/bin/sh
curl -sSL https://dot.net/v1/dotnet-install.sh > dotnet-install.sh
chmod +x dotnet-install.sh
./dotnet-install.sh -c 8.0 -InstallDir ./dotnet
./dotnet/dotnet --version
echo "dotnet installed!"
./dotnet/dotnet workload install wasm-tools

echo "Build"
./dotnet/dotnet publish src/Snappy.Demo/ -c Release -o output
