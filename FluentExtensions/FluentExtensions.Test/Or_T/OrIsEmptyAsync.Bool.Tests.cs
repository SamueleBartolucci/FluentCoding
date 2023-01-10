using FluentAssertions;
using FluentCoding;

using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.Or_T
{
    [ExcludeFromCodeCoverage]
    public class OrIsEmptyAsync_Bool_Tests
    {

        [Test]
        public void Or_String_Left1()
            => Test.Left.ToTask().OrIsEmptyAsync(Test.Right)
                .Result.Should().Be(Test.Left);

        [Test]
        public void Or_String_Left2()
            => Test.Left.ToTask().OrIsEmptyAsync(null)
                .Result.Should().Be(Test.Left);

        [Test]
        public void Or_StringEmpty_Right()
            => string.Empty.ToTask().OrIsEmptyAsync(Test.Right)
                .Result.Should().Be(Test.Right);

        [Test]
        public void Or_StringSpaces_Right()
            => " ".ToTask().OrIsEmptyAsync(Test.Right)
                .Result.Should().Be(" ");

        [Test]
        public void Or_Null_Right()
            => (null as string).ToTask().OrIsEmptyAsync(Test.Right)
                .Result.Should().Be(Test.Right);


    }
}
