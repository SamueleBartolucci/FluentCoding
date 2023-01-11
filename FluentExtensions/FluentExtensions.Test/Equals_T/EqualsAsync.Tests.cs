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
            Test.Left.ToTask().EqualsToAnyAsync(Test.Right, Test.Left, "VV")
            .Result
            .Should().BeTrue();

        [Test]
        public void EqualsToAnyAsync_Strings_False() =>
            "XX".ToTask().EqualsToAnyAsync(Test.Left, "Xx", Test.Right)
            .Result
            .Should().BeFalse();

        [Test]
        public void EqualsToAnyAsync_Object_False() =>
            Test.T.ToTask().EqualsToAnyAsync(Test.T, Test.T)
            .Result
            .Should().BeFalse();

        [Test]
        public void EqualsToAnyAsync_Null_False() =>
            Test.GetDefault<object>().ToTask().EqualsToAnyAsync(null, new object())
            .Result
            .Should().BeFalse();
    }
}
