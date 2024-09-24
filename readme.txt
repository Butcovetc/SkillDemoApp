Hello, 

>>>Getting started

Application is complete and fully functional

1) pls clone development branch using git
2) Open project using visual studio 2022
3) Configure User Secrets and connection string in it. (Check sample below)
4) Run and use

>>>>User secrets sample:
>For a DemoApp.API project:

{
  "ConnectionStrings": {
    "DemoAppDbConnectionString": "Server=tcp:(local)\\SQLEXPRESS;Initial Catalog=demoAppDb;INTEGRATED SECURITY=SSPI;Connection Timeout=300;TrustServerCertificate=True;Encrypt=False;"
  },

  "UserPassWordEncryptionSalt": "Ww+mu?6^nv7$'P(4S9tQJ<-V*f2Ha8;}q.AZ&j,kpY[szc:~X,"
}


>For a DemoApp.ConsoleUI

{
  "AppServerURI": "https://localhost:7023"
}


>>>Project's description 

DemoApp.API - Rest API project.
DemoApp.ConsoleUI - Client console application 

Those two project should be started together by (multiple startup) (pls check solution properties)

DemoApp.Model - contains application logic
DemoApp.MSTests - contains test's over a model

Application used MSSQL server
