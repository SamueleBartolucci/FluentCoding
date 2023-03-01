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
            Test.GetDefault<TType>()
            .ToTask()
            .MapAsync((_) => _.TDesc)
            .Result
            .Should().BeNull();


        [Test]
        public void MapAsync_Strings() =>
            Test.NewTLeft
            .ToTask()
            .MapAsync((_) => _.TDesc)
            .Result
            .Should().Be(Test.LEFT);

        [Test]
        public void MapAsync_Object() =>
            Test.NewT
            .ToTask()
            .MapAsync((_) => new KType())
            .Result
            .Should().BeEquivalentTo(new KType());

        [Test]
        public void MapAsync_Struct() =>
            DateTime.Now
            .ToTask()
            .MapAsync((_) => new KType())
            .Result
            .Should().BeEquivalentTo(new KType());

    }
}
