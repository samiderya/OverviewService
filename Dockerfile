FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
EXPOSE 5203
COPY . /app/
ENTRYPOINT ["dotnet", "Overview.dll"]