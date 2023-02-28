using FluentAssertions;
using FluentCoding;
using FluentCodingTest;
using NUnit.Framework.Internal;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Intrinsics.X86;


namespace FluentCodingTest.Outcome_S_F
{
    [ExcludeFromCodeCoverage]
    public class Outcome_Tests
    {


        [Test]
        public void Outcome_Success_Istrue()
        {
            if(Test.T.ToSuccessOutcome<TypeT, TypeK>())
                Assert.Pass();
            else
                Assert.Fail();
        }


        [Test]
        public void Outcome_Failure_IsFalse()
        {
            if (Test.T.ToFailureOutcome<TypeK, TypeT>())
                Assert.Fail();
            else
                Assert.Pass();
        }
        [Test]
        public void Outcome_Band_Success_IsFalse()
        {
            if (!Test.T.ToSuccessOutcome<TypeT, TypeK>())
                Assert.Fail();
            else
                Assert.Pass();
        }


        [Test]
        public void Outcome_Band_Failure_IsTrue()
        {
            if (!Test.T.ToFailureOutcome<TypeK, TypeT>())
                Assert.Pass();
            else
                Assert.Fail();
        }

        [Test]
        public void Outcome_ToSuccessOutcome()
        {
            var outcome = Test.T.ToSuccessOutcome<TypeT, TypeK>();

            outcome.IsSuccessful.Should().BeTrue();
            outcome.Success.Should().BeEquivalentTo(Test.T);
            outcome.Failure.Should().BeNull();

        }

        [Test]
        public void Outcome_ToSuccess()
        {
            var outcome = Outcome<TypeT, TypeK>.ToSuccess(Test.T);

            outcome.IsSuccessful.Should().BeTrue();
            outcome.Success.Should().BeEquivalentTo(Test.T);
            outcome.Failure.Should().BeNull();

        }

        [Test]
        public void Outcome_ToFaliure()
        {
            var outcome = Outcome<TypeT, TypeK>.ToFailure(Test.K);

            outcome.IsSuccessful.Should().BeFalse();
            outcome.Success.Should().BeNull();
            outcome.Failure.Should().BeEquivalentTo(Test.K);

        }

        [Test]
        public void Outcome_ToFailureOutcome()
        {
            var outcome = Test.K.ToFailureOutcome<TypeT, TypeK>();

            outcome.IsSuccessful.Should().BeFalse();
            outcome.Success.Should().BeNull();
            outcome.Failure.Should().BeEquivalentTo(Test.K);

        }


    }
}