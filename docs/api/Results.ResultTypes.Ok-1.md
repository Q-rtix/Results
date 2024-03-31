# <a id="Results_ResultTypes_Ok_1"></a> Class Ok<TValue\>

Namespace: [Results.ResultTypes](Results.ResultTypes.md)  
Assembly: Results.dll  

Represents a result type indicating a successful operation with a value.

```csharp
public class Ok<TValue> : Ok
```

#### Type Parameters

`TValue` 

The type of the value.

#### Inheritance

[object](https://learn.microsoft.com/dotnet/api/system.object) ← 
[ResultType](Results.ResultTypes.ResultType.md) ← 
[Ok](Results.ResultTypes.Ok.md) ← 
[Ok<TValue\>](Results.ResultTypes.Ok\-1.md)

#### Inherited Members

[Ok.ToString\(\)](Results.ResultTypes.Ok.md\#Results\_ResultTypes\_Ok\_ToString), 
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

### <a id="Results_ResultTypes_Ok_1__ctor__0_"></a> Ok\(TValue\)

Initializes a new instance of the <xref href="Results.ResultTypes.Ok%601" data-throw-if-not-resolved="false"></xref> class.

```csharp
public Ok(TValue value)
```

#### Parameters

`value` TValue

The value obtained in the operation.

## Properties

### <a id="Results_ResultTypes_Ok_1_Value"></a> Value

Represents the value of a successful operation result.

```csharp
public TValue Value { get; protected set; }
```

#### Property Value

 TValue

## Methods

### <a id="Results_ResultTypes_Ok_1_ToString"></a> ToString\(\)

Returns a string that represents the current object.

```csharp
public override string ToString()
```

#### Returns

 [string](https://learn.microsoft.com/dotnet/api/system.string)

A string that represents the current object.

