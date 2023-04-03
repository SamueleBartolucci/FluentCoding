using FluentAssertions;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace FluentCoding.Test.FluentExtensions.Do.Optional
{
    [ExcludeFromCodeCoverage]
    public class Do_Optional_Action_Tests
    {
        [Test]
        public void DoOptn_Action_ValueType()
        {
            int startValue = 1;
            var postDo = startValue.ToOptional().DoOptn(_ => _++);
            postDo.Subject.Should().Be(1);
            postDo.IsSome().Should().BeTrue();
        }

        [Test]
        public void DoOptn_Action_Null()
        {
            var preDo = ((TType)null).ToOptional();
            var postDo = preDo.DoOptn(_ => _.TDesc = Test.DONE);
            postDo.Subject.Should().Be(null);
            postDo.IsSome().Should().BeFalse();
            postDo.IsNone().Should().BeTrue();
        }

        [Test]
        public void DoOptn_Action_SubjectField()
        {
            var preDo = Test.NewT.ToOptional();
            var postDo = preDo.DoOptn(_ => _.TDesc = Test.DONE);
            postDo.Subject.TDesc.Should().Be(Test.DONE);
            postDo.Subject.Should().BeEquivalentTo(Test.NewTDone);
            preDo.Should().BeSameAs(postDo);
            postDo.IsSome().Should().BeTrue();
        }

        [Test]
        public void DoOptn_Actions_SubjectField()
        {
            var preDo = Test.NewT.ToOptional();
            var postDo = preDo.DoOptn(_ => _.TDesc = ".",
                                  _ => _.TDesc += ".",
                                  _ => _.TDesc += ".",
                                  _ => _.TDesc += ".");
            postDo.Subject.TDesc.Should().Be("....");
            preDo.Should().BeSameAs(postDo);
            postDo.IsSome().Should().BeTrue();
        }

        private Optional<string> Testino(Optional<string> t) => t;

        [Test]
        public void DoOptn_Actions_NewObject()
        {
            Optional<string> preDo = Optional<string>.Some("notDone");
            List<string> output = new List<string>();

            var postDo = preDo.DoOptn(_ => output.Add(_ + "1"),
                                  _ => output.Add(_ + "2"),
                                  _ => output.Add(_ + "3"));

            postDo.Subject.Should().Be(preDo.Subject);
            output.Should().HaveCount(3);
            output[0].Should().Be(preDo.Subject + "1");
            output[1].Should().Be(preDo.Subject + "2");
            output[2].Should().Be(preDo.Subject + "3");
            postDo.IsSome().Should().BeTrue();
        }

        [Test]
        public void DoOptn_Actions_None()
        {
            Optional<string> preDo = Optional<string>.None();
            List<string> output = new List<string>();

            var postDo = preDo.DoOptn(_ => output.Add(_ + "1"),
                                  _ => output.Add(_ + "2"),
                                  _ => output.Add(_ + "3"));

            postDo.IsNone().Should().BeTrue();
            postDo.IsSome().Should().BeFalse();
            postDo.Subject.Should().BeNull();

        }

        [Test]
        public void DoOptn_Actions_Null()
        {
            Optional<string> preDo = Test.GetDefault<Optional<string>>();
            List<string> output = new List<string>();

            var postDo = preDo.DoOptn(_ => output.Add(_ + "1"),
                                  _ => output.Add(_ + "2"),
                                  _ => output.Add(_ + "3"));

            postDo.IsNone().Should().BeTrue();
            postDo.IsSome().Should().BeFalse();
            postDo.Subject.Should().BeNull();
        }
    }
}