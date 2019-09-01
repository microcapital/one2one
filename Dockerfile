FROM mcr.microsoft.com/dotnet/core/sdk:2.2.401 AS build-env
  
WORKDIR /app
COPY . ./

RUN sed -i 's#<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="2.2.6" />#<PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="2.2.6" />#' src/OneTwoOne.WebHost/OneTwoOne.WebHost.csproj
RUN sed -i 's/UseSqlServer/UseNpgsql/' src/OneTwoOne.WebHost/Program.cs
RUN sed -i 's/UseSqlServer/UseNpgsql/' src/OneTwoOne.WebHost/Extensions/ServiceCollectionExtensions.cs

RUN rm src/OneTwoOne.WebHost/Migrations/* && cp -f src/OneTwoOne.WebHost/appsettings.docker.json src/OneTwoOne.WebHost/appsettings.json

# ef core migrations run in debug, so we have to build in Debug for copying module correctly 
RUN dotnet restore && dotnet build \
    && cd src/OneTwoOne.WebHost \
	&& dotnet ef migrations add initialSchema \
    && dotnet ef migrations script -o dbscript.sql

RUN dotnet build -c Release \
	&& cd src/OneTwoOne.WebHost \
    && dotnet build -c Release \
	&& dotnet publish -c Release -o out

# remove BOM for psql	
RUN sed -i -e '1s/^\xEF\xBB\xBF//' /app/src/OneTwoOne.WebHost/dbscript.sql

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2.6

# hack to make postgresql-client install work on slim
RUN mkdir -p /usr/share/man/man1 \
    && mkdir -p /usr/share/man/man7

RUN apt-get update \
	&& apt-get install -y --no-install-recommends postgresql-client \
	&& apt-get install libgdiplus -y \
	&& rm -rf /var/lib/apt/lists/*

WORKDIR /app	
COPY --from=build-env /app/src/OneTwoOne.WebHost/out ./
COPY --from=build-env /app/src/OneTwoOne.WebHost/dbscript.sql ./

RUN curl -SL "https://github.com/rdvojmoc/DinkToPdf/raw/v1.0.8/v0.12.4/64%20bit/libwkhtmltox.so" --output ./libwkhtmltox.so

COPY --from=build-env /app/docker-entrypoint.sh /
RUN chmod 755 /docker-entrypoint.sh

ENTRYPOINT ["/docker-entrypoint.sh"]
