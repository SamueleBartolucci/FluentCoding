using FluentAssertions;
using FluentCoding;

using System.Diagnostics.CodeAnalysis;

namespace FluentCodingTest.IsNullOrDefault_T
{
    [ExcludeFromCodeCoverage]
    public class IsNullOrDefault_T_Tests
    {
        [Test]
        public void IsNullOrDefault_Object() =>
            Test.T.IsNullOrDefault()
            .Should().BeFalse();

        [Test]
        public void IsNullOrDefault_String() =>
            Test.Left.IsNullOrDefault()
                .Should().BeFalse();

        [Test]
        public void IsNullOrDefault_StringEmpty() =>
            string.Empty.IsNullOrDefault()
            .Should().BeTrue();

        [Test]
        public void IsNullOrDefault_StringWhiteSpace() =>
            " ".IsNullOrDefault()
            .Should().BeTrue();

        [Test]
        public void IsNullOrDefault_StringWhiteSpace_NoTrim() =>
            " ".IsNullOrDefault(false)
            .Should().BeFalse();

        [Test]
        public void IsNullOrDefault_null() =>
            Test.GetDefault<object>().IsNullOrDefault()
            .Should().BeTrue();

        [Test]
        public void IsNullOrDefault_Enum_FirstEntry() =>
            TestEnum.Enum1.IsNullOrDefault()
            .Should().BeFalse();

        [Test]
        public void IsNullOrDefault_Enum_NotFirstEntry() =>
            TestEnum.Enum2.IsNullOrDefault()
            .Should().BeFalse();

        [Test]
        public void IsNullOrDefault_Func() =>
            Test.NotNullFunc.IsNullOrDefault()
            .Should().BeFalse();

        [Test]
        public void IsNullOrDefault_NullFunc() =>
            Test.NullFunc.IsNullOrDefault()
            .Should().BeTrue();

    }
}
