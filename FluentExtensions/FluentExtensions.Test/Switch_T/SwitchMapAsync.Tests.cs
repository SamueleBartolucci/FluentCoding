using FluentAssertions;
using FluentCoding;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.Switch_T
{
    [ExcludeFromCodeCoverage]
    public class SwitchMapAsync_T_Tests
    {

        [Test]
        public void SwitchMapAsync_Func_T_Bool_Default() =>
            Test.T.ToTask().SwitchAsync
            (
                (_) => Test.KRight,
                (_ => false, _ => Test.KNotDone),
                (_ => false, _ => Test.KLeft)
             )
            .Result.Should().BeEquivalentTo(Test.KRight);

        [Test]
        public void SwitchMapAsync_Func_T_Bool_NotDefault1() =>
            Test.T.ToTask().SwitchAsync
            (
                (_) => Test.KRight,
                (_ => true, _ => Test.KNotDone),
                (_ => false, _ => Test.KLeft)
             )
            .Result.Should().BeEquivalentTo(Test.KNotDone);

        [Test]
        public void SwitchMapAsync_Func_T_Bool_NotDefault2() =>
            Test.T.ToTask().SwitchAsync
            (
                (_) => Test.KRight,
                (_ => false, _ => Test.KNotDone),
                (_ => true, _ => Test.KLeft)
             )
            .Result.Should().BeEquivalentTo(Test.KLeft);


        [Test]
        public void SwitchMapAsync_Func_Bool_Default() =>
           Test.T.ToTask().SwitchAsync
           (
               (_) => Test.KRight,
               (() => false, _ => Test.KNotDone),
               (() => false, _ => Test.KLeft)
            )
           .Result.Should().BeEquivalentTo(Test.KRight);

        [Test]
        public void SwitchMapAsync_Func_Bool_NotDefault1() =>
            Test.T.ToTask().SwitchAsync
            (
                (_) => Test.KRight,
                (() => true, _ => Test.KNotDone),
                (() => false, _ => Test.KLeft)
             )
            .Result.Should().BeEquivalentTo(Test.KNotDone);

        [Test]
        public void SwitchMapAsync_Func_Bool_NotDefault2() =>
            Test.T.ToTask().SwitchAsync
            (
                (_) => Test.KRight,
                (() => false, _ => Test.KNotDone),
                (() => true, _ => Test.KLeft)
             )
            .Result.Should().BeEquivalentTo(Test.KLeft);


        [Test]
        public void SwitchMapAsync_Bool_Default() =>
          Test.T.ToTask().SwitchAsync
          (
              (_) => Test.KRight,
              (false, _ => Test.KNotDone),
              (false, _ => Test.KLeft)
           )
          .Result.Should().BeEquivalentTo(Test.KRight);

        [Test]
        public void SwitchMapAsync_Bool_NotDefault1() =>
            Test.T.ToTask().SwitchAsync
            (
                (_) => Test.KRight,
                (true, _ => Test.KNotDone),
                (false, _ => Test.KLeft)
             )
            .Result.Should().BeEquivalentTo(Test.KNotDone);

        [Test]
        public void SwitchMapAsync_Bool_NotDefault2() =>
            Test.T.ToTask().SwitchAsync
            (
                (_) => Test.KRight,
                (false, _ => Test.KNotDone),
                (true, _ => Test.KLeft)
             )
            .Result.Should().BeEquivalentTo(Test.KLeft);
    }
}
