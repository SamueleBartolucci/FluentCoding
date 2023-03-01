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
            Test.NewT.ToTask().EquivalentToAsync(Test.NewT, (a, b) => a.TDesc == b.TDesc)
            .Result
            .Should().BeTrue();

        [Test]
        public void EquivalentToAsync_False() =>
            Test.NewTLeft.ToTask().EquivalentToAsync(Test.NewTRight, (a, b) => a.TDesc == b.TDesc)
            .Result
            .Should().BeFalse();

        [Test]
        public void EquivalentToAnyAsync_Object_True() =>
            Test.NewT.ToTask().EquivalentToAnyAsync((l, r) => l.TDesc == r.TDesc, Test.NewT, Test.NewT)
            .Result
            .Should().BeTrue();      
      
        [Test]
        public void EquivalentToAnyAsync_CustomCompare_True() =>
            "XX".ToTask().EquivalentToAnyAsync((l, r) => l.Equals(r, StringComparison.InvariantCultureIgnoreCase), "TT", "Xx", "VV")
            .Result
            .Should().BeTrue();

        [Test]
        public void EquivalentToAnyAsync_Null_CustomCompare_False() =>
         Test.GetDefault<string>().ToTask().EquivalentToAnyAsync((a, b) => a == b, Test.LEFT, "Xx", Test.RIGHT)
            .Result
            .Should().BeFalse();
    }
}
