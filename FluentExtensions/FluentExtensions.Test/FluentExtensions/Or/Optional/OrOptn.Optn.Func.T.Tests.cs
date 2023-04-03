using FluentAssertions;
using System.Diagnostics.CodeAnalysis;


namespace FluentCoding.Test.FluentExtensions.Or.Generics
{
    [ExcludeFromCodeCoverage]
    public class OrOptn_T_Optn_Func_TBool_Tests
    {
        [Test]
        public void OrOptn_None_None()
         => Optional<string>.None().OrOptn(Optional<string>.None(), (s) => true)
            .IsNone().Should().BeTrue();


        [Test]
        public void OrOptn_None_Some()
         => Optional<string>.None().OrOptn("some".ToOptional(), (s) => true)
            .IsSome().Should().BeTrue();


        [Test]
        public void OrOptn_String_Left1()
            => Test.LEFT.ToOptional().OrOptn(Test.RIGHT.ToOptional(), (s) => false)
                .Do(result => result.IsSome().Should().BeTrue()).Subject.Should().Be(Test.LEFT);

        [Test]
        public void OrOptn_String_Left2()
            => Test.LEFT.ToOptional().OrOptn(Test.GetDefault<string>().ToOptional(), (s) => false)
                .Do(result => result.IsSome().Should().BeTrue()).Subject.Should().Be(Test.LEFT);

        [Test]
        public void OrOptn_StringEmpty_Right()
            => string.Empty.ToOptional().OrOptn(Test.RIGHT.ToOptional(), (s) => false)
                .Do(result => result.IsSome().Should().BeTrue()).Subject.Should().Be(string.Empty);

        [Test]
        public void OrOptn_StringSpaces_Right()
            => " ".ToOptional().OrOptn(Test.RIGHT.ToOptional(), (s) => false)
                .Do(result => result.IsSome().Should().BeTrue()).Subject.Should().Be(" ");

        [Test]
        public void OrOptn_Null_Right()
            => (null as string)
                .ToOptional().OrOptn(Test.RIGHT.ToOptional(), (s) => false)
                .Do(result => result.IsSome().Should().BeTrue()).Subject.Should().Be(Test.RIGHT);

        [Test]
        public void OrOptn_Object_Left()
            => Test.NewTLeft
                .ToOptional().OrOptn(Test.NewTRight.ToOptional(), (s) => false)
                .Do(result => result.IsSome().Should().BeTrue()).Subject.Should().BeEquivalentTo(Test.NewTLeft);

        [Test]
        public void OrOptn_Object_Right()
            => Test.GetDefault<TType>()
                .ToOptional().OrOptn(Test.NewTRight.ToOptional(), (s) => false)
                .Do(result => result.IsSome().Should().BeTrue()).Subject.Should().BeEquivalentTo(Test.NewTRight);

        [Test]
        public void OrOptn_Null_RightPriority_Right()
            => Test.GetDefault<TType>().ToOptional().OrOptn(Test.NewTRight.ToOptional(), (s) => true)
                .Do(result => result.IsSome().Should().BeTrue()).Subject.Should().BeEquivalentTo(Test.NewTRight);

        [Test]
        public void OrOptn_Null_LeftPriority_Right()
          => Test.GetDefault<TType>().ToOptional().OrOptn(Test.NewTRight.ToOptional(), (s) => false)
              .Do(result => result.IsSome().Should().BeTrue()).Subject.Should().BeEquivalentTo(Test.NewTRight);

        [Test]
        public void OrOptn_Object_RightPriority_Right()
            => Test.NewTLeft.ToOptional().OrOptn(Test.NewTRight.ToOptional(), (s) => true)
                .Do(result => result.IsSome().Should().BeTrue()).Subject.Should().BeEquivalentTo(Test.NewTRight);
    }
}
