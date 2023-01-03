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
        public void Do_Action_ObjectField()
        {
            var preDo = Test.T;
            var postDo = preDo.Do(_ => _.DescType = Test.Done);
            postDo.DescType.Should().Be(Test.Done);
            postDo.Should().BeEquivalentTo(Test.TDone);            
            preDo.Should().BeSameAs(postDo);
        }

        private void MergeAction(string string1, string string2)
        {
            string1 = string1 + string2;
        }

        [Test]
        public void Do_Action_ObjectFieldValue()
        {
            var preDo = Test.TNotDone;
            var postDo = preDo.DescType.Do(_ => MergeAction(_, Test.Done));
            postDo.Should().NotBe(Test.NotDone+Test.Done);
            preDo.DescType.Should().BeEquivalentTo(postDo);
        }

        [Test]
        public void Do_Action_Null()
        {
            TypeT preDo = null;
            var postDo = preDo.Do(_ => _.DescType = Test.Done);
            postDo.Should().Be(null);
        }

        [Test]
        public void Do_Action_StringEmpty()
        {
            string preDo = string.Empty;
            var postDo = preDo.Do(_ => _.Concat(Test.Done));
            postDo.Should().Be(string.Empty);

        }
        [Test]
        public void Do_Action_String()
        {
            string preDo = "notDone";
            var postDo = preDo.Do(_ => _.Concat(Test.Done));
            postDo.Should().Be(preDo);            
        }

        [Test]
        public void Do_Actions()
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