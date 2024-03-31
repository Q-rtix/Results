# <a id="Results_Extensions_MapperResultExtensions"></a> Class MapperResultExtensions

Namespace: [Results.Extensions](Results.Extensions.md)  
Assembly: Results.dll  

Extension methods for mapping <xref href="Results.Result%601" data-throw-if-not-resolved="false"></xref> and <xref href="Results.Result" data-throw-if-not-resolved="false"></xref> objectes with different value.

```csharp
public static class MapperResultExtensions
```

#### Inheritance

[object](https://learn.microsoft.com/dotnet/api/system.object) ← 
[MapperResultExtensions](Results.Extensions.MapperResultExtensions.md)

#### Inherited Members

[object.Equals\(object?\)](https://learn.microsoft.com/dotnet/api/system.object.equals\#system\-object\-equals\(system\-object\)), 
[object.Equals\(object?, object?\)](https://learn.microsoft.com/dotnet/api/system.object.equals\#system\-object\-equals\(system\-object\-system\-object\)), 
[object.GetHashCode\(\)](https://learn.microsoft.com/dotnet/api/system.object.gethashcode), 
[object.GetType\(\)](https://learn.microsoft.com/dotnet/api/system.object.gettype), 
[object.MemberwiseClone\(\)](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone), 
[object.ReferenceEquals\(object?, object?\)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals), 
[object.ToString\(\)](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Methods

### <a id="Results_Extensions_MapperResultExtensions_Map__1_Results_Result_System_Func___0__"></a> Map<T\>\(Result, Func<T\>\)

Maps a <xref href="Results.Result" data-throw-if-not-resolved="false"></xref> object to a new <xref href="Results.Result%601" data-throw-if-not-resolved="false"></xref> with a value using the specified mapper function.

```csharp
public static Result<T> Map<T>(this Result self, Func<T> mapper)
```

#### Parameters

`self` [Result](Results.Result.md)

The result to map.

`mapper` [Func](https://learn.microsoft.com/dotnet/api/system.func\-1)<T\>

The mapper function to apply to the value of the result.

#### Returns

 [Result](Results.Result\-1.md)<T\>

A new <xref href="Results.Result%601" data-throw-if-not-resolved="false"></xref> object with the mapped value if the input <xref href="Results.Result" data-throw-if-not-resolved="false"></xref> is succeed;
otherwise, returns a new <xref href="Results.Result%601" data-throw-if-not-resolved="false"></xref> object with the error of the <xref href="Results.Result" data-throw-if-not-resolved="false"></xref> input object.

#### Type Parameters

`T` 

The type of the new value.

### <a id="Results_Extensions_MapperResultExtensions_Map__2_Results_Result___0__System_Func___0___1__"></a> Map<T, U\>\(Result<T\>, Func<T, U\>\)

Maps a <xref href="Results.Result%601" data-throw-if-not-resolved="false"></xref> object to a new <xref href="Results.Result%601" data-throw-if-not-resolved="false"></xref> with a different value using the specified mapper function.

```csharp
public static Result<U> Map<T, U>(this Result<T> self, Func<T, U> mapper)
```

#### Parameters

`self` [Result](Results.Result\-1.md)<T\>

The input result object.

`mapper` [Func](https://learn.microsoft.com/dotnet/api/system.func\-2)<T, U\>

The function that maps the input value to the output value.

#### Returns

 [Result](Results.Result\-1.md)<U\>

A new <xref href="Results.Result%601" data-throw-if-not-resolved="false"></xref> object with the mapped value if the input <xref href="Results.Result%601" data-throw-if-not-resolved="false"></xref> is succeed;
otherwise, returns a new <xref href="Results.Result%601" data-throw-if-not-resolved="false"></xref> object with the error of the <xref href="Results.Result%601" data-throw-if-not-resolved="false"></xref> input object.

#### Type Parameters

`T` 

The type of value contained in the input result.

`U` 

The type of value contained in the output result.

### <a id="Results_Extensions_MapperResultExtensions_MapError_Results_Result_System_Func_Results_ResultTypes_Error_Results_ResultTypes_Error__"></a> MapError\(Result, Func<Error, Error\>\)

Maps the error of a <xref href="Results.Result" data-throw-if-not-resolved="false"></xref> or a <xref href="Results.Result%601" data-throw-if-not-resolved="false"></xref> object to a new <xref href="Results.Result" data-throw-if-not-resolved="false"></xref> using the specified mapper function.

```csharp
public static Result MapError(this Result self, Func<Error, Error> mapper)
```

#### Parameters

`self` [Result](Results.Result.md)

The input result object.

`mapper` [Func](https://learn.microsoft.com/dotnet/api/system.func\-2)<[Error](Results.ResultTypes.Error.md), [Error](Results.ResultTypes.Error.md)\>

The mapper function that transforms the error.

#### Returns

 [Result](Results.Result.md)

A new <xref href="Results.Result" data-throw-if-not-resolved="false"></xref> object with the mapped error if the input <xref href="Results.Result" data-throw-if-not-resolved="false"></xref> is faulted;
otherwise, returns the <xref href="Results.Result" data-throw-if-not-resolved="false"></xref> imput object.

### <a id="Results_Extensions_MapperResultExtensions_MapError__1_Results_Result___0__System_Func_Results_ResultTypes_Error_Results_ResultTypes_Error__"></a> MapError<T\>\(Result<T\>, Func<Error, Error\>\)

Maps the error of a <xref href="Results.Result%601" data-throw-if-not-resolved="false"></xref> object to a new <xref href="Results.Result%601" data-throw-if-not-resolved="false"></xref> using the provided mapper function.

```csharp
public static Result<T> MapError<T>(this Result<T> self, Func<Error, Error> mapper)
```

#### Parameters

`self` [Result](Results.Result\-1.md)<T\>

The <xref href="Results.Result%601" data-throw-if-not-resolved="false"></xref> object.

`mapper` [Func](https://learn.microsoft.com/dotnet/api/system.func\-2)<[Error](Results.ResultTypes.Error.md), [Error](Results.ResultTypes.Error.md)\>

The mapper function that takes the current error and returns a new error.

#### Returns

 [Result](Results.Result\-1.md)<T\>

A new <xref href="Results.Result%601" data-throw-if-not-resolved="false"></xref> object with the mapped error if the input <xref href="Results.Result%601" data-throw-if-not-resolved="false"></xref> is faulted;
otherwise, returns the <xref href="Results.Result%601" data-throw-if-not-resolved="false"></xref> imput object.

#### Type Parameters

`T` 

The type of value contained in the input result.

