#FROM microsoft/dotnet:2.2-aspnetcore-runtime
#FROM mcr.microsoft.com/dotnet/core/aspnet:2.2

#pobranie obrazu .net core sdk 2.2 
FROM mcr.microsoft.com/dotnet/core/sdk:2.2
#skopiowanie plików i folderów z obecnej ścieżki do folderu /app w powstającym obrazie
COPY . /app
#ustawienie folderu /app w powstającym obrazie jako ścieżki roboczej
WORKDIR /app
#pobranie brakujących paczek Nugget
RUN dotnet restore
#wykonanie publisha do folderu /publish ustawiając projekt BicycleService jako projekt startowy apliakcji  
RUN dotnet publish ./BicycleService/BicycleService.Api.csproj -o /publish/
#ustawienie folderu /publish jako ścieżki roboczej
WORKDIR /publish
#ustawienie komendy uruchamiającej aplikację .Net wraz z ustawieniem zmiennej środowiskowej PORT ($ oznacza początek nazwy zmiennej środowiskowej)
CMD ASPNETCORE_URLS=http://*:$PORT dotnet BicycleService.dll