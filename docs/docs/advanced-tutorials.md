# Advanced Usage Tutorial

In this tutorial, we'll explore advanced usage scenarios of the Qrtix.Results library, including error handling
strategies and composition of Result objects.

## Error Handling Strategies

- Introduce the concept of mapping errors using MapError<T> method.
- Provide examples demonstrating how to transform and handle errors effectively.

```csharp
// Advanced Usage Tutorial: Error Handling Strategies

using Qrtix.Results;
using Qrtix.Results.ResultTypes;
using static Qrtix.Results.ResultFactory;

public class AdvancedUsageTutorial
{
    // Step 1: Error Handling Strategies

    // Method to simulate a database query that might fail
    public Result<string> GetUserById(int userId)
    {
        // Simulate a database error
        if (userId <= 0)
        {
            return Error<string>("Invalid user ID");
        }

        // Simulate a successful database query
        return Ok("John Doe");
    }

    public void Run()
    {
        // Example 1: Handling error using MapError<T> method
        var result1 = GetUserById(0).MapError<string>(error => new Error("User not found"));

        // Example 2: Handling error with default value using MapOr method
        var result2 = GetUserById(0).MapOr(user => user.ToUpper(), "Unknown User");

        // Example 3: Handling error with function using MapOrElse method
        var result3 = GetUserById(0).MapOrElse(user => user.ToUpper(), error => "Unknown User");

        // Displaying results
        Console.WriteLine("Example 1: " + result1);
        Console.WriteLine("Example 2: " + result2);
        Console.WriteLine("Example 3: " + result3);
    }
}
```

In this example, we demonstrate various error handling strategies provided by the Qrtix.Results library:

1. **Using `MapError<T>` Method:** Maps the error to a new error object of type `T`.
2. **Using `MapOr` Method:** Maps the value if successful or returns a default value if there is an error.
3. **Using `MapOrElse` Method:** Maps the value if successful or returns a value based on the error if there is an
   error.

> All that methods have an asynchronous counterpart, `MapErrorAsync`, `MapOrAsync`, and `MapOrElseAsync`.

## Result Composition

- Explore how to compose Result objects using logical AND (And) and logical OR (Or) operations.
- Demonstrate how to flatten nested Result objects and handle complex error scenarios.

```csharp
// Advanced Usage Tutorial: Step 2 - Logical Operations

using Qrtix.Results;
using Qrtix.Results.ResultTypes;
using static Qrtix.Results.ResultFactory;

public class AdvancedUsageTutorialStep2
{
    // Step 2: Logical Operations

    // Method to simulate a database query that might fail
    public Result<string> GetUserById(int userId)
    {
        // Simulate a database error
        if (userId <= 0)
        {
            return Error<string>("Invalid user ID");
        }

        // Simulate a successful database query
        return Ok("John Doe");
    }

    // Method to simulate checking user permissions
    public Result<Empty> CheckUserPermission(string username)
    {
        // Simulate a permission check error
        if (string.IsNullOrEmpty(username))
        {
            return Error("Invalid username");
        }

        // Simulate a successful permission check
        return Ok();
    }

    public void Run()
    {
        // Example 1: Logical AND operation with two successful results
        var result1 = GetUserById(1).And(CheckUserPermission("John Doe"));

        // Example 2: Logical AND operation with a failed and a successful result
        var result2 = GetUserById(0).And(CheckUserPermission("John Doe"));

        // Displaying results
        Console.WriteLine("Example 1: " + result1);
        Console.WriteLine("Example 2: " + result2);
    }
}
```

In this example, we demonstrate the usage of logical AND and OR operations with Qrtix.Results:

1. **Logical AND Operation:** Combines two results, returning a success if both are successful, or an error if any of them fails.
2. **Logical OR Operation:** Combines two results, returning a success if any of them is successful, or an error if both fail.

## Ensure Result Value

- Explore how to ensure the value of a Result object using `Ensure` method.
- Demonstrate how to handle errors in a `Ensure` method.

```csharp
// Advanced Usage Tutorial: Step 3 - Ensure Value

using Qrtix.Results;
using Qrtix.Results.ResultTypes;
using Qrtix.Results.Extensions;
using static Qrtix.Results.ResultFactory;

public class AdvancedUsageTutorialStep3
{
    // Step 3: Ensure Value

    // Method to simulate a database query that might fail for invalid email
    public Result<Email> CreateEmail(string email)
       => Ok(email)
           .Ensure(email => !string.IsNullOrEmpty(email), "Email cannot be empty")
           .Ensure(email => email.Contains("@"), "Invalid email address")
           .Ensure(email => email.Split("@").Length == 2, "Invalid email address")
           .Ensure(email => email.EndsWith(".com"), "Invalid email address")
           .Map(email => new Email(email));

    public void Run()
    {
        // Example 1: Ensure value with successful result
        var result1 = CreateEmail("nWUeh@example.com");

        // Example 2: Ensure value with failed result
        var result2 = CreateEmail("");

        // Displaying results
        Console.WriteLine("Example 1: " + result1);
        Console.WriteLine("Example 2: " + result2);
    }
}
```

