using FluentAssertions;
using FluentExtensions;
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
                .When(_ => _.DescType == Test.Left).ThenDo(_ => _.DescType = Test.Done)
                .Is(_ => _.DescType == Test.Right)
                .IsSatisfied.Should().BeTrue();
        }

        [Test]
        public void Try_ContinueTryWith_Satisfy_WhenSatify_Map()
        {
            var outcome =
                Test.TLeft.Try(_ => Test.TDone)
                .When(_ => _.IsSuccesful)
                .ThenMap
                (
                   _ => _.Map(_ => _.Result)
                         .When(_ => _.DescType == Test.Done)
                         .ThenDo(_ => _.Do(_ => _.DescType = Test.Right),
                                 _ => _.Do(_ => _.DescType = Test.Left)),
                   _ => Test.TNotDone
                )
                .Should().BeEquivalentTo(Test.TRight);
        }

        //[Test]
        //public void Try_ContinueTryWith_Satisfy_IsNullOrDefault_WhenSatify_Map2()
        //{
        //    var outcome =
        //        Test.TLeft.Try(_ => Test.TDone, e => e)
        //        .ContinueTryWith
        //        (
        //           _ => _.Is(__ => !__.IsNullOrDefault() && __.DescType == Test.NotDone)
        //                    .WhenSatisfiedDo(_ => Test.TRight)
        //                    .WhenNotSatisfiedDo(_ => Test.TNotDone)
        //                    .Map(__ => __.Subject),
        //           _ => Test.EException
        //        )
        //        .Map(_ => _.Result)
        //        .Should().BeEquivalentTo(Test.TNotDone);
        //}

        [Test]
        public void Map_Do_SwitchMap_EqualsToAny1()
        {
            Test.K
                .Map(_ => Test.EException)
                .Do(_ => _.Source = Test.Done)
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
                .Do(_ => _.Source = Test.Done)
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
                    _ => _.Do(_ => _.result.DescType = "PRESENT"),
                    (_ => _.time > DateTime.Now.AddDays(12), _ => _.Do(_ => _.result.DescType = "FUTURE")),
                    (_ => _.time < DateTime.Now.AddDays(-12), _ => _.Do(_ => _.result.DescType = "PAST"))
                )
                .Map(_ => "BACK TO THE: " + _.result.DescType)
                .Should().Be("BACK TO THE: PRESENT");
        }

        [Test]
        public void DoCascade()
        {
            Test.GetDefault<TypeK>().Or(Test.K)
                  .When(_ => _.DescType == "XXX")
                  .ThenDo(_ => _.DescType = Test.NotDone)
                  .When(_ => _ is TypeK)
                  .ThenDo(_ => _.DescType = Test.Done)
                  .When(_ => !_.IsNullOrDefault())
                  .ThenDo(_ => _.DescType += " NOT NULL")
                  .Map(_ => _.DescType)
                  .Should().Be(Test.Done+" NOT NULL");
        }

        [Test]
        public void DoMapCascade()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            var t = dic.Do(_ => _.Add("1", "1"))
                .When(_ => _.ContainsKey("1"))
                .ThenDo( _ => dic["1"].Do(__ => __.Map(__ => int.Parse(__)).Map(__ => __.ToString())))
                .Try(_ => _.Do(d => d.Add("1", "1")),
                    (s, e) => s.Do(__ => __.Add("2", "1")))
                .Map(_ => _.Subject);

            t["1"].Should().Be("2");
            t["2"].Should().Be("1");

        }
    }
}

