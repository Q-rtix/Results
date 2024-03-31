# <a id="Results_Extensions_CheckResultExtensions"></a> Class CheckResultExtensions

Namespace: [Results.Extensions](Results.Extensions.md)  
Assembly: Results.dll  

Provides extension methods for the Check Result operations.

```csharp
public static class CheckResultExtensions
```

#### Inheritance

[object](https://learn.microsoft.com/dotnet/api/system.object) ← 
[CheckResultExtensions](Results.Extensions.CheckResultExtensions.md)

#### Inherited Members

[object.Equals\(object?\)](https://learn.microsoft.com/dotnet/api/system.object.equals\#system\-object\-equals\(system\-object\)), 
[object.Equals\(object?, object?\)](https://learn.microsoft.com/dotnet/api/system.object.equals\#system\-object\-equals\(system\-object\-system\-object\)), 
[object.GetHashCode\(\)](https://learn.microsoft.com/dotnet/api/system.object.gethashcode), 
[object.GetType\(\)](https://learn.microsoft.com/dotnet/api/system.object.gettype), 
[object.MemberwiseClone\(\)](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone), 
[object.ReferenceEquals\(object?, object?\)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals), 
[object.ToString\(\)](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Methods

### <a id="Results_Extensions_CheckResultExtensions_IsFailedAnd_Results_Result_System_Func_Results_ResultTypes_Error_System_Boolean__"></a> IsFailedAnd\(Result, Func<Error, bool\>\)

Checks if the result is faulted and satisfies the given condition.

```csharp
public static bool IsFailedAnd(this Result self, Func<Error, bool> function)
```

#### Parameters

`self` [Result](Results.Result.md)

The Result object.

`function` [Func](https://learn.microsoft.com/dotnet/api/system.func\-2)<[Error](Results.ResultTypes.Error.md), [bool](https://learn.microsoft.com/dotnet/api/system.boolean)\>

The function to check the error condition.

#### Returns

 [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

True if the Result object represents a failed operation and meets the specified condition; otherwise, false.

### <a id="Results_Extensions_CheckResultExtensions_IsSucceedAnd__1_Results_Result___0__System_Func___0_System_Boolean__"></a> IsSucceedAnd<TValue\>\(Result<TValue\>, Func<TValue, bool\>\)

Checks if the result is successful and satisfies the given condition.

```csharp
public static bool IsSucceedAnd<TValue>(this Result<TValue> self, Func<TValue, bool> function)
```

#### Parameters

`self` [Result](Results.Result\-1.md)<TValue\>

The result object to check.

`function` [Func](https://learn.microsoft.com/dotnet/api/system.func\-2)<TValue, [bool](https://learn.microsoft.com/dotnet/api/system.boolean)\>

The condition function to apply on the result value.

#### Returns

 [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

True if the result is successful and satisfies the condition, otherwise false.

#### Type Parameters

`TValue` 

The type of the value contained in case of successful result.

