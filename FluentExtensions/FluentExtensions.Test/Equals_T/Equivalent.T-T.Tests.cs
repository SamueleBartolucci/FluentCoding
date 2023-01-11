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
            Test.T.EquivalentTo(Test.T, (a, b) => a.DescType == b.DescType)
            .Should().BeTrue();

        [Test]
        public void EquivalentTo_False() =>
            Test.TLeft.EquivalentTo(Test.TRight, (a, b) => a.DescType == b.DescType)
            .Should().BeFalse();

        [Test]
        public void EquivalentToAny_Object_True() =>
            Test.T.EquivalentToAny((l, r) => l.DescType == r.DescType, Test.T, Test.T)
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
         Test.GetDefault<string>().EquivalentToAny((a, b) => a == b, Test.Left, "Xx", Test.Right)
         .Should().BeFalse();
    }
}
