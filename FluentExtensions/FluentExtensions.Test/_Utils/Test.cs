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

        public static string Left => "left";
        public static string Right => "right";
        public static string Done => "done";
        public static string NotDone => "not-done";

        private static TypeT GetTypeT(string typeDesc = nameof(T)) => new TypeT() { DescType = typeDesc };
        private static TypeK GetTypeK(string typeDesc = nameof(K)) => new TypeK() { DescType = typeDesc };

        public static TypeT TLeft => GetTypeT(Left);
        public static TypeT TRight => GetTypeT(Right);
        public static TypeK KLeft => GetTypeK(Left);
        public static TypeK KRight => GetTypeK(Right);
        public static TypeT TDone => GetTypeT(Done);
        public static TypeT TNotDone => GetTypeT(NotDone);
        public static TypeK KDone => GetTypeK(Done);
        public static TypeK KNotDone => GetTypeK(NotDone);

        public static TypeT T => GetTypeT();
        public static TypeK K => GetTypeK();


        public static IEnumerable<EnumType> GetEnumerable<EnumType>(int howMany) where EnumType : new()
        { 
            var list = new List<EnumType>();
            while (list.Count < howMany)
            {
                if (typeof(EnumType) == typeof(TypeT))
                    list.Add(T.As<EnumType>());
                else if (typeof(EnumType) == typeof(TypeK))
                    list.Add(K.As<EnumType>());
                else if (typeof(EnumType) == typeof(DateTime))
                    list.Add(DateTime.Now.As<EnumType>());
                else
                    list.Add(new EnumType());
            }

            return list;
        }
        public static T GetDefault<T>() => default(T);        
        public static T GetException<T>() => throw new Exception();
        public static Task<T> ToTask<T>(this T input) => Task.FromResult(input);

        public static Exception EException = new Exception();

        public static Func<bool> NullFunc = null;
        public static Func<bool> NotNullFunc = () => true;

    }
}
