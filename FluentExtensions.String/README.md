# FluentCoding.String

Add a set of functionalities to manipulate strings

## PrependWhen
Allow to prepend ad item into a IEnumerable<string> when the predicate is satisfied

```csharp
var IEnumerable<string> BuildCsvHeader() { /* do something  [...]*/ return csvHeader; }
var IEnumerable<string> BuildCsvContent() { /* do something  [...]*/ return csvContent; }

var IEnumerable<string> BuildCsv(bool includeHeader)
{
    BuildCsvContent()
    .PrependWhen(BuildCsvHeader(), includeHeader)
}

var IEnumerable<string> BuildCsv(bool includeHeader, int currentFileNumber)
{
    BuildCsvContent()
    .PrependWhen(BuildCsvHeader(), () => currentFileNumber > 1)
}
```

# Concatenate
Add a small set of tools to concatanate string with a bit of logic.
For all the following methods the concatenation is enabled only when the base value is not null or default

### `ConcatLeftToAll`, `ConcatRightToAll`
Take an IEnumerable<string> ad append to each item the input string

```csharp
 internal static string ToCsv(this XElement node, string csvChar) => { /* do something [...]*/ return csvNode;}
 
 internal static string MainNodeToCsv(this XElement rootElement, string csvChar) =>
    rootElement.DescendantsAndSelf("Main").First().ToCsv(csvChar)

 static IEnumerable<string> BuildCsv(XElement rootElement, string csvChar, bool includeHeader, string externalReference) =>
    string.Join(csvChar, externalReference, rootElement.MainNodeToCsv(csvChar))
          .ConcatLeftToAll(rootElement.ContentNodesToCsv(csvChar), csvChar)
          .PrependWhen(GetCsvHeader(csvChar), () => includeHeader);
```
```csharp
List<string> coordinates = new List<string> ("33.21338, 2.71403", "", "7.40338, 22.10301")
var coordinateDescriptions = coordinates.ConcatLeftToAll("Decimal degrees (DD)", " -> ");
/* result:
coordinateDescriptions:
{
    "Decimal degrees (DD) -> 33.21338, 2.71403", 
    "", 
    "Decimal degrees (DD) -> 7.40338, 22.10301"
}
*/
```
### `ConcatRightToWhenWithValue`, `ConcatLeftToWhenWithValue`
Join an input string with the specified value, when the input is not null or default

```csharp
 //Create the address only when the base info 'street-name' is available
 public string GetFullAddress(XPathNavigator addressXmlSource) =>
     addressXmlSource.GetAttribute("street-name")
        .ConcatLeftToWhenWithValue(addressXmlSource.GetAttribute("street-number"))
        .ConcatLeftToWhenWithValue(addressXmlSource.GetAttribute("province"));
```

### `ConcatWhenWithValue`
Join an input string with a left and right string when the input has value

```csharp
 //Create the province description only when the provice is available: 
 //Example: 
 //output can be: "Bologna (BO)" or "Bologna" 
 //but not "Bologna ()" or "()"
 public string GetFullAddress(XPathNavigator addressXmlSource) =>
     addressXmlSource.GetAttribute("province-name")
        .ConcatLeftToWhenWithValue(
            addressXmlSource.GetAttribute("province-name-short")
            .ConcatWhenWithValue("(", ")")
        );
```

