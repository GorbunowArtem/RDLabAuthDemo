FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/RDLabAuthDemo.BasicJwt/RDLabAuthDemo.BasicJwt.csproj", "RDLabAuthDemo.BasicJwt/"]
RUN dotnet restore "src/RDLabAuthDemo.BasicJwt/RDLabAuthDemo.BasicJwt.csproj"
COPY . .
WORKDIR "/src/RDLabAuthDemo.BasicJwt"
RUN dotnet build "RDLabAuthDemo.BasicJwt.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RDLabAuthDemo.BasicJwt.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RDLabAuthDemo.BasicJwt.dll"]
