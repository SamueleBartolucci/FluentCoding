using FluentAssertions;
using FluentCoding;

using System.Diagnostics.CodeAnalysis;


namespace FluentCoding.Test.FluentTypes.When
{
    [ExcludeFromCodeCoverage]
    public class WhenAsync_Test
    {

        [TestCase(true)]
        [TestCase(false)]
        public void WhenAsync_bool(bool trueCondition)
        {
            var when = Test.NewT.ToTask().WhenAsync(trueCondition).Result;
            when.IsSuccessful.Should().Be(trueCondition);
            when.Should().BeOfType(typeof(WhenOr<TType>));
            when.Subject.Should().BeEquivalentTo(Test.NewT);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void WhenAsync_Funct_T_bool(bool trueCondition)
        {
            var when = Test.NewT.ToTask().WhenAsync(() => trueCondition).Result;
            when.IsSuccessful.Should().Be(trueCondition);
            when.Should().BeOfType(typeof(WhenOr<TType>));
            when.Subject.Should().BeEquivalentTo(Test.NewT);
        }


        [TestCase(true)]
        [TestCase(false)]
        public void WhenAsync_Func_bool(bool trueCondition)
        {
            var when = Test.NewT.ToTask().WhenAsync((_) => trueCondition).Result;
            when.IsSuccessful.Should().Be(trueCondition);
            when.Should().BeOfType(typeof(WhenOr<TType>));
            when.Subject.Should().BeEquivalentTo(Test.NewT);
        }

        [Test]
        public void When_IsNullOrEquivalent()
        {
            var when = Test.NewT.ToTask().WhenIsNullOrEquivalentAsync().Result;
            when.IsSuccessful.Should().Be(false);
            when.Should().BeOfType(typeof(WhenOr<TType>));
            when.Subject.Should().BeEquivalentTo(Test.NewT);


            when = Test.GetDefault<TType>().ToTask().WhenIsNullOrEquivalentAsync().Result;
            when.IsSuccessful.Should().Be(true);
            when.Should().BeOfType(typeof(WhenOr<TType>));
            when.Subject.Should().BeEquivalentTo(Test.GetDefault<TType>());
        }

        [Test]
        public void When_IsNotNullOrEquivalent()
        {
            var when = Test.NewT.ToTask().WhenIsNotNullOrEquivalentAsync().Result;
            when.IsSuccessful.Should().Be(true);
            when.Should().BeOfType(typeof(WhenOr<TType>));
            when.Subject.Should().BeEquivalentTo(Test.NewT);


            when = Test.GetDefault<TType>().ToTask().WhenIsNotNullOrEquivalentAsync().Result;
            when.IsSuccessful.Should().Be(false);
            when.Should().BeOfType(typeof(WhenOr<TType>));
            when.Subject.Should().BeEquivalentTo(Test.GetDefault<TType>());
        }

        [Test]
        public void When_IsEqualsTo_string()
        {
            var when = Test.NewT.TDesc.ToTask().WhenEqualsToAsync(Test.NewT.TDesc).Result;
            when.IsSuccessful.Should().Be(true);
            when.Should().BeOfType(typeof(WhenOr<string>));
            when.Subject.Should().BeEquivalentTo(Test.NewT.TDesc);


            when = Test.NewT.TDesc.ToTask().WhenEqualsToAsync("XXX").Result;
            when.IsSuccessful.Should().Be(false);
            when.Should().BeOfType(typeof(WhenOr<string>));
            when.Subject.Should().BeEquivalentTo(Test.NewT.TDesc);
        }

        [Test]
        public void When_IsEqualsTo_enum()
        {
            var when = TestEnum.Enum1.ToTask().WhenEqualsToAsync(TestEnum.Enum1).Result;
            when.IsSuccessful.Should().Be(true);
            when.Should().BeOfType(typeof(WhenOr<TestEnum>));
            when.Subject.Should().Be(TestEnum.Enum1);


            when = TestEnum.Enum1.ToTask().WhenEqualsToAsync(TestEnum.Enum2).Result;
            when.IsSuccessful.Should().Be(false);
            when.Should().BeOfType(typeof(WhenOr<TestEnum>));
            when.Subject.Should().Be(TestEnum.Enum1);
        }
    }
}