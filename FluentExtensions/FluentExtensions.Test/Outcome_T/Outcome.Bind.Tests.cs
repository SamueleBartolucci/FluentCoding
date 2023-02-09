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
    public class Outcome_Bind_Tests
    {

        private Outcome<string, string> GetSuccessOutcome()
            => Outcome<string, string>.ToSuccess(Test.Right);

        private Outcome<string, string> GetFailureOutcome()
            => Outcome<string, string>.ToFailure(Test.Left);

        private List<T> ToList<T>(T subject) => new List<T> { subject };

        private Outcome<TypeT, TypeK> DoSomethingThatCanFail(bool isFailing)
            => isFailing? Outcome<TypeT, TypeK>.ToFailure(Test.KLeft) : Outcome<TypeT, TypeK>.ToSuccess(Test.TRight);

        [Test]
        public void Outcome_Success_Bind_SuccessBindResult()
        {
            var outcome = GetSuccessOutcome();
            var newOutcome = outcome
                                .Bind(succ => DoSomethingThatCanFail(false),
                                     fail => Test.KNotDone.ToFailureOutcome<TypeT, TypeK>());

            newOutcome.IsSuccesful.Should().BeTrue();
            newOutcome.Failure.Should().BeNull();            
            newOutcome.Success.Should().BeEquivalentTo(Test.TRight);
        }

        [Test]
        public void Outcome_Success_Bind_FailureBindResult()
        {
            var outcome = GetSuccessOutcome();
            var newOutcome = outcome
                                .Bind(succ => DoSomethingThatCanFail(true),
                                     fail => Test.KNotDone.ToFailureOutcome<TypeT, TypeK>());

            newOutcome.IsSuccesful.Should().BeFalse();
            newOutcome.Failure.Should().BeEquivalentTo(Test.KLeft);
            newOutcome.Success.Should().BeNull();
        }


        [Test]
        public void Outcome_Failure_Bind_SuccessBindResult()
        {
            var outcome = GetFailureOutcome();
            var newOutcome = outcome
                                .Bind(succ => Test.TDone.ToSuccessOutcome<TypeT, TypeK>(),
                                     fail => DoSomethingThatCanFail(false));

            newOutcome.IsSuccesful.Should().BeTrue();
            newOutcome.Failure.Should().BeNull();
            newOutcome.Success.Should().BeEquivalentTo(Test.TRight);
        }

        [Test]
        public void Outcome_Failure_Bind_FailureBindResult()
        {
            var outcome = GetFailureOutcome();
            var newOutcome = outcome
                                .Bind(succ => Test.TDone.ToSuccessOutcome<TypeT, TypeK>(),
                                      fail => DoSomethingThatCanFail(true));

            newOutcome.IsSuccesful.Should().BeFalse();
            newOutcome.Failure.Should().BeEquivalentTo(Test.KLeft);
            newOutcome.Success.Should().BeNull();
        }

        [Test]
        public void Outcome_Success_BindFailureBindSuccess()
        {
            var x = ToList(Test.K.Do(f => f.DescType = Test.Left)).ToFailureOutcome<List<TypeT>, List<TypeK>>();
            var outcome = GetSuccessOutcome();
            var newOutcome = outcome
                                .BindFailure(fail => ToList(Test.K.Do(f => f.DescType = Test.Left)).ToFailureOutcome<string, List<TypeK>>())
                                .BindSuccess(succ => ToList(Test.T.Do(t => t.DescType = succ)).ToSuccessOutcome<List<TypeT>, List<TypeK>>());

            newOutcome.IsSuccesful.Should().BeTrue();
            newOutcome.Failure.Should().BeNull();
            newOutcome.Success.Should().BeOfType<List<TypeT>>();
            newOutcome.Success.First().Should().BeEquivalentTo(Test.TRight);
        }

        [Test]
        public void Outcome_Success_BindSuccessBindFailure()
        {            
            var outcome = GetSuccessOutcome();
            var newOutcome = outcome                                
                                .BindSuccess(succ => ToList(Test.T.Do(t => t.DescType = succ)).ToSuccessOutcome<List<TypeT>, string>())
                                .BindFailure(fail => ToList(Test.K.Do(f => f.DescType = Test.Left)).ToFailureOutcome<List<TypeT>, List<TypeK>>());

            newOutcome.IsSuccesful.Should().BeTrue();
            newOutcome.Failure.Should().BeNull();
            newOutcome.Success.Should().BeOfType<List<TypeT>>();
            newOutcome.Success.First().Should().BeEquivalentTo(Test.TRight);
        }


        [Test]
        public void Outcome_Failure_BindFailureBindSuccess()
        {
            var outcome = GetFailureOutcome();
            var newOutcome = outcome
                                .BindFailure(fail => ToList(Test.K.Do(f => f.DescType = Test.Left)).ToFailureOutcome<string, List<TypeK>>())
                                .BindSuccess(succ => ToList(Test.T.Do(t => t.DescType = succ)).ToSuccessOutcome<List<TypeT>, List<TypeK>>());

            newOutcome.IsSuccesful.Should().BeFalse();
            newOutcome.Success.Should().BeNull();
            newOutcome.Failure.Should().BeOfType<List<TypeK>>();
            newOutcome.Failure.First().Should().BeEquivalentTo(Test.TLeft);
        }

        [Test]
        public void Outcome_Failure_BindSuccessBindFailure()
        {
            var outcome = GetFailureOutcome();
            var newOutcome = outcome
                                .BindSuccess(succ => ToList(Test.T.Do(t => t.DescType = succ)).ToSuccessOutcome<List<TypeT>, string>())
                                .BindFailure(fail => ToList(Test.K.Do(f => f.DescType = Test.Left)).ToFailureOutcome<List<TypeT>, List<TypeK>>());

            newOutcome.IsSuccesful.Should().BeFalse();
            newOutcome.Success.Should().BeNull();
            newOutcome.Failure.Should().BeOfType<List<TypeK>>();
            newOutcome.Failure.First().Should().BeEquivalentTo(Test.TLeft);
        }
    }
}