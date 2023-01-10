using FluentAssertions;
using FluentCoding;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.SwitchAsync_T
{
    [ExcludeFromCodeCoverage]
    public class SwitchAsync_Tests
    {

        #region TEST PREDICATE AS boolean
        [Test]
        public void SwitchAsync_Bool_Default() =>
          Test.T.ToTask().SwitchAsync
          (
              (_) => Test.TRight,
              (false, _ => Test.TNotDone),
              (false, _ => Test.TLeft)
           )
          .Result.Should().BeEquivalentTo(Test.TRight);

        [Test]
        public void SwitchAsync_Bool_NotDefault1() =>
            Test.T.ToTask().SwitchAsync
            (
                (_) => Test.TRight,
                (true, _ => Test.TNotDone),
                (false, _ => Test.TLeft)
             )
            .Result.Should().BeEquivalentTo(Test.TNotDone);

        [Test]
        public void SwitchAsync_Bool_NotDefault2() =>
            Test.T.ToTask().SwitchAsync
            (
                (_) => Test.TRight,
                (false, _ => Test.TNotDone),
                (true, _ => Test.TLeft)
             )
            .Result.Should().BeEquivalentTo(Test.TLeft);
        #endregion

        #region TEST PREDICATE AS Func without parameters
        [Test]
        public void SwitchAsync_Func_Bool_Default() =>
           Test.T.ToTask().SwitchAsync
           (
               (_) => Test.TRight,
               (() => false, _ => Test.TNotDone),
               (() => false, _ => Test.TLeft)
            )
           .Result.Should().BeEquivalentTo(Test.TRight);

        [Test]
        public void SwitchAsync_Func_Bool_NotDefault1() =>
            Test.T.ToTask().SwitchAsync
            (
                (_) => Test.TRight,
                (() => true, _ => Test.TNotDone),
                (() => false, _ => Test.TLeft)
             )
            .Result.Should().BeEquivalentTo(Test.TNotDone);

        [Test]
        public void SwitchAsync_Func_Bool_NotDefault2() =>
            Test.T.ToTask().SwitchAsync
            (
                (_) => Test.TRight,
                (() => false, _ => Test.TNotDone),
                (() => true, _ => Test.TLeft)
             )
            .Result.Should().BeEquivalentTo(Test.TLeft);
        #endregion

        #region TEST PREDICATE AS Func with Subject as parameter
        [Test]
        public void SwitchAsync_Func_T_Bool_Default() =>
            Test.T.ToTask().SwitchAsync
            (
                (_) => Test.TRight,
                (_ => false, _ => Test.TNotDone),
                (_ => false, _ => Test.TLeft)
             )
            .Result.Should().BeEquivalentTo(Test.TRight);

        [Test]
        public void SwitchAsync_Func_T_Bool_NotDefault1() =>
            Test.T.ToTask().SwitchAsync
            (
                (_) => Test.TRight,
                (_ => true, _ => Test.TNotDone),
                (_ => false, _ => Test.TLeft)
             )
            .Result.Should().BeEquivalentTo(Test.TNotDone);

        [Test]
        public void SwitchAsync_Func_T_Bool_NotDefault2() =>
            Test.T.ToTask().SwitchAsync
            (
                (_) => Test.TRight,
                (_ => false, _ => Test.TNotDone),
                (_ => true, _ => Test.TLeft)
             )
            .Result.Should().BeEquivalentTo(Test.TLeft);
        #endregion 

       

    }
}
