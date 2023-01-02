using FluentAssertions;
using FluentCoding;
using FluentCoding.Try;
using FluentCodingTest;
using NUnit.Framework.Internal;
using System;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.TryCatch_T
{
    [ExcludeFromCodeCoverage]
    public class TryCatch_OnSuccess_OnFail_Tests
    {

        [Test]
        public void TryCatch_Success_OnSuccess()
        {
            var tryCatch = Test.TNotDone.Try(_ => Test.KRight);
            var then = tryCatch.OnSuccess(_ => _.Do(_ => _.DescType = Test.Done));
            then.Success.Should().BeEquivalentTo(Test.KDone);
            then.TryCatch.Should().BeSameAs(tryCatch);
        }

        [Test]
        public void TryCatch_Fail_OnSuccess()
        {
            var tryCatch = Test.TNotDone.Try(_ => Test.GetException<TypeK>());
            var then = tryCatch.OnSuccess(_ => _.Do(_ => _.DescType = Test.Done));

            then.Success.Should().BeNull();
            then.TryCatch.Should().BeSameAs(tryCatch);
        }


        [Test]
        public void TryCatch_Success_OnFail()
        {
            var tryCatch = Test.TNotDone.Try(_ => Test.KRight);
            var then = tryCatch.OnFail((s, e) => e);
            then.Fail.Should().BeNull();
            then.TryCatch.Should().BeSameAs(tryCatch);
        }


        [Test]
        public void TryCatch_Fail_OnFail()
        {
            var tryCatch = Test.TNotDone.Try(_ => Test.GetException<TypeK>());
            var then = tryCatch.OnFail((s, e) => e);

            then.Fail.Should().BeOfType<Exception>();
            then.TryCatch.Should().BeSameAs(tryCatch);
        }

    }
}