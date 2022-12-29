using FluentCoding;
using System.Diagnostics.CodeAnalysis;



namespace FluentCodingTest
{
    [ExcludeFromCodeCoverage]
    internal static class Test
    {
        private static TypeT _instanceTypeT = new TypeT();
        private static TypeK _instanceTypeK = new TypeK();

        public static string Left => "left";
        public static string Right => "right";
        public static string Done => "done";
        public static string NotDone => "not-done";

        public static TypeT TypeTSingleton => _instanceTypeT;
        public static TypeK TypeKSingleton => _instanceTypeK;
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
        public static ApplicationException XException = new ApplicationException();

        public static Func<bool> NullFunc = null;
        public static Func<bool> NotNullFunc = () => true;

        public static (bool IsSatisfied, TypeT Subject) SatisfiedT => (true, T);
        public static (bool IsSatisfied, TypeK Subject) SatisfiedK => (true, K);
        public static (bool IsSatisfied, TypeT Subject) NotSatisfiedT => (false, T);
        public static (bool IsSatisfied, TypeK Subject) NotSatisfiedK => (false, K);


        public static (TypeT Source, TypeT Result, Exception Error) TryTTE_OK => (T, T, null as Exception);
        public static (TypeT Source, TypeT Result, Exception Error) TryTTE_Exception => (T, GetDefault<TypeT>(), EException);


        public static (TypeT Source, TypeK Result, Exception Error) TryTKE_OK => (T, K, null as Exception);
        public static (TypeT Source, TypeK Result, Exception Error) TryTKE_Exception => (T, GetDefault<TypeK>(), EException);

    }
}
