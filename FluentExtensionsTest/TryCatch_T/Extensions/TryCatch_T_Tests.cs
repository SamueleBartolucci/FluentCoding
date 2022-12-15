using FluentAssertions;
using FluentCoding;

using NUnit.Framework.Internal;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest
{
    [ExcludeFromCodeCoverage]
    public class TryCatch_T_Tests
    {

        [Test]
        public void Try_Success()
        {
            var tryCatch = Test.TNotDone.Try(_ => Test.KRight);

            tryCatch.IsSuccesful.Should().BeTrue();
            tryCatch.Subject.Should().BeEquivalentTo(Test.TNotDone);
            tryCatch.Result.Should().BeEquivalentTo(Test.KRight);
            tryCatch.Error.Should().BeNull();
        }

        [Test]
        public void Try_Fail()
        {
            var tryCatch = Test.TNotDone.Try(_ => Test.GetDefault<TypeK>().DescType.Do(_ => "never reach this"));

            tryCatch.IsSuccesful.Should().BeFalse();
            tryCatch.Subject.Should().BeEquivalentTo(Test.TNotDone);
            tryCatch.Result.Should().BeNull();
            tryCatch.Error.Should().NotBeNull();
        }

        [Test]
        public void TryOnError_Success()
        {
            var tryCatch = Test.TNotDone.Try(_ => Test.KRight, (s, e) => string.Concat(s.DescType, "_", e.Message));

            tryCatch.Result.Should().BeEquivalentTo(Test.KRight);
            tryCatch.Error.Should().BeNull();
            tryCatch.Subject.Should().BeEquivalentTo(Test.TNotDone);
        }

        [Test]
        public void TryOnError_Fail()
        {
            var tryCatch = Test.TNotDone.Try(_ => Test.GetDefault<TypeK>().DescType.Do(_ => "never reach this"), 
                                             (s, e) => string.Concat(s.DescType, "_", e.Message));

            tryCatch.Result.Should().BeNull();
            tryCatch.Error.Should().StartWith(Test.TNotDone.DescType + "_Object");
            tryCatch.Subject.Should().BeEquivalentTo(Test.TNotDone);
        }

        [Test]
        public void TryWrap_Success()
        {
            var result = Test.TNotDone.TryWrap(_ => Test.Right, (s, e) => Test.Left);
            result.Should().Be(Test.Right);
        }

        [Test]
        public void TryWrap_Fail()
        {
            var result = Test.TNotDone.TryWrap(_ => Test.GetDefault<TypeK>().DescType.Do(_ => "never reach this"), (s, e) => Test.Left);
            result.Should().Be(Test.Left);
        }
    }
}