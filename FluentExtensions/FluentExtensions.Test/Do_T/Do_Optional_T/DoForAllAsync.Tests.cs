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
            IEnumerable<Optional<TType>> original = new[] { Test.NewT.ToOptional(), Test.NewT.ToOptional(), Test.NewT.ToOptional(), Test.NewT.ToOptional() };
            
            var postDo = original.ToTask().DoOptionalForEachAsync(_ => _.TDesc = Test.DONE).Result;
            postDo.Should().HaveCount(4);
            postDo.Should().AllSatisfy(_ => _.Subject.Should().BeEquivalentTo(Test.NewTDone));
            original.Should().AllSatisfy(_ => _.Subject.Should().BeEquivalentTo(Test.NewTDone));
        }

        [Test]
        public void DoForEachAsync_Actions()
        {
            IEnumerable<Optional<TType>> original = new[] { Test.NewT.ToOptional(), Test.NewT.ToOptional(), Test.NewT.ToOptional(), Test.NewT.ToOptional() };

            var postDo = original.ToTask().DoOptionalForEachAsync(_ => _.TDesc = Test.DONE,
                                                         _ => _.TDesc += "." )
                                          .Result;
            postDo.Should().HaveCount(4);
            postDo.Should().AllSatisfy(_ => _.Subject.TDesc.Should().Be(Test.NewTDone.TDesc+"."));
            original.Should().AllSatisfy(_ => _.Subject.TDesc.Should().Be(Test.NewTDone.TDesc + "."));
        }


        [Test]
        public void DoForEachAsync_Func()
        {

            IEnumerable<Optional<TType>> original = new[] { Test.NewT.ToOptional(), Test.NewT.ToOptional(), Test.NewT.ToOptional(), Test.NewT.ToOptional() };
            var postDo = original.ToTask().DoOptionalForEachAsync(_ => UpdateDesc(_, Test.DONE)).Result;
            postDo.Should().HaveCount(4);
            postDo.Should().AllSatisfy(_ => _.Subject.Should().BeEquivalentTo(Test.NewTDone));
            original.Should().AllSatisfy(_ => _.Subject.Should().BeEquivalentTo(Test.NewTDone));
        }


        [Test]
        public void DoForEachAsync_Funcs()
        {
            IEnumerable<Optional<TType>> original = new[] { Test.NewT.ToOptional(), Test.NewT.ToOptional(), Test.NewT.ToOptional(), Test.NewT.ToOptional() };

            var postDo = original
                            .ToTask()
                            .DoOptionalForEachAsync(originalItem        => UpdateDesc(originalItem, Test.DONE),
                                            itemWihtUpdatedDesc => MergeDesc(itemWihtUpdatedDesc, "."))
                            .Result;

            postDo.Should().HaveCount(4);
            postDo.Should().AllSatisfy(_ => _.Subject.TDesc.Should().BeEquivalentTo(Test.DONE + "."));
            original.Should().AllSatisfy(_ => _.Subject.TDesc.Should().BeEquivalentTo(Test.DONE + "."));
        }

    }
}