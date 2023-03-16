using FluentAssertions;
using FluentCoding;


using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;


namespace FluentCoding.Test.FluentExtensions.Or.Generics
{
    [ExcludeFromCodeCoverage]
    public class OrOptn_Bool_Tests
    {

        [Test]
        public void OrOptn_NullValueType()
        {
            decimal? input = null;
            input.ToOptional().OrOptn(10).Should().Be(10);
        }

        [Test]
        public void OrOptn_String_Left1()
            => Test.LEFT.ToOptional().OrOptn(Test.RIGHT)
                .Should().Be(Test.LEFT);

        [Test]
        public void OrOptn_String_Left2()
            => Test.LEFT.ToOptional().OrOptn(Test.GetDefault<string>())
                .Should().Be(Test.LEFT);

        [Test]
        public void OrOptn_StringEmpty_Right()
            => string.Empty.ToOptional().OrOptn(Test.RIGHT)
                .Should().Be(string.Empty);

        [Test]
        public void OrOptn_StringSpaces_Right()
            => " ".ToOptional().OrOptn(Test.RIGHT)
                .Should().Be(" ");

        [Test]
        public void OrOptn_Null_Right()
            => (null as string).ToOptional().OrOptn(Test.RIGHT)
                .Should().Be(Test.RIGHT);

        [Test]
        public void OrOptn_Object_Left()
            => Test.NewTLeft.ToOptional().OrOptn(Test.NewTRight)
                .Should().BeEquivalentTo(Test.NewTLeft);

        [Test]
        public void OrOptn_Object_Right()
            => Test.GetDefault<TType>().ToOptional().OrOptn(Test.NewTRight)
                .Should().BeEquivalentTo(Test.NewTRight);

        [Test]
        public void OrOptn_Null_RightPriority_Right()
            => Test.GetDefault<TType>().ToOptional().OrOptn(Test.NewTRight, true)
                .Should().BeEquivalentTo(Test.NewTRight);

        [Test]
        public void OrOptn_Object_RightPriority_Right()
            => Test.NewTLeft.ToOptional().OrOptn(Test.NewTRight, true)
               .Should().BeEquivalentTo(Test.NewTRight);

    }
}
