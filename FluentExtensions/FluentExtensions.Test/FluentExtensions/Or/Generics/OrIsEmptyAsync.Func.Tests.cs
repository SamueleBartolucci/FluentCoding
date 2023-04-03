using FluentAssertions;
using System.Diagnostics.CodeAnalysis;


namespace FluentCoding.Test.FluentExtensions.Or.Generics
{
    [ExcludeFromCodeCoverage]
    public class OrIsEmptyAsync_Func_Tests
    {

        [Test]
        public void OrIsEmptyAsync_String_Left1()
            => Test.LEFT.ToTask().OrIsEmptyAsync(Test.RIGHT, () => false)
                .Result.Should().Be(Test.LEFT);

        [Test]
        public void OrIsEmptyAsync_String_Left2()
            => Test.LEFT.ToTask().OrIsEmptyAsync(null, () => false)
                .Result.Should().Be(Test.LEFT);

        [Test]
        public void OrIsEmptyAsync_StringEmpty_Right()
            => string.Empty.ToTask().OrIsEmptyAsync(Test.RIGHT, () => false)
                .Result.Should().Be(Test.RIGHT);

        [Test]
        public void OrIsEmptyAsync_StringSpaces_Right()
            => " ".ToTask().OrIsEmptyAsync(Test.RIGHT, () => false)
                .Result.Should().Be(" ");

        [Test]
        public void OrIsEmptyAsync_Null_Right()
            => (null as string)
                .ToTask().OrIsEmptyAsync(Test.RIGHT, () => false)
                .Result.Should().Be(Test.RIGHT);

    }
}
