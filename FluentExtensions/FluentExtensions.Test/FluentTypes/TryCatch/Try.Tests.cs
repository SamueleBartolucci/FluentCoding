using FluentAssertions;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace FluentCoding.Test.FluentTypes.TryCatch
{
    [ExcludeFromCodeCoverage]
    public class Try_Tests
    {

        [Test]
        public void Try_Action_Success()
        {
            var parsed = new List<int>();
            var tryCatch = "0".Try(_ => parsed.Add(int.Parse(_)));

            tryCatch.IsSuccessful.Should().BeTrue();
            parsed.Count.Should().Be(1);
            parsed.First().Should().Be(0);
        }

        [Test]
        public void Try_Action_Success2()
        {
            var parsed = new List<int>();
            var tryCatch = "0".Try(_ => parsed.Add(int.Parse(_)), (_, e) => e.Do(__ => parsed.Add(2)));

            tryCatch.IsSuccessful.Should().BeTrue();
            parsed.Count.Should().Be(1);
            parsed.First().Should().Be(0);
        }


        [Test]
        public void Try_Action_Failure()
        {
            var parsed = new List<int>();
            var tryCatch = "x".Try(_ => parsed.Add(int.Parse(_)));

            parsed.Count.Should().Be(0);

            tryCatch.IsSuccessful.Should().BeFalse();
            tryCatch.Error.Should().NotBeNull();
        }
        [Test]
        public void Try_Action_Failure2()
        {
            var parsed = new List<int>();
            var tryCatch = "x".Try(_ => parsed.Add(int.Parse(_)), 
                                  (_, e) => e.Do(__ => parsed.Add(2)));

            parsed.Count.Should().Be(1);
            parsed.First().Should().Be(2);

            tryCatch.IsSuccessful.Should().BeFalse();
            tryCatch.Error.Should().NotBeNull();
        }

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