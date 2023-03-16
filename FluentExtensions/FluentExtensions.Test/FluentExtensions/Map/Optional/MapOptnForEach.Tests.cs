using FluentAssertions;
using FluentCoding;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.NetworkInformation;

namespace FluentCoding.Test.FluentExtensions.Map.Optional
{
    [ExcludeFromCodeCoverage]
    public class MapOptnForEach_Optional_Tests
    {

        [Test]
        public void MapOptnForEach_NullEnumerable()
        {
            var enumerable = Test.GetDefault<IEnumerable<TType>>().ToOptionalForEach();
            var mappedResult = enumerable.MapOptnForEach(_ => _.TDesc + "MAP");
            mappedResult.Should().BeNull();
        }

        [Test]
        public void MapOptnForEach_EmptyEnumerable()
        {
            "Ciao".ToOptional();
            Optional<string>.None();
            Optional<string>.Some("Ciao");

            var enumerable = Test.GetEnumerable<TType>(0).ToOptionalForEach();
            var mappedResult = enumerable.MapOptnForEach(_ => _.TDesc + "MAP");
            mappedResult.Count().Should().Be(0);
        }

        [Test]
        public void MapOptnForEach_Strings()
        {
            var enumerable = Test.GetEnumerable<TType>(4).ToOptionalForEach();
            var mappedResult = enumerable.MapOptnForEach(_ => _.TDesc + "MAP");
            mappedResult.Count().Should().Be(enumerable.Count());
            mappedResult.Should().AllSatisfy(_ => _.Subject.Should().Be(Test.NewT.TDesc + "MAP"));
        }

        [Test]
        public void MapOptnForEach_Object()
        {
            var enumerable = Test.GetEnumerable<TType>(4).ToOptionalForEach();
            var mappedResult = enumerable.MapOptnForEach(_ => new KType() { KDesc = _.TDesc + "MAP" });
            mappedResult.Count().Should().Be(enumerable.Count());
            mappedResult.Should().AllSatisfy(_ =>
                                                {
                                                    _.Subject.KDesc.Should().Be(Test.NewT.TDesc + "MAP");
                                                    _.Subject.Should().BeOfType<KType>();
                                                });
        }

        [Test]
        public void MapOptnForEach_Struct()
        {
            var currentHour = DateTime.Now.Map(_ => $"{_.Day}{_.Hour}");
            var enumerable = Test.GetEnumerable<DateTime>(4).ToOptionalForEach();
            var mappedResult = enumerable.MapOptnForEach(d => d.Map(_ => $"{_.Day}{_.Hour}"));
            mappedResult.Count().Should().Be(enumerable.Count());
            mappedResult.Should().AllSatisfy(_ => _.Subject.Should().Be(currentHour));
        }

    }
}
