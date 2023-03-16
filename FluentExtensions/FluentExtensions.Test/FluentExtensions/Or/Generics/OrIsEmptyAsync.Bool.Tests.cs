using FluentAssertions;
using FluentCoding;


using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;


namespace FluentCoding.Test.FluentExtensions.Or.Generics
{
    [ExcludeFromCodeCoverage]
    public class OrIsEmptyAsync_Bool_Tests
    {

        [Test]
        public void Or_String_Left1()
            => Test.LEFT.ToTask().OrIsEmptyAsync(Test.RIGHT)
                .Result.Should().Be(Test.LEFT);

        [Test]
        public void Or_String_Left2()
            => Test.LEFT.ToTask().OrIsEmptyAsync(null)
                .Result.Should().Be(Test.LEFT);

        [Test]
        public void Or_StringEmpty_Right()
            => string.Empty.ToTask().OrIsEmptyAsync(Test.RIGHT)
                .Result.Should().Be(Test.RIGHT);

        [Test]
        public void Or_StringSpaces_Right()
            => " ".ToTask().OrIsEmptyAsync(Test.RIGHT)
                .Result.Should().Be(" ");

        [Test]
        public void Or_Null_Right()
            => (null as string).ToTask().OrIsEmptyAsync(Test.RIGHT)
                .Result.Should().Be(Test.RIGHT);


    }
}
