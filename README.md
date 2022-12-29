# FluentCoding

Set of basic functionalities to extend linq with more fluent capabilities


### `Or`

Choose when pick the right object based on a predicate.
By default Left when not default

```csharp
var currentAddress = object.AddressDomicile.Or(object.AddressResidence);
var mostRecentData = objectInstance1.Or(objectInstance2, (left, right)=> right.LastUpdateTime > left.LastUpdateTime);
var validData = objectInstance1.Or(objectInstance2, (left)=> !left.IsStillValid); // => objectInstance2
```

### `Do`

Update an object and return the object itself via Action or Function

```csharp
identity.Do(_ => _.Name = "John")
        .Do(_ => _.Surname = "Smith");
```

```csharp
private TypeT UpdateIdentity(TypeT identity)
{ 
  ....
  return updatedIdentity
}

identity.Do(UpdateIdentity)
```
