# FluentCoding

Set of basic functionalities to extend linq with more fluent capabilities


# Or

Choose when pick the right object based on a predicate.
By default Left when not default

```csharp
var currentAddress = object.AddressDomicile.Or(object.AddressResidence);
var validData = object1.Or(object2, (subject)=> !subject.IsStillValid);
var mostRecentData = dataSource1.Or(dataSource2, (subject, orValue)=> orValue.LastUpdateTime > subject.LastUpdateTime);
```

# Do

Update an object and return the object itself via Action or Function

```csharp
identity.Do(_ => _.Name = "John")
        .Do(_ => _.Surname = "Smith");
```

```csharp
private TypeT UpdateIdentity(TypeT identity)
{ 
  [...] //do stuff
  return updatedIdentity
}

identity.Do(UpdateIdentity);
```

# Equals

Expand the equality functions: `EqualsTo`, `EqualsToAny`, `EquivalentTo`, `EquivalentToAny`

```csharp
bool EqualityCheck(Identity p1, Identity p2) => p1.Pincode == p1.Pincode;ma è acceso?

Identity people1 = ReadFromDataBase(...);
Identity people2 = ReadFromDataBase(...);
Identity people3 = ReadFromDataBase(...);
Identity people4 = ReadFromDataBase(...);

people1.EqualsTo(people2, EqualityCheck);
people1.EqualsToAny(EqualityCheck, people2, people3, people4);
"XX".EqualsToAny("YY", "TT", "XX", "VV"); //when no specified an equality check, the framework Equals is used
```

