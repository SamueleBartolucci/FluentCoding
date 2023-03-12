using FluentAssertions;
using FluentCoding;
using FluentCoding._BaseTypes._IsTypes;
using FluentCodingTest;

using System.Diagnostics.CodeAnalysis;

namespace FluentCodingTest.Is_T
{
    [ExcludeFromCodeCoverage]
    public class IsOptnNullOrEquivalent_Optional_Tests
    {
        [Test]
        public void IsNullOrDefault_IsNullOptionInstance()
        {
            "".ToOptional().IsOptnNullOrEquivalent(IsNullOptions.StringIsNullWhenNull).Should().BeFalse();
            "".ToOptional().IsOptnNullOrEquivalent(IsNullOptions.StringIsNullWhenNullOrEmpty).Should().BeTrue();
            "".ToOptional().IsOptnNullOrEquivalent(IsNullOptions.StringIsNullWhenNullOrEmptyOrWhiteSpaces).Should().BeTrue();

            " ".ToOptional().IsOptnNullOrEquivalent(IsNullOptions.StringIsNullWhenNull).Should().BeFalse();
            " ".ToOptional().IsOptnNullOrEquivalent(IsNullOptions.StringIsNullWhenNullOrEmpty).Should().BeFalse();
            " ".ToOptional().IsOptnNullOrEquivalent(IsNullOptions.StringIsNullWhenNullOrEmptyOrWhiteSpaces).Should().BeTrue();

            (null as string).ToOptional().IsOptnNullOrEquivalent(IsNullOptions.StringIsNullWhenNull).Should().BeTrue();
            (null as string).ToOptional().IsOptnNullOrEquivalent(IsNullOptions.StringIsNullWhenNullOrEmpty).Should().BeTrue();
            (null as string).ToOptional().IsOptnNullOrEquivalent(IsNullOptions.StringIsNullWhenNullOrEmptyOrWhiteSpaces).Should().BeTrue();
        }

        [TestCase(StringIsNullWhenEnum.Null, true)]
        [TestCase(StringIsNullWhenEnum.NullOrEmpty, true)]
        [TestCase(StringIsNullWhenEnum.NullOrEmptyOrWhiteSpaces, true)]
        public void IsNullOrDefault_NullString_Cases(StringIsNullWhenEnum nullWhen, bool expected)
        {
            (null as string).ToOptional().IsOptnNullOrEquivalent().Should().BeTrue();

            (null as string).ToOptional().IsOptnNullOrEquivalent(_ => _.StringIsNullWhen = nullWhen)
             .Should().Be(expected);
        }


        [TestCase(StringIsNullWhenEnum.Null, false)]
        [TestCase(StringIsNullWhenEnum.NullOrEmpty, true)]
        [TestCase(StringIsNullWhenEnum.NullOrEmptyOrWhiteSpaces, true)]
        public void IsNullOrDefault_EmptyString_Cases(StringIsNullWhenEnum nullWhen, bool expected)
        {
            "".ToOptional().IsOptnNullOrEquivalent().Should().BeTrue();

            "".ToOptional().IsOptnNullOrEquivalent(_ => _.StringIsNullWhen = nullWhen)
             .Should().Be(expected);
        }

        [TestCase(StringIsNullWhenEnum.Null, false)]
        [TestCase(StringIsNullWhenEnum.NullOrEmpty, false)]
        [TestCase(StringIsNullWhenEnum.NullOrEmptyOrWhiteSpaces, true)]
        public void IsNullOrDefault_WhiteString_Cases(StringIsNullWhenEnum nullWhen, bool expected)
        {
            " ".ToOptional().IsOptnNullOrEquivalent().Should().BeFalse();
            " ".ToOptional().IsOptnNullOrEquivalent(_ => _.StringIsNullWhen = nullWhen)
             .Should().Be(expected);
        }




        [Test]
        public void IsNullOrDefault_Object() =>
            Test.NewT.ToOptional().IsOptnNullOrEquivalent()
            .Should().BeFalse();

        [Test]
        public void IsNullOrDefault_String() =>
            Test.LEFT.ToOptional().IsOptnNullOrEquivalent()
                .Should().BeFalse();
        
        [Test]
        public void IsNullOrDefault_null() =>
            Test.GetDefault<object>().ToOptional().IsOptnNullOrEquivalent()
            .Should().BeTrue();

        [Test]
        public void IsNullOrDefault_Enum_FirstEntry() =>
            TestEnum.Enum1.ToOptional().IsOptnNullOrEquivalent()
            .Should().BeFalse();

        [Test]
        public void IsNullOrDefault_Enum_NotFirstEntry() =>
            TestEnum.Enum2.ToOptional().IsOptnNullOrEquivalent()
            .Should().BeFalse();

        [Test]
        public void IsNullOrDefault_Func() =>
            Test.NotNullFunc.ToOptional().IsOptnNullOrEquivalent()
            .Should().BeFalse();

        [Test]
        public void IsNullOrDefault_NullFunc() =>
            Test.NullFunc.ToOptional().IsOptnNullOrEquivalent()
            .Should().BeTrue();

    }
}
