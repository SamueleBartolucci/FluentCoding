using FluentAssertions;
using FluentCoding;

using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.Or_T
{
    [ExcludeFromCodeCoverage]
    public class Or_Func_T_T_Tests
    { 
        [Test]
        public void Or_String_Left1()
            => Test.Left.Or(Test.Right, (l, r) => false)
                .Should().Be(Test.Left);

        [Test]
        public void Or_String_Left2()
            => Test.Left.Or(null, (l, r) => false)
                .Should().Be(Test.Left);

        [Test]
        public void Or_StringEmpty_Right()
            => string.Empty.Or(Test.Right, (l, r) => false)
                .Should().Be(string.Empty);

        [Test]
        public void Or_StringSpaces_Right()
            => " ".Or(Test.Right, (l, r) => false)
                .Should().Be(" ");

        [Test]
        public void Or_Null_Right()
            => (null as string)
                .Or(Test.Right, (l, r) => false)
                .Should().Be(Test.Right);

        [Test]
        public void Or_Object_Left()
            => Test.TLeft
                .Or(Test.TRight, (l, r) => false)
                .Should().BeEquivalentTo(Test.TLeft);

        [Test]
        public void Or_Object_Right()
            => Test.GetDefault<TypeT>()
                .Or(Test.TRight, (l, r) => false)
                .Should().BeEquivalentTo(Test.TRight);

        [Test]
        public void Or_Null_RightPriority_Right()
            => Test.GetDefault<TypeT>().Or(Test.TRight, (l, r) => true)
                .Should().BeEquivalentTo(Test.TRight);

        [Test]
        public void Or_Null_LeftPriority_Right()
          => Test.GetDefault<TypeT>().Or(Test.TRight, (l, r) => false)
              .Should().BeEquivalentTo(Test.TRight);

        [Test]
        public void Or_Object_RightPriority_Right()
            => Test.TLeft.Or(Test.TRight, (l, r) => true)
                .Should().BeEquivalentTo(Test.TRight);
    }
}
