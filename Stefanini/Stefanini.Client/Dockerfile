#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Stefanini.Client/Stefanini.Client.csproj", "Stefanini.Client/"]
RUN dotnet restore "Stefanini.Client/Stefanini.Client.csproj"
COPY . .
WORKDIR "/src/Stefanini.Client"
RUN dotnet build "Stefanini.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Stefanini.Client.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Stefanini.Client.dll"]