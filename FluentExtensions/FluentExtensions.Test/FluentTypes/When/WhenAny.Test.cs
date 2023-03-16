using FluentAssertions;
using FluentCoding;
using FluentCoding;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;


namespace FluentCoding.Test.FluentTypes.When
{
    [ExcludeFromCodeCoverage]
    public class WhenAny_Test
    {

        [Test]
        public void WhenAny_IsSuccessful()
        {
            var input = new[] { Test.DONE, Test.NOT_DONE, Test.LEFT, Test.RIGHT };
            var when = input.WhenAny(_ => _ == Test.LEFT);
            when.IsSuccessful.Should().BeTrue();
            when.Should().BeOfType(typeof(WhenOr<IEnumerable<string>>));
            when.Subject.Should().BeEquivalentTo(input);
        }


        [Test]
        public void WhenAny_NotIsSuccessful()
        {
            var input = new[] { Test.DONE, Test.NOT_DONE, Test.LEFT, Test.RIGHT };
            var when = input.WhenAny(_ => _ == "XX");
            when.IsSuccessful.Should().BeFalse();
            when.Should().BeOfType(typeof(WhenOr<IEnumerable<string>>));
            when.Subject.Should().BeEquivalentTo(input);
        }
    }
}