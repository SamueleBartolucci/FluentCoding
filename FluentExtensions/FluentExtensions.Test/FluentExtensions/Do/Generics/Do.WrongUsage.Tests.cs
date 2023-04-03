using FluentAssertions;
using System.Diagnostics.CodeAnalysis;

namespace FluentCoding.Test.FluentExtensions.Do.Generics
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
            var preDo = Test.NewTNotDone;
            var postDo = preDo.TDesc.Do(_ => MergeAction(_, Test.DONE));
            postDo.Should().NotBe(Test.NOT_DONE + Test.DONE);
            postDo.Should().Be(Test.NewTNotDone.TDesc);
            preDo.Should().BeEquivalentTo(Test.NewTNotDone);
        }


        [Test]
        public void Do_Action_StringEmpty()
        {
            string preDo = string.Empty;
            var postDo = preDo.Do(_ => MergeAction(_, Test.DONE));
            postDo.Should().Be(string.Empty);

        }
        [Test]
        public void Do_Action_String()
        {
            string preDo = "notDone";
            var postDo = preDo.Do(_ => MergeAction(_, Test.DONE));
            postDo.Should().Be(preDo);
        }

        [Test]
        public void Do_Func_NewObject_Unchanged()
        {
            TType preDo = Test.NewT;
            var postDo = preDo.Do(_ => new TType() { TDesc = Test.DONE });
            postDo.TDesc.Should().Be(Test.NewT.TDesc);
            preDo.Should().BeSameAs(postDo);
        }


        [Test]
        public void Do_Func_StringEmpty()
        {
            string preDo = string.Empty;
            var postDo = preDo.Do(_ => Test.DONE);
            postDo.Should().BeSameAs(preDo);
            postDo.Should().Be(string.Empty);

        }

        [Test]
        public void Do_Func_String()
        {
            string preDo = Test.NOT_DONE;
            var postDo = preDo.Do((_) => Test.DONE);
            postDo.Should().BeSameAs(preDo);
            postDo.Should().Be(Test.NOT_DONE);
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