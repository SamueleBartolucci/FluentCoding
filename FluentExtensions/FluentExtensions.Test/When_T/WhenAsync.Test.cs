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
            var when = Test.NewT.ToTask().WhenAsync(trueCondition).Result;
            when.IsSuccessful.Should().Be(trueCondition);
            when.Should().BeOfType(typeof(WhenOr<TType>));
            when.Subject.Should().BeEquivalentTo(Test.NewT);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void WhenAsync_Funct_T_bool(bool trueCondition)
        {
            var when = Test.NewT.ToTask().WhenAsync(() => trueCondition).Result;
            when.IsSuccessful.Should().Be(trueCondition);
            when.Should().BeOfType(typeof(WhenOr<TType>));
            when.Subject.Should().BeEquivalentTo(Test.NewT);
        }


        [TestCase(true)]
        [TestCase(false)]
        public void WhenAsync_Func_bool(bool trueCondition)
        {
            var when = Test.NewT.ToTask().WhenAsync((_) => trueCondition).Result;
            when.IsSuccessful.Should().Be(trueCondition);
            when.Should().BeOfType(typeof(WhenOr<TType>));
            when.Subject.Should().BeEquivalentTo(Test.NewT);
        }
    }
}