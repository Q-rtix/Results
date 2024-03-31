# <a id="Results_ResultTypes_Error"></a> Class Error

Namespace: [Results.ResultTypes](Results.ResultTypes.md)  
Assembly: Results.dll  

Represents a result type indicating an operation failure with error data.

```csharp
public class Error : ResultType
```

#### Inheritance

[object](https://learn.microsoft.com/dotnet/api/system.object) ← 
[ResultType](Results.ResultTypes.ResultType.md) ← 
[Error](Results.ResultTypes.Error.md)

#### Inherited Members

[ResultType.IsSucceed](Results.ResultTypes.ResultType.md\#Results\_ResultTypes\_ResultType\_IsSucceed), 
[ResultType.ToString\(\)](Results.ResultTypes.ResultType.md\#Results\_ResultTypes\_ResultType\_ToString), 
[object.Equals\(object?\)](https://learn.microsoft.com/dotnet/api/system.object.equals\#system\-object\-equals\(system\-object\)), 
[object.Equals\(object?, object?\)](https://learn.microsoft.com/dotnet/api/system.object.equals\#system\-object\-equals\(system\-object\-system\-object\)), 
[object.GetHashCode\(\)](https://learn.microsoft.com/dotnet/api/system.object.gethashcode), 
[object.GetType\(\)](https://learn.microsoft.com/dotnet/api/system.object.gettype), 
[object.MemberwiseClone\(\)](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone), 
[object.ReferenceEquals\(object?, object?\)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals), 
[object.ToString\(\)](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Constructors

### <a id="Results_ResultTypes_Error__ctor_System_Object___"></a> Error\(params object\[\]\)

Initializes a new instance of the <xref href="Results.ResultTypes.Error" data-throw-if-not-resolved="false"></xref> class.

```csharp
public Error(params object[] errors)
```

#### Parameters

`errors` [object](https://learn.microsoft.com/dotnet/api/system.object)\[\]

The errors to associate with this result.

### <a id="Results_ResultTypes_Error__ctor_System_Collections_Generic_IEnumerable_System_Object__"></a> Error\(IEnumerable<object\>\)

Initializes a new instance of the <xref href="Results.ResultTypes.Error" data-throw-if-not-resolved="false"></xref> class.

```csharp
public Error(IEnumerable<object> errors)
```

#### Parameters

`errors` [IEnumerable](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable\-1)<[object](https://learn.microsoft.com/dotnet/api/system.object)\>

The errors to associate with this result.

## Properties

### <a id="Results_ResultTypes_Error_Errors"></a> Errors

Gets the list of errors associated with the operation failure.

```csharp
public object[] Errors { get; protected set; }
```

#### Property Value

 [object](https://learn.microsoft.com/dotnet/api/system.object)\[\]

## Methods

### <a id="Results_ResultTypes_Error_ToString"></a> ToString\(\)

Provides a string representation of the Error object.

```csharp
public override string ToString()
```

#### Returns

 [string](https://learn.microsoft.com/dotnet/api/system.string)

