using FluentAssertions;
using FluentCoding;
using FluentCodingTest;

using System.Diagnostics.CodeAnalysis;

namespace FluentCodingTest.Is_T
{
    [ExcludeFromCodeCoverage]
    public class IsNullOrDefault_Tests
    {


        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, true)]
        [TestCase(true, false)]
        public void IsNullOrDefault_EmptyString_Cases(bool emptyIsNull, bool emptyOrWhiteSpaceIsNull)
        {
            "".IsNullOrEquivalent().Should().BeTrue();

            "".IsNullOrEquivalent(_ =>
            {
                _.EmptyStringIsNull = emptyIsNull;
                _.EmptyOrWhiteSpacesIsNull = emptyOrWhiteSpaceIsNull;
            })
             .Should().Be(emptyIsNull||emptyOrWhiteSpaceIsNull);
        }

        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, true)]
        [TestCase(true, false)]
        public void IsNullOrDefault_WhiteString_Cases(bool emptyIsNull, bool emptyOrWhiteSpaceIsNull)
        {
            " ".IsNullOrEquivalent().Should().BeFalse();
            " ".IsNullOrEquivalent(_ =>
            {
                _.EmptyStringIsNull = emptyIsNull;
                _.EmptyOrWhiteSpacesIsNull = emptyOrWhiteSpaceIsNull;
            })
             .Should().Be(emptyOrWhiteSpaceIsNull);
        }




        [Test]
        public void IsNullOrDefault_Object() =>
            Test.T.IsNullOrEquivalent()
            .Should().BeFalse();

        [Test]
        public void IsNullOrDefault_String() =>
            Test.Left.IsNullOrEquivalent()
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
