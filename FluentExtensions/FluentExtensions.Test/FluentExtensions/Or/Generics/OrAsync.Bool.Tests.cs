using FluentAssertions;
using System.Diagnostics.CodeAnalysis;


namespace FluentCoding.Test.FluentExtensions.Or.Generics
{
    [ExcludeFromCodeCoverage]
    public class OrAsync_Bool_Tests
    {

        [Test]
        public void OrAsync_NullValueType()
        {
            decimal? input = null;
            input.ToTask().OrAsync(10).Result.Should().Be(10);
        }

        [Test]
        public void OrAsync_String_Left1()
            => Test.LEFT.ToTask().OrAsync(Test.RIGHT)
                .Result.Should().Be(Test.LEFT);

        [Test]
        public void OrAsync_String_Left2()
            => Test.LEFT.ToTask().OrAsync(Test.GetDefault<string>())
                .Result.Should().Be(Test.LEFT);

        [Test]
        public void OrAsync_StringEmpty_Right()
            => string.Empty.ToTask().OrAsync(Test.RIGHT)
                .Result.Should().Be(string.Empty);

        [Test]
        public void OrAsync_StringSpaces_Right()
            => " ".ToTask().OrAsync(Test.RIGHT)
                .Result.Should().Be(" ");

        [Test]
        public void OrAsync_Null_Right()
            => (null as string).ToTask().OrAsync(Test.RIGHT)
                .Result.Should().Be(Test.RIGHT);

        [Test]
        public void OrAsync_Object_Left()
            => Test.NewTLeft.ToTask().OrAsync(Test.NewTRight)
                .Result.Should().BeEquivalentTo(Test.NewTLeft);

        [Test]
        public void OrAsync_Object_Right()
            => Test.GetDefault<TType>().ToTask().OrAsync(Test.NewTRight)
                .Result.Should().BeEquivalentTo(Test.NewTRight);

        [Test]
        public void OrAsync_Null_RightPriority_Right()
            => Test.GetDefault<TType>().ToTask().OrAsync(Test.NewTRight, true)
                .Result.Should().BeEquivalentTo(Test.NewTRight);

        [Test]
        public void OrAsync_Object_RightPriority_Right()
            => Test.NewTLeft.ToTask().OrAsync(Test.NewTRight, true)
               .Result.Should().BeEquivalentTo(Test.NewTRight);

    }
}
