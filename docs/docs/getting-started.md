# Getting Started

Welcome to **Qrtix.Results**! This section will guide you through the process of getting started with **Qrtix.Results** in your
.NET projects. Follow these steps to install the library, set up your development environment, and start using
**Qrtix.Results** to handle operation results effectively.

## Installation

To install **Qrtix.Results**, you can use NuGet Package Manager in Visual Studio or the .NET CLI.

### NuGet Package Manager

1. Open your project in Visual Studio.
2. Right-click on your project in Solution Explorer.
3. Select "Manage NuGet Packages..."
4. Search for "Qrtix.Results" in the NuGet Package Manager.
5. Click on "Install" to add the package to your project.

### .NET CLI

You can also install **Qrtix.Results** using the .NET CLI:

```sh
dotnet add package Qrtix.Results
```

## Setting Up

Once you've installed the **Qrtix.Results** package, you're ready to start using it in your project. Make sure to include
the necessary `using` directives in your code files to access the **Qrtix.Results** classes and extension methods:

```csharp
using Results;
using Results.Extensions;
using static Results.ResultFactory;
```

## Basic Usage

**Qrtix.Results** provides classes and extension methods for handling operation results in your code. Here's a simple
example to demonstrate how to use **Qrtix.Results**:

```csharp
using System;

class Program
{
    static void Main()
    {
        // Perform an operation that can either succeed or fail
        Result<int> result = SomeOperation();

        // Check if the operation was successful
        if (result.IsSucceed)
        {
            // Operation was successful, retrieve the value
            int value = result.Value;
            Console.WriteLine($"Operation succeeded! Value: {value}");
        }
        else
        {
            // Operation failed, handle the error
            Error error = result.Error()!;
            Console.WriteLine($"Operation failed! Error: {error.Message}");
        }
    }

    static Result<int> SomeOperation()
    {
        // Simulate a successful operation
        return Ok(42);
    }
}
```

This is just a basic example to get you started. Explore the rest of the documentation to learn more about **Qrtix.Results**
features, advanced usage, and best practices.

## Next Steps

Now that you've set up **Qrtix.Results** in your project and learned the basics, it's time to explore more advanced topics
such as error handling strategies, logical operations, and extending the functionality of **Qrtix.Results**. Check out the "
Core Concepts" and "Advanced Usage" sections for more in-depth information.

Happy coding with **Qrtix.Results**!