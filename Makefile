build:
	dotnet build
clean:
	dotnet clean
restore:
	dotnet restore
watch:
	dotnet watch --project console/console.csproj run
start:
	dotnet run --project console/console.csproj
test:
	dotnet test --project console.tests/console.tests.csproj