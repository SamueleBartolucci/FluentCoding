using FluentAssertions;
using FluentCoding;

using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.Equals_T
{
    [ExcludeFromCodeCoverage]
    public class Equivalent_Tests
    {

        [Test]
        public void EquivalentTo_True() =>
            Test.NewTLeft.EquivalentTo(Test.NewKLeft, (a, b) => a.TDesc == b.KDesc)
            .Should().BeTrue();

        [Test]
        public void EquivalentTo_False() =>
            Test.NewT.EquivalentTo(Test.NewTLeft, (a, b) => a.TDesc == b.TDesc)
            .Should().BeFalse();

        [Test]
        public void EquivalentToAny_True() =>
            Test.NewTLeft.EquivalentToAny((o1, o2) => o1.TDesc == o2.KDesc, Test.NewKLeft, Test.NewK).
            Should().BeTrue();

        [Test]
        public void EquivalentToAny_False() =>
            Test.NewT.EquivalentToAny((o1, o2) => o1.TDesc == o2.KDesc, Test.NewK, Test.NewK)
            .Should().BeFalse();     

        [Test]
        public void EquvalentToAny_Null_False() =>
            Test.GetDefault<TType>().EquivalentToAny((l, r) => true, Test.NewK, Test.NewKDone)
            .Should().BeFalse();
    }
}
