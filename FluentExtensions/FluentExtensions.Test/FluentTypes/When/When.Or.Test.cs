using FluentAssertions;

using System.Diagnostics.CodeAnalysis;


namespace FluentCoding.Test.FluentTypes.When
{
    [ExcludeFromCodeCoverage]
    public class When_Or_Test
    {
        static WhenOr<T> WhenContext<T>(T obj, bool isTrue) => obj.When(isTrue);


        [TestCase(true)]
        [TestCase(false)]
        public void OrWhen_Bool(bool trueCondition)
        {
            var when = WhenContext(Test.NewT, trueCondition)
                       .OrWhen(trueCondition);
            when.IsSuccessful.Should().Be(trueCondition);
            when.Should().BeOfType(typeof(WhenOr<TType>));
            when.Subject.Should().BeEquivalentTo(Test.NewT);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void OrWhen_Func_Bool(bool trueCondition)
        {
            var when = WhenContext(Test.NewT, trueCondition)
                        .OrWhen(() => trueCondition);

            when.IsSuccessful.Should().Be(trueCondition);
            when.Should().BeOfType(typeof(WhenOr<TType>));
            when.Subject.Should().BeEquivalentTo(Test.NewT);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void OrWhen_Func_T_Bool(bool trueCondition)
        {
            var when = WhenContext(Test.NewT, trueCondition)
                        .OrWhen((_) => trueCondition);

            when.IsSuccessful.Should().Be(trueCondition);
            when.Should().BeOfType(typeof(WhenOr<TType>));
            when.Subject.Should().BeEquivalentTo(Test.NewT);
        }


        [TestCase]
        public void OrWhen_TrueAndFalse()
        {
            var when = WhenContext(Test.NewT, true)
                        .OrWhen(false);

            when.IsSuccessful.Should().Be(true);
            when.Should().BeOfType(typeof(WhenOr<TType>));
            when.Subject.Should().BeEquivalentTo(Test.NewT);
        }

        [TestCase]
        public void OrWhen_FalseAndTrue()
        {
            var when = WhenContext(Test.NewT, false)
                        .OrWhen(true);

            when.IsSuccessful.Should().Be(true);
            when.Should().BeOfType(typeof(WhenOr<TType>));
            when.Subject.Should().BeEquivalentTo(Test.NewT);
        }
    }
}
