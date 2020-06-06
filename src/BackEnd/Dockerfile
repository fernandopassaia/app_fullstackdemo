FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS base
LABEL version="1.0" maintainer="AppFullStackDemoBackEnd"
EXPOSE 4001

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
ADD / ./
RUN dotnet restore
COPY . .
WORKDIR /src/AppFullStackDemo.Api
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AppFullStackDemo.Api.dll"]