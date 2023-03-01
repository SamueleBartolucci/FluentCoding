using FluentAssertions;
using FluentCoding;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.When_T
{
    [ExcludeFromCodeCoverage]
    public class When_Then_FuncMap_T_T_Tests
    {
        static WhenAnd<T> WhenContext<T>(T obj, bool isTrue) => obj.When(isTrue);


        [TestCase(true)]
        [TestCase(false)]
        public void ThenMap_T_K(bool trueCondition)
        {
            var when = WhenContext(Test.NewT, trueCondition)
                  .ThenMap((_) => Test.NewKDone);
            when.OnTrue.Should().BeEquivalentTo(trueCondition ? Test.NewKDone : null);
            when.Subject.Should().BeEquivalentTo(Test.NewT);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ThenWhenTrue(bool trueCondition)
        {
            WhenContext(Test.NewT, trueCondition)
                .Then((_) => Test.NewKDone, (_) => Test.NewKNotDone)
                .Should().BeEquivalentTo(trueCondition ? Test.NewKDone : Test.NewKNotDone);
        }

    }
}

