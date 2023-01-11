using FluentAssertions;
using FluentCoding;

using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.Or_T
{
    [ExcludeFromCodeCoverage]
    public class OrIsEmptyAsync_Func_Tests
    {

        [Test]
        public void OrIsEmptyAsync_String_Left1()
            => Test.Left.ToTask().OrIsEmptyAsync(Test.Right, () => false)
                .Result.Should().Be(Test.Left);

        [Test]
        public void OrIsEmptyAsync_String_Left2()
            => Test.Left.ToTask().OrIsEmptyAsync(null, () => false)
                .Result.Should().Be(Test.Left);

        [Test]
        public void OrIsEmptyAsync_StringEmpty_Right()
            => string.Empty.ToTask().OrIsEmptyAsync(Test.Right, () => false)
                .Result.Should().Be(Test.Right);

        [Test]
        public void OrIsEmptyAsync_StringSpaces_Right()
            => " ".ToTask().OrIsEmptyAsync(Test.Right, () => false)
                .Result.Should().Be(" ");

        [Test]
        public void OrIsEmptyAsync_Null_Right()
            => (null as string)
                .ToTask().OrIsEmptyAsync(Test.Right, () => false)
                .Result.Should().Be(Test.Right);

    }
}
