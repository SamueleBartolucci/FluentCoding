using FluentAssertions;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace FluentCoding.Test.FluentExtensions.Map.Generics
{
    [ExcludeFromCodeCoverage]
    public class MapForEach_Tests
    {
        [Test]
        public void MapForEach_NullEnumerable()
        {
            var enumerable = Test.GetDefault<IEnumerable<TType>>();
            var mappedResult = enumerable.MapForEach(_ => _.TDesc + "MAP");
            mappedResult.Should().BeNull();
        }

        [Test]
        public void MapForEach_EmptyEnumerable()
        {
            var enumerable = Test.GetEnumerable<TType>(0);
            var mappedResult = enumerable.MapForEach(_ => _.TDesc + "MAP");
            mappedResult.Count().Should().Be(0);
        }

        [Test]
        public void MapForEach_Strings()
        {
            var enumerable = Test.GetEnumerable<TType>(4);
            var mappedResult = enumerable.MapForEach(_ => _.TDesc + "MAP");
            mappedResult.Count().Should().Be(enumerable.Count());
            mappedResult.Should().AllSatisfy(_ => _.Should().Be(Test.NewT.TDesc + "MAP"));
        }

        [Test]
        public void MapForEach_Object()
        {
            var enumerable = Test.GetEnumerable<TType>(4);
            var mappedResult = enumerable.MapForEach(_ => new KType() { KDesc = _.TDesc + "MAP" });
            mappedResult.Count().Should().Be(enumerable.Count());
            mappedResult.Should().AllSatisfy(_ =>
                                                {
                                                    _.KDesc.Should().Be(Test.NewT.TDesc + "MAP");
                                                    _.Should().BeOfType<KType>();
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
