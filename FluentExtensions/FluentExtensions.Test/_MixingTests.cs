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
            subject.When(_ => _.Equals(Test.LEFT))
                .OrWhen(_ => _.Equals(Test.RIGHT))
                .Then(_ => Test.DONE)
                .TryTo(_ => _, (s, e) => Test.NOT_DONE)
                .Should().Be(subject.EqualsToAny(Test.LEFT, Test.RIGHT) ? Test.DONE : "not-ok");
        }

        [Test]
        public void When_OrWhen_Then_TryTo_Or_Exception()
        {
            "".When(_ => _.Equals(Test.LEFT))
                .AndWhen(_ => _.Equals(Test.RIGHT))
                .Then(_ => Test.DONE)
                .TryTo(_ => Test.DONE.Or(Test.RaiseException<string>(), _.Equals(Test.DONE)), (s, e) => Test.NOT_DONE)
                .Should().Be(Test.NOT_DONE);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Or_DoWhen_Func(bool isTrue)
        {
            Test.GetDefault<TType>().Or(Test.NewT)
                .When((_) => isTrue)
                .Then(_ => _.TDesc = Test.DONE)
                .Should().BeEquivalentTo(isTrue ? Test.NewTDone : Test.NewT);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Or_DoWhen_Bool(bool isTrue)
        {
            Test.GetDefault<TType>().Or(Test.NewT)
                .When(isTrue)
                .Then(_ => _.TDesc = Test.DONE)
                .Should().BeEquivalentTo(isTrue ? Test.NewTDone : Test.NewT);
        }

        [Test]
        public void Or_DoWhen_Satisfy()
        {
            Test.NewTRight.Or(Test.NewTLeft)
                .When(_ => _.TDesc == Test.LEFT).Then(_ => _.TDesc = Test.DONE)
                .Is(_ => _.TDesc == Test.RIGHT)
                .IsSatisfied.Should().BeTrue();
        }

        [Test]
        public void Try_When_ThenMap_Map_When_Then_Do()
        {
            var outcome =
                Test.NewTLeft.Try(_ => Test.NewTDone)
                .When(_ => _.IsSuccessful)
                .Then
                (
                   _ => _.Map(_ => _.Result)
                         .When(_ => _.TDesc == Test.DONE)
                         .Then(_ => _.Do(_ => _.TDesc = Test.RIGHT),
                               _ => _.Do(_ => _.TDesc = Test.LEFT)),
                   _ => Test.NewTNotDone
                )
                .Should().BeEquivalentTo(Test.NewTRight);
        }

        [Test]
        public void Try_Then_Is_When_ThenMap_Map()
        {
            var outcome =
                Test.NewTLeft.Try(_ => Test.NewTDone, (_, e) => e)
                .Then
                (
                   _ => _.Is(__ => !__.IsNullOrEquivalent() && __.TDesc == Test.NOT_DONE)
                            .When(_ => _.IsSatisfied)
                            .Then(_ => Test.NewTDone, _ => Test.NewTNotDone),
                   (_, e) => Test.EException
                )
                .Map(_ => _.Success.Or(Test.NewTNotDone))
                .Should().BeEquivalentTo(Test.NewTNotDone);
        }

        [Test]
        public void Map_Do_SwitchMap_EqualsToAny1()
        {
            Test.NewK
                .Map(_ => Test.EException)
                .Do(_ => _.Source = Test.DONE)
                .Switch
                (
                    _ => _.Source,
                    (_ => _.Source == Test.NOT_DONE, _ => Test.NOT_DONE),
                    (_ => _.Source == Test.LEFT, _ => Test.LEFT)
                )
                .EqualsToAny(Test.LEFT, Test.NOT_DONE, Test.DONE)
                .Should().BeTrue();
        }

        [Test]
        public void Map_Do_SwitchMap_EqualsToAny2()
        {
            Test.NewK
                .Map(_ => Test.EException)
                .Do(_ => _.Source = Test.DONE)
                .Switch
                (
                    _ => _.Source,
                    (_ => _.Source == Test.NOT_DONE, _ => Test.NOT_DONE),
                    (_ => _.Source == Test.LEFT, _ => Test.LEFT)
                )
                .EqualsToAny(Test.LEFT, Test.NOT_DONE, Test.RIGHT)
                .Should().BeFalse();
        }


        [Test]
        public void Switch_Do_Map()
        {
            (result: Test.NewT, time: DateTime.Now)
            .Switch
            (
                _ => _.Do(_ => _.result.TDesc = "PRESENT"),
                (_ => _.time > DateTime.Now.AddDays(12), _ => _.Do(_ => _.result.TDesc = "FUTURE")),
                (_ => _.time < DateTime.Now.AddDays(-12), _ => _.Do(_ => _.result.TDesc = "PAST"))
            )
            .Map(_ => "BACK TO THE: " + _.result.TDesc)
            .Should().Be("BACK TO THE: PRESENT");
        }

        [Test]
        public void WhenThenCascade()
        {
            Test.GetDefault<KType>().Or(Test.NewK)
                  .When(_ => _.KDesc == "XXX")
                  .Then(_ => _.KDesc = Test.NOT_DONE)
                  .When(_ => _ is KType)
                  .Then(_ => _.KDesc = Test.DONE)
                  .When(_ => !_.IsNullOrEquivalent())
                  .Then(_ => _.KDesc += " NOT NULL")
                  .Map(_ => _.KDesc)
                  .Should().Be(Test.DONE + " NOT NULL");
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

