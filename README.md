# AppointMateApi

The project was generated using the [Clean.Architecture.Solution.Template](https://github.com/jasontaylordev/AppointMateApi) version 8.0.0.

## Getting Started

This section includes the steps required to run and develop your project on your local machine.

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)

### Installation

1. Clone the project to your local machine.
   
```bash
git clone https://github.com/yourusername/AppointMateApi.git
cd AppointMateApi
```

## Build

Run `dotnet build -tl` to build the solution.

## Run

To run the web application:

```bash
cd .\src\Web\
dotnet watch run
```

Navigate to https://localhost:5001. The application will automatically reload if you change any of the source files.

Project Layers
1. Domain
The domain layer contains core entities and value objects.

2. Application
The application layer houses business logic, application services, and command/query handlers.

3. Infrastructure
The infrastructure layer includes database connections, identity management, and other external service integrations.

4. Web
The web layer provides API endpoints and user interfaces.

## Code Styles & Formatting

The template includes [EditorConfig](https://editorconfig.org/) support to help maintain consistent coding styles for multiple developers working on the same project across various editors and IDEs. The **.editorconfig** file defines the coding styles applicable to this solution.

## Code Scaffolding

The template includes support to scaffold new commands and queries.

Start in the `.\src\Application\` folder.

Create a new command:

```
dotnet new ca-usecase --name CreateTodoList --feature-name TodoLists --usecase-type command --return-type int
```

Create a new query:

```
dotnet new ca-usecase -n GetTodos -fn TodoLists -ut query -rt TodosVm
```

If you encounter the error *"No templates or subcommands found matching: 'ca-usecase'."*, install the template and try again:

```bash
dotnet new install Clean.Architecture.Solution.Template::8.0.0
```

## Test

The solution contains unit, integration, and functional tests.

To run the tests:
```bash
dotnet test
```

## Help
To learn more about the template go to the [project website](https://github.com/JasonTaylorDev/AppointMateApi). Here you can find additional guidance, request new features, report a bug, and discuss the template with other users.
