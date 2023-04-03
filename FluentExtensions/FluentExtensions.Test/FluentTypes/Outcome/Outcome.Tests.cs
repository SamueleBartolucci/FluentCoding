using FluentAssertions;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace FluentCoding.Test.FluentTypes.Outcome
{
    [ExcludeFromCodeCoverage]
    public class Outcome_Tests
    {

        [Test]
        public void Outcome_WhenSuccessWhenFailure_Success()
        {
            var listEmpty = new List<string>();

            var result = Test.NewT.ToOutcome(() => false, Test.NewK)
                .WhenSuccess(_ => listEmpty.Add(_.TDesc))
                .WhenFailure(_ => listEmpty.Add(_.KDesc))
                .IsSuccessful.Should().BeTrue();

            listEmpty.Count.Should().Be(1);
            listEmpty.First().Should().BeEquivalentTo(Test.NewT.TDesc);
        }

        [Test]
        public void Outcome_WhenSuccessWhenFailure_Failure()
        {
            var listEmpty = new List<string>();

            var result = Test.NewT.ToOutcome(() => true, Test.NewK)
                .WhenSuccess(_ => listEmpty.Add(_.TDesc))
                .WhenFailure(_ => listEmpty.Add(_.KDesc))
                .IsSuccessful.Should().BeFalse();

            listEmpty.Count.Should().Be(1);
            listEmpty.First().Should().BeEquivalentTo(Test.NewK.KDesc);
        }


        [Test]
        public void Outcome_ToOutcome1_bool_Success()
        {
            Outcome<TType, KType>.ToOutcome(Test.NewT, () => false, Test.NewK)
                .IsSuccessful.Should().BeTrue();

        }
        [Test]
        public void Outcome_ToOutcome2_bool_Success()
        {
            Test.NewT.ToOutcome(() => false, Test.NewK)
                .IsSuccessful.Should().BeTrue();
        }

        [Test]
        public void Outcome_ToOutcome1_T_bool_Success()
        {
            Test.NewT.ToOutcome(_ => _.IsNullOrEquivalent(), Test.NewK)
                .IsSuccessful.Should().BeTrue();
        }

        [Test]
        public void Outcome_ToOutcome2_T_bool_Success()
        {
            Outcome<TType, KType>.ToOutcome(Test.NewT, _ => _.IsNullOrEquivalent(), Test.NewK)
                .IsSuccessful.Should().BeTrue();
        }

        [Test]
        public void Outcome_ToOutcome_bool_Failure()
        {
            Test.NewT.ToOutcome(() => true, Test.NewK)
                .IsSuccessful.Should().BeFalse();
        }

        [Test]
        public void Outcome_ToOutcome_T_bool_Failure()
        {
            Test.NewT.ToOutcome(_ => !_.IsNullOrEquivalent(), Test.NewK)
                .IsSuccessful.Should().BeFalse();
        }

        [Test]
        public void Outcome_Success_Match()
        {
            Test.NewT.ToSuccessOutcome<TType, KType>()
                .Match(t => t.TDesc,
                       k => k.KDesc)
                .Should().Be(Test.NewT.TDesc);
        }

        [Test]
        public void Outcome_Failure_Match()
        {
            Test.NewK.ToFailureOutcome<TType, KType>()
                .Match(t => t.TDesc,
                       k => k.KDesc)
                .Should().Be(Test.NewK.KDesc);
        }


        [Test]
        public void Outcome_Success_Istrue()
        {
            if (Test.NewT.ToSuccessOutcome<TType, KType>())
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