[![.NET](https://github.com/iongritco/ModularMonolithAndVerticalSlice/actions/workflows/dotnet.yml/badge.svg)](https://github.com/iongritco/ModularMonolithAndVerticalSlice/actions/workflows/dotnet.yml)

# ModularMonolith with Vertical Slice architecture
A playground for experimenting projects with a Modular Monolith with Vertical Slice Architecture - DDD, CQRS, MediatR, .NET 8, Entity Framework Core

## Setup
- To get started, just create the databases ToDo and ToDo_Tests and update the connection string in appsettings (both in ToDoApp.Server.API and in ToDoApp.Tests.EndToEnd for integration tests) - the migration will be executed automatically on the first run. 
- Set as startup the ToDoApp.Client.Blazor and ToDoApp.Server.API projects.

### Tests
#### Unit tests
- Unit tests can be executed directly from Visual Studio, no additional setup. Every module has it's own set of unit tests that can be found under Modules\[ModuleName]\Tests
#### End to end tests
- The scope of the end to end tests is to simulate an end to end flow by using WebApplicationFactory and an actual database
#### Performance tests
- There are two types of performance tests - by using k6 and nbomber
- To run stress tests with **k6**, you need first to install k6 by following [these steps](https://grafana.com/docs/k6/latest/set-up/install-k6/). After that, update the .\tests\ToDoApp.Performance.Tests\scripts.js file with the url, username and password that you want to use. Then run the application, open a cmd in the .\tests\ToDoApp.Performance.Tests folder and execute *k6 run script.js*
- To run the tests with nbomber, open the solution .\tests\ToDoApp.Performance.Tests\ToDoApp.Performance.Tests.sln, update the username and password of the user in appsettings.json. Run the application and after that run the performance tests as well. At the end, you'll get a report with all the results.
### Health checks
Server has both endpoint and UI for checking the health of dependencies, in this case SQL Server and MassTransit:
- Endpoint - default address: https://localhost:5002/api/health
- UI - default address: https://localhost:5002/healthchecks-ui

### Modules communications
There are two ways of communicating between modules:
1) Asynchronous - via MassTransit that runs locally
2) Synchronous - via Contracts projects - direct dependency on Contracts project without direct dependency on any other module component