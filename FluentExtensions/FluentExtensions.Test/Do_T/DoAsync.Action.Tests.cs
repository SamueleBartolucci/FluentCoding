using FluentAssertions;
using FluentCoding;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace FluentCodingTest.Do_T
{
    [ExcludeFromCodeCoverage]
    public class DoAsync_Action_Tests
    {
        private void MergeAction(string string1, string string2)
        {
            string1 = string1 + string2;
        }


        [Test]
        public void Do_Action_ObjectField()
        {
            var preDo = Test.T.ToTask();
            var taskPostDo = preDo.DoAsync(_ => _.DescType = Test.Done);
            taskPostDo.Should().BeOfType(typeof(Task<TypeT>));
            var postDo = taskPostDo.Result;
            postDo.DescType.Should().Be(Test.Done);
            postDo.Should().BeEquivalentTo(Test.TDone);            
            preDo.Result.Should().BeSameAs(postDo);
        }

        [Test]
        public void Do_Action_Null()
        {
            var preDo = (Test.GetDefault<TypeT>()).ToTask();
            var postDo = preDo.DoAsync(_ => _.DescType = Test.Done).Result;
            postDo.Should().Be(null);
        }

        [Test]
        public void Do_Action_StringEmpty()
        {
            var preDo = string.Empty.ToTask();
            var postDo = preDo.DoAsync(_ => MergeAction(_, Test.Done)).Result;
            postDo.Should().Be(string.Empty);

        }
        [Test]
        public void Do_Action_String()
        {
            var preDo = "notDone".ToTask();
            var postDo = preDo.DoAsync(_ => MergeAction(_, Test.Done)).Result;
            postDo.Should().Be(preDo.Result);            
        }

        [Test]
        public void Do_Actions()
        {
            var preDo = "notDone".ToTask();
            List<string> output = new List<string>();
            var postDo = preDo.DoAsync(_ => output.Add(_ +"1"),
                                       _ => output.Add(_ + "2"),
                                       _ => output.Add(_ + "3"))
                .Result;

            postDo.Should().Be(preDo.Result);
            output.Should().HaveCount(3);
            output[0].Should().Be(preDo.Result + "1");
            output[1].Should().Be(preDo.Result + "2");
            output[2].Should().Be(preDo.Result + "3");
        }




    }
}