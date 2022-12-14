using FluentAssertions;
using FluentCoding;

using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.Is_T
{
    [ExcludeFromCodeCoverage]
    public class Is_T_Func_T_Bool_Tests
    {


        [Test]
        public void Is_True_Null()
        {
            var sbj = Test.GetDefault<TypeT>();
            var result = sbj.Is((_) => true);
            result.IsSatisfied.Should().BeTrue();
            result.Subject.Should().BeNull();
        }

        [Test]
        public void Is_False_Null()
        {
            var sbj = Test.GetDefault<TypeT>();
            var result = sbj.Is((_) => false);
            result.IsSatisfied.Should().BeFalse();
            result.Subject.Should().BeNull();
        }


        [Test]
        public void Is_True_Object()
        {
            var sbj = Test.TLeft;
            var result = sbj.Is((_) => true);
            result.IsSatisfied.Should().BeTrue();
            result.Subject.Should().BeSameAs(sbj);
        }

        [Test]
        public void Is_False_Object()
        {
            var sbj = Test.TLeft;
            var result = sbj.Is((_) => false);
            result.IsSatisfied.Should().BeFalse();
            result.Subject.Should().BeSameAs(sbj);
        }


        [Test]
        public void Is_True_String()
        {
            var sbj = Test.Left;
            var result = sbj.Is((_) => true);
            result.IsSatisfied.Should().BeTrue();
            result.Subject.Should().BeSameAs(sbj);
        }

        [Test]
        public void Is_False_String()
        {
            var sbj = Test.Left;
            var result = sbj.Is((_) => false);
            result.IsSatisfied.Should().BeFalse();
            result.Subject.Should().BeSameAs(sbj);
        }


        [Test]
        public void Is_True_Struct()
        {
            var sbj = DateTime.Now;
            var result = sbj.Is((_) => true);
            result.IsSatisfied.Should().BeTrue();
            result.Subject.Should().Be(sbj);
        }

        [Test]
        public void Is_False_Struct()
        {
            var sbj = DateTime.Now;
            var result = sbj.Is((_) => false);
            result.IsSatisfied.Should().BeFalse();
            result.Subject.Should().Be(sbj);
        }

    }
}
