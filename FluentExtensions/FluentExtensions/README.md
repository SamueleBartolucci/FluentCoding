# FluentCoding

Set of functionalities to extend linq with more fluent capabilities
This functionalities can be combined together to fluently manipulate an object:

#### `ForEach`, `When`, `Or`, `Is`, `Try`, `Do`, `Equals`, `Map`, `Switch`

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
When the Do subject is null it just return the subject

```csharp
identity.Do(_ => _.Name = "John");

//or

identity.Do(_ => _.Name = "John",
            _ => _.Surname = "Smith");
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

# Equals

Expand the equality functions: `EqualsTo`, `EqualsToAny`, `EquivalentTo`, `EquivalentToAny`
When the subject is null it return false

### EqualsTo - EqualsToAny

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

### EquivalentTo - EquivalentToAny
```csharp
bool EqualityCheck(Identity p1, Identity p2) => p1.Pincode == p1.Pincode;ma è acceso?

Tesla tesla = new Tesla() { ... };
Ferrari ferrari = new Ferrari() { ... };
Ferrari ferrari2 = new Ferrari() { ... };
Ferrari ferrari3 = new Ferrari() { ... };

tesla.EquivalentTo(ferrari, (t, f) => t.PlateNumber == f.PlateNumber);

tesla.EquivalentToAny((t, f) => t.PlateNumber == f.PlateNumber, ferrari, ferrari2, ferrari3);
```

# IsNullOrEquivalent

Handy shorthand method to check if something is null or an equivalent state
Expose a way to specify more option to check fo null or equivalent state.
Via action on a 'IsNullOptions' object, or submitting an 'IsNullOptions' object

```csharp
string.Empty.IsNullOrEquivalent(); //true
null.IsNullOrEquivalent(); //true
" ".IsNullOrEquivalent(); //false
objectInstance.IsNullOrEquivalent(); //false
```

```csharp
"".IsNullOrEquivalent(_ => _.EmptyStringIsNull = false); //false
"".IsNullOrEquivalent(_ => _.EmptyStringIsNull = true); //true
"  ".IsNullOrEquivalent(_ => _.EmptyOrWhiteSpacesIsNull = false); //false
"  ".IsNullOrEquivalent(_ => _.EmptyOrWhiteSpacesIsNull = true); //true

var options = new IsNullOptions() { EmptyStringIsNull = false,  EmptyOrWhiteSpacesIsNull = false;};
"".IsNullOrEquivalent(options); //false
" ".IsNullOrEquivalent(options); //false

```

```csharp
public enum TestEnum { Enum1, Enum2 }
TestEnum.Enum1.IsNullOrEquivalent(); //False
TestEnum.Enum2.IsNullOrEquivalent(); //False
```
```csharp
public static Func<bool> NullFunc = null;
public static Func<bool> NotNullFunc = () => true;
NullFunc.IsNullOrEquivalent(); //true
NotNullFunc.IsNullOrEquivalent(); //false
```

# Is

Apply a boolean predicate to an object and obtain the preticate result along with the subject.
Can be combined with other functions from this library in a fluent way

```csharp
Address address = new Address() { ... }; 
(var isSatisfied, var checkSubject) = address.Is(_ => _.Country == "ITA");

var result = address.Is(_ => _.LastUpdate > DateTime.Now.AddYears(-5));
if(result.IsSatisfied) 
   result.Subject; /*do something*/
```


# Map

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

# Switch 

Fluent version of the switch case: `Switch`, `SwitchMap`

### Switch
```csharp
Identity people = new Identity() { ... };
Identity ApiGetPeople(string pincode) { ... return people; }
Identity ApiGetPeopleAddress(people) { ... return peopleAddress; }

var updatedPeople =
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

# When
Apply one or more checks on the subjects and then apply and Action or a Function only when all the checks are satisfied

## When base class
```csharp
var car = LoadCarData(...);

When<Car> result = car.When(c => c.Type == "Ferrari");

result.IsSuccess; // the predicate result
result.Subject; //the predicate subject
```


## When.Then
```csharp
var car = LoadCarData(...);
c.Insurance = InsuranceType.LowBudget;

car.When(c => c.Type == "Ferrari")   
   .Then(c => c.Insurance = InsuranceType.Luxury);
```

## When.ThenAnd
Concatenate more Then on the subject 
```csharp
var car = LoadCarData(...);
c.Insurance = InsuranceType.LowBudget;

car.When(c => c.Type == "Ferrari")   
   .ThenAnd(c => c.Insurance = InsuranceType.Luxury)
   .ThenAnd(c => c.Color = "Red")
   .Then(c => c.Available = true)
```


## When.Or.Then
```csharp
var car = LoadCarData(...);
c.Insurance = InsuranceType.LowBudget;

car.When(c => c.Type == "Ferrari")
   .OrWhen(c => c.Type == "Lamborghini")
   .Then(c => c.Insurance = InsuranceType.Luxury);
```

## When.Or.And.Then
```csharp
var car = LoadCarData(...);
c.Insurance = InsuranceType.LowBudget;

car.When(c => c.Type == "Ferrari")
   .OrWhen(c => c.Type == "Lamborghini")
   .AndWhen(c => c.MarketPrice >= 180000)
   .Then(c => c.Insurance = InsuranceType.Luxury);
```

## When.ThenMap only when True
```csharp
var car = LoadCarData(...);
Ferrari ConvertToFerrari(Car car) 
{
 //[...] do something
 return ferrari; 
}

//when
(Ferrari ferrari, Car subject) = car.When(c => c.Type == "Ferrari")      
                                    .ThenMap(ConvertToFerrari);
```


## When.ThenMap when True or When False
```csharp
var car = LoadCarData(...);
Ferrari ConvertToFerrari(Car car) 
{
 //[...] do something
 return ferrari; 
}

Ferrari CreateNewFerrari(Car car)
{
 //[...] do something
 return newFerrari; 
}

//when
var ferrari = car.When(c => c.Type == "Ferrari")      
                 .ThenMap(ConvertToFerrari, CreateNewFerrari);
```


# TryCatch
Inline wrap methods for the Try{}Catch{}

## Try base class
Try to do something and return a context with all the information

```csharp
Car LoadCarData(string licensPlate)
{
 //[...] do something
 return car; 
}

var tryResult = "xxxxx".Try(LoadCarData);
tryResult.IsSuccesful; //true or false
tryResult.Subject; //the input string licensePlace
tryResult.Result; //the Car object loader
tryResult.Error; //the Exception raised when loading the car data
```

```csharp
Car LoadCarData(string licensePlate)
{
 //[...] do something
 return car; 
}

CustomError ManageException(String licensePlate, Exception e) => new CustomError(e.Messge, licensePlate);

var tryResult = "carLicensePlate".Try(LoadCarData, ManageException);
tryResult.IsSuccesful; //true or false
tryResult.Subject; //the input string licensePlace
tryResult.Result; //the Car object loader
tryResult.Error; //the CustomError returned by ManageException
```

## Try.OnSuccess or Try.OnFail
Try to do something and when ok do something else
```csharp
Car LoadCarData(string licensPlate)
{
 //[...] do something
 return car; 
}
List<CarComponent> DisassembleCar(Car car)
{
 //[...] do something
 return carComponents; 
}

(var Components, var tryCatchContext) = "xxxxx".Try(LoadCarData)
                                               .OnSuccess(DisassembleCar);                       
Components; //the disassembled car components ONLY WHEN no exception occurred, default of List<CarComponent> otherwise
tryCatchContext; //the TryCatch class from the previous example, ALWAYS returned
```
```csharp
Car LoadCarData(string licensPlate)
{
 //[...] do something
 return car; 
}
CustomError ManageException(String licensePlate, Exception e) => new CustomError(e.Messge, licensePlate);

List<Car> availableCar = new List<Car>();

(var error, var tryCatchContext) = "xxxxx".Try(plate => availableCar.Add(LoadCarData(plate))
                                          .OnFail(ManageException);
                       
error; //the CustomError ONLY WHEN and exception occurred, default of CustomError otherwise
tryCatchContext; //the TryCatch class from the previous example, ALWAYS returned
```

## Try.Then
Try to do something and then manage the success or the fail result
```csharp
Car LoadCarData(string licensPlate)
{
 //[...] do something
 return car; 
}
bool AddCarToStock(Car car) 
{
 //[...] do something
 return true; 
}
bool TraceCarError(string plate, Exception e) 
{
 //[...] do something
 return true; 
}

CustomError ManageException(String licensePlate, Exception e) => new CustomError(e.Messge, licensePlate);

"xxxxx".Try(LoadCarData)
       .Then(AddCarToStock, TraceCarError);                       
```

## TryTo
Try to do something or manage the exception, the output type can differ from the subject input type
```csharp
var date = "2022-12-29".TryTo(DateTime.Parse, (c, ex) => DateTime.MinValue);
```

# ForEach
Expand the ForEach function to all the IEnumerable types

## Action
```csharp
int[] original = { 1, 2, 3 };
var reworked = new List<string>();
original.ForEach(_ => reworked.Add(_.ToString()));
```

## Function: 
Return a new IEnumerable with the result of the function applied to each item
```csharp
int[] original = { 1, 2, 3 };
IEnumerable<string> reworked = original.ForEach(_ => _.ToString());
```
