using FluentAssertions;
using FluentCoding;

using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.Equals_T
{
    [ExcludeFromCodeCoverage]
    public class Equivalent_T_Tests
    {

        [Test]
        public void EquivalentTo_True() =>
            Test.TLeft.EquivalentTo(Test.KLeft, (a, b) => a.DescType == b.DescType)
            .Should().BeTrue();

        [Test]
        public void EquivalentTo_False() =>
            Test.T.EquivalentTo(Test.TLeft, (a, b) => a.DescType == b.DescType)
            .Should().BeFalse();

        [Test]
        public void EquivalentToAny_True() =>
            Test.TLeft.EquivalentToAny((o1, o2) => o1.DescType == o2.DescType, Test.KLeft, Test.K).
            Should().BeTrue();

        [Test]
        public void EquivalentToAny_False() =>
            Test.T.EquivalentToAny((o1, o2) => o1.DescType == o2.DescType, Test.K, Test.K)
            .Should().BeFalse();     

        [Test]
        public void EquvalentToAny_Null_False() =>
            Test.GetDefault<TypeT>().EquivalentToAny((l, r) => true, Test.K, Test.KDone)
            .Should().BeFalse();
    }
}
