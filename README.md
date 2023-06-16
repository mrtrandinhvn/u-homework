# Umbraco Homework

## Setup local dev environment
- dotnet 7.0.x.
- sql server 2019.
- `./Website` folder contains the code of the main website.
- Go to `./Website/appsettings.json` and update `ConnectionStrings > DefaultConnection` to point to your empty sql server database.
- Execute `./setup/0. initialization.sql` file in that database.
- You can find 100 valid serial numbers to use in `./setup/1. valid serial numbers.txt`.
- Build and run `./Website/Website.csproj` .project using `https` profile using visual studio or open a command line in the current folder and run this command: `dotnet run --project=./Website/Website.csproj --launch-profile=https`. The website should start up at `https://localhost:7246`. You may need to accept dotnet self-signed certificate or some warnings relate to https connection. Just ignore them for now.

Use this account to login and read the form submissions.
- Admin username: `admin@contoso.com`
- Admin password: `123456qQ@`

# Project structure
This project use Clean Code Architecture.
## Domain project
This project contains primitive classes of your application. The core will be your domain entities.

## Application project
This project contains all of your application logic. It depends only on Domain project. It defines all of it dependencies as interfaces. The actual implementation of those interfaces will be defined in outside projects. For example, when you want to get data from a sql database, your will define an interface to do that in this application. That interface's implementation will be defined in `Infrastructure` project.

## Infrastructure project
This project contains actual implementation of `Application` interfaces and other external dependencies like database access, caching, etc.

## Website project
This is the presentation layer. This project will be the one we use to communicate with client/user.
