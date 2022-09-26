FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR serbici

EXPOSE 80
EXPOSE 8084


COPY ./*.csproj ./
RUN dotnet restore 

COPY . .
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/sdk:3.1
WORKDIR /serbici

COPY --from=build /serbici/out .
ENTRYPOINT ["dotnet", "BackCRUD.dll"]