#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM node:10.15-alpine AS client 
ARG skip_client_build=false 
WORKDIR /app 
COPY ["baffis.FrontEnd.Web/ClientApp", "."]
RUN [[ ${skip_client_build} = true ]] && echo "Skipping npm install" || npm install 
RUN [[ ${skip_client_build} = true ]] && mkdir dist || npm run-script build

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["baffis.FrontEnd.Web/baffis.FrontEnd.Web.csproj", "baffis.FrontEnd.Web/"]
RUN dotnet restore "baffis.FrontEnd.Web/baffis.FrontEnd.Web.csproj"
COPY . .
WORKDIR "/src/baffis.FrontEnd.Web"
RUN dotnet build "baffis.FrontEnd.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "baffis.FrontEnd.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=client /app/dist /app/dist
ENTRYPOINT ["dotnet", "baffis.FrontEnd.Web.dll"]