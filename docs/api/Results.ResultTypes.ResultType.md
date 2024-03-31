# <a id="Results_ResultTypes_ResultType"></a> Class ResultType

Namespace: [Results.ResultTypes](Results.ResultTypes.md)  
Assembly: Results.dll  

Represents a result type indicating the success or failure of an operation.

```csharp
public abstract class ResultType
```

#### Inheritance

[object](https://learn.microsoft.com/dotnet/api/system.object) ← 
[ResultType](Results.ResultTypes.ResultType.md)

#### Derived

[Error](Results.ResultTypes.Error.md), 
[Ok](Results.ResultTypes.Ok.md)

#### Inherited Members

[object.Equals\(object?\)](https://learn.microsoft.com/dotnet/api/system.object.equals\#system\-object\-equals\(system\-object\)), 
[object.Equals\(object?, object?\)](https://learn.microsoft.com/dotnet/api/system.object.equals\#system\-object\-equals\(system\-object\-system\-object\)), 
[object.GetHashCode\(\)](https://learn.microsoft.com/dotnet/api/system.object.gethashcode), 
[object.GetType\(\)](https://learn.microsoft.com/dotnet/api/system.object.gettype), 
[object.MemberwiseClone\(\)](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone), 
[object.ReferenceEquals\(object?, object?\)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals), 
[object.ToString\(\)](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Constructors

### <a id="Results_ResultTypes_ResultType__ctor_System_Boolean_"></a> ResultType\(bool\)

Represents a generic success result type.

```csharp
protected ResultType(bool isSucceed)
```

#### Parameters

`isSucceed` [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

#### Remarks

This result type indicates a successful operation.

## Properties

### <a id="Results_ResultTypes_ResultType_IsSucceed"></a> IsSucceed

Gets a value indicating whether the operation was successful.

```csharp
public bool IsSucceed { get; }
```

#### Property Value

 [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

## Methods

### <a id="Results_ResultTypes_ResultType_ToString"></a> ToString\(\)

Override the ToString method to output 'Success' or 'Failure'

```csharp
public override string ToString()
```

#### Returns

 [string](https://learn.microsoft.com/dotnet/api/system.string)

A string that represents the current object.

