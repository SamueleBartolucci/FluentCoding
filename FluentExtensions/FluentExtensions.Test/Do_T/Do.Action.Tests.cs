using FluentAssertions;
using FluentCoding;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace FluentCodingTest.Do_T
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
            TypeT preDo = null;
            var postDo = preDo.Do(_ => _.DescType = Test.Done);
            postDo.Should().Be(null);
        }

        [Test]
        public void Do_Action_SubjectField()
        {
            var preDo = Test.T;
            var postDo = preDo.Do(_ => _.DescType = Test.Done);
            postDo.DescType.Should().Be(Test.Done);
            postDo.Should().BeEquivalentTo(Test.TDone);            
            preDo.Should().BeSameAs(postDo);
        }

        [Test]
        public void Do_Actions_SubjectField()
        {
            var preDo = Test.T;
            var postDo = preDo.Do(_ => _.DescType = ".",
                                  _ => _.DescType += ".",
                                  _ => _.DescType += ".",
                                  _ => _.DescType += ".");
            postDo.DescType.Should().Be("....");            
            preDo.Should().BeSameAs(postDo);
        }


        [Test]
        public void Do_Actions_NewObject()
        {
            string preDo = "notDone";
            List<string> output = new List<string>();
            var postDo = preDo.Do(_ => output.Add(_ +"1"),
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