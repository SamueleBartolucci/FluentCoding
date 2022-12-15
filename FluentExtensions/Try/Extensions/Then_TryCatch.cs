using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FluentCoding
{
    public static class Then_TryCatch
    {

        public static (TRES Success, TERR Fail) Then<S, R, E, TRES, TERR>(this TryCatch<S, R, E> _, Func<R, TRES> whenOk, Func<S, E, TERR> whenOnException) 
            => (whenOk(_.Result), whenOnException(_.Subject, _.Error));      
    }
}
