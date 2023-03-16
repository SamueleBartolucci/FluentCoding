using FluentAssertions;
using FluentCoding;


using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using System.Diagnostics.CodeAnalysis;


namespace FluentCoding.Test.FluentExtensions.Or.Generics
{
    [ExcludeFromCodeCoverage]
    public class OrOptn_T_Func_TBool_Tests
    {

        [Test]
        public void OrOptn_String_Left1()
            => Test.LEFT.ToOptional().OrOptn(Test.RIGHT, (s) => false)
                .Should().Be(Test.LEFT);

        [Test]
        public void OrOptn_String_Left2()
            => Test.LEFT.ToOptional().OrOptn(Test.GetDefault<string>(), (s) => false)
                .Should().Be(Test.LEFT);

        [Test]
        public void OrOptn_StringEmpty_Right()
            => string.Empty.ToOptional().OrOptn(Test.RIGHT, (s) => false)
                .Should().Be(string.Empty);

        [Test]
        public void OrOptn_StringSpaces_Right()
            => " ".ToOptional().OrOptn(Test.RIGHT, (s) => false)
                .Should().Be(" ");

        [Test]
        public void OrOptn_Null_Right()
            => (null as string)
                .ToOptional().OrOptn(Test.RIGHT, (s) => false)
                .Should().Be(Test.RIGHT);

        [Test]
        public void OrOptn_Object_Left()
            => Test.NewTLeft
                .ToOptional().OrOptn(Test.NewTRight, (s) => false)
                .Should().BeEquivalentTo(Test.NewTLeft);

        [Test]
        public void OrOptn_Object_Right()
            => Test.GetDefault<TType>()
                .ToOptional().OrOptn(Test.NewTRight, (s) => false)
                .Should().BeEquivalentTo(Test.NewTRight);

        [Test]
        public void OrOptn_Null_RightPriority_Right()
            => Test.GetDefault<TType>().ToOptional().OrOptn(Test.NewTRight, (s) => true)
                .Should().BeEquivalentTo(Test.NewTRight);

        [Test]
        public void OrOptn_Null_LeftPriority_Right()
          => Test.GetDefault<TType>().ToOptional().OrOptn(Test.NewTRight, (s) => false)
              .Should().BeEquivalentTo(Test.NewTRight);

        [Test]
        public void OrOptn_Object_RightPriority_Right()
            => Test.NewTLeft.ToOptional().OrOptn(Test.NewTRight, (s) => true)
                .Should().BeEquivalentTo(Test.NewTRight);
    }
}
