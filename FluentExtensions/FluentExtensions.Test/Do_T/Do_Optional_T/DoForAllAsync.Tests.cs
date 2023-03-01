using FluentAssertions;
using FluentCoding;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace FluentCodingTest.Do_T
{
    [ExcludeFromCodeCoverage]
    public class DoForEachAsync_Optional_Tests
    {

        private TypeT UpdateDesc(TypeT t, string newDesc)
        {
            t.DescType = newDesc;
            return t;
        }

        private TypeT MergeDesc(TypeT t, string newDescPart)
        {
            t.DescType += newDescPart;
            return t;
        }


        [Test]
        public void DoForEachAsync_Action()
        {
            IEnumerable<TypeT> original = new[] { Test.T, Test.T, Test.T, Test.T };
            
            var postDo = original.ToTask().DoForEachAsync(_ => _.DescType = Test.Done).Result;
            postDo.Should().HaveCount(4);
            postDo.Should().AllSatisfy(_ => _.Should().BeEquivalentTo(Test.TDone));
            original.Should().AllSatisfy(_ => _.Should().BeEquivalentTo(Test.TDone));
        }

        [Test]
        public void DoForEachAsync_Actions()
        {
            IEnumerable<TypeT> original = new[] { Test.T, Test.T, Test.T, Test.T };
            
            var postDo = original.ToTask().DoForEachAsync(_ => _.DescType = Test.Done,
                                                         _ => _.DescType += "." )
                                          .Result;
            postDo.Should().HaveCount(4);
            postDo.Should().AllSatisfy(_ => _.DescType.Should().Be(Test.TDone.DescType+"."));
            original.Should().AllSatisfy(_ => _.DescType.Should().Be(Test.TDone.DescType + "."));
        }


        [Test]
        public void DoForEachAsync_Func()
        {

            IEnumerable<TypeT> original = new[] { Test.T, Test.T, Test.T, Test.T };
            var postDo = original.ToTask().DoForEachAsync(_ => UpdateDesc(_, Test.Done)).Result;
            postDo.Should().HaveCount(4);
            postDo.Should().AllSatisfy(_ => _.Should().BeEquivalentTo(Test.TDone));
            original.Should().AllSatisfy(_ => _.Should().BeEquivalentTo(Test.TDone));
        }


        [Test]
        public void DoForEachAsync_Funcs()
        {
            IEnumerable<TypeT> original = new[] { Test.T, Test.T, Test.T, Test.T };
            var postDo = original.ToTask().DoForEachAsync(_ => UpdateDesc(_, Test.Done),
                                                         _ => MergeDesc(_, "."))
                                           .Result;
            postDo.Should().HaveCount(4);
            postDo.Should().AllSatisfy(_ => _.DescType.Should().BeEquivalentTo(Test.Done + "."));
            original.Should().AllSatisfy(_ => _.DescType.Should().BeEquivalentTo(Test.Done + "."));
        }

    }
}