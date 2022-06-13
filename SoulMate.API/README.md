Issue #1 Enable CORS policy
	- Add cors builder to builder service in program.cs
	- Add Use CORS in program.cs before run command

Issue #2 Configure Logging with Serilog
Logging with Serilog and SeQ
    Nuget dependencies: Serilog.ASPNetCore, Serilog.Expression, Serilog.SInks.Seq
	verify dependencies in SoulMate.API.csproj
	Download and install Seq to windows: https://datalust.co/seq
	Add Serilog to builder (Program.cs)
	Add logging configuration at (appsettings.json)
	Provide port on which Seq to run (Make sure port number is same as that provided in appsettings.json)

Issue #3 Set up SQL Server and Entity Framework
Setup SQL Server
    Nuget dependencies: Microsoft.EntityFrameworkCore.SqlServer
	                    Microsoft.EntityFrameworkCore.Tools
	Set connectionstring (appsettings.json)
	Add DbContext to builder Services (Program.cs)
Create DBContext and Entities
	Create DbContext
	Create entities
Perform migration to migrate seed data into database 
Run below commands in tools>Nuget Package Manager>Package Managaer Console
	add-migration <InitialMigration>
	update-database

Issue #4 Create Scaffold Controllers and Actions	
	Perform scaffolding to create controller and action
	Test through Swagger

Issue #5 Create Automapper and DTO
Create DTO and use Auto Mapper
	Nuget: AutoMapper.Extensions.Microsoft.DependencyInjection
	Create Incomming and Outgoing DTOs
	Create MapperConfig
	Register MapperConfig to builder service (Program.cs)
	Inject Mapper in controller constructor
	Use Mapper for DTO<->Entity conversions

Issue #6 Implement Repository Pattern
	Create Generic Repository Interface and Implementation to use DbContext for CRUD
	Create entiy specific Repository Interface and implementation specific to entity
	Register as service (Program.cs)
	Update controller to use DI repository

Issue #7 Implementing logger in soulmate and contry controller
	Use logger in controller class