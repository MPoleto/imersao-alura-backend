FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /languages-api
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine as runtime
WORKDIR /languages-api
COPY --from=build /languages-api/out .
ENTRYPOINT ["dotnet", "languages-api.dll"]