using FluentAssertions;
using FluentCoding.Enum_;
using NUnit.Framework;

namespace FluentExtensions.Enum.Test
{

    public class Tests
    {
        enum WithValues
        {
            [System.ComponentModel.Description("FirstValue")]
            Value01,
            [System.ComponentModel.Description("SecondValue")]
            Value02
        }

        enum WithoutValues
        {
            Value01,
            Value02
        }


        [Test]
        public void GetDescription_EnumWithValue() =>
            WithValues.Value01.GetEnumDescription().Should().Be("FirstValue");

        [Test]
        public void GetDescription_EnumWithoutValue() =>
           WithoutValues.Value01.GetEnumDescription().Should().Be("Value01");
    }
}