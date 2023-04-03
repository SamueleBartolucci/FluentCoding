using FluentAssertions;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace FluentCoding.Test.FluentTypes.Optional
{
    [ExcludeFromCodeCoverage]
    public class Optional_Tests
    {

        [Test]
        public void Some_BangOperator()
        {
            Assert.False(!Optional<TType>.Some(Test.NewT));
            Assert.True(Optional<TType>.Some(Test.NewT));
        }

        [Test]
        public void None_BangOperator()
        {
            Assert.True(!Optional<TType>.None());
            Assert.False(Optional<TType>.None());
        }


        [Test]
        public void Some_NotNull()
        {
            Optional<TType>.Some(Test.NewT).Do(optnT =>
            {
                optnT.IsSome().Should().BeTrue();
                optnT.IsNone().Should().BeFalse();
                optnT.Subject.Should().BeEquivalentTo(Test.NewT);
                optnT.IsSuccessful.Should().BeTrue();
            });
        }


        [Test]
        public void Some_Null()
        {
            Optional<TType>.Some(Test.GetDefault<TType>()).Do(optnT =>
            {
                optnT.IsNone().Should().BeTrue();
                optnT.IsSome().Should().BeFalse();
                optnT.Subject.Should().BeNull();
                optnT.IsSuccessful.Should().BeFalse();
            });
        }


        [Test]
        public void None()
        {
            Optional<TType>.None().Do(optnT =>
            {
                optnT.IsNone().Should().BeTrue();
                optnT.IsSome().Should().BeFalse();
                optnT.Subject.Should().BeNull();
                optnT.IsSuccessful.Should().BeFalse();
            });
        }

        [Test]
        public void ToOptional_NotNull()
        {
            Test.NewT.ToOptional().Do(optnT =>
            {
                optnT.IsSome().Should().BeTrue();
                optnT.IsNone().Should().BeFalse();
                optnT.Subject.Should().BeEquivalentTo(Test.NewT);
                optnT.IsSuccessful.Should().BeTrue();
            });
        }


        [Test]
        public void ToOptional_Null()
        {
            Test.GetDefault<TType>().ToOptional().Do(optnT =>
             {
                 optnT.IsNone().Should().BeTrue();
                 optnT.IsSome().Should().BeFalse();
                 optnT.Subject.Should().BeNull();
                 optnT.IsSuccessful.Should().BeFalse();
             });
        }


        [Test]
        public void ToOptional_EnumerableWithData()
        {
            var enumOptionalItems = Enumerable.Range(0, 10).ToOptionalForEach();

            enumOptionalItems.Should().NotBeNullOrEmpty();
            (enumOptionalItems is IEnumerable<Optional<int>>).Should().BeTrue();
            enumOptionalItems.Should().AllSatisfy(optnItem =>
            {
                optnItem.IsSome();
                optnItem.IsNone().Should().BeFalse();
                optnItem.Subject.Should().BeGreaterThanOrEqualTo(0);
                optnItem.IsSuccessful.Should().BeTrue();
            });
        }

        [Test]
        public void ToOptional_EnumerableEmpty()
        {
            var enumOptionalItems = Enumerable.Range(0, 0).ToOptionalForEach();

            enumOptionalItems.Should().BeEmpty();
            (enumOptionalItems is ICollection<Optional<int>>).Should().BeTrue();
        }

        [Test]
        public void ToOptional_EnumerableNull()
        {
            var enumOptionalItems = Test.GetDefault<IEnumerable<int>>().ToOptionalForEach();
            enumOptionalItems.Should().BeNull();
        }
    }
}

