using FluentAssertions;
using FluentCoding;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace FluentCodingTest.MapForEach_T
{
    [ExcludeFromCodeCoverage]
    public class MapForEach_Tests
    {
        [Test]
        public void MapForEach_NullEnumerable()
        {
            var enumerable = Test.GetDefault<IEnumerable<TypeT>>();
            var mappedResult = enumerable.MapForEach(_ => _.DescType + "MAP");
            mappedResult.Should().BeNull();            
        }

        [Test]
        public void MapForEach_EmptyEnumerable()
        {
            var enumerable = Test.GetEnumerable<TypeT>(0);
            var mappedResult = enumerable.MapForEach(_ => _.DescType + "MAP");
            mappedResult.Count().Should().Be(0);            
        }

        [Test]
        public void MapForEach_Strings()
        {
            var enumerable = Test.GetEnumerable<TypeT>(4);
            var mappedResult = enumerable.MapForEach(_ => _.DescType+"MAP");
            mappedResult.Count().Should().Be(enumerable.Count());
            mappedResult.Should().AllSatisfy(_ => _.Should().Be(Test.T.DescType + "MAP"));
        }

        [Test]
        public void MapForEach_Object() 
        {
            var enumerable = Test.GetEnumerable<TypeT>(4);
            var mappedResult = enumerable.MapForEach(_ => new TypeK() { DescType = _.DescType+"MAP" });
            mappedResult.Count().Should().Be(enumerable.Count());
            mappedResult.Should().AllSatisfy(_ =>
                                                {
                                                    _.DescType.Should().Be(Test.T.DescType + "MAP");
                                                    _.Should().BeOfType<TypeK>();
                                                });
        }

        [Test]
        public void MapForEach_Struct()
        {
            var currentHour = DateTime.Now.Map(_ => $"{_.Day}{_.Hour}");
            var enumerable = Test.GetEnumerable<DateTime>(4);
            var mappedResult = enumerable.MapForEach(d => d.Map(_ => $"{_.Day}{_.Hour}"));
            mappedResult.Count().Should().Be(enumerable.Count());
            mappedResult.Should().AllSatisfy(_ => _.Should().Be(currentHour));
        }

    }
}
