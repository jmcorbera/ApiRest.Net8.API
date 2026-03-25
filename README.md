# ApiRest.Net8.API

This project focuses on the implementation of a CI/CD workflow for an ASP.NET Core Web API built with .NET 8. It includes a basic WeatherForecast controller as an example application to demonstrate the CI/CD pipeline.

## CI/CD Workflow

- **CI (Continuous Integration)**: Builds and pushes the Docker image.
- **CD (Continuous Deployment)**: Uses ArgoCD for deployment.

## Configuration

In a real application, database connection strings should be obtained through secrets management systems (e.g., Kubernetes secrets, Azure Key Vault, AWS Secrets Manager) rather than being hardcoded in configuration files.