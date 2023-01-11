using FluentAssertions;
using FluentCoding;

using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using System;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.MapAsync_T
{
    [ExcludeFromCodeCoverage]
    public class MapAsync_Tests
    {
        [Test]
        public void MapAsync_Null() =>
            Test.GetDefault<TypeT>()
            .ToTask()
            .MapAsync((_) => _.DescType)
            .Result
            .Should().BeNull();


        [Test]
        public void MapAsync_Strings() =>
            Test.TLeft
            .ToTask()
            .MapAsync((_) => _.DescType)
            .Result
            .Should().Be(Test.Left);

        [Test]
        public void MapAsync_Object() =>
            Test.T
            .ToTask()
            .MapAsync((_) => new TypeK())
            .Result
            .Should().BeEquivalentTo(new TypeK());

        [Test]
        public void MapAsync_Struct() =>
            DateTime.Now
            .ToTask()
            .MapAsync((_) => new TypeK())
            .Result
            .Should().BeEquivalentTo(new TypeK());

    }
}
