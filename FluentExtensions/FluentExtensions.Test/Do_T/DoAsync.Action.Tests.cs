using FluentAssertions;
using FluentCoding;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace FluentCodingTest.DoAsync_T
{
    [ExcludeFromCodeCoverage]
    public class DoAsync_Action_Tests
    {
        [Test]
        public void DoWrapAsync_Action_ValueType()
        {
            int startValue = 1;
            var postDo = startValue
                            .ToTask()
                            .DoWrapAsync(_ => _.Subject++)
                            .Result;

            startValue.Should().Be(2);
            postDo.Should().Be(2);
        }

        [Test]
        public void DoAsync_Action_ValueType()
        {
            int startValue = 1;
            var postDo = startValue
                            .ToTask()
                            .DoAsync(_ => _++)
                            .Result;
            postDo.Should().Be(1);
        }

        [Test]
        public void DoAsync_Action_Null()
        {
            TypeT preDo = null;
            var postDo = preDo.ToTask().DoAsync(_ => _.DescType = Test.Done).Result;
            postDo.Should().Be(null);
        }

        [Test]
        public void DoAsync_Action_SubjectField()
        {
            var preDo = Test.T;
            var postDo = preDo.ToTask().DoAsync(_ => _.DescType = Test.Done).Result;
            postDo.DescType.Should().Be(Test.Done);
            postDo.Should().BeEquivalentTo(Test.TDone);            
            preDo.Should().BeSameAs(postDo);
        }

        [Test]
        public void DoAsync_Actions_SubjectField()
        {
            var preDo = Test.T;
            var postDo = preDo.ToTask().DoAsync(_ => _.DescType = ".",
                                                  _ => _.DescType += ".",
                                                  _ => _.DescType += ".",
                                                  _ => _.DescType += ".")
                                        .Result;
            postDo.DescType.Should().Be("....");            
            preDo.Should().BeSameAs(postDo);
        }


        [Test]
        public void DoAsync_Actions_NewObject()
        {
            string preDo = "notDone";
            List<string> output = new List<string>();
            var postDo = preDo.ToTask().DoAsync(_ => output.Add(_ +"1"),
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