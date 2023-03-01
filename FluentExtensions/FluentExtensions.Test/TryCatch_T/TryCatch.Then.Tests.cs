using FluentAssertions;
using FluentCoding;

using FluentCodingTest;
using NUnit.Framework.Internal;
using System;
using System.Diagnostics.CodeAnalysis;


namespace FluentCodingTest.TryCatch_T
{
    [ExcludeFromCodeCoverage]
    public class TryCatch_Then_Tests
    {

        [Test]
        public void TryCatch_Success_Then()
        {
            var then = Test.NewTNotDone.Try(_ => Test.NewKRight).Then(_ => _.Do(_ => _.KDesc = Test.DONE), (s, e) => e.Message);
            then.Success.Should().BeEquivalentTo(Test.NewKDone);
            then.Fail.Should().BeNull();
        }

        [Test]
        public void TryCatch_Fail_Then()
        {
            var then = Test.NewTNotDone.Try(_ => Test.RaiseException<KType>()).Then(_ => _.KDesc, (s, e) => e);
            then.Success.Should().BeNull();
            then.Fail.Should().BeOfType<Exception>();
        }


        [Test]
        public void TryCatch_Success_ThenMap()
        {
            var then = Test.NewTNotDone.Try(_ => Test.NewKRight)
                .ThenMap(_ => Test.DONE, (s, e) => Test.NOT_DONE)
                .Should().Be(Test.DONE);
        }

        [Test]
        public void TryCatch_Fail_ThenMap()
        {
            var then = Test.NewTNotDone.Try(_ => Test.RaiseException<KType>())
                .ThenMap(_ => Test.DONE, (s, e) => Test.NOT_DONE)
                .Should().Be(Test.NOT_DONE);
        }

    }
}