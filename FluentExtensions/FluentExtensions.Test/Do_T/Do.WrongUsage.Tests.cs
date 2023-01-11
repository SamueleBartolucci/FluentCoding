using FluentAssertions;
using FluentCoding;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace FluentCodingTest.Do_T
{
    [ExcludeFromCodeCoverage]
    public class Do_WrongUsage_Tests
    {
        private void MergeAction(string string1, string string2)
        {
            string1 = string1 + string2;
        }


        [Test]
        public void Do_Action_ValueType_FromObject()
        {
            var preDo = Test.TNotDone;
            var postDo = preDo.DescType.Do(_ => MergeAction(_, Test.Done));
            postDo.Should().NotBe(Test.NotDone + Test.Done);
            postDo.Should().Be(Test.TNotDone.DescType);
            preDo.Should().BeEquivalentTo(Test.TNotDone);            
        }


        [Test]
        public void Do_Action_StringEmpty()
        {
            string preDo = string.Empty;
            var postDo = preDo.Do(_ => MergeAction(_, Test.Done));
            postDo.Should().Be(string.Empty);

        }
        [Test]
        public void Do_Action_String()
        {
            string preDo = "notDone";
            var postDo = preDo.Do(_ => MergeAction(_, Test.Done));
            postDo.Should().Be(preDo);
        }

        [Test]
        public void Do_Func_NewObject_Unchanged()
        {
            TypeT preDo = Test.T;
            var postDo = preDo.Do(_ => new TypeT() { DescType = Test.Done });
            postDo.DescType.Should().Be(Test.T.DescType);
            preDo.Should().BeSameAs(postDo);
        }


        [Test]
        public void Do_Func_StringEmpty()
        {
            string preDo = string.Empty;
            var postDo = preDo.Do(_ => Test.Done);
            postDo.Should().BeSameAs(preDo);
            postDo.Should().Be(string.Empty);

        }

        [Test]
        public void Do_Func_String()
        {
            string preDo = Test.NotDone;
            var postDo = preDo.Do((_) => Test.Done);
            postDo.Should().BeSameAs(preDo);
            postDo.Should().Be(Test.NotDone);
        }


        [Test]
        public void Do_Func_Enum()
        {
            var preDo = TestEnum.Enum1;
            var postDo = preDo.Do(_ => TestEnum.Enum2);
            postDo.Should().Be(TestEnum.Enum1);
            preDo.Should().Be(postDo);
        }

    }
}