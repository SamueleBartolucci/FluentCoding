using FluentAssertions;
using FluentExtensions;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using System.Diagnostics.CodeAnalysis;
using UsefulExtensionsTest.TestTypes;

namespace FluentCodingTest
{
    [ExcludeFromCodeCoverage]
    public class EqualsTests
    {
        
        [Test]
        public void EqualsTo_True() => 
            Test.T.EqualsTo(Test.T, (a, b) => a.DescType == b.DescType)
            .Should().BeTrue();

        [Test]
        public void EqualsTo_False() => 
            Test.TLeft.EqualsTo(Test.TRight, (a, b) => a.DescType == b.DescType)
            .Should().BeFalse();

        [Test]
        public void EquivalentTo_True() => 
            Test.TLeft.EquivalentTo(Test.KLeft, (a, b) => a.DescType == b.DescType)
            .Should().BeTrue();

        [Test]
        public void EquivalentTo_False() => 
            Test.T.EquivalentTo(Test.TLeft, (a, b) => a.DescType == b.DescType)
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
            Test.T.EqualsToAny((l, r) => l.DescType == r.DescType, Test.T, Test.T)
            .Should().BeTrue();

        [Test]
        public void SameToAny_True() => 
            Test.TLeft.EquivalentToAny((o1, o2) => o1.DescType == o2.DescType, Test.KLeft, Test.K).
            Should().BeTrue();

        [Test]
        public void SameToAny_False() => 
            Test.T.EquivalentToAny((o1, o2) => o1.DescType == o2.DescType, Test.K, Test.K)
            .Should().BeFalse();

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
            "XX".EqualsToAny((l, r) => l.Equals(r, StringComparison.InvariantCultureIgnoreCase),  "TT", "Xx", "VV")
            .Should().BeTrue();

        [Test]
        public void EqualsToAny_Null_False() => 
            Test.GetDefault<object>().EqualsToAny(null, new object())
            .Should().BeFalse();

        [Test]
        public void EqualsToAny_Null_CustomCompare_False() =>
         Test.GetDefault<string>().EqualsToAny((a, b) => a == b, Test.Left, "Xx", Test.Right)
         .Should().BeFalse();

        [Test]
        public void EquvalentToAny_Null_False() =>
            Test.GetDefault<TypeT>().EquivalentToAny((l, r) => true, Test.K, Test.KDone)
            .Should().BeFalse();
    }
}
