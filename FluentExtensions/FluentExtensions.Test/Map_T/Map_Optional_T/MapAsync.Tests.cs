using FluentAssertions;
using FluentCoding;

using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using System;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.MapAsync_T
{
    [ExcludeFromCodeCoverage]
    public class MapAsync_Optional_Tests
    {
        [Test]
        public void MapAsync_Null() =>
            Test.GetDefault<TType>()
            .ToOptional()
            .ToTask()
            .MapOptionalAsync((_) => _.TDesc)
            .Result
            .IsNone()
            .Should().BeTrue();


        [Test]
        public void MapAsync_Strings() =>
            Test.NewTLeft
            .ToOptional()
            .ToTask()
            .MapOptionalAsync(_ => _.TDesc)
            .Result
            .Subject
            .Should().Be(Test.LEFT);

        [Test]
        public void MapAsync_Object() =>
            Test.NewT
            .ToOptional()
            .ToTask()
            .MapOptionalAsync<TType, KType>(_ => new KType())
            .Result
            .Subject
            .Should().BeEquivalentTo(new KType());

        [Test]
        public void MapAsync_Struct() =>
            DateTime.Now
            .ToOptional()
            .ToTask()
            .MapAsync((_) => new KType())
            .Result
            .Subject
            .Should().BeEquivalentTo(new KType());

    }
}
