using FluentAssertions;
using FluentCoding;
using FluentCoding;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using NUnit.Framework.Internal;
using System.Diagnostics.CodeAnalysis;


namespace FluentCoding.Test.FluentTypes.When
{
    [ExcludeFromCodeCoverage]
    public class When_Test
    {

        [TestCase(true)]
        [TestCase(false)]
        public void When_bool(bool trueCondition)
        {
            var when = Test.NewT.When(trueCondition);
            when.IsSuccessful.Should().Be(trueCondition);
            when.Should().BeOfType(typeof(WhenOr<TType>));
            when.Subject.Should().BeEquivalentTo(Test.NewT);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void When_Funct_T_bool(bool trueCondition)
        {
            var when = Test.NewT.When(() => trueCondition);
            when.IsSuccessful.Should().Be(trueCondition);
            when.Should().BeOfType(typeof(WhenOr<TType>));
            when.Subject.Should().BeEquivalentTo(Test.NewT);
        }


        [TestCase(true)]
        [TestCase(false)]
        public void When_Func_bool(bool trueCondition)
        {
            var when = Test.NewT.When((_) => trueCondition);
            when.IsSuccessful.Should().Be(trueCondition);
            when.Should().BeOfType(typeof(WhenOr<TType>));
            when.Subject.Should().BeEquivalentTo(Test.NewT);
        }


        [Test]
        public void When_IsNullOrEquivalent()
        {
            var when = Test.NewT.WhenIsNullOrEquivalent();
            when.IsSuccessful.Should().Be(false);
            when.Should().BeOfType(typeof(WhenOr<TType>));
            when.Subject.Should().BeEquivalentTo(Test.NewT);


            when = Test.GetDefault<TType>().WhenIsNullOrEquivalent();
            when.IsSuccessful.Should().Be(true);
            when.Should().BeOfType(typeof(WhenOr<TType>));
            when.Subject.Should().BeEquivalentTo(Test.GetDefault<TType>());
        }

        [Test]
        public void When_IsNotNullOrEquivalent()
        {
            var when = Test.NewT.WhenIsNotNullOrEquivalent();
            when.IsSuccessful.Should().Be(true);
            when.Should().BeOfType(typeof(WhenOr<TType>));
            when.Subject.Should().BeEquivalentTo(Test.NewT);


            when = Test.GetDefault<TType>().WhenIsNotNullOrEquivalent();
            when.IsSuccessful.Should().Be(false);
            when.Should().BeOfType(typeof(WhenOr<TType>));
            when.Subject.Should().BeEquivalentTo(Test.GetDefault<TType>());
        }

        [Test]
        public void When_IsEqualsTo_string()
        {
            var when = Test.NewT.TDesc.WhenEqualsTo(Test.NewT.TDesc);
            when.IsSuccessful.Should().Be(true);
            when.Should().BeOfType(typeof(WhenOr<string>));
            when.Subject.Should().BeEquivalentTo(Test.NewT.TDesc);


            when = Test.NewT.TDesc.WhenEqualsTo("XXX");
            when.IsSuccessful.Should().Be(false);
            when.Should().BeOfType(typeof(WhenOr<string>));
            when.Subject.Should().BeEquivalentTo(Test.NewT.TDesc);
        }

        [Test]
        public void When_IsEqualsTo_enum()
        {
            var when = TestEnum.Enum1.WhenEqualsTo(TestEnum.Enum1);
            when.IsSuccessful.Should().Be(true);
            when.Should().BeOfType(typeof(WhenOr<TestEnum>));
            when.Subject.Should().Be(TestEnum.Enum1);


            when = TestEnum.Enum1.WhenEqualsTo(TestEnum.Enum2);
            when.IsSuccessful.Should().Be(false);
            when.Should().BeOfType(typeof(WhenOr<TestEnum>));
            when.Subject.Should().Be(TestEnum.Enum1);
        }
    }
}