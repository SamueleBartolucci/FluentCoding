using FluentAssertions;
using FluentCoding;
using FluentCoding._BaseTypes._IsTypes;
using FluentCodingTest;

using System.Diagnostics.CodeAnalysis;

namespace FluentCodingTest.Is_T
{
    [ExcludeFromCodeCoverage]
    public class IsNullOrEquivalent_Tests
    {
        [Test]
        public void IsNullOrDefault_IsNullOptionInstance()
        {
            "".IsNullOrEquivalent(IsNullOptions.StringIsNullWhenNull).Should().BeFalse();
            "".IsNullOrEquivalent(IsNullOptions.StringIsNullWhenNullOrEmpty).Should().BeTrue();
            "".IsNullOrEquivalent(IsNullOptions.StringIsNullWhenNullOrEmptyOrWhiteSpaces).Should().BeTrue();

            " ".IsNullOrEquivalent(IsNullOptions.StringIsNullWhenNull).Should().BeFalse();
            " ".IsNullOrEquivalent(IsNullOptions.StringIsNullWhenNullOrEmpty).Should().BeFalse();
            " ".IsNullOrEquivalent(IsNullOptions.StringIsNullWhenNullOrEmptyOrWhiteSpaces).Should().BeTrue();

            (null as string).IsNullOrEquivalent(IsNullOptions.StringIsNullWhenNull).Should().BeTrue();
            (null as string).IsNullOrEquivalent(IsNullOptions.StringIsNullWhenNullOrEmpty).Should().BeTrue();
            (null as string).IsNullOrEquivalent(IsNullOptions.StringIsNullWhenNullOrEmptyOrWhiteSpaces).Should().BeTrue();
        }

        [TestCase(StringIsNullWhenEnum.Null, true)]
        [TestCase(StringIsNullWhenEnum.NullOrEmpty, true)]
        [TestCase(StringIsNullWhenEnum.NullOrEmptyOrWhiteSpaces, true)]
        public void IsNullOrDefault_NullString_Cases(StringIsNullWhenEnum nullWhen, bool expected)
        {
            (null as string).IsNullOrEquivalent().Should().BeTrue();

            (null as string).IsNullOrEquivalent(_ => _.StringIsNullWhen = nullWhen)
             .Should().Be(expected);
        }


        [TestCase(StringIsNullWhenEnum.Null, false)]
        [TestCase(StringIsNullWhenEnum.NullOrEmpty, true)]
        [TestCase(StringIsNullWhenEnum.NullOrEmptyOrWhiteSpaces, true)]
        public void IsNullOrDefault_EmptyString_Cases(StringIsNullWhenEnum nullWhen, bool expected)
        {
            "".IsNullOrEquivalent().Should().BeTrue();

            "".IsNullOrEquivalent(_ => _.StringIsNullWhen = nullWhen)
             .Should().Be(expected);
        }

        [TestCase(StringIsNullWhenEnum.Null, false)]
        [TestCase(StringIsNullWhenEnum.NullOrEmpty, false)]
        [TestCase(StringIsNullWhenEnum.NullOrEmptyOrWhiteSpaces, true)]
        public void IsNullOrDefault_WhiteString_Cases(StringIsNullWhenEnum nullWhen, bool expected)
        {
            " ".IsNullOrEquivalent().Should().BeFalse();
            " ".IsNullOrEquivalent(_ => _.StringIsNullWhen = nullWhen)
             .Should().Be(expected);
        }




        [Test]
        public void IsNullOrDefault_Object() =>
            Test.NewT.IsNullOrEquivalent()
            .Should().BeFalse();

        [Test]
        public void IsNullOrDefault_String() =>
            Test.LEFT.IsNullOrEquivalent()
                .Should().BeFalse();
        
        [Test]
        public void IsNullOrDefault_null() =>
            Test.GetDefault<object>().IsNullOrEquivalent()
            .Should().BeTrue();

        [Test]
        public void IsNullOrDefault_Enum_FirstEntry() =>
            TestEnum.Enum1.IsNullOrEquivalent()
            .Should().BeFalse();

        [Test]
        public void IsNullOrDefault_Enum_NotFirstEntry() =>
            TestEnum.Enum2.IsNullOrEquivalent()
            .Should().BeFalse();

        [Test]
        public void IsNullOrDefault_Func() =>
            Test.NotNullFunc.IsNullOrEquivalent()
            .Should().BeFalse();

        [Test]
        public void IsNullOrDefault_NullFunc() =>
            Test.NullFunc.IsNullOrEquivalent()
            .Should().BeTrue();

    }
}
