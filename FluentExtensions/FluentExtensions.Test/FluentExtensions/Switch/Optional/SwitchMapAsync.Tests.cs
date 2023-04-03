using FluentAssertions;
using System.Diagnostics.CodeAnalysis;


namespace FluentCoding.Test.FluentExtensions.SwitchOptnAsync.Optional
{
    [ExcludeFromCodeCoverage]
    public class SwitchOptionAsync_T_Tests
    {

        [Test]
        public void SwitchMap_None() =>
            Test.GetDefault<string>().ToOptional().ToTask().SwitchOptnAsync
            (
                (_) => Test.NewKRight,
                (_ => false, _ => Test.NewKNotDone),
                (_ => false, _ => Test.NewKLeft)
             ).Result.Should().BeEquivalentTo(Optional<string>.None());



        [Test]
        public void SwitchMap_Func_T_Bool_Default() =>
            Test.NewT.ToOptional().ToTask().SwitchOptnAsync
            (
                (_) => Test.NewKRight,
                (_ => false, _ => Test.NewKNotDone),
                (_ => false, _ => Test.NewKLeft)
             )
            .Result.Subject.Should().BeEquivalentTo(Test.NewKRight);

        [Test]
        public void SwitchMap_Func_T_Bool_NotDefault1() =>
            Test.NewT.ToOptional().ToTask().SwitchOptnAsync
            (
                (_) => Test.NewKRight,
                (_ => true, _ => Test.NewKNotDone),
                (_ => false, _ => Test.NewKLeft)
             )
            .Result.Subject.Should().BeEquivalentTo(Test.NewKNotDone);

        [Test]
        public void SwitchMap_Func_T_Bool_NotDefault2() =>
            Test.NewT.ToOptional().ToTask().SwitchOptnAsync
            (
                (_) => Test.NewKRight,
                (_ => false, _ => Test.NewKNotDone),
                (_ => true, _ => Test.NewKLeft)
             )
            .Result.Subject.Should().BeEquivalentTo(Test.NewKLeft);


        [Test]
        public void SwitchMap_Func_Bool_Default() =>
           Test.NewT.ToOptional().ToTask().SwitchOptnAsync
           (
               (_) => Test.NewKRight,
               (() => false, _ => Test.NewKNotDone),
               (() => false, _ => Test.NewKLeft)
            )
           .Result.Subject.Should().BeEquivalentTo(Test.NewKRight);

        [Test]
        public void SwitchMap_Func_Bool_NotDefault1() =>
            Test.NewT.ToOptional().ToTask().SwitchOptnAsync
            (
                (_) => Test.NewKRight,
                (() => true, _ => Test.NewKNotDone),
                (() => false, _ => Test.NewKLeft)
             )
            .Result.Subject.Should().BeEquivalentTo(Test.NewKNotDone);

        [Test]
        public void SwitchMap_Func_Bool_NotDefault2() =>
            Test.NewT.ToOptional().ToTask().SwitchOptnAsync
            (
                (_) => Test.NewKRight,
                (() => false, _ => Test.NewKNotDone),
                (() => true, _ => Test.NewKLeft)
             )
            .Result.Subject.Should().BeEquivalentTo(Test.NewKLeft);


        [Test]
        public void SwitchMap_Bool_Default() =>
          Test.NewT.ToOptional().ToTask().SwitchOptnAsync
          (
              (_) => Test.NewKRight,
              (false, _ => Test.NewKNotDone),
              (false, _ => Test.NewKLeft)
           )
          .Result.Subject.Should().BeEquivalentTo(Test.NewKRight);

        [Test]
        public void SwitchMap_Bool_NotDefault1() =>
            Test.NewT.ToOptional().ToTask().SwitchOptnAsync
            (
                (_) => Test.NewKRight,
                (true, _ => Test.NewKNotDone),
                (false, _ => Test.NewKLeft)
             )
            .Result.Subject.Should().BeEquivalentTo(Test.NewKNotDone);

        [Test]
        public void SwitchMap_Bool_NotDefault2() =>
            Test.NewT.ToOptional().ToTask().SwitchOptnAsync
            (
                (_) => Test.NewKRight,
                (false, _ => Test.NewKNotDone),
                (true, _ => Test.NewKLeft)
             )
            .Result.Subject.Should().BeEquivalentTo(Test.NewKLeft);
    }
}
