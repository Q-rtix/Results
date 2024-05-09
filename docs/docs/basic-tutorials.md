# Basic Usage Example

```csharp
// Basic usage example of creating and handling a Result object
using Qrtix.Results;
using static Qrtix.Results.ResultFactory;

public class BasicUsageExample
{
    public Result<int> Divide(int numerator, int denominator)
    {
        if (denominator == 0)
            return Error<int>("Division by zero error");

        return Ok(numerator / denominator);
    }

    public void Run()
    {
        Result<int> result = Divide(10, 5);

        if (result.IsSucceed)
        {
            Console.WriteLine($"Result -> {result}"); // Output: Result -> Ok: 2
        }
        else
        {
            Console.WriteLine("Result -> {result}"); // Output: Result -> Error: Division by zero error
        }
    }
}
```