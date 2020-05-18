#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ConnectionStrings:UserDbConnectionMssql= Server=swati2698-02,1401;Initial Catalog=UserDb;  Trusted_Connection=True;  MultipleActiveResultSets=true;


FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1903 AS build
WORKDIR /src
COPY ["UserAPI/UserAPI.csproj", "UserAPI/"]
RUN dotnet restore "UserAPI/UserAPI.csproj"
COPY . .
WORKDIR "/src/UserAPI"
RUN dotnet build "UserAPI.csproj" -c Release -o /app/build

#EXPOSE 80/tcp
#COPY entrypoint.sh /entrypoint.sh 
#RUN chmod +x ./entrypoint.sh
#RUN /entrypoint.sh
#CMD /bin/bash ./entrypoint.sh

FROM build AS publish
RUN dotnet publish "UserAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserAPI.dll"]