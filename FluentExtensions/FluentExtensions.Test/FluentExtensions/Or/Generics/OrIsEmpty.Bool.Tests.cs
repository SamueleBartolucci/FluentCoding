using FluentAssertions;
using FluentCoding;

using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;


namespace FluentCoding.Test.FluentExtensions.Or.Generics
{
    [ExcludeFromCodeCoverage]
    public class OrIsEmpty_Bool_Tests
    {

        [Test]
        public void Or_String_Left1()
            => Test.LEFT.OrIsEmpty(Test.RIGHT)
                .Should().Be(Test.LEFT);

        [Test]
        public void Or_String_Left2()
            => Test.LEFT.OrIsEmpty(null)
                .Should().Be(Test.LEFT);

        [Test]
        public void Or_StringEmpty_Right()
            => string.Empty.OrIsEmpty(Test.RIGHT)
                .Should().Be(Test.RIGHT);

        [Test]
        public void Or_StringSpaces_Right()
            => " ".OrIsEmpty(Test.RIGHT)
                .Should().Be(" ");

        [Test]
        public void Or_Null_Right()
            => (null as string).OrIsEmpty(Test.RIGHT)
                .Should().Be(Test.RIGHT);


    }
}
