using FluentAssertions;
using FluentCoding;

using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.OrAsync_T
{
    [ExcludeFromCodeCoverage]
    public class OrAsync_Bool_Tests
    {

        [Test]
        public void OrAsync_NullValueType()
        {
            decimal? input = null;
            input.ToTask().OrAsync(10).Result.Should().Be(10);
        }

        [Test]
        public void OrAsync_String_Left1()
            => Test.Left.ToTask().OrAsync(Test.Right)
                .Result.Should().Be(Test.Left);

        [Test]
        public void OrAsync_String_Left2()
            => Test.Left.ToTask().OrAsync(Test.GetDefault<string>())
                .Result.Should().Be(Test.Left);

        [Test]
        public void OrAsync_StringEmpty_Right()
            => string.Empty.ToTask().OrAsync(Test.Right)
                .Result.Should().Be(string.Empty);

        [Test]
        public void OrAsync_StringSpaces_Right()
            => " ".ToTask().OrAsync(Test.Right)
                .Result.Should().Be(" ");

        [Test]
        public void OrAsync_Null_Right()
            => (null as string).ToTask().OrAsync(Test.Right)
                .Result.Should().Be(Test.Right);

        [Test]
        public void OrAsync_Object_Left()
            => Test.TLeft.ToTask().OrAsync(Test.TRight)
                .Result.Should().BeEquivalentTo(Test.TLeft);

        [Test]
        public void OrAsync_Object_Right()
            => Test.GetDefault<TypeT>().ToTask().OrAsync(Test.TRight)
                .Result.Should().BeEquivalentTo(Test.TRight);

        [Test]
        public void OrAsync_Null_RightPriority_Right()
            => Test.GetDefault<TypeT>().ToTask().OrAsync(Test.TRight, true)
                .Result.Should().BeEquivalentTo(Test.TRight);

        [Test]
        public void OrAsync_Object_RightPriority_Right()
            => Test.TLeft.ToTask().OrAsync(Test.TRight, true)
               .Result.Should().BeEquivalentTo(Test.TRight);

    }
}
