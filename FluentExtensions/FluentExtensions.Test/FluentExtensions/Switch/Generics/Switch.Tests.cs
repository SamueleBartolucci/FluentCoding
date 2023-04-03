using FluentAssertions;
using System.Diagnostics.CodeAnalysis;


namespace FluentCoding.Test.FluentExtensions.Switch.Generics
{
    [ExcludeFromCodeCoverage]
    public class Switch_Tests
    {

        #region TEST PREDICATE AS boolean
        [Test]
        public void Switch_Bool_Default() =>
          Test.NewT.Switch
          (
              (_) => Test.NewTRight,
              (false, _ => Test.NewTNotDone),
              (false, _ => Test.NewTLeft)
           )
          .Should().BeEquivalentTo(Test.NewTRight);

        [Test]
        public void Switch_Bool_NotDefault1() =>
            Test.NewT.Switch
            (
                (_) => Test.NewTRight,
                (true, _ => Test.NewTNotDone),
                (false, _ => Test.NewTLeft)
             )
            .Should().BeEquivalentTo(Test.NewTNotDone);

        [Test]
        public void Switch_Bool_NotDefault2() =>
            Test.NewT.Switch
            (
                (_) => Test.NewTRight,
                (false, _ => Test.NewTNotDone),
                (true, _ => Test.NewTLeft)
             )
            .Should().BeEquivalentTo(Test.NewTLeft);
        #endregion

        #region TEST PREDICATE AS Func without parameters
        [Test]
        public void Switch_Func_Bool_Default() =>
           Test.NewT.Switch
           (
               (_) => Test.NewTRight,
               (() => false, _ => Test.NewTNotDone),
               (() => false, _ => Test.NewTLeft)
            )
           .Should().BeEquivalentTo(Test.NewTRight);

        [Test]
        public void Switch_Func_Bool_NotDefault1() =>
            Test.NewT.Switch
            (
                (_) => Test.NewTRight,
                (() => true, _ => Test.NewTNotDone),
                (() => false, _ => Test.NewTLeft)
             )
            .Should().BeEquivalentTo(Test.NewTNotDone);

        [Test]
        public void Switch_Func_Bool_NotDefault2() =>
            Test.NewT.Switch
            (
                (_) => Test.NewTRight,
                (() => false, _ => Test.NewTNotDone),
                (() => true, _ => Test.NewTLeft)
             )
            .Should().BeEquivalentTo(Test.NewTLeft);
        #endregion

        #region TEST PREDICATE AS Func with Subject as parameter
        [Test]
        public void Switch_Func_T_Bool_Default() =>
            Test.NewT.Switch
            (
                (_) => Test.NewTRight,
                (_ => false, _ => Test.NewTNotDone),
                (_ => false, _ => Test.NewTLeft)
             )
            .Should().BeEquivalentTo(Test.NewTRight);

        [Test]
        public void Switch_Func_T_Bool_NotDefault1() =>
            Test.NewT.Switch
            (
                (_) => Test.NewTRight,
                (_ => true, _ => Test.NewTNotDone),
                (_ => false, _ => Test.NewTLeft)
             )
            .Should().BeEquivalentTo(Test.NewTNotDone);

        [Test]
        public void Switch_Func_T_Bool_NotDefault2() =>
            Test.NewT.Switch
            (
                (_) => Test.NewTRight,
                (_ => false, _ => Test.NewTNotDone),
                (_ => true, _ => Test.NewTLeft)
             )
            .Should().BeEquivalentTo(Test.NewTLeft);
        #endregion



    }
}
