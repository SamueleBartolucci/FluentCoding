using FluentAssertions;
using FluentCoding;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace FluentCodingTest.Do_T
{
    [ExcludeFromCodeCoverage]
    public class DoForEach_Tests
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
        public void DoForEach_Action()
        {
            TypeT[] original = { Test.T, Test.T, Test.T, Test.T };
            
            var postDo = original.DoForEach(_ => _.DescType = Test.Done);
            postDo.Should().HaveCount(4);
            postDo.Should().AllSatisfy(_ => _.Should().BeEquivalentTo(Test.TDone));
            original.Should().AllSatisfy(_ => _.Should().BeEquivalentTo(Test.TDone));
        }

        [Test]
        public void DoForEach_Actions()
        {
            TypeT[] original = { Test.T, Test.T, Test.T, Test.T };
            
            var postDo = original.DoForEach(_ => _.DescType = Test.Done,
                                           _ => _.DescType += "." );
            postDo.Should().HaveCount(4);
            postDo.Should().AllSatisfy(_ => _.DescType.Should().Be(Test.TDone.DescType+"."));
            original.Should().AllSatisfy(_ => _.DescType.Should().Be(Test.TDone.DescType + "."));
        }


        [Test]
        public void DoForEach_Func()
        {
            TypeT[] original = { Test.T, Test.T, Test.T, Test.T };
            var postDo = original.DoForEach(_ => UpdateDesc(_, Test.Done));
            postDo.Should().HaveCount(4);
            postDo.Should().AllSatisfy(_ => _.Should().BeEquivalentTo(Test.TDone));
            original.Should().AllSatisfy(_ => _.Should().BeEquivalentTo(Test.TDone));
        }


        [Test]
        public void DoForEach_Funcs()
        {
            TypeT[] original = { Test.T, Test.T, Test.T, Test.T };
            var postDo = original.DoForEach(_ => UpdateDesc(_, Test.Done),
                                           _ => MergeDesc(_, "."));
            postDo.Should().HaveCount(4);
            postDo.Should().AllSatisfy(_ => _.DescType.Should().BeEquivalentTo(Test.Done + "."));
            original.Should().AllSatisfy(_ => _.DescType.Should().BeEquivalentTo(Test.Done + "."));
        }

    }
}