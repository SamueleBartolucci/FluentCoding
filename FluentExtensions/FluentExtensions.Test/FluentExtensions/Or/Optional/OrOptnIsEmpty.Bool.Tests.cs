using FluentAssertions;
using System.Diagnostics.CodeAnalysis;


namespace FluentCoding.Test.FluentExtensions.Or.Generics
{
    [ExcludeFromCodeCoverage]
    public class OrOptnIsEmpty_Bool_Tests
    {


        [TestCase(false)]
        [TestCase(true)]
        public void OrOptn_None_Right(bool chooseRight)
           => Optional<string>.None().OrOptnIsEmpty(Test.RIGHT, chooseRight)
               .Should().Be(Test.RIGHT);

        [Test]
        public void OrOptnIsEmpty_String_Left1()
            => Test.LEFT.ToOptional().OrOptnIsEmpty(Test.RIGHT, false)
                .Should().Be(Test.LEFT);

        [Test]
        public void OrOptnIsEmpty_String_Left2()
            => Test.LEFT.ToOptional().OrOptnIsEmpty(null, false)
                .Should().Be(Test.LEFT);

        [Test]
        public void OrOptnIsEmpty_StringEmpty_Right()
            => string.Empty.ToOptional().OrOptnIsEmpty(Test.RIGHT, false)
                .Should().Be(Test.RIGHT);

        [Test]
        public void OrOptnIsEmpty_StringSpaces_Right()
            => " ".ToOptional().OrOptnIsEmpty(Test.RIGHT, false)
                .Should().Be(" ");

        [Test]
        public void OrOptnIsEmpty_Null_Right()
            => (null as string)
                .ToOptional().OrOptnIsEmpty(Test.RIGHT, false)
                .Should().Be(Test.RIGHT);

    }
}
