# FluentCoding

Set of basic functionalities to extend linq with more fluent capabilities

# `Base Extensions`
Basic functionalities available to any Type T

## Or

Choose when pick the right object based on a predicate.
By default Left when not default

```csharp
var currentAddress = object.AddressDomicile.Or(object.AddressResidence);
var validData = object1.Or(object2, (subject)=> !subject.IsStillValid);
var mostRecentData = dataSource1.Or(dataSource2, (subject, orValue)=> orValue.LastUpdateTime > subject.LastUpdateTime);
```

## Do

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

var identitiesList = new List<Identity>();
identitiesList.Add(identity.Do(UpdateIdentity));
```

## Equals

Expand the equality functions: `EqualsTo`, `EqualsToAny`, `EquivalentTo`, `EquivalentToAny`

### EqualsTo
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

### EquivalentTo
```csharp
bool EqualityCheck(Identity p1, Identity p2) => p1.Pincode == p1.Pincode;ma è acceso?

Tesla tesla = new Tesla() { ... };
Ferrari ferrari = new Ferrari() { ... };
Ferrari ferrari2 = new Ferrari() { ... };
Ferrari ferrari3 = new Ferrari() { ... };

tesla.EquivalentTo(ferrari, (t, f) => t.PlateNumber == f.PlateNumber);

tesla.EquivalentToAny((t, f) => t.PlateNumber == f.PlateNumber, ferrari, ferrari2, ferrari3);
```

## IsNullOrDefault

Handy shorthand method to check if something is null or default

```csharp
string.Empty.IsNullOrDefault(); //true
null.IsNullOrDefault(); //true
" ".IsNullOrDefault(); //true
" ".IsNullOrDefault(false); //false
objectInstance.IsNullOrDefault(); //false
```
```csharp
public enum TestEnum { Enum1, Enum2 }
TestEnum.Enum1.IsNullOrDefault(); //true
TestEnum.Enum2.IsNullOrDefault(); //false
```
```csharp
public static Func<bool> NullFunc = null;
public static Func<bool> NotNullFunc = () => true;
NullFunc.IsNullOrDefault(); //true
NotNullFunc.IsNullOrDefault(); //false
```

## Is

Apply a boolean predicate to an object and obtain the preticate result along with the subject.
Can be combined with other functions from this library in a fluent way

```csharp
Address address = new Address() { ... }; 
(var isSatisfied, var checkSubject) = address.Is(_ => _.Country == "ITA");

var result = address.Is(_ => _.LastUpdate > DateTime.Now.AddYears(-5));
if(result.IsSatisfied) 
   result.Subject; /*do something*/
```


## Map

Convert a Type into another one
```csharp
Identity people = ReadFromDataBase(...);
var address = people.Map(p => new Address() {Street = p.Domicile, Country = p.BornCountry, ...});
```
```csharp
Tesla ConvertToTesla(Ferrari f) 
{
    //[...] do something
    return teslaConversion;
}

TeslaSoftware ExtractSoftware(Tesla t) 
{
    //[...] do something
    return softwareFromTesla;
}

Ferrari ferrari = new Ferrari() { ... };
var sw = ferrari.Map(ConvertToTesla)
                .Map(ExtractSoftware);
```

## Switch 

Fluent version of the switch case: `Switch`, `SwitchMap`

### Switch
```csharp
Identity people = new Identity() { ... };
Identity ApiGetPeople(string pincode) { ... return people; }
Identity ApiGetPeopleAddress(people) { ... return peopleAddress; }

people.Switch
(
    p => p,
    (p => p.LastUpdate < DateTime.Node.AddDays(-30) , p => ApiGetPeople(p.Pincode)),
    (p => p.LastUpdate < DateTime.Node.AddDays(-10) , p => p.Do(_ => _.Address = ApiGetPeopleAddress(p)))
)
```

### SwitchMap
```csharp
Identity people = new Identity() { ... };

var ageType = 
people.Switch
(
    p => Enum.Old,
    (p => p.YearsOld < 18 , p => Enum.Child),
    (p => p.YearsOld > 18  &&  p.YearsOld < 60 , p => Enum.Adult)
);
```
