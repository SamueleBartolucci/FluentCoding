using FluentAssertions;
using FluentCoding;
using FluentCoding.When;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.When_T
{
    [ExcludeFromCodeCoverage]
    public class When_Or_And_Test
    {
        static WhenOr<T> WhenContext<T>(T obj, bool isTrue) => obj.When(isTrue);


        [TestCase(true, true, true)]
        [TestCase(false, false, false)]
        [TestCase(true, true, false)]
        [TestCase(true, false, false)]
        [TestCase(true, false, true)]
        [TestCase(false, true, true)]
        [TestCase(false, true, false)]
        [TestCase(false, false, true)]
        public void WhenOrAnd(bool baseCondition, bool orCondition, bool andCondition)
        {
            var when = WhenContext(Test.T, baseCondition)
                        .OrWhen(orCondition)
                        .AndWhen(andCondition);

            when.IsSuccesful.Should().Be((baseCondition || orCondition) && andCondition);
            when.Should().BeOfType(typeof(WhenAnd<TypeT>));
            when.Subject.Should().BeEquivalentTo(Test.T);
        }
    }
}
