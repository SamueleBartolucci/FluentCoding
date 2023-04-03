using FluentAssertions;

using System;
using System.Diagnostics.CodeAnalysis;


namespace FluentCoding.Test.FluentExtensions.Equals.Generics
{
    [ExcludeFromCodeCoverage]
    public class Equals_Tests
    {

        [Test]
        public void EqualsTo_True() =>
            Test.NewT.EquivalentTo(Test.NewT, (a, b) => a.TDesc == b.TDesc)
            .Should().BeTrue();

        [Test]
        public void EqualsTo_False() =>
            Test.NewTLeft.EquivalentTo(Test.NewTRight, (a, b) => a.TDesc == b.TDesc)
        .Should().BeFalse();



        [Test]
        public void EqualsToAny_Strings_True() =>
            Test.LEFT.EqualsToAny(Test.RIGHT, Test.LEFT, "VV")
            .Should().BeTrue();

        [Test]
        public void EqualsToAny_Strings_False() =>
            "XX".EqualsToAny(Test.LEFT, "Xx", Test.RIGHT)
            .Should().BeFalse();

        [Test]
        public void EqualsToAny_Object_False() =>
            Test.NewT.EqualsToAny(Test.NewT, Test.NewT)
            .Should().BeFalse();

        [Test]
        public void EqualsToAny_Object_True() =>
            Test.NewT.EquivalentToAny((l, r) => l.TDesc == r.TDesc, Test.NewT, Test.NewT)
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
         Test.GetDefault<string>().EquivalentToAny((a, b) => a == b, Test.LEFT, "Xx", Test.RIGHT)
         .Should().BeFalse();
    }
}
