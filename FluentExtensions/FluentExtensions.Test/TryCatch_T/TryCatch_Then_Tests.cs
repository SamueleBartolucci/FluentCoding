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
            var then = Test.TNotDone.Try(_ => Test.KRight).Then(_ => _.Do(_ => _.DescType = Test.Done), (s, e) => e.Message);
            then.Success.Should().BeEquivalentTo(Test.KDone);
            then.Fail.Should().BeNull();
        }

        [Test]
        public void TryCatch_Fail_Then()
        {
            var then = Test.TNotDone.Try(_ => Test.GetException<TypeK>()).Then(_ => _.DescType, (s, e) => e);
            then.Success.Should().BeNull();
            then.Fail.Should().BeOfType<Exception>();
        }


        [Test]
        public void TryCatch_Success_ThenMap()
        {
            var then = Test.TNotDone.Try(_ => Test.KRight)
                .ThenMap(_ => Test.Done, (s, e) => Test.NotDone)
                .Should().Be(Test.Done);
        }

        [Test]
        public void TryCatch_Fail_ThenMap()
        {
            var then = Test.TNotDone.Try(_ => Test.GetException<TypeK>())
                .ThenMap(_ => Test.Done, (s, e) => Test.NotDone)
                .Should().Be(Test.NotDone);
        }

    }
}