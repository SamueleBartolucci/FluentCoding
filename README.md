# What's NEW 2.1.3
- Added: `WhenIsTrue`,`WhenIsFalse`,`WhenAll`,`WhenAllAsync`,`WhenIsTrueAsync`,`WhenIsFalseAsync`,`ThenForAll`

# What's NEW 2.1.2
- Added `SwitchOptn` and `OrOptn` 
- Added `IsNotNullOrEquivalent`, `IsNullOrEquivalent`
- Added `WhenIsNullOrEquivalent`, `WhenIsNotNullOrEquivalent`, `WhenEqualsTo`, `WhenAny`, `WhenEmptyOrNull`

# What's NEW 2.1.1
- Added `Option` FluentType plus all of its FluentExtensions  (DoOptn, DoOptnForEach, OrOptn, MapOptn...)
- Added `Nothing` as base value, it can be used instead of void
- Added `Or` with Func as right parameter (evaluated only when the result is required)

# What's NEW 2.1.0
- Fixed `Outcome.Succes` typo
- Fixed `FluentContext.IsSuccesful` typo. 
This change impacts: `TryCatch.IsSuccesful`, `When.IsSuccesful`, `Outcome.IsSuccesful`


# What's NEW 2.0.1
- Added `DoWrap` and `DoWrapAsync` to quickly manage value types
- Added `Outcome<R,L>` to mimic **F#** `Result<'T,'TFailure>` (with Map and Bind functionalities) [[railway oriented programming](https://fsharpforfunandprofit.com/rop/)]

# What's NEW 2.0.0
- `Do` now **ALWAYS** returns the subject (even when called with a `Func`)
- Removed `Do` extension with a single `Action`/`Func`, left only the extension with `params[]` `Action`/`Func`
- Added `DoAsync` extension
- Changed `DoForAll` into `DoForEach`, added `DoForEachAsync`
- Changed `DoForAllMap` into `MapForEach`, added `MapForEachAsync`
- Removed `EqualsToAny` and `EqualsTo` (with a comparator as input), same as `EquivalentTo` or `EquivalentToAny`
- Added `EqualsToAnyAsync` (without a comparator as input)
- Added `MapAsync`
- Collapsed `Switch` and `SwitchMap` into `Switch`
- Added `SwitchAsync`
- Added `TryAsync` and `TryToAsync`
- Collapsed `Then(onSuccess, onFail)` and `ThenMap(onSuccess, onFail)` into `Then`
- Added `WhenAnyAsync`, `WhenAsync`

# FluentCoding

Set of functionalities to extend linq with more fluent capabilities
These functionalities can be combined together to fluently manipulate an object
The libriary provides new types and extension to work with base generic types and the new ones

### [FluentExtensions](#fluentextensions):
Methods that extend generic types (T, Task, Enumerable) to bring new functionalities
####  [`Do`](#do), [`Equals`](#equals), [`Is`](#is), [`Map`](#map), [`Or`](#or), [`Switch`](#switch)

### [FluentTypes](#fluenttypes):
Classes that implement new functionalities, and (when usefull) are extended with the functionalites by FluentExtension
####  [`When`](#when), [`Try`](#trycatch), [`Outcome`](#outcome), [`Optional`](#optional) 

### FluentExtension of FluentTypes:
Extensions for Optional type:
####  [`DoOptn`](#do), [`IsOptn`](#is), [`MapOptn`](#map), [`OrOptn`](#or), [`Switch`](#switch)


# FluentExtensions 
## explanations and examples


# Do 
### [Extension of generic type T]

Do something with/to an object and then returns the object itself:
 `Do`, `DoForEach`,`DoAsync`, `DoForEachAsync` 
 
**Null Safe** when the subject is null, nothing is done (and `null` is returned as output).  \
**NOTE:** the async version takes the assumption that `Task<T>` is not null 

### Do, DoAsync
When the `Do` subject is null it directly returns the `null` subject.

`Action` applies one or more actions to the subject and then returns the subject.
```csharp
identity.Do(_ => _.Name = "John");
//or
identity.Do(_ => _.Name = "John",
            _ => _.Surname = "Smith");
//or
identity.Do(_ =>
		   {
				_.Name = "John";
	            _.Surname = "Smith";
	            //[...]
           });
```
`Func` applies one or more functions to the subject and then returns the Subject.
```csharp
private TypeT UpdateIdentity(TypeT identity) { /* [...] do stuff*/ return updatedIdentity }

var identitiesList = new List<Identity>();
identitiesList.Add(identity.Do(UpdateIdentity));
```

`*Async`
```csharp
Task<Identity> identity = GetIdentityFromAPIAsync(...);
identity.DoAsync(_ => _.Name = "John").Result;
//or
identity.DoAsync(_ => _.Name = "John",
    	         _ => _.Surname = "Smith").Result;
```


### DoWrap, DoWrapAsync
Quick way to manipulate value types, the subject is wrapped inside the `Context.Subject` field.
Only the output will carry the changes, the input value will be left untouched
```csharp

public string GetPersonData(string pincode) => { /*[...]*/ return "John Smith"; }
public string GetNewArchiveId() => { /*[...]*/ return "_XXX"; }
string archivePersonData = GetPersonData("pincode")
					 		  .DoWrap(_ => _.Subject += GetNewArchiveId()); 
//archivePersonData  == "John Smith_XXX"
```

### DoForEach, DoForEachAsync
Applies one ore more actions or functions to each item in an `Enumerable` and then returns the `Enumerable` itself.
```csharp
IEnumerable<Identity> itentities = LoadIdentitiesDataBase(...);

//update the LastUpdate field for each item in identities
itentities.DoForEach(_ => _.LastUpdate = DateTime.Now); 

//or

//update the LastUpdate field and the LastUpdateAuthor for each item in identities
itentities.DoForEach(_ => _.LastUpdate = DateTime.Now,
                     _ => _.LastUpdateAuthor = "Admin");
```

`*Async`
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
### [Extension of generic type T]

Expands the equality functions: `EqualsToAny`, `EquivalentTo`, `EquivalentToAny`

**Null Safe:** When the subject is null it returns false  \
**NOTE:** the async version presumes that the `Task<T>` is not `null`


### EqualsToAny

```csharp
bool EqualityCheck(Identity p1, Identity p2) => p1.Pincode == p1.Pincode;

Identity people1 = ReadFromDataBase(...);
Identity people2 = ReadFromDataBase(...);
Identity people3 = ReadFromDataBase(...);
Identity people4 = ReadFromDataBase(...);

//The framework Equals is used in this case
people1.EqualsToAny(people2, people3, people4); //true or false
"XX".EqualsToAny("YY", "TT", "XX", "VV"); //true
```

### EquivalentTo - EquivalentToAny
```csharp
bool EqualityCheck(Identity p1, Identity p2) => p1.Pincode == p1.Pincode;

Tesla tesla = new Tesla() { ... };
Ferrari ferrari = new Ferrari() { ... };
Ferrari ferrari2 = new Ferrari() { ... };
Ferrari ferrari3 = new Ferrari() { ... };

tesla.EquivalentTo(ferrari, (t, f) => t.PlateNumber == f.PlateNumber); //true or false
tesla.EquivalentToAny((t, f) => t.PlateNumber == f.PlateNumber, ferrari, ferrari2, ferrari3); //true or false
```



# Is 
### [Extension of generic type T]

Functionalities: `Is`, `IsNullOrEquivalent`, `IsNotNullOrEquivalent`,

`IsNullOrEquivalent` and `IsNotaNullOrEquivalent` are **Null Safe**, when the subject is null returns true  \
`Is` is partially safe, the function/action is always executed so its logic must manage the subject being potentially `null`

### IsNullOrEquivalent

Handy shorthand method to check if something is `null` or an equivalent state. 
```csharp
string.Empty.IsNullOrEquivalent(); //true
null.IsNullOrEquivalent(); //true
" ".IsNullOrEquivalent(); //false
objectInstance.IsNullOrEquivalent(); //false
```
It exposes two ways to specify more options to check for `null` or equivalent state:
- **A)** By submitting an Action that set an implicit `IsNullOptions` object
- **B)** By submitting an instance of a `IsNullOptions` object

```csharp
//CASE A: submit an Action
"".IsNullOrEquivalent(_ => _.StringIsNullWhen = StringIsNullWhenEnum.Null); //false
"".IsNullOrEquivalent(_ => _.StringIsNullWhen = StringIsNullWhenEnum.NullOrEmpty); //true
"  ".IsNullOrEquivalent(_ => _.StringIsNullWhen = StringIsNullWhenEnum.Null); //false
"  ".IsNullOrEquivalent(_ => _.StringIsNullWhen = StringIsNullWhenEnum.NullOrEmptyOrWhiteSpaces); //true

//CASE B: submit an IsNullOptions instance
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
Applies a boolean predicate to an object and obtains the predicate result along with the subject. 
Can be combined with other functions from this library in a fluent way.

```csharp
Address address = new Address() { ... }; 
(var isSatisfied, var checkSubject) = address.Is(_ => _.Country == "ITA");

var result = address.Is(_ => _.LastUpdate > DateTime.Now.AddYears(-5));
if(result.IsSatisfied) 
   result.Subject; /*do something*/
```


# Map 
### [Extension of generic type T]
Converts a type into another one: `Map`, `MapForEach`,`MapAsync`, `MapForEachAsync`

**Null Safe:** when the subject is null, `default(T)` is returned  \
**NOTE1:** the *Async version presumes that the Task is not null  \
**NOTE2:** the *ForEach version will apply the Func/Action to the `null` item when the `enumerable` is not `null` and contains `null` values 

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
Returns an `Enumerable` with the result of all the calls to `Map(item)`
```csharp
IEnumerable<Car> cars = ReadCarsFromDataBase(...);
var carsSoftware = cars.MapForEach(ExtractSoftware);
//do something...
carsSoftware.Where(_ => _.Version >= 1.4).[...];
```
# Or 
### [Extension of generic type T]

Chooses whether to pick the object on the right or on the left, based on a predicate.
By default returns ***Left***  when not `null`  \
**Null Safe:** when the subject is `null`, ***Right*** is returned  
**NOTE:** the current version of `Or` works with 2 values.
  this means that `Function(something).Or(AnotherFunction(somethingElse))` will always evaluate both functions.
  
  ***In a future release I intend to expand **Or** to work also with functions, in order to allow the above case to evaluate only the really required part of the whole function.***
The `Or` accepts as predicates:  
- **bool**: `leftValue.Or(rightValue, bool boolValueFromContext)` 
- **Func\<bool\>**: `leftValue.Or(rightValue, Func<bool> predicateToEvaluate)` 
- **Func\<T, bool\>**: `leftValue.Or(rightValue, Func<T, bool> predicateToEvaluateOnTheLeftValue)` 
### Or
```csharp
var currentAddress = object.AddressDomicile.Or(object.AddressResidence);
var validData = object1.Or(object2, (subject)=> !subject.IsStillValid);
var mostRecentData = dataSource1.Or(dataSource2, (subject, orValue)=> orValue.LastUpdateTime > subject.LastUpdateTime);

//you can combine an Or cascade
var currentAddress =
		 object.AddressDomicile
		 .Or(object.AddressResidence)
		 .Or(object.AddressForeignResidence)
		 .Or("ADDRESS NOT AVAILABLE");
```

### OrIsEmpty [Extension of type string]
*(for strings only)*  \
Extends **Or** to manage an `Empty` string as `null` value
```csharp
string newAddress = null; //left string is null
string oldAddress = "address-value";
newAddress.Or(oldAddress); // returns oldAddress
newAddress.OrIsEmpty(oldAddress); // returns oldAddress

string newAddress = ""; //left string is empty
string oldAddress = "address-value";
newAddress.Or(oldAddress); // returns newAddress!!!
newAddress.Or(oldAddress, newAddr => string.IsNullOrEmpty(newAddr)); // returns oldAddress
newAddress.OrIsEmpty(oldAddress); // returns oldAddress
```

# Switch [Extension of generic type T]

Fluent version of the switch-case: `Switch`  \
It takes a **default** function, along with a list of `Tuple(predicateToCheck, FunctionToExecuteWhenMatched)`  \
The first `predicateToCheck` that returns true will run its binded function `FunctionToExecuteWhenMatched`.
When there aren't any matches, the **default** function is called
The **default** function and all the `FunctionToExecuteWhenMatched` functions must have the same output type.

The predicates from the `Switch` tuples, can be:
- **boolean**: 
`subject.Switch(Func<T, K> default, (bool whenPredicate, Func<T, K> mapActionWhenTrue)[] cases)`
- **Func\<bool\>**:
`subject.Switch(Func<T, K> default, (Func<bool> whenPredicate, Func<T, K> mapActionWhenTrue)[] cases)`
- **Func\<T, bool\>**:
`subject.Switch(Func<T, K> default, (Func<T, bool> whenPredicate, Func<T, K> mapActionWhenTrue)[] cases)`
	
### Switch 

Input and output types are the same T -> T
```csharp
Identity people = new Identity() { ... };
Identity ApiGetPeople(string pincode) { ... return people; }
Identity ApiGetPeopleAddress(people) { ... return peopleAddress; }

var updatedPeople =
people.Switch
(
    p => p, // -> Default case, applied when no predicate do match
    (
	  	p => p.LastUpdate < DateTime.Node.AddDays(-30), //the this predicate is true
		p => ApiGetPeople(p.Pincode)			//apply this function
    ),
    (
		p => p.LastUpdate < DateTime.Node.AddDays(-10),    //the this predicate is true
		p => p.Do(_ => _.Address = ApiGetPeopleAddress(p)) //apply this function
    )
)
```

### Switch
Change the output type from the subject type to the type from the function output: `T -> K`
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


# FluentTypes


# When 
### [Extension of generic type T]
Applies one or more checks on the Subject and then applies an Action or Function only when all the checks are satisfied

## When (initialize When base class)

The when predicate can be:
- **bool**: `subject.When(bool boolValueFromContext)` 
- **Func\<bool\>**: `subject.When(Func<bool> predicateToEvaluate)` 
- **Func\<T, bool\>**: `subject.When(Func<T, bool> predicateToEvaluateOnSubject)` 
- **NullCheck**: `subject.WhenIsNullOrEquivalent()` 
- **NotNullCheck**: `subject.WhenIsNotNullOrEquivalent()` 
- **Equality**: `subject.WhenEqualsTo(comparable)` 

The `result` is `When<T>`:
- result.IsSuccessful: `true`/`false` based on the predicate result
- result.Subject: the `When` subject 

```csharp
var car = LoadCarData(...);

When<Car> result = car.When(c => c.Type == "Ferrari");
result.IsSuccess; // the predicate result
result.Subject; //the predicate subject

When<Car> result = car.WhenIsNullOrEquivalent();
result.IsSuccess; // false the predicate result
result.Subject; // car the predicate subject
```

### [Extension of generic type IEnumerable\<T\>]
## WhenAny (initialize When base class)
- **Func\<T, bool\>**: `subject.WhenAny(Func<T, bool> whenCondition)` 
- **Null or Empty Check**: `subject.WhenEmptyOrNull()` 
- **NotNullCheck**: `subject.WhenAny()` 

```csharp
var cars = LoadCarsData(...);

When<Car> result = cars.WhenAny();
result.IsSuccess; // the predicate result
result.Subject; //the predicate subject

When<Car> result = cars.WhenEmptyOrNull();
result.IsSuccess; // the predicate result
result.Subject; // the predicate subject
```

## When.Then
**Applies a Func olny when the condition is true**  \
(Input and output types must be the same T -> T)
```csharp
var car = LoadCarData(...);
c.Insurance = InsuranceType.LowBudget;

car.When(c => c.Type == "Ferrari")   
   .Then(c => c.Insurance = InsuranceType.Luxury);
```

**Applies the first Func when the condition is true and the second one when the condition is false**  \
Both functions must return the same type (they can change the output type T->K)  \
`subject.When(Func<T,bool>/Func<bool>/bool).Then(Func<T,K> whenTrue, Func<T,K> whenFalse)`
	
```csharp
var car = LoadCarData(...);

car.When(c => c.Type == "Ferrari")   
   .Then(ferrari    => ferrati.Insurance = InsuranceType.Luxury,
		 notFerrari => notFerrari.Insurance = InsuranceType.LowBudget);

//or
Ferrari CreateNewFerrari(Car car) {  /*[...] do something */ return newFerrari; }
Ferrari UpdateFerrari(Car ferrari) {  /*[...] do something */ return updatedFerrari; }

car.When(c => c.Type == "Ferrari")   
   .Then(UpdateFerrari,
		 CreateNewFerrari);
```

## When.ThenAnd
Allows to concatenate more than one `Then` on the subject.
The `ThenAnd` output is the `When` context.
In order to close a chain of `ThenAnd`, the last one should be a `Then` (that will unwrap the context)
```csharp
var car = LoadCarData(...);
c.Insurance = InsuranceType.LowBudget;

car.When(c => c.Type == "Ferrari")   
   .ThenAnd(c => c.Insurance = InsuranceType.Luxury)
   .ThenAnd(c => c.Color = "Red")
   .Then(c => c.Available = true)
```


## When.OrWhen.Then
Applies one or more check conditions on the subject, in **or**  with the current `IsSuccessful` state 
```csharp
var car = LoadCarData(...);
c.Insurance = InsuranceType.LowBudget;

car.When(c => c.Type == "Ferrari")
   .OrWhen(c => c.Type == "Lamborghini")
   .Then(c => c.Insurance = InsuranceType.Luxury);
```



## When.OrWhen.AndWhen.Then
Applies one or more check conditions on the subject, in **or** with the current `IsSuccessful` state.  \
 Then applies one or more check conditions on the subject, in **and** with the current `IsSuccessful` state.  \
Once `AndWhen` is used  the `OrWhen` is not available anymore
```csharp
var car = LoadCarData(...);
c.Insurance = InsuranceType.LowBudget;

car.When(c => c.Type == "Ferrari")
   .OrWhen(c => c.Type == "Lamborghini")
   .AndWhen(c => c.MarketPrice >= 180000)
   .Then(c => c.Insurance = InsuranceType.Luxury);
```

## When.ThenMap
Maps the subject when the condition is satisfied, if not it returns the subject. 
Assuming that the `ThenMap` function is of type `Func<T,K>`, the result is a tuple: `(K OnTrue, T Subject)`
```csharp
var car = LoadCarData(...);
Part[] ScrapCar(Car car) { /*[...] do something*/  return parts; }


var result = car.When(c => c.Year < 1990)      
                .ThenMap(ScrapCar);
result.OnTrue;  //is Part[] when the condition is true, null otherwise
result.Subject; //is the input car
```



# TryCatch 
### [Extension of generic type T]
Inline wraps methods for the Try{}Catch{}:  `Try`, `TryTo`, `TryAsync`, `TryToAsync`

## Try (initialize TryCatch base class)
Applies a `Func<T,K>` on the subject `T` and returns a `Context<T>` with all the information.

`var result = subject.Try(Func<T,K> functToTry)`
Where `result` is of type `Context<T>` :
- `result.IsSuccessful`: **false** if an exception is raised from  `Func<T,K>` , **true** otherwise
- `result.Subject`:  The instance of the subject `T`
- `result.Result`:  The result of the `Func<T,K>` if `Context.IsSucessful`, `default(K)` otherwise
- `result.Error`:  The `Exception` raised from `Func<T,K>` if any, `default(Exception)` otherwise

`Try` also allows to specify a `Func<S, Exception, E>`  to manage the error with a custom type  \
`var result = subject.Try(Func<T,K> functToTry, Func<S, Exception, E> onError)`  

In this case `result.Error` contains: 
- the result of  `Func<S, Exception, E>` when *functToTry* raise an exception
- `default(E)` otherwise
```csharp
Car LoadCarData(string licensPlate) { /*[...] do something*/ return car; }

var tryResult = "license-plate".Try(LoadCarData);
tryResult.IsSuccessful; //true or false
tryResult.Subject; //the input string 'license-plate'
tryResult.Result; //the Car object loader
tryResult.Error; //the Exception raised when loading the car data
```

```csharp
Car LoadCarData(string licensePlate) { /*[...] do something*/ return car; }
CustomError ManageException(String licensePlate, Exception e) => new CustomError(e.Messge, licensePlate);

var tryResult = "carLicensePlate".Try(LoadCarData, ManageException);
tryResult.IsSuccessful; //true or false
tryResult.Subject; //the input string licensePlace
tryResult.Result; //the Car object loader
tryResult.Error; //the CustomError returned by ManageException
```

## TryCatch.OnSuccess or TryCatch.OnFail
Once the `Try` has been executed, do something else on success or on fail as specified.
`var result = subject.Try(Func<S,R> funcToTry).OnSuccess(Func<R,R1> onSuccess)`
The `result` is a tuple `(R1 Success, TryCatch<S, R, E> TryCatch)`

`var result = subject.Try(Func<S,R> funcToTry).OnFail(Func<S,E,E1> whenException)`
The `result` is a tuple `(E1 Fail, TryCatch<S, R, E> TryCatch)`
```csharp
Car LoadCarData(string licensPlate) { /*[...] do something*/ return car; }
List<CarComponent> DisassembleCar(Car car) { /*[...] do something*/ return carComponents; }

(var Components, var tryCatchContext) = "xxxxx".Try(LoadCarData)
                                               .OnSuccess(DisassembleCar);
//"Components" variable contains:
// - the DisassembleCar result ONLY WHEN no exception is raised from LoadCarData, 
// - default of List<CarComponent> otherwise
//"tryCatchContext" variable is never null and contains the TryCatch class from the previous example
```
```csharp
Car LoadCarData(string licensPlate) { /*[...] do something*/ return car; }
CustomError ManageException(String licensePlate, Exception e) => new CustomError(e.Messge, licensePlate);

List<Car> availableCar = new List<Car>();
(var error, var tryCatchContext) = "xxx-yyy-xxx".Try(plate => availableCar.Add(LoadCarData(plate))
                                                .OnFail(ManageException);                      
//"error" variable contains:
// - the CustomError from ManageException ONLY WHEN an exception is raised from 'Try'
// - default of CustomError otherwise
//"tryCatchContext" variable is never null and contains the TryCatch class from the previous example
```

## TryCatch.Then
Once the `Try` has been executed, specify what to do when Successful or when on Error

Subject.`Try(Func<T,K> funcToTry)`
.`Then(Func<K, K1> funcWhenOk ,Func<K, Exception, K1> funcWhenOnError)`
```csharp
Car LoadCarData(string licensPlate) { /*[...] do something*/ return car; }
bool AddCarToStock(Car car) { /*[...] do something*/ return true; }
bool TraceCarError(string plate, Exception e) { /*[...] do something*/ return true; }

CustomError ManageException(String licensePlate, Exception e) => new CustomError(e.Messge, licensePlate);

"xxxxx".Try(LoadCarData)
       .Then(AddCarToStock, TraceCarError);                       
```

## TryTo
Tries to do something or manages the exception.
The output type can differ from the subject input type.  \
Given a subject of type `T`, it takes 2 functions :
 - **Func<T, K>** function wrapped from the TryCatch
 - **Func<T, E, K>** function is executed only when TryTo raises an exception; it takes the Subject and the Exception object and returns K

`subject.TryTo(Func<S,R> tryTo, Func<S,Exception,R> onError)`

```csharp
var date = "2022-12-29".TryTo(DateTime.Parse, (subject, ex) => DateTime.MinValue);
```



# Outcome
Mimics [railway oriented programming](https://fsharpforfunandprofit.com/rop/) concept of  functional programming.
Similar to `Result<L,R>` of **F#**

### Outcome.Map
`Outcome<R, F>.Map` takes two Functions: 
- **A**  `Func<R, R1>`
- **B** `Func<F, F1>` 

If **Outcome**  is successful applies **A** to `Outcome.Succes` field and returns a new `Outcome<R1, F>` 
If **Outcome** is **not** successful applies **B** to `Outcome.Failure` field and returns a new `Outcome<R, F1>`

```csharp
Outcome<Data, Error> ReadUserFromDataBase(string userId) {/*[...]*/ return userDataOrErrorOutcome; }

IPrincipals GetUserPrincipals(Data userData) {/*[...]*/ return userPrincipals; }
string LogErrorAndReturnSummary(Error error) {/*[...]*/ return error.SummaryDescription(); }

var outcome = ReadUserFromDataBase(123)
			     .Map(success => GetUserPrincipals(success),
   	  		          failure => LogErrorAndReturnSummary(success));
//Outcome<IPrincipals , string> outcome:
// - If successful:
//   - outcome.Success will contain the IPrincipals data
//   - outcome.Failure is null

// - If NOT successful:
//   - outcome.Success is null
//   - outcome.Failure will contain the summary error and the error is Logged somewhere

```


### Outcome.MapFailure, Outcome.MapSuccess
Similar to `Outcome.Map` but allows to manage only a specific state: `IsSuccessful` or `!IsSuccessful`.
You can combine more **MapSuccess** in a cascade, these will be executed only when the state **IsSuccessful = true**, otherwise they will only carry forward the `Failure` field.

```csharp
Outcome<Data, Error> ReadUserFromDataBase(string userId) {/*[...]*/ return userDataOrErrorOutcome; }

IPrincipals GetUserPrincipals(Data userData) {/*[...]*/ return userPrincipals; }
string LogErrorAndReturnSummary(Error error) {/*[...]*/ return error.SummaryDescription(); }

var outcome = ReadUserFromDataBase(123)
		   	      .MapFailure(failure => LogErrorAndReturnSummary(success));				
//Outcome<Data, String> outcome:
// - If successful:
//   - outcome.Success will contain the userdata Data
//   - outcome.Failure is null

// - If NOT successful:
//   - outcome.Success is null
//   - outcome.Failure will contains the summury error and such error is logged 


outcome = ReadUserFromDataBase(123)
		   	      .MapSuccess(success => GetUserPrincipals(success));
//Outcome<IPrincipals , Error> outcome:
// - If successful:
//   - outcome.Success will contain the IPrincipals for the loaded user
//   - outcome.Failure is null

// - If NOT successful:
//   - outcome.successful is null
//   - outcome.Failure will contain the Error information object


//Example of cascade calls
ReadUserFromDataBase(123) // Outcome<Data, Error>
		.MapSuccess(data => GetUserPrincipals(data )) // Outcome<IPrincipals, Error>
		.MapSuccess(principal => GetAuthorizedServices(principal))  // Outcome<List<IServices>, Error>
		.MapSuccess(services => services.FirstOrDefault(_ => _.ServiceName == "ServiceToSearch")) // Outcome<IServices, Error>

/*
In the example above, when ReadUserFromDataBase does not fail, the MapSuccess chain will end with an Outcome<IService, Error> where:
- outcome.IsSuccessful is true
- outcome.Success is not null and contains the IService. 
- outcome.Failure is null
  
If the database ReadUserFromDataBase fails, the MapSuccess chain will only bring forward the Error and end with an Outcome<IService, Error> where:
- outcome.IsSuccessful is false
- outcome.Success is null and contains the IService. 
- outcome.Failure is the Error from the first call 'ReadUserFromDataBase'
*/
```

### Outcome.Bind
Like the `Outcome.Map` but each function returns a new `Outcome<S, F>`, so each call to `Bind` can switch from **Success** to **Failure** track (or the other way around, even if usually once you end in the failure track you keep that status)

```csharp
Outcome<Data, string> ReadUserFromDataBase(string userId) {/*[...]*/ return userDataOrErrorOutcome; }
Outcome<IPrincipals, Error> GetUserPrincipals(Data userData) {/*[...]*/ return userPrincipals; }
Outcome<IPrincipals, Error> ProcessErrorInformation(string error) {/*[...]*/ return errorDetails }

Outcome<Data, Error> GetAuthorizedServices(Data userData) {/*[...]*/ return userPrincipals; }


var outcome = ReadUserFromDataBase(123)
				.Bind(success => GetUserPrincipals(success),
	  	  	   	      failure => ProcessErrorInformation(failure));
//ReadUserFromDataBase -- Outcome<IPrincipals , Error>:
// - If successful:
//   - outcome.Success will contain the user Data
//   - outcome.Failure is null
// - If NOT successful:
//   - outcome.Success is null
//   - outcome.Failure will contain the error string

//GetUserPrincipals -- Outcome<IPrincipals , string>:
// - If successful:
//   - outcome.Success will contain the IPrincipals data
//   - outcome.Failure is null
// - If NOT successful:
//   - outcome.successful is null
//   - outcome.Failure will contain the Error returned while fetching the principals

//ProcessErrorInformation -- Outcome<IPrincipals , string>:
// - If successful:
//   - outcome.Success will contain the IPrincipals data
//   - outcome.Failure is null
// - If NOT successful:
//   - outcome.Success is null
//   - outcome.Failure will contains the Error object converted from the string error from database
```


### Outcome.BindSuccess
To an `Outcome<S, F>` apply a function of type `S -> Outcome<S1, F>`
You can chain one ore more **BindSuccess**: as soon as one fails, all the others will only bring the `Failure` result at the end of the chain.

```csharp
Outcome<Data, string> ReadUserFromDataBase(string userId) {/*[...]*/ return userDataOrErrorOutcome; }
Outcome<IPrincipals, Error> GetUserPrincipals(Data userData) {/*[...]*/ return userPrincipals; }
Outcome<IServices, Error> GetAuthorizedServices(Data userData) {/*[...]*/ return userPrincipals; }


var outcome = ReadUserFromDataBase(123)
			     .BindSuccess(success => GetUserPrincipals(success))
  			     .BindSuccess(success => GetAuthorizedServices(success));

//when all the bind are successful the result will be		
//Outcome<IServices, Error> 
//   - outcome.Success will contain the IServices Data
//   - outcome.Failure is null

//if at least one bind fails the result will be
//Outcome<IServices, Error> 
//   - outcome.Success is null
//   - outcome.Failure will contain the Error from the Bind that failed (that can be any one of the 3 functions called)
```

### Outcome.BindFailure
Same logic of  `Outcome.BindSuccess` but applied to the Failure part of the outcome.
Usually, only one is called at the bottom of a BindSuccess chain



# Optional
Wraps an object in Some when not null or None when null.
Similar to `Option` of **F#**, this class avoid to use null references.



## Initialize Optional type

``` csharp
var opt = Optional<Car>.Some(car);
var opt = car.ToOptional();
```

## IsSome or IsNone
Check if the optional value is null or not

``` csharp
var something = new Something();
var optSomething = something.ToOptional();

optSomething.IsSome(); //true the object is not null
optSomething.IsNone(); //false the object is not null
optSomething.Subject; //something

var something = null;
var optSomething = something.ToOptional();
optSomething.IsSome(); //false the object is null
optSomething.IsNone(); //true the object is null
optSomething.Subject; // null
```

## WhenSome or WhenNone
`WhenSome` Apply an action to the Option subject when IsSome()
`WheNone` Apply a generic action when the subject IsNone()

## Optional and Do, Map, Is, Or, Switch FluentExtensions
Inherit almost all the Fluent extensions with the specific Opt suffix.
`DoOptn`, `MapOptn`, `SwitchOptn`...
All the extension check when Optional\<T\>.None() and manage it properly with the context