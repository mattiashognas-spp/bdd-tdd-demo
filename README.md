# bdd-tdd-demo

BDD + TDD demo code

## Branches
- demo-started    Demo ready
- demo-complete   Demo finished
- master          Demo finished

## Procedure
- dotnet tool restore
- dotnet clean ./lab.api
- dotnet clean ./lab.api.tests
- dotnet build ./lab.api
- dotnet build ./lab.api.tests
- dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=lcov /p:CoverletOutput=../lcov.info ./lab.api.tests
- dotnet reportgenerator "-reports:./lcov.info" "-targetdir:coveragereport" -reporttypes:Html