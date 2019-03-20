FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY Edgenuity.Poc.GraphQL.sln ./
COPY ["SQL.Entity/*.csproj", "./SQL.Entity/"]
COPY ["Mongo.Context/*.csproj", "./Mongo.Context/"]
COPY ["SqlApi/*.csproj", "./SqlApi/"]
COPY ["GraphQLApi/*.csproj", "./GraphQLApi/"]
RUN dotnet restore

COPY . .
WORKDIR "/src/SQL.Entity"
RUN dotnet build "SqlDB.csproj" -c Release -o /app

WORKDIR "/src/Mongo.Context"
RUN dotnet build "MongoDB.csproj" -c Release -o /app

WORKDIR "/src/SqlApi"
RUN dotnet build "SqlApi.csproj" -c Release -o /app

WORKDIR "/src/GraphQLApi"
RUN dotnet build "GraphQLApi.csproj" -c Release -o /app 

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
# RUN dotnet dev-certs https
ENTRYPOINT ["dotnet", "GraphQLApi.dll"]

#https://stackoverflow.com/questions/47103570/asp-net-core-2-0-multiple-projects-solution-docker-file?rq=1
# docker run -d=false -p 8080:80 --name webapi webapi:dev -e "DOTNET_USE_POLLING_FILE_WATCHER=1" -e "ASPNET CORE_ENVIRONMENT=Development" -e "ASPNETCORE_URLS=https://+:443;http://+:80" -e "ASPNETCORE_HTTPS_PORT=44397" -e "NUGET_PACKAGES=/root /.nuget/fallbackpackages2" -e "NUGET_FALLBACK_PACKAGES=/root/.nuget/fallbackpackages;/root/.nuget/fallbackpackages2"  -p 56014:80 -p 44397:443