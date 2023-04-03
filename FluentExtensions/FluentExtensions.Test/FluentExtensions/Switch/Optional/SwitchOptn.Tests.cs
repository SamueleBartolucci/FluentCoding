using FluentAssertions;
using System.Diagnostics.CodeAnalysis;


namespace FluentCoding.Test.FluentExtensions.SwitchOptn.Optional
{
    [ExcludeFromCodeCoverage]
    public class SwitchOption_T_Tests
    {

        [Test]
        public void SwitchMap_None() =>
            Test.GetDefault<string>().ToOptional().SwitchOptn
            (
                (_) => Test.NewKRight,
                (_ => false, _ => Test.NewKNotDone),
                (_ => false, _ => Test.NewKLeft)
             ).Should().BeEquivalentTo(Optional<string>.None());



        [Test]
        public void SwitchMap_Func_T_Bool_Default() =>
            Test.NewT.ToOptional().SwitchOptn
            (
                (_) => Test.NewKRight,
                (_ => false, _ => Test.NewKNotDone),
                (_ => false, _ => Test.NewKLeft)
             )            
            .Subject.Should().BeEquivalentTo(Test.NewKRight);

        [Test]
        public void SwitchMap_Func_T_Bool_NotDefault1() =>
            Test.NewT.ToOptional().SwitchOptn
            (
                (_) => Test.NewKRight,
                (_ => true, _ => Test.NewKNotDone),
                (_ => false, _ => Test.NewKLeft)
             )
            .Subject.Should().BeEquivalentTo(Test.NewKNotDone);

        [Test]
        public void SwitchMap_Func_T_Bool_NotDefault2() =>
            Test.NewT.ToOptional().SwitchOptn
            (
                (_) => Test.NewKRight,
                (_ => false, _ => Test.NewKNotDone),
                (_ => true, _ => Test.NewKLeft)
             )
            .Subject.Should().BeEquivalentTo(Test.NewKLeft);


        [Test]
        public void SwitchMap_Func_Bool_Default() =>
           Test.NewT.ToOptional().SwitchOptn
           (
               (_) => Test.NewKRight,
               (() => false, _ => Test.NewKNotDone),
               (() => false, _ => Test.NewKLeft)
            )
           .Subject.Should().BeEquivalentTo(Test.NewKRight);

        [Test]
        public void SwitchMap_Func_Bool_NotDefault1() =>
            Test.NewT.ToOptional().SwitchOptn
            (
                (_) => Test.NewKRight,
                (() => true, _ => Test.NewKNotDone),
                (() => false, _ => Test.NewKLeft)
             )
            .Subject.Should().BeEquivalentTo(Test.NewKNotDone);

        [Test]
        public void SwitchMap_Func_Bool_NotDefault2() =>
            Test.NewT.ToOptional().SwitchOptn
            (
                (_) => Test.NewKRight,
                (() => false, _ => Test.NewKNotDone),
                (() => true, _ => Test.NewKLeft)
             )
            .Subject.Should().BeEquivalentTo(Test.NewKLeft);


        [Test]
        public void SwitchMap_Bool_Default() =>
          Test.NewT.ToOptional().SwitchOptn
          (
              (_) => Test.NewKRight,
              (false, _ => Test.NewKNotDone),
              (false, _ => Test.NewKLeft)
           )
          .Subject.Should().BeEquivalentTo(Test.NewKRight);

        [Test]
        public void SwitchMap_Bool_NotDefault1() =>
            Test.NewT.ToOptional().SwitchOptn
            (
                (_) => Test.NewKRight,
                (true, _ => Test.NewKNotDone),
                (false, _ => Test.NewKLeft)
             )
            .Subject.Should().BeEquivalentTo(Test.NewKNotDone);

        [Test]
        public void SwitchMap_Bool_NotDefault2() =>
            Test.NewT.ToOptional().SwitchOptn
            (
                (_) => Test.NewKRight,
                (false, _ => Test.NewKNotDone),
                (true, _ => Test.NewKLeft)
             )
            .Subject.Should().BeEquivalentTo(Test.NewKLeft);
    }
}
