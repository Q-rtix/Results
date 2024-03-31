# <a id="Results_Extensions_MapperSuccessfulResultValueExtensions"></a> Class MapperSuccessfulResultValueExtensions

Namespace: [Results.Extensions](Results.Extensions.md)  
Assembly: Results.dll  

Contains extension methods for the <xref href="Results.Result%601" data-throw-if-not-resolved="false"></xref> class that deal with mapping successful results.

```csharp
public static class MapperSuccessfulResultValueExtensions
```

#### Inheritance

[object](https://learn.microsoft.com/dotnet/api/system.object) ← 
[MapperSuccessfulResultValueExtensions](Results.Extensions.MapperSuccessfulResultValueExtensions.md)

#### Inherited Members

[object.Equals\(object?\)](https://learn.microsoft.com/dotnet/api/system.object.equals\#system\-object\-equals\(system\-object\)), 
[object.Equals\(object?, object?\)](https://learn.microsoft.com/dotnet/api/system.object.equals\#system\-object\-equals\(system\-object\-system\-object\)), 
[object.GetHashCode\(\)](https://learn.microsoft.com/dotnet/api/system.object.gethashcode), 
[object.GetType\(\)](https://learn.microsoft.com/dotnet/api/system.object.gettype), 
[object.MemberwiseClone\(\)](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone), 
[object.ReferenceEquals\(object?, object?\)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals), 
[object.ToString\(\)](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Methods

### <a id="Results_Extensions_MapperSuccessfulResultValueExtensions_MapOr__2_Results_Result___0__System_Func___0___1____1_"></a> MapOr<T, U\>\(Result<T\>, Func<T, U\>, U\)

Maps the successful result value to a new value using the provided mapper function, or returns a default value if the result is a failure.

```csharp
public static U MapOr<T, U>(this Result<T> self, Func<T, U> mapper, U defaultValue)
```

#### Parameters

`self` [Result](Results.Result\-1.md)<T\>

The result instance.

`mapper` [Func](https://learn.microsoft.com/dotnet/api/system.func\-2)<T, U\>

The mapper function to convert the successful result value.

`defaultValue` U

The default value to be returned if the result is a failure.

#### Returns

 U

The mapped value if the result is successful; otherwise, the default value.

#### Type Parameters

`T` 

The type of the value contained in the result.

`U` 

The type of the mapped result value.

### <a id="Results_Extensions_MapperSuccessfulResultValueExtensions_MapOrElse__2_Results_Result___0__System_Func___0___1__System_Func_Results_ResultTypes_Error___1__"></a> MapOrElse<T, U\>\(Result<T\>, Func<T, U\>, Func<Error, U\>\)

Maps the value of the result to a new value using the specified mapper function,
or returns a default value if the result is not successful.

```csharp
public static U MapOrElse<T, U>(this Result<T> self, Func<T, U> mapper, Func<Error, U> function)
```

#### Parameters

`self` [Result](Results.Result\-1.md)<T\>

The result object.

`mapper` [Func](https://learn.microsoft.com/dotnet/api/system.func\-2)<T, U\>

The function to map the value of the result.

`function` [Func](https://learn.microsoft.com/dotnet/api/system.func\-2)<[Error](Results.ResultTypes.Error.md), U\>

The function that return a value based on the error if the result is not successful.

#### Returns

 U

The mapped value if the result is successful; otherwise, the value based on the error object.

#### Type Parameters

`T` 

The type of the value contained in the result.

`U` 

The type of the mapped result value.

