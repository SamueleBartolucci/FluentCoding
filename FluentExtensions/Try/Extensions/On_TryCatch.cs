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
        public static (TRES Success, TryCatch<S, R, E> TryCatch) OnSuccess<S, R, E, TRES>(this TryCatch<S, R, E> _, Func<R, TRES> whenOk)
            => (_.IsSuccesful ? whenOk(_.Result) : default(TRES), _);

        public static (TERR Fail, TryCatch<S, R, E> TryCatch) OnFail<S, R, E, TERR>(this TryCatch<S, R, E> _, Func<S, E, TERR> whenException)
            => (!_.IsSuccesful ? whenException(_.Subject, _.Error) : default(TERR), _);
    }
}
