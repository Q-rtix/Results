# <a id="Results_Extensions_FlattenResultExtensions"></a> Class FlattenResultExtensions

Namespace: [Results.Extensions](Results.Extensions.md)  
Assembly: Results.dll  

Extensions for flattening Result objects.

```csharp
public static class FlattenResultExtensions
```

#### Inheritance

[object](https://learn.microsoft.com/dotnet/api/system.object) ← 
[FlattenResultExtensions](Results.Extensions.FlattenResultExtensions.md)

#### Inherited Members

[object.Equals\(object?\)](https://learn.microsoft.com/dotnet/api/system.object.equals\#system\-object\-equals\(system\-object\)), 
[object.Equals\(object?, object?\)](https://learn.microsoft.com/dotnet/api/system.object.equals\#system\-object\-equals\(system\-object\-system\-object\)), 
[object.GetHashCode\(\)](https://learn.microsoft.com/dotnet/api/system.object.gethashcode), 
[object.GetType\(\)](https://learn.microsoft.com/dotnet/api/system.object.gettype), 
[object.MemberwiseClone\(\)](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone), 
[object.ReferenceEquals\(object?, object?\)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals), 
[object.ToString\(\)](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Methods

### <a id="Results_Extensions_FlattenResultExtensions_Flatten_Results_Result_Results_Result__"></a> Flatten\(Result<Result\>\)

Flattens a nested result by returning the inner result if it is successful,
otherwise constructs a new error result using the errors from the outer result.

```csharp
public static Result Flatten(this Result<Result> self)
```

#### Parameters

`self` [Result](Results.Result\-1.md)<[Result](Results.Result.md)\>

The nested result to flatten.

#### Returns

 [Result](Results.Result.md)

The inner result if it is successful,
otherwise a new error result with the errors from the outer result.

### <a id="Results_Extensions_FlattenResultExtensions_Flatten__1_Results_Result_Results_Result___0___"></a> Flatten<T\>\(Result<Result<T\>\>\)

Flattens a nested result by extracting the inner result if the outer result is successful,
or creates a new error result containing the errors from the outer result.

```csharp
public static Result<T> Flatten<T>(this Result<Result<T>> self)
```

#### Parameters

`self` [Result](Results.Result\-1.md)<[Result](Results.Result\-1.md)<T\>\>

The nested result to flatten.

#### Returns

 [Result](Results.Result\-1.md)<T\>

The inner result if the outer result is successful,
or a new error result containing the errors from the outer result.

#### Type Parameters

`T` 

The type of value contained in the inner result.

