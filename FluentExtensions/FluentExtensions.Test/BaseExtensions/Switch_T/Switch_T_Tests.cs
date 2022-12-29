using FluentAssertions;
using FluentCoding;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.Switch_T
{
    [ExcludeFromCodeCoverage]
    public class Switch_T_Tests
    {

        [Test]
        public void Switch_Func_T_Bool_Default() =>
            Test.T.Switch
            (
                (_) => Test.TRight,
                (_ => false, _ => Test.TNotDone),
                (_ => false, _ => Test.TLeft)
             )
            .Should().BeEquivalentTo(Test.TRight);

        [Test]
        public void Switch_Func_T_Bool_NotDefault1() =>
            Test.T.Switch
            (
                (_) => Test.TRight,
                (_ => true, _ => Test.TNotDone),
                (_ => false, _ => Test.TLeft)
             )
            .Should().BeEquivalentTo(Test.TNotDone);

        [Test]
        public void Switch_Func_T_Bool_NotDefault2() =>
            Test.T.Switch
            (
                (_) => Test.TRight,
                (_ => false, _ => Test.TNotDone),
                (_ => true, _ => Test.TLeft)
             )
            .Should().BeEquivalentTo(Test.TLeft);


        [Test]
        public void Switch_Func_Bool_Default() =>
           Test.T.Switch
           (
               (_) => Test.TRight,
               (() => false, _ => Test.TNotDone),
               (() => false, _ => Test.TLeft)
            )
           .Should().BeEquivalentTo(Test.TRight);

        [Test]
        public void Switch_Func_Bool_NotDefault1() =>
            Test.T.Switch
            (
                (_) => Test.TRight,
                (() => true, _ => Test.TNotDone),
                (() => false, _ => Test.TLeft)
             )
            .Should().BeEquivalentTo(Test.TNotDone);

        [Test]
        public void Switch_Func_Bool_NotDefault2() =>
            Test.T.Switch
            (
                (_) => Test.TRight,
                (() => false, _ => Test.TNotDone),
                (() => true, _ => Test.TLeft)
             )
            .Should().BeEquivalentTo(Test.TLeft);


        [Test]
        public void Switch_Bool_Default() =>
          Test.T.Switch
          (
              (_) => Test.TRight,
              (false, _ => Test.TNotDone),
              (false, _ => Test.TLeft)
           )
          .Should().BeEquivalentTo(Test.TRight);

        [Test]
        public void Switch_Bool_NotDefault1() =>
            Test.T.Switch
            (
                (_) => Test.TRight,
                (true, _ => Test.TNotDone),
                (false, _ => Test.TLeft)
             )
            .Should().BeEquivalentTo(Test.TNotDone);

        [Test]
        public void Switch_Bool_NotDefault2() =>
            Test.T.Switch
            (
                (_) => Test.TRight,
                (false, _ => Test.TNotDone),
                (true, _ => Test.TLeft)
             )
            .Should().BeEquivalentTo(Test.TLeft);
    }
}
