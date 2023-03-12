using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCoding
{
    public class IsNullOptions
    {
        /// <summary>
        /// Return a new IsNullOptions with the value StringIsNullWhen = StringIsNullWhenEnum.Null
        /// </summary>
        public static IsNullOptions StringIsNullWhenNull => new IsNullOptions() { StringIsNullWhen = StringIsNullWhenEnum.Null };

        /// <summary>
        /// Return a new IsNullOptions with the value StringIsNullWhen = StringIsNullWhenEnum.NullOrEmpty
        /// </summary>
        public static IsNullOptions StringIsNullWhenNullOrEmpty => new IsNullOptions() { StringIsNullWhen = StringIsNullWhenEnum.NullOrEmpty };

        /// <summary>
        /// Return a new IsNullOptions with the value StringIsNullWhen = StringIsNullWhenEnum.NullOrEmptyOrWhiteSpaces
        /// </summary>
        public static IsNullOptions StringIsNullWhenNullOrEmptyOrWhiteSpaces => new IsNullOptions() { StringIsNullWhen = StringIsNullWhenEnum.NullOrEmptyOrWhiteSpaces };


        /// <summary>
        /// Specify when a string is considered equivalent to null
        /// </summary>
        public StringIsNullWhenEnum StringIsNullWhen { get; set; } = StringIsNullWhenEnum.NullOrEmpty;
        //to do: add more option for further types like 'first enum is null', 0 is null etc
    }
}
