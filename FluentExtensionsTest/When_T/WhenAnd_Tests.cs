using FluentAssertions;
using FluentCoding;

using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.When_T.Extensions
{
    [ExcludeFromCodeCoverage]
    public class WhenAnd_Tests
    {
        static WhenAnd<T> WhenContext<T>(T obj, bool isTrue) => obj.When(isTrue);


        [TestCase(true)]
        [TestCase(false)]
        public void AndWhen_Bool(bool trueCondition)
        {
            var when = WhenContext(Test.T, trueCondition)
                       .AndWhen(trueCondition);
            when.IsSuccesful.Should().Be(trueCondition);
            when.Should().BeOfType(typeof(WhenAnd<TypeT>));
            when.Subject.Should().BeEquivalentTo(Test.T);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void AndWhen_Func_Bool(bool trueCondition)
        {
            var when = WhenContext(Test.T, trueCondition)
                        .AndWhen(() => trueCondition);

            when.IsSuccesful.Should().Be(trueCondition);
            when.Should().BeOfType(typeof(WhenAnd<TypeT>));
            when.Subject.Should().BeEquivalentTo(Test.T);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void AndWhen_Func_T_Bool(bool trueCondition)
        {
            var when = WhenContext(Test.T, trueCondition)
                        .AndWhen((_) => trueCondition);

            when.IsSuccesful.Should().Be(trueCondition);
            when.Should().BeOfType(typeof(WhenAnd<TypeT>));
            when.Subject.Should().BeEquivalentTo(Test.T);
        }


        [TestCase]
        public void AndWhen_TrueAndFalse()
        {
            var when = WhenContext(Test.T, true)        
                        .AndWhen(false);

            when.IsSuccesful.Should().Be(false);
            when.Should().BeOfType(typeof(WhenAnd<TypeT>));
            when.Subject.Should().BeEquivalentTo(Test.T);
        }

        [TestCase]
        public void AndWhen_FalseAndTrue()
        {
            var when = WhenContext(Test.T, false)
                        .AndWhen(true)
                        .AndWhen(true);

            when.IsSuccesful.Should().Be(false);
            when.Should().BeOfType(typeof(WhenAnd<TypeT>));
            when.Subject.Should().BeEquivalentTo(Test.T);
        }
    }
}
