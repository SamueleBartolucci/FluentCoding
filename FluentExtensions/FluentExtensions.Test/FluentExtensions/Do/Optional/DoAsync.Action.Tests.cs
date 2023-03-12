using FluentAssertions;
using FluentCoding;

using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace FluentCoding.Test.FluentExtensions.Do.Optional
{
    [ExcludeFromCodeCoverage]
    public class DoAsync_Optional_Action_Tests
    {

        [Test]
        public void DoAsync_Action_ValueType()
        {
            var startValue = 1.ToOptional();
            var postDo = startValue
                            .ToTask()
                            .DoOptnAsync(_ => _++)
                            .Result;

            postDo.Subject.Should().Be(1);
        }

        [Test]
        public void DoAsync_Action_Null()
        {
            TType preDo = null;
            var postDo = preDo.ToOptional().ToTask().DoOptnAsync(_ => _.TDesc = Test.DONE).Result;
            postDo.IsNone().Should().BeTrue();
            postDo.Subject.Should().Be(null);
        }

        [Test]
        public void DoAsync_Action_SubjectField()
        {
            var preDo = Test.NewT.ToOptional();
            var postDo = preDo.ToTask().DoOptnAsync(_ => _.TDesc = Test.DONE).Result;
            postDo.Subject.TDesc.Should().Be(Test.DONE);
            postDo.Subject.Should().BeEquivalentTo(Test.NewTDone);
            preDo.Should().BeSameAs(postDo);
        }

        [Test]
        public void DoAsync_Actions_SubjectField()
        {
            var preDo = Test.NewT.ToOptional();
            var postDo = preDo.ToTask().DoOptnAsync(_ => _.TDesc = ".",
                                                  _ => _.TDesc += ".",
                                                  _ => _.TDesc += ".",
                                                  _ => _.TDesc += ".")
                                        .Result;
            postDo.Subject.TDesc.Should().Be("....");
            preDo.Should().BeSameAs(postDo);
        }


        [Test]
        public void DoAsync_Actions_NewObject()
        {
            string preDo = "notDone";
            List<string> output = new List<string>();
            var postDo = preDo.ToTask().DoAsync(_ => output.Add(_ + "1"),
                                  _ => output.Add(_ + "2"),
                                  _ => output.Add(_ + "3"))
                                 .Result;

            postDo.Should().Be(preDo);
            output.Should().HaveCount(3);
            output[0].Should().Be(preDo + "1");
            output[1].Should().Be(preDo + "2");
            output[2].Should().Be(preDo + "3");
        }
    }
}