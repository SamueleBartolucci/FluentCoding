using FluentAssertions;
using FluentCoding;

using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using System.Diagnostics.CodeAnalysis;


namespace FluentCoding.Test.FluentExtensions.Or.Generics
{
    [ExcludeFromCodeCoverage]
    public class OrIsEmpty_Func_T_T_Tests
    {
        [Test]
        public void OrIsEmpty_String_Left1()
            => Test.LEFT.OrIsEmpty(Test.RIGHT, (l, r) => false)
                .Should().Be(Test.LEFT);

        [Test]
        public void OrIsEmpty_String_Left2()
            => Test.LEFT.OrIsEmpty(null, (l, r) => false)
                .Should().Be(Test.LEFT);

        [Test]
        public void OrIsEmpty_StringEmpty_Right()
            => string.Empty.OrIsEmpty(Test.RIGHT, (l, r) => false)
                .Should().Be(Test.RIGHT);

        [Test]
        public void OrIsEmpty_StringSpaces_Right()
            => " ".OrIsEmpty(Test.RIGHT, (l, r) => false)
                .Should().Be(" ");

        [Test]
        public void OrIsEmpty_Null_Right()
            => (null as string)
                .OrIsEmpty(Test.RIGHT, (l, r) => false)
                .Should().Be(Test.RIGHT);

    }
}
