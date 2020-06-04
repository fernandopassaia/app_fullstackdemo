FROM mcr.microsoft.com/dotnet/core/samples:aspnetapp
LABEL version="1.0" maintainer="AppFullStackDemoBackEnd"
COPY ./BackEnd/dist /app
WORKDIR /app
ENTRYPOINT ["dotnet", "src.dll"]