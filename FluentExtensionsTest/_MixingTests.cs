using FluentAssertions;
using FluentExtensions;
using FluentExtensions.When;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using System.Diagnostics.CodeAnalysis;
using System.Net.Security;

namespace FluentCodingTest
{
    [ExcludeFromCodeCoverage]
    public class MixingTests
    {

        [TestCase(true)]
        [TestCase(false)]
        public void Or_DoWhen_Func(bool isTrue)
        {
            Test.GetDefault<TypeT>().Or(Test.T)
                .When((_) => isTrue)
                .ThenDo(_ => _.DescType = Test.Done)
                .Should().BeEquivalentTo(isTrue? Test.TDone : Test.T);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Or_DoWhen_Bool(bool isTrue)
        {
            Test.GetDefault<TypeT>().Or(Test.T)
                .When(true)
                .ThenDo(_ => _.DescType = Test.Done)
                .Should().BeEquivalentTo(isTrue ? Test.TDone : Test.T);
        }

        [Test]
        public void Or_DoWhen_Satisfy()
        {
            Test.TRight.Or(Test.TLeft)
                .TouchWhen(_ => _.DescType == Test.Left, _ => _.DescType = Test.Done)
                .Satisfy(_ => _.DescType == Test.Right)
                .IsSatisfied.Should().BeTrue();
        }

        [Test]
        public void Try_ContinueTryWith_Satisfy_WhenSatify_Map()
        {
            var outcome =
                Test.TLeft.Try(_ => Test.TDone, e => e)
                .ContinueTryWith
                (
                   _ => _.Is(__ => __.DescType == Test.Done)
                            .WhenSatisfiedDo(_ => Test.TRight)
                            .WhenNotSatisfiedDo(_ => Test.TNotDone)
                            .Map(__ => __.Subject),
                   _ => Test.EException
                )
                .Map(_ => _.Result)
                .Should().BeEquivalentTo(Test.TRight);
        }

        [Test]
        public void Try_ContinueTryWith_Satisfy_IsNullOrDefault_WhenSatify_Map2()
        {
            var outcome =
                Test.TLeft.Try(_ => Test.TDone, e => e)
                .ContinueTryWith
                (
                   _ => _.Is(__ => !__.IsNullOrDefault() && __.DescType == Test.NotDone)
                            .WhenSatisfiedDo(_ => Test.TRight)
                            .WhenNotSatisfiedDo(_ => Test.TNotDone)
                            .Map(__ => __.Subject),
                   _ => Test.EException
                )
                .Map(_ => _.Result)
                .Should().BeEquivalentTo(Test.TNotDone);
        }

        [Test]
        public void Map_Do_SwitchMap_EqualsToAny1()
        {
            Test.K
                .Map(_ => Test.EException)
                .Do((_ => _.Source = Test.Done)
                .SwitchMap
                (
                    _ => _.Source,
                    (_ => _.Source == Test.NotDone, _ => Test.NotDone),
                    (_ => _.Source == Test.Left, _ => Test.Left)
                )
                .EqualsToAny(Test.Left, Test.NotDone, Test.Done)
                .Should().BeTrue();
        }

        [Test]
        public void Map_Do_SwitchMap_EqualsToAny2()
        {
            Test.K
                .Map(_ => Test.EException)
                .Do((_ => _.Source = Test.Done)
                .SwitchMap
                (
                    _ => _.Source,
                    (_ => _.Source == Test.NotDone, _ => Test.NotDone),
                    (_ => _.Source == Test.Left, _ => Test.Left)
                )
                .EqualsToAny(Test.Left, Test.NotDone, Test.Right)
                .Should().BeFalse();
        }


        [Test]
        public void Switch_Do_Map()
        {
                (result: Test.T, time: DateTime.Now)
                .Switch
                (
                    _ => _.Do((_ => _.result.DescType = "PRESENT"),
                    (_ => _.time > DateTime.Now.AddDays(12), _ => _.Do((_ => _.result.DescType = "FUTURE")),
                    (_ => _.time < DateTime.Now.AddDays(-12), _ => _.Do((_ => _.result.DescType = "PAST"))
                )
                .Map(_ => "BACK TO THE: " + _.result.DescType)
                .Should().Be("BACK TO THE: PRESENT");
        }

        [Test]
        public void DoCascade()
        {
            Test.GetDefault<TypeK>().Or(Test.K)
                  .TouchWhen(_ => _.DescType == "XXX", _ => _.DescType = Test.NotDone)
                  .TouchWhen(_ => _ is TypeK, _ => _.DescType = Test.Done)
                  .TouchWhen(_ => !_.IsNullOrDefault(), _ => _.DescType += " NOT NULL")
                  .Map(_ => _.DescType)
                  .Should().Be(Test.Done+" NOT NULL");
        }

        [Test]
        public void DoMapCascade()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            var t = dic.Do((_ => _.Add("1", "1"))
                .TouchWhen
                (
                    _ => _.ContainsKey("1"),
                    _ => dic["1"].Do((__ => __.Map(__ => int.Parse(__))
                                             .Map(__ => __.ToString()))
                )
                .Try(_ => _.Dod => d.Add("1", "1")), _ => Test.EException)
                //.WhenTryException((src, ex) => (src, src, ex))
                .WhenTryException((s, e) => (s.Do__ => __.Add("2", "1")), s, null as Exception))
                .Map(_ => _.Result);

            t["1"].Should().Be("2");
            t["2"].Should().Be("1");

        }
    }
}

