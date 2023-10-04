# <center>Quizz</center>

## **Introduction** ⚙️

This repository contains a sample of a full-stack real-world Quiz Application.
It's split in different folders:

- **.github:** contains CI-CD scripts for Github Actions
- **scripts:** contains scripts to startup/cleanup the dev environment and all required resources
- **docker:** contains docker-compose and docker files to start required containers (mongodb, frontend app, backend service)
- **app:** contains the application/frontend assets (built with html, css and vanilla js)
- **backend:** contains the backend service (built with .NET 7)

<br>

## **Dev Environment** 👨‍💻

- WSL-2
- Ubuntu 22.04
- Docker
- Visual Studio Code
- Visual Studio Code Extensions (Docker, MongoDB, C#, IntelliCode, ThunderClient)

## **Run Application** 🚀

### **System Requirements:**

- [Docker](https://docs.docker.com/)
- [Docker Compose](https://docs.docker.com/)
- Make sure you can run `.sh` scripts

### **Startup:**

1. `git clone https://github.com/leopoldev404/quizz.git`
2. `cd quizz`
3. `bash ./scripts/setup.sh` (pull required docker images, build applications, create docker containers and volumes)
4. Open your browser on `localhost:4000`
5. `bash ./scripts/cleanup.sh` (remove docker containers and volumes)

<br>

## **Test Application** 🧪

### **Disclaimer**

_NB. In order to run Unit and Integration Tests you need to install .NET 7 and run dotnet-cli command utilities._

_Also no Unit or Integration test has been done for the frontend application_

1. `git clone https://github.com/leopoldev404/quizz.git`
2. `cd quizz/backend/tests`
3. `dotnet test`

<br>

## **Features** 💥

- Project structure following [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html) principles
- Developed following [Best Practices](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/best-practices?view=aspnetcore-7.0)
- Based on .NET 7
- TDD: Test Driven Development
- [IDistributedCache](https://learn.microsoft.com/en-us/aspnet/core/performance/caching/distributed?view=aspnetcore-7.0) caching implementation
- [Serilog](https://github.com/serilog/serilog)
- [Repository Pattern]()
- [FluentAssertions](https://fluentassertions.com/)
- [CQRS](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs)
- [Mediator Pattern](https://en.wikipedia.org/wiki/Mediator_pattern) using [MediatR package](https://github.com/jbogard/MediatR)
- [Pipeline Behaviors]() for Logging, Caching and Validation
- Unit and Integration Testing with [xUnit](https://xunit.net/), [Testcontainers](https://dotnet.testcontainers.org/) and [FluentAssertions](https://fluentassertions.com/)
- [Docker](https://docs.docker.com/)
- [Docker Compose](https://docs.docker.com/)
- [MongoDB](https://www.mongodb.com/it-it?utm_source=google&utm_campaign=search_gs_pl_evergreen_atlas_core_prosp-brand_gic-null_emea-it_ps-all_desktop_it_lead&utm_term=mongodb&utm_medium=cpc_paid_search&utm_ad=e&utm_ad_campaign_id=20378068754&adgroup=154980289881&cq_cmp=20378068754&gad=1&gclid=EAIaIQobChMI183GxdHXgQMV8oVoCR0pCAM3EAAYASAAEgLRPPD_BwE) as Database
- [MongoDB Driver package](https://www.mongodb.com/docs/drivers/) for database connection and operations

## **Missing** 🤔❓

- Authentication/Authorization for users
- CI-CD for Deployment
- More accurate unit tests
- More testing using TestContainers package
- Pagination using mongodb cursor
