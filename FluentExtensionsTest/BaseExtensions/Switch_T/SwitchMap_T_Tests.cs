using FluentAssertions;
using FluentCoding;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.Switch_T
{
    [ExcludeFromCodeCoverage]
    public class SwitchMap_T_Tests
    {

        [Test]
        public void SwitchMap_Func_T_Bool_Default() =>
            Test.T.SwitchMap
            (
                (_) => Test.KRight,
                (_ => false, _ => Test.KNotDone),
                (_ => false, _ => Test.KLeft)
             )
            .Should().BeEquivalentTo(Test.KRight);

        [Test]
        public void SwitchMap_Func_T_Bool_NotDefault1() =>
            Test.T.SwitchMap
            (
                (_) => Test.KRight,
                (_ => true, _ => Test.KNotDone),
                (_ => false, _ => Test.KLeft)
             )
            .Should().BeEquivalentTo(Test.KNotDone);

        [Test]
        public void SwitchMap_Func_T_Bool_NotDefault2() =>
            Test.T.SwitchMap
            (
                (_) => Test.KRight,
                (_ => false, _ => Test.KNotDone),
                (_ => true, _ => Test.KLeft)
             )
            .Should().BeEquivalentTo(Test.KLeft);


        [Test]
        public void SwitchMap_Func_Bool_Default() =>
           Test.T.SwitchMap
           (
               (_) => Test.KRight,
               (() => false, _ => Test.KNotDone),
               (() => false, _ => Test.KLeft)
            )
           .Should().BeEquivalentTo(Test.KRight);

        [Test]
        public void SwitchMap_Func_Bool_NotDefault1() =>
            Test.T.SwitchMap
            (
                (_) => Test.KRight,
                (() => true, _ => Test.KNotDone),
                (() => false, _ => Test.KLeft)
             )
            .Should().BeEquivalentTo(Test.KNotDone);

        [Test]
        public void SwitchMap_Func_Bool_NotDefault2() =>
            Test.T.SwitchMap
            (
                (_) => Test.KRight,
                (() => false, _ => Test.KNotDone),
                (() => true, _ => Test.KLeft)
             )
            .Should().BeEquivalentTo(Test.KLeft);


        [Test]
        public void SwitchMap_Bool_Default() =>
          Test.T.SwitchMap
          (
              (_) => Test.KRight,
              (false, _ => Test.KNotDone),
              (false, _ => Test.KLeft)
           )
          .Should().BeEquivalentTo(Test.KRight);

        [Test]
        public void SwitchMap_Bool_NotDefault1() =>
            Test.T.SwitchMap
            (
                (_) => Test.KRight,
                (true, _ => Test.KNotDone),
                (false, _ => Test.KLeft)
             )
            .Should().BeEquivalentTo(Test.KNotDone);

        [Test]
        public void SwitchMap_Bool_NotDefault2() =>
            Test.T.SwitchMap
            (
                (_) => Test.KRight,
                (false, _ => Test.KNotDone),
                (true, _ => Test.KLeft)
             )
            .Should().BeEquivalentTo(Test.KLeft);
    }
}
