using FluentAssertions;
using FluentCoding;

using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.Equals_T
{
    [ExcludeFromCodeCoverage]
    public class EquivalentAsync_Tests
    {

        [Test]
        public void EquivalentToAsync_True() =>
            Test.TLeft.ToTask().EquivalentToAsync(Test.KLeft, (a, b) => a.DescType == b.DescType)
            .Result
            .Should().BeTrue();

        [Test]
        public void EquivalentToAsync_False() =>
            Test.T.ToTask().EquivalentToAsync(Test.TLeft, (a, b) => a.DescType == b.DescType)
            .Result
            .Should().BeFalse();

        [Test]
        public void EquivalentToAnyAsync_True() =>
            Test.TLeft.ToTask().EquivalentToAnyAsync((o1, o2) => o1.DescType == o2.DescType, Test.KLeft, Test.K)
            .Result
            .Should().BeTrue();

        [Test]
        public void EquivalentToAnyAsync_False() =>
            Test.T.ToTask().EquivalentToAnyAsync((o1, o2) => o1.DescType == o2.DescType, Test.K, Test.K)
            .Result
            .Should().BeFalse();     

        [Test]
        public void EquvalentToAnyAsync_Null_False() =>
            Test.GetDefault<TypeT>().ToTask().EquivalentToAnyAsync((l, r) => true, Test.K, Test.KDone)
            .Result
            .Should().BeFalse();
    }
}
