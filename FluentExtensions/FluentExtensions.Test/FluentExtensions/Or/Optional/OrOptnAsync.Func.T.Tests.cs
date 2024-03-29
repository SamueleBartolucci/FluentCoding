using FluentAssertions;
using System.Diagnostics.CodeAnalysis;


namespace FluentCoding.Test.FluentExtensions.Or.Generics
{
    [ExcludeFromCodeCoverage]
    public class OrOptnAsync_T_Func_TBool_Tests
    {

        [Test]
        public void OrOptnAsync_String_Left1()
            => Test.LEFT.ToOptional().ToTask().OrOptnAsync(Test.RIGHT, (s) => false)
                .Result.Should().Be(Test.LEFT);

        [Test]
        public void OrOptnAsync_String_Left2()
            => Test.LEFT.ToOptional().ToTask().OrOptnAsync(null, (s) => false)
                .Result.Should().Be(Test.LEFT);

        [Test]
        public void OrOptnAsync_StringEmpty_Right()
            => string.Empty.ToOptional().ToTask().OrOptnAsync(Test.RIGHT, (s) => false)
                .Result.Should().Be(string.Empty);

        [Test]
        public void OrOptnAsync_StringSpaces_Right()
            => " ".ToOptional().ToTask().OrOptnAsync(Test.RIGHT, (s) => false)
                .Result.Should().Be(" ");

        [Test]
        public void OrOptnAsync_Null_Right()
            => (null as string)
                .ToOptional().ToTask().OrOptnAsync(Test.RIGHT, (s) => false)
                .Result.Should().Be(Test.RIGHT);

        [Test]
        public void OrOptnAsync_Object_Left()
            => Test.NewTLeft
                .ToOptional().ToTask().OrOptnAsync(Test.NewTRight, (s) => false)
                .Result.Should().BeEquivalentTo(Test.NewTLeft);

        [Test]
        public void OrOptnAsync_Object_Right()
            => Test.GetDefault<TType>()
                .ToOptional().ToTask().OrOptnAsync(Test.NewTRight, (s) => false)
                .Result.Should().BeEquivalentTo(Test.NewTRight);

        [Test]
        public void OrOptnAsync_Null_RightPriority_Right()
            => Test.GetDefault<TType>().ToOptional().ToTask().OrOptnAsync(Test.NewTRight, (s) => true)
                .Result.Should().BeEquivalentTo(Test.NewTRight);

        [Test]
        public void OrOptnAsync_Null_LeftPriority_Right()
          => Test.GetDefault<TType>().ToOptional().ToTask().OrOptnAsync(Test.NewTRight, (s) => false)
              .Result.Should().BeEquivalentTo(Test.NewTRight);

        [Test]
        public void OrOptnAsync_Object_RightPriority_Right()
            => Test.NewTLeft.ToOptional().ToTask().OrOptnAsync(Test.NewTRight, (s) => true)
                .Result.Should().BeEquivalentTo(Test.NewTRight);
    }
}
