# <a id="Results_Result"></a> Class Result

Namespace: [Results](Results.md)  
Assembly: Results.dll  

Represents the result of an operation that can either succeed or fail.

```csharp
public class Result
```

#### Inheritance

[object](https://learn.microsoft.com/dotnet/api/system.object) ← 
[Result](Results.Result.md)

#### Derived

[Result<TValue\>](Results.Result\-1.md)

#### Inherited Members

[object.Equals\(object?\)](https://learn.microsoft.com/dotnet/api/system.object.equals\#system\-object\-equals\(system\-object\)), 
[object.Equals\(object?, object?\)](https://learn.microsoft.com/dotnet/api/system.object.equals\#system\-object\-equals\(system\-object\-system\-object\)), 
[object.GetHashCode\(\)](https://learn.microsoft.com/dotnet/api/system.object.gethashcode), 
[object.GetType\(\)](https://learn.microsoft.com/dotnet/api/system.object.gettype), 
[object.MemberwiseClone\(\)](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone), 
[object.ReferenceEquals\(object?, object?\)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals), 
[object.ToString\(\)](https://learn.microsoft.com/dotnet/api/system.object.tostring)

#### Extension Methods

[LogicalAndOperationResultExtensions.And\(Result, Result\)](Results.Extensions.LogicalAndOperationResultExtensions.md\#Results\_Extensions\_LogicalAndOperationResultExtensions\_And\_Results\_Result\_Results\_Result\_), 
[LogicalAndOperationResultExtensions.And<T\>\(Result, Result<T\>\)](Results.Extensions.LogicalAndOperationResultExtensions.md\#Results\_Extensions\_LogicalAndOperationResultExtensions\_And\_\_1\_Results\_Result\_Results\_Result\_\_\_0\_\_), 
[CheckResultExtensions.IsFailedAnd\(Result, Func<Error, bool\>\)](Results.Extensions.CheckResultExtensions.md\#Results\_Extensions\_CheckResultExtensions\_IsFailedAnd\_Results\_Result\_System\_Func\_Results\_ResultTypes\_Error\_System\_Boolean\_\_), 
[MapperResultExtensions.Map<T\>\(Result, Func<T\>\)](Results.Extensions.MapperResultExtensions.md\#Results\_Extensions\_MapperResultExtensions\_Map\_\_1\_Results\_Result\_System\_Func\_\_\_0\_\_), 
[MapperResultExtensions.MapError\(Result, Func<Error, Error\>\)](Results.Extensions.MapperResultExtensions.md\#Results\_Extensions\_MapperResultExtensions\_MapError\_Results\_Result\_System\_Func\_Results\_ResultTypes\_Error\_Results\_ResultTypes\_Error\_\_), 
[LogicalOrOperationExtensions.Or\(Result, Result\)](Results.Extensions.LogicalOrOperationExtensions.md\#Results\_Extensions\_LogicalOrOperationExtensions\_Or\_Results\_Result\_Results\_Result\_)

## Constructors

### <a id="Results_Result__ctor_Results_ResultTypes_ResultType_"></a> Result\(ResultType\)

Create a new instance of <xref href="Results.Result" data-throw-if-not-resolved="false"></xref>.

```csharp
public Result(ResultType result)
```

#### Parameters

`result` [ResultType](Results.ResultTypes.ResultType.md)

## Fields

### <a id="Results_Result_result"></a> result

```csharp
protected readonly ResultType result
```

#### Field Value

 [ResultType](Results.ResultTypes.ResultType.md)

## Properties

### <a id="Results_Result_Errors"></a> Errors

Retrieves the errors of the operation if it was failure; otherwise, throws an exception.

```csharp
public object[] Errors { get; }
```

#### Property Value

 [object](https://learn.microsoft.com/dotnet/api/system.object)\[\]

#### Exceptions

 [InvalidOperationException](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception)

Thrown when the operation could be completed successfully. Result object contains only data; Expected 'Errors' are
missing.

### <a id="Results_Result_IsFaulted"></a> IsFaulted

Gets a value indicating whether the result is faulted.

```csharp
public bool IsFaulted { get; }
```

#### Property Value

 [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

### <a id="Results_Result_IsSucceed"></a> IsSucceed

Gets a boolean value which represents the status of the operation.

```csharp
public bool IsSucceed { get; }
```

#### Property Value

 [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

### <a id="Results_Result_ResultType"></a> ResultType

Gets the type of the result contained in the Result object.

```csharp
public Type ResultType { get; }
```

#### Property Value

 [Type](https://learn.microsoft.com/dotnet/api/system.type)

#### Remarks

The Result object represents the result of an operation that can either succeed or fail.
This method retrieves the type of the result stored within the Result object.

### <a id="Results_Result_StatusCode"></a> StatusCode

Gets or sets the status code.

```csharp
public int? StatusCode { get; set; }
```

#### Property Value

 [int](https://learn.microsoft.com/dotnet/api/system.int32)?

#### Remarks

This status code is versatile, having applicability as both an internal status marker within the application, or
externally as an HTTP status code when interacting over HTTP protocols.

## Methods

### <a id="Results_Result_Error"></a> Error\(\)

Retrieves the error of the operation if it was unsuccessful; otherwise, null.

```csharp
public Error? Error()
```

#### Returns

 [Error](Results.ResultTypes.Error.md)?

An instance of <xref href="Results.Result.Error" data-throw-if-not-resolved="false"></xref> representing the error of an unsuccessful operation; otherwise, null.

### <a id="Results_Result_GetErrorsOr_System_Object___"></a> GetErrorsOr\(params object\[\]\)

Retrieves the error of the operation if it was failure; otherwise, returns the provided default value.

```csharp
public object[] GetErrorsOr(params object[] defaultValue)
```

#### Parameters

`defaultValue` [object](https://learn.microsoft.com/dotnet/api/system.object)\[\]

The default value to return if the Result is a success.

#### Returns

 [object](https://learn.microsoft.com/dotnet/api/system.object)\[\]

An array of objects representing the error data if the Result is a failure; otherwise, the provided default value.

### <a id="Results_Result_GetErrorsOrDefault"></a> GetErrorsOrDefault\(\)

Retrieves the error of the operation if it was failure; otherwise, returns the default value.

```csharp
public object[]? GetErrorsOrDefault()
```

#### Returns

 [object](https://learn.microsoft.com/dotnet/api/system.object)\[\]?

An array of objects representing the error data if the Result is a failure; otherwise, the default value.

### <a id="Results_Result_InspectError_System_Action_Results_ResultTypes_Error__"></a> InspectError\(Action<Error\>\)

Executes the specified action on the error contained in a failure result.

```csharp
public Result InspectError(Action<Error> action)
```

#### Parameters

`action` [Action](https://learn.microsoft.com/dotnet/api/system.action\-1)<[Error](Results.ResultTypes.Error.md)\>

The action to perform with the Error object.

#### Returns

 [Result](Results.Result.md)

The current instance of the <xref href="Results.Result%601" data-throw-if-not-resolved="false"></xref> object.

### <a id="Results_Result_Match__1_System_Func___0__System_Func_Results_ResultTypes_Error___0__"></a> Match<TReturn\>\(Func<TReturn\>, Func<Error, TReturn\>\)

Matches the result of an operation using success and error functions.

```csharp
public TReturn Match<TReturn>(Func<TReturn> success, Func<Error, TReturn> fail)
```

#### Parameters

`success` [Func](https://learn.microsoft.com/dotnet/api/system.func\-1)<TReturn\>

The function to invoke if the operation succeeds.

`fail` [Func](https://learn.microsoft.com/dotnet/api/system.func\-2)<[Error](Results.ResultTypes.Error.md), TReturn\>

The function to invoke if the operation fails.

#### Returns

 TReturn

The result of the matched operation.

#### Type Parameters

`TReturn` 

The type of the matched result.

### <a id="Results_Result_OnFail__1_System_Func_Results_ResultTypes_Error___0__"></a> OnFail<TReturn\>\(Func<Error, TReturn\>\)

Executes the specified function if the result represents a failure.

```csharp
public TReturn? OnFail<TReturn>(Func<Error, TReturn> function)
```

#### Parameters

`function` [Func](https://learn.microsoft.com/dotnet/api/system.func\-2)<[Error](Results.ResultTypes.Error.md), TReturn\>

The function to execute.

#### Returns

 TReturn?

The result of the function if the result represents a failure; otherwise, the default value of TReturn.

#### Type Parameters

`TReturn` 

The type of the return value.

### <a id="Results_Result_OnSuccess__1_System_Func___0__"></a> OnSuccess<TReturn\>\(Func<TReturn\>\)

Executes the specified function if the operation was successful.

```csharp
public TReturn? OnSuccess<TReturn>(Func<TReturn> function)
```

#### Parameters

`function` [Func](https://learn.microsoft.com/dotnet/api/system.func\-1)<TReturn\>

The function to execute.

#### Returns

 TReturn?

The result of the function execution if the operation was successful, or <a href="https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/default">default</a> if the
operation failed.

#### Type Parameters

`TReturn` 

The return type of the function.

### <a id="Results_Result_ToString"></a> ToString\(\)

Returns a string that represents the current object.

```csharp
public override string ToString()
```

#### Returns

 [string](https://learn.microsoft.com/dotnet/api/system.string)

A string that represents the current object.

## Operators

### <a id="Results_Result_op_Implicit_Results_ResultTypes_Ok__Results_Result"></a> implicit operator Result\(Ok\)

```csharp
public static implicit operator Result(Ok ok)
```

#### Parameters

`ok` [Ok](Results.ResultTypes.Ok.md)

#### Returns

 [Result](Results.Result.md)

### <a id="Results_Result_op_Implicit_Results_ResultTypes_Error__Results_Result"></a> implicit operator Result\(Error\)

```csharp
public static implicit operator Result(Error error)
```

#### Parameters

`error` [Error](Results.ResultTypes.Error.md)

#### Returns

 [Result](Results.Result.md)

