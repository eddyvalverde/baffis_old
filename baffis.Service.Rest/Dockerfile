#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["baffis.Service.Rest/baffis.Service.Rest.csproj", "baffis.Service.Rest/"]
COPY ["baffis.DataAccess/baffis.DataAccess.csproj", "baffis.DataAccess/"]
COPY ["baffis.DataAccess.Interface/baffis.DataAccess.Interface.csproj", "baffis.DataAccess.Interface/"]
COPY ["baffis.Model/baffis.Model.csproj", "baffis.Model/"]
COPY ["baffis.BussinessLogic/baffis.BusinessLogic.csproj", "baffis.BussinessLogic/"]
COPY ["baffis.BusinessLogic.Interface/baffis.BusinessLogic.Interface.csproj", "baffis.BusinessLogic.Interface/"]
RUN dotnet restore "baffis.Service.Rest/baffis.Service.Rest.csproj"
COPY . .
WORKDIR "/src/baffis.Service.Rest"
RUN dotnet build "baffis.Service.Rest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "baffis.Service.Rest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "baffis.Service.Rest.dll"]