using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCoding
{
    public class IsNullOptions
    {
        public bool EmptyStringIsNull { get; set; } = true;
        public bool EmptyOrWhiteSpacesIsNull { get; set; } = false;
        //to do: add more option for further types like 'first enum is null', 0 is null etc
    }
}
