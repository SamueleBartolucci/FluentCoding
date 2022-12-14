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

        public static (TRES Success, TERR Fail) Then<S, R, TRES, TERR>(this TryCatch<S, R> _, Func<R, TRES> whenOk, Func<S, Exception, TERR> whenOnException) => (whenOk(_.Result), whenOnException(_.Subject, _.Error));        
    }
}
