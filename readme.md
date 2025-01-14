# domaincrafters domain 🏛️

![License](https://img.shields.io/badge/license-MIT-blue.svg)

![workflow](https://github.com/domaincrafters/ddd_dotnet_domain/actions/workflows/release.yml/badge.svg)
![GitHub Release](https://img.shields.io/github/v/release/domaincrafters/ddd_dotnet_domain)
[![NuGet](https://img.shields.io/nuget/v/Domaincrafters.Domain
)](https://img.shields.io/nuget/v/Domaincrafters.Domain
)

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=domaincrafters.dotnet.domain&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=domaincrafters.dotnet.domain)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=domaincrafters.dotnet.domain&metric=coverage)](https://sonarcloud.io/summary/new_code?id=domaincrafters.dotnet.domain)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=domaincrafters.dotnet.domain&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=domaincrafters.dotnet.domain)

Domaincrafters/domain is a package designed to simplify the development of **educational** Domain-Driven Design (DDD) projects in .NET using C#. It provides essential domain constructs that embody DDD principles, including Entities, Repositories, and UUID-based Entity Identifiers. 🏗️

## Changelog

See the [CHANGELOG](CHANGELOG.md) for detailed information about changes in each version.

## Features ✨

- **Entity**: An abstract base class representing domain entities with identity and equality methods.
- **Repository Interface**: A generic interface defining standard operations for managing entities.
- **UUIDEntityId**: An abstract class for UUID-based entity identifiers, ensuring unique and consistent IDs.
- **EntityId**: An interface for entity identifiers, providing a common contract for entity ID types.

## Installation 📦

In your .NET project, install the package from NuGet:
```powershell
dotnet add package Domaincrafters.Domain
```

Then, in your C# file:
```csharp
using System;
using DomainCrafters.Domain;

// Example EntityId using a UUID
public class MyEntityId : UUIDEntityId
{
    public MyEntityId(Guid value) : base(value) {}
}

// Example Entity
public class MyEntity : Entity<MyEntityId>
{
    public string Name { get; private set; }
    
    public MyEntity(MyEntityId id, string name) : base(id)
    {
        Name = name;
    }
}

// Example Repository Interface
public interface IMyEntityRepository : IRepository<MyEntity, MyEntityId>
{
    // Add your domain-specific methods here
}

```

## Contributing 🤝

Contributions are welcome! Please follow these steps:

1. Fork the repository.
2. Create a new branch: `git checkout -b feature/YourFeature`.
3. Commit your changes: `git commit -m 'feat: Add new feature'`.
4. Push to the branch: `git push origin feature/YourFeature`.
5. Open a pull request.

Please ensure your code adheres to the project's coding standards and includes relevant tests. 🧪

## Semantic Versioning with Conventional Commits 🔄

This project follows semantic versioning. To simplify the release process, we use conventional commits. Please ensure your commit messages follow the [conventional commit format](https://www.conventionalcommits.org/en/v1.0.0/).

## License 📝

This project is licensed under the [MIT License](LICENSE).

Happy coding with domaincrafters domain! 🚀✨

---

**Emoticon Guide:**

- **🚀**: Represents the project's forward-thinking and dynamic nature.
- **🏗️**: Indicates the building blocks provided by the package.
- **✨**: Highlights features and important sections.
- **📦**: Symbolizes installation or packaging.
- **🔑**: Relates to UUID functionality.
- **🏛️**: Denotes domain entities and DDD concepts.
- **🗄️**: Represents the Repository interface and data management.
- **🤝**: Signifies collaboration and contributions.
- **🧪**: Relates to testing and quality assurance.
- **📝**: Pertains to licensing information.

Feel free to adjust or add more emojis to better suit your project's personality and documentation style!