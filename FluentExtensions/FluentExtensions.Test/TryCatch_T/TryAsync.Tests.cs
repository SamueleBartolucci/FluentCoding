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
            var tryCatch = Test.TNotDone.ToTask().TryAsync(_ => Test.KRight).Result;

            tryCatch.IsSuccesful.Should().BeTrue();
            tryCatch.Subject.Should().BeEquivalentTo(Test.TNotDone);
            tryCatch.Result.Should().BeEquivalentTo(Test.KRight);
            tryCatch.Error.Should().BeNull();
        }

        [Test]
        public void TryAsync_Fail()
        {
            var tryCatch = Test.TNotDone.ToTask().TryAsync(_ => Test.GetException<TypeK>()).Result;

            tryCatch.IsSuccesful.Should().BeFalse();
            tryCatch.Subject.Should().BeEquivalentTo(Test.TNotDone);
            tryCatch.Result.Should().BeNull();
            tryCatch.Error.Should().NotBeNull();
        }

        [Test]
        public void TryOnError_Success()
        {
            var tryCatch = Test.TNotDone.ToTask().TryAsync(_ => Test.KRight, (s, e) => string.Concat(s.DescType, "_", e.Message)).Result;

            tryCatch.Result.Should().BeEquivalentTo(Test.KRight);
            tryCatch.Error.Should().BeNull();
            tryCatch.Subject.Should().BeEquivalentTo(Test.TNotDone);
        }

        [Test]
        public void TryOnError_Fail()
        {
            var tryCatch = Test.TNotDone.ToTask().TryAsync(_ => Test.GetException<TypeK>(),
                                             (s, e) => string.Concat(s.DescType, "_", e.Message)).Result;

            tryCatch.Result.Should().BeNull();
            tryCatch.Error.Should().StartWith(Test.TNotDone.DescType + "_Exception");
            tryCatch.Subject.Should().BeEquivalentTo(Test.TNotDone);
        }

        [Test]
        public void TryTo_Success()
        {
            var result = Test.TNotDone.ToTask().TryToAsync(_ => Test.Right, (s, e) => Test.Left).Result;
            result.Should().Be(Test.Right);
        }

        [Test]
        public void TryTo_Fail()
        {
            var result = Test.TNotDone.ToTask().TryToAsync(_ => Test.GetException<string>(), (s, e) => Test.Left).Result;
            result.Should().Be(Test.Left);
        }
    }
}