using FluentAssertions;
using FluentCoding;

using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace FluentCoding.Test.FluentTypes.Outcome
{
    [ExcludeFromCodeCoverage]
    public class Outcome_Map_Tests
    {

        private Outcome<TType, KType> GetSuccessOutcome()
            => Outcome<TType, KType>.ToSuccess(Test.NewT);

        private Outcome<TType, KType> GetFailureOutcome()
            => Outcome<TType, KType>.ToFailure(Test.NewK);


        private List<T> ToList<T>(T subject) => new List<T> { subject };
        [Test]
        public void Outcome_Success_Map()
        {
            var outcome = GetSuccessOutcome();
            var newOutcome = outcome
                                .Map(succ => ToList(succ.Do(t => t.TDesc = Test.DONE)),
                                     fail => ToList(fail.Do(_ => _.KDesc = Test.LEFT)));

            newOutcome.IsSuccessful.Should().BeTrue();
            newOutcome.Failure.Should().BeNull();
            newOutcome.Success.Should().BeOfType<List<TType>>();
            newOutcome.Success.First().Should().BeEquivalentTo(Test.NewTDone);
        }

        [Test]
        public void Outcome_Failure_Map()
        {
            var outcome = GetFailureOutcome();
            var newOutcome = outcome
                                .Map(succ => ToList(succ.Do(t => t.TDesc = Test.DONE)),
                                     fail => new List<KType> { fail.Do(k => k.KDesc = Test.LEFT) });

            newOutcome.IsSuccessful.Should().BeFalse();
            newOutcome.Success.Should().BeNull();
            newOutcome.Failure.Should().BeOfType<List<KType>>();
            newOutcome.Failure.First().Should().BeEquivalentTo(Test.NewKLeft);
        }

        [Test]
        public void Outcome_Success_MapFailureMapSuccess()
        {
            var outcome = GetSuccessOutcome();
            var newOutcome = outcome
                                .MapFailure(_ => new List<KType>() { _.Do(__ => __.KDesc = Test.LEFT) })
                                .MapSuccess(_ => new List<TType>() { _.Do(__ => __.TDesc = Test.DONE) });

            newOutcome.IsSuccessful.Should().BeTrue();
            newOutcome.Failure.Should().BeNull();
            newOutcome.Success.Should().BeOfType<List<TType>>();
            newOutcome.Success.First().Should().BeEquivalentTo(Test.NewTDone);
        }

        [Test]
        public void Outcome_Success_MapSuccessMapFailure()
        {
            var outcome = GetSuccessOutcome();
            var newOutcome = outcome
                                .MapSuccess(tSuccess => new List<TType>() { tSuccess.Do(t => t.TDesc = Test.DONE) })
                                .MapFailure(kFailure => new List<KType>() { kFailure.Do(k => k.KDesc = Test.LEFT) });

            newOutcome.IsSuccessful.Should().BeTrue();
            newOutcome.Failure.Should().BeNull();
            newOutcome.Success.Should().BeOfType<List<TType>>();
            newOutcome.Success.First().Should().BeEquivalentTo(Test.NewTDone);
        }


        [Test]
        public void Outcome_Failure_MapSuccessMapFailure()
        {
            var outcome = GetFailureOutcome();
            var newOutcome = outcome
                                .MapSuccess(tSuccess => new List<TType>() { tSuccess.Do(t => t.TDesc = Test.DONE) })
                                .MapFailure(kFailure => new List<KType>() { kFailure.Do(k => k.KDesc = Test.LEFT) });

            newOutcome.IsSuccessful.Should().BeFalse();
            newOutcome.Success.Should().BeNull();
            newOutcome.Failure.Should().BeOfType<List<KType>>();
            newOutcome.Failure.First().Should().BeEquivalentTo(Test.NewKLeft);
        }


        [Test]
        public void Outcome_Failure_MapFailureMapSuccess()
        {
            var outcome = GetFailureOutcome();
            var newOutcome = outcome
                                .MapFailure(kFailure => new List<KType>() { kFailure.Do(k => k.KDesc = Test.LEFT) })
                                .MapSuccess(tSuccess => new List<TType>() { tSuccess.Do(t => t.TDesc = Test.DONE) });

            newOutcome.IsSuccessful.Should().BeFalse();
            newOutcome.Success.Should().BeNull();
            newOutcome.Failure.Should().BeOfType<List<KType>>();
            newOutcome.Failure.First().Should().BeEquivalentTo(Test.NewKLeft);
        }

    }
}