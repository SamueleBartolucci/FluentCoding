using FluentAssertions;
using FluentCoding;

using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Principal;


namespace FluentCodingTest.Equals_T
{
    [ExcludeFromCodeCoverage]
    public class EqualsAsync_Tests
    {


        [Test]
        public void EqualsToAnyAsync_Strings_True() =>
            Test.LEFT.ToTask().EqualsToAnyAsync(Test.RIGHT, Test.LEFT, "VV")
            .Result
            .Should().BeTrue();

        [Test]
        public void EqualsToAnyAsync_Strings_False() =>
            "XX".ToTask().EqualsToAnyAsync(Test.LEFT, "Xx", Test.RIGHT)
            .Result
            .Should().BeFalse();

        [Test]
        public void EqualsToAnyAsync_Object_False() =>
            Test.NewT.ToTask().EqualsToAnyAsync(Test.NewT, Test.NewT)
            .Result
            .Should().BeFalse();

        [Test]
        public void EqualsToAnyAsync_Null_False() =>
            Test.GetDefault<object>().ToTask().EqualsToAnyAsync(null, new object())
            .Result
            .Should().BeFalse();
    }
}
