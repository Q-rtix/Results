# Advanced Usage Tutorial

In this tutorial, we'll explore advanced usage scenarios of the Qrtix.Results library, including error handling
strategies and composition of Result objects.

## Error Handling Strategies

- Introduce the concept of mapping errors using MapError and MapError<T> methods.
- Provide examples demonstrating how to transform and handle errors effectively.

```csharp
// Advanced Usage Tutorial: Error Handling Strategies

using Qrtix.Results;
using Qrtix.Results.ResultTypes;

public class AdvancedUsageTutorial
{
    // Step 1: Error Handling Strategies

    // Method to simulate a database query that might fail
    public Result<string> GetUserById(int userId)
    {
        // Simulate a database error
        if (userId <= 0)
        {
            return new Error("Invalid user ID");
        }

        // Simulate a successful database query
        return new Ok<string>("John Doe");
    }

    public void Run()
    {
        // Example 1: Handling error using MapError method
        var result1 = GetUserById(0).MapError(error => new Error("User not found"));

        // Example 2: Handling error using MapError<T> method
        var result2 = GetUserById(0).MapError<Error>(error => new Error("User not found"));

        // Example 3: Handling error with default value using MapOr method
        var result3 = GetUserById(0).MapOr(user => user.ToUpper(), "Unknown User");

        // Example 4: Handling error with function using MapOrElse method
        var result4 = GetUserById(0).MapOrElse(user => user.ToUpper(), error => "Unknown User");

        // Displaying results
        Console.WriteLine("Example 1: " + result1);
        Console.WriteLine("Example 2: " + result2);
        Console.WriteLine("Example 3: " + result3);
        Console.WriteLine("Example 4: " + result4);
    }
}
```

In this example, we demonstrate various error handling strategies provided by the Qrtix.Results library:

1. **Using `MapError` Method:** Maps the error to a new error message.
2. **Using `MapError<T>` Method:** Maps the error to a new error object of type `T`.
3. **Using `MapOr` Method:** Maps the value if successful or returns a default value if there is an error.
4. **Using `MapOrElse` Method:** Maps the value if successful or returns a value based on the error if there is an
   error.

## Result Composition

- Explore how to compose Result objects using logical AND (And) and logical OR (Or) operations.
- Demonstrate how to flatten nested Result objects and handle complex error scenarios.

```csharp
// Advanced Usage Tutorial: Step 2 - Logical Operations

using Qrtix.Results;
using Qrtix.Results.ResultTypes;

public class AdvancedUsageTutorialStep2
{
    // Step 2: Logical Operations

    // Method to simulate a database query that might fail
    public Result<string> GetUserById(int userId)
    {
        // Simulate a database error
        if (userId <= 0)
        {
            return new Error("Invalid user ID");
        }

        // Simulate a successful database query
        return new Ok<string>("John Doe");
    }

    // Method to simulate checking user permissions
    public Result<bool> CheckUserPermission(string username)
    {
        // Simulate a permission check error
        if (string.IsNullOrEmpty(username))
        {
            return new Error("Invalid username");
        }

        // Simulate a successful permission check
        return new Ok<bool>(true);
    }

    public void Run()
    {
        // Example 1: Logical AND operation with two successful results
        var result1 = GetUserById(1).And(CheckUserPermission("John Doe"));

        // Example 2: Logical AND operation with a failed and a successful result
        var result2 = GetUserById(0).And(CheckUserPermission("John Doe"));

        // Example 3: Logical OR operation with two successful results
        var result3 = GetUserById(1).Or(CheckUserPermission("John Doe"));

        // Example 4: Logical OR operation with a failed and a successful result
        var result4 = GetUserById(0).Or(CheckUserPermission("John Doe"));

        // Displaying results
        Console.WriteLine("Example 1: " + result1);
        Console.WriteLine("Example 2: " + result2);
        Console.WriteLine("Example 3: " + result3);
        Console.WriteLine("Example 4: " + result4);
    }
}
```

In this example, we demonstrate the usage of logical AND and OR operations with Qrtix.Results:

1. **Logical AND Operation:** Combines two results, returning a success if both are successful, or an error if any of them fails.
2. **Logical OR Operation:** Combines two results, returning a success if any of them is successful, or an error if both fail.