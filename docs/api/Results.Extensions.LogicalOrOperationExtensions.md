# <a id="Results_Extensions_LogicalOrOperationExtensions"></a> Class LogicalOrOperationExtensions

Namespace: [Results.Extensions](Results.Extensions.md)  
Assembly: Results.dll  

Extensions for performing logical OR operations on <xref href="Results.Result" data-throw-if-not-resolved="false"></xref> and <xref href="Results.Result%601" data-throw-if-not-resolved="false"></xref> objects.

```csharp
public static class LogicalOrOperationExtensions
```

#### Inheritance

[object](https://learn.microsoft.com/dotnet/api/system.object) ← 
[LogicalOrOperationExtensions](Results.Extensions.LogicalOrOperationExtensions.md)

#### Inherited Members

[object.Equals\(object?\)](https://learn.microsoft.com/dotnet/api/system.object.equals\#system\-object\-equals\(system\-object\)), 
[object.Equals\(object?, object?\)](https://learn.microsoft.com/dotnet/api/system.object.equals\#system\-object\-equals\(system\-object\-system\-object\)), 
[object.GetHashCode\(\)](https://learn.microsoft.com/dotnet/api/system.object.gethashcode), 
[object.GetType\(\)](https://learn.microsoft.com/dotnet/api/system.object.gettype), 
[object.MemberwiseClone\(\)](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone), 
[object.ReferenceEquals\(object?, object?\)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals), 
[object.ToString\(\)](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Methods

### <a id="Results_Extensions_LogicalOrOperationExtensions_Or_Results_Result_Results_Result_"></a> Or\(Result, Result\)

Performs a logical OR operation between two <xref href="Results.Result" data-throw-if-not-resolved="false"></xref> objects.

```csharp
public static Result Or(this Result self, Result result)
```

#### Parameters

`self` [Result](Results.Result.md)

The first <xref href="Results.Result" data-throw-if-not-resolved="false"></xref> object.

`result` [Result](Results.Result.md)

The second <xref href="Results.Result" data-throw-if-not-resolved="false"></xref> object.

#### Returns

 [Result](Results.Result.md)

A new <xref href="Results.Result" data-throw-if-not-resolved="false"></xref> object that is the result of the logical OR operation.
If the first <xref href="Results.Result" data-throw-if-not-resolved="false"></xref> is faulted, the second <xref href="Results.Result" data-throw-if-not-resolved="false"></xref> is returned.
Otherwise, a new <xref href="Results.ResultTypes.Ok" data-throw-if-not-resolved="false"></xref> object is returned.

#### Remarks

<pre><code class="lang-csharp">Result x = new Ok();
Result y = new Ok();
Assert.Equal(x.Or(y), new Ok());


Result x = new Ok();
Result y = new Error("late error");
Assert.Equal(x.Or(y), new Ok());

Result x = new Error("early error");
Result y = new Ok();
Assert.Equal(x.Or(y), new Ok());

Result x = new Error("early error");
Result y = new Error("late error");
Assert.Equal(x.Or(y), new Error("late error"));</code></pre>

### <a id="Results_Extensions_LogicalOrOperationExtensions_Or__1_Results_Result___0__Results_Result___0__"></a> Or<T\>\(Result<T\>, Result<T\>\)

Performs a logical OR operation between <xref href="Results.Result%601" data-throw-if-not-resolved="false"></xref> and <xref href="Results.Result" data-throw-if-not-resolved="false"></xref> objects.

```csharp
public static Result<T> Or<T>(this Result<T> self, Result<T> result)
```

#### Parameters

`self` [Result](Results.Result\-1.md)<T\>

The first <xref href="Results.Result" data-throw-if-not-resolved="false"></xref> object.

`result` [Result](Results.Result\-1.md)<T\>

The second <xref href="Results.Result" data-throw-if-not-resolved="false"></xref> object.

#### Returns

 [Result](Results.Result\-1.md)<T\>

A new <xref href="Results.Result" data-throw-if-not-resolved="false"></xref> object that is the result of the logical OR operation.
If the first <xref href="Results.Result" data-throw-if-not-resolved="false"></xref> is faulted, the second <xref href="Results.Result" data-throw-if-not-resolved="false"></xref> is returned.
Otherwise, a new <xref href="Results.ResultTypes.Ok" data-throw-if-not-resolved="false"></xref> object is returned.

#### Type Parameters

`T` 

The type of the value associated with this result and the result received as parameter.

#### Remarks

<pre><code class="lang-csharp">Result&lt;int&gt; x = new Ok(2);
Result&lt;int&gt; y = new Ok(3);
Assert.Equal(x.Or(y), new Ok(2));


Result&lt;int&gt; x = new Ok(2);
Result&lt;int&gt; y = new Error("late error");
Assert.Equal(x.Or(y), new Ok(2));

Result&lt;int&gt; x = new Error("early error");
Result&lt;int&gt; y = new Ok(3);
Assert.Equal(x.Or(y), new Ok(3));

Result&lt;int&gt; x = new Error("early error");
Result&lt;int&gt; y = new Error("late error");
Assert.Equal(x.Or(y), new Error("late error"));</code></pre>

