1. coloar la licencia. MIT
2. Colocar una breve explicacion de lo que el sistema hace (los 6 algoritmos de ordenamiento)
https://codingblast.com/hosting-asp-net-core-on-heroku-with-dockercircleci-for-free/
https://github.com/Ibro/AspNetCoreHerokuDocker
https://docs.docker.com/engine/examples/dotnetcore/
https://github.com/dotnet/dotnet-docker/tree/master/samples/aspnetapp



1.  HOW to deploy to LOCAL DOCKER
(explanation Dockerfile: https://www.softwaredeveloper.blog/multi-project-dotnet-core-solution-in-docker-image)
Related files: .dockerignore and dockerfile.

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
As this is a webproject with references to other projects, do the build adding as a parameter
the dockerfile of the webproject to run.
docker build -t myimage -f WebSortAlgorithms/Dockerfile .

- See the installed images: (see that "myimage" is listed)
docker images

-Run the image:
docker run -it -p 8080:80 --name WebSortAlgorithms myimage
-it : interactive
-d, this simply means we run the container in the background.
-p that means we will match an external port to an internal container port. 

- Open the application in web browser,
http://192.168.99.100:8080/
as you are running the web application in itmode (interactive) use the ip of the docker container
NOT THE LOCAL IP.

- stop the container:
docker stop [Name]

- Delete the container:
docker rm [Name]

** Other way to run container, is creating and starting it step by step:
- Create container:
docker create myimage

- list of containers:
docker ps -a

- start the container:
docker start [Name]

- run command (in previous section) 


Possible errors starting docker:
This computer doesn’t have VT-X/AMD-v enabled. Enabling it in the BIOS is mandatory.
Solution: enable Virtualization in the machine, if it does not work and you are working in windows machine
please disable Hyper-V and reastart machine: bcdedit /set hypervisorlaunchtype off
https://localbyflywheel.com/community/t/windows-help-im-getting-a-bios-error-about-vt-x-amd-v-during-installation/426



2. DEPLOY HEROKU:
https://codingblast.com/hosting-asp-net-core-on-heroku-with-dockercircleci-for-free/
Heroku does not support Net Core application you have to use "buildpacks"
Added heroku.yml file

- Create app in Heroku
- Install Heroku cli
- run command: "heroku buildpacks:set https://github.com/jincod/dotnetcore-buildpack#v3.0.100 --app [Heroku APP name]"
- On "Seetings" section inside Heroku for this app verifies taht buildpack was added in section "Buildpacks"
- Launch a manual deploy (section "Deploy")
- url: https://sort-algorithms.herokuapp.com/

3. Deploy to CircleCI
Related files: folder .circleci and config.yml