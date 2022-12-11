using FluentAssertions;
using FluentExtensions;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.When
{
    [ExcludeFromCodeCoverage]
    public class WhenExtensionTest
    {

        [TestCase(true)]
        [TestCase(false)]
        public void When_bool(bool trueCondition)
        {            
            var when = Test.T.When(trueCondition);
            when.IsSuccesful.Should().Be(trueCondition);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void When_Func(bool trueCondition)
        {
            var when = Test.T.When((_) => trueCondition);
            when.IsSuccesful.Should().Be(trueCondition);
        }
    }
}