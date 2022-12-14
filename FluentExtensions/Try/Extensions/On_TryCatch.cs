using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FluentCoding
{
    public static class On_TryCatch
    {        
        public static (TRES Success, TryCatch<S, R> TryCatch) OnSuccess<S, R, TRES>(this TryCatch<S, R> _, Func<R, TRES> whenOk) => (whenOk(_.Result), _);
        public static (TryCatch<S, R> TryCatch, TERR Fail) OnFail<S, R, TERR>(this TryCatch<S, R> _, Func<S, Exception, TERR> whenException) => (_, whenException(_.Subject, _.Error));
    }
}
