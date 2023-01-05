using FluentAssertions;
using FluentCoding;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;



namespace FluentCodingTest.ForEach_T
{
    [ExcludeFromCodeCoverage]
    public class ForEach_Tests
    {    

        [Test]
        public void ForEach()
        {
            TypeT[] original = { Test.T, Test.T, Test.T, Test.T };
            List<TypeT> empty = new List<TypeT>();
            
            original.ForEach(t => empty.Add(t));
            empty.Count.Should().Be(4);
            empty.Should().AllSatisfy(_ => _.Should().BeEquivalentTo(Test.T));
        }

        [Test]
        public void ForEachMap()
        {

            TypeT[] original = { Test.T, Test.T, Test.T, Test.T };
            List<TypeK> empty = new List<TypeK>();

            var result = original.ForEachMap(t => Test.K.Do(k => k.DescType = t.DescType));
            result.Should().AllSatisfy(_ =>
                {
                    _.Should().BeOfType(typeof(TypeK));
                    _.DescType.Should().Be(Test.T.DescType);
                });

            original.Should().AllSatisfy(_ => _.Should().BeEquivalentTo(Test.T));
        }
    }
}

