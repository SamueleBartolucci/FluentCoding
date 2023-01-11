using FluentAssertions;
using FluentCoding;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace FluentCodingTest.MapForEachAsync_T
{
    [ExcludeFromCodeCoverage]
    public class MapForEachAsync_Tests
    {
        [Test]
        public void MapForEachAsync_NullEnumerable()
        {
            var enumerable = Test.GetDefault<IEnumerable<TypeT>>();
            var mappedResult = enumerable.ToTask().MapForEachAsync(_ => _.DescType + "MAP").Result;
            mappedResult.Should().BeNull();            
        }

        [Test]
        public void MapForEachAsync_EmptyEnumerable()
        {
            var enumerable = Test.GetEnumerable<TypeT>(0);
            var mappedResult = enumerable.ToTask().MapForEachAsync(_ => _.DescType + "MAP").Result;
            mappedResult.Count().Should().Be(0);            
        }

        [Test]
        public void MapForEachAsync_Strings()
        {
            var enumerable = Test.GetEnumerable<TypeT>(4);
            var mappedResult = enumerable.ToTask().MapForEachAsync(_ => _.DescType+"MAP").Result;
            mappedResult.Count().Should().Be(enumerable.Count());
            mappedResult.Should().AllSatisfy(_ => _.Should().Be(Test.T.DescType + "MAP"));
        }

        [Test]
        public void MapForEachAsync_Object() 
        {
            var enumerable = Test.GetEnumerable<TypeT>(4);
            var mappedResult = enumerable.ToTask().MapForEachAsync(_ => new TypeK() { DescType = _.DescType+"MAP" }).Result;
            mappedResult.Count().Should().Be(enumerable.Count());
            mappedResult.Should().AllSatisfy(_ =>
                                                {
                                                    _.DescType.Should().Be(Test.T.DescType + "MAP");
                                                    _.Should().BeOfType<TypeK>();
                                                });
        }

        [Test]
        public void MapForEachAsync_Struct()
        {
            var currentHour = DateTime.Now.Map(_ => $"{_.Day}{_.Hour}");
            var enumerable = Test.GetEnumerable<DateTime>(4);
            var mappedResult = enumerable.ToTask().MapForEachAsync(d => d.Map(_ => $"{_.Day}{_.Hour}")).Result;
            mappedResult.Count().Should().Be(enumerable.Count());
            mappedResult.Should().AllSatisfy(_ => _.Should().Be(currentHour));
        }

    }
}
