using FluentAssertions;

using System.Diagnostics.CodeAnalysis;


namespace FluentCoding.Test.FluentTypes.When
{
    [ExcludeFromCodeCoverage]
    public class When_And_Tests
    {
        static WhenAnd<T> WhenContext<T>(T obj, bool isTrue) => obj.When(isTrue);


        [TestCase(true)]
        [TestCase(false)]
        public void AndWhen_Bool(bool trueCondition)
        {
            var when = WhenContext(Test.NewT, trueCondition)
                       .AndWhen(trueCondition);
            when.IsSuccessful.Should().Be(trueCondition);
            when.Should().BeOfType(typeof(WhenAnd<TType>));
            when.Subject.Should().BeEquivalentTo(Test.NewT);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void AndWhen_Func_Bool(bool trueCondition)
        {
            var when = WhenContext(Test.NewT, trueCondition)
                        .AndWhen(() =>
                        trueCondition);

            when.IsSuccessful.Should().Be(trueCondition);
            when.Should().BeOfType(typeof(WhenAnd<TType>));
            when.Subject.Should().BeEquivalentTo(Test.NewT);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void AndWhen_Func_T_Bool(bool trueCondition)
        {
            var when = WhenContext(Test.NewT, trueCondition)
                        .AndWhen((_) => trueCondition);

            when.IsSuccessful.Should().Be(trueCondition);
            when.Should().BeOfType(typeof(WhenAnd<TType>));
            when.Subject.Should().BeEquivalentTo(Test.NewT);
        }


        [TestCase]
        public void AndWhen_TrueAndFalse()
        {
            var when = WhenContext(Test.NewT, true)
                        .AndWhen(false);

            when.IsSuccessful.Should().Be(false);
            when.Should().BeOfType(typeof(WhenAnd<TType>));
            when.Subject.Should().BeEquivalentTo(Test.NewT);
        }

        [TestCase]
        public void AndWhen_FalseAndTrue()
        {
            var when = WhenContext(Test.NewT, false)
                        .AndWhen(true)
                        .AndWhen(true);

            when.IsSuccessful.Should().Be(false);
            when.Should().BeOfType(typeof(WhenAnd<TType>));
            when.Subject.Should().BeEquivalentTo(Test.NewT);
        }
    }
}
