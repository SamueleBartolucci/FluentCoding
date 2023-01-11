using FluentAssertions;
using FluentCoding;

using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using System;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.Map_T
{
    [ExcludeFromCodeCoverage]
    public class Map_Tests
    {
        [Test]
        public void Map_Null() =>
            Test.GetDefault<TypeT>().Map((_) => _.DescType)
            .Should().BeNull();


        [Test]
        public void Map_Strings() =>
            Test.TLeft.Map((_) => _.DescType)
            .Should().Be(Test.Left);

        [Test]
        public void Map_Object() =>
            Test.T.Map((_) => new TypeK())
            .Should().BeEquivalentTo(new TypeK());

        [Test]
        public void Map_Struct() =>
            DateTime.Now.Map((_) => new TypeK())
            .Should().BeEquivalentTo(new TypeK());

    }
}
