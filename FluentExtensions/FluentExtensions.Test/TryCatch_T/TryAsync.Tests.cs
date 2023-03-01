using FluentAssertions;
using FluentCoding;
using FluentCodingTest;
using NUnit.Framework.Internal;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.TryCatch_T
{
    [ExcludeFromCodeCoverage]
    public class TryAsync_Tests
    {

        [Test]
        public void TryAsync_Success()
        {
            var tryCatch = Test.NewTNotDone.ToTask().TryAsync(_ => Test.NewKRight).Result;

            tryCatch.IsSuccessful.Should().BeTrue();
            tryCatch.Subject.Should().BeEquivalentTo(Test.NewTNotDone);
            tryCatch.Result.Should().BeEquivalentTo(Test.NewKRight);
            tryCatch.Error.Should().BeNull();
        }

        [Test]
        public void TryAsync_Fail()
        {
            var tryCatch = Test.NewTNotDone.ToTask().TryAsync(_ => Test.RaiseException<KType>()).Result;

            tryCatch.IsSuccessful.Should().BeFalse();
            tryCatch.Subject.Should().BeEquivalentTo(Test.NewTNotDone);
            tryCatch.Result.Should().BeNull();
            tryCatch.Error.Should().NotBeNull();
        }

        [Test]
        public void TryOnError_Success()
        {
            var tryCatch = Test.NewTNotDone.ToTask().TryAsync(_ => Test.NewKRight, (s, e) => string.Concat(s.TDesc, "_", e.Message)).Result;

            tryCatch.Result.Should().BeEquivalentTo(Test.NewKRight);
            tryCatch.Error.Should().BeNull();
            tryCatch.Subject.Should().BeEquivalentTo(Test.NewTNotDone);
        }

        [Test]
        public void TryOnError_Fail()
        {
            var tryCatch = Test.NewTNotDone.ToTask().TryAsync(_ => Test.RaiseException<KType>(),
                                             (s, e) => string.Concat(s.TDesc, "_", e.Message)).Result;

            tryCatch.Result.Should().BeNull();
            tryCatch.Error.Should().StartWith(Test.NewTNotDone.TDesc + "_Exception");
            tryCatch.Subject.Should().BeEquivalentTo(Test.NewTNotDone);
        }

        [Test]
        public void TryTo_Success()
        {
            var result = Test.NewTNotDone.ToTask().TryToAsync(_ => Test.RIGHT, (s, e) => Test.LEFT).Result;
            result.Should().Be(Test.RIGHT);
        }

        [Test]
        public void TryTo_Fail()
        {
            var result = Test.NewTNotDone.ToTask().TryToAsync(_ => Test.RaiseException<string>(), (s, e) => Test.LEFT).Result;
            result.Should().Be(Test.LEFT);
        }
    }
}