using FluentAssertions;
using FluentCoding;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace FluentCodingTest
{
    [ExcludeFromCodeCoverage]
    internal static class Test
    {

        public static string LEFT => "left";
        public static string RIGHT => "right";
        public static string DONE => "done";
        public static string NOT_DONE => "not-done";

        private static TType GetTType(string typeDesc = nameof(NewT)) => new TType() { TDesc = typeDesc };
        private static KType GetKType(string typeDesc = nameof(NewK)) => new KType() { KDesc = typeDesc };

        public static TType NewTLeft => GetTType(LEFT);
        public static TType NewTRight => GetTType(RIGHT);
        public static KType NewKLeft => GetKType(LEFT);
        public static KType NewKRight => GetKType(RIGHT);
        public static TType NewTDone => GetTType(DONE);
        public static TType NewTNotDone => GetTType(NOT_DONE);
        public static KType NewKDone => GetKType(DONE);
        public static KType NewKNotDone => GetKType(NOT_DONE);

        public static TType NewT => GetTType();
        public static KType NewK => GetKType();


        public static IEnumerable<EnumType> GetEnumerable<EnumType>(int howMany) where EnumType : new()
        { 
            var list = new List<EnumType>();
            while (list.Count < howMany)
            {
                if (typeof(EnumType) == typeof(TType))
                    list.Add(NewT.As<EnumType>());
                else if (typeof(EnumType) == typeof(KType))
                    list.Add(NewK.As<EnumType>());
                else if (typeof(EnumType) == typeof(DateTime))
                    list.Add(DateTime.Now.As<EnumType>());
                else
                    list.Add(new EnumType());
            }

            return list;
        }
        public static T GetDefault<T>() => default;        
        public static T RaiseException<T>() => throw new Exception();
        public static Task<T> ToTask<T>(this T input) => Task.FromResult(input);

        public static Exception EException = new Exception();

        public static Func<bool> NullFunc = null;
        public static Func<bool> NotNullFunc = () => true;

    }
}
