## FunTranslate

This repository is an approach to use principles of Clean Architecture and CQRS by implementing a custom wrapper api to use [Fun Translations API](https://funtranslations.com/) services.

### FunTranslations
Funtranslations API gives access to the full set of translations available at [funtranslations.com](https://funtranslations.com/) so that you can integrate them in your workflow or an app.

## Libraries & Technologies
- [ASP.NET Core 6](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-6.0)
- [Entity Framework Core 6](https://docs.microsoft.com/en-us/ef/core/)
- [MediatR](https://github.com/jbogard/MediatR)
- [AutoMapper](https://automapper.org/)
- [FluentValidation](https://fluentvalidation.net/)
- [xUnit](https://github.com/xunit/xunit) , [Moq](https://github.com/moq) , [Shouldly](https://github.com/shouldly/shouldly)

## Overview

### Domain

This will contain all entities, entities base classes, and shared classes related to entities.

### Application

This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers. For example, application needs to access an external service [funtranslations.com](https://funtranslations.com/) , so an interface added to application and an implementation would be created within infrastructure. It also contains all abstraction related to persistence layer ([MS SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads))

### Infrastructure

This layer contains classes for accessing external resources such as api, persistence and so on. These classes should be based on interfaces defined within the application layer.

### API
This layer is a RESTful API based on ASP.NET Core 6. This layer depends on both the Application and Infrastructure layers, however, the dependency on Infrastructure is only to support dependency injection. Therefore only *Program.cs* should reference Infrastructure.

### WebUI

This layer is a Web Application based on ASP.NET Core 6. This layer depends on API.
