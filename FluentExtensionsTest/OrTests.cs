using FluentAssertions;
using FluentExtensions;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using System.Diagnostics.CodeAnalysis;
using UsefulExtensionsTest.TestTypes;

namespace FluentCodingTest
{
    [ExcludeFromCodeCoverage]
    public class OrTests
    {

        [Test]
        public void Or_String_Left1()
            => Test.Left.Or(Test.Right)
                .Should().Be(Test.Left);

        [Test]
        public void Or_String_Left2()
            => Test.Left.Or(null)
                .Should().Be(Test.Left);

        [Test]
        public void Or_StringEmpty_Right()
            => string.Empty.Or(Test.Right)
                .Should().Be(Test.Right);

        [Test]
        public void Or_StringSpaces_Right()
            => " ".Or(Test.Right)
                .Should().Be(Test.Right);

        [Test]
        public void Or_Null_Right()
            => (null as string).Or(Test.Right)
                .Should().Be(Test.Right);

        [Test]
        public void Or_Object_Left()
            => Test.TLeft.Or(Test.TRight)
                .Should().BeEquivalentTo(Test.TLeft);

        [Test]
        public void Or_Object_Right()
            => Test.GetDefault<TypeT>().Or(Test.TRight)
                .Should().BeEquivalentTo(Test.TRight);

        [Test]
        public void Or_Null_RightPriority_Right()
            => Test.GetDefault<TypeT>().Or(Test.TRight, false)
                .Should().BeEquivalentTo(Test.TRight);

        [Test]
        public void Or_Object_RightPriority_Right()
            => Test.TLeft.Or(Test.TRight, false)
                .Should().BeEquivalentTo(Test.TRight);

        [Test]
        public void OrWhen_True_Right()
            => Test.TLeft.Or(Test.TRight, (_) => true)            
                .Should().BeEquivalentTo(Test.TRight);

        [Test]
        public void OrWhen_False_Left()
            => Test.TLeft.Or(Test.TRight, (_) => false)
                .Should().BeEquivalentTo(Test.TLeft);

        [Test]
        public void OrWhen_False_Right()
            =>  Test.GetDefault<TypeT>().Or(Test.TRight, (_) => false)
                .Should().BeEquivalentTo(Test.TRight);

        [Test]
        public void OrWhenDefault_Left()
            => Test.TLeft.Or(Test.TRight)
                .Should().BeEquivalentTo(Test.TLeft);

        [Test]
        public void OrWhenDefault_Right()
           => Test.GetDefault<TypeT>().Or(Test.TRight)
               .Should().BeEquivalentTo(Test.TRight);

    }
}
