using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCoding
{
    /// <summary>
    /// Used by IsNullOrEquivalend to check a string status
    /// </summary>
    public enum StringIsNullWhenEnum
    { 
        Null,
        NullOrEmpty,
        NullOrEmptyOrWhiteSpaces
    }
}
