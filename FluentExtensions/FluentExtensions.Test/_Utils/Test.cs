using FluentAssertions;
using FluentCoding;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace FluentCoding.Test
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


        public static IEnumerable<EnumOfType> GetEnumerable<EnumOfType>(int howMany) where EnumOfType : new()
        { 
            var list = new List<EnumOfType>();
            while (list.Count < howMany)
            {
                if (typeof(EnumOfType) == typeof(TType))
                    list.Add(NewT.As<EnumOfType>());
                else if (typeof(EnumOfType) == typeof(KType))
                    list.Add(NewK.As<EnumOfType>());
                else if (typeof(EnumOfType) == typeof(DateTime))
                    list.Add(DateTime.Now.As<EnumOfType>());
                else
                    list.Add(new EnumOfType());
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
