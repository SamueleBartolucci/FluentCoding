using FluentAssertions;
using FluentCoding;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.When_T
{
    [ExcludeFromCodeCoverage]
    public class When_ThenAnd_Func_T_T_Tests
    {
        static WhenAnd<T> WhenContext<T>(T obj, bool isTrue) => obj.When(isTrue);


        [TestCase(true)]
        [TestCase(false)]
        public void Then_Func_T_T(bool trueCondition)
        {
            WhenContext(Test.T, trueCondition)
                .ThenAnd(_ => _.Do(x => x.DescType = "."))
                .ThenAnd(_ => _.Do(x => x.DescType += "."))
                .Then(_ => _.Do(x => x.DescType += "."))
                .DescType
                .Should().Be(trueCondition ? "..." : Test.T.DescType);
        }

    }
}
