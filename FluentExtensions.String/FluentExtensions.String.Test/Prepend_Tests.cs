using FluentAssertions;
using FluentCoding;
using FluentCoding.String;
using System.Collections.Generic;
using System.Linq;

namespace FluentExtensions.String.Test
{
    public class Prepend_Tests
    {
        [TestCase(true)]
        [TestCase(false)]
        public void PrependWhen_bool(bool doPrepend)
        {
            var testList = new List<string>() { "1", "2", "3" };
            var result = testList.PrependWhen("0", doPrepend).ToList();

            testList.First().Should().Be("1");
            testList.Count.Should().Be(3);

            result.First().Should().Be("1".Or("0", doPrepend));
            result.Count.Should().Be(3.Or(4, doPrepend));
        }
    }
}
