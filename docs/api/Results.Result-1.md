# <a id="Results_Result_1"></a> Class Result<TValue\>

Namespace: [Results](Results.md)  
Assembly: Results.dll  

Represents the result of an operation that can either succeed or fail.

```csharp
public class Result<TValue> : Result
```

#### Type Parameters

`TValue` 

The type of the value contained in a successful result.

#### Inheritance

[object](https://learn.microsoft.com/dotnet/api/system.object) ← 
[Result](Results.Result.md) ← 
[Result<TValue\>](Results.Result\-1.md)

#### Inherited Members

[Result.result](Results.Result.md\#Results\_Result\_result), 
[Result.StatusCode](Results.Result.md\#Results\_Result\_StatusCode), 
[Result.IsSucceed](Results.Result.md\#Results\_Result\_IsSucceed), 
[Result.IsFaulted](Results.Result.md\#Results\_Result\_IsFaulted), 
[Result.Errors](Results.Result.md\#Results\_Result\_Errors), 
[Result.ResultType](Results.Result.md\#Results\_Result\_ResultType), 
[Result.Error\(\)](Results.Result.md\#Results\_Result\_Error), 
[Result.GetErrorsOrDefault\(\)](Results.Result.md\#Results\_Result\_GetErrorsOrDefault), 
[Result.GetErrorsOr\(params object\[\]\)](Results.Result.md\#Results\_Result\_GetErrorsOr\_System\_Object\_\_\_), 
[Result.Match<TReturn\>\(Func<TReturn\>, Func<Error, TReturn\>\)](Results.Result.md\#Results\_Result\_Match\_\_1\_System\_Func\_\_\_0\_\_System\_Func\_Results\_ResultTypes\_Error\_\_\_0\_\_), 
[Result.OnFail<TReturn\>\(Func<Error, TReturn\>\)](Results.Result.md\#Results\_Result\_OnFail\_\_1\_System\_Func\_Results\_ResultTypes\_Error\_\_\_0\_\_), 
[Result.OnSuccess<TReturn\>\(Func<TReturn\>\)](Results.Result.md\#Results\_Result\_OnSuccess\_\_1\_System\_Func\_\_\_0\_\_), 
[Result.InspectError\(Action<Error\>\)](Results.Result.md\#Results\_Result\_InspectError\_System\_Action\_Results\_ResultTypes\_Error\_\_), 
[Result.ToString\(\)](Results.Result.md\#Results\_Result\_ToString), 
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
[CheckResultExtensions.IsSucceedAnd<TValue\>\(Result<TValue\>, Func<TValue, bool\>\)](Results.Extensions.CheckResultExtensions.md\#Results\_Extensions\_CheckResultExtensions\_IsSucceedAnd\_\_1\_Results\_Result\_\_\_0\_\_System\_Func\_\_\_0\_System\_Boolean\_\_), 
[MapperResultExtensions.Map<T\>\(Result, Func<T\>\)](Results.Extensions.MapperResultExtensions.md\#Results\_Extensions\_MapperResultExtensions\_Map\_\_1\_Results\_Result\_System\_Func\_\_\_0\_\_), 
[MapperResultExtensions.Map<TValue, U\>\(Result<TValue\>, Func<TValue, U\>\)](Results.Extensions.MapperResultExtensions.md\#Results\_Extensions\_MapperResultExtensions\_Map\_\_2\_Results\_Result\_\_\_0\_\_System\_Func\_\_\_0\_\_\_1\_\_), 
[MapperResultExtensions.MapError\(Result, Func<Error, Error\>\)](Results.Extensions.MapperResultExtensions.md\#Results\_Extensions\_MapperResultExtensions\_MapError\_Results\_Result\_System\_Func\_Results\_ResultTypes\_Error\_Results\_ResultTypes\_Error\_\_), 
[MapperResultExtensions.MapError<TValue\>\(Result<TValue\>, Func<Error, Error\>\)](Results.Extensions.MapperResultExtensions.md\#Results\_Extensions\_MapperResultExtensions\_MapError\_\_1\_Results\_Result\_\_\_0\_\_System\_Func\_Results\_ResultTypes\_Error\_Results\_ResultTypes\_Error\_\_), 
[MapperSuccessfulResultValueExtensions.MapOr<TValue, U\>\(Result<TValue\>, Func<TValue, U\>, U\)](Results.Extensions.MapperSuccessfulResultValueExtensions.md\#Results\_Extensions\_MapperSuccessfulResultValueExtensions\_MapOr\_\_2\_Results\_Result\_\_\_0\_\_System\_Func\_\_\_0\_\_\_1\_\_\_\_1\_), 
[MapperSuccessfulResultValueExtensions.MapOrElse<TValue, U\>\(Result<TValue\>, Func<TValue, U\>, Func<Error, U\>\)](Results.Extensions.MapperSuccessfulResultValueExtensions.md\#Results\_Extensions\_MapperSuccessfulResultValueExtensions\_MapOrElse\_\_2\_Results\_Result\_\_\_0\_\_System\_Func\_\_\_0\_\_\_1\_\_System\_Func\_Results\_ResultTypes\_Error\_\_\_1\_\_), 
[LogicalOrOperationExtensions.Or\(Result, Result\)](Results.Extensions.LogicalOrOperationExtensions.md\#Results\_Extensions\_LogicalOrOperationExtensions\_Or\_Results\_Result\_Results\_Result\_), 
[LogicalOrOperationExtensions.Or<TValue\>\(Result<TValue\>, Result<TValue\>\)](Results.Extensions.LogicalOrOperationExtensions.md\#Results\_Extensions\_LogicalOrOperationExtensions\_Or\_\_1\_Results\_Result\_\_\_0\_\_Results\_Result\_\_\_0\_\_)

## Constructors

### <a id="Results_Result_1__ctor_Results_ResultTypes_ResultType_"></a> Result\(ResultType\)

Represents the result of an operation that can either succeed or fail.

```csharp
public Result(ResultType result)
```

#### Parameters

`result` [ResultType](Results.ResultTypes.ResultType.md)

## Properties

### <a id="Results_Result_1_Value"></a> Value

Retrieves the value contained in a successful result if the operation was successful, or throws an exception.

```csharp
public TValue Value { get; }
```

#### Property Value

 TValue

#### Exceptions

 [InvalidOperationException](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception)

Thrown when the operation was not successful and the result object does not contain the expected value.

## Methods

### <a id="Results_Result_1_GetValueOr__0_"></a> GetValueOr\(TValue\)

Retrieves the value contained in a successful result, otherwise returns the provided default value.

```csharp
public TValue GetValueOr(TValue defaultValue)
```

#### Parameters

`defaultValue` TValue

The default value to return if the result is not successful.

#### Returns

 TValue

The unwrapped value if the result is successful, otherwise the specified default value.

### <a id="Results_Result_1_GetValueOrDefault"></a> GetValueOrDefault\(\)

Retrieves the value contained in a successful result or returns the default value.

```csharp
public TValue? GetValueOrDefault()
```

#### Returns

 TValue?

The value contained in a successful result if the operation succeeded;
otherwise, the default value of type <code class="typeparamref">TValue</code>.

### <a id="Results_Result_1_GetValueOrElse_System_Func_Results_ResultTypes_Error__0__"></a> GetValueOrElse\(Func<Error, TValue\>\)

Retrieves the value of the result if the operation succeeded, or the result of a function if the operation failed.

```csharp
public TValue GetValueOrElse(Func<Error, TValue> function)
```

#### Parameters

`function` [Func](https://learn.microsoft.com/dotnet/api/system.func\-2)<[Error](Results.ResultTypes.Error.md), TValue\>

The function to be executed if the operation failed.

#### Returns

 TValue

The value of the result if the operation succeeded, or the result of the function if the operation failed.

### <a id="Results_Result_1_Inspect_System_Action__0__"></a> Inspect\(Action<TValue\>\)

Executes the specified action on the value contained in a successful result.

```csharp
public Result<TValue> Inspect(Action<TValue> action)
```

#### Parameters

`action` [Action](https://learn.microsoft.com/dotnet/api/system.action\-1)<TValue\>

The action to execute on the value.

#### Returns

 [Result](Results.Result\-1.md)<TValue\>

The current instance of the <xref href="Results.Result%601" data-throw-if-not-resolved="false"></xref> object.

### <a id="Results_Result_1_InspectError_System_Action_Results_ResultTypes_Error__"></a> InspectError\(Action<Error\>\)

Executes the specified action on the error contained in a failure result.

```csharp
public Result<TValue> InspectError(Action<Error> action)
```

#### Parameters

`action` [Action](https://learn.microsoft.com/dotnet/api/system.action\-1)<[Error](Results.ResultTypes.Error.md)\>

The action to perform with the Error object.

#### Returns

 [Result](Results.Result\-1.md)<TValue\>

The current instance of the <xref href="Results.Result%601" data-throw-if-not-resolved="false"></xref> object.

### <a id="Results_Result_1_Match__1_System_Func__0___0__System_Func_Results_ResultTypes_Error___0__"></a> Match<TReturn\>\(Func<TValue, TReturn\>, Func<Error, TReturn\>\)

Matches the result of an operation using success and error functions.

```csharp
public TReturn Match<TReturn>(Func<TValue, TReturn> success, Func<Error, TReturn> fail)
```

#### Parameters

`success` [Func](https://learn.microsoft.com/dotnet/api/system.func\-2)<TValue, TReturn\>

The function to invoke if the operation succeeds.

`fail` [Func](https://learn.microsoft.com/dotnet/api/system.func\-2)<[Error](Results.ResultTypes.Error.md), TReturn\>

The function to invoke if the operation fails.

#### Returns

 TReturn

The result of the matched operation.

#### Type Parameters

`TReturn` 

The type of the matched result.

### <a id="Results_Result_1_Ok"></a> Ok\(\)

Retrieves the operation result if it was successful.

```csharp
public Ok<TValue>? Ok()
```

#### Returns

 [Ok](Results.ResultTypes.Ok\-1.md)<TValue\>?

An instance of <xref href="Results.ResultTypes.Ok%601" data-throw-if-not-resolved="false"></xref>  representing the result of a successful operation; otherwise, null.

### <a id="Results_Result_1_OnSuccess__1_System_Func__0___0__"></a> OnSuccess<TReturn\>\(Func<TValue, TReturn\>\)

Executes the specified function if the operation was successful.

```csharp
public TReturn? OnSuccess<TReturn>(Func<TValue, TReturn> function)
```

#### Parameters

`function` [Func](https://learn.microsoft.com/dotnet/api/system.func\-2)<TValue, TReturn\>

The function to execute.

#### Returns

 TReturn?

The result of the function execution if the operation was successful, or <a href="https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/default">default</a> if the operation failed.

#### Type Parameters

`TReturn` 

The return type of the function.

## Operators

### <a id="Results_Result_1_op_Implicit_Results_ResultTypes_Ok__0___Results_Result__0_"></a> implicit operator Result<TValue\>\(Ok<TValue\>\)

```csharp
public static implicit operator Result<TValue>(Ok<TValue> ok)
```

#### Parameters

`ok` [Ok](Results.ResultTypes.Ok\-1.md)<TValue\>

#### Returns

 [Result](Results.Result\-1.md)<TValue\>

### <a id="Results_Result_1_op_Implicit_Results_ResultTypes_Error__Results_Result__0_"></a> implicit operator Result<TValue\>\(Error\)

```csharp
public static implicit operator Result<TValue>(Error error)
```

#### Parameters

`error` [Error](Results.ResultTypes.Error.md)

#### Returns

 [Result](Results.Result\-1.md)<TValue\>

