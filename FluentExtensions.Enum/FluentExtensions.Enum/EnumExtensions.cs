
using System;
using System.ComponentModel;
using System.Linq;

namespace FluentCoding.Enum_
{
    public static class EnumExtensions
    {

        public static string GetEnumDescription<T>(this T enumValue)
           where T : Enum, IConvertible
        {
            if (!typeof(T).IsEnum)
                return null;

            var description = enumValue.ToString();
            var fieldInfo = enumValue.GetType().GetField(description);


            return enumValue.GetType()
                            .GetField(description)
                            .GetCustomAttributes(typeof(DescriptionAttribute), true)                                                                         
                            .When(_ => _.Any())
                            .ThenMap(_ => ((DescriptionAttribute)_.First()).Description,
                                     _ => description);        }
    }
}