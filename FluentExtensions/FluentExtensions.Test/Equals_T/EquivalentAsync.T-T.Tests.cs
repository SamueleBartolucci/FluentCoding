using FluentAssertions;
using FluentCoding;

using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Principal;


namespace FluentCodingTest.Equals_T
{
    [ExcludeFromCodeCoverage]
    public class EquivalentAsync_T_T_Tests
    {

        [Test]
        public void EquivalentToAsync_True() =>
            Test.T.ToTask().EquivalentToAsync(Test.T, (a, b) => a.DescType == b.DescType)
            .Result
            .Should().BeTrue();

        [Test]
        public void EquivalentToAsync_False() =>
            Test.TLeft.ToTask().EquivalentToAsync(Test.TRight, (a, b) => a.DescType == b.DescType)
            .Result
            .Should().BeFalse();

        [Test]
        public void EquivalentToAnyAsync_Object_True() =>
            Test.T.ToTask().EquivalentToAnyAsync((l, r) => l.DescType == r.DescType, Test.T, Test.T)
            .Result
            .Should().BeTrue();      
      
        [Test]
        public void EquivalentToAnyAsync_CustomCompare_True() =>
            "XX".ToTask().EquivalentToAnyAsync((l, r) => l.Equals(r, StringComparison.InvariantCultureIgnoreCase), "TT", "Xx", "VV")
            .Result
            .Should().BeTrue();

        [Test]
        public void EquivalentToAnyAsync_Null_CustomCompare_False() =>
         Test.GetDefault<string>().ToTask().EquivalentToAnyAsync((a, b) => a == b, Test.Left, "Xx", Test.Right)
            .Result
            .Should().BeFalse();
    }
}
