# Integration with ASP.NET Core

In this tutorial, we'll explore how to integrate the **Qrtix.Results** library with **ASP.NET Core** web applications to handle controller actions and return results.

## Step 1: Creating a BaseController

Implement a custom base controller that handles Result objects and standardizes error responses.

```csharp
using Microsoft.AspNetCore.Mvc;
using Qrtix.Results;
using System;

public class BaseController : ControllerBase
{
    protected IActionResult HandleResult<TValue>(Result<TValue> result)
    {
        return result.Match(
            success: value => Ok(value),
            fail: error =>
            {
                // Handle error response
                return error switch
                {
                    Error e => StatusCode(500, e.Message),
                    _ => throw new InvalidOperationException("Unexpected error type"),
                };
            });
    }
}
```

## Step 2: Handling Controller Actions

Demonstrate how to use Result objects in controller actions to represent operation outcomes.

```csharp
[Route("api/[controller]")]
[ApiController]
public class UserController : BaseController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        var result = _userService.GetUserById(id);
        return HandleResult(result);
    }

    [HttpPost]
    public IActionResult CreateUser(User user)
    {
        var result = _userService.CreateUser(user);
        return HandleResult(result);
    }
}
```

## Step 3: Error Handling Middleware

Implement middleware to intercept errors and convert them into appropriate Result objects.

```csharp
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Qrtix.Results;
using System;
using static Qrtix.Results.ResultFactory;

public static class ErrorHandlingMiddlewareExtensions
{
    public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(builder =>
        {
            builder.Run(async context =>
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";

                var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (errorFeature != null)
                {
                    var error = errorFeature.Error;
                    var result = error switch
                    {
                        BusinessException e => Error(e.Message),
                        _ => Error("An unexpected error occurred"),
                    };

                    await context.Response.WriteAsync(result.ToString());
                }
            });
        });
    }
}
```