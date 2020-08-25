build:
	dotnet build
clean:
	dotnet clean
restore:
	dotnet restore
watch:
	dotnet watch --project console/console.csproj run -- ~/git/parsecsv/console.tests/valid.csv
	#dotnet watch --project console/console.csproj run -- ~/git/parsecsv/console.tests/invalid_fewer.csv
start:
	dotnet run --project console/console.csproj
test:
	dotnet test console.tests/console.tests.csproj