using FluentAssertions;
using FluentCoding;
using FluentCoding;

using System.Diagnostics.CodeAnalysis;


namespace FluentCoding.Test.FluentTypes.When
{
    [ExcludeFromCodeCoverage]
    public class When_Test
    {

        [TestCase(true)]
        [TestCase(false)]
        public void When_bool(bool trueCondition)
        {
            var when = Test.NewT.When(trueCondition);
            when.IsSuccessful.Should().Be(trueCondition);
            when.Should().BeOfType(typeof(WhenOr<TType>));
            when.Subject.Should().BeEquivalentTo(Test.NewT);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void When_Funct_T_bool(bool trueCondition)
        {
            var when = Test.NewT.When(() => trueCondition);
            when.IsSuccessful.Should().Be(trueCondition);
            when.Should().BeOfType(typeof(WhenOr<TType>));
            when.Subject.Should().BeEquivalentTo(Test.NewT);
        }


        [TestCase(true)]
        [TestCase(false)]
        public void When_Func_bool(bool trueCondition)
        {
            var when = Test.NewT.When((_) => trueCondition);
            when.IsSuccessful.Should().Be(trueCondition);
            when.Should().BeOfType(typeof(WhenOr<TType>));
            when.Subject.Should().BeEquivalentTo(Test.NewT);
        }
    }
}