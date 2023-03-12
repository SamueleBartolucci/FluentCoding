using FluentAssertions;
using FluentCoding;

using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.Or_T
{
    [ExcludeFromCodeCoverage]
    public class Or_Bool_Tests
    {

        [Test]
        public void Or_NullValueType()
        {
            decimal? input = null;
            input.Or(10).Should().Be(10);
        }

        [Test]
        public void Or_String_Left1()
            => Test.LEFT.Or(Test.RIGHT)
                .Should().Be(Test.LEFT);

        [Test]
        public void Or_String_Left2()
            => Test.LEFT.Or(Test.GetDefault<string>())
                .Should().Be(Test.LEFT);

        [Test]
        public void Or_StringEmpty_Right()
            => string.Empty.Or(Test.RIGHT)
                .Should().Be(string.Empty);

        [Test]
        public void Or_StringSpaces_Right()
            => " ".Or(Test.RIGHT)
                .Should().Be(" ");

        [Test]
        public void Or_Null_Right()
            => (null as string).Or(Test.RIGHT)
                .Should().Be(Test.RIGHT);

        [Test]
        public void Or_Object_Left()
            => Test.NewTLeft.Or(Test.NewTRight)
                .Should().BeEquivalentTo(Test.NewTLeft);

        [Test]
        public void Or_Object_Right()
            => Test.GetDefault<TType>().Or(Test.NewTRight)
                .Should().BeEquivalentTo(Test.NewTRight);

        [Test]
        public void Or_Null_RightPriority_Right()
            => Test.GetDefault<TType>().Or(Test.NewTRight, true)
                .Should().BeEquivalentTo(Test.NewTRight);

        [Test]
        public void Or_Object_RightPriority_Right()
            => Test.NewTLeft.Or(Test.NewTRight, true)
               .Should().BeEquivalentTo(Test.NewTRight);

    }
}
