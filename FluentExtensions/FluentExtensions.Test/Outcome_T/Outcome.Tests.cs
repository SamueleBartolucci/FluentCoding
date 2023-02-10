using FluentAssertions;
using FluentCoding;
using FluentCodingTest;
using NUnit.Framework.Internal;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.Outcome
{
    [ExcludeFromCodeCoverage]
    public class Outcome_Tests
    {


        [Test]
        public void Outcome_ToSuccessOutcome()
        {
            var outcome = Test.T.ToSuccessOutcome<TypeT, TypeK>();

            outcome.IsSuccesful.Should().BeTrue();
            outcome.Success.Should().BeEquivalentTo(Test.T);
            outcome.Failure.Should().BeNull();

        }

        [Test]
        public void Outcome_ToSuccess()
        {
            var outcome = Outcome<TypeT, TypeK>.ToSuccess(Test.T);

            outcome.IsSuccesful.Should().BeTrue();
            outcome.Success.Should().BeEquivalentTo(Test.T);
            outcome.Failure.Should().BeNull();

        }

        [Test]
        public void Outcome_ToFaliure()
        {
            var outcome = Outcome<TypeT, TypeK>.ToFailure(Test.K);

            outcome.IsSuccesful.Should().BeFalse();
            outcome.Success.Should().BeNull();
            outcome.Failure.Should().BeEquivalentTo(Test.K);

        }

        [Test]
        public void Outcome_ToFailureOutcome()
        {
            var outcome = Test.K.ToFailureOutcome<TypeT, TypeK>();

            outcome.IsSuccesful.Should().BeFalse();
            outcome.Success.Should().BeNull();
            outcome.Failure.Should().BeEquivalentTo(Test.K);

        }


    }
}