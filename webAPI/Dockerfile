#Compiling project in container
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build_env
WORKDIR /webAPI
COPY *.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o out

#Create runtime docker image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /webAPI

#Expose port outside of container
EXPOSE 80

COPY --from=build_env /webAPI/out .
ENTRYPOINT ["dotnet", "webAPI.dll"]