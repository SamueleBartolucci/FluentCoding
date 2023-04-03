using FluentAssertions;
using System.Diagnostics.CodeAnalysis;


namespace FluentCoding.Test.FluentTypes.When
{
    [ExcludeFromCodeCoverage]
    public class When_ThenAnd_Func_T_T_Tests
    {
        static WhenAnd<T> WhenContext<T>(T obj, bool isTrue) => obj.When(isTrue);


        [TestCase(true)]
        [TestCase(false)]
        public void Then_Func_T_T(bool trueCondition)
        {
            WhenContext(Test.NewT, trueCondition)
                .ThenAnd(_ => _.Do(x => x.TDesc = "."))
                .ThenAnd(_ => _.Do(x => x.TDesc += "."))
                .Then(_ => _.Do(x => x.TDesc += "."))
                .TDesc
                .Should().Be(trueCondition ? "..." : Test.NewT.TDesc);
        }

    }
}
