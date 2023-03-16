using FluentAssertions;
using FluentCoding;

using System.Diagnostics.CodeAnalysis;


namespace FluentCoding.Test.FluentExtensions.Switch
{
    [ExcludeFromCodeCoverage]
    public class SwitchMapAsync_T_Tests
    {

        [Test]
        public void SwitchMapAsync_Func_T_Bool_Default() =>
            Test.NewT.ToTask().SwitchAsync
            (
                (_) => Test.NewKRight,
                (_ => false, _ => Test.NewKNotDone),
                (_ => false, _ => Test.NewKLeft)
             )
            .Result.Should().BeEquivalentTo(Test.NewKRight);

        [Test]
        public void SwitchMapAsync_Func_T_Bool_NotDefault1() =>
            Test.NewT.ToTask().SwitchAsync
            (
                (_) => Test.NewKRight,
                (_ => true, _ => Test.NewKNotDone),
                (_ => false, _ => Test.NewKLeft)
             )
            .Result.Should().BeEquivalentTo(Test.NewKNotDone);

        [Test]
        public void SwitchMapAsync_Func_T_Bool_NotDefault2() =>
            Test.NewT.ToTask().SwitchAsync
            (
                (_) => Test.NewKRight,
                (_ => false, _ => Test.NewKNotDone),
                (_ => true, _ => Test.NewKLeft)
             )
            .Result.Should().BeEquivalentTo(Test.NewKLeft);


        [Test]
        public void SwitchMapAsync_Func_Bool_Default() =>
           Test.NewT.ToTask().SwitchAsync
           (
               (_) => Test.NewKRight,
               (() => false, _ => Test.NewKNotDone),
               (() => false, _ => Test.NewKLeft)
            )
           .Result.Should().BeEquivalentTo(Test.NewKRight);

        [Test]
        public void SwitchMapAsync_Func_Bool_NotDefault1() =>
            Test.NewT.ToTask().SwitchAsync
            (
                (_) => Test.NewKRight,
                (() => true, _ => Test.NewKNotDone),
                (() => false, _ => Test.NewKLeft)
             )
            .Result.Should().BeEquivalentTo(Test.NewKNotDone);

        [Test]
        public void SwitchMapAsync_Func_Bool_NotDefault2() =>
            Test.NewT.ToTask().SwitchAsync
            (
                (_) => Test.NewKRight,
                (() => false, _ => Test.NewKNotDone),
                (() => true, _ => Test.NewKLeft)
             )
            .Result.Should().BeEquivalentTo(Test.NewKLeft);


        [Test]
        public void SwitchMapAsync_Bool_Default() =>
          Test.NewT.ToTask().SwitchAsync
          (
              (_) => Test.NewKRight,
              (false, _ => Test.NewKNotDone),
              (false, _ => Test.NewKLeft)
           )
          .Result.Should().BeEquivalentTo(Test.NewKRight);

        [Test]
        public void SwitchMapAsync_Bool_NotDefault1() =>
            Test.NewT.ToTask().SwitchAsync
            (
                (_) => Test.NewKRight,
                (true, _ => Test.NewKNotDone),
                (false, _ => Test.NewKLeft)
             )
            .Result.Should().BeEquivalentTo(Test.NewKNotDone);

        [Test]
        public void SwitchMapAsync_Bool_NotDefault2() =>
            Test.NewT.ToTask().SwitchAsync
            (
                (_) => Test.NewKRight,
                (false, _ => Test.NewKNotDone),
                (true, _ => Test.NewKLeft)
             )
            .Result.Should().BeEquivalentTo(Test.NewKLeft);
    }
}
