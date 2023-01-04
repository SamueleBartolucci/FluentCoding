using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCoding
{
    public class IsNullOptions
    {
        public static IsNullOptions StringIsNullWhenNull => new IsNullOptions() { StringIsNullWhen = StringIsNullWhenEnum.Null };
        public static IsNullOptions StringIsNullWhenNullOrEmpty => new IsNullOptions() { StringIsNullWhen = StringIsNullWhenEnum.NullOrEmpty };
        public static IsNullOptions StringIsNullWhenNullOrEmptyOrWhiteSpaces => new IsNullOptions() { StringIsNullWhen = StringIsNullWhenEnum.NullOrEmptyOrWhiteSpaces };



        public StringIsNullWhenEnum StringIsNullWhen { get; set; } = StringIsNullWhenEnum.NullOrEmpty;
        //to do: add more option for further types like 'first enum is null', 0 is null etc
    }
}
