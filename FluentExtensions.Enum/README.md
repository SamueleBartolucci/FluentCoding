# FluentCoding.Enum

Add a set of functionalities to manage Enums

## GetEnumDescription
Extract a predefined description for the enum instead of its Name

```csharp
 enum WarningsDomain
{
    [System.ComponentModel.Description("Data not found")]
    Warning01,
    Warning02,
    [System.ComponentModel.Description("Data corrupted")]
    Warning03
}

WarningsDomain.Warning01.GetEnumDescription(); // => "Data not found"
WarningsDomain.Warning02.GetEnumDescription(); // => "Warning02"
WarningsDomain.Warning01.GetEnumDescription(); // => "Data corrupted"

```
