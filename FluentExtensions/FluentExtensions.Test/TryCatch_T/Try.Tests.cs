using FluentAssertions;
using FluentCoding;
using FluentCodingTest;
using NUnit.Framework.Internal;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.TryCatch_T
{
    [ExcludeFromCodeCoverage]
    public class Try_Tests
    {

        [Test]
        public void Try_Success()
        {
            var tryCatch = Test.NewTNotDone.Try(_ => Test.NewKRight);

            tryCatch.IsSuccessful.Should().BeTrue();
            tryCatch.Subject.Should().BeEquivalentTo(Test.NewTNotDone);
            tryCatch.Result.Should().BeEquivalentTo(Test.NewKRight);
            tryCatch.Error.Should().BeNull();
        }

        [Test]
        public void Try_Fail()
        {
            var tryCatch = Test.NewTNotDone.Try(_ => Test.RaiseException<KType>());

            tryCatch.IsSuccessful.Should().BeFalse();
            tryCatch.Subject.Should().BeEquivalentTo(Test.NewTNotDone);
            tryCatch.Result.Should().BeNull();
            tryCatch.Error.Should().NotBeNull();
        }

        [Test]
        public void TryOnError_Success()
        {
            var tryCatch = Test.NewTNotDone.Try(_ => Test.NewKRight, (s, e) => string.Concat(s.TDesc, "_", e.Message));

            tryCatch.Result.Should().BeEquivalentTo(Test.NewKRight);
            tryCatch.Error.Should().BeNull();
            tryCatch.Subject.Should().BeEquivalentTo(Test.NewTNotDone);
        }

        [Test]
        public void TryOnError_Fail()
        {
            var tryCatch = Test.NewTNotDone.Try(_ => Test.RaiseException<KType>(),
                                             (s, e) => string.Concat(s.TDesc, "_", e.Message));

            tryCatch.Result.Should().BeNull();
            tryCatch.Error.Should().StartWith(Test.NewTNotDone.TDesc + "_Exception");
            tryCatch.Subject.Should().BeEquivalentTo(Test.NewTNotDone);
        }

        [Test]
        public void TryTo_Success()
        {
            var result = Test.NewTNotDone.TryTo(_ => Test.RIGHT, (s, e) => Test.LEFT);
            result.Should().Be(Test.RIGHT);
        }

        [Test]
        public void TryTo_Fail()
        {
            var result = Test.NewTNotDone.TryTo(_ => Test.RaiseException<string>(), (s, e) => Test.LEFT);
            result.Should().Be(Test.LEFT);
        }
    }
}