using FluentAssertions;
using FluentCoding;

using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using System.Diagnostics.CodeAnalysis;


namespace FluentCoding.Test.FluentExtensions.Switch
{
    [ExcludeFromCodeCoverage]
    public class SwitchAsync_Tests
    {

        #region TEST PREDICATE AS boolean
        [Test]
        public void SwitchAsync_Bool_Default() =>
          Test.NewT.ToTask().SwitchAsync
          (
              (_) => Test.NewTRight,
              (false, _ => Test.NewTNotDone),
              (false, _ => Test.NewTLeft)
           )
          .Result.Should().BeEquivalentTo(Test.NewTRight);

        [Test]
        public void SwitchAsync_Bool_NotDefault1() =>
            Test.NewT.ToTask().SwitchAsync
            (
                (_) => Test.NewTRight,
                (true, _ => Test.NewTNotDone),
                (false, _ => Test.NewTLeft)
             )
            .Result.Should().BeEquivalentTo(Test.NewTNotDone);

        [Test]
        public void SwitchAsync_Bool_NotDefault2() =>
            Test.NewT.ToTask().SwitchAsync
            (
                (_) => Test.NewTRight,
                (false, _ => Test.NewTNotDone),
                (true, _ => Test.NewTLeft)
             )
            .Result.Should().BeEquivalentTo(Test.NewTLeft);
        #endregion

        #region TEST PREDICATE AS Func without parameters
        [Test]
        public void SwitchAsync_Func_Bool_Default() =>
           Test.NewT.ToTask().SwitchAsync
           (
               (_) => Test.NewTRight,
               (() => false, _ => Test.NewTNotDone),
               (() => false, _ => Test.NewTLeft)
            )
           .Result.Should().BeEquivalentTo(Test.NewTRight);

        [Test]
        public void SwitchAsync_Func_Bool_NotDefault1() =>
            Test.NewT.ToTask().SwitchAsync
            (
                (_) => Test.NewTRight,
                (() => true, _ => Test.NewTNotDone),
                (() => false, _ => Test.NewTLeft)
             )
            .Result.Should().BeEquivalentTo(Test.NewTNotDone);

        [Test]
        public void SwitchAsync_Func_Bool_NotDefault2() =>
            Test.NewT.ToTask().SwitchAsync
            (
                (_) => Test.NewTRight,
                (() => false, _ => Test.NewTNotDone),
                (() => true, _ => Test.NewTLeft)
             )
            .Result.Should().BeEquivalentTo(Test.NewTLeft);
        #endregion

        #region TEST PREDICATE AS Func with Subject as parameter
        [Test]
        public void SwitchAsync_Func_T_Bool_Default() =>
            Test.NewT.ToTask().SwitchAsync
            (
                (_) => Test.NewTRight,
                (_ => false, _ => Test.NewTNotDone),
                (_ => false, _ => Test.NewTLeft)
             )
            .Result.Should().BeEquivalentTo(Test.NewTRight);

        [Test]
        public void SwitchAsync_Func_T_Bool_NotDefault1() =>
            Test.NewT.ToTask().SwitchAsync
            (
                (_) => Test.NewTRight,
                (_ => true, _ => Test.NewTNotDone),
                (_ => false, _ => Test.NewTLeft)
             )
            .Result.Should().BeEquivalentTo(Test.NewTNotDone);

        [Test]
        public void SwitchAsync_Func_T_Bool_NotDefault2() =>
            Test.NewT.ToTask().SwitchAsync
            (
                (_) => Test.NewTRight,
                (_ => false, _ => Test.NewTNotDone),
                (_ => true, _ => Test.NewTLeft)
             )
            .Result.Should().BeEquivalentTo(Test.NewTLeft);
        #endregion



    }
}
