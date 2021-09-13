dotnet tool restore
dotnet clean ./lab.api
dotnet clean ./lab.api.tests
dotnet build ./lab.api
dotnet build ./lab.api.tests
dotnet test /p:AltCover=true ./lab.api.tests
dotnet reportgenerator "-reports:./lab.api.tests/coverage.xml" "-targetdir:coveragereport" -reporttypes:Html -assemblyfilters:"-*!;+lab.api;" -classfilters:"-System.*;-Microsoft.*;"