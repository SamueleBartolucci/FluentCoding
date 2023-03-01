using FluentAssertions;
using FluentCoding;

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
            var tryCatch = Test.NewTNotDone.Try(_ => Test.NewKRight);
            var then = tryCatch.OnSuccess(_ => _.Do(_ => _.KDesc = Test.DONE));
            then.Success.Should().BeEquivalentTo(Test.NewKDone);
            then.TryCatch.Should().BeSameAs(tryCatch);
        }

        [Test]
        public void TryCatch_Fail_OnSuccess()
        {
            var tryCatch = Test.NewTNotDone.Try(_ => Test.RaiseException<KType>());
            var then = tryCatch.OnSuccess(_ => _.Do(_ => _.KDesc = Test.DONE));

            then.Success.Should().BeNull();
            then.TryCatch.Should().BeSameAs(tryCatch);
        }


        [Test]
        public void TryCatch_Success_OnFail()
        {
            var tryCatch = Test.NewTNotDone.Try(_ => Test.NewKRight);
            var then = tryCatch.OnFail((s, e) => e);
            then.Fail.Should().BeNull();
            then.TryCatch.Should().BeSameAs(tryCatch);
        }


        [Test]
        public void TryCatch_Fail_OnFail()
        {
            var tryCatch = Test.NewTNotDone.Try(_ => Test.RaiseException<KType>());
            var then = tryCatch.OnFail((s, e) => e);

            then.Fail.Should().BeOfType<Exception>();
            then.TryCatch.Should().BeSameAs(tryCatch);
        }

    }
}