@ECHO OFF

SET ASPNETCORE_ENVIRONMENT=Development

@ECHO Database starting with docker...

docker-compose up -d database

timeout /nobreak /t 2

@ECHO.

@ECHO TransportePublico.Api starting...
cd TransportePublico.Api

dotnet watch run --no-launch-profile

cd ..
