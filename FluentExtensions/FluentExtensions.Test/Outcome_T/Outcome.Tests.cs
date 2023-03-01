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
            if(Test.NewT.ToSuccessOutcome<TType, KType>())
                Assert.Pass();
            else
                Assert.Fail();
        }


        [Test]
        public void Outcome_Failure_IsFalse()
        {
            if (Test.NewT.ToFailureOutcome<KType, TType>())
                Assert.Fail();
            else
                Assert.Pass();
        }
        [Test]
        public void Outcome_Band_Success_IsFalse()
        {
            if (!Test.NewT.ToSuccessOutcome<TType, KType>())
                Assert.Fail();
            else
                Assert.Pass();
        }


        [Test]
        public void Outcome_Band_Failure_IsTrue()
        {
            if (!Test.NewT.ToFailureOutcome<KType, TType>())
                Assert.Pass();
            else
                Assert.Fail();
        }

        [Test]
        public void Outcome_ToSuccessOutcome()
        {
            var outcome = Test.NewT.ToSuccessOutcome<TType, KType>();

            outcome.IsSuccessful.Should().BeTrue();
            outcome.Success.Should().BeEquivalentTo(Test.NewT);
            outcome.Failure.Should().BeNull();

        }

        [Test]
        public void Outcome_ToSuccess()
        {
            var outcome = Outcome<TType, KType>.ToSuccess(Test.NewT);

            outcome.IsSuccessful.Should().BeTrue();
            outcome.Success.Should().BeEquivalentTo(Test.NewT);
            outcome.Failure.Should().BeNull();

        }

        [Test]
        public void Outcome_ToFaliure()
        {
            var outcome = Outcome<TType, KType>.ToFailure(Test.NewK);

            outcome.IsSuccessful.Should().BeFalse();
            outcome.Success.Should().BeNull();
            outcome.Failure.Should().BeEquivalentTo(Test.NewK);

        }

        [Test]
        public void Outcome_ToFailureOutcome()
        {
            var outcome = Test.NewK.ToFailureOutcome<TType, KType>();

            outcome.IsSuccessful.Should().BeFalse();
            outcome.Success.Should().BeNull();
            outcome.Failure.Should().BeEquivalentTo(Test.NewK);

        }


    }
}