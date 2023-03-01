using FluentAssertions;
using FluentCoding;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace FluentCodingTest.Do_T
{
    [ExcludeFromCodeCoverage]
    public class DoForEach_Optional_Tests
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
            Optional<TType>[] original =
                {
                    Test.NewT.ToOptional(),
                    Test.NewT.ToOptional(),
                    Test.NewT.ToOptional(),
                    Test.NewT.ToOptional()
                };
            
            var postDo = original.DoOptionalForEach(_ => _.TDesc = Test.DONE);
            postDo.Should().HaveCount(4);
            postDo.Should().AllSatisfy(_ => _.Subject.Should().BeEquivalentTo(Test.NewTDone));
            original.Should().AllSatisfy(_ => _.Subject.Should().BeEquivalentTo(Test.NewTDone));
        }

        [Test]
        public void DoForEach_Actions()
        {
            Optional<TType>[] original =
                {
                    Test.NewT.ToOptional(),
                    Test.NewT.ToOptional(),
                    Test.NewT.ToOptional(),
                    Test.NewT.ToOptional()
                };

            var postDo = original.DoOptionalForEach(_ => _.TDesc = Test.DONE,
                                           _ => _.TDesc += "." );
            postDo.Should().HaveCount(4);
            postDo.Should().AllSatisfy(_ => _.Subject.TDesc.Should().Be(Test.NewTDone.TDesc+"."));
            original.Should().AllSatisfy(_ => _.Subject.TDesc.Should().Be(Test.NewTDone.TDesc + "."));
        }


        [Test]
        public void DoForEach_Func()
        {
            Optional<TType>[] original =
               {
                    Test.NewT.ToOptional(),
                    Test.NewT.ToOptional(),
                    Test.NewT.ToOptional(),
                    Test.NewT.ToOptional()
                };

            var postDo = original.DoOptionalForEach(_ => UpdateDesc(_, Test.DONE));
            postDo.Should().HaveCount(4);
            postDo.Should().AllSatisfy(_ => _.Subject.Should().BeEquivalentTo(Test.NewTDone));
            original.Should().AllSatisfy(_ => _.Subject.Should().BeEquivalentTo(Test.NewTDone));
        }


        [Test]
        public void DoForEach_Funcs()
        {
            Optional<TType>[] original =
                 {
                    Test.NewT.ToOptional(),
                    Test.NewT.ToOptional(),
                    Test.NewT.ToOptional(),
                    Test.NewT.ToOptional()
                };

            var postDo = original.DoOptionalForEach(_ => UpdateDesc(_, Test.DONE),
                                           _ => MergeDesc(_, "."));
            postDo.Should().HaveCount(4);
            postDo.Should().AllSatisfy(_ => _.Subject.TDesc.Should().BeEquivalentTo(Test.DONE + "."));
            original.Should().AllSatisfy(_ => _.Subject.TDesc.Should().BeEquivalentTo(Test.DONE + "."));
        }

    }
}