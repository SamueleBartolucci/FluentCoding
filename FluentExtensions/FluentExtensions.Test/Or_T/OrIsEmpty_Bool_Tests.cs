using FluentAssertions;
using FluentCoding;

using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.Or_T
{
    [ExcludeFromCodeCoverage]
    public class OrIsEmpty_Bool_Tests
    {

        [Test]
        public void Or_String_Left1()
            => Test.Left.OrIsEmpty(Test.Right)
                .Should().Be(Test.Left);

        [Test]
        public void Or_String_Left2()
            => Test.Left.OrIsEmpty(null)
                .Should().Be(Test.Left);

        [Test]
        public void Or_StringEmpty_Right()
            => string.Empty.OrIsEmpty(Test.Right)
                .Should().Be(Test.Right);

        [Test]
        public void Or_StringSpaces_Right()
            => " ".OrIsEmpty(Test.Right)
                .Should().Be(" ");

        [Test]
        public void Or_Null_Right()
            => (null as string).OrIsEmpty(Test.Right)
                .Should().Be(Test.Right);


    }
}
