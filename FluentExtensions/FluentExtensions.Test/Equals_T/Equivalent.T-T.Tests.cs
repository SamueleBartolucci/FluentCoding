using FluentAssertions;
using FluentCoding;

using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using System;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.Equals_T
{
    [ExcludeFromCodeCoverage]
    public class Equivalent_T_T_Tests
    {

        [Test]
        public void EquivalentTo_True() =>
            Test.NewT.EquivalentTo(Test.NewT, (a, b) => a.TDesc == b.TDesc)
            .Should().BeTrue();

        [Test]
        public void EquivalentTo_False() =>
            Test.NewTLeft.EquivalentTo(Test.NewTRight, (a, b) => a.TDesc == b.TDesc)
            .Should().BeFalse();

        [Test]
        public void EquivalentToAny_Object_True() =>
            Test.NewT.EquivalentToAny((l, r) => l.TDesc == r.TDesc, Test.NewT, Test.NewT)
            .Should().BeTrue();

        [Test]
        public void EquivalentToAny_CustomCompare_True() =>
            "XX".EquivalentToAny((l, r) => l.Equals(r, StringComparison.InvariantCultureIgnoreCase), "TT", "Xx", "VV")
            .Should().BeTrue();

        [Test]
        public void EquivalentToAny_Null_False() =>
            Test.GetDefault<object>().EquivalentToAny(null, new object())
            .Should().BeFalse();

        [Test]
        public void EquivalentToAny_Null_CustomCompare_False() =>
         Test.GetDefault<string>().EquivalentToAny((a, b) => a == b, Test.LEFT, "Xx", Test.RIGHT)
         .Should().BeFalse();
    }
}
