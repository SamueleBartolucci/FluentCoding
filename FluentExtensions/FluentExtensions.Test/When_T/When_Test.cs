using FluentAssertions;
using FluentCoding;
using FluentCoding.When;
using FluentCodingTest;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.When_T
{
    [ExcludeFromCodeCoverage]
    public class When_Test
    {

        [TestCase(true)]
        [TestCase(false)]
        public void When_bool(bool trueCondition)
        {
            var when = Test.T.When(trueCondition);
            when.IsSuccesful.Should().Be(trueCondition);
            when.Should().BeOfType(typeof(WhenOr<TypeT>));
            when.Subject.Should().BeEquivalentTo(Test.T);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void When_Funct_T_bool(bool trueCondition)
        {
            var when = Test.T.When(() => trueCondition);
            when.IsSuccesful.Should().Be(trueCondition);
            when.Should().BeOfType(typeof(WhenOr<TypeT>));
            when.Subject.Should().BeEquivalentTo(Test.T);
        }


        [TestCase(true)]
        [TestCase(false)]
        public void When_Func_bool(bool trueCondition)
        {
            var when = Test.T.When((_) => trueCondition);
            when.IsSuccesful.Should().Be(trueCondition);
            when.Should().BeOfType(typeof(WhenOr<TypeT>));
            when.Subject.Should().BeEquivalentTo(Test.T);
        }
    }
}