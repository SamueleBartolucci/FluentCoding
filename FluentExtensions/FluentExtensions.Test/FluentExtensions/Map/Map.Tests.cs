using FluentAssertions;
using FluentCoding;


using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using System;
using System.Diagnostics.CodeAnalysis;


namespace FluentCoding.Test.FluentExtensions.Map
{
    [ExcludeFromCodeCoverage]
    public class Map_Tests
    {
        [Test]
        public void Map_Null() =>
            Test.GetDefault<TType>().Map((_) => _.TDesc)
            .Should().BeNull();


        [Test]
        public void Map_Strings() =>
            Test.NewTLeft.Map((_) => _.TDesc)
            .Should().Be(Test.LEFT);

        [Test]
        public void Map_Object() =>
            Test.NewT.Map((_) => new KType())
            .Should().BeEquivalentTo(new KType());

        [Test]
        public void Map_Struct() =>
            DateTime.Now.Map((_) => new KType())
            .Should().BeEquivalentTo(new KType());

    }
}
