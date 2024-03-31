# Basic Usage Example

```csharp
// Basic usage example of creating and handling a Result object
using Qrtix.Results;
using Qrtix.Results.ResultTypes;

public class BasicUsageExample
{
    public Result<int> Divide(int numerator, int denominator)
    {
        if (denominator == 0)
            return new Error("Division by zero error");

        return new Ok<int>(numerator / denominator);
    }

    public void Run()
    {
        Result<int> result = Divide(10, 5);

        if (result.IsSucceed)
        {
            Console.WriteLine("Result: " + result.Value);
        }
        else
        {
            Console.WriteLine("Error: " + result.Errors);
        }
    }
}
```