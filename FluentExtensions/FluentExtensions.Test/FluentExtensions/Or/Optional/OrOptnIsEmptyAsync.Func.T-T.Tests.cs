using FluentAssertions;
using FluentCoding;


using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using System.Diagnostics.CodeAnalysis;


namespace FluentCoding.Test.FluentExtensions.Or.Generics
{
    [ExcludeFromCodeCoverage]
    public class OrOptnIsEmptyAsync_Func_T_T_Tests
    {


        [TestCase(false)]
        [TestCase(true)]
        public void OrOptn_None_Right(bool chooseRight)
           => Optional<string>.None().ToTask().OrOptnIsEmptyAsync(Test.RIGHT, (l, r) => chooseRight)
               .Result.Should().Be(Test.RIGHT);


        [Test]
        public void OrOptnIsEmptyAsync_String_Left1()
            => Test.LEFT.ToOptional().ToTask().OrOptnIsEmptyAsync(Test.RIGHT, (l, r) => false)
                .Result.Should().Be(Test.LEFT);

        [Test]
        public void OrOptnIsEmptyAsync_String_Left2()
            => Test.LEFT.ToOptional().ToTask().OrOptnIsEmptyAsync(null, (l, r) => false)
                .Result.Should().Be(Test.LEFT);

        [Test]
        public void OrOptnIsEmptyAsync_StringEmpty_Right()
            => string.Empty.ToOptional().ToTask().OrOptnIsEmptyAsync(Test.RIGHT, (l, r) => false)
                .Result.Should().Be(Test.RIGHT);

        [Test]
        public void OrOptnIsEmptyAsync_StringSpaces_Right()
            => " ".ToOptional().ToTask().OrOptnIsEmptyAsync(Test.RIGHT, (l, r) => false)
                .Result.Should().Be(" ");

        [Test]
        public void OrOptnIsEmptyAsync_Null_Right()
            => (null as string)
                .ToOptional().ToTask().OrOptnIsEmptyAsync(Test.RIGHT, (l, r) => false)
                .Result.Should().Be(Test.RIGHT);

    }
}
