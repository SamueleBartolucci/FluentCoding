using FluentAssertions;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;


namespace FluentCoding.Test.FluentTypes.When
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


        [Test]
        public void ThenForAll_whenTrue()
        {
            IEnumerable<string> input = new[] { Test.DONE, Test.NOT_DONE, Test.LEFT, Test.RIGHT };
            input.WhenAny().ThenForAll(_ => _ + 1, _ => _ + 2)
                .Should().AllSatisfy(x =>
                {
                    x.Should().NotStartWith("1");
                    x.Should().EndWith("1");
                });
        }


        [Test]
        public void ThenForAll_WhenFalse()
        {
            IEnumerable<string> input = new[] { Test.DONE, Test.NOT_DONE, Test.LEFT, Test.RIGHT };
            input.WhenAny(_ => _.StartsWith("XXX")).ThenForAll(_ => _ + 1, _ => _ + 2)
                .Should().AllSatisfy(x =>
                {
                    x.Should().NotStartWith("2");
                    x.Should().EndWith("2");
                });
        }

    }
}

