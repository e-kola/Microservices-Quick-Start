FROM microsoft/aspnetcore:2.0-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-nanoserver-1709 AS build
WORKDIR /src
COPY *.sln ./
COPY TVX.Test.PostsService/TVX.Test.PostsService.csproj TVX.Test.PostsService/
RUN dotnet restore
COPY . .
WORKDIR /src/TVX.Test.PostsService
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TVX.Test.PostsService.dll"]
