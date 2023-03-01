using FluentAssertions;
using FluentCoding;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace FluentCodingTest.Do_T
{
    [ExcludeFromCodeCoverage]
    public class DoForEachAsync_Tests
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
        public void DoForEachAsync_Action()
        {
            IEnumerable<TType> original = new[] { Test.NewT, Test.NewT, Test.NewT, Test.NewT };
            
            var postDo = original.ToTask().DoForEachAsync(_ => _.TDesc = Test.DONE).Result;
            postDo.Should().HaveCount(4);
            postDo.Should().AllSatisfy(_ => _.Should().BeEquivalentTo(Test.NewTDone));
            original.Should().AllSatisfy(_ => _.Should().BeEquivalentTo(Test.NewTDone));
        }

        [Test]
        public void DoForEachAsync_Actions()
        {
            IEnumerable<TType> original = new[] { Test.NewT, Test.NewT, Test.NewT, Test.NewT };
            
            var postDo = original.ToTask().DoForEachAsync(_ => _.TDesc = Test.DONE,
                                                         _ => _.TDesc += "." )
                                          .Result;
            postDo.Should().HaveCount(4);
            postDo.Should().AllSatisfy(_ => _.TDesc.Should().Be(Test.NewTDone.TDesc+"."));
            original.Should().AllSatisfy(_ => _.TDesc.Should().Be(Test.NewTDone.TDesc + "."));
        }


        [Test]
        public void DoForEachAsync_Func()
        {

            IEnumerable<TType> original = new[] { Test.NewT, Test.NewT, Test.NewT, Test.NewT };
            var postDo = original.ToTask().DoForEachAsync(_ => UpdateDesc(_, Test.DONE)).Result;
            postDo.Should().HaveCount(4);
            postDo.Should().AllSatisfy(_ => _.Should().BeEquivalentTo(Test.NewTDone));
            original.Should().AllSatisfy(_ => _.Should().BeEquivalentTo(Test.NewTDone));
        }


        [Test]
        public void DoForEachAsync_Funcs()
        {
            IEnumerable<TType> original = new[] { Test.NewT, Test.NewT, Test.NewT, Test.NewT };
            var postDo = original.ToTask().DoForEachAsync(_ => UpdateDesc(_, Test.DONE),
                                                         _ => MergeDesc(_, "."))
                                           .Result;
            postDo.Should().HaveCount(4);
            postDo.Should().AllSatisfy(_ => _.TDesc.Should().BeEquivalentTo(Test.DONE + "."));
            original.Should().AllSatisfy(_ => _.TDesc.Should().BeEquivalentTo(Test.DONE + "."));
        }

    }
}