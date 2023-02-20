using FluentAssertions;
using FluentCoding;
using FluentCoding;
using FluentCodingTest;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.WhenAsync_T
{
    [ExcludeFromCodeCoverage]
    public class WhenAsync_Test
    {

        [TestCase(true)]
        [TestCase(false)]
        public void WhenAsync_bool(bool trueCondition)
        {
            var when = Test.T.ToTask().WhenAsync(trueCondition).Result;
            when.IsSuccessful.Should().Be(trueCondition);
            when.Should().BeOfType(typeof(WhenOr<TypeT>));
            when.Subject.Should().BeEquivalentTo(Test.T);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void WhenAsync_Funct_T_bool(bool trueCondition)
        {
            var when = Test.T.ToTask().WhenAsync(() => trueCondition).Result;
            when.IsSuccessful.Should().Be(trueCondition);
            when.Should().BeOfType(typeof(WhenOr<TypeT>));
            when.Subject.Should().BeEquivalentTo(Test.T);
        }


        [TestCase(true)]
        [TestCase(false)]
        public void WhenAsync_Func_bool(bool trueCondition)
        {
            var when = Test.T.ToTask().WhenAsync((_) => trueCondition).Result;
            when.IsSuccessful.Should().Be(trueCondition);
            when.Should().BeOfType(typeof(WhenOr<TypeT>));
            when.Subject.Should().BeEquivalentTo(Test.T);
        }
    }
}