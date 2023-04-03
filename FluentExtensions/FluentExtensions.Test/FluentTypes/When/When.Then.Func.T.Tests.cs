using FluentAssertions;
using System.Diagnostics.CodeAnalysis;


namespace FluentCoding.Test.FluentTypes.When
{
    [ExcludeFromCodeCoverage]
    public class When_Then_Func_T_Tests
    {
        static WhenAnd<T> WhenContext<T>(T obj, bool isTrue) => obj.When(isTrue);


        [TestCase(true)]
        [TestCase(false)]
        public void Then_Func_T_T(bool trueCondition)
        {
            WhenContext(Test.NewT, trueCondition)
                .Then(() => Test.NewTDone)
                .Should().BeEquivalentTo(trueCondition ? Test.NewTDone : Test.NewT);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Then_TrueAndFalse_Func_T_Func_T(bool trueCondition)
        {
            WhenContext(Test.NewT, trueCondition)
                .Then(() => Test.NewTDone, () => Test.NewTNotDone)
                .Should().BeEquivalentTo(trueCondition ? Test.NewTDone : Test.NewTNotDone);
        }

    }
}
