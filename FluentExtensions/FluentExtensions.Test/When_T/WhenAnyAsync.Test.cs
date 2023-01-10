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
        public void WhenAnyAsync_IsSuccesful()
        {
            
            IEnumerable<string> input = new List<string>() { Test.Done, Test.NotDone, Test.Left, Test.Right };

            var when = input.ToTask().WhenAnyAsync(_ => _ == Test.Left).Result;
            when.IsSuccesful.Should().BeTrue();
            when.Should().BeOfType(typeof(WhenOr<IEnumerable<string>>));
            when.Subject.Should().BeEquivalentTo(input);
        }


        [Test]
        public void WhenAnyAsync_NotIsSuccesful()
        {
            IEnumerable<string> input = new[] { Test.Done, Test.NotDone, Test.Left, Test.Right };
            var when = input.ToTask().WhenAnyAsync(_ => _ == "XX").Result;
            when.IsSuccesful.Should().BeFalse();
            when.Should().BeOfType(typeof(WhenOr<IEnumerable<string>>));
            when.Subject.Should().BeEquivalentTo(input);
        }
    }
}