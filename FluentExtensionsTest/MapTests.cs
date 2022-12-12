using FluentAssertions;
using FluentExtensions;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest
{
    [ExcludeFromCodeCoverage]
    public class MapTests
    {

        [Test]
        public void Map_Strings() => 
            Test.TLeft.Map((_) => _.DescType)
            .Should().Be(Test.Left);

        [Test]
        public void Map_Object() => 
            Test.T.Map((_) => new TypeK())
            .Should().BeEquivalentTo(new TypeK());

    }
}
