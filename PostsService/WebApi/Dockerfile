FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY *.sln ./
COPY PostsService/WebApi/MicroservicesQuickStart.PostsService.WebApi.csproj MicroservicesQuickStart.PostsService.WebApi/
RUN dotnet restore
COPY . .
WORKDIR /src/MicroservicesQuickStart.PostsService.WebApi
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MicroservicesQuickStart.PostsService.WebApi.dll"]
