using FluentAssertions;
using System.Diagnostics.CodeAnalysis;

namespace FluentCoding.Test.FluentExtensions.Do.Generics
{
    [ExcludeFromCodeCoverage]
    public class DoForEach_Tests
    {

        private TType UpdateDesc(TType t, string newDesc)
        {
            t.TDesc = newDesc;
            return t;
        }

        private TType MergeDesc(TType t, string newDescPart)
        {
            t.TDesc += newDescPart;
            return t;
        }


        [Test]
        public void DoForEach_Action()
        {
            TType[] original = { Test.NewT, Test.NewT, Test.NewT, Test.NewT };

            var postDo = original.DoForEach(_ => _.TDesc = Test.DONE);
            postDo.Should().HaveCount(4);
            postDo.Should().AllSatisfy(_ => _.Should().BeEquivalentTo(Test.NewTDone));
            original.Should().AllSatisfy(_ => _.Should().BeEquivalentTo(Test.NewTDone));
        }

        [Test]
        public void DoForEach_Actions()
        {
            TType[] original = { Test.NewT, Test.NewT, Test.NewT, Test.NewT };

            var postDo = original.DoForEach(_ => _.TDesc = Test.DONE,
                                           _ => _.TDesc += ".");
            postDo.Should().HaveCount(4);
            postDo.Should().AllSatisfy(_ => _.TDesc.Should().Be(Test.NewTDone.TDesc + "."));
            original.Should().AllSatisfy(_ => _.TDesc.Should().Be(Test.NewTDone.TDesc + "."));
        }


        [Test]
        public void DoForEach_Func()
        {
            TType[] original = { Test.NewT, Test.NewT, Test.NewT, Test.NewT };
            var postDo = original.DoForEach(_ => UpdateDesc(_, Test.DONE));
            postDo.Should().HaveCount(4);
            postDo.Should().AllSatisfy(_ => _.Should().BeEquivalentTo(Test.NewTDone));
            original.Should().AllSatisfy(_ => _.Should().BeEquivalentTo(Test.NewTDone));
        }


        [Test]
        public void DoForEach_Funcs()
        {
            TType[] original = { Test.NewT, Test.NewT, Test.NewT, Test.NewT };
            var postDo = original.DoForEach(_ => UpdateDesc(_, Test.DONE),
                                           _ => MergeDesc(_, "."));
            postDo.Should().HaveCount(4);
            postDo.Should().AllSatisfy(_ => _.TDesc.Should().BeEquivalentTo(Test.DONE + "."));
            original.Should().AllSatisfy(_ => _.TDesc.Should().BeEquivalentTo(Test.DONE + "."));
        }

    }
}