using FluentAssertions;
using FluentCoding;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace FluentCodingTest.Do_T
{
    [ExcludeFromCodeCoverage]
    public class DoForAll_Tests
    {
        [Test]
        public void DoForAll_Action()
        {
            TypeT[] original = { Test.T, Test.T, Test.T, Test.T };
            
            var postDo = original.DoForAll(_ => _.DescType = Test.Done);
            postDo.Should().HaveCount(4);
            postDo.Should().AllSatisfy(_ => _.Should().BeEquivalentTo(Test.TDone));
            original.Should().AllSatisfy(_ => _.Should().BeEquivalentTo(Test.TDone));
        }

        [Test]
        public void DoForAll_Actions()
        {
            TypeT[] original = { Test.T, Test.T, Test.T, Test.T };
            
            var postDo = original.DoForAll(_ => _.DescType = Test.Done,
                                           _ => _.DescType += "." );
            postDo.Should().HaveCount(4);
            postDo.Should().AllSatisfy(_ => _.DescType.Should().Be(Test.TDone.DescType+"."));
            original.Should().AllSatisfy(_ => _.DescType.Should().Be(Test.TDone.DescType + "."));
        }

        private TypeT Update(TypeT t, string newDesc)
        {
            t.DescType = newDesc;
            return t;
        }

        [Test]
        public void Do_Action_ObjectFieldValue()
        {
            TypeT[] original = { Test.T, Test.T, Test.T, Test.T };
            var postDo = original.DoForAll(_ => Update(_, Test.Done));
            postDo.Should().HaveCount(4);
            postDo.Should().AllSatisfy(_ => _.Should().BeEquivalentTo(Test.TDone));
            original.Should().AllSatisfy(_ => _.Should().BeEquivalentTo(Test.TDone));
        }


        [Test]
        public void DoForAllMap()
        {

            TypeT[] original = { Test.T, Test.T, Test.T, Test.T };
            List<TypeK> empty = new List<TypeK>();

            var result = original.DoForAllMap(t => Test.K.Do(k => k.DescType = t.DescType));
            result.Should().AllSatisfy(_ =>
            {
                _.Should().BeOfType(typeof(TypeK));
                _.DescType.Should().Be(Test.T.DescType);
            });

            original.Should().AllSatisfy(_ => _.Should().BeEquivalentTo(Test.T));
        }

    }
}