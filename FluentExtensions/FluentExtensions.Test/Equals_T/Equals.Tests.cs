using FluentAssertions;
using FluentCoding;

using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Principal;


namespace FluentCodingTest.Equals_T
{
    [ExcludeFromCodeCoverage]
    public class Equals_Tests
    {

        [Test]
        public void EqualsTo_True() =>
            Test.T.EquivalentTo(Test.T, (a, b) => a.DescType == b.DescType)
            .Should().BeTrue();

        [Test]
        public void EqualsTo_False() =>
            Test.TLeft.EquivalentTo(Test.TRight, (a, b) => a.DescType == b.DescType)
        .Should().BeFalse();



        [Test]
        public void EqualsToAny_Strings_True() =>
            Test.Left.EqualsToAny(Test.Right, Test.Left, "VV")
            .Should().BeTrue();

        [Test]
        public void EqualsToAny_Strings_False() =>
            "XX".EqualsToAny(Test.Left, "Xx", Test.Right)
            .Should().BeFalse();

        [Test]
        public void EqualsToAny_Object_False() =>
            Test.T.EqualsToAny(Test.T, Test.T)
            .Should().BeFalse();

        [Test]
        public void EqualsToAny_Object_True() =>
            Test.T.EquivalentToAny((l, r) => l.DescType == r.DescType, Test.T, Test.T)
            .Should().BeTrue();


        
        [Test]
        public void EqualsToAny_Enum_False() =>
            TestEnum.Enum1.EqualsToAny(TestEnum.Enum2, TestEnum.Enum2)
            .Should().BeFalse();

        [Test]
        public void EqualsToAny_Enum_True() =>
            TestEnum.Enum1.EqualsToAny(TestEnum.Enum1, TestEnum.Enum2)
            .Should().BeTrue();

        [Test]
        public void EqualsToAny_CustomCompare_True() =>
            "XX".EquivalentToAny((l, r) => l.Equals(r, StringComparison.InvariantCultureIgnoreCase), "TT", "Xx", "VV")
            .Should().BeTrue();

        [Test]
        public void EqualsToAny_Null_False() =>
            Test.GetDefault<object>().EquivalentToAny(null, new object())
            .Should().BeFalse();

        [Test]
        public void EqualsToAny_Null_CustomCompare_False() =>
         Test.GetDefault<string>().EquivalentToAny((a, b) => a == b, Test.Left, "Xx", Test.Right)
         .Should().BeFalse();
    }
}
