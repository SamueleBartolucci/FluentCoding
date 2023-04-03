using FluentAssertions;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;


namespace FluentCoding.Test.FluentTypes.When
{
    [ExcludeFromCodeCoverage]
    public class WhenAny_Test
    {

        [Test]
        public void WhenAny_Func_IsSuccessful()
        {
            var input = new[] { Test.DONE, Test.NOT_DONE, Test.LEFT, Test.RIGHT };
            var when = input.WhenAny(_ => _ == Test.LEFT);
            when.IsSuccessful.Should().BeTrue();
            when.Should().BeOfType(typeof(WhenOr<IEnumerable<string>>));
            when.Subject.Should().BeEquivalentTo(input);
        }


        [Test]
        public void WhenAny_Func_NotIsSuccessful()
        {
            var input = new[] { Test.DONE, Test.NOT_DONE, Test.LEFT, Test.RIGHT };
            var when = input.WhenAny(_ => _ == "XX");
            when.IsSuccessful.Should().BeFalse();
            when.Should().BeOfType(typeof(WhenOr<IEnumerable<string>>));
            when.Subject.Should().BeEquivalentTo(input);
        }


        [Test]
        public void WhenAny_NotEmpty()
        {
            var input = new[] { Test.DONE, Test.NOT_DONE, Test.LEFT, Test.RIGHT };
            var when = input.WhenAny();
            when.IsSuccessful.Should().BeTrue();
            when.Should().BeOfType(typeof(WhenOr<IEnumerable<string>>));
            when.Subject.Should().BeEquivalentTo(input);
        }


        [Test]
        public void WhenAny_Empty()
        {
            var when = new List<string>().WhenAny();
            when.IsSuccessful.Should().BeFalse();
            when.Should().BeOfType(typeof(WhenOr<IEnumerable<string>>));
            when.Subject.Should().BeEquivalentTo(new List<string>());
        }


        [Test]
        public void WhenEmptyOrNull_NotEmpty()
        {
            var input = new[] { Test.DONE, Test.NOT_DONE, Test.LEFT, Test.RIGHT };
            var when = input.WhenEmptyOrNull();
            when.IsSuccessful.Should().BeFalse();
            when.Should().BeOfType(typeof(WhenOr<IEnumerable<string>>));
            when.Subject.Should().BeEquivalentTo(input);
        }


        [Test]
        public void WhenEmptyOrNull_Empty()
        {
            var when = new List<string>().WhenEmptyOrNull();
            when.IsSuccessful.Should().BeTrue();
            when.Should().BeOfType(typeof(WhenOr<IEnumerable<string>>));
            when.Subject.Should().BeEquivalentTo(new List<string>());
        }


        [Test]
        public void WhenAll_true()
        {
            var when = new[] { 1, 2, 3, 4, 5, 6 }.WhenAll(v => v <= 6);
            when.IsSuccessful.Should().BeTrue();
            when.Should().BeOfType(typeof(WhenOr<IEnumerable<int>>));
            when.Subject.Should().BeEquivalentTo(new[] { 1, 2, 3, 4, 5, 6 });
        }

        [Test]
        public void WhenAll_false()
        {
            var when = new[] { 1, 2, 3, 4, 5, 6 }.WhenAll(v => v <= 4);
            when.IsSuccessful.Should().BeFalse();
            when.Should().BeOfType(typeof(WhenOr<IEnumerable<int>>));
            when.Subject.Should().BeEquivalentTo(new[] { 1, 2, 3, 4, 5, 6 });
        }
    }

}