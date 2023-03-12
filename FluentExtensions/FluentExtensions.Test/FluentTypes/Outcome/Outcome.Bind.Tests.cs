using FluentAssertions;
using FluentCoding;

using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace FluentCoding.Test.FluentTypes.Outcome
{
    [ExcludeFromCodeCoverage]
    public class Outcome_Bind_Tests
    {

        private Outcome<string, string> GetSuccessOutcome()
            => Outcome<string, string>.ToSuccess(Test.RIGHT);

        private Outcome<string, string> GetFailureOutcome()
            => Outcome<string, string>.ToFailure(Test.LEFT);

        private List<T> ToList<T>(T subject) => new List<T> { subject };

        private Outcome<TType, KType> DoSomethingThatCanFail(bool isFailing)
            => isFailing ? Outcome<TType, KType>.ToFailure(Test.NewKLeft) : Outcome<TType, KType>.ToSuccess(Test.NewTRight);

        [Test]
        public void Outcome_Success_Bind_SuccessBindResult()
        {

            var outcome = GetSuccessOutcome();
            var newOutcome = outcome
                                .Bind(succ => DoSomethingThatCanFail(false),
                                     fail => Test.NewKNotDone.ToFailureOutcome<TType, KType>());

            newOutcome.IsSuccessful.Should().BeTrue();
            newOutcome.Failure.Should().BeNull();
            newOutcome.Success.Should().BeEquivalentTo(Test.NewTRight);
        }

        [Test]
        public void Outcome_Success_Bind_FailureBindResult()
        {
            var outcome = GetSuccessOutcome();
            var newOutcome = outcome
                                .Bind(succ => DoSomethingThatCanFail(true),
                                     fail => Test.NewKNotDone.ToFailureOutcome<TType, KType>());

            newOutcome.IsSuccessful.Should().BeFalse();
            newOutcome.Failure.Should().BeEquivalentTo(Test.NewKLeft);
            newOutcome.Success.Should().BeNull();
        }


        [Test]
        public void Outcome_Failure_Bind_SuccessBindResult()
        {
            var outcome = GetFailureOutcome();
            var newOutcome = outcome
                                .Bind(succ => Test.NewTDone.ToSuccessOutcome<TType, KType>(),
                                     fail => DoSomethingThatCanFail(false));

            newOutcome.IsSuccessful.Should().BeTrue();
            newOutcome.Failure.Should().BeNull();
            newOutcome.Success.Should().BeEquivalentTo(Test.NewTRight);
        }

        [Test]
        public void Outcome_Failure_Bind_FailureBindResult()
        {
            var outcome = GetFailureOutcome();
            var newOutcome = outcome
                                .Bind(succ => Test.NewTDone.ToSuccessOutcome<TType, KType>(),
                                      fail => DoSomethingThatCanFail(true));

            newOutcome.IsSuccessful.Should().BeFalse();
            newOutcome.Failure.Should().BeEquivalentTo(Test.NewKLeft);
            newOutcome.Success.Should().BeNull();
        }

        [Test]
        public void Outcome_Success_BindFailureBindSuccess()
        {
            var x = ToList(Test.NewK.Do(f => f.KDesc = Test.LEFT)).ToFailureOutcome<List<TType>, List<KType>>();
            var outcome = GetSuccessOutcome();
            var newOutcome = outcome
                                .BindFailure(fail => ToList(Test.NewK.Do(f => f.KDesc = Test.LEFT)).ToFailureOutcome<string, List<KType>>())
                                .BindSuccess(succ => ToList(Test.NewT.Do(t => t.TDesc = succ)).ToSuccessOutcome<List<TType>, List<KType>>());

            newOutcome.IsSuccessful.Should().BeTrue();
            newOutcome.Failure.Should().BeNull();
            newOutcome.Success.Should().BeOfType<List<TType>>();
            newOutcome.Success.First().Should().BeEquivalentTo(Test.NewTRight);
        }

        [Test]
        public void Outcome_Success_BindSuccessBindFailure()
        {
            var outcome = GetSuccessOutcome();
            var newOutcome = outcome
                                .BindSuccess(succ => ToList(Test.NewT.Do(t => t.TDesc = succ)).ToSuccessOutcome<List<TType>, string>())
                                .BindFailure(fail => ToList(Test.NewK.Do(f => f.KDesc = Test.LEFT)).ToFailureOutcome<List<TType>, List<KType>>());

            newOutcome.IsSuccessful.Should().BeTrue();
            newOutcome.Failure.Should().BeNull();
            newOutcome.Success.Should().BeOfType<List<TType>>();
            newOutcome.Success.First().Should().BeEquivalentTo(Test.NewTRight);
        }


        [Test]
        public void Outcome_Failure_BindFailureBindSuccess()
        {
            var outcome = GetFailureOutcome();
            var newOutcome = outcome
                                .BindFailure(fail => ToList(Test.NewK.Do(f => f.KDesc = Test.LEFT)).ToFailureOutcome<string, List<KType>>())
                                .BindSuccess(succ => ToList(Test.NewT.Do(t => t.TDesc = succ)).ToSuccessOutcome<List<TType>, List<KType>>());

            newOutcome.IsSuccessful.Should().BeFalse();
            newOutcome.Success.Should().BeNull();
            newOutcome.Failure.Should().BeOfType<List<KType>>();
            newOutcome.Failure.First().Should().BeEquivalentTo(Test.NewKLeft);
        }

        [Test]
        public void Outcome_Failure_BindSuccessBindFailure()
        {
            var outcome = GetFailureOutcome();
            var newOutcome = outcome
                                .BindSuccess(succ => ToList(Test.NewT.Do(t => t.TDesc = succ)).ToSuccessOutcome<List<TType>, string>())
                                .BindFailure(fail => ToList(Test.NewK.Do(f => f.KDesc = Test.LEFT)).ToFailureOutcome<List<TType>, List<KType>>());

            newOutcome.IsSuccessful.Should().BeFalse();
            newOutcome.Success.Should().BeNull();
            newOutcome.Failure.Should().BeOfType<List<KType>>();
            newOutcome.Failure.First().Should().BeEquivalentTo(Test.NewKLeft);
        }

        [TestCase(true, true, true)]
        [TestCase(true, true, false)]
        [TestCase(true, false, false)]
        [TestCase(false, false, false)]
        [TestCase(false, true, true)]
        [TestCase(false, false, true)]
        [TestCase(false, true, false)]
        [TestCase(true, false, true)]

        public void Outcome_Cascade_BindSuccess(bool isBind1Success, bool isBind2Success, bool isBind3Success)
        {
            var outcome = "0".ToSuccessOutcome<string, string>();
            var newOutcome = outcome
                                .BindSuccess(succ => isBind1Success ? (int.Parse(succ) + 1).ToSuccessOutcome<int, string>() : "ErrorBind1".ToFailureOutcome<int, string>())
                                .BindSuccess(succ => isBind2Success ? (succ + 1).ToString().ToSuccessOutcome<string, string>() : "ErrorBind2".ToFailureOutcome<string, string>())
                                .BindSuccess(succ => isBind3Success ? (int.Parse(succ) + 1).ToSuccessOutcome<int, string>() : "ErrorBind3".ToFailureOutcome<int, string>())
                                .MapSuccess(succ => succ.ToString());


            newOutcome.IsSuccessful.Should().Be(isBind1Success && isBind2Success && isBind3Success);

            if (newOutcome.IsSuccessful)
            {
                newOutcome.Failure.Should().BeNull();
                newOutcome.Success.Should().Be("3");
            }

            else if (!isBind1Success)
            {
                newOutcome.Success.Should().BeNull();
                newOutcome.Failure.Should().Be("ErrorBind1");
            }
            else if (isBind1Success && !isBind2Success)
            {
                newOutcome.Success.Should().BeNull();
                newOutcome.Failure.Should().Be("ErrorBind2");
            }
            else if (isBind1Success && isBind2Success && !isBind3Success)
            {
                newOutcome.Success.Should().BeNull();
                newOutcome.Failure.Should().Be("ErrorBind3");
            }
            else
                Assert.Fail("unmanaged case");


        }
    }

}