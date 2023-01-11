
# What's NEW
- Do now ALWAYS return the subject (even when called with a Func)
- Removed the Do extension with a single Action/Func, left only the extension with params[] Action/Func
- Added the DoAsync extension
- Changed DoForAll into DoForEach, added DoForEachAsync
- Changed DoForAllMap into MapForEach, added MapForEachAsync
- Removed EqualsToAny and EqualsTo (with input a comparator) same as EquivalentTo or EquivalentToAny
- Added EqualsToAnyAsync (without input comparator)
- Added MapAsync
- Collapsed Switch and SwitchMap into Switch
- Added SwitchAsync
- Added TryAsync and TryToAsync
- Collapsed Then(onSucces, onFail) and ThenMap(onSucces, onFail) into Then
- Added WhenAnyAsync, WhenAsync

# FluentCoding

Set of functionalities to extend linq with more fluent capabilities
This functionalities can be combined together to fluently manipulate an object:

####  `Do`,`Equals`,`Is`, `Map`,`Or`, `Switch`,`Try`, `When`

Almost all the Fluent extension expose the `Async` version that can be used with a Task<T>.
Currently excluded: `Is`

# Do

Do something with/to and object and return the object:
 `Do`, `DoForEach`,`DoAsync`, `DoForEachAsync`

### Do, DoAsync
When the Do subject is null it just return the subject

`Action` Apply one or more Actions to the subject and the return the subject
```csharp
identity.Do(_ => _.Name = "John");
//or
identity.Do(_ => _.Name = "John",
            _ => _.Surname = "Smith");
```
`Func` Apply one or more Func to the subject and then return the Subject
```csharp
private TypeT UpdateIdentity(TypeT identity)
{ 
  [...] //do stuff
  return updatedIdentity
}

var identitiesList = new List<Identity>();
identitiesList.Add(identity.Do(UpdateIdentity));
```

`Async`
```csharp
Task<Identity> identity = GetIdentityFromAPIAsync(...);
identity.DoAsync(_ => _.Name = "John").Result;
//or
identity.DoAsync(_ => _.Name = "John",
            _ => _.Surname = "Smith").Result;
```

### DoForEach, DoForEachAsync
Apply one ore more Actions or a Function to each item in an Enumerable and then return the Enumerable itself
```csharp
IEnumerable<Identity> itentities = LoadIdentitiesDataBase(...);

//update the LastUpdate field for each item in identities
itentities.DoForEach(_ => _.LastUpdate = DateTime.Now); 

//or

//update the LastUpdate field and the LastUpdateAuthor for each item in identities
itentities.DoForEach(_ => _.LastUpdate = DateTime.Now,
                    _ => _.LastUpdateAuthor = "Admin");
```

`Async`
```csharp
Task<IEnumerable<Identity>> itentities = GetIdentitiesFromAPIAsync(...);

//update the LastUpdate field for each item in identities
itentities.DoForEachAsync(_ => _.LastUpdate = DateTime.Now).Result; 

//or

//update the LastUpdate field and the LastUpdateAuthor for each item in identities
itentities.DoForEachAsync(_ => _.LastUpdate = DateTime.Now,
                          _ => _.LastUpdateAuthor = "Admin").Result;
```


# Equals

Expand the equality functions: `EqualsToAny`, `EquivalentTo`, `EquivalentToAny`

When the subject is null it return false

### EqualsToAny

```csharp
bool EqualityCheck(Identity p1, Identity p2) => p1.Pincode == p1.Pincode;

Identity people1 = ReadFromDataBase(...);
Identity people2 = ReadFromDataBase(...);
Identity people3 = ReadFromDataBase(...);
Identity people4 = ReadFromDataBase(...);

//The framework Equals is used in this case
people1.EqualsToAny(people2, people3, people4);
"XX".EqualsToAny("YY", "TT", "XX", "VV"); 
```

### EquivalentTo - EquivalentToAny
```csharp
bool EqualityCheck(Identity p1, Identity p2) => p1.Pincode == p1.Pincode;

Tesla tesla = new Tesla() { ... };
Ferrari ferrari = new Ferrari() { ... };
Ferrari ferrari2 = new Ferrari() { ... };
Ferrari ferrari3 = new Ferrari() { ... };

tesla.EquivalentTo(ferrari, (t, f) => t.PlateNumber == f.PlateNumber);

tesla.EquivalentToAny((t, f) => t.PlateNumber == f.PlateNumber, ferrari, ferrari2, ferrari3);
```



# Is

Functionalities: `Is`, `IsNullOrEquivalent`

### IsNullOrEquivalent

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
"".IsNullOrEquivalent(_ => _.StringIsNullWhen = StringIsNullWhenEnum.Null); //false
"".IsNullOrEquivalent(_ => _.StringIsNullWhen = StringIsNullWhenEnum.NullOrEmpty); //true
"  ".IsNullOrEquivalent(_ => _.StringIsNullWhen = StringIsNullWhenEnum.Null); //false
"  ".IsNullOrEquivalent(_ => _.StringIsNullWhen = StringIsNullWhenEnum.NullOrEmptyOrWhiteSpaces); //true

var options = IsNullOptions.StringIsNullWhenNull;
"".IsNullOrEquivalent(options); //false
" ".IsNullOrEquivalent(options); //false

options = IsNullOptions.StringIsNullWhenNullOrEmpty;
"".IsNullOrEquivalent(options); //true
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

### Is
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
Convert a Type into another one: `Map`, `MapForEach`,`MapAsync`, `MapForEachAsync`

### Map
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

### MapForEach
Return an enumerable with the result of all the call to Map(item)
```csharp
IEnumerable<Car> cars = ReadCarsFromDataBase(...);
var carsSoftware = cars.MapForEach(ExtractSoftware);
//do soemthing...
carsSoftware.Where(_ => _.Version >= 1.4).[...];
```
# Or

Choose when pick the right object based on a predicate.
By default Left when not null

### Or
```csharp
var currentAddress = object.AddressDomicile.Or(object.AddressResidence);
var validData = object1.Or(object2, (subject)=> !subject.IsStillValid);
var mostRecentData = dataSource1.Or(dataSource2, (subject, orValue)=> orValue.LastUpdateTime > subject.LastUpdateTime);
```

###  OrIsEmpty 
(for strings)
```csharp
string newAddress = null; //left string is null
string oldAddress = "address-value";
newAddress.Or(oldAddress); // return oldAddress
newAddress.OrIsEmpty(oldAddress); // return oldAddress

string newAddress = ""; //left string is empty
string oldAddress = "address-value";
newAddress.Or(oldAddress); // return newAddress !!
newAddress.Or(oldAddress, newAddr => string.IsNullOrEmpty(newAddr)); // return oldAddress
newAddress.OrIsEmpty(oldAddress); // return oldAddress
```


# Switch 

Fluent version of the switch case: `Switch`

### Switch 
Keep the same type on the output T -> T
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

### Switch
Change the output type from the subject type to the type from the function output: T -> K
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


# TryCatch
Inline wrap methods for the Try{}Catch{}:  `Try`, `TryTo`, `TryAsync`, `TryToAsync`
## Try (base class)
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

# When
Apply one or more checks on the subjects and then apply and Action or a Function only when all the checks are satisfied

## When (base class)
```csharp
var car = LoadCarData(...);

When<Car> result = car.When(c => c.Type == "Ferrari");

result.IsSuccess; // the predicate result
result.Subject; //the predicate subject
```


## When.Then
Keep the same input type T -> T
```csharp
var car = LoadCarData(...);
c.Insurance = InsuranceType.LowBudget;

car.When(c => c.Type == "Ferrari")   
   .Then(c => c.Insurance = InsuranceType.Luxury);
```
Change the input type T -> K
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

## When.ThenAnd
Concatenate more Then on the subject.
The `ThenAnd` output is the When context, to close a chain of `ThenAnd` the latest should be a `Then`
```csharp
var car = LoadCarData(...);
c.Insurance = InsuranceType.LowBudget;

car.When(c => c.Type == "Ferrari")   
   .ThenAnd(c => c.Insurance = InsuranceType.Luxury)
   .ThenAnd(c => c.Color = "Red")
   .Then(c => c.Available = true)
```


## When.OrWhen.Then
Apply one or more checks conditions on the subject, in Or condition with the current succesful state 
```csharp
var car = LoadCarData(...);
c.Insurance = InsuranceType.LowBudget;

car.When(c => c.Type == "Ferrari")
   .OrWhen(c => c.Type == "Lamborghini")
   .Then(c => c.Insurance = InsuranceType.Luxury);
```



## When.OrWhen.AndWhen.Then
Apply one or more checks conditions on the subject, in Or condition with the with the current succesful state 
Then Apply one or more checks conditions on the subject, in And condition with the current succesful state `When` 
Once `AndWhen` is used  the `OrWhen` is not available anymore
```csharp
var car = LoadCarData(...);
c.Insurance = InsuranceType.LowBudget;

car.When(c => c.Type == "Ferrari")
   .OrWhen(c => c.Type == "Lamborghini")
   .AndWhen(c => c.MarketPrice >= 180000)
   .Then(c => c.Insurance = InsuranceType.Luxury);
```

## When.ThenMap only when True
Map the subject when condition is satisfied, if not return the subject
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