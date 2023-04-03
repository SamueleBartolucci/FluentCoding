using FluentAssertions;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace FluentCoding.Test.FluentTypes.Outcome
{
    [ExcludeFromCodeCoverage]
    public class Outcome_Optional_Tests
    {

      
        [Test]
        public void Outcome_ToOutcome_Some()
        {
            var outcome = Test.NewT.ToOptional().ToOutcome("X");
            outcome.IsSuccessful.Should().BeTrue();
            outcome.Success.Should().BeEquivalentTo(Test.NewT);
            outcome.Failure.Should().BeNull();
        }

        [Test]
        public void Outcome_ToOutcome_None()
        {
            var outcome = Optional<string>.None().ToOutcome("X");
            outcome.IsSuccessful.Should().BeFalse();
            outcome.Failure.Should().BeEquivalentTo("X");
            outcome.Success.Should().BeNull();
        }


        [Test]
        public void Outcome_ToOutcome_Some_Func()
        {
            var outcome = Test.NewT.ToOptional().ToOutcome(() => "X");
            outcome.IsSuccessful.Should().BeTrue();
            outcome.Success.Should().BeEquivalentTo(Test.NewT);
            outcome.Failure.Should().BeNull();
        }

        [Test]
        public void Outcome_ToOutcome_None_Func()
        {
            var outcome = Optional<string>.None().ToOutcome(() => "X");
            outcome.IsSuccessful.Should().BeFalse();
            outcome.Failure.Should().BeEquivalentTo("X");
            outcome.Success.Should().BeNull();
        }




    }
}