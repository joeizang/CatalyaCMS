FROM microsoft/dotnet:3.0-aspnetcore-runtime

RUN apt-get -qq update && apt-get install -y libfontconfig1
RUN apt-get -qq update && apt-get install -y libfreetype6
WORKDIR /cat
EXPOSE 80

FROM microsoft/dotnet:3.0-sdk AS build

WORKDIR /catsrc
COPY CatalyaCMS.Api/CatalyaCMS.Api.csproj CatalyaCMS.Api.CatalyaCMS.Api/
COPY CatalyaCMS.Domain/CatalyaCMS.Domain.csproj CatalyaCMS.Domain.CatalyaCMS.Domain/
COPY CatalyaCMS.Infrastructure/CatalyaCMS.Infrastructure.csproj  CatalyaCMS.Infrastructure.CatalyaCMS.Infrastructure/
COPY CatalyaCMS.Tests.CatalyaCMS/Domain.csproj  CatalyaCMS.Tests.CatalyaCMS.Tests/


RUN dotnet restore CatalyaCMS.Api/CatalyaCMS.Api.csproj 
COPY . .
WORKDIR /catsrc/CatalyaCMS.Api
RUN dotnet build CatalyaCMS.Api/CatalyaCMS.Api.csproj  -c Release -o /cat

FROM build AS publish
RUN dotnet publish CatalyaCMS.Api/CatalyaCMS.Api.csproj  -c Release -o /cat

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
