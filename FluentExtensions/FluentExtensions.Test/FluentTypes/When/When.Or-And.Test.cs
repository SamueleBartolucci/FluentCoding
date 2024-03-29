using FluentAssertions;

using System.Diagnostics.CodeAnalysis;


namespace FluentCoding.Test.FluentTypes.When
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
            var when = WhenContext(Test.NewT, baseCondition)
                        .OrWhen(orCondition)
                        .AndWhen(andCondition);

            when.IsSuccessful.Should().Be((baseCondition || orCondition) && andCondition);
            when.Should().BeOfType(typeof(WhenAnd<TType>));
            when.Subject.Should().BeEquivalentTo(Test.NewT);
        }
    }
}
