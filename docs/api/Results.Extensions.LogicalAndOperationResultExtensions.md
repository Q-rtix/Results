# <a id="Results_Extensions_LogicalAndOperationResultExtensions"></a> Class LogicalAndOperationResultExtensions

Namespace: [Results.Extensions](Results.Extensions.md)  
Assembly: Results.dll  

Extensions for performing logical AND operations on <xref href="Results.Result" data-throw-if-not-resolved="false"></xref> and <xref href="Results.Result%601" data-throw-if-not-resolved="false"></xref> objects.

```csharp
public static class LogicalAndOperationResultExtensions
```

#### Inheritance

[object](https://learn.microsoft.com/dotnet/api/system.object) ← 
[LogicalAndOperationResultExtensions](Results.Extensions.LogicalAndOperationResultExtensions.md)

#### Inherited Members

[object.Equals\(object?\)](https://learn.microsoft.com/dotnet/api/system.object.equals\#system\-object\-equals\(system\-object\)), 
[object.Equals\(object?, object?\)](https://learn.microsoft.com/dotnet/api/system.object.equals\#system\-object\-equals\(system\-object\-system\-object\)), 
[object.GetHashCode\(\)](https://learn.microsoft.com/dotnet/api/system.object.gethashcode), 
[object.GetType\(\)](https://learn.microsoft.com/dotnet/api/system.object.gettype), 
[object.MemberwiseClone\(\)](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone), 
[object.ReferenceEquals\(object?, object?\)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals), 
[object.ToString\(\)](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Methods

### <a id="Results_Extensions_LogicalAndOperationResultExtensions_And_Results_Result_Results_Result_"></a> And\(Result, Result\)

Performs a logical AND operation between two <xref href="Results.Result" data-throw-if-not-resolved="false"></xref> objects.

```csharp
public static Result And(this Result self, Result result)
```

#### Parameters

`self` [Result](Results.Result.md)

The first result to combine.

`result` [Result](Results.Result.md)

The other result to combine with this result.

#### Returns

 [Result](Results.Result.md)

A new instance of <xref href="Results.Result" data-throw-if-not-resolved="false"></xref> representing a successful result if both results are successful;
     otherwise, returns a new instance representing an error result with the error value from this result.

#### Remarks

<pre><code class="lang-csharp">Result x = new Ok();
Result y = new Error("late error");
Assert.Equal(x.And(y), new Error("late error"));

Result x = new Ok();
Result y = new Ok();
Assert.Equal(x.And(y), new Ok());


Result x = new Error("early error");
Result y = new Error("late error");
Assert.Equal(x.And(y), new Error("early error"));

Result x = new Error("early error");
Result y = new Ok();
Assert.Equal(x.And(y), new Error("early error"));</code></pre>

### <a id="Results_Extensions_LogicalAndOperationResultExtensions_And__1_Results_Result_Results_Result___0__"></a> And<T\>\(Result, Result<T\>\)

Performs a logical AND operation between <xref href="Results.Result" data-throw-if-not-resolved="false"></xref> and <xref href="Results.Result%601" data-throw-if-not-resolved="false"></xref> objects.

```csharp
public static Result<T> And<T>(this Result self, Result<T> result)
```

#### Parameters

`self` [Result](Results.Result.md)

The first result to combine.

`result` [Result](Results.Result\-1.md)<T\>

The other result to combine with this result.

#### Returns

 [Result](Results.Result\-1.md)<T\>

A new instance of <xref href="Results.Result" data-throw-if-not-resolved="false"></xref> representing a successful result if both results are successful;
     otherwise, returns a new instance representing an error result with the error value from this result.

#### Type Parameters

`T` 

The type of the value associated with the result received as parameter.

#### Remarks

<pre><code class="lang-csharp">Result x = new Ok();
Result&lt;int&gt; y = new Error("late error");
Assert.Equal(x.And(y), new Error("late error"));


Result x = new Ok();
Result&lt;int&gt; y = new Ok(3);
Assert.Equal(x.And(y), new Ok(3));

Result x = new Error("early error");
Result&lt;int&gt; y = new Error("late error");
Assert.Equal(x.And(y), new Error("early error"));

Result x = new Error("early error");
Result&lt;int&gt; y = new Ok(3);
Assert.Equal(x.And(y), new Error("early error"));</code></pre>

