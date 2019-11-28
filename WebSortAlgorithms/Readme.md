1. coloar la licencia. MIT
2. Colocar una breve explicacion de lo que el sistema hace (los 6 algoritmos de ordenamiento)
3. Correr la aplicacion en doker local
4. Subir la aplicacion a Heroku con Net Core:
https://codingblast.com/hosting-asp-net-core-on-heroku-with-dockercircleci-for-free/
https://github.com/Ibro/AspNetCoreHerokuDocker
https://docs.docker.com/engine/examples/dotnetcore/
https://github.com/dotnet/dotnet-docker/tree/master/samples/aspnetapp


Publish the app (using console)
- dotnet publish -c Release
This command compiles your app to the publish folder. 
The path to the publish folder from the working folder should be .\app\bin\Release\netcoreapp2.2\publish\

- Create the Dockerfile
The Dockerfile file is used by the docker build command to create a container image.

the first line in dockerfile is the docker image to pull: 3.0
FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build

- Start Docker

- Creates the image in docker:
docker build -t myimage -f Dockerfile .

- See the installed images:
docker images


Possible errors starting docker:
This computer doesn’t have VT-X/AMD-v enabled. Enabling it in the BIOS is mandatory.
Solution: enable Virtualization in the machine, if it does not work and you are working in windows machine
please disable Hyper-V and reastart machine: bcdedit /set hypervisorlaunchtype off
https://localbyflywheel.com/community/t/windows-help-im-getting-a-bios-error-about-vt-x-amd-v-during-installation/426

