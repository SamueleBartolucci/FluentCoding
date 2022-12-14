using FluentAssertions;
using FluentCoding;

using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.When_T.Extensions
{
    [ExcludeFromCodeCoverage]
    public class WhenOr_Test
    {
        static WhenOr<T> WhenContext<T>(T obj, bool isTrue) => obj.When(isTrue);


        [TestCase(true)]
        [TestCase(false)]
        public void OrWhen_Bool(bool trueCondition)
        {
            var when = WhenContext(Test.T, trueCondition)
                       .OrWhen(trueCondition);
            when.IsSuccesful.Should().Be(trueCondition);
            when.Should().BeOfType(typeof(WhenOr<TypeT>));
            when.Subject.Should().BeEquivalentTo(Test.T);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void OrWhen_Func_Bool(bool trueCondition)
        {
            var when = WhenContext(Test.T, trueCondition)
                        .OrWhen(() => trueCondition);

            when.IsSuccesful.Should().Be(trueCondition);
            when.Should().BeOfType(typeof(WhenOr<TypeT>));
            when.Subject.Should().BeEquivalentTo(Test.T);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void OrWhen_Func_T_Bool(bool trueCondition)
        {
            var when = WhenContext(Test.T, trueCondition)
                        .OrWhen((_) => trueCondition);

            when.IsSuccesful.Should().Be(trueCondition);
            when.Should().BeOfType(typeof(WhenOr<TypeT>));
            when.Subject.Should().BeEquivalentTo(Test.T);
        }


        [TestCase]
        public void OrWhen_TrueAndFalse()
        {
            var when = WhenContext(Test.T, true)        
                        .OrWhen(false);

            when.IsSuccesful.Should().Be(true);
            when.Should().BeOfType(typeof(WhenOr<TypeT>));
            when.Subject.Should().BeEquivalentTo(Test.T);
        }

        [TestCase]
        public void OrWhen_FalseAndTrue()
        {
            var when = WhenContext(Test.T, false)
                        .OrWhen(true);

            when.IsSuccesful.Should().Be(true);
            when.Should().BeOfType(typeof(WhenOr<TypeT>));
            when.Subject.Should().BeEquivalentTo(Test.T);
        }
    }
}
