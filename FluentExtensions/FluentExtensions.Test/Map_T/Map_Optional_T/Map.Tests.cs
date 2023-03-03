using FluentAssertions;
using FluentCoding;

using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using System;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.Map_T
{
    [ExcludeFromCodeCoverage]
    public class Map_Optional_Tests
    {
        [Test]
        public void Map_FromNull() =>
            Test.GetDefault<TType>().ToOptional().MapOptn(_ => _.TDesc)
            .IsNone().Should().BeTrue();


        [Test]
        public void Map_ToStrings() =>
            Test.NewTLeft.ToOptional().MapOptn(_ => _.TDesc)
            .Subject.Should().Be(Test.LEFT);

        [Test]
        public void Map_FromStrings()
        {
            var result = "1".ToOptional().MapOptn(_ => int.Parse(_));
            result.IsSome().Should().BeTrue();
            result.Subject.Should().Be(1);
        }

        [Test]
        public void Map_Object() =>
            Test.NewT.ToOptional().MapOptn(_ => new KType())
            .Subject.Should().BeEquivalentTo(new KType());

        [Test]
        public void Map_Struct() =>
            DateTime.Now.ToOptional().MapOptn(_ => new KType())
            .Subject.Should().BeEquivalentTo(new KType());

    }
}
