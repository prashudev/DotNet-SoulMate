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