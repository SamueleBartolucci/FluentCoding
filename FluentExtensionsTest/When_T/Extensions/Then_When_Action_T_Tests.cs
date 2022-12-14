using FluentAssertions;
using FluentCoding;

using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.When_T.Extensions
{
    [ExcludeFromCodeCoverage]
    public class Then_When_Action_T_Tests
    {
        static WhenAnd<T> WhenContext<T>(T obj, bool isTrue) => obj.When(isTrue);
        [TestCase(true)]
        [TestCase(false)]
        public void Then_Func_T_T(bool trueCondition)
        {
            WhenContext(Test.T, trueCondition)
                .Then(_ => _.DescType = Test.Done)
                .Should().BeEquivalentTo(trueCondition ? Test.TDone : Test.T);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Then_TrueAndFalse_Func_T_T(bool trueCondition)
        {
            WhenContext(Test.T, trueCondition)
                .Then(_ => _.DescType = Test.Done, _ => _.DescType = Test.NotDone)
                .Should().BeEquivalentTo(trueCondition ? Test.TDone : Test.TNotDone);
        }

    }
}
