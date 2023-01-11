using FluentAssertions;
using FluentCoding;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest
{
    [ExcludeFromCodeCoverage]
    public class MixingTests
    {

        [TestCase(4, 6)]
        [TestCase(6, 4)]
        [TestCase(5, 5)]
        public void Or_Map(int left, int right)
        {
            left.Or(right, (l, r) => l < r)
                .Map(_ => _.ToString())
                .Should().Be(left < right ? right.ToString() : left.ToString());
        }

        [TestCase("left")]
        [TestCase("right")]
        [TestCase("not-ok")]
        public void When_OrWhen_Then_TryWrap(string subject)
        {
            subject.When(_ => _.Equals(Test.Left))
                .OrWhen(_ => _.Equals(Test.Right))
                .Then(_ => Test.Done)
                .TryTo(_ => _, (s, e) => Test.NotDone)
                .Should().Be(subject.EqualsToAny(Test.Left, Test.Right) ? Test.Done : "not-ok");
        }

        [Test]
        public void When_OrWhen_Then_TryTo_Or_Exception()
        {
            "".When(_ => _.Equals(Test.Left))
                .AndWhen(_ => _.Equals(Test.Right))
                .Then(_ => Test.Done)
                .TryTo(_ => Test.Done.Or(Test.GetException<string>(), _.Equals(Test.Done)), (s, e) => Test.NotDone)
                .Should().Be(Test.NotDone);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Or_DoWhen_Func(bool isTrue)
        {
            Test.GetDefault<TypeT>().Or(Test.T)
                .When((_) => isTrue)
                .Then(_ => _.DescType = Test.Done)
                .Should().BeEquivalentTo(isTrue ? Test.TDone : Test.T);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Or_DoWhen_Bool(bool isTrue)
        {
            Test.GetDefault<TypeT>().Or(Test.T)
                .When(isTrue)
                .Then(_ => _.DescType = Test.Done)
                .Should().BeEquivalentTo(isTrue ? Test.TDone : Test.T);
        }

        [Test]
        public void Or_DoWhen_Satisfy()
        {
            Test.TRight.Or(Test.TLeft)
                .When(_ => _.DescType == Test.Left).Then(_ => _.DescType = Test.Done)
                .Is(_ => _.DescType == Test.Right)
                .IsSatisfied.Should().BeTrue();
        }

        [Test]
        public void Try_When_ThenMap_Map_When_Then_Do()
        {
            var outcome =
                Test.TLeft.Try(_ => Test.TDone)
                .When(_ => _.IsSuccesful)
                .Then
                (
                   _ => _.Map(_ => _.Result)
                         .When(_ => _.DescType == Test.Done)
                         .Then(_ => _.Do(_ => _.DescType = Test.Right),
                               _ => _.Do(_ => _.DescType = Test.Left)),
                   _ => Test.TNotDone
                )
                .Should().BeEquivalentTo(Test.TRight);
        }

        [Test]
        public void Try_Then_Is_When_ThenMap_Map()
        {
            var outcome =
                Test.TLeft.Try(_ => Test.TDone, (_, e) => e)
                .Then
                (
                   _ => _.Is(__ => !__.IsNullOrEquivalent() && __.DescType == Test.NotDone)
                            .When(_ => _.IsSatisfied)
                            .Then(_ => Test.TDone, _ => Test.TNotDone),
                   (_, e) => Test.EException
                )
                .Map(_ => _.Success.Or(Test.TNotDone))
                .Should().BeEquivalentTo(Test.TNotDone);
        }

        [Test]
        public void Map_Do_SwitchMap_EqualsToAny1()
        {
            Test.K
                .Map(_ => Test.EException)
                .Do(_ => _.Source = Test.Done)
                .Switch
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
                .Do(_ => _.Source = Test.Done)
                .Switch
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
                _ => _.Do(_ => _.result.DescType = "PRESENT"),
                (_ => _.time > DateTime.Now.AddDays(12), _ => _.Do(_ => _.result.DescType = "FUTURE")),
                (_ => _.time < DateTime.Now.AddDays(-12), _ => _.Do(_ => _.result.DescType = "PAST"))
            )
            .Map(_ => "BACK TO THE: " + _.result.DescType)
            .Should().Be("BACK TO THE: PRESENT");
        }

        [Test]
        public void WhenThenCascade()
        {
            Test.GetDefault<TypeK>().Or(Test.K)
                  .When(_ => _.DescType == "XXX")
                  .Then(_ => _.DescType = Test.NotDone)
                  .When(_ => _ is TypeK)
                  .Then(_ => _.DescType = Test.Done)
                  .When(_ => !_.IsNullOrEquivalent())
                  .Then(_ => _.DescType += " NOT NULL")
                  .Map(_ => _.DescType)
                  .Should().Be(Test.Done + " NOT NULL");
        }

        [Test]
        public void Do_When_Then_Do_Map_Map_Try_Do_Do_Map()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            var t = dic.Do(_ => _.Add("1", "1"))
                       .When(_ => _.ContainsKey("1"))
                       .Then(_ => _.Do(_ => _["1"] = _["1"].Map(v => int.Parse(v) + 1)
                                                                        .Map(i => i.ToString())))
                       .Try(_ => _.Do(d => d.Add("1", "1")), (_, e) => _.Do(_ => _.Add("2", "1")))
                       .Map(_ => _.Subject);
            t["1"].Should().Be("2");
            t["2"].Should().Be("1");
        }
    }
}

