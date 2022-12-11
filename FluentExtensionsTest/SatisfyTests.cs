using FluentAssertions;
using FluentExtensions;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using System.Diagnostics.CodeAnalysis;
using UsefulExtensionsTest.TestTypes;

namespace FluentCodingTest
{
    [ExcludeFromCodeCoverage]
    public class SatisfyTests
    {

        [Test]
        public void Satisfy_True()
        {
            var sbj = Test.TLeft;
            var result = sbj.Is(() => true);
            result.IsSatisfied.Should().BeTrue();
            result.Subject.Should().BeSameAs(sbj);
        }

        [Test]
        public void Satisfy_False()
        {
            var sbj = Test.TLeft;
            var result = sbj.Is(() => false);
            result.IsSatisfied.Should().BeFalse();
            result.Subject.Should().BeSameAs(sbj);
        }

        [Test]
        public void Satisfy_T_True()
        {
            var sbj = Test.TLeft;
            var result = sbj.Is((_) => true);
            result.IsSatisfied.Should().BeTrue();
            result.Subject.Should().BeSameAs(sbj);
        }

        [Test]
        public void Satisfy_T_False()
        {
            var sbj = Test.TLeft;
            var result = sbj.Is((_) => false);
            result.IsSatisfied.Should().BeFalse();
            result.Subject.Should().BeSameAs(sbj);
        }

        [Test]
        public void WhenSatisfiedDo_Action_True()
        {
            Test.SatisfiedT.WhenSatisfiedDo(_ => _.DescType = Test.Right)
                .Subject
                .Should().BeEquivalentTo(Test.TRight);
        }

        [Test]
        public void WhenSatisfiedDo_Action_False()
        {
            Test.NotSatisfiedT.WhenSatisfiedDo(_ => _.DescType = Test.Right)
                .Subject
                .Should().BeEquivalentTo(Test.T);
        }

        [Test]
        public void WhenNotSatisfiedDo_Action_True()
        {
            Test.NotSatisfiedT.WhenNotSatisfiedDo(_ => _.DescType = Test.Right)
                .Subject
                .Should().BeEquivalentTo(Test.TRight);
        }

        [Test]
        public void WhenNotSatisfiedDo_Action_False()
        {
            Test.SatisfiedT.WhenNotSatisfiedDo(_ => _.DescType = Test.Right)
                .Subject
                .Should().BeEquivalentTo(Test.T);
        }

        [Test]
        public void WhenSatisfiedDo_Func_True()
        {
            Test.SatisfiedT.WhenSatisfiedDo((_) => Test.TRight)
                .Subject
                .Should().BeEquivalentTo(Test.TRight);
        }

        [Test]
        public void WhenSatisfiedDo_Func_False()
        {
            Test.NotSatisfiedT.WhenSatisfiedDo(_ => Test.TRight)
                .Subject.Should().BeEquivalentTo(Test.T);
        }

        [Test]
        public void WhenNotSatisfiedDo_Func_True()
        {
            Test.NotSatisfiedT.WhenNotSatisfiedDo(_ => Test.TRight)
                .Subject
                .Should().BeEquivalentTo(Test.TRight);
        }

        [Test]
        public void WhenNotSatisfiedDo_Func_False()
        {
            Test.SatisfiedT.WhenNotSatisfiedDo(_ => Test.TRight)
                .Subject
                .Should().BeEquivalentTo(Test.T);
        }


        [Test]
        public void When_Cascade_Func_NotSatified()
        {
            Test.NotSatisfiedT
                .WhenNotSatisfiedDo(_ => Test.TRight)
                .WhenSatisfiedDo(_ => Test.TLeft)
                .Subject
                .Should().BeEquivalentTo(Test.TRight);
        }


        [Test]
        public void When_Cascade_Func_Satified()
        {
            Test.SatisfiedT
                .WhenNotSatisfiedDo(_ => Test.TRight)
                .WhenSatisfiedDo(_ => Test.TLeft)
                .Subject
                .Should().BeEquivalentTo(Test.TLeft);
        }


        [Test]
        public void When_Cascade_Action_NotSatified()
        {
            Test.NotSatisfiedT
                .WhenNotSatisfiedDo(_ => _.DescType = Test.Right)
                .WhenSatisfiedDo(_ => _.DescType = Test.Left)
                .Subject
                .Should().BeEquivalentTo(Test.TRight);
        }


        [Test]
        public void When_Cascade_Action_Satified()
        {
            Test.SatisfiedT
                .WhenNotSatisfiedDo(_ => _.DescType = Test.Right)
                .WhenSatisfiedDo(_ => _.DescType = Test.Left)
                .Subject
                .Should().BeEquivalentTo(Test.TLeft);
        }

        [Test]
        public void ContinueSatisfyWith_Action_Satified()
        {
            Test.SatisfiedT
                .ContinueSatisfyWith
                (
                    _ => _.DescType = Test.Right,
                    _ => _.DescType = Test.Left
                )
                .Subject
                .Should().BeEquivalentTo(Test.TRight);
        }


        [Test]
        public void ContinueSatisfyWith_Action_NotSatified()
        {
            Test.NotSatisfiedT
                .ContinueSatisfyWith
                (
                    _ => _.DescType = Test.Right,
                    _ => _.DescType = Test.Left
                )
                .Subject
                .Should().BeEquivalentTo(Test.TLeft);
        }

        [Test]
        public void ContinueSatisfyWith_Func_Satified()
        {
            Test.SatisfiedT
                .ContinueSatisfyWith
                (
                    _ => Test.TRight,
                    _ => Test.TLeft
                )
                .Subject
                .Should().BeEquivalentTo(Test.TRight);
        }


        [Test]
        public void ContinueSatisfyWith_Func_NotSatified()
        {
            Test.NotSatisfiedT
                .ContinueSatisfyWith
                (
                    _ => Test.TRight,
                    _ => Test.TLeft
                )
                .Subject
                .Should().BeEquivalentTo(Test.TLeft);
        }


        [Test]
        public void ContinueSatisfyWithMap_Satisfied()
        {
            Test.SatisfiedT
                .ContinueSatisfyWithMap
                (
                    _ => Test.Right,
                    _ => Test.Left
                )
                .Subject
                .Should().Be(Test.Right);
        }

        [Test]
        public void ContinueSatisfyWithMap_NotSatisfied()
        {
            Test.NotSatisfiedT
                .ContinueSatisfyWithMap
                (
                    _ => Test.Right,
                    _ => Test.Left
                )
                .Subject
                .Should().Be(Test.Left);
        }
    }
}
