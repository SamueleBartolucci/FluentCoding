using FluentAssertions;
using FluentCoding;

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;


namespace FluentCoding.Test.FluentTypes.When
{
    [ExcludeFromCodeCoverage]
    public class WhenAnyAsync_Test
    {

        [Test]
        public void WhenAnyAsync_func_IsSuccessful()
        {

            IEnumerable<string> input = new List<string>() { Test.DONE, Test.NOT_DONE, Test.LEFT, Test.RIGHT };

            var when = input.ToTask().WhenAnyAsync(_ => _ == Test.LEFT).Result;
            when.IsSuccessful.Should().BeTrue();
            when.Should().BeOfType(typeof(WhenOr<IEnumerable<string>>));
            when.Subject.Should().BeEquivalentTo(input);
        }


        [Test]
        public void WhenAnyAsync_func_NotIsSuccessful()
        {
            IEnumerable<string> input = new[] { Test.DONE, Test.NOT_DONE, Test.LEFT, Test.RIGHT };
            var when = input.ToTask().WhenAnyAsync(_ => _ == "XX").Result;
            when.IsSuccessful.Should().BeFalse();
            when.Should().BeOfType(typeof(WhenOr<IEnumerable<string>>));
            when.Subject.Should().BeEquivalentTo(input);
        }


        [Test]
        public void WhenAnyAsync_NotEmpty()
        {
            IEnumerable<string> input = new[] { Test.DONE, Test.NOT_DONE, Test.LEFT, Test.RIGHT };
            var when = input.ToTask().WhenAnyAsync().Result;
            when.IsSuccessful.Should().BeTrue();
            when.Should().BeOfType(typeof(WhenOr<IEnumerable<string>>));
            when.Subject.Should().BeEquivalentTo(input);
        }


        [Test]
        public void WhenAnyAsync_Empty()
        {
            IEnumerable<string> input = new List<string>();
            var when = input.ToTask().WhenAnyAsync().Result;
            when.IsSuccessful.Should().BeFalse();
            when.Should().BeOfType(typeof(WhenOr<IEnumerable<string>>));
            when.Subject.Should().BeEquivalentTo(new List<string>());
        }


        [Test]
        public void WhenEmptyOrNullAsync_NotEmpty()
        {
            IEnumerable<string> input = new[] { Test.DONE, Test.NOT_DONE, Test.LEFT, Test.RIGHT };
            var when = input.ToTask().WhenEmptyOrNullAsync().Result;
            when.IsSuccessful.Should().BeFalse();
            when.Should().BeOfType(typeof(WhenOr<IEnumerable<string>>));
            when.Subject.Should().BeEquivalentTo(input);
        }


        [Test]
        public void WhenEmptyOrNullAsync_Empty()
        {
            IEnumerable<string> input = new List<string>();
            var when = input.ToTask().WhenEmptyOrNullAsync().Result;
            when.IsSuccessful.Should().BeTrue();
            when.Should().BeOfType(typeof(WhenOr<IEnumerable<string>>));
            when.Subject.Should().BeEquivalentTo(input);
        }
    }
}