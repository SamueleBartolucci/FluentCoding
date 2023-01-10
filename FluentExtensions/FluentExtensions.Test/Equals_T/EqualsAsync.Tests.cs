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
        public void EqualsToAsync_True() =>
            Test.T.ToTask().EqualsToAsync(Test.T, (a, b) => a.DescType == b.DescType)
            .Result
            .Should().BeTrue();

        [Test]
        public void EqualsToAsync_False() =>
            Test.TLeft.ToTask().EqualsToAsync(Test.TRight, (a, b) => a.DescType == b.DescType)
            .Result
            .Should().BeFalse();



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
        public void EqualsToAnyAsync_Object_True() =>
            Test.T.ToTask().EqualsToAnyAsync((l, r) => l.DescType == r.DescType, Test.T, Test.T)
            .Result
            .Should().BeTrue();



        [Test]
        public void EqualsToAnyAsync_Enum_False() =>
            TestEnum.Enum1.ToTask().EqualsToAnyAsync(TestEnum.Enum2, TestEnum.Enum2)
            .Result
            .Should().BeFalse();

        [Test]
        public void EqualsToAnyAsync_Enum_True() =>
            TestEnum.Enum1.ToTask().EqualsToAnyAsync(TestEnum.Enum1, TestEnum.Enum2)
            .Result
            .Should().BeTrue();

        [Test]
        public void EqualsToAnyAsync_CustomCompare_True() =>
            "XX".ToTask().EqualsToAnyAsync((l, r) => l.Equals(r, StringComparison.InvariantCultureIgnoreCase), "TT", "Xx", "VV")
            .Result
            .Should().BeTrue();

        [Test]
        public void EqualsToAnyAsync_Null_False() =>
            Test.GetDefault<object>().ToTask().EqualsToAnyAsync(null, new object())
            .Result
            .Should().BeFalse();

        [Test]
        public void EqualsToAnyAsync_Null_CustomCompare_False() =>
         Test.GetDefault<string>().ToTask().EqualsToAnyAsync((a, b) => a == b, Test.Left, "Xx", Test.Right)
            .Result
            .Should().BeFalse();
    }
}
