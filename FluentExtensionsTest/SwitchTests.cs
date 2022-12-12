using FluentAssertions;
using FluentExtensions;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest
{
    [ExcludeFromCodeCoverage]
    public class SwitchTests
    {

        [Test]
        public void Switch_Default() =>
            Test.T.Switch
            (
                (_) => Test.TRight,
                (_ => false, _ => Test.TNotDone),
                (_ => false, _ => Test.TLeft)                
             )
            .Should().BeEquivalentTo(Test.TRight);

        [Test]
        public void Switch_NotDefault1() =>
            Test.T.Switch
            (
                (_) => Test.TRight,
                (_ => true, _ => Test.TNotDone),
                (_ => false, _ => Test.TLeft)
             )
            .Should().BeEquivalentTo(Test.TNotDone);

        [Test]
        public void Switch_NotDefault2() =>
            Test.T.Switch
            (
                (_) => Test.TRight,
                (_ => false, _ => Test.TNotDone),
                (_ => true, _ => Test.TLeft)
             )
            .Should().BeEquivalentTo(Test.TLeft);


        [Test]
        public void SwitchMap_Default() =>
         Test.T.SwitchMap
         (
             (_) => Test.KRight,
             (_ => false, _ => Test.KNotDone),
             (_ => false, _ => Test.KLeft)
          )
         .Should().BeEquivalentTo(Test.TRight);

        [Test]
        public void SwitchMap_NotDefault1() =>
            Test.T.SwitchMap
            (
                (_) => Test.KRight,
                (_ => true, _ => Test.KNotDone),
                (_ => false, _ => Test.KLeft)
             )
            .Should().BeEquivalentTo(Test.KNotDone);

        [Test]
        public void SwitchMap_NotDefault2() =>
            Test.T.SwitchMap
            (
                (_) => Test.KRight,
                (_ => false, _ => Test.KNotDone),
                (_ => true, _ => Test.KLeft)
             )
            .Should().BeEquivalentTo(Test.KLeft);


    }
}
