using FluentAssertions;
using FluentCoding;


using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using System;
using System.Diagnostics.CodeAnalysis;


namespace FluentCoding.Test.FluentExtensions.Map.Optional
{
    [ExcludeFromCodeCoverage]
    public class MapOptn_Tests
    {
        [Test]
        public void MapOptn_FromNull() =>
            Test.GetDefault<TType>().ToOptional().MapOptn(_ => _.TDesc)
            .IsNone().Should().BeTrue();


        [Test]
        public void MapOptn_ToStrings() =>
            Test.NewTLeft.ToOptional().MapOptn(_ => _.TDesc)
            .Subject.Should().Be(Test.LEFT);

        [Test]
        public void MapOptn_FromStrings()
        {
            var result = "1".ToOptional().MapOptn(_ => int.Parse(_));
            result.IsSome().Should().BeTrue();
            result.Subject.Should().Be(1);
        }

        [Test]
        public void MapOptn_Object() =>
            Test.NewT.ToOptional().MapOptn(_ => new KType())
            .Subject.Should().BeEquivalentTo(new KType());

        [Test]
        public void MapOptn_Struct() =>
            DateTime.Now.ToOptional().MapOptn(_ => new KType())
            .Subject.Should().BeEquivalentTo(new KType());

    }
}
