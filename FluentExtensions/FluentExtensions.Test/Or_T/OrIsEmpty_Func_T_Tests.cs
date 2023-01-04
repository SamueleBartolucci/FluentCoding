using FluentAssertions;
using FluentCoding;

using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.Or_T
{
    [ExcludeFromCodeCoverage]
    public class OrIsEmpty_Func_T_Bool_Tests
    {

        [Test]
        public void OrIsEmpty_String_Left1()
            => Test.Left.OrIsEmpty(Test.Right, (s) => false)
                .Should().Be(Test.Left);

        [Test]
        public void OrIsEmpty_String_Left2()
            => Test.Left.OrIsEmpty(null, (s) => false)
                .Should().Be(Test.Left);

        [Test]
        public void OrIsEmpty_StringEmpty_Right()
            => string.Empty.OrIsEmpty(Test.Right, (s) => false)
                .Should().Be(Test.Right);

        [Test]
        public void OrIsEmpty_StringSpaces_Right()
            => " ".OrIsEmpty(Test.Right, (s) => false)
                .Should().Be(" ");

        [Test]
        public void OrIsEmpty_Null_Right()
            => (null as string)
                .OrIsEmpty(Test.Right, (s) => false)
                .Should().Be(Test.Right);

    }
}
