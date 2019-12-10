#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-nanoserver-1809 AS build
WORKDIR /src
COPY ["Life-In-Notes/Life-In-Notes.csproj", "Life-In-Notes/"]
RUN dotnet restore "Life-In-Notes/Life-In-Notes.csproj"
COPY . .
WORKDIR "/src/Life-In-Notes"
RUN dotnet build "Life-In-Notes.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Life-In-Notes.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Life-In-Notes.dll"]