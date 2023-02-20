using FluentAssertions;
using FluentCoding;
using FluentCoding;
using FluentCodingTest;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.When_T
{
    [ExcludeFromCodeCoverage]
    public class WhenAny_Test
    {

        [Test]
        public void WhenAny_IsSuccessful()
        {
            var input = new[] { Test.Done, Test.NotDone, Test.Left, Test.Right };
            var when = input.WhenAny(_ => _ == Test.Left);
            when.IsSuccessful.Should().BeTrue();
            when.Should().BeOfType(typeof(WhenOr<IEnumerable<string>>));
            when.Subject.Should().BeEquivalentTo(input);
        }


        [Test]
        public void WhenAny_NotIsSuccessful()
        {
            var input = new[] { Test.Done, Test.NotDone, Test.Left, Test.Right };
            var when = input.WhenAny(_ => _ == "XX");
            when.IsSuccessful.Should().BeFalse();
            when.Should().BeOfType(typeof(WhenOr<IEnumerable<string>>));
            when.Subject.Should().BeEquivalentTo(input);
        }
    }
}