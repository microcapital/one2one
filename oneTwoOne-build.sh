#!/bin/bash
set -e

sed -i'' -e 's|<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="2.2.6" />|<PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="2.2.0" />|' src/OneTwoOne.WebHost/OneTwoOne.WebHost.csproj
sed -i'' -e 's/UseSqlServer/UseNpgsql/' src/OneTwoOne.WebHost/Program.cs
sed -i'' -e 's/UseSqlServer/UseNpgsql/' src/OneTwoOne.WebHost/Extensions/ServiceCollectionExtensions.cs

rm -rf src/OneTwoOne.WebHost/Migrations/*

dotnet restore && dotnet build

cd src/OneTwoOne.WebHost \
	&& dotnet ef migrations add initialSchema \
	&& dotnet ef database update
	
echo "The database schema has been created. Please execute the src/Database/StaticData_Postgres.sql to insert static data."
echo "Then type 'dotnet run' in src/OneTwoOne.WebHost to start the app."
