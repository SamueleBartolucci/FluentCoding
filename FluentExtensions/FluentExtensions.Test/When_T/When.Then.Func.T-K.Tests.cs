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
            var when = WhenContext(Test.T, trueCondition)
                  .ThenMap((_) => Test.KDone);
            when.OnTrue.Should().BeEquivalentTo(trueCondition ? Test.KDone : null);
            when.Subject.Should().BeEquivalentTo(Test.T);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ThenWhenTrue(bool trueCondition)
        {
            WhenContext(Test.T, trueCondition)
                .Then((_) => Test.KDone, (_) => Test.KNotDone)
                .Should().BeEquivalentTo(trueCondition ? Test.KDone : Test.KNotDone);
        }

    }
}

