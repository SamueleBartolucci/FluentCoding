using FluentCoding;
using System;
using System.Diagnostics.CodeAnalysis;



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


        public static T GetDefault<T>() => default(T);
        public static T GetException<T>() => throw new Exception();

        public static Exception EException = new Exception();

        public static Func<bool> NullFunc = null;
        public static Func<bool> NotNullFunc = () => true;

    }
}
