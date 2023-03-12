using FluentAssertions;
using FluentCoding;


using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using System.Diagnostics.CodeAnalysis;


namespace FluentCoding.Test.FluentExtensions.Equals.Generics
{
    [ExcludeFromCodeCoverage]
    public class EquivalentAsync_Tests
    {

        [Test]
        public void EquivalentToAsync_True() =>
            Test.NewTLeft.ToTask().EquivalentToAsync(Test.NewKLeft, (a, b) => a.TDesc == b.KDesc)
            .Result
            .Should().BeTrue();

        [Test]
        public void EquivalentToAsync_False() =>
            Test.NewT.ToTask().EquivalentToAsync(Test.NewTLeft, (a, b) => a.TDesc == b.TDesc)
            .Result
            .Should().BeFalse();

        [Test]
        public void EquivalentToAnyAsync_True() =>
            Test.NewTLeft.ToTask().EquivalentToAnyAsync((o1, o2) => o1.TDesc == o2.KDesc, Test.NewKLeft, Test.NewK)
            .Result
            .Should().BeTrue();

        [Test]
        public void EquivalentToAnyAsync_False() =>
            Test.NewT.ToTask().EquivalentToAnyAsync((o1, o2) => o1.TDesc == o2.KDesc, Test.NewK, Test.NewK)
            .Result
            .Should().BeFalse();

        [Test]
        public void EquvalentToAnyAsync_Null_False() =>
            Test.GetDefault<TType>().ToTask().EquivalentToAnyAsync((l, r) => true, Test.NewK, Test.NewKDone)
            .Result
            .Should().BeFalse();
    }
}
