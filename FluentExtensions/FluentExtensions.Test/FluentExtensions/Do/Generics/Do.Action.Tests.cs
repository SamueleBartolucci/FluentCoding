using FluentAssertions;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace FluentCoding.Test.FluentExtensions.Do.Generics
{
    [ExcludeFromCodeCoverage]
    public class Do_Action_Tests
    {
        [Test]
        public void DoWrap_Action_ValueType()
        {
            int startValue = 1;
            var postDo = startValue.DoWrap(_ => _.Subject++);
            postDo.Should().Be(2);
        }

        [Test]
        public void Do_Action_ValueType()
        {
            int startValue = 1;
            var postDo = startValue.Do(_ => _++);
            postDo.Should().Be(1);
        }

        [Test]
        public void Do_Action_Null()
        {
            TType preDo = null;
            var postDo = preDo.Do(_ => _.TDesc = Test.DONE);
            postDo.Should().Be(null);
        }

        [Test]
        public void Do_Action_SubjectField()
        {
            var preDo = Test.NewT;
            var postDo = preDo.Do(_ => _.TDesc = Test.DONE);
            postDo.TDesc.Should().Be(Test.DONE);
            postDo.Should().BeEquivalentTo(Test.NewTDone);
            preDo.Should().BeSameAs(postDo);
        }

        [Test]
        public void Do_Actions_SubjectField()
        {
            var preDo = Test.NewT;
            var postDo = preDo.Do(_ => _.TDesc = ".",
                                  _ => _.TDesc += ".",
                                  _ => _.TDesc += ".",
                                  _ => _.TDesc += ".");
            postDo.TDesc.Should().Be("....");
            preDo.Should().BeSameAs(postDo);
        }


        [Test]
        public void Do_Actions_NewObject()
        {
            string preDo = "notDone";
            List<string> output = new List<string>();
            var postDo = preDo.Do(_ => output.Add(_ + "1"),
                                  _ => output.Add(_ + "2"),
                                  _ => output.Add(_ + "3"));

            postDo.Should().Be(preDo);
            output.Should().HaveCount(3);
            output[0].Should().Be(preDo + "1");
            output[1].Should().Be(preDo + "2");
            output[2].Should().Be(preDo + "3");
        }
    }
}