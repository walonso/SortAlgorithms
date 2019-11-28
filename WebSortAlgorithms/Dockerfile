# getting the image to build Net Core 3
FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build-env
# creating the new folder in docker container
WORKDIR /WebSortAlgorithms

# . means all curent files
# ./ means the current folder (WORKDIR /WebSortAlgorithms)
# .. means cd .. (back one folder)
# so, this commands means: move all current files to curret created folder.
COPY . ./
# compile and publish project.
RUN dotnet publish WebSortAlgorithms -c Release -o out

# getting the image production nt core 3. (previous image is for compile)
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0
WORKDIR /WebSortAlgorithms
# move compilation build-env (setted in first image) folder out to current folder.
COPY --from=build-env /WebSortAlgorithms/out .

# run project.
ENTRYPOINT ["dotnet", "WebSortAlgorithms.dll"]



#FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
#WORKDIR /WebSortAlgorithms

	# copy csproj and restore as distinct layers
#COPY *.sln .
#COPY ../WebSortAlgorithms/*.csproj ./WebSortAlgorithms/
#RUN dotnet restore

	# copy everything else and build app
#COPY aspnetapp/. ./aspnetapp/
#WORKDIR /app/aspnetapp
#RUN dotnet publish -c Release -o out


#FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS runtime
#WORKDIR /WebSortAlgorithms
#COPY WebSortAlgorithms/bin/Release/netcoreapp3.0/publish/ WebSortAlgorithms/
#COPY --from=build /app/aspnetapp/out ./
#ENTRYPOINT ["dotnet", "WebSortAlgorithms.dll"]