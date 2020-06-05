FROM mcr.microsoft.com/dotnet/core/samples:aspnetapp
LABEL version="1.0" maintainer="AppFullStackDemoBackEnd"
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
RUN ["dotnet", "publish -o ../dist"]
RUN ["dotnet", "ef database update"]
COPY ../dist /app
WORKDIR /app
ENTRYPOINT ["dotnet", "AppFullStackDemo.Api.dll"]