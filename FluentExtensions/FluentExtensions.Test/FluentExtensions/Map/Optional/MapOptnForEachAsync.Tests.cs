using FluentAssertions;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace FluentCoding.Test.FluentExtensions.Map.Optional
{
    [ExcludeFromCodeCoverage]
    public class MapOptnForEachAsync_Optional_Tests
    {
        [Test]
        public void MapOptnForEachAsync_NullEnumerable()
        {
            var enumerable = Test.GetDefault<IEnumerable<TType>>().ToOptionalForEach();
            var mappedResult = enumerable.ToTask().MapOptnForEachAsync(_ => _.TDesc + "MAP").Result;
            mappedResult.Should().BeNull();
        }

        [Test]
        public void MapOptnForEachAsync_EmptyEnumerable()
        {
            var enumerable = Test.GetEnumerable<TType>(0).ToOptionalForEach();
            var mappedResult = enumerable.ToTask().MapOptnForEachAsync(_ => _.TDesc + "MAP").Result;
            mappedResult.Count().Should().Be(0);
        }

        [Test]
        public void MapOptnForEachAsync_Strings()
        {
            var enumerable = Test.GetEnumerable<TType>(4).ToOptionalForEach();
            var mappedResult = enumerable.ToTask().MapOptnForEachAsync(_ => _.TDesc + "MAP").Result;
            mappedResult.Count().Should().Be(enumerable.Count());
            mappedResult.Should().AllSatisfy(_ => _.Subject.Should().Be(Test.NewT.TDesc + "MAP"));
        }

        [Test]
        public void MapOptnForEachAsync_Object()
        {
            var enumerable = Test.GetEnumerable<TType>(4).ToOptionalForEach();
            var mappedResult = enumerable.ToTask().MapOptnForEachAsync(_ => new KType() { KDesc = _.TDesc + "MAP" }).Result;
            mappedResult.Count().Should().Be(enumerable.Count());
            mappedResult.Should().AllSatisfy(_ =>
                                                {
                                                    _.Subject.KDesc.Should().Be(Test.NewT.TDesc + "MAP");
                                                    _.Subject.Should().BeOfType<KType>();
                                                });
        }

        [Test]
        public void MapOptnForEachAsync_Struct()
        {
            var currentHour = DateTime.Now.Map(_ => $"{_.Day}{_.Hour}");
            var enumerable = Test.GetEnumerable<DateTime>(4).ToOptionalForEach();
            var mappedResult = enumerable.ToTask().MapOptnForEachAsync(d => d.Map(_ => $"{_.Day}{_.Hour}")).Result;
            mappedResult.Count().Should().Be(enumerable.Count());
            mappedResult.Should().AllSatisfy(_ => _.Subject.Should().Be(currentHour));
        }

    }
}
