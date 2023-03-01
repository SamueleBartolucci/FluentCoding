using FluentAssertions;
using FluentCoding;
using FluentCodingTest;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.When_T
{
    [ExcludeFromCodeCoverage]
    public class WhenAnyAsync_Test
    {

        [Test]
        public void WhenAnyAsync_IsSuccessful()
        {
            
            IEnumerable<string> input = new List<string>() { Test.DONE, Test.NOT_DONE, Test.LEFT, Test.RIGHT };

            var when = input.ToTask().WhenAnyAsync(_ => _ == Test.LEFT).Result;
            when.IsSuccessful.Should().BeTrue();
            when.Should().BeOfType(typeof(WhenOr<IEnumerable<string>>));
            when.Subject.Should().BeEquivalentTo(input);
        }


        [Test]
        public void WhenAnyAsync_NotIsSuccessful()
        {
            IEnumerable<string> input = new[] { Test.DONE, Test.NOT_DONE, Test.LEFT, Test.RIGHT };
            var when = input.ToTask().WhenAnyAsync(_ => _ == "XX").Result;
            when.IsSuccessful.Should().BeFalse();
            when.Should().BeOfType(typeof(WhenOr<IEnumerable<string>>));
            when.Subject.Should().BeEquivalentTo(input);
        }
    }
}