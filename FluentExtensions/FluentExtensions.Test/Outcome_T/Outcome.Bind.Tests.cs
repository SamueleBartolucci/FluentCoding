using FluentAssertions;
using FluentCoding;
using FluentCodingTest;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace FluentCodingTest.Outcome
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

            newOutcome.IsSuccessful.Should().BeTrue();
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

            newOutcome.IsSuccessful.Should().BeFalse();
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

            newOutcome.IsSuccessful.Should().BeTrue();
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

            newOutcome.IsSuccessful.Should().BeFalse();
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

            newOutcome.IsSuccessful.Should().BeTrue();
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

            newOutcome.IsSuccessful.Should().BeTrue();
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

            newOutcome.IsSuccessful.Should().BeFalse();
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

            newOutcome.IsSuccessful.Should().BeFalse();
            newOutcome.Success.Should().BeNull();
            newOutcome.Failure.Should().BeOfType<List<TypeK>>();
            newOutcome.Failure.First().Should().BeEquivalentTo(Test.TLeft);
        }

        [TestCase(true, true, true)]
        [TestCase(true, true, false)]
        [TestCase(true, false, false)]
        [TestCase(false, false, false)]
        [TestCase(false, true, true)]
        [TestCase(false, false, true)]
        [TestCase(false, true, false)]
        [TestCase(true, false, true)]

        public void Outcome_Cascade_BindSuccess(bool bind1, bool bind2, bool bind3)
        {
            var outcome = "0".ToSuccessOutcome<string, string>();
            var newOutcome = outcome
                                .BindSuccess(succ => bind1 ? (int.Parse(succ) + 1).ToSuccessOutcome<int, string>() : "ErrorBind1".ToFailureOutcome<int, string>())
                                .BindSuccess(succ => bind2 ? (succ + 1).ToString().ToSuccessOutcome<string, string>() : "ErrorBind2".ToFailureOutcome<string, string>())
                                .BindSuccess(succ => bind3 ? (int.Parse(succ) + 1).ToSuccessOutcome<int, string>() : "ErrorBind3".ToFailureOutcome<int, string>())
                                .MapSuccess(succ => succ.ToString());
            

            newOutcome.IsSuccessful.Should().Be(bind1 && bind2 && bind3);

            if (newOutcome.IsSuccessful)
            {
                newOutcome.Failure.Should().BeNull();
                newOutcome.Success.Should().Be("3");
            }

            else if (!bind1)
            {
                newOutcome.Success.Should().BeNull();
                newOutcome.Failure.Should().Be("ErrorBind1");
            }
            else if (bind1 && !bind2)
            {
                newOutcome.Success.Should().BeNull();
                newOutcome.Failure.Should().Be("ErrorBind2");
            }
            else if (bind1 && bind2 && !bind3)
            {
                newOutcome.Success.Should().BeNull();
                newOutcome.Failure.Should().Be("ErrorBind3");
            }
            else
                Assert.Fail("unmanaged case");
            

        }
    }

}