**SETUP HTTPS CERTIFICATE FOR DOCKER ON UBUNTU**
---
- Navigate to the root folder
- Open the terminal
- Create https folder by running `mkdir https`
- Navigate to the created folder with `cd https`
- Create or Obtain an SSL CertificateCreate or Obtain an SSL Certificate
  - Run this command to generate a .crt and .key file:
    - `openssl req -x509 -nodes -days 365 -newkey rsa:2048 -keyout aspnetcore.key -out aspnetcore.crt -subj "/CN=localhost"`
  - To create a .pfx file, run the following command
    - `openssl pkcs12 -export -out aspnetcore.pfx -inkey aspnetcore.key -in aspnetcore.crt`
  - This will ask for a password. You can either create your own password and set it up on the .env file or use the existing password on the .env.example file on this project.
  - Note: You can delete the aspnetcore.key and aspnetcore.crt file on this folder after creating aspnetcore.pfx
- Navigate back by running `cd ..`
- Run the following command to trust the createda certificate:
  - `dotnet dev-certs https --trust`
- Run `docker compose up --build -d`
  - Note: if the docker compose build fails due to missing env file. Go to root folder of this project and change the name of env.example to .env.
 
**Database Migration with Entity Framework**
- From the root folder of this project. Navigate to apps/api/DotNetRPG.API
- Change the `Host` of the `DefaultConnection` in the appsettings.json to `localhost`
- Go to the terminal and run `dotnet ef database update`

**Note**
- When running debug mode for the application. Change the `Host` of the `DefaultConnectikon` in appsettings.json to `localhost` like in the `DefaultConnection_BAK`. You can then change it back to `rpg-db` before running `docker compose --build`. (This is the work around for now, since the certificate on this is using the one from openssl and not the dotnet dev-certs)

PS: This project is created to further enhance my knowledge in webapi development with dotnet framework and docker while using linux. This project is not going to be perfect since its just going to be use for practicing. I also want to use this project as a reference for when I encounter scenarios that are similar to what I'm currently doing. 

PPS: You are also free to use this project for practicing and/or reference. 
