using FluentAssertions;
using FluentCoding;
using FluentCodingTest;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace FluentCodingTest.TryCatch_T
{
    [ExcludeFromCodeCoverage]
    public class Outcome_Map_Tests
    {

        private Outcome<TypeT, TypeK> GetSuccessOutcome()
            => Outcome<TypeT, TypeK>.ToSuccess(Test.T);

        private Outcome<TypeT, TypeK> GetFailureOutcome()
            => Outcome<TypeT, TypeK>.ToFailure(Test.K);


        private List<T> ToList<T> (T subject) => new List<T> { subject };
        [Test]
        public void Outcome_Success_Map()
        {
            var outcome = GetSuccessOutcome();
            var newOutcome = outcome
                                .Map(succ => ToList(succ.Do(_ => _.DescType = Test.Done)),
                                     fail => ToList(fail.Do(_ => _.DescType = Test.Left)));

            newOutcome.IsSuccesful.Should().BeTrue();
            newOutcome.Failure.Should().BeNull();
            newOutcome.Success.Should().BeOfType<List<TypeT>>();
            newOutcome.Success.First().Should().BeEquivalentTo(Test.TDone);
        }

        [Test]
        public void Outcome_Failure_Map()
        {
            var outcome = GetFailureOutcome();
            var newOutcome = outcome
                                .Map(succ => ToList(succ.Do(_ => _.DescType = Test.Done)),
                                     fail => new List<TypeK> { fail.Do(_ => _.DescType = Test.Left) });

            newOutcome.IsSuccesful.Should().BeFalse();
            newOutcome.Success.Should().BeNull();
            newOutcome.Failure.Should().BeOfType<List<TypeK>>();
            newOutcome.Failure.First().Should().BeEquivalentTo(Test.TLeft);
        }

        [Test]
        public void Outcome_Success_MapFailureMapSuccess()
        {
            var outcome = GetSuccessOutcome();
            var newOutcome = outcome                                
                                .MapFailure(_ => new List<TypeK>() { _.Do(__ => __.DescType = Test.Left) })
                                .MapSuccess(_ => new List<TypeT>() { _.Do(__ => __.DescType = Test.Done) });

            newOutcome.IsSuccesful.Should().BeTrue();
            newOutcome.Failure.Should().BeNull();
            newOutcome.Success.Should().BeOfType<List<TypeT>>();
            newOutcome.Success.First().Should().BeEquivalentTo(Test.TDone);
        }

        [Test]
        public void Outcome_Success_MapSuccessMapFailure()
        {
            var outcome = GetSuccessOutcome();
            var newOutcome = outcome
                                .MapSuccess(_ => new List<TypeT>() { _.Do(__ => __.DescType = Test.Done) })
                                .MapFailure(_ => new List<TypeK>() { _.Do(__ => __.DescType = Test.Left) });

            newOutcome.IsSuccesful.Should().BeTrue();
            newOutcome.Failure.Should().BeNull();
            newOutcome.Success.Should().BeOfType<List<TypeT>>();
            newOutcome.Success.First().Should().BeEquivalentTo(Test.TDone);
        }


        [Test]
        public void Outcome_Failure_MapSuccessMapFailure()
        {
            var outcome = GetFailureOutcome();
            var newOutcome = outcome
                                .MapSuccess(_ => new List<TypeT>() { _.Do(__ => __.DescType = Test.Done) })
                                .MapFailure(_ => new List<TypeK>() { _.Do(__ => __.DescType = Test.Left) });

            newOutcome.IsSuccesful.Should().BeFalse();            
            newOutcome.Success.Should().BeNull();
            newOutcome.Failure.Should().BeOfType<List<TypeK>>();
            newOutcome.Failure.First().Should().BeEquivalentTo(Test.TLeft);
        }


        [Test]
        public void Outcome_Failure_MapFailureMapSuccess()
        {
            var outcome = GetFailureOutcome();
            var newOutcome = outcome                                
                                .MapFailure(_ => new List<TypeK>() { _.Do(__ => __.DescType = Test.Left) })
                                .MapSuccess(_ => new List<TypeT>() { _.Do(__ => __.DescType = Test.Done) });

            newOutcome.IsSuccesful.Should().BeFalse();
            newOutcome.Success.Should().BeNull();
            newOutcome.Failure.Should().BeOfType<List<TypeK>>();
            newOutcome.Failure.First().Should().BeEquivalentTo(Test.TLeft);
        }

    }
}